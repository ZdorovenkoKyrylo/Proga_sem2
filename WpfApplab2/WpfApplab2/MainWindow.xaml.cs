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
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Button[,] buttons = new Button[5, 5];
        public int k = 1;
        public Label input;
        public MainWindow()
        {
            InitializeComponent();

        }
        public void To1Window_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w_1 = new MainWindow();
            Grid g = new Grid();
            w_1.Width = 800;
            w_1.Height = 750;
            g = addTextBoxToGrid(g, new singularity(150, 90, 70, 580, "number of the book", "TB1"));
            g = addTextBoxToGrid(g, new singularity(150, 90, 320, 580, "ПІБ", "TB2"));
            g = addTextBoxToGrid(g, new singularity(150, 90, 570, 580, "date of birth", "TB3"));
            g = addLabelToGrid(g, new singularity(150, 90, 70, 400, "", "LB1"));
            g = addLabelToGrid(g, new singularity(150, 90, 320, 400, "", "LB2"));
            g = addLabelToGrid(g, new singularity(150, 90, 570, 400, "", "LB3"));
            g = addButtonToGrid(g, new singularity(150, 90, 140, 120, "write", "B1"),B1_Click);
            g = addButtonToGrid(g, new singularity(150, 90, 140, 120, "delete", "B1"), B2_Click);
            g = addButtonToGrid(g, new singularity(150, 90, 140, 120, "GoToMain", "B1"), GoToMain_Click);
            w_1.Content = g;
            Hide();
            w_1.Show();
        }
        public void B1_Click(object sender, RoutedEventArgs e)
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
        public void B2_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllLines(@"C:\Users\conqueror\Documents\File_1.txt", File.ReadAllLines(@"C:\Users\conqueror\Documents\File_1.txt").Where(i => i.Split('[')[0] != TB1.Text));
            TB1.Text = "";
            TB2.Text = "";
            TB3.Text = "";
        }
        public void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }
        public void To2Window_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w_2 = new MainWindow();
            Grid g = new Grid();
            w_2.Width = 800;
            w_2.Height = 750;
            g = addLabelToGrid(g, new singularity(150, 90, 70, 70, "", "LB"));
            g = addButtonToGrid(g, new singularity(150, 90, 140, 120, "GoToMain", "B1"), GoToMain_Click);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Content = "";
                    buttons[i, j].Width = 40;
                    buttons[i, j].Height = 40;
                    buttons[i, j].Click += ButtonX0_Click;
                    buttons[i, j].Margin = new Thickness(-50 + 70 * j, -150 + 60 * i, 0, 0);
                    g.Children.Add(buttons[i, j]);
                }
            }
            w_2.Content = g;
            Hide();
            w_2.Show();
        }
        private void ButtonX0_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = "X";
            ((Button)sender).IsEnabled = false;
            AI();

            winning();
        }
        private void winning()
        {
            int p = 0, t = 0;           
            for (int i = 0; i < 5; i++) //перемога/поразка по головній діагоналі
            {
                if (buttons[i, i].Content.ToString() == "")
                {
                    t = 0;
                    p = 0;
                }
                if (buttons[i, i].Content.ToString() == "X")
                {
                    p++;
                    t = 0;
                    if (p == 4)
                    {
                        LB.Content = "Winer";
                        break;
                    }
                }
                else if (buttons[i, i].Content.ToString() == "0")
                {
                    t++;
                    p = 0;
                    if (t == 4)
                    {
                        LB.Content = "Loser";
                        break;
                    }
                }
            }
            t = 0;
            p = 0;
            for (int i = 0; i < 4; i++) //перемога/поразка по діагоналі, що розташована над/під головною
            {
                if (buttons[i, i + 1].Content.ToString() == "")
                {
                    t = 0;
                    p = 0;
                }
                if (buttons[i, i + 1].Content.ToString() == "X")
                {
                    p++;
                    t = 0;
                    if (p == 4)
                    {
                        LB.Content = "Winer";
                        break;
                    }
                }
                else if (buttons[i, i + 1].Content.ToString() == "0")
                {
                    t++;
                    p = 0;
                    if (t == 4)
                    {
                        LB.Content = "Loser";
                        break;
                    }
                }
            }
            t = 0;
            p = 0;
            for (int i = 0; i < 4; i++)
            {
                if (buttons[i + 1, i].Content.ToString() == "")
                {
                    t = 0;
                    p = 0;
                }
                if (buttons[i + 1, i].Content.ToString() == "X")
                {
                    p++;
                    t = 0;
                    if (p == 4)
                    {
                        LB.Content = "Winer";
                        break;
                    }
                }
                if (buttons[i + 1, i].Content.ToString() == "0")
                {
                    t++;
                    p = 0;
                    if (t == 4)
                    {
                        LB.Content = "Loser";
                        break;
                    }
                }
            }
            t = 0;
            p = 0;
            for (int i = 0; i < 5; i++)//перемога/поразка по побічній діагоналі
            {
                if (buttons[i, 5 - i - 1].Content.ToString() == "")
                {
                    t = 0;
                    p = 0;
                }
                if (buttons[i, 5 - i - 1].Content.ToString() == "X")
                {
                    p++;
                    t = 0;
                    if (p == 4)
                    {
                        LB.Content = "Winer";
                        break;
                    }
                }
                if (buttons[i, 5 - i - 1].Content.ToString() == "0")
                {
                    t++;
                    p = 0;
                    if (t == 4)
                    {
                        LB.Content = "Loser";
                        break;
                    }
                }
            }
            t = 0;
            p = 0;
            for (int i = 0; i < 4; i++)
            {
                if (buttons[i, 5 - i - 2].Content.ToString() == "")
                {
                    t = 0;
                    p = 0;
                }
                if (buttons[i, 5 - i - 2].Content.ToString() == "X")
                {
                    p++;
                    t = 0;
                    if (p == 4)
                    {
                        LB.Content = "Winer";
                        break;
                    }
                }
                if (buttons[i, 5 - i - 2].Content.ToString() == "0")
                {
                    t++;
                    p = 0;
                    if (t == 4)
                    {
                        LB.Content = "Loser";
                        break;
                    }
                }
            }
            t = 0;
            p = 0;
            for (int i = 0; i < 4; i++)
            {
                if (buttons[i + 1, 5 - i - 1].Content.ToString() == "")
                {
                    t = 0;
                    p = 0;
                }
                if (buttons[i + 1, 5 - i - 1].Content.ToString() == "X")
                {
                    p++;
                    t = 0;
                    if (p == 4)
                    {
                        LB.Content = "Winer";
                        break;
                    }
                }
                if (buttons[i + 1, 5 - i - 1].Content.ToString() == "0")
                {
                    t++;
                    p = 0;
                    if (t == 4)
                    {
                        LB.Content = "Loser";
                        break;
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (buttons[i, j].Content.ToString() == "")
                    {
                        t = 0;
                        p = 0;
                    }
                    if (buttons[i, j].Content.ToString() == "X")
                    {
                        p++;
                        t = 0;
                        if (p == 4)
                        {
                            LB.Content = "Winer";
                            break;
                        }
                    }
                    if (buttons[i, j].Content.ToString() == "0")
                    {
                        t++;
                        p = 0;
                        if (t == 4)
                        {
                            LB.Content = "Loser";
                            break;
                        }
                    }
                }
                t = 0;
                p = 0;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (buttons[j, i].Content.ToString() == "")
                    {
                        t = 0;
                        p = 0;
                    }
                    if (buttons[j, i].Content.ToString() == "X")
                    {
                        p++;
                        t = 0;
                        if (p == 4)
                        {
                            LB.Content = "Winer";
                            break;
                        }
                    }
                    if (buttons[j, i].Content.ToString() == "0")
                    {
                        t++;
                        p = 0;
                        if (t == 4)
                        {
                            LB.Content = "Loser";
                            break;
                        }
                    }
                }
                t = 0;
                p = 0;
            }
        }

        private void AI()
        {
            int h = 0;
            int[] arr = new int[32];
            for (int i = 0; i < 5; i++)
            {
                if (buttons[i, i].Content.ToString() == "X")
                {
                    arr[0]++;
                    arr[1] = 0;
                }
                else if (buttons[i, i].Content.ToString() == "0")
                {
                    arr[1]++;
                    arr[0] = 0;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (buttons[i, i + 1].Content.ToString() == "X")
                {
                    arr[2]++;
                    arr[3] = 0;
                }
                else if (buttons[i, i + 1].Content.ToString() == "0")
                {
                    arr[3]++;
                    arr[2] = 0;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (buttons[i + 1, i].Content.ToString() == "X")
                {
                    arr[4]++;
                    arr[5] = 0;
                }
                else if (buttons[i + 1, i].Content.ToString() == "0")
                {
                    arr[5]++;
                    arr[4] = 0;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (buttons[i, 5 - i - 1].Content.ToString() == "X")
                {
                    arr[6]++;
                    arr[7] = 0;
                }
                else if (buttons[i, 5 - i - 1].Content.ToString() == "0")
                {
                    arr[7]++;
                    arr[6] = 0;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (buttons[i, 5 - i - 2].Content.ToString() == "X")
                {
                    arr[8]++;
                    arr[9] = 0;
                }
                else if (buttons[i, 5 - i - 2].Content.ToString() == "0")
                {
                    arr[9]++;
                    arr[8] = 0;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (buttons[i + 1, 5 - i - 1].Content.ToString() == "X")
                {
                    arr[10]++;
                    arr[11] = 0;
                }
                else if (buttons[i + 1, 5 - i - 1].Content.ToString() == "0")
                {
                    arr[11]++;
                    arr[10] = 0;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (buttons[i, j].Content.ToString() == "X")
                    {
                        arr[12 + 2 * i]++;
                        arr[13 + 2 * i] = 0;
                    }
                    else if (buttons[i, j].Content.ToString() == "0")
                    {
                        arr[13 + 2 * i]++;
                        arr[12 + 2 * i] = 0;
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (buttons[j, i].Content.ToString() == "X")
                    {
                        arr[22 + 2 * i]++;
                        arr[23 + 2 * i] = 0;
                    }
                    else if (buttons[i, j].Content.ToString() == "0")
                    {
                        arr[23 + 2 * i]++;
                        arr[22 + 2 * i] = 0;
                    }
                }
            }
            int max_val = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (max_val < arr[i + 1])
                {
                    h = i + 1;
                    max_val = arr[i + 1];
                }
            }
            if (h / 2 == 0)
            {
                if (buttons[2, 2].IsEnabled == true && new Random().NextDouble() < 0.85)
                {
                    buttons[2, 2].Content = "0";
                    buttons[2, 2].IsEnabled = false;
                    return;
                }
                if (buttons[1, 1].IsEnabled == true && new Random().NextDouble() < 0.9)
                {
                    buttons[1, 1].Content = "0";
                    buttons[1, 1].IsEnabled = false;
                    return;
                }
                if (buttons[3, 3].IsEnabled == true && new Random().NextDouble() < 0.9)
                {
                    buttons[3, 3].Content = "0";
                    buttons[3, 3].IsEnabled = false;
                    return;
                }
                if (buttons[0, 0].IsEnabled == true)
                {
                    buttons[0, 0].Content = "0";
                    buttons[0, 0].IsEnabled = false;
                    return;
                }
                if (buttons[4, 4].IsEnabled == true)
                {
                    buttons[4, 4].Content = "0";
                    buttons[4, 4].IsEnabled = false;
                    return;
                }
            }
            if (h / 2 == 1)
            {
                if (buttons[1, 2].IsEnabled == true && new Random().NextDouble() < 0.8)
                {
                    buttons[1, 2].Content = "0";
                    buttons[1, 2].IsEnabled = false;
                    return;
                }
                if (buttons[2, 3].IsEnabled == true && new Random().NextDouble() < 0.8)
                {
                    buttons[2, 3].Content = "0";
                    buttons[2, 3].IsEnabled = false;
                    return;
                }
                if (buttons[0, 1].IsEnabled == true)
                {
                    buttons[0, 1].Content = "0";
                    buttons[0, 1].IsEnabled = false;
                    return;
                }
                if (buttons[3, 4].IsEnabled == true)
                {
                    buttons[3, 4].Content = "0";
                    buttons[3, 4].IsEnabled = false;
                    return;
                }
            }
            if (h / 2 == 2)
            {
                if (buttons[2, 1].IsEnabled == true && new Random().NextDouble() < 0.8)
                {
                    buttons[2, 1].Content = "0";
                    buttons[2, 1].IsEnabled = false;
                    return;
                }
                if (buttons[3, 2].IsEnabled == true && new Random().NextDouble() < 0.8)
                {
                    buttons[3, 2].Content = "0";
                    buttons[3, 2].IsEnabled = false;
                    return;
                }
                if (buttons[1, 0].IsEnabled == true)
                {
                    buttons[1, 0].Content = "0";
                    buttons[1, 0].IsEnabled = false;
                    return;
                }
                if (buttons[4, 3].IsEnabled == true)
                {
                    buttons[4, 3].Content = "0";
                    buttons[4, 3].IsEnabled = false;
                    return;
                }
            }
            if (h / 2 == 3)
            {
                if (buttons[2, 2].IsEnabled == true && new Random().NextDouble() < 0.85)
                {
                    buttons[2, 2].Content = "0";
                    buttons[2, 2].IsEnabled = false;
                    return;
                }
                if (buttons[1, 3].IsEnabled == true && new Random().NextDouble() < 0.9)
                {
                    buttons[1, 3].Content = "0";
                    buttons[1, 3].IsEnabled = false;
                    return;
                }
                if (buttons[3, 1].IsEnabled == true && new Random().NextDouble() < 0.9)
                {
                    buttons[3, 1].Content = "0";
                    buttons[3, 1].IsEnabled = false;
                    return;
                }
                if (buttons[0, 4].IsEnabled == true)
                {
                    buttons[0, 4].Content = "0";
                    buttons[0, 4].IsEnabled = false;
                    return;
                }
                if (buttons[4, 0].IsEnabled == true)
                {
                    buttons[4, 0].Content = "0";
                    buttons[4, 0].IsEnabled = false;
                    return;
                }
            }
            if (h / 2 == 4)
            {
                if (buttons[1, 2].IsEnabled == true && new Random().NextDouble() < 0.85)
                {
                    buttons[1, 2].Content = "0";
                    buttons[1, 2].IsEnabled = false;
                    return;
                }
                if (buttons[2, 1].IsEnabled == true && new Random().NextDouble() < 0.85)
                {
                    buttons[2, 1].Content = "0";
                    buttons[2, 1].IsEnabled = false;
                    return;
                }
                if (buttons[0, 3].IsEnabled == true)
                {
                    buttons[0, 3].Content = "0";
                    buttons[0, 3].IsEnabled = false;
                    return;
                }
                if (buttons[3, 0].IsEnabled == true)
                {
                    buttons[3, 0].Content = "0";
                    buttons[3, 0].IsEnabled = false;
                    return;
                }
            }
            if (h / 2 == 5)
            {
                if (buttons[2, 3].IsEnabled == true && new Random().NextDouble() < 0.85)
                {
                    buttons[2, 3].Content = "0";
                    buttons[2, 3].IsEnabled = false;
                    return;
                }
                if (buttons[3, 2].IsEnabled == true && new Random().NextDouble() < 0.85)
                {
                    buttons[3, 2].Content = "0";
                    buttons[3, 2].IsEnabled = false;
                    return;
                }
                if (buttons[1, 4].IsEnabled == true)
                {
                    buttons[1, 4].Content = "0";
                    buttons[1, 4].IsEnabled = false;
                    return;
                }
                if (buttons[4, 1].IsEnabled == true)
                {
                    buttons[4, 1].Content = "0";
                    buttons[4, 1].IsEnabled = false;
                    return;
                }
            }
            if (h / 2 < 11 && h / 2 > 5)
            {
                if (buttons[h / 2 - 6, 2].IsEnabled == true && new Random().NextDouble() < 0.9)
                {
                    buttons[h / 2 - 6, 2].Content = "0";
                    buttons[h / 2 - 6, 2].IsEnabled = false;
                    return;
                }
                if (buttons[h / 2 - 6, 1].IsEnabled == true && new Random().NextDouble() < 0.85)
                {
                    buttons[h / 2 - 6, 1].Content = "0";
                    buttons[h / 2 - 6, 1].IsEnabled = false;
                    return;
                }
                if (buttons[h / 2 - 6, 3].IsEnabled == true && new Random().NextDouble() < 0.85)
                {
                    buttons[h / 2 - 6, 3].Content = "0";
                    buttons[h / 2 - 6, 3].IsEnabled = false;
                    return;
                }
                if (buttons[h / 2 - 6, 4].IsEnabled == true && new Random().NextDouble() < 0.95)
                {
                    buttons[h / 2 - 6, 4].Content = "0";
                    buttons[h / 2 - 6, 4].IsEnabled = false;
                    return;
                }
                if (buttons[h / 2 - 6, 0].IsEnabled == true && new Random().NextDouble() < 0.95)
                {
                    buttons[h / 2 - 6, 0].Content = "0";
                    buttons[h / 2 - 6, 0].IsEnabled = false;
                    return;
                }
            }

            if (h / 2 > 10)
            {
                if (buttons[2, h / 2 - 11].IsEnabled == true && new Random().NextDouble() < 0.9)
                {
                    buttons[2, h / 2 - 11].Content = "0";
                    buttons[2, h / 2 - 11].IsEnabled = false;
                    return;
                }
                if (buttons[1, h / 2 - 11].IsEnabled == true && new Random().NextDouble() < 0.85)
                {
                    buttons[1, h / 2 - 11].Content = "0";
                    buttons[1, h / 2 - 11].IsEnabled = false;
                    return;
                }
                if (buttons[3, h / 2 - 11].IsEnabled == true && new Random().NextDouble() < 0.85)
                {
                    buttons[3, h / 2 - 11].Content = "0";
                    buttons[3, h / 2 - 11].IsEnabled = false;
                    return;
                }
                if (buttons[0, h / 2 - 11].IsEnabled == true && new Random().NextDouble() < 0.95)
                {
                    buttons[0, h / 2 - 11].Content = "0";
                    buttons[0, h / 2 - 11].IsEnabled = false;
                    return;
                }
                if (buttons[4, h / 2 - 11].IsEnabled == true && new Random().NextDouble() < 0.95)
                {
                    buttons[4, h / 2 - 11].Content = "0";
                    buttons[4, h / 2 - 11].IsEnabled = false;
                    return;
                }

            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (buttons[i, j].IsEnabled == true)
                    {
                        buttons[i, j].Content = "0";
                        return;
                    }
                }
            }
        }
        public void GoTo3Window_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w_3 = new MainWindow();
            Grid g = new Grid();
            w_3.Width = 800;
            w_3.Height = 750;
            g = addButtonToGrid(g, new singularity(80, 90, 100, 200, "1", "B1"), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 180, 200, "2", "B2"), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 260, 200, "3", "B3"), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 100, 290, "4", "B4"), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 180, 290, "5", "B5"), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 260, 290, "6", "B6"), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 100, 380, "7", "B7"), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 180, 380, "8", "B8"), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 260, 380, "9", "B9"), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 180, 110, "0", "B10"), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 100, 110, "+/-", "B11"), changeofznak_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 260, 110, ",", "B12"), doublepart_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 360, 110, "+", "B13"), plus_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 360, 200, "-", "B14"), minus_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 360, 290, "*", "B15"), multi_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 360, 380, "/", "B16"), divide_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 260, 470, "C", "B17"), C_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 360, 470, "X", "B18"), X_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 180, 470, "=", "B19"), equal_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 180, 470, "=", "B20"), equal_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 650, 100, "GoToMain", "B21"), GoToMain_Click);
            g = addLabelToGrid(g, new singularity(150, 100, 300, 600, "", "input"));
            g = addLabelToGrid(g, new singularity(150, 100, 500, 600, "", "LB_2"));
            w_3.Content = g;
            Hide();
            w_3.Show();
        }
        public void number_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            input.Content += B.Content.ToString();
        }
        public void changeofznak_Click(object sender, RoutedEventArgs e)
        {
            input.Content = (-Double.Parse(input.Content.ToString())).ToString();
        }
        public void doublepart_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            input.Content += B.Content.ToString();
        }
        public void plus_Click(object sender, RoutedEventArgs e)
        {
            input = LB_1;
            if (input.Content.ToString() == "")
            {
                Console.WriteLine("Error");
                return;
            }
            LB_2.Content = (Double.Parse(LB_2.Content.ToString()) + Double.Parse(LB_1.Content.ToString())).ToString();
        }
        public void minus_Click(object sender, RoutedEventArgs e)
        {
            input = LB_1;
            if (input.Content.ToString() == "")
            {
                Console.WriteLine("Error");
                return;
            }
            LB_2.Content = (Double.Parse(LB_2.Content.ToString()) - Double.Parse(LB_1.Content.ToString())).ToString();
        }
        public void multi_Click(object sender, RoutedEventArgs e)
        {
            input = LB_1;
            if (input.Content.ToString() == "")
            {
                Console.WriteLine("Error");
                return;
            }
            LB_2.Content = (Double.Parse(LB_2.Content.ToString()) * Double.Parse(LB_1.Content.ToString())).ToString();
        }
        public void divide_Click(object sender, RoutedEventArgs e)
        {
            input = LB_1;
            if (input.Content.ToString() == "")
            {
                Console.WriteLine("Error");
                return;
            }
            LB_2.Content = (Double.Parse(LB_2.Content.ToString()) / Double.Parse(LB_1.Content.ToString())).ToString();
        }
        public void C_Click(object sender, RoutedEventArgs e)
        {
            LB_1.Content = "0";
        }
        public void X_Click(object sender, RoutedEventArgs e)
        {
            if (input.Content.ToString() == "")
            {
                return;
            }
            input.Content = input.Content.ToString().Substring(0, input.Content.ToString().Length - 1);
        }
        public void equal_Click(object sender, RoutedEventArgs e)
        {

        }
        public void GoTo4Window_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w_4 = new MainWindow();
            Grid g = new Grid();
            w_4.Width = 800;
            w_4.Height = 750;
            g = addTextBoxToGrid(g, new singularity(300, 400, 400, 375, "Здоровенко Кирило Сергійович КП-11 2022р. створення", "TB1"));
            g = addButtonToGrid(g, new singularity(80, 90, 650, 100, "GoToMain", "B1"), GoToMain_Click);
            w_4.Content = g;
            Hide();
            w_4.Show();
        }
        public Grid addTextBoxToGrid(Grid gr, singularity sing)
        {
            TextBox tb = new TextBox();
            tb.Width = sing.width;
            tb.Height = sing.height;           
            tb.Name = sing.name;
            gr.Children.Add(sing);
            return gr;
        }
        public Grid addButtonToGrid(Grid gr, singularity sing, RoutedEventHandler func)
        {
            Button b = new Button();
            b.Width = sing.width;
            b.Height = sing.height;
            b.Name = sing.name;
            b.Click += func;
            gr.Children.Add(sing);
            return gr;
        }
        public Grid addLabelToGrid(Grid gr, singularity sing)
        {
            Label lb = new Label();
            lb.Width = sing.width;
            lb.Height = sing.height;
            lb.Name = sing.name;
            gr.Children.Add(sing);
            return gr;
        }
        public class singularity
        {
           public int width;
           public int height;
           public int left;
           public int top;
           public string cont;
           public string name;
           public singularity(int wid, int heig, int lef, int t, string con, string nam)
            {
                wid = width;
                heig = this.height;
                lef = this.left;
                t = this.top;
                con = this.cont;
                nam = this.name;
            }
        }
    }                             
}
