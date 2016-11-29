using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;

namespace Vaxplan.Common.IO
{
    public class JsonResourceReader : EmbeddedResourceReader
    {
        public JsonResourceReader() { }

        public JsonResourceReader(Type type) : base(type)
        {
        }
        public JsonResourceReader(Assembly assembly) : base(assembly)
        {
        }

        public override T Read<T>(string pattern)
        {
            var name = GetMatchingResourceName(new Regex(pattern));
            var text = StringResourceByName(name);
            return JsonConvert.DeserializeObject<T>(text);
        }
    }
}
