using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{

  [ApiController]
  public class TodoController
  {
    public GenericCommandResult Create([FromBody]CreateTodoCommand command, [FromServices]TodoHandler todoHandler)
    {
      command.User = "Diego";
      var commandResult = (GenericCommandResult)todoHandler.Handle(command);
      return commandResult;
    }
    public IEnumerable<TodoItem> GetAll([FromServices]ITodoRepository repository)
    {
      return repository.GelAllUser("Diego");
    }
  }
}