namespace Canducci.Blazor.Redux
{
    public interface IAction
    {
    }

    public interface IAction<T>: IAction
    {
        T Value { get; }
    }
}
