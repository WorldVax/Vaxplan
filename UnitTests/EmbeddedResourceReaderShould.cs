using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vaxplan.Common.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;

namespace Vaxplan.UnitTests
{
    [TestClass]
    public class EmbeddedResourceReaderShould
    {
        const string JSON_RESOURCE = "json";
        const string JSON_RESOURCE_OBJECT = "object.json";
        const string JSON_RESOURCE_ARRAY = "array.json";
        const string XML_RESOURCE_ARRAY = "array.xml";

        [TestMethod]
        public void ReadEmbeddedJsonResourceAsObject()
        {
            var reader = new JsonResourceReader(typeof(Aclass));
            var data = reader.Read<Aclass>(JSON_RESOURCE_OBJECT);
            Assert.IsTrue(data.key.StartsWith("one, two"));
        }

        [TestMethod]
        public void ReadEmbeddedJsonResourceAsList()
        {
            var reader = new JsonResourceReader(typeof(Aclass));
            var data = reader.Read<Aclass[]>(JSON_RESOURCE_ARRAY);
            Assert.IsTrue(data.Length > 1);
            var item = data[0];
            Assert.IsTrue(item.key.StartsWith("one"));
        }
    }
}
