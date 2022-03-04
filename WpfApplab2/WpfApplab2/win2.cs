using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplab2
{
    class win2
    {
        Window w_2 = new Window();
        public Button[,] buttons = new Button[5, 5];
        public int k = 1;
        Label LB = new Label();
        Button B = new Button();
        Grid g = new Grid();
        public void To2Window_Click(object sender, RoutedEventArgs e)
        {
            w_2.Width = 2000;
            w_2.Height = 1700;
            addLabelToGrid(new singularity(150, 90, 70, 70, "", LB));
            addButtonToGrid( new singularity(150, 90, 140, 120, "GoToMain", B), GoToMain_Click);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Content = "";
                    buttons[i, j].Width = 40;
                    buttons[i, j].Height = 40;
                    buttons[i, j].Click += ButtonX0_Click;
                    buttons[i, j].Margin = new Thickness(50 + 40 * j, 50 + 40 * i, 0, 0);
                    g.Children.Add(buttons[i, j]);
                }
            }
            w_2.Content = g;
            //Hide();
            w_2.Show();
        }
        public void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            //this.Hide();
            mw.Show();
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
        public void addButtonToGrid(singularity sing, RoutedEventHandler func)
        {
            Button b = new Button();
            b.Width = sing.width;
            b.Height = sing.height;
            b.Margin = new Thickness(sing.left, sing.top, 0, 0);
            b.Content = sing.cont;
            b.HorizontalAlignment = HorizontalAlignment.Left;
            b.VerticalAlignment = VerticalAlignment.Top;
            b.Click += func;
            g.Children.Add(b);

        }
        public void addLabelToGrid(singularity sing)
        {
            Label lb = new Label();
            lb.Width = sing.width;
            lb.Height = sing.height;
            lb.Margin = new Thickness(sing.left, sing.top, 0, 0);
            lb.Content = sing.cont;
            lb.HorizontalAlignment = HorizontalAlignment.Left;
            lb.VerticalAlignment = VerticalAlignment.Top;
            g.Children.Add(lb);
        }
    }
}
