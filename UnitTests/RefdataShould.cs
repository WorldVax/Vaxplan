using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
    }
}
