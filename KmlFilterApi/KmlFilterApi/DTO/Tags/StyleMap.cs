using System.Xml.Serialization;

namespace KmlFilterApi.DTO.Tags
{
    public class StyleMap
    {
        [XmlElement("Pair")]
        public List<Pair> Pairs { get; set; }
    }
}
