using CleanArchitectureV2.Core.Entities;
using CleanArchitectureV2.Core.SharedKernel;

namespace CleanArchitectureV2.Core.Events
{
    public class ToDoItemCompletedEvent : BaseDomainEvent
    {
        public ToDoItem CompletedItem { get; set; }

        public ToDoItemCompletedEvent(ToDoItem completedItem)
        {
            CompletedItem = completedItem;
        }

    }
}
