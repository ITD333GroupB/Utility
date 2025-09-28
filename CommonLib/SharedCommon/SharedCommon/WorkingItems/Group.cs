using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedCommon.WorkingItems
{
    public class Group : IOwner
    {
        public string GroupId { get; set; } // unique identifier for the group
        public string Name { get; set; } // name of the group
        public string Description { get; set; } // description of the group
        public List<string> MemberUserIds { get; set; } // list of user IDs that are members of the group
        public List<string> WorkspaceIds { get; set; } // list of workspace IDs that belong to the group
        public DateTime CreatedAt { get; set; } // timestamp of when the group was created

        [JsonConstructor]
        public Group() { }

        #region IOwner Implementation
        public string OwnerId { get; set; }
        public string ParentTaskId { get; set; }
        public string ParentWorkspaceId { get; set; }
        public string ParentGroupId { get; set; }
        #endregion
    }
}
