using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace WpfApplab2_fin
{
    class Win4
    {
        Button B1 = new Button();
        TextBox TB1 = new TextBox();
        Grid g = new Grid();
        public Win4()
        {
            Window w_4 = new Window();

            w_4.Width = 800;
            w_4.Height = 750;
            addTextBoxToGrid(new singularity(400, 100, 200, 300, "Здоровенко Кирило Сергійович КП-11 2022р. створення", TB1));
            addButtonToGrid(new singularity(80, 90, 650, 100, "GoToMain", B1), GoToMain_Click);
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
        public void addTextBoxToGrid(singularity sing)
        {
            TextBox tb = new TextBox();
            tb.Width = sing.width;
            tb.Height = sing.height;
            tb.Margin = new Thickness(sing.left, sing.top, 0, 0);
            tb.Text = sing.cont;
            tb.HorizontalAlignment = HorizontalAlignment.Left;
            tb.VerticalAlignment = VerticalAlignment.Top;
            g.Children.Add(tb);
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
    }
}
