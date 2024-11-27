using KmlFilterApi.Constants;
using KmlFilterApi.Constants.Enum;
using KmlFilterApi.DTO.Tags;
using KmlFilterApi.DTO.Files;
using KmlFilterApi.Exceptions;
using KmlFilterApi.Interfaces;
using KmlFilterApi.Constants.LogMessages;
using System.Xml.Linq;
using System.Text.Json;

namespace KmlFilterApi.Service
{
    public class KmlFileService : IKmlFileService
    {
        private readonly string _kmlFile = XDocument.Load(KmlFileDirectory.filePath).ToString();
        private readonly IKmlFileRefactorService _kmlFileRefactorService;

        public KmlFileService(IKmlFileRefactorService kmlFileRefactorService)
        {
            _kmlFileRefactorService = kmlFileRefactorService;
        }

        public async Task<string> ReadFile(IFormFile kmlFile)
        {
            if (kmlFile == null || kmlFile.Length == 0)
            {
                throw new KmlFileNullOrEmptyException(GeneralLogMessages.KmlFileNullOrEmpty);
            }

            using (var stream = kmlFile.OpenReadStream())
            using (var reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task<Kml> Export(string parameter, string value, IFormFile kmlFile)
        {
            try
            {
                var result = XmlSerializerService<Kml>.Deserialize(await ReadFile(kmlFile));
                var filteredFile = Filter(parameter, value, result);
                var newFile = _kmlFileRefactorService.RefactorKml(result, filteredFile);

                return newFile;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Placemark> Filter(string parameter, string value, Kml kml)
        {
            ValidateValues(value, SetParamValidationRule(parameter));

            return kml.Document.Folder.Placemark
             .Where(p => p.ExtendedData.Data.Any(d => d.Name == parameter && d.Value == value))
             .ToList();
        }

        public async Task<string> GetJson(string parameter, string value)
        {
            var result = XmlSerializerService<Kml>.Deserialize(_kmlFile);
            var newFile = _kmlFileRefactorService.RefactorKml(result, Filter(parameter, value, result));

            return JsonSerializer.Serialize(newFile);
        }

        public async Task<List<string>> GetUniqueElements(string parameter)
        {
            var result = XmlSerializerService<Kml>.Deserialize(_kmlFile);

            return result.Document.Folder.Placemark
                   .SelectMany(p => p.ExtendedData.Data)
                   .Where(d => d.Name == parameter)
                   .Select(d => d.Value)
                   .Distinct()
                   .ToList();
        }

        private Dictionary<ValueValidationRules, string> SetParamValidationRule(string parameter)
        {
            if (ValidParameters.PreSelection.Contains(parameter))
            {
                return new Dictionary<ValueValidationRules, string>()
                {
                    { ValueValidationRules.PreSelectionByValidValues, parameter }
                };
            }
            if (ValidParameters.WithPartialMinimalText.Contains(parameter))
            {
                return new Dictionary<ValueValidationRules, string>()
                {
                    { ValueValidationRules.WithPartialMinimalText, parameter }
                };
            }

            throw new ParamValidationException(GeneralLogMessages.ParamValidationError);
        }

        private void ValidateValues(string value, Dictionary<ValueValidationRules, string> paramRulePairs)
        {
            if (paramRulePairs.ContainsKey(ValueValidationRules.WithPartialMinimalText))
            {
                if (value.Length < 3)
                {
                    throw new MinimalLengthException($"{value} {GeneralLogMessages.MinimalLenghError}");
                }
            }
            if (paramRulePairs.ContainsKey(ValueValidationRules.PreSelectionByValidValues))
            {
                if (!GetUniqueElements(paramRulePairs[ValueValidationRules.PreSelectionByValidValues]).Result.Contains(value))
                {
                    throw new PreSelectedException(GeneralLogMessages.PreSelectedNotFound);
                }
            }
        }
    }
}
