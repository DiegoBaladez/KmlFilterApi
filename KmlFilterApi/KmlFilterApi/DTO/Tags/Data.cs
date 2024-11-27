using System.Xml.Serialization;

namespace KmlFilterApi.DTO.Tags
{
    public class Data
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("value")]
        public string Value { get; set; }
    }
}
