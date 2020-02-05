using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
  public class GebericCommandResult : ICommandResult
  {
    public GebericCommandResult() { }
    public GebericCommandResult(bool success, int message, object data)
    {
      Success = success;
      Message = message;
      Data = data;
    }

    public bool Success { get; set; }
    public int Message { get; set; }
    public object Data { get; set; }
  }
}