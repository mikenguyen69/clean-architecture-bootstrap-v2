using CleanArchitectureV2.Api.DTO;
using CleanArchitectureV2.Core.Entities;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Newtonsoft.Json;

namespace CleanArchitectureV2.Tests.Integration.Api.Controllers.ToDoItems
{

    public class PostShould : BaseAction<ToDoItem>
    {
        [Fact]
        public async Task AddNewItem()
        {
            var todoItemDto = new ToDoItemDTO()
            {
                Id = 3,
                Title = "Test Item 3",
                Description = "This is item 3 testing only",               
            };

            var response = await _client.PostAsync($"/api/todoitems", GetPayLoad(todoItemDto));
            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);

            var result = await response.Content.ReadAsStringAsync();
            todoItemDto = JsonConvert.DeserializeObject<ToDoItemDTO>(result);

            response.Headers.Location.ToString().Should().BeEquivalentTo($"/api/todoitems/{todoItemDto.Id}");

        }
    }
}