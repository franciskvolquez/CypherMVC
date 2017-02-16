using System.Collections.Generic;

namespace CypherMVC.Models
{
    public class MessageThread
    {
        public int MessageThreadId { get; set; }

        public virtual List<Message> Messages { get; set; }
    }
}