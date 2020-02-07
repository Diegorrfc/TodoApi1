using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTest
{
  [TestClass]
  public class EntityTests
  {
    [TestMethod]
    public void Uma_Nova_Tarefa_Deve_Ser_Criada_Como_Nao_Concluida()
    {
      var todoItem = new TodoItem("Novo Titulo", DateTime.Now, "Usuario");
      Assert.AreEqual(todoItem.Done, false);
    }
  }
}