using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{

  public class Handler : IHandler<CreateTodoCommand>, IHandler<UpdateTodoCommand>, IHandler<MarkTodoAsDoneCommand>, IHandler<MarkAsUndoneCommand>
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

    public ICommandResult Handle(UpdateTodoCommand command)
    {
      command.Validate();
      if (!command.Valid)
        return new GenericCommandResult(false, "Houve um erro na solicitação", command.Notifications);

      TodoItem item = _repository.GetByIdAndUser(command.Id, command.User);

      item.UpdateTitle(command.Title);

      _repository.Update(item);

      return new GenericCommandResult(true, "certo", item);
    }

    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
      command.Validate();
      if (!command.Valid)
        return new GenericCommandResult(false, "Houve um erro na solicitação", command.Notifications);

      TodoItem item = _repository.GetByIdAndUser(command.Id, command.User);

      item.MarkAsDone();

      _repository.Update(item);

      return new GenericCommandResult(true, "certo", item);
    }

    public ICommandResult Handle(MarkAsUndoneCommand command)
    {
      command.Validate();
      if (!command.Valid)
        return new GenericCommandResult(false, "Houve um erro na solicitação", command.Notifications);

      TodoItem item = _repository.GetByIdAndUser(command.Id, command.User);

      item.MarkAsUndone();

      _repository.Update(item);

      return new GenericCommandResult(true, "certo", item);
    }
  }
}