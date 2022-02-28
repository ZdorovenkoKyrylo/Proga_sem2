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

namespace WpfApplab_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button B1 = new Button();
        Button B2 = new Button();
        Button B3 = new Button();
        Button B4 = new Button();
        Button B5 = new Button();
        public MainWindow()
        {
            MainWindow mw = new MainWindow();
            Grid g = new Grid();
            g = addButtonToGrid(g, new singularity(80, 90, 650, 100, "GoTo1Window", B1), B1_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 650, 100, "GoTo2Window", B2), B2_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 650, 100, "GoTo3Window", B3), B3_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 650, 100, "GoTo4Window", B4), B4_Click);
            g = addButtonToGrid(g, new singularity(80, 90, 650, 100, "Exit", B5), B5_Click);
            mw.Content = g;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
           Window _window1 = new Window();
           Hide();
           _window1.Show();
        }
        private void B2_Click(object sender, RoutedEventArgs e)
        {
            Window _window2 = new Window();
            Hide();
            _window2.Show();
        }
        private void B3_Click(object sender, RoutedEventArgs e)
        {
            Window _window3 = new Window();
            Hide();
            _window3.Show();
        }

        private void B4_Click(object sender, RoutedEventArgs e)
        {
            Window _window4 = new Window();
            Hide();
            _window4.Show();
        }
        private void B5_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
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
