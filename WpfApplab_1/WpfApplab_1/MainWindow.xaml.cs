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

namespace WpfApplab_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Window1 _window1;
        private Window2 _window2;
        private Window3 _window3;
        private Window4 _window4;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button1_Click_1(object sender, RoutedEventArgs e)
        {
            _window1 = new Window1();
            Hide();
            _window1.Show();
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            _window2 = new Window2();
            Hide();
            _window2.Show();
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            _window3 = new Window3();
            Hide();
            _window3.Show();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            _window4 = new Window4();
            Hide();
            _window4.Show();
        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
