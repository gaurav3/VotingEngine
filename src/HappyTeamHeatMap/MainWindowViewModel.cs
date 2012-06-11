using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingEngineCommon;

namespace VotingResultsHeatMap
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object syncLock = new object();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            PopulateData();
        }

        public GroupDetails ThisGroup { get; set; }

        public List<GroupDetails> SubGroups { get; set; }

        public void UpdateGroupId(string groupId)
        {
            lock (syncLock)
            {
                var heatmapInfo = ServiceProxy.GetGroupHeatMapInfo(groupId);

                if (heatmapInfo.SubGroupDetails == null || heatmapInfo.SubGroupDetails.Count == 0) return;

                ThisGroup = heatmapInfo.CurrentGroupDetails;

                SubGroups = heatmapInfo.SubGroupDetails;
             
                OnDataChanged();
            }
        }

        private void PopulateData()
        {
            lock (syncLock)
            {
                var heatmapInfo = ServiceProxy.GetRootHeatMapInfo();

                ThisGroup = heatmapInfo.CurrentGroupDetails;

                SubGroups = heatmapInfo.SubGroupDetails;

                OnDataChanged();
            }
        }

        private void OnDataChanged()
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs("ThisGroup"));
                handler(this, new PropertyChangedEventArgs("SubGroups"));
            }
        }

    }

}
