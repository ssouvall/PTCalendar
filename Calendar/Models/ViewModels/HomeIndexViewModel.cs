using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Models.ViewModels
{
  //  events: [
  //  { // this object will be "parsed" into an Event Object
  //    title: 'The Title', // a property!
  //    start: '2018-09-01', // a property!
  //    end: '2018-09-02' // a property! ** see important note below about 'end' **
  //  }
  //]
    public class HomeIndexViewModel
    {
        public Event Event { get; set; }
        public EventData[] events { get; set; }
    }

    public class EventData
    {
        public string id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }

}
