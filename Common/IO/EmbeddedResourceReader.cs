using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Vaxplan.Common.IO
{
    public abstract class EmbeddedResourceReader : IEmbeddedResourceReader
    {
        public Assembly TypeContainer { get; set; }

        public EmbeddedResourceReader()
        { }

        public EmbeddedResourceReader(Type type)
        {
            TypeContainer = Assembly.GetAssembly(type);
        }
        
        public EmbeddedResourceReader(Assembly assembly)
        {
            TypeContainer = assembly;
        }

        public IEnumerable<string> GetMatchingResourceNames(Regex pattern)
        {
            return TypeContainer.GetManifestResourceNames().Where(x => pattern.IsMatch(x));
        }

        public string GetMatchingResourceName(Regex pattern)
        {
            var names = GetMatchingResourceNames(pattern).ToList();
            if (names.Count() != 1) throw new ArgumentException("Too many matching resources");
            return names[0];
        }

        public string StringResourceByName(string name)
        {
            return ResourceStreamByName(name).ReadToEnd();
        }

        public StreamReader ResourceStreamByName(string name)
        {
            return new StreamReader(TypeContainer.GetManifestResourceStream(name));
        }

        public abstract T Read<T>(string pattern);
    }
}
