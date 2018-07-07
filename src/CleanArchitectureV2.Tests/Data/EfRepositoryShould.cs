using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Moq;
using CleanArchitectureBase.Infrastructure.Data;
using CleanArchitectureBase.Core.Entities;
using CleanArchitectureBase.Core.Interfaces;
using System;

namespace CleanArchitectureBase.Tests.Data
{
    public class EfRepositoryShould
    {
        private AppDbContext _dbContext;

        private EfRepository<ToDoItem> GetRepository()
        {
            var options = CreateNewContextOptions();
            var mockDispatcher = new Mock<IDomainEventDispatcher>();

            _dbContext = new AppDbContext(options, mockDispatcher.Object);

            return new EfRepository<ToDoItem>(_dbContext);

        }

        private DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            // Setup fresh in-memory service provider 
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Builder for the service provider 
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("cleanarchitecture")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [Fact]
        public void AddItemAndGetId()
        {
            var repository = GetRepository();
            var item = new ToDoItem();

            repository.Add(item);

            var newItem = repository.List().FirstOrDefault();

            Assert.Equal(item, newItem);
            Assert.True(newItem.Id > 0);
        }

        [Fact]
        public void UpdateItemAfterAddingIt()
        {
            var repository = GetRepository();
            string initiatedTitle = Guid.NewGuid().ToString();
            var item = new ToDoItem()
            {
                Title = initiatedTitle
            };
            repository.Add(item);

            // detach the items for that we can get different instance 
            _dbContext.Entry(item).State = EntityState.Detached;

            // fetch the item and update its title
            var newItem = repository.List().FirstOrDefault(x => x.Title == initiatedTitle);

            Assert.NotSame(item, newItem);

            var newTitle = Guid.NewGuid().ToString();
            newItem.Title = newTitle;

            repository.Update(newItem);

            var updatedItem = repository.List().FirstOrDefault(x => x.Title == newTitle);

            Assert.NotEqual(item.Title, updatedItem.Title);
            Assert.Equal(item.Id, updatedItem.Id);
        }

        [Fact]
        public void DeleteItemAfterAddingIt()
        {
            var repository = GetRepository();
            string initiatedTitle = Guid.NewGuid().ToString();
            var item = new ToDoItem()
            {
                Title = initiatedTitle
            };
            repository.Add(item);

            repository.Delete(item);

            Assert.DoesNotContain(repository.List(), x => x.Title == initiatedTitle);
        }
    }
}
