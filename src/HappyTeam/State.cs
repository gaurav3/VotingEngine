using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingClient
{
    public class State
    {
        public string Id { get; set; }
        public string Image { get; set; }

        static State()
        {
            AllStates = new List<State>
            {
                new State{Id="Cry", Image="/Resources/Crying32x32.png"},
                new State{Id="Sad", Image="/Resources/Sad32x32.png"},
                new State{Id="Smile", Image="/Resources/Smile32x32.png"},
                new State{Id="BigSmile", Image="/Resources/BigSmile32x32.png"}
            };
        }

        public static List<State> AllStates
        {
            get;
            set;
        }
    }
}
