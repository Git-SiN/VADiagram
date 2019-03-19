using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VADiagram
{
    public partial class Form1 : Form
    {
        private Parent p = null;
        delegate void dUpdateFormSize(Form1 f, int w, int h);
        internal bool isInitiated = false;

        // UI
        private Point lastScrollPosition;
        static Size maximumFormSize = new Size(800, 600);

        public Form1()
        {
            InitializeComponent();

            p = new Parent(this, 4);
            this.Controls.Add(p);

        }

        internal void UpdateFormSize(int w, int h)
        {
            // It's the code to deal with the Cross Thread Exception... 
            // But, the exception was not occured......

            //if (f.InvokeRequired)
            //{
            //    dUpdateFormSize d = new dUpdateFormSize(UpdateFormSize);
            //    this.Invoke(d, new object[] { f, (w > Screen.PrimaryScreen.Bounds.Width) ? 600 : w, (h > Screen.PrimaryScreen.Bounds.Height) ? 400 : h});
            //}
            //else
            //{

            // Scroll : 16, 43  
            this.Size = new Size(((w + 16) > Screen.PrimaryScreen.Bounds.Width) ? maximumFormSize.Width : (w + 16),
            ((h + 43) > Screen.PrimaryScreen.Bounds.Height) ? maximumFormSize.Height : (h + 43 + 15));

            if (!isInitiated)
            {
                isInitiated = true;
                lastScrollPosition = new Point((w - this.Size.Width) / 2, 0);
                //MessageBox.Show(this.Size.Width + " " + this.HorizontalScroll.Maximum + " " + (w - this.Size.Width) / 2);
            }
            LoadScrollPosition();

            // MessageBox.Show(w + ", " + h + "     " + lastScrollPosition.X + ", " + lastScrollPosition.Y);
            //}
        }

        internal void LoadScrollPosition()
        {
            this.HorizontalScroll.Value = lastScrollPosition.X;
            this.VerticalScroll.Value = lastScrollPosition.Y;
            //MessageBox.Show("LOAD : " + this.HorizontalScroll.Value + " / " + lastScrollPosition.X);
        }

        internal void SaveScrollPosition()
        {
            lastScrollPosition = new Point(this.HorizontalScroll.Value, this.VerticalScroll.Value);
            //MessageBox.Show("IN SaveScrollPosition : " + this.HorizontalScroll.Value + "/"  + lastScrollPosition.X + " [" + this.HorizontalScroll.Minimum + " - " + this.HorizontalScroll.Maximum + "]");
        }

    }
}
    