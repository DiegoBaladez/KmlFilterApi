using System.Xml.Serialization;

namespace KmlFilterApi.DTO.Tags
{
    public class Point
    {
        [XmlElement("coordinates")]
        public string Coordinates { get; set; }
    }
}
