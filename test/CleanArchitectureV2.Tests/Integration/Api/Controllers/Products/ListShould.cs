using CleanArchitectureV2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace CleanArchitectureV2.Tests.Integration.Api.Controllers.Products
{
    public class ListShould : BaseAction<Product>
    {
        [Fact]
        public async Task ReturnsTwoItems()
        {
            var result = (await GetResult("/api/products")).ToList();

            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.Count(a => a.Name == "Test Product 1"));
            Assert.Equal(1, result.Count(a => a.Name == "Test Product 2"));
        }
    }
}
