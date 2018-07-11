using CleanArchitectureV2.Core.Entities;
using CleanArchitectureV2.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace CleanArchitectureV2.Api.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(AppDbContext context)
        {
            //AppDbContext context = services
            //    .GetRequiredService<AppDbContext>();
            //context.Database.Migrate();
            if (!context.ToDoItems.Any())
            {
                context.ToDoItems.AddRange(
                    new ToDoItem
                    {
                        Id = 1,
                        Title = "Item 1",
                        Description = "Item 1 Description"
                    },
                    new ToDoItem
                    {
                        Id = 2,
                        Title = "Item 2",
                        Description = "Item 2 Description"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
