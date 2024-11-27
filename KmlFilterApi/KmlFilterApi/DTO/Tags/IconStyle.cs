using System.Xml.Serialization;

namespace KmlFilterApi.DTO.Tags
{
    public class IconStyle
    {
        [XmlElement("color")]
        public string Color { get; set; }

        [XmlElement("scale")]
        public float Scale { get; set; }

        [XmlElement("Icon")]
        public Icon Icon { get; set; }

        [XmlElement("hotSpot")]
        public HotSpot HotSpot { get; set; }
    }
}
