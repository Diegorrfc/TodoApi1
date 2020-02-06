using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
  public class CreateTodoComand : Notifiable, ICommand
  {
    public CreateTodoComand() { }

    public CreateTodoComand(string title, DateTime date, string user)
    {
      Title = title;
      Done = false;
      Date = date;
      User = user;
    }

    public string Title { get; set; }
    public bool Done { get; set; }
    public DateTime Date { get; set; }
    public string User { get; set; }

    public void Validate()
    {
      AddNotifications(
        new Contract()
              .Requires()
              .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa")
              .HasMinLen(User, 6, "User", "usuário invalido"));

    }
  }
}

