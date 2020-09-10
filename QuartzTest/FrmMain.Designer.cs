namespace QuartzTest
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonQuartzStart = new System.Windows.Forms.Button();
            this.buttonQuartzStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonNow = new System.Windows.Forms.Button();
            this.buttonEvery2Min = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonClearList = new System.Windows.Forms.Button();
            this.buttonEvery3Min = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonQuartzStart
            // 
            this.buttonQuartzStart.Location = new System.Drawing.Point(6, 19);
            this.buttonQuartzStart.Name = "buttonQuartzStart";
            this.buttonQuartzStart.Size = new System.Drawing.Size(75, 23);
            this.buttonQuartzStart.TabIndex = 0;
            this.buttonQuartzStart.Text = "Start";
            this.buttonQuartzStart.UseVisualStyleBackColor = true;
            this.buttonQuartzStart.Click += new System.EventHandler(this.buttonQuartzStart_Click);
            // 
            // buttonQuartzStop
            // 
            this.buttonQuartzStop.Location = new System.Drawing.Point(6, 59);
            this.buttonQuartzStop.Name = "buttonQuartzStop";
            this.buttonQuartzStop.Size = new System.Drawing.Size(75, 23);
            this.buttonQuartzStop.TabIndex = 1;
            this.buttonQuartzStop.Text = "Stop";
            this.buttonQuartzStop.UseVisualStyleBackColor = true;
            this.buttonQuartzStop.Click += new System.EventHandler(this.buttonQuartzStop_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonQuartzStop);
            this.groupBox1.Controls.Add(this.buttonQuartzStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 96);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quartz";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonEvery3Min);
            this.groupBox2.Controls.Add(this.buttonNow);
            this.groupBox2.Controls.Add(this.buttonEvery2Min);
            this.groupBox2.Location = new System.Drawing.Point(12, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(87, 138);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Jobs";
            // 
            // buttonNow
            // 
            this.buttonNow.Location = new System.Drawing.Point(6, 109);
            this.buttonNow.Name = "buttonNow";
            this.buttonNow.Size = new System.Drawing.Size(75, 23);
            this.buttonNow.TabIndex = 2;
            this.buttonNow.Text = "Now";
            this.buttonNow.UseVisualStyleBackColor = true;
            this.buttonNow.Click += new System.EventHandler(this.buttonNow_Click);
            // 
            // buttonEvery2Min
            // 
            this.buttonEvery2Min.Location = new System.Drawing.Point(6, 19);
            this.buttonEvery2Min.Name = "buttonEvery2Min";
            this.buttonEvery2Min.Size = new System.Drawing.Size(75, 23);
            this.buttonEvery2Min.TabIndex = 3;
            this.buttonEvery2Min.Text = "Job 1 - 2 min";
            this.buttonEvery2Min.UseVisualStyleBackColor = true;
            this.buttonEvery2Min.Click += new System.EventHandler(this.buttonEvery2Min_Click);
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.Location = new System.Drawing.Point(134, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(667, 342);
            this.listBox.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonClearList);
            this.groupBox3.Location = new System.Drawing.Point(12, 268);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(87, 62);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "List";
            // 
            // buttonClearList
            // 
            this.buttonClearList.Location = new System.Drawing.Point(6, 19);
            this.buttonClearList.Name = "buttonClearList";
            this.buttonClearList.Size = new System.Drawing.Size(75, 23);
            this.buttonClearList.TabIndex = 3;
            this.buttonClearList.Text = "Clear list";
            this.buttonClearList.UseVisualStyleBackColor = true;
            this.buttonClearList.Click += new System.EventHandler(this.butttonClearList_Click);
            // 
            // buttonEvery3Min
            // 
            this.buttonEvery3Min.Location = new System.Drawing.Point(6, 48);
            this.buttonEvery3Min.Name = "buttonEvery3Min";
            this.buttonEvery3Min.Size = new System.Drawing.Size(75, 23);
            this.buttonEvery3Min.TabIndex = 4;
            this.buttonEvery3Min.Text = "Job 2 - 3 min";
            this.buttonEvery3Min.UseVisualStyleBackColor = true;
            this.buttonEvery3Min.Click += new System.EventHandler(this.buttonEvery3Min_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 342);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMain";
            this.Text = "QuartzTest";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonQuartzStart;
        private System.Windows.Forms.Button buttonQuartzStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonNow;
        private System.Windows.Forms.Button buttonEvery2Min;
        public System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonClearList;
        private System.Windows.Forms.Button buttonEvery3Min;
    }
}

