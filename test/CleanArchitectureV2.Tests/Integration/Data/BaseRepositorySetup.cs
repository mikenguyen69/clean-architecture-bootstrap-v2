using CleanArchitectureV2.Core.Interfaces;
using CleanArchitectureV2.Core.SharedKernel;
using CleanArchitectureV2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace CleanArchitectureV2.Tests.Integration.Data
{
    public class BaseRepositorySetup<T> where T : BaseEntity
    {
        protected AppDbContext _dbContext;
        protected EfRepository<T> _repository;

        public BaseRepositorySetup()
        {
            var options = CreateNewContextOptions();
            var mockDispatcher = new Mock<IDomainEventDispatcher>();

            _dbContext = new AppDbContext(options, mockDispatcher.Object);

            _repository = new EfRepository<T>(_dbContext);
        }

        protected DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("cleanarchitecture")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }        
    }
}
