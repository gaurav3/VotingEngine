using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
        }
    }
}
