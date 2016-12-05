using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Vaxplan.Common.IO
{
    public class XmlResourceReader : EmbeddedResourceReader
    {
        public XmlResourceReader() { }

        public XmlResourceReader(Type type) : base(type)
        {
        }

        public XmlResourceReader(Assembly assembly) : base(assembly)
        {
        }
        
        public override T Read<T>(string pattern)
        {
            var name = GetMatchingResourceName(new Regex(pattern));
            var stream = ResourceStreamByName(name);
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stream);
        }
    }
}
