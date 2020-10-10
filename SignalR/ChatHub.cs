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
            await Clients.All.SendAsync(
                "ReceiveMessage",
                "Chat Room",
                DateTimeOffset.UtcNow,
                "Hi There! What Can I help you with?");
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
                SenderName = name,
                Text = text,
                SentAt = DateTimeOffset.UtcNow
            };

            // Broadcast to all clients
            await Clients.All.SendAsync(
                "ReceiveMessage",
                message.SenderName,
                message.SentAt,
                message.Text);

        }
    }
}
