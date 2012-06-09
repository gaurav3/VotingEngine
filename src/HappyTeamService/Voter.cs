using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HappyTeamService
{
    [XmlRoot("Group")]
    public class VoterGroup
    {
        [XmlAttribute("Id")]
        public string GroupId { get; set; }

        [XmlIgnoreAttribute()]
        public VoterGroup ParentGroup { get; set; }

        [XmlElement("Users")]
        public List<Voter> DirectChildren { get; set; }

        [XmlElement("SubGroups")]
        public List<VoterGroup> SubGroups { get; set; }

        [XmlIgnoreAttribute()]
        public List<Voter> AllVoters { get; set; }

        [XmlIgnoreAttribute()]
        public double Average
        {
            get 
            {
                if (AllVoters == null || AllVoters.Count == 0) return 0;

                return AllVoters.Average(a => Vote.GetVoteValue(a.Vote));
            }
        }
    }

    [XmlRoot("User")]
    public class Voter
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }
        
        [XmlIgnoreAttribute()]
        public string Vote { get; set; }
    }

    public class Vote
    {
        static Dictionary<string, double> VoteValues = new Dictionary<string, double>();

        static Vote()
        {
            var statesString = ConfigurationManager.AppSettings["states"];

            if (string.IsNullOrEmpty(statesString)) return;

            var stateValuePairs = statesString.Split(';');

            foreach (var svp in stateValuePairs)
            {
                var subStrings = svp.Split('=');

                double value;
                if (double.TryParse(subStrings[1], out value))
                {
                    VoteValues[subStrings[0]] = value;
                }
            }
        }

        public static double GetVoteValue(string vote)
        {
            if (!string.IsNullOrEmpty(vote) && VoteValues.ContainsKey(vote))
                return VoteValues[vote];

            return 0;
        }
    }

}
