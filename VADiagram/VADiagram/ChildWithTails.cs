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
    public partial class ChildWithTails : UserControl
    {
        private Parent myParent = null;
        private Point myLocation;
        //private int startVPN;
        //private int endVPN;
        private bool isLeft;
        private bool isRight;

        private byte itemCounts;
        private bool isInitialized = false;

        internal byte level;
        internal int order;

        // UI
        internal static Size buttonSize = new Size(100, 25);
        internal static byte lastRowHeight = 17;

        internal static byte itemHeight = 15;
        private static Color clickedColor = Color.LightCoral;
        private static Color unclickedColor = Color.FromArgb(80,80,80);

        private Color currentColor = unclickedColor;
        internal bool isClicked = false;
        internal int variableHeight;
        
            
        public ChildWithTails()
        {
            InitializeComponent();
        }

        public ChildWithTails(Parent p, int x, int y, int w, int h, int ord, byte lev, byte c, bool l, bool r)
        {
            InitializeComponent();

            myParent = p;
            isLeft = l;
            isRight = r;
            itemCounts = c;
            level = lev;
            order = ord;

            this.Location = myLocation = new Point(x, y);
            this.Size = new Size(w, h);

            if (InitializeAppearance())
                HeightControl();
        }

        private bool InitializeAppearance()
        {
            this.splitContainer1.Width = buttonSize.Width;
            this.splitContainer1.Height = buttonSize.Height + lastRowHeight + 3;
            this.splitContainer1.Location = new Point((this.Width - buttonSize.Width) / 2, 0);

            variableHeight = buttonSize.Height + 2 + lastRowHeight + ((itemCounts == 0) ? 1 : (itemCounts * itemHeight));
            variableHeight -= this.splitContainer1.Height;    
            //this.splitContainer1.Height = expandedHeight = 27 + lastRowHeight + ((itemCounts == 0) ? 1 : (itemCounts * itemHeight));

            this.splitContainer1.SplitterDistance = buttonSize.Height;
            this.splitContainer1.Panel2MinSize = lastRowHeight + 2;

            this.splitContainer2.Panel1MinSize = 1;
            this.splitContainer2.Panel2MinSize = lastRowHeight;
            this.splitContainer2.Panel1Collapsed = true;
            this.splitContainer2.SplitterDistance = 1;

            this.pictureBox1.BackColor = Color.Transparent;
            //MessageBox.Show(this.splitContainer1.Panel1.Height + "  " + this.splitContainer1.Panel2.Location.Y + "  " + "" + this.splitContainer1.Height);
            return true;
        }

        private void HeightControl()
        {
            this.pictureBox1.Height = this.Height - this.splitContainer1.SplitterDistance - this.splitContainer2.SplitterDistance - 1;

            if (!isInitialized)
                isInitialized = true;
            else
                myParent.UpdateHeight(this);
            
        }

        private void bRange_Click(object sender, EventArgs e)
        {
            myParent.ownerForm.SaveScrollPosition();

            if (isClicked)
            {
                this.splitContainer1.Height -= variableHeight;
                this.splitContainer2.SplitterDistance = 1;
                this.Height -= variableHeight;
                currentColor = unclickedColor;
                isClicked = false;
            }
            else
            {
                this.splitContainer1.Height += variableHeight;
                this.splitContainer2.SplitterDistance = ((itemCounts == 0) ? 1 : (itemCounts * itemHeight));
                this.Height += variableHeight;
                currentColor = clickedColor;
                isClicked = true;
            }

            HeightControl();
        }

 
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen currentPen;
            SolidBrush currentBrush;
            Rectangle rect;
            Point lPoint;
            Point rPoint;

            if (isInitialized)
            {
                // Border
                rect = new Rectangle(this.splitContainer1.Location, new Size(this.splitContainer1.Width - 1, lastRowHeight - 1));
                currentBrush = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(currentBrush, rect);

                currentPen = new Pen(currentColor);
                e.Graphics.DrawRectangle(currentPen, rect);

                // Center Bar
                e.Graphics.DrawLine(currentPen, new Point(this.Width / 2, 0), new Point(this.Width / 2, lastRowHeight - 1));

                // Tails
                lPoint = new Point((this.Width / 2) - (this.splitContainer1.Width / 4), lastRowHeight / 2);
                rPoint = new Point((this.Width / 2) + (this.splitContainer1.Width / 4), lastRowHeight / 2);

                currentBrush.Color = currentColor;
                currentPen.Width = 2;

                if (isLeft)
                    e.Graphics.DrawLine(currentPen, lPoint, new Point(this.Width / 4, this.pictureBox1.Height));
                else
                    e.Graphics.FillEllipse(currentBrush, lPoint.X - 1, lPoint.Y - 1, 2, 2);

                if (isRight)
                    e.Graphics.DrawLine(currentPen, rPoint, new Point(this.Width / 4 * 3, this.pictureBox1.Height));
                else
                    e.Graphics.FillEllipse(currentBrush, rPoint.X - 1, rPoint.Y - 1, 2, 2);

            }
        }

        private void ChildWithTails_Enter(object sender, EventArgs e)
        {
            this.bRange.Focus();    
        }
    }
}
