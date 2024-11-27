using System.Xml.Serialization;

namespace KmlFilterApi.DTO.Tags
{
    public class Icon
    {
        [XmlElement("href")]
        public string Href { get; set; }
    }
}
