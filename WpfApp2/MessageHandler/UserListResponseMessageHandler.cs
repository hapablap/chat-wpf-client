using ChatProtocol;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace WpfApp2.MessageHandler
{
    public class UserListResponseMessageHandler : IMessageHandler
    {
        public void Execute(MainWindowViewModel viewModel, IMessage message)
        {
            var userListResponseMessage = message as UserListResponseMessage;
            viewModel.Users = JsonSerializer.Deserialize<ObservableCollection<User>>(userListResponseMessage.UserListJson);
        }
    }
}
