﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Refdata.SupportingData;

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
            var data = Refdata.AntigensByCvx["05"];
            Assert.IsInstanceOfType(data, typeof(IEnumerable<string>));
        }

        [TestMethod]
        public void GetLiveVirusConflicts()
        {
            var data = Refdata.ConflictsByCvx["03"];
            Assert.IsTrue(data.Count() == 17);
        }
    }
}
