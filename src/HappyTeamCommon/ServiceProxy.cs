using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using HappyTeamCommon;

namespace HappyTeamCommon
{
    public class ServiceProxy
    {
        static ILoggingService httpProxy;

        static ServiceProxy()
        {
            ChannelFactory<ILoggingService> httpFactory =
                                                new ChannelFactory<ILoggingService>(
                                                new BasicHttpBinding(),
                                                new EndpointAddress(
                                                "http://localhost:8090/LogData"));

            httpProxy = httpFactory.CreateChannel();
        }

        public static void LogData(string id, string value)
        {
            httpProxy.LogData(id, value);
        }

        public static HeatMapInfo GetRootHeatMapInfo()
        {
            return httpProxy.GetRootHeatMapInfo();
        }

        public static HeatMapInfo GetGroupHeatMapInfo(string groupdId)
        {
            return httpProxy.GetHeatMapInfo(groupdId);
        }
    }
}
