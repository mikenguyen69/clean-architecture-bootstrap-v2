using CleanArchitectureV2.Core.Events;
using CleanArchitectureV2.Core.SharedKernel;

namespace CleanArchitectureV2.Core.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public void MarkComplete()
        {
            IsDone = true;
            Events.Add(new ToDoItemCompletedEvent(this));
        }   
    }
}
