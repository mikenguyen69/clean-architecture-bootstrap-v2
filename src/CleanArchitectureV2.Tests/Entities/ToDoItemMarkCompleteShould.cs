using CleanArchitectureBase.Core.Entities;
using CleanArchitectureBase.Core.Events;
using Xunit;
using System.Linq;

namespace CleanArchitectureBase.Tests.Entities
{
    public class ToDoItemMarkCompleteShould
    {
        [Fact]
        public void SetIsDoneToTrue()
        {
            var item = new ToDoItem();

            item.MarkComplete();

            Assert.True(item.IsDone);
        }

        [Fact]
        public void RaiseToDoItemCompletedEvent()
        {
            var item = new ToDoItem();

            item.MarkComplete();

            Assert.Single(item.Events);
            Assert.IsType<ToDoItemCompletedEvent>(item.Events.First());
        }
    }
}
