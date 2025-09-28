using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedCommon.WorkingItems
{
    public class Workspace : IOwner, ITaskOwner
    {
        public string WorkspaceId { get; set; } // unique identifier for the workspace, we may want to just set this to an Int or use GUIDs but string is ok for now
        public string Name { get; set; } // name of the workspace
        public string Description { get; set; } // description of the workspace
        public DateTime CreatedAt { get; set; } // timestamp of when the workspace was created
        public List<IMessage> ChatMessageHistory { get; set; } // list of chat messages associated with this workspace

        private TaskList _tasks;
        public TaskList Tasks
        {
            get => _tasks ??= new TaskList(this); // lazy-init for non-JSON scenarios
            set
            {
                // when deserializing, JSON sets this property; ensure owner is bound
                _tasks = value ?? new TaskList(this);
                _tasks._owner = this;
            }
        }

        [JsonConstructor]
        public Workspace() { }


        #region ITaskOwner Implementation
        public bool IsChildTask { get; set; } // indicates if this task is a child task or not (will be either child task, or parent task/workspace)

        #endregion

        #region IOwner Implementation
        public string OwnerId { get; set; }
        public string ParentTaskId { get; set; }
        public string ParentWorkspaceId { get; set; }
        public string ParentGroupId { get; set; }
        #endregion
    }
}
