namespace VADiagram
{
    partial class Child
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lDetail = new System.Windows.Forms.ListView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.pLeft = new System.Windows.Forms.PictureBox();
            this.pRight = new System.Windows.Forms.PictureBox();
            this.bRange = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lDetail);
            this.splitContainer2.Panel1MinSize = 15;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel2MinSize = 15;
            this.splitContainer2.Size = new System.Drawing.Size(100, 64);
            this.splitContainer2.SplitterDistance = 38;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // lDetail
            // 
            this.lDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lDetail.Location = new System.Drawing.Point(0, 0);
            this.lDetail.Name = "lDetail";
            this.lDetail.Size = new System.Drawing.Size(100, 38);
            this.lDetail.TabIndex = 0;
            this.lDetail.UseCompatibleStateImageBehavior = false;
            this.lDetail.View = System.Windows.Forms.View.List;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.pLeft);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.pRight);
            this.splitContainer3.Size = new System.Drawing.Size(100, 25);
            this.splitContainer3.SplitterDistance = 49;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 0;
            // 
            // pLeft
            // 
            this.pLeft.BackColor = System.Drawing.Color.White;
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(49, 25);
            this.pLeft.TabIndex = 0;
            this.pLeft.TabStop = false;
            this.pLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.White;
            this.pRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight.Location = new System.Drawing.Point(0, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(50, 25);
            this.pRight.TabIndex = 0;
            this.pRight.TabStop = false;
            this.pRight.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // bRange
            // 
            this.bRange.BackColor = System.Drawing.Color.White;
            this.bRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bRange.FlatAppearance.BorderSize = 0;
            this.bRange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Salmon;
            this.bRange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSalmon;
            this.bRange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRange.Location = new System.Drawing.Point(0, 0);
            this.bRange.Name = "bRange";
            this.bRange.Size = new System.Drawing.Size(100, 25);
            this.bRange.TabIndex = 0;
            this.bRange.UseVisualStyleBackColor = false;
            this.bRange.Click += new System.EventHandler(this.bRange_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bRange);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 18;
            this.splitContainer1.Size = new System.Drawing.Size(100, 90);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // Child
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Child";
            this.Size = new System.Drawing.Size(100, 90);
            this.Load += new System.EventHandler(this.Child_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRight)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bRange;
        private System.Windows.Forms.PictureBox pRight;
        private System.Windows.Forms.PictureBox pLeft;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView lDetail;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}
