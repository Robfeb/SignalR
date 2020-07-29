using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalR.Models;

namespace SignalR
{
    public class ChatHub: Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveMessage", "Chat Room", "Hi There! What Can I help you with?", DateTime.Now);
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string name, string text)
        {
            var message = new ChatMessage
            {
                Message = text,
                User = name,
                Sent = DateTimeOffset.UtcNow
            };
            await Clients.All.SendAsync("ReceiveMessage",message.User,message.Message, message.Sent) ;

        }
    }
}
