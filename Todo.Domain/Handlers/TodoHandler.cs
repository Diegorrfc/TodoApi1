using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{

  public class Handler : IHandler<CreateTodoCommand>
  {
    private readonly ITodoRepository _repository;
    public Handler(ITodoRepository todorepository)
    {
      _repository = todorepository;
    }

    public ICommandResult Handle(CreateTodoCommand command)
    {
      command.Validate();
      if (!command.Valid)
        return new GenericCommandResult(false, "Houve um erro na solicitação", command.Notifications);

      TodoItem item = new TodoItem(command.Title, command.Date, command.User);

      _repository.Create(item);

      return new GenericCommandResult(true, "certo", item);
    }
  }
}