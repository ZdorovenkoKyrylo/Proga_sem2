using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfAppprac_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static DispatcherTimer dT;
        static int Radius = 30;
        static int PointCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> EllipseArray = new List<Ellipse>();
        static PointCollection pC = new PointCollection();
        Road road;     
        public MainWindow()
        {
            dT = new DispatcherTimer();
            InitializeComponent();
            InitPoints();

            road = new Mainfirstalg(pC);

            InitPolygon();
            dT = new DispatcherTimer();
            dT.Tick += new EventHandler(OneStep);
            dT.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }
        private void InitPoints()
        {
            Random rnd = new Random();
            pC.Clear();
            EllipseArray.Clear();
            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();
                p.X = rnd.Next(Radius, (int)(0.75 * MainWin.Width) -
                3 * Radius);

                p.Y = rnd.Next(Radius, (int)(0.90 * MainWin.Height -
                3 * Radius));

                pC.Add(p);
            }
            for (int i = 0; i < PointCount; i++)
            {
                Ellipse el = new Ellipse();
                el.StrokeThickness = 2;
                el.Height = el.Width = Radius;
                el.Stroke = Brushes.Black;
                el.Fill = Brushes.LightBlue;
                EllipseArray.Add(el);
            }
        }
        private void InitPolygon()
        {
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.StrokeThickness = 2;
        }
        private void PlotPoints()
        {
            for (int i = 0; i < PointCount; i++)
            {
                Canvas.SetLeft(EllipseArray[i], pC[i].X - Radius / 2);
                Canvas.SetTop(EllipseArray[i], pC[i].Y - Radius / 2);
                MyCanvas.Children.Add(EllipseArray[i]);
            }
        }
        private void PlotWay(int[] BestWayIndex)
        {
            PointCollection Points = new PointCollection();
            for (int i = 0; i < BestWayIndex.Length; i++)
                Points.Add(pC[BestWayIndex[i]]);
            myPolygon.Points = Points;
            MyCanvas.Children.Add(myPolygon);
        }
        private void VelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;
            dT.Interval = new

            TimeSpan(0, 0, 0, 0, Convert.ToInt16(item.Content));

        }
        private void Alg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB1 = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB1.SelectedItem;            
                switch (item.Content)
                {
                    case "greedy":
                        road = new Mainfirstalg(pC);
                        break;
                    case "genetic":
                        road = new Genetic(pC);
                        break;
                }           
        }
        private void StopStart_Click(object sender, RoutedEventArgs e)
        {
            if (dT.IsEnabled)
            {
                dT.Stop();
                NumElemCB.IsEnabled = true;
            }
            else
            {
                NumElemCB.IsEnabled = false;
                dT.Start();
            }
        }
        private void NumElemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;
            PointCount = Convert.ToInt32(item.Content);
            InitPoints();
            InitPolygon();
            road?.Update(pC);
        }
        private void OneStep(object sender, EventArgs e)
        {
            MyCanvas.Children.Clear();
            PlotPoints();
            PlotWay(road.GetWay());
        }
        private int[] GetBestWay()
        {
            Random rnd = new Random();
            int[] way = new int[PointCount];
            for (int i = 0; i < PointCount; i++)
                way[i] = i;
            for (int s = 0; s < 2 * PointCount; s++)
            {
                int i1, i2, tmp;
                i1 = rnd.Next(PointCount);
                i2 = rnd.Next(PointCount);
                tmp = way[i1];
                way[i1] = way[i2];
                way[i2] = tmp;
            }
            return way;
        }

    }
    class Road
    {
        public PointCollection p;
        public virtual void Update(PointCollection pC) { }
        public virtual int[] GetWay()
        {
            return null;
        }
    }
    class Mainfirstalg : Road
    {
        public Mainfirstalg(PointCollection pC)
        {
            Update(pC);
        }
        public override int[] GetWay()
        {
            PointCollection copy = p.Clone();
            Point point = p[0];
            int temp = copy.Count;
            int[] road = new int[temp + 1];
            road[0] = 0;
            road[temp] = 0;
            copy.Remove(point);
            for (int i = 0; i < p.Count - 1; i++)
            {
                point = copy.OrderBy(t => (t.X - point.X) * (t.X - point.X) + (t.Y - point.Y) * (t.Y - point.Y)).First();
                copy.Remove(point);
                road[i + 1] = p.IndexOf(point);
            }
            return road;
        }

        public override void Update(PointCollection pC)
        {
            p = pC;
        }
    }
    class Genetic : Road
    {
        const int N = 5;
        Random rnd = new Random();
        List<int[]> l = new List<int[]>();
        public Genetic(PointCollection pC)
        {
            Update(pC);
        }
        public override void Update(PointCollection pC)
        {
            l.Clear();
            List<int> numb = new List<int>();
            p = pC;
            for (int i = 0; i < N; i++)
            {
                int[] arr = new int[p.Count];
                for (int k = 0; k < p.Count; k++)
                {
                    numb.Add(k);
                }
                for (int j = 0; j < p.Count; j++)
                {
                    arr[j] = numb[rnd.Next(0, numb.Count - 1)];
                    numb.Remove(arr[j]);
                }
                l.Add(arr);
            }
        }
        public override int[] GetWay()
        {
            int i1, i2;
            for (int i = 0; i < N; i++)
            {
                i1 = rnd.Next(0, N);
                i2 = rnd.Next(0, N);
                int crossPoint = rnd.Next(1, p.Count - 1);
                int[] temp1, temp2, temp3, temp4;
                List<int> ch = new List<int>();
                var test = l[i1].ToList();
                temp1 = test.GetRange(0, crossPoint).ToArray();
                temp2 = l[i1].ToList().GetRange(crossPoint, p.Count - crossPoint).ToArray();
                temp3 = l[i2].ToList().GetRange(0, crossPoint).ToArray();
                temp4 = l[i2].ToList().GetRange(crossPoint, p.Count - crossPoint).ToArray();
                if (rnd.NextDouble() < 0.5)
                {
                    ch = temp1.Union(temp4).Union(temp2).Union(temp3).ToList();
                }
                else
                {
                    ch = temp2.Union(temp3).Union(temp1).Union(temp4).ToList();
                }
                l.Add(ch.ToArray());
            }
            int[] temporary;
            for (int i = N; i < 2 * N; i++)
            {
                if (rnd.NextDouble() < 0.7)
                {
                    i1 = rnd.Next(0, p.Count);
                    i2 = rnd.Next(0, p.Count);
                    if (i1 < i2)
                    {
                        temporary = l[i].ToList().GetRange(i1, i2 - i1).ToArray();
                        temporary = temporary.Reverse().ToArray();
                        for (int j = i1; j < i2; j++)
                        {
                            l[i][j] = temporary[j - i1];
                        }
                    }
                    else
                    {
                        temporary = l[i].ToList().GetRange(i2, i1 - i2).ToArray();
                        temporary = temporary.Reverse().ToArray();
                        for (int j = i2; j < i1; j++)
                        {
                            l[i][j] = temporary[j - i2];
                        }
                    }
                }
            }
            l = l.OrderBy(t => Selection(t)).ToList();
            l = l.GetRange(0, N);
            return l[0];
        }
        public double Selection(int[] road)
        {
            double len, length = 0;
            for (int j = 0; j < road.Length - 1; j++)
            {
                len = (p[road[j + 1]].X - p[road[j]].X) * (p[road[j + 1]].X - p[road[j]].X)
                     + (p[road[j + 1]].Y - p[road[j]].Y) * (p[road[j + 1]].Y - p[road[j]].Y);
                length += len;
            }
            length += (p[road[road.Length - 1]].X - p[road[0]].X) * (p[road[road.Length - 1]].X - p[road[0]].X)
                                     + (p[road[road.Length - 1]].Y - p[road[0]].Y) * (p[road[road.Length - 1]].Y - p[road[0]].Y);
            return length;
        }
    }
}
