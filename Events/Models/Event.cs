using System;
using System.Text.Json.Serialization;

namespace Events.Models
{
    public class Event
    {
        private readonly DateTime creationDate = DateTime.Now;

        [JsonConstructor]
        public Event(string name, int value)
            => (Name, Value) = (name, value);

        //public Event() { }

        public string Name { get; set; }

        public int Value { get; set; }

        public DateTime CreationDate => creationDate;
    }
}
