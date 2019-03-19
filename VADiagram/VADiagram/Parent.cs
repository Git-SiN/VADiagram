/*
These Controls, the Parent & ChildWithTails are for my projects...
    -> Memory Explorer [https://github.com/Git-SiN/MemoryExplorer]
    -> Memory Reviewer [https://github.com/Git-SiN/MemoryReviewer] 
    
            
    
    Written by SIN[miceshin@gmail.com]
*/



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
    // Distance between children...
    struct Distance
    {
        public byte X;
        public byte Y;
    };

    public partial class Parent : UserControl
    {
        internal Form1 ownerForm = null;
        private Distance distance;
        private byte maximumLevel;
        private int defaultHeight;
        private int[] levelWidth;
        private int[] levelHeight;
        private int[] clickedCount;
        private List<ChildWithTails> myChildren = null;


        private static byte itemCounts = 2;
         
        public Parent()
        {
            InitializeComponent();
        }

        public Parent(Form1 form, byte maxLev, byte dX = 10, byte dY = 20)
        {
            InitializeComponent();

            maximumLevel = maxLev;
            distance.X = dX;
            distance.Y = dY;
            ownerForm = form;

            if (InitConfiguration())
            {
                this.AutoSize = this.pCanvas.AutoSize = false;
                this.AutoScaleMode = AutoScaleMode.None;

                myChildren = new List<ChildWithTails>();
                myChildren.Clear();
            }
            else
            {
                MessageBox.Show("InitConfiguration() is failed....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }

        }

        private bool InitConfiguration()
        {
            int i = maximumLevel + 1;

            // Level 0 : VadRoot
            if(maximumLevel > 0 && distance.X > 0 && distance.Y > 0)
            {
                levelWidth = new int[i];
                levelHeight = new int[i];
                clickedCount = new int[i];
                clickedCount.Initialize();

                // for Child
                levelWidth[--i] = ChildWithTails.buttonSize.Width + distance.X;  // Last Level
                do
                    levelWidth[i - 1] = levelWidth[i--] * 2;
                while (i != 0);

                defaultHeight = ChildWithTails.buttonSize.Height + 3 + ChildWithTails.lastRowHeight + distance.Y;
                do
                    levelHeight[i++] = defaultHeight;
                while (i <= maximumLevel);


                // for Parent
                this.Location = new Point(0, 0);
                this.pCanvas.Location = new Point(distance.X / 2, distance.Y / 2);

                // Fixed...
                //this.Size = new Size(levelWidth[0] + distance.X, levelHeight.Sum() + distance.Y + (ChildWithTails.itemHeight * itemCounts * maximumLevel));
                
                return true;
            }
            return false;
        }


        /// <summary>
        /// All Nodes in the same level's Height are updated...
        ///     -> It's inompletion.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="variableHeight"></param>
        /// <param name="order"></param>
        /// <param name="level"></param>
        /// <param name="isClicked"></param>
        //internal void UpdateHeight(int variableHeight, int order, byte level, bool isClicked)
        //{
        //    if (level != maximumLevel)
        //    {
        //        if (isClicked)
        //        {
        //            if (clickedCount[level]++ == 0)
        //            {
        //                levelHeight[level] += variableHeight;

        //                foreach (ChildWithTails c in myChildren)
        //                {
        //                    if (c.level > level)
        //                    {
        //                        Point loc = c.Location;
        //                        loc.Y += variableHeight;
        //                        c.Location = loc;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (--clickedCount[level] == 0)
        //            {
        //                levelHeight[level] -= variableHeight;

        //                foreach (ChildWithTails c in myChildren)
        //                {
        //                    if (c.level > level)
        //                    {
        //                        Point loc = c.Location;
        //                        loc.Y -= variableHeight;
        //                        c.Location = loc;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    UpdateCanvasSize();
        //}



        /// <summary>
        /// Only the Associated Sub-Nodes' Locations are updated.
        /// </summary>
        /// <param name="clickedChild"></param>
        internal void UpdateHeight(ChildWithTails clickedChild)
        {

            // For Canvas Size...
            if (clickedChild.isClicked)
            {
                if (clickedCount[clickedChild.level]++ == 0)
                    levelHeight[clickedChild.level] += clickedChild.variableHeight;
            }
            else
            {
                if (--clickedCount[clickedChild.level] == 0)
                    levelHeight[clickedChild.level] -= clickedChild.variableHeight;
            }

            // Update the Associated SubNodes...
            if (clickedChild.level != maximumLevel)
            {
                foreach (ChildWithTails c in myChildren)
                {
                    if (c.level > clickedChild.level)
                    {
                        int minOrder = clickedChild.order;
                        int count = 1;
                        int i = (c.level - clickedChild.level);

                        while (i-- > 0)
                        {
                            minOrder *= 2;
                            count *= 2;
                        }

                        if ((c.order >= minOrder) && (c.order < (minOrder + count)))
                        {
                            Point loc = c.Location;
                            loc.Y += (clickedChild.isClicked ? clickedChild.variableHeight : -(clickedChild.variableHeight));
                            c.Location = loc;
                        }
                    }
                }
            }
            
            UpdateCanvasSize();
            clickedChild.Focus();
        }

        private void UpdateCanvasSize()
        {
            this.Size = new Size(levelWidth[0] + distance.X, levelHeight.Sum() + distance.Y);
            this.pCanvas.Size = new Size(levelWidth[0], levelHeight.Sum());

            ownerForm.UpdateFormSize(this.Width, this.Height);
        }

        private void Parent_Load(object sender, EventArgs e)
        {
            ///////////////////   Test for 'Child'   ///////////////////
            //  Child ch = new Child(2, 20, 40, 125, 20);
            //  this.panel1.Controls.Add(ch);
            //  ch.AutoSize = false;

            //  Child ch1 = new Child(2, 20, 30, 50, 120);
            //  this.panel1.Controls.Add(ch1);
            //  ch1.AutoSize = false;

            //  Child ch2 = new Child(2, 30, 40, 200, 120);
            //  this.panel1.Controls.Add(ch2);
            //  ch2.AutoSize = false;
            ////////////////////////////////////////////////////////////

            // At the OwnerForm...
            if (!ReceiveVADInfo(0, 0))
            {
                // Failed...
            }

            if (!ReceiveVADInfo(0, 1))
            {
                // Failed...
            }

            if (!ReceiveVADInfo(1, 1))
            {
                // Failed...
            }

            if (!ReceiveVADInfo(0, 2))
            {
                // Failed...
            }

            if (!ReceiveVADInfo(1, 2))
            {
                // Failed...
            }

            if (!ReceiveVADInfo(2, 2))
            {
                // Failed...
            }

            if (!ReceiveVADInfo(3, 2))
            {
                // Failed...
            }
            if (!ReceiveVADInfo(0, 3))
            {
                // Failed...
            }
            if (!ReceiveVADInfo(1, 3))
            {
                // Failed...
            }
            if (!ReceiveVADInfo(2, 3))
            {
                // Failed...
            }
            if (!ReceiveVADInfo(3, 3))
            {
                // Failed...
            }
            if (!ReceiveVADInfo(4, 3))
            {
                // Failed...
            }
            if (!ReceiveVADInfo(5, 3))
            {
                // Failed...
            }
            if (!ReceiveVADInfo(6, 3))
            {
                // Failed...
            }
            if (!ReceiveVADInfo(7, 3))
            {
                // Failed...
            }

            if (!ReceiveVADInfo(1, 4))
            {
                // Failed...
            }

            if (!ReceiveVADInfo(2, 4))
            {
                // Failed...
            }
            if (!ReceiveVADInfo(3, 4))
            {
                // Failed...
            }

            if (!ReceiveVADInfo(8, 4))
            {
                // Failed...
            }

            UpdateCanvasSize();

            foreach (ChildWithTails c in myChildren){
                if (c.level == 0)
                {
                    c.Focus();
                    return;
                }
            }
                
        }

        // In practice, the parameter will be the 'VADInfo' structure, made in the 'ReceiveVADInfo' function.
        private ChildWithTails CreateChild(int order, byte lev)
        {
            int y = 0;
            byte i = 0;

            while (i < lev)
                y += levelHeight[i++];

            ChildWithTails currentChild = new ChildWithTails
                (this, levelWidth[lev] * order, y, levelWidth[lev], levelHeight[lev], order, lev, itemCounts, true, true);

            this.pCanvas.Controls.Add(currentChild);
            currentChild.AutoSize = false;

            return currentChild; 
        }

        internal bool ReceiveVADInfo(int ord, byte lev)
        {
            ChildWithTails currentChild = null;

            currentChild = CreateChild(ord, lev);
            if (currentChild == null)
            {
//                MessageBox.Show(String.Format("Failed to create the Child : 0x{0:X8}", vadAddress), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                myChildren.Add(currentChild);
                return true;
            }
        }


    }


}
