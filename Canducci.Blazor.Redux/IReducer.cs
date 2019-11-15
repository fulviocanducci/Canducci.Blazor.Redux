namespace Canducci.Blazor.Redux
{   
    public interface IReducer<T>
    {
        T Value { get; set; }
        T Logical(T value, IAction action);
    }
}
