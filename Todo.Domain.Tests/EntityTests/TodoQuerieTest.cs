using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.EntityTests
{

  [TestClass]
  public class TodoQuerieTest
  {
    private readonly List<TodoItem> _items;
    public TodoQuerieTest()
    {
      _items = new List<TodoItem>();
      _items.Add(new TodoItem("Titulo 1", DateTime.Now, "Diego Rodrigo"));
      _items.Add(new TodoItem("Titulo 2", DateTime.Now, "Diego Russo"));
      _items.Add(new TodoItem("Titulo 3", DateTime.Now, "Diego Normal"));
      _items.Add(new TodoItem("Titulo 4", DateTime.Now, "Diego felix"));
      _items.Add(new TodoItem("Titulo 5", DateTime.Now, "Diego Rodrigo"));
    }

    [TestMethod]
    public void Dada_a_conslta_deve_retornar_tarefas_apenas_do_diego_rodrigo()
    {
      var result = _items.AsQueryable().Where(TodoQueries.GelAllUser("Diego Rodrigo"));
      Assert.AreEqual(2, result.Count());
    }

  }
}