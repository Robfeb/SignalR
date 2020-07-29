using System;

namespace SignalR.Models
{
    public class ChatMessage
    {
        public string Message { get; set; }
        public string User { get; set; }
        public DateTimeOffset Sent { get; set; }
    }
}
