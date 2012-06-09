using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Serialization;
using System.Configuration;
using HappyTeamCommon;

namespace HappyTeamService
{
    public class LoggingService : ILoggingService
    {
        public void LogData(string id, string value)
        {
            if(id!=null && value!=null)
                DataModel.Publishedvalues[id] = value;
        }

        public HeatMapInfo GetHeatMapInfo(string groupId)
        {
            var group = DataModel.GetGroup(groupId);

            return FetchHeatMap(group);
        }

        public HeatMapInfo GetRootHeatMapInfo()
        {
            var rootNode = DataModel.RootNode;

            return FetchHeatMap(rootNode);
        }

        private HeatMapInfo FetchHeatMap(VoterGroup group)
        {
            if (group == null) return null;

            HeatMapInfo info = new HeatMapInfo();
            
            info.CurrentGroupDetails = FetchGroupDetails(group);

            info.SubGroupDetails = new List<GroupDetails>();

            group.SubGroups.ForEach(s => info.SubGroupDetails.Add(FetchGroupDetails(s)));

            return info;
        }

        private GroupDetails FetchGroupDetails(VoterGroup group)
        {
            var details = new GroupDetails { GroupId = group.GroupId, Average = group.Average, Count = group.AllVoters.Count };

            if (group.ParentGroup != null)
                details.ParentGroupId = group.ParentGroup.GroupId;

            return details;
        }
    }
}
