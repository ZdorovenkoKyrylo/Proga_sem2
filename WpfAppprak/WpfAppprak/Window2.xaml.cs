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
using System.IO;
using System.Diagnostics;
using System.Windows.Shapes;

namespace WpfAppprak
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void CloseStudyMode_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }
        Stopwatch st;
        int counter=3;
        const string path = @"C:\Users\conqueror\source\repos\WpfAppprak\WpfAppprak\prak_1.txt";
        bool start= false;
        bool indicator = false;
        const string tex = "длагнитор";
        List<double> inter = new List<double>();
        private void InputField_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountProtection.IsEnabled = false;
            if (indicator)
            {
                indicator = false;
                inter.Clear();
                start = false;
                return;
            }
            if (InputField.Text != tex.Substring(0,InputField.Text.Length))
            {
                MessageBox.Show("Wrong input");
                indicator = true;
                InputField.Text = "";
                return;
            }
            if (!start)
            {
                st = new Stopwatch();
                st.Start();
                start = true;
            }
            else
            {
                st.Stop();
                inter.Add(st.Elapsed.TotalSeconds);
                st.Reset();
                st.Start();               
            }
            if (InputField.Text == tex)
            {
                int n = inter.Count;
                bool g = true;
                for (int i = 0; i < n ; i++)
                {
                    var y = inter.Where(h => h != inter[i]).ToList();
                    double M = y.Sum() / (n - 1);
                    double S = y.Sum(k => k * k - M * M) / (n - 2);
                    double t_p = (inter[i] - M) /Math.Sqrt(S);
                    if (t_p > 1.895)
                    {
                        MessageBox.Show($"{t_p}");
                        g = false;
                        break;
                    }
                }
                if (g)
                {
                    MessageBox.Show("ok");
                    double M = inter.Sum() / n;
                    double S = inter.Sum(k => k * k - M * M) / (n - 1);
                    File.AppendAllText(path, $"{M} {S}\n");
                    counter--;
                }
                if (counter==0)
                {
                    InputField.IsEnabled = false;
                }
                indicator = true;
                InputField.Text = "";
                return;
            }
        }

        private void CountProtection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            counter = CountProtection.SelectedIndex + 3;           
        }
    }
}
