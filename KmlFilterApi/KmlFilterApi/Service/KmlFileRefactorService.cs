using KmlFilterApi.DTO.Tags;
using KmlFilterApi.DTO.Files;

namespace KmlFilterApi.Service
{
    public class KmlFileRefactorService : IKmlFileRefactorService
    {
        public Kml RefactorKml(Kml kmlBase, List<Placemark> filteresPlacemarks)
        {
            var newKml = kmlBase;
            newKml.Document.Folder.Placemark = filteresPlacemarks;

            return newKml; 
        }
    }
}
