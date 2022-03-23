using System;

namespace lab6.Models
{
    public class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
