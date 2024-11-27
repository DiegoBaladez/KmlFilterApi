using System.Xml.Serialization;

namespace KmlFilterApi.DTO.Files
{
    [XmlRoot("kml", Namespace = "http://www.opengis.net/kml/2.2")]
    public class Kml
    {
        [XmlElement("Document")]
        public Tags.Document Document { get; set; }
    }
}
