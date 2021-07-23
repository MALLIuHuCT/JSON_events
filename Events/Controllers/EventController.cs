using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

using Events.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IList<Event> _events;

        public EventController(IList<Event> events)
            => _events = events;

        [HttpGet]
        public int Get()
        {
            if (_events.Count == 0)
                return 0;

            var now = DateTime.Now;
            now.AddSeconds(-now.Second);

            return _events.Where(x => Math.Abs((x.CreationDate - now).TotalMinutes) <= 1)
                .Sum(x => x.Value);
        }

        [HttpPost]
        public List<Event> Post([FromBody] Event addedEvent)
        {
            _events.Add(addedEvent);

            return _events.ToList();
        }
    }
}
