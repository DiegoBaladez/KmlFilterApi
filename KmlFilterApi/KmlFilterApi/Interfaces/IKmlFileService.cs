using KmlFilterApi.DTO.Tags;
using KmlFilterApi.DTO.Files;

namespace KmlFilterApi.Interfaces
{
    public interface IKmlFileService
    {
        Task<Kml> Export(string parameter, string value, IFormFile kmlFile);
        List<Placemark> Filter(string parameter, string value, Kml kml);
        Task<List<string>> GetUniqueElements(string parameter);
        Task<string> GetJson(string parameter, string value);
        Task<string> ReadFile(IFormFile kmlFile);
    }
}
