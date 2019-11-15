namespace Canducci.Blazor.Redux
{
    public abstract class Store<TReducer, TValue> : IStore<TReducer, TValue>
        where TReducer: Reducer<TValue>
    {
        public TReducer Reducer { get; }
        public Store(TReducer reducer)
        {
            Reducer = reducer;
        }
        public void Dispatch(IAction action)
        {            
            Reducer.Value = Reducer.Logical(Reducer.Value, action);
        }

        public TValue Value
        {
            get
            {
                return Reducer.Value;
            }
        }        
    }
}
