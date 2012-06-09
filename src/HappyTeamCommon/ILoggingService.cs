using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HappyTeamCommon
{
    [ServiceContract]
    public interface ILoggingService
    {
        [OperationContract]
        void LogData(string id, string value);

        [OperationContract]
        HeatMapInfo GetHeatMapInfo(string groupId);

        [OperationContract]
        HeatMapInfo GetRootHeatMapInfo();
    }
}
