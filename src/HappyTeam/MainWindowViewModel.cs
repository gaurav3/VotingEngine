using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Security.Principal;
using HappyTeamCommon;

namespace HappyTeam
{
    public class MainWindowViewModel
    {

        public List<State> States { get { return State.AllStates; } }

        private State selectedState;

        public State SelectedState
        {
            get 
            { 
                return selectedState; 
            }
            set 
            { 
                selectedState = value;

                ServiceProxy.LogData(System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1], value.Id);
            }
        }
    }
}
