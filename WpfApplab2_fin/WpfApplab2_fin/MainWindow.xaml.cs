using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;


namespace WpfApplab2_fin
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
        Grid g = new Grid();
        public MainWindow()
        {
            InitializeComponent();

            addButtonToGrid(new singularity(100, 30, 10, 10, "GoTo1Window", B1), B1_Click);
            addButtonToGrid(new singularity(100, 30, 150, 10, "GoTo2Window", B2), B2_Click);
            addButtonToGrid(new singularity(100, 30, 10, 60, "GoTo3Window", B3), B3_Click);
            addButtonToGrid(new singularity(100, 30, 150, 60, "GoTo4Window", B4), B4_Click);
            addButtonToGrid(new singularity(100, 30, 10, 120, "Exit", B5), B5_Click);
            this.Content = g;
            this.Show();

        }



        private void B1_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Win1 _window1 = new Win1();
        }
        private void B2_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Win2 _window2 = new Win2();
        }
        private void B3_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Win3 _window3 = new Win3();
        }

        private void B4_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Win4 _window4 = new Win4();

        }
        private void B5_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void addButtonToGrid(singularity sing, RoutedEventHandler func)
        {
            Button b = new Button();
            b.Width = sing.width;
            b.Height = sing.height;
            b.Content = sing.cont;
            b.Margin = new Thickness(sing.left, sing.top, 0, 0);
            b.HorizontalAlignment = HorizontalAlignment.Left;
            b.VerticalAlignment = VerticalAlignment.Top;
            b.Click += func;
            g.Children.Add(b);
        }
    }
}
