using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplab2_fin
{
    public class singularity
    {
        public int width;
        public int height;
        public int left;
        public int top;
        public string cont;
        public UIElement control;

        public singularity(int width, int heig, int lef, int t, string con, UIElement control)
        {
            this.width = width;
            height = heig;
            left = lef;
            top = t;
            cont = con;
            this.control = control;

        }
    }
}

