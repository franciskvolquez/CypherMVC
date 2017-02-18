using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CypherMVC.Models
{
    public class DashBoardVM
    {
        public IEnumerable<Message> Messages   { get; set; }
        public IEnumerable<Task> Tasks { get; set; }

    }
}