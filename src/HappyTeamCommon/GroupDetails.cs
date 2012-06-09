using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTeamCommon
{
    public class GroupDetails
    {
        public string GroupId { get; set; }

        public string ParentGroupId { get; set; }

        public double Average { get; set; }

        public int Count { get; set; }
    }
}
