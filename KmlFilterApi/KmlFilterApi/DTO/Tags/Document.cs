using System.Xml.Serialization;

namespace KmlFilterApi.DTO.Tags
{
    public class Document
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("Style")]
        public List<Style> Styles { get; set; }

        [XmlElement("StyleMap")]
        public List<StyleMap> StyleMaps { get; set; }

        [XmlElement("Folder")]
        public Folder Folder { get; set; }
    }
}
