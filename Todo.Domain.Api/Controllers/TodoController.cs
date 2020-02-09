using System;
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
  [Route("v1/todos")]
  public class TodoController : ControllerBase
  {
    [Route("")]
    [HttpPost]
    public GenericCommandResult Create([FromBody]CreateTodoCommand command, [FromServices]TodoHandler todoHandler)
    {
      command.User = "Diego Rodrigo";
      var commandResult = (GenericCommandResult)todoHandler.Handle(command);
      return commandResult;
    }
    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll([FromServices]ITodoRepository repository)
    {
      return repository.GelAllUser("Diego Rodrigo");
    }
    [Route("done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone([FromServices]ITodoRepository repository)
    {
      return repository.GetAllDone("Diego Rodrigo");
    }
    [Route("undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndone([FromServices]ITodoRepository repository)
    {
      return repository.GetAllUndone("Diego Rodrigo");
    }
    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndoneToday([FromServices]ITodoRepository repository)
    {
      return repository.GetByPeriod("Diego Rodrigo", DateTime.Now.Date, false);
    }
    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUndoneTomorrow([FromServices]ITodoRepository repository)
    {
      return repository.GetByPeriod("Diego Rodrigo", DateTime.Now.Date.AddDays(1), false);
    }
    [Route("markAsDone")]
    [HttpPost]
    public GenericCommandResult MarkAsDone([FromBody]MarkTodoAsDoneCommand command, [FromServices]TodoHandler todoHandler)
    {
      var commandResult = (GenericCommandResult)todoHandler.Handle(command);
      return commandResult;
    }
    [Route("markAsUndone")]
    [HttpPost]
    public GenericCommandResult MarkAsUndone([FromBody]MarkAsUndoneCommand command, [FromServices]TodoHandler todoHandler)
    {
      var commandResult = (GenericCommandResult)todoHandler.Handle(command);
      return commandResult;
    }
  }
}