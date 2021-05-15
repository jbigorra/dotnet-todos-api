using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using todos_api.Repositories.Models;

namespace todos_api.Repositories.InMemory
{
    public class InMemoryTodosRepository : ITodosRepository
    {
        private readonly Dictionary<int,IEnumerable<Todo>> _initialTodos;
        
        public InMemoryTodosRepository(Dictionary<int, IEnumerable<Todo>> initialTodos)
        {
            _initialTodos = initialTodos;
        }

        public IObservable<IEnumerable<Todo>> GetAllById(int id)
        {
            var userExists = _initialTodos.ContainsKey(id);

            return userExists 
                ? Observable.Return(_initialTodos[id]) 
                : Observable.Return(Array.Empty<Todo>());
        }
    }
}