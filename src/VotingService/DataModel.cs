using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VotingService
{
    public static class DataModel
    {
        private static readonly string usersFileName;

        public static VoterGroup RootNode{get; private set;}

        private static Dictionary<string, Voter> _voterIndex = new Dictionary<string, Voter>();

        private static Dictionary<string, VoterGroup> _groupIndex = new Dictionary<string, VoterGroup>();

        static DataModel()
        {
            usersFileName = ConfigurationManager.AppSettings["usersxml"];

            //generate dummy for test.. to be used only for testing after the data structures are changed
            //DummyTree();

            //load Voter Tree
            LoadTree();

            BuildIndex(RootNode);
            PopolateAllVotersWithInEachSubGroup(RootNode);
        }
        
        public static void LogData(string id, string value)
        {
            if (_voterIndex.ContainsKey(id))
            {
                _voterIndex[id].Vote = value;
            }
        }
        
        public static VoterGroup GetGroup(string groupId)
        {
            if (_groupIndex.ContainsKey(groupId))
                return _groupIndex[groupId];

            return null;
        }

        private static void DummyTree()
        {
            VoterGroup VoterTreeRoot = new VoterGroup
            {
                GroupId = "Dummy root",
                DirectChildren = new List<Voter>
                {
                    new Voter{Id= "Top Boss"},
                    new Voter{Id= "Second Top Boss"}
                },
                SubGroups = new List<VoterGroup>
                {
                    new VoterGroup
                    {
                        GroupId = "Team 1",
                        DirectChildren = new List<Voter>
                        {
                            new Voter{Id="Employee1"},
                            new Voter{Id="Employee2"}
                        },
                        SubGroups= new List<VoterGroup>
                        {
                            new VoterGroup
                            {
                                GroupId = "SubTeam",
                                DirectChildren = new List<Voter>
                                {
                                    new Voter{Id = "SubTeam Employee1"},
                                    new Voter{Id = "SubTeam Employee2"},
                                }
                            }
                        }
                    },
                    new VoterGroup
                    {
                        GroupId = "Team 2",
                        DirectChildren = new List<Voter>
                        {
                            new Voter{Id="Employee3"},
                            new Voter{Id="Employee4"},
                            new Voter{Id="Employee5"}
                        }
                    }
                }
            };

            XmlSerializer serializer = new XmlSerializer(typeof(VoterGroup));
            TextWriter textWriter = new StreamWriter(usersFileName);
            serializer.Serialize(textWriter, VoterTreeRoot);
            textWriter.Close();
        }

        private static void LoadTree()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(VoterGroup));
            TextReader textReader = new StreamReader(usersFileName);
            RootNode = (VoterGroup)deserializer.Deserialize(textReader);
            textReader.Close();
        }

        private static void BuildIndex(VoterGroup group)
        {
            if (!_groupIndex.ContainsKey(group.GroupId)) _groupIndex[group.GroupId] = group;

            //Build Voter Index
            foreach (var voter in group.DirectChildren)
            {
                _voterIndex[voter.Id] = voter;
            }

            foreach (var subGroup in group.SubGroups)
            {
                BuildIndex(subGroup);
            }
        }

        private static void PopolateAllVotersWithInEachSubGroup(VoterGroup group)
        {
            group.AllVoters = new List<Voter>();
            group.AllVoters.AddRange(group.DirectChildren);

            if (group.SubGroups != null && group.SubGroups.Count > 0)
            {
                group.SubGroups.ForEach(s => s.ParentGroup = group);

                group.SubGroups.ForEach(PopolateAllVotersWithInEachSubGroup);

                group.SubGroups.ForEach(s => group.AllVoters.AddRange(s.AllVoters));
            }
        }

        //todo: persist
    }
}
