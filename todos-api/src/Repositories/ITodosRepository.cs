using System;
using System.Collections.Generic;
using todos_api.Repositories.Models;

namespace todos_api.Repositories
{
    public interface ITodosRepository
    {
        IObservable<IEnumerable<Todo>> GetAllById(int id);
    }
}