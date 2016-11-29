using System;
using System.Collections.Generic;
using System.Linq;
using Vaxplan.Common.Collections;
using Vaxplan.Common.IO;

namespace Vaxplan
{
    public static class Refdata
    {
        private static Lazy<scheduleSupportingData> _scheduleSupportingData;
        public static IDictionary<string, antigenSupportingData> Antigens { get; private set; }
        static Refdata()
        {
            _scheduleSupportingData = new Lazy<scheduleSupportingData>(() => GetEmbeddedResource<scheduleSupportingData>("ScheduleSupportingData"));
            Antigens = new LazyDictionary<string, antigenSupportingData>(key => GetEmbeddedResource<antigenSupportingData>(key));
        }

        public static IEnumerable<string> CvxToAntigen(string cvx)
        {
            return _scheduleSupportingData.Value
                .cvxToAntigenMap
                .Where(x => x.cvx == cvx)
                .SelectMany(x => x.association)
                .Select(x => x.antigen);
        }

        public static IEnumerable<string> CvxGroupToAntigen(string cvxGroup)
        {
            return _scheduleSupportingData.Value
                .vaccineGroupToAntigenMap
                .Where(x => x.name == cvxGroup)
                .SelectMany(x => x.antigen);
        }

        public static scheduleSupportingDataVaccineGroup GetCvxGroup(string name)
        {
            return _scheduleSupportingData.Value
                .vaccineGroups
                .FirstOrDefault(x => x.name == name);
        }

        public static IEnumerable<scheduleSupportingDataContraindication> GetContraindications(string antigen)
        {
            return _scheduleSupportingData.Value
                .contraindications
                .Where(x => x.antigen == antigen);
        }

        public static IEnumerable<scheduleSupportingDataLiveVirusConflict> GetLiveVirusConflicts(string cvx)
        {
            return _scheduleSupportingData.Value
                .liveVirusConflicts
                .Where(x => x.current.cvx == cvx);
        }

        private static T GetEmbeddedResource<T>(string pattern)
        {
            var reader = new XmlResourceReader(typeof(T));
            return reader.Read<T>(pattern);
        }
    }
}
