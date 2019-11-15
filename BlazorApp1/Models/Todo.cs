using System;
namespace BlazorApp1.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
