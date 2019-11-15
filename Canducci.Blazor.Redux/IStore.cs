namespace Canducci.Blazor.Redux
{
    public interface IStore<TReducer, TValue>
        where TReducer: Reducer<TValue>
    {
        TValue Value { get; }

        TReducer Reducer { get; }

        void Dispatch(IAction action);
    }
}