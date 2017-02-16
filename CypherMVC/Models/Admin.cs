using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CypherMVC.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }

        public virtual List<Vote> Votes { get; set; }

    }
}