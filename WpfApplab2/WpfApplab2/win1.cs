using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;

namespace WpfApplab2
{
    class win1
    {
        Window w_1 = new Window();
        TextBox TB1 = new TextBox();
        TextBox TB2 = new TextBox();
        TextBox TB3 = new TextBox();
        Label LB1 = new Label();
        Label LB2 = new Label();
        Label LB3 = new Label();
        Button B1 = new Button();
        Button B2 = new Button();
        Button B3 = new Button();
        public void To1Window_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w_1 = new MainWindow();
            Grid g = new Grid();
            w_1.Width = 800;
            w_1.Height = 750;
            g = addTextBoxToGrid(g, new singularity(150, 90, 70, 580, "number of the book", TB1));
            g = addTextBoxToGrid(g, new singularity(150, 90, 320, 580, "ПІБ", TB2));
            g = addTextBoxToGrid(g, new singularity(150, 90, 570, 580, "date of birth", TB3));
            g = addLabelToGrid(g, new singularity(150, 90, 70, 400, "", LB1));
            g = addLabelToGrid(g, new singularity(150, 90, 320, 400, "", LB2));
            g = addLabelToGrid(g, new singularity(150, 90, 570, 400, "", LB3));
            g = addButtonToGrid(g, new singularity(150, 90, 140, 120, "write", B1), B1_Click);
            g = addButtonToGrid(g, new singularity(150, 90, 140, 120, "delete", B2), B2_Click);
            g = addButtonToGrid(g, new singularity(150, 90, 140, 120, "GoToMain", B3), GoToMain_Click);
            w_1.Content = g;
            //Hide();
            w_1.Show();
        }
        public void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            //this.Hide();
            mw.Show();
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
        public Grid addTextBoxToGrid(Grid gr, singularity sing)
        {
            TextBox tb = new TextBox();
            tb.Width = sing.width;
            tb.Height = sing.height;
            gr.Children.Add(sing.GetUIElement());
            return gr;
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
            public singularity(int wid, int heig, int lef, int t, string con,  UIElement control)
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
