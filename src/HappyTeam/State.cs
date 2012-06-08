using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTeam
{
    public class State
    {
        public string Id { get; set; }
        public string Image { get; set; }

        static State()
        {
            AllStates = new List<State>
            {
                new State{Id="Cry", Image="/Resources/Cry.png"},
                new State{Id="AboutToCry", Image="/Resources/AboutToCry.png"},
                new State{Id="Smile", Image="/Resources/Smile.png"},
                new State{Id="BigSmile", Image="/Resources/BigSmile.png"}
            };
        }

        public static List<State> AllStates
        {
            get;
            set;
        }
    }
}
