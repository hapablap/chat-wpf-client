using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Connect();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SendChatMessage();
        }
    }
}
