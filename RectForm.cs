using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CutCake
{
    public partial class RectForm : Form
    {
        int unit;

        Brush brush = new SolidBrush(Color.Red);
        Pen pen = new Pen(new SolidBrush(Color.Blue), 4);

        List<Ob> pieces;
        Graphics graphics;

        public RectForm(int unit, int height, int width,
            List<Ob> pieces)
        {
            InitializeComponent();
            this.unit = unit;
            this.pieces = pieces;

            FormBorderStyle = FormBorderStyle.None;
            Size = new()
            {

                Height = height * unit,
                Width = width * unit
            };
            StartPosition = FormStartPosition.Manual;
            graphics = CreateGraphics();
            Draw();

            Paint += (s, e) => Draw();
        }

        public void Draw()
        {
            graphics.DrawRectangle(pen, new Rectangle(0, 0, Width, Height));

            foreach(var item in pieces)
            {
                Rectangle rect = new Rectangle((int)(item.rectangleF.X * unit), (int)(item.rectangleF.Y * unit),
                    (int)(item.rectangleF.Width * unit), (int)(item.rectangleF.Height * unit));
                graphics.DrawRectangle(pen, rect);
            }

            //foreach(var item in raisins)
            //{
            //    graphics.FillEllipse(brush,
            //        new Rectangle((int)(item.X * unit) - 4, (int)(item.Y * unit) - 4, 8, 8));
            //}
        }

        public bool RaisinsSuccess()
        {
            foreach(var item in pieces)
            {
                Rectangle rect = new Rectangle((int)(item.rectangleF.X * unit), (int)(item.rectangleF.Y * unit),
                    (int)(item.rectangleF.Width * unit), (int)(item.rectangleF.Height * unit));
                //if(RaisinsCount(rect) != 1)
                  //  return false;
            }
            return true;
        }

        //int RaisinsCount(Rectangle rect)
        //{
        //    int count = 0;
        //    foreach(var item in raisins)
        //    {
        //        if(rect.Left < item.X * unit &&
        //           rect.Right > item.X * unit &&
        //           rect.Top < item.Y * unit &&
        //           rect.Bottom > item.Y * unit)
        //            count++;
        //    }
        //    return count;
        //}
    }
}

