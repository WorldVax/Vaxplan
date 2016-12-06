using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Refdata.SupportingData;
using Vaxplan.Common.Collections;
using Vaxplan.Common.IO;

namespace Vaxplan
{
    public static class Refdata
    {
        public static IDictionary<string, IList<string>> AntigensByCvx { get; private set; }
        public static IDictionary<string, antigenSupportingData> Antigens { get; private set; }
        public static scheduleSupportingData SupportingData { get; private set; }
        public static IList<string> AntigenNames { get; private set; }

        static Refdata()
        {
            SupportingData = GetEmbeddedResource<scheduleSupportingData>("ScheduleSupportingData");
            Antigens = new LazyDictionary<string, antigenSupportingData>(GetEmbeddedResource<antigenSupportingData>);

            var reader = new EmbeddedResourceReader(typeof(antigenSupportingData));
            var names = reader.GetMatchingResourceNames(new Regex("AntigenSupportingData"));
            var re = new Regex(@"AntigenSupportingData- (?<antigen>\w*)\.xml");
            AntigenNames = names.Select(x => re.Match(x).Groups["antigen"].Value).ToList();
        }

        
        //public static IEnumerable<string> CvxToAntigen(string cvx)
        //{
        //    throw new NotImplementedException();
        //    //return _scheduleSupportingData.Value.Items
        //    //    .cvxToAntigenMap
        //    //    .Where(x => x.cvx == cvx)
        //    //    .SelectMany(x => x.association)
        //    //    .Select(x => x.antigen);
        //}

        //public static IEnumerable<string> CvxGroupToAntigen(string cvxGroup)
        //{
        //    throw new NotImplementedException();
        //    //return _scheduleSupportingData.Value
        //    //    .vaccineGroupToAntigenMap
        //    //    .Where(x => x.name == cvxGroup)
        //    //    .SelectMany(x => x.antigen);
        //}

        //public static scheduleSupportingDataVaccineGroups GetCvxGroup(string name)
        //{
        //    throw new NotImplementedException();
        //    //return _scheduleSupportingData.Value
        //    //    .vaccineGroups
        //    //    .FirstOrDefault(x => x.name == name);
        //}

        //public static IEnumerable<scheduleSupportingDataLiveVirusConflicts> GetLiveVirusConflicts(string cvx)
        //{
        //    throw new NotImplementedException();
        //    //return _scheduleSupportingData.Value
        //    //    .liveVirusConflicts
        //    //    .Where(x => x.current.cvx == cvx);
        //}

        private static T GetEmbeddedResource<T>(string pattern)
        {
            var reader = new XmlResourceReader(typeof(T));
            return reader.Read<T>(pattern);
        }
    }
}
