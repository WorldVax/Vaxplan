﻿using System.Collections.Generic;
using System.Linq;
using Vaxplan.Common.Collections;
using Vaxplan.Common.IO;
using Vaxplan.Testcases;

namespace Vaxplan
{
    public partial class CaseLibrary : LazyDictionary<string, Testcase>
    {
        public static CaseLibrary Testcases { get; private set; }

        static CaseLibrary()
        {
            Testcases = new CaseLibrary();
        }

        private CaseLibrary() : base(ValueFactory) { }

        private static Testcase ValueFactory(string id)
        {
            var reader = new JsonResourceReader(typeof(Testcase));
            return reader.Read<Testcase[]>("testcases").FirstOrDefault(x => x.Id == id);
        }
    }
}
