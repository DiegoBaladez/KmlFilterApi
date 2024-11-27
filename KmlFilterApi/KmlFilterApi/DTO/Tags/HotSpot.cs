using System.Xml.Serialization;

namespace KmlFilterApi.DTO.Tags
{
    public class HotSpot
    {
        [XmlAttribute("x")]
        public int X { get; set; }

        [XmlAttribute("xunits")]
        public string XUnits { get; set; }

        [XmlAttribute("y")]
        public int Y { get; set; }

        [XmlAttribute("yunits")]
        public string YUnits { get; set; }
    }
}
