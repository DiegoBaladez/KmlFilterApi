using System.Xml.Serialization;

namespace KmlFilterApi.DTO.Tags
{
    public class Pair
    {
        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("styleUrl")]
        public string StyleUrl { get; set; }
    }
}
