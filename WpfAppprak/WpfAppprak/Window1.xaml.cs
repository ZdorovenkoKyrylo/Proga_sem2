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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            AlphaSelector.IsEnabled = false;
            m = File.ReadAllLines(path).Select(i => double.Parse(i.Split(' ')[0])).ToArray();
            s_0 = File.ReadAllLines(path).Select(i => double.Parse(i.Split(' ')[1])).ToArray();
        }

        private void CloseStudyMode_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }
        Stopwatch st;
        int counter = 3;
        int wri_input, wro_input;
        const string path = @"C:\Users\conqueror\source\repos\WpfAppprak\WpfAppprak\prak_1.txt";
        bool start = false;
        bool indicator = false;
        const string tex = "длагнитор";
        List<double> inter = new List<double>();
        double[] m, s_0;
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
            if (InputField.Text != tex.Substring(0, InputField.Text.Length))
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
                double M = inter.Sum() / n;
                bool state = false;
                for (int i = 0; i < m.Length; i++)
                {
                    if (Math.Max(m[i],M)/ Math.Min(m[i], M) > 3.18)
                    {
                        state = false;
                        break;
                    }
                    else
                    {
                        double s_y = inter.Sum(y => Math.Pow(y - m[i], 2))/(n-1);
                        double s = Math.Sqrt((s_0[i] + s_y) * (n - 1) / (2 * n - 1));
                        double t_p = (m[i] - M) / (s * Math.Sqrt(2 / n));
                        if (t_p < 1.895)
                        {
                            state = true;

                        }
                    }                
                }
                if (state)
                {
                    wri_input++;
                }
                else
                {
                    wro_input++;
                }
                StatisticsBlock.Content = Math.Round((double)wri_input / (wri_input + wro_input)*100).ToString() + "%" + $" {wri_input}/{wri_input + wro_input}";
                P1Field.Content = Math.Round(100.0-((double)wri_input / (wri_input + wro_input) * 100)).ToString() + "%" + $" {wro_input}/{wri_input + wro_input}";
                indicator = true;
                InputField.Text = "";
                counter--;
                if (counter==0)
                {
                    InputField.IsEnabled = false;
                }
            }
        }       
        private void CountProtection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            counter = CountProtection.SelectedIndex + 3;
        }
    }
}
