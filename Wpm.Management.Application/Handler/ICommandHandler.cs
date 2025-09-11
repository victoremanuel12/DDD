namespace Wpm.Management.Application.Handler
{
    public interface ICommandHandler<T>
    {
        Task Handle(T command);
    }
}
