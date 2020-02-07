using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
  [TestClass]
  public class CreateTodoHandlerTests
  {

    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo", DateTime.Now, "Diego Rodrigo");
    private readonly Handler _handler = new Handler(new TodoFakeRepository());
    [TestMethod]
    public void Create_Todo_Handler_invalid_Command()
    {
      var handlerResult = (GenericCommandResult)_handler.Handle(_invalidCommand);
      Assert.AreEqual(handlerResult.Success, false);
    }
    [TestMethod]
    public void Create_Todo_HandlerValid_Command()
    {
      var handlerResult = (GenericCommandResult)_handler.Handle(_validCommand);
      Assert.AreEqual(handlerResult.Success, true);
    }
  }
}