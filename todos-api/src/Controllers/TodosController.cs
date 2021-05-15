using System;
using System.Collections.Generic;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todos_api.Repositories;
using todos_api.Repositories.Models;

namespace todos_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : Controller
    {
        private readonly ITodosRepository _todosRepository;

        public TodosController(ITodosRepository todosRepository)
        {
            _todosRepository = todosRepository;
        }

        [HttpGet("{userId}")]
        public Task<IEnumerable<Todo>> Get(int userId)
        {
            return _todosRepository.GetAllById(userId).ToTask();
        }
    }
}