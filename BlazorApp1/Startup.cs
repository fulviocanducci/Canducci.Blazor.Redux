using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using BlazorApp1.Reducers;
using System.Collections.Generic;
using System.Collections.Immutable;
namespace BlazorApp1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICounterStore, CounterStore>(_ => new CounterStore(new CounterReducer(0)));
            services.AddScoped<IListOfTodoStore, ListOfTodoStore>(_ => new ListOfTodoStore(new ListOfTodoReducer(new List<Models.Todo>().ToImmutableList())));
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
