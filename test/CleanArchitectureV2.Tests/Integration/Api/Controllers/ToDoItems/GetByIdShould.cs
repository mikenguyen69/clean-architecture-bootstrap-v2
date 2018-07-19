using CleanArchitectureV2.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureV2.Tests.Integration.Api.Controllers.ToDoItems
{

    public class GetByIdShould : BaseAction<ToDoItem>
    {
        [Fact]
        public async Task ReturnOneItem()
        {
            var result = (await GetSingleResult("/api/todoitems/1"));

            Assert.NotNull(result);
            Assert.Equal("Test Item 1", result.Title);
        }
    }
}