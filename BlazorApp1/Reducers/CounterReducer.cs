using Canducci.Blazor.Redux;
namespace BlazorApp1.Reducers
{
    public sealed class CounterActionIncrement : IAction { }
    public sealed class CounterActionDecrement : IAction { }
    public sealed class CounterActionChangeValue : IAction<long>
    {
        public CounterActionChangeValue(long value)
        {
            Value = value;
        }
        public long Value { get; }
    }
    public sealed class CounterReducer : Reducer<long>
    {
        public CounterReducer(long initialValue) : base(initialValue)
        {
        }

        public override long Logical(long value, IAction action)
        {
            switch(action)
            {
                case CounterActionIncrement _:
                    {
                        value++;
                        break;
                    }
                case CounterActionDecrement _:
                    {
                        value--;
                        break;
                    }
                case CounterActionChangeValue v:
                    {
                        value = v.Value;
                        break;
                    }
            }
            return value;
        }
    }
    public interface ICounterStore: IStore<CounterReducer, long> { }
    public sealed class CounterStore : Store<CounterReducer, long>, ICounterStore
    {
        public CounterStore(CounterReducer reducer) : base(reducer)
        {
        }
    }
}
