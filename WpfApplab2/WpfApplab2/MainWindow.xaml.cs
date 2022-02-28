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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

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
