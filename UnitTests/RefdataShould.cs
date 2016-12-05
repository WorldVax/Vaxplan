using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Vaxplan.SupportingData.Antigens;

namespace Vaxplan.UnitTests
{
    [TestClass]
    public class RefdataShould
    {
        [TestMethod]
        public void GetAnAntigen()
        {
            var data = Refdata.Antigens["Diphtheria"];
            Assert.IsInstanceOfType(data, typeof(antigenSupportingData));
        }

        [TestMethod]
        public void GetAntigens()
        {
            var data = Refdata.CvxToAntigen("MMR");
            Assert.IsInstanceOfType(data, typeof(IEnumerable<string>));
        }

        [TestMethod]
        public void GetAntigenNames()
        {
            var names = Refdata.AntigenNames.ToList();
            Assert.IsTrue(names.Any());
            Assert.IsTrue(names.Contains("Diphtheria"));
        }
    }
}
