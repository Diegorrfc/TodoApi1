using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
  public class TodoFakeRepository : ITodoRepository
  {
    public void Create(TodoItem todo)
    {

    }

    public TodoItem GetByIdAndUser(Guid id, string user)
    {
      return new TodoItem("novo Item", DateTime.Now, "Usuário da base");
    }

    public void Update(TodoItem todo)
    {

    }
  }
}