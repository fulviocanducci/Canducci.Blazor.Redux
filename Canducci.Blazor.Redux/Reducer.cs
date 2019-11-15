namespace Canducci.Blazor.Redux
{
    public abstract class Reducer<T>: IReducer<T>
    {
        public Reducer(T initialValue)
        {
            Value = initialValue;
        }
        public T Value { get; set; }
        public abstract T Logical(T value, IAction action);
    }
}
