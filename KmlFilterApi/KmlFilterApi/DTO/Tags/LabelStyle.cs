using System.Xml.Serialization;

namespace KmlFilterApi.DTO.Tags
{
    public class LabelStyle
    {
        [XmlElement("scale")]
        public float Scale { get; set; }
    }
}
