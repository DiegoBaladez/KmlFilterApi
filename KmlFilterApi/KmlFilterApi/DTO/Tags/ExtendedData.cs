using System.Xml.Serialization;

namespace KmlFilterApi.DTO.Tags
{
    public class ExtendedData
    {
        [XmlElement("Data")]
        public List<Data> Data { get; set; }
    }
}
