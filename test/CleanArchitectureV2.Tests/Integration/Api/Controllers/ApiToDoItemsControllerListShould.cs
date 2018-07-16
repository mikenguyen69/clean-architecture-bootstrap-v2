using CleanArchitectureV2.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureV2.Tests.Integration.Api.Controllers
{

    public class ApiToDoItemsControllerList : BaseWebTest<ToDoItem>
    {
        [Fact]
        public async Task ReturnsTwoItems()
        {
            var result = (await GetResult("/api/todoitems")).ToList();

            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.Count(a => a.Title == "Test Item 1"));
            Assert.Equal(1, result.Count(a => a.Title == "Test Item 2"));
        }
    }
}