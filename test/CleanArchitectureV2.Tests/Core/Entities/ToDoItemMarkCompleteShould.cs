using CleanArchitectureV2.Core.Entities;
using CleanArchitectureV2.Core.Events;
using System.Linq;
using Xunit;

namespace CleanArchitectureV2.Tests.Core.Entities
{
    public class ToDoItemMarkCompleteShould
    {
        // this is to test after completed then the item must be done
        [Fact]
        public void SetIsDoneToTrue()
        {
            var item = new ToDoItem();

            item.MarkComplete();

            Assert.True(item.IsDone);
        }

        // this is to test the complete event via trigger the item to be completed
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
