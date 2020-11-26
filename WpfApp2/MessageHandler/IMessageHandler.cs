using ChatProtocol;

namespace WpfApp2.MessageHandler
{
    public interface IMessageHandler
    {
        public void Execute(MainWindowViewModel viewModel, IMessage message);
    }
}
