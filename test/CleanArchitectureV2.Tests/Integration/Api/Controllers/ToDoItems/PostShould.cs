﻿using CleanArchitectureV2.Core.Entities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureV2.Tests.Integration.Api.Controllers.ToDoItems
{

    public class PostShould : BaseAction<ToDoItem>
    {
        [Fact]
        public async Task AddNewItem()
        {
            //var result = (await GetResult("/api/todoitems")).ToList();

            //Assert.Equal(2, result.Count());
            //Assert.Equal(1, result.Count(a => a.Title == "Test Item 1"));
            //Assert.Equal(1, result.Count(a => a.Title == "Test Item 2"));
            throw new Exception("Not implemented");
        }
    }
}