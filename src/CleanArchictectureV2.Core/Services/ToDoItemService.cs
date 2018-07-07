using Ardalis.GuardClauses;
using CleanArchitectureV2.Core.Events;
using CleanArchitectureV2.Core.Interfaces;

namespace CleanArchitectureV2.Core.Services
{
    public class ToDoItemService : IHandler<ToDoItemCompletedEvent>
    {
        public void Handle(ToDoItemCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            // Do nothing
        }
    }
}
