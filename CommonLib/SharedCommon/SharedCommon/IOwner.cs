using SharedCommon.WorkingItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedCommon
{
    // this interface can be implemented by any class that has an owner, such as a Group, Workspace, or Task
    // this allows us to easily check if a user or parent object is the owner or holder of an object
    public interface IOwner
    {
        /// <summary>
        /// This is the unique identifier of the user profile Id who owns this object.
        /// </summary>
        public string OwnerId { get; set; } // unique identifier for the owner, we may want to just set this to an Int or use GUIDs but string is ok for now

        /// <summary>
        /// This is the unique identifier of the parent task to a child task.
        /// </summary>
        /// <remarks>This ONLY is ever applied to <see cref="Tasks"/> and is meant to assist with database to backend organization.</remarks>
        public string ParentTaskId { get; set; } // if this object is a sub-task, this will be the unique identifier of the parent task

        /// <summary>
        /// This is the unique identifier of the workspace Id that this object belongs to.
        /// </summary>
        public string ParentWorkspaceId { get; set; }
        /// <summary>
        /// This is the unique identifier of the group Id that this object belongs to.
        /// </summary>
        public string ParentGroupId { get; set; }
    }
}
