using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskListApp
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Task(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            return $"Title: {Title}\nDescription: {Description}";
        }
    }
}
