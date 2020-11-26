using ChatProtocol;

namespace WpfApp2.MessageHandler
{
    public class UserCountMessageHandler : IMessageHandler
    {
        public void Execute(MainWindowViewModel viewModel, IMessage message)
        {
            var userCountMessage = message as UserCountMessage;
            viewModel.UserOnlineCount = userCountMessage.UserOnlineCount;
        }
    }
}
