using BlazorApp1.Models;
using Canducci.Blazor.Redux;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BlazorApp1.Reducers
{
    public sealed class ListOfTodoActionAdd : IAction<Todo>
    {
        public ListOfTodoActionAdd(Todo value)
        {
            Value = value;
        }
        public Todo Value { get; }
    }
    public sealed class ListOfTodoActionEdit : IAction<Todo>
    {
        public ListOfTodoActionEdit(Todo value)
        {
            Value = value;
        }
        public Todo Value { get; }
    }
    public sealed class ListOfTodoActionDelete : IAction<Todo>
    {
        public ListOfTodoActionDelete(Todo value)
        {
            Value = value;
        }
        public Todo Value { get; }
    }
    public sealed class ListOfTodoActionChangeInitialValue : IAction<IReadOnlyList<Todo>>
    {        
        public ListOfTodoActionChangeInitialValue(IReadOnlyList<Todo> value)
        {
            Value = value;
        }

        public IReadOnlyList<Todo> Value { get; }
    }
    public sealed class ListOfTodoReducer : Reducer<IReadOnlyList<Todo>>
    {
        public ListOfTodoReducer(IReadOnlyList<Todo> initialValue) : base(initialValue)
        {
        }
        public override IReadOnlyList<Todo> Logical(IReadOnlyList<Todo> value, IAction action)
        {
            
            switch (action)
            {
                case ListOfTodoActionAdd v:
                    {
                        value = value
                            .ToImmutableArray()
                            .Add(v.Value);
                        break;
                    }
                case ListOfTodoActionEdit v:
                    {
                        var p = value
                            .ToImmutableList()
                            .Find(x => x.Id == v.Value.Id);

                        if (p != null)
                        {
                            p.Done = v.Value.Done;
                            p.Description = v.Value.Description;
                        }
                        break;
                    }
                case ListOfTodoActionDelete v:
                    {
                        value = value
                            .ToImmutableArray()
                            .Remove(v.Value);

                        break;
                    }
                case ListOfTodoActionChangeInitialValue items:
                    {
                        value = items.Value;
                        break;
                    }
            }
            return value;
        }
    }
    public interface IListOfTodoStore : IStore<ListOfTodoReducer, IReadOnlyList<Todo>> { }
    public sealed class ListOfTodoStore : Store<ListOfTodoReducer, IReadOnlyList<Todo>>, IListOfTodoStore
    {
        public ListOfTodoStore(ListOfTodoReducer reducer) : base(reducer)
        {
        }
    }
}
