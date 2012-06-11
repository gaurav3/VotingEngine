using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VotingEngineCommon
{
    [DataContract]
    public class HeatMapInfo
    {
        [DataMember]
        public GroupDetails CurrentGroupDetails { get; set; }

        [DataMember]
        public List<GroupDetails> SubGroupDetails { get; set; }
    }
}
