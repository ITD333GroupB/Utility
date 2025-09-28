using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedCommon.WorkingItems
{
    /// <summary>
    /// Represents an association between the status of a task and the task itself.
    /// </summary>
    public enum TaskStatus
    {
        NotStarted = 0,
        InProgress = 1,
        OnHold = 2,
        Completed = 3
    } // the numbers are what will appear in the database tables


    public class Tasks : IOwner, ITaskOwner
    {
        public string TaskId { get; set; } // unique identifier for the task, we may want to just set this to an Int or use GUIDs but string is ok for now
        public string Title { get; set; }
        public string Description { get; set; }
        public List<IMessage> Comments { get; set; } // list of comments associated with this task
        public TaskList ChildTasks { get; set; } // if this task has child tasks, they will be stored here
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; } // enums when passed to DB are typically stored as ints (0, 1, 2, 3...)

        [JsonConstructor]
        public Tasks() { }

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
