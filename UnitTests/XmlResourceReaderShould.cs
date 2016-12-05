using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vaxplan.Common.IO;
using Vaxplan.SupportingData.Antigens;
using Vaxplan.SupportingData.Schedule;

namespace Vaxplan.UnitTests
{
    [TestClass]
    public class XmlResourceReaderShould
    {
        [TestMethod]
        public void ReadTheSupportingData()
        {
            var reader = new XmlResourceReader(typeof(scheduleSupportingData));
            var data = reader.Read<scheduleSupportingData>("ScheduleSupportingData");
        }

        [TestMethod]
        public void ReadTheAntigenData()
        {
            var reader = new XmlResourceReader(typeof(antigenSupportingData));
            var data = reader.Read<antigenSupportingData>("Diphtheria");
        }
    }
}
