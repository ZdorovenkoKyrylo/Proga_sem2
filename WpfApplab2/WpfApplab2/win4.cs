using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplab2
{
    class win4
    {
        Button B1 = new Button();
        TextBox TB1 = new TextBox();
        public void GoTo4Window_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w_4 = new MainWindow();
            Grid g = new Grid();
            w_4.Width = 800;
            w_4.Height = 750;
            g = addTextBoxToGrid(g, new singularity(300, 400, 400, 375, "Здоровенко Кирило Сергійович КП-11 2022р. створення", TB1));
            g = addButtonToGrid(g, new singularity(80, 90, 650, 100, "GoToMain", B1), GoToMain_Click);
            w_4.Content = g;
            //Hide();
            w_4.Show();
        }
        public void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            //this.Hide();
            mw.Show();
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
