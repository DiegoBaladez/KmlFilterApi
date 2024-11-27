using System.Xml.Serialization;
using KmlFilterApi.Constants.LogMessages;
using KmlFilterApi.Exceptions;

namespace KmlFilterApi.Service
{
    public static class XmlSerializerService<T> where T : class
    {
            public static T Deserialize(string xml)
            {
                if (string.IsNullOrWhiteSpace(xml))
                {
                    throw new ArgumentNullException(GeneralLogMessages.NullOrEmptyXmlString);
                }

                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (var reader = new StringReader(xml))
                    {
                        return serializer.Deserialize(reader) as T;
                    }
                }
                catch (Exception ex)
                {
                    throw new SerializationException(GeneralLogMessages.SerializationError);
                }
            }
    }
}
