using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using todos_api.Controllers;
using todos_api.Repositories.InMemory;
using todos_api.Repositories.Models;

namespace todos_api_tests.Controllers
{
    public class TodosControllerTests
    {
        
        [Test]
        public void Get_Empty_Todos_List()
        {
            const int USER_ID = 1; ;
            var initialTodos = new Dictionary<int, IEnumerable<Todo>>();
            var todosRepository = new InMemoryTodosRepository(initialTodos);
            var sut = new TodosController(todosRepository);

            var result = sut.Get(USER_ID);

            result.Result.Should().BeEmpty();
        }

        [Test]
        public void Get_Todos_List()
        {
            const int USER_ID = 1;
            IEnumerable<Todo> todos = new []{ new Todo() { Id = 1 } };
            var initialTodos = new Dictionary<int, IEnumerable<Todo>>() { { USER_ID, todos } };
            var todosRepository = new InMemoryTodosRepository(initialTodos);
            var sut = new TodosController(todosRepository);

            var result = sut.Get(USER_ID);

            result.Result.Should().NotBeEmpty()
                  .And.HaveCount(1)
                  .And.BeEquivalentTo(new { Id = 1 });
        }
    }
}