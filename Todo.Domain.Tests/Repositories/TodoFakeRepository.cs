using System;
using System.Collections.Generic;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
  public class TodoFakeRepository : ITodoRepository
  {
    public void Create(TodoItem todo)
    {

    }

    public IEnumerable<TodoItem> GelAllUser(string user)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllUndone(string user)
    {
      throw new NotImplementedException();
    }

    public TodoItem GetByIdAndUser(Guid id, string user)
    {
      return new TodoItem("novo Item", DateTime.Now, "Usuário da base");
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
    {
      throw new NotImplementedException();
    }

    public void Update(TodoItem todo)
    {

    }
  }
}