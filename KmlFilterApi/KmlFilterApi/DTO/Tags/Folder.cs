using System.Xml.Serialization;

namespace KmlFilterApi.DTO.Tags
{
    public class Folder
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("Placemark")]
        public List<Placemark> Placemark { get; set; }
    }
}
