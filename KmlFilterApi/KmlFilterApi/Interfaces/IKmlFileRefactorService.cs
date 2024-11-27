using KmlFilterApi.DTO.Tags;
using KmlFilterApi.DTO.Files;

namespace KmlFilterApi.Service
{
    public interface IKmlFileRefactorService
    {
        Kml RefactorKml(Kml kmlBase, List<Placemark> filteresPlacemarks);
    }
}