using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests
{
  [TestClass]
  public class CreateTodoCommandTest
  {
    private readonly CreateTodoComand _createCommandInvalid = new CreateTodoComand("", DateTime.Now, "Diego Rodrigo");
    private readonly CreateTodoComand _createCommandValid = new CreateTodoComand("Titulo da tarefa", DateTime.Now, "Diego Rodrigo");
    public CreateTodoCommandTest()
    {
      _createCommandInvalid.Validate();
      _createCommandValid.Validate();
    }
    [TestMethod]
    public void Dado_um_commando_invalido()
    {
      Assert.AreEqual(_createCommandInvalid.Invalid, true);
    }
    [TestMethod]
    public void Dado_um_commando_valido()
    {
      Assert.AreEqual(_createCommandValid.Valid, true);
    }
  }
}
