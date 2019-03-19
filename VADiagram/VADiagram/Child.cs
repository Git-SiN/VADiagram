// Incompletion...

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VADiagram
{
    public partial class Child : UserControl
    {

        internal static Size buttonSize = new Size(100, 25);
        private byte itemCounts = 2;
        internal Color themeColor = Color.LightSalmon;

        private int start;
        private int end;
        internal Point myLoc;


        private byte level = 0;
        private bool isClicked = false;



        public Child()
        {
            InitializeComponent();
        }


        public Child(byte lev, int s, int e, int x, int y)
        {
            InitializeComponent();
            
            level = lev;
            start = s;
            end = e;

            this.myLoc = new Point(x, y);
            this.Location = myLoc;

            this.Width = 100;
            this.Height = 26 + (itemCounts * 15) + 18;
            
            this.splitContainer2.SplitterDistance = this.splitContainer1.Panel2.Height - 18;


            this.bRange.Text = String.Format("{0:X}  -  {1:X}", start, end);

            //          lDetails.Items.Add("Level : " + level);
          
        }

        private void Child_Load(object sender, EventArgs e)
        {

        }

        private void bRange_Click(object sender, EventArgs e)
        {
            if (isClicked)
            {
                bRange.BackColor = Color.White;
                this.BackColor = Color.Black;
                isClicked = false;
            }
            else
            {
                bRange.BackColor = themeColor;
                this.BackColor = themeColor;
                isClicked = true;
            }
            
            Invalidate(true);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(isClicked? themeColor : Color.Black);

            float x = ((PictureBox)sender).Width / 2 - (float)2.5;
            float y = ((PictureBox)sender).Height / 2 - (float)2.5;

            e.Graphics.FillEllipse(brush, x, y, 5, 5);

        }


    }
}
