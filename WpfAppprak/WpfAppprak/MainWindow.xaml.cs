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

namespace WpfAppprak
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Window1 _window1;
        private Window2 _window2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void StudyModeBtn_Click(object sender, RoutedEventArgs e)
        {
            _window2 = new Window2();
            Hide();
            _window2.Show();
        }

        private void ProtectionModeBtn_Click(object sender, RoutedEventArgs e)
        {
            _window1 = new Window1();
            Hide();
            _window1.Show();
        }
    }
}
