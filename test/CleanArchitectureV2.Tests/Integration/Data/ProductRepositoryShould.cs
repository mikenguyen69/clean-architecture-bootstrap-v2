using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using CleanArchitectureV2.Core.Entities;

namespace CleanArchitectureV2.Tests.Integration.Data
{
    public class ProductRepositoryShould : BaseRepositorySetup<Product>
    {
        [Fact]
        public void AddProductAndSetId()
        {           
            var item = new Product();

            _repository.Add(item);

            var newItem = _repository.List().FirstOrDefault();

            Assert.Equal(item, newItem);
            Assert.True(newItem.Id > 0);
        }

        [Fact]
        public void UpdateProductAfterAddingIt()
        {
            // add an item
            var initialTitle = Guid.NewGuid().ToString();
            var item = new Product()
            {
                Name= initialTitle
            };
            _repository.Add(item);
            
            // detach the item so we get a different instance
            _dbContext.Entry(item).State = EntityState.Detached;

            // fetch the item and update its title
            var newItem = _repository.List()
                .FirstOrDefault(i => i.Name == initialTitle);
            Assert.NotSame(item, newItem);
            var newTitle = Guid.NewGuid().ToString();
            newItem.Name = newTitle;

            // Update the item
            _repository.Update(newItem);        
            var updatedItem = _repository.List()
                .FirstOrDefault(i => i.Name == newTitle);

            Assert.NotEqual(item.Name, updatedItem.Name);
            Assert.Equal(newItem.Id, updatedItem.Id);
        }

        [Fact]
        public void DeleteProductAfterAddingIt()
        {
            // add an item
            var initialTitle = Guid.NewGuid().ToString();
            var item = new Product()
            {
                Name = initialTitle
            };
            _repository.Add(item);

            // delete the item
            _repository.Delete(item);

            // verify it's no longer there
            Assert.DoesNotContain(_repository.List(), 
                i => i.Name == initialTitle);
        }        
    }
}