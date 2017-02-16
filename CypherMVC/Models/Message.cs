﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CypherMVC.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int MessageThreadId { get; set; }
        public DateTime? Created { get; set; }

        public virtual MessageThread MessageThread { get; set; }

    }
}