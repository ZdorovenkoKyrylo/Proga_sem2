using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplab_1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void GoToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }

        private void write_Click(object sender, RoutedEventArgs e)
        {
            string str1 = TB1.Text;
            string str2 = TB2.Text;
            string str3 = TB3.Text;
            string str4 = str1 + "[" + str2 + "[" + str3 + "[" + "\n";         
            File.AppendAllText(@"C:\Users\conqueror\Documents\File_1.txt", str4);
            TB1.Text = "";
            TB2.Text = "";
            TB3.Text = "";
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllLines(@"C:\Users\conqueror\Documents\File_1.txt", File.ReadAllLines(@"C:\Users\conqueror\Documents\File_1.txt").Where(i => i.Split('[')[0]!= TB1.Text));
            TB1.Text = "";
            TB2.Text = "";
            TB3.Text = "";
        }
    }
}
