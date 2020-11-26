using ClientLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using WpfApp2.MessageHandler;

namespace WpfApp2
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Client client;

        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value; NotifyPropertyChanged(); }
        }

        private bool isConnected = false;
        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; NotifyPropertyChanged(); }
        }

        private string chatMessage;
        public string ChatMessage
        {
            get { return chatMessage; }
            set { chatMessage = value; NotifyPropertyChanged(); }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; NotifyPropertyChanged(); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; NotifyPropertyChanged(); }
        }

        private int userOnlineCount;
        public int UserOnlineCount
        {
            get { return userOnlineCount; }
            set { userOnlineCount = value; NotifyPropertyChanged(); }
        }

        private string chatHistory;
        public string ChatHistory
        {
            get { return chatHistory; }
            set { chatHistory = value; NotifyPropertyChanged(); }
        }

        public void Connect()
        {
            ChatHistory = string.Empty;
            client = new Client("127.0.0.1", 13000);
            client.Connect(username, password);
            StartMessageHandleThread();
        }

        public void Disconnect()
        {
            client.Disconnect();
        }

        public void RequestUsers()
        {
            client.RequestUserList();
        }

        public void SendChatMessage()
        {
            if (chatMessage.Length > 0)
            {
                client.SendChatMessage(chatMessage);
                ChatMessage = string.Empty;
            }
        }

        void MessageHandle()
        {
            while (true)
            {
                lock (client.ReceivedMessages)
                {
                    foreach (var message in client.ReceivedMessages)
                    {
                        var messageHandler = MessageHandlerFactory.GetMessageHandler(message.MessageId);
                        if (messageHandler != null)
                            messageHandler.Execute(this, message);
                    }

                    client.ReceivedMessages.Clear();
                }
            }
        }

        void StartMessageHandleThread()
        {
            var messageHandleThreadStart = new ThreadStart(MessageHandle);
            var messageHandleThread = new Thread(messageHandleThreadStart);
            messageHandleThread.Start();
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
