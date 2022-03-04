﻿using System;
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
        Button B = new Button();       
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

        Grid g = new Grid();
        public win3()
        {
            Window w_3 = new Window();            
            w_3.Width = 800;
            w_3.Height = 750;
            addButtonToGrid(new singularity(80, 90, 100, 200, "1", B), number_Click);
            addButtonToGrid(new singularity(80, 90, 180, 200, "2", B), number_Click);
            addButtonToGrid(new singularity(80, 90, 260, 200, "3", B), number_Click);
            addButtonToGrid(new singularity(80, 90, 100, 290, "4", B), number_Click);
            addButtonToGrid(new singularity(80, 90, 180, 290, "5", B), number_Click);
            addButtonToGrid(new singularity(80, 90, 260, 290, "6", B), number_Click);
            addButtonToGrid(new singularity(80, 90, 100, 380, "7", B), number_Click);
            addButtonToGrid(new singularity(80, 90, 180, 380, "8", B), number_Click);
            addButtonToGrid(new singularity(80, 90, 260, 380, "9", B), number_Click);
            addButtonToGrid(new singularity(80, 90, 180, 110, "0", B), number_Click);
            addButtonToGrid(new singularity(80, 90, 100, 110, "+/-", B11), changeofznak_Click);
            addButtonToGrid(new singularity(80, 90, 260, 110, ",", B12), doublepart_Click);
            addButtonToGrid(new singularity(80, 90, 360, 110, "+", B13), plus_Click);
            addButtonToGrid(new singularity(80, 90, 360, 200, "-", B14), minus_Click);
            addButtonToGrid(new singularity(80, 90, 360, 290, "*", B15), multi_Click);
            addButtonToGrid(new singularity(80, 90, 360, 380, "/", B16), divide_Click);
            addButtonToGrid(new singularity(80, 90, 260, 470, "C", B17), C_Click);
            addButtonToGrid(new singularity(80, 90, 360, 470, "X", B18), X_Click);
            addButtonToGrid(new singularity(80, 90, 180, 470, "=", B19), equal_Click);
            addButtonToGrid(new singularity(80, 90, 650, 100, "GoToMain", B21), GoToMain_Click);
            addLabelToGrid(new singularity(150, 100, 550, 400, "", input));
            addLabelToGrid(new singularity(150, 100, 550, 600, "", LB_2));
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
