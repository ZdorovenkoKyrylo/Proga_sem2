using System.Linq;
using System.Windows;
using System.IO;
using System.Windows.Controls;


namespace WpfApplab2_fin
{
    class Win1
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
        Grid g = new Grid();

        public Win1()
        {
            w_1.Width = 800;
            w_1.Height = 750;
            addTextBoxToGrid(new singularity(150, 90, 170, 350, "", TB1));
            addTextBoxToGrid(new singularity(150, 90, 320, 350, "", TB2));
            addTextBoxToGrid(new singularity(150, 90, 470, 350, "", TB3));
            addLabelToGrid(new singularity(150, 90, 330, 300, "number of the book", LB1));
            addLabelToGrid(new singularity(150, 90, 220, 300, "ПІБ", LB2));
            addLabelToGrid(new singularity(150, 90, 500, 300, "date of birth", LB3));
            addButtonToGrid(new singularity(150, 90, 250, 500, "write", B1), B1_Click);
            addButtonToGrid(new singularity(150, 90, 420, 500, "delete", B2), B2_Click);
            addButtonToGrid(new singularity(150, 90, 600, 600, "GoToMain", B3), GoToMain_Click);
            w_1.Content = g;
            //Hide();
            w_1.Show();
        }
        public void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            w_1.Hide();
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
        public void addTextBoxToGrid(singularity sing)
        {
            TextBox tb = (TextBox)sing.control;
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
            Button b = (Button)sing.control;
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
            Label lb = (Label)sing.control;
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

