using ChatProtocol;
using System;
using System.Linq;

namespace WpfApp2.MessageHandler
{
    public class ChatMessageHandler : IMessageHandler
    {
        public void Execute(MainWindowViewModel viewModel, IMessage message)
        {
            var chatMessage = message as ChatMessage;
            var user = viewModel.Users.Single(u => u.Id == chatMessage.UserId);
            var username = $"Unbekannt ({chatMessage.UserId})";
            if (user != null)
                username = user.Username;

            viewModel.ChatHistory += $"{username} [{DateTime.Now}]: {chatMessage.Content}{Environment.NewLine}";
        }
    }
}
