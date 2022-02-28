using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplab2
{
    class win3
    {
        Button B1 = new Button();
        Button B2 = new Button();
        Button B3 = new Button();
        Button B4 = new Button();
        Button B5 = new Button();
        Button B6 = new Button();
        Button B7 = new Button();
        Button B8 = new Button();
        Button B9 = new Button();
        Button B10 = new Button();
        Button B11 = new Button();
        Button B12 = new Button();
        Button B13 = new Button();
        Button B14 = new Button();
        Button B15 = new Button();
        Button B16 = new Button();
        Button B17 = new Button();
        Button B18 = new Button();
        Button B19 = new Button();
        Button B20 = new Button();
        Button B21 = new Button();
        Label input = new Label();
        Label LB_2 = new Label();
        public Label LB_1;
        public void GoTo3Window_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w_3 = new MainWindow();
            Grid g = new Grid();
            w_3.Width = 800;
            w_3.Height = 750;
            g = addButtonToGrid(g, new singularity(80, 90, 100, 200, "1", B1), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 180, 200, "2", B2), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 260, 200, "3", B3), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 100, 290, "4", B4), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 180, 290, "5", B5), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 260, 290, "6", B6), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 100, 380, "7", B7), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 180, 380, "8", B8), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 260, 380, "9", B9), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 180, 110, "0", B10), number_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 100, 110, "+/-", B11), changeofznak_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 260, 110, ",", B12), doublepart_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 360, 110, "+", B13), plus_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 360, 200, "-", B14), minus_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 360, 290, "*", B15), multi_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 360, 380, "/", B16), divide_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 260, 470, "C", B17), C_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 360, 470, "X", B18), X_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 180, 470, "=", B19), equal_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 180, 470, "=", B20), equal_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 650, 100, "GoToMain", B21), GoToMain_Click);
            g = addLabelToGrid(g, new singularity(150, 100, 300, 600, "", input));
            g = addLabelToGrid(g, new singularity(150, 100, 500, 600, "", LB_2));
            w_3.Content = g;
            //Hide();
            w_3.Show();
        }
        public void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            //this.Hide();
            mw.Show();
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
        public Grid addButtonToGrid(Grid gr, singularity sing, RoutedEventHandler func)
        {
            Button b = new Button();
            b.Width = sing.width;
            b.Height = sing.height;
            b.Click += func;
            gr.Children.Add(sing.GetUIElement());
            return gr;
        }
        public Grid addLabelToGrid(Grid gr, singularity sing)
        {
            Label lb = new Label();
            lb.Width = sing.width;
            lb.Height = sing.height;
            gr.Children.Add(sing.GetUIElement());
            return gr;
        }
        public class singularity
        {
            public int width;
            public int height;
            public int left;
            public int top;
            public string cont;
            public UIElement control;
            public UIElement GetUIElement()
            {
                return control;
            }
            public singularity(int wid, int heig, int lef, int t, string con, UIElement control)
            {
                wid = this.width;
                heig = this.height;
                lef = this.left;
                t = this.top;
                con = this.cont;
                control = this.control;
            }
        }
    }
}
