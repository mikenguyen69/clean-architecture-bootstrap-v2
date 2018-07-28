using CleanArchitectureV2.Api.DTO;
using CleanArchitectureV2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureV2.Tests.Integration.Api
{
    public class ToDoItemsControllerTest : BaseWebControllerTest<ToDoItem>
    {
        [Fact]
        public async Task ListShouldReturnsTwoItems()
        {
            var result = (await GetList("/api/todoitems")).ToList();

            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.Count(a => a.Title == "Test Item 1"));
            Assert.Equal(1, result.Count(a => a.Title == "Test Item 2"));
        }

        [Fact]
        public async Task GetByIdShouldReturnOneItem()
        {
            var result = (await GetById("/api/todoitems/1"));

            Assert.NotNull(result);
            Assert.Equal("Test Item 1", result.Title);
        }

        [Fact]
        public async Task PostShouldAddNewItem()
        {
            var todoItemDto = new ToDoItemDTO()
            {
                Id = 3,
                Title = "Test 3",
                Description = "This is item 3 testing only",
            };

            await Post($"/api/todoitems", todoItemDto);

            var result = (await GetById($"/api/todoitems/{todoItemDto.Id}"));

            Assert.NotNull(result);
            Assert.Equal("Test 3", result.Title);

        }

        [Fact]
        public async Task CompleteShouldMarkItemToBeDone()
        {
            var result = await GetById("/api/todoitems/1/complete");

            Assert.NotNull(result);
            Assert.Equal("Test Item 1", result.Title);
            Assert.True(result.IsDone);
        }

        [Fact]
        public async Task CompleteByPatchShouldAlsoMarkItemToBeDone()
        {
            var result = await GetById("api/todoitems/1");
            
            var response = await Patch("/api/todoitems/complete", result);

            Assert.Equal(response.Id, result.Id);
            Assert.Equal(response.Title, result.Title);
            Assert.True(response.IsDone);
        }
    }
}
