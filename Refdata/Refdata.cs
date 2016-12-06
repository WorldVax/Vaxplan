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
        public static IDictionary<string, scheduleSupportingDataVaccineGroup> VaccineGroups { get; private set; }
        public static MultiValueDictionary<string, scheduleSupportingDataLiveVirusConflict> ConflictsByCvx { get; private set; }
        public static IDictionary<string, scheduleSupportingDataVaccineGroupMap> AntigenByVacccineGroup { get; private set; }
        public static IDictionary<string, scheduleSupportingDataObservation> Observations { get; private set; }

        static Refdata()
        {
            // Get the antigen series records.
            Antigens = new Dictionary<string, antigenSupportingData>();
            var namer = new Regex(@"AntigenSupportingData- (?<antigen>\w*)\.xml");
            foreach (var name in GetResourceNames("AntigenSupportingData"))
            {
                var antigen = GetEmbeddedResource<antigenSupportingData>(name);
                var antigenName = namer.Match(name).Groups["antigen"].Value;
                Antigens.Add(antigenName, antigen);
            }

            // Build the supporting data library
            var supportingData = GetEmbeddedResource<scheduleSupportingData>("ScheduleSupportingData");

            AntigensByCvx = new Dictionary<string, IList<string>>();
            foreach (var item in supportingData.cvxToAntigenMap)
            {
                AntigensByCvx.Add(item.cvx, item.association.Select(x => x.antigen).ToList());
            }

            VaccineGroups = new Dictionary<string, scheduleSupportingDataVaccineGroup>();
            foreach (var item in supportingData.vaccineGroups)
            {
                VaccineGroups.Add(item.name, item);
            }

            ConflictsByCvx = new MultiValueDictionary<string, scheduleSupportingDataLiveVirusConflict>();
            foreach (var item in supportingData.liveVirusConflicts)
            {
                ConflictsByCvx.Add(item.current.cvx, item);
            }

            AntigenByVacccineGroup = new Dictionary<string, scheduleSupportingDataVaccineGroupMap>();
            foreach (var item in supportingData.vaccineGroupToAntigenMap)
            {
                AntigenByVacccineGroup.Add(item.name, item);
            }

            Observations = new Dictionary<string, scheduleSupportingDataObservation>();
            foreach (var item in supportingData.observations)
            {
                Observations.Add(item.observationCode, item);
            }
        }

        private static T GetEmbeddedResource<T>(string pattern)
        {
            var reader = new XmlResourceReader(typeof(T));
            return reader.Read<T>(pattern);
        }

        private static IEnumerable<string> GetResourceNames(string pattern)
        {
            var reader = new XmlResourceReader(typeof(antigenSupportingData));
            return reader.GetMatchingResourceNames(new Regex(pattern));
        }
    }
}
