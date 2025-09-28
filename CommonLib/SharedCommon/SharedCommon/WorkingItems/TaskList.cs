using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SharedCommon.WorkingItems
{
    /// <summary>
    /// Since Tasks have a list of child tasks, we want to enforce some rules on how that list is managed.
    /// This is a simple implementation of IList to get us started, but we can expand it later as needed.
    /// Basically, the TaskList will need to be passed a reference to the parent task so that we can determined
    /// if it's a child task or not. This will have to be done through out the code as things develop. Maybe
    /// we can do away with this later if it's overkill though.
    /// </summary>
    public class TaskList : IList<Tasks>
    {
        public List<Tasks> _items = new();
        public IOwner? _owner { get; set; }

        public TaskList() { }

        // Accept any IOwner (Workspace, Tasks, etc.). Caller can pass a Tasks instance when creating
        // a TaskList that belongs to a Tasks parent.
        public TaskList(IOwner owner)
        {
            _owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public Tasks this[int index]
        {
            get => _items[index];
            set
            {
                if (value is null) throw new ArgumentNullException(nameof(value));
                EnsureOwnerCanHaveChildren();
                EnsureNoSubChildren(value);

                var previous = _items[index];
                UnsetChildFlags(previous);

                SetChildFlags(value);
                _items[index] = value;
            }
        }

        public int Count => _items.Count;

        public bool IsReadOnly => false;

        public void Add(Tasks item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            EnsureOwnerCanHaveChildren();
            EnsureNoSubChildren(item);

            SetChildFlags(item);
            _items.Add(item);
        }

        public void Clear()
        {
            foreach (var child in _items)
                UnsetChildFlags(child);

            _items.Clear();
        }

        public bool Contains(Tasks item) => _items.Contains(item);

        public void CopyTo(Tasks[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

        public IEnumerator<Tasks> GetEnumerator() => _items.GetEnumerator();

        public int IndexOf(Tasks item) => _items.IndexOf(item);

        public void Insert(int index, Tasks item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            EnsureOwnerCanHaveChildren();
            EnsureNoSubChildren(item);

            SetChildFlags(item);
            _items.Insert(index, item);
        }

        public bool Remove(Tasks item)
        {
            if (item is null) return false;
            var removed = _items.Remove(item);
            if (removed)
                UnsetChildFlags(item);
            return removed;
        }

        public void RemoveAt(int index)
        {
            var item = _items[index];
            UnsetChildFlags(item);
            _items.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // If the owner implements ITaskOwner and it is marked as a child, it cannot have children.
        private void EnsureOwnerCanHaveChildren()
        {
            if (_owner is ITaskOwner taskOwner && taskOwner.IsChildTask)
                throw new InvalidOperationException("The owner task is itself a child task and cannot have child tasks.");
        }

        // Prevent adding an item that already has child tasks (no deeper than one level).
        private static void EnsureNoSubChildren(Tasks item)
        {
            if (item.ChildTasks != null && item.ChildTasks.Count > 0)
                throw new ArgumentException("A child task cannot have its own child tasks; only one level of nesting is allowed.", nameof(item));
        }

        // If owner is a Tasks instance, mark the added item as a child and set ParentTaskId.
        // If owner is a Workspace (or any IOwner that is not Tasks) the added item is kept as top-level.
        private void SetChildFlags(Tasks child)
        {
            if (_owner is Tasks parentTask)
            {
                // owner is a Tasks => child relationship
                child.IsChildTask = true;
                child.ParentTaskId = parentTask.TaskId;
            }
            else
            {
                // owner is a Workspace (or null) => not a child task
                child.IsChildTask = false;
                child.ParentTaskId = null;
            }
        }

        // Only unset flags if they point to this owner (avoid clobbering state set elsewhere).
        private void UnsetChildFlags(Tasks child)
        {
            if (_owner is Tasks parentTask && child.ParentTaskId == parentTask.TaskId)
            {
                child.ParentTaskId = null;
                child.IsChildTask = false;
            }
        }
    }
}