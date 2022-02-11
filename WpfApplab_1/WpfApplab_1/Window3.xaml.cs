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
using System.Windows.Shapes;

namespace WpfApplab_1
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private double n=0;
        private Label input;
        public Window3()
        {
            InitializeComponent();
            input = LB_2;
        }
        private void GoToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            input.Content += B.Content.ToString();      
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (input.Content.ToString()=="")
            {
                return;
            }
            input.Content = input.Content.ToString().Substring(0, input.Content.ToString().Length - 1);          
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LB_1.Content = "0";
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            input = LB_1;
            if (input.Content.ToString() == "")
            {
                Console.WriteLine("Error");
                return;
            }
            LB_2.Content = (Double.Parse(LB_2.Content.ToString()) / Double.Parse(LB_1.Content.ToString())).ToString();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            input = LB_1;
            if (input.Content.ToString() == "")
            {
                Console.WriteLine("Error");
                return;
            }
            LB_2.Content = (Double.Parse(LB_2.Content.ToString()) * Double.Parse(LB_1.Content.ToString())).ToString();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            input = LB_1;
            if (input.Content.ToString() == "")
            {
                Console.WriteLine("Error");
                return;
            }
            LB_2.Content = (Double.Parse(LB_2.Content.ToString()) - Double.Parse(LB_1.Content.ToString())).ToString();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            input = LB_1;
            if (input.Content.ToString()=="")
            {
                Console.WriteLine("Error");
                return;
            }
            LB_2.Content = (Double.Parse(LB_2.Content.ToString()) + Double.Parse(LB_1.Content.ToString())).ToString();
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            input.Content = (-Double.Parse(input.Content.ToString())).ToString();
        }
    }
}
