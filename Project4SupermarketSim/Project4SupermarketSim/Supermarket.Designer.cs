
namespace Project4SupermarketSim
{
    partial class Supermarket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Supermarket));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DesiredServiceBox = new System.Windows.Forms.TextBox();
            this.MinServiceBox = new System.Windows.Forms.TextBox();
            this.CheckoutLinesBox = new System.Windows.Forms.TextBox();
            this.ExpCustomersBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.HoursOpenBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BeatExpectBox = new System.Windows.Forms.TextBox();
            this.MaxLineBox = new System.Windows.Forms.TextBox();
            this.AvgServiceBox = new System.Windows.Forms.TextBox();
            this.CustomersServedBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.DesiredServiceBox);
            this.splitContainer1.Panel1.Controls.Add(this.MinServiceBox);
            this.splitContainer1.Panel1.Controls.Add(this.CheckoutLinesBox);
            this.splitContainer1.Panel1.Controls.Add(this.ExpCustomersBox);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.HoursOpenBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.BeatExpectBox);
            this.splitContainer1.Panel2.Controls.Add(this.MaxLineBox);
            this.splitContainer1.Panel2.Controls.Add(this.AvgServiceBox);
            this.splitContainer1.Panel2.Controls.Add(this.CustomersServedBox);
            this.splitContainer1.Size = new System.Drawing.Size(903, 413);
            this.splitContainer1.SplitterDistance = 449;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 303);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(240, 17);
            this.label13.TabIndex = 12;
            this.label13.Text = "Desired Avg Service Time (Seconds)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(189, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "Min. Service Time (Seconds)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "# of Checkout Lines";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Expected Customer Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "# of Hours Open";
            // 
            // DesiredServiceBox
            // 
            this.DesiredServiceBox.Location = new System.Drawing.Point(289, 303);
            this.DesiredServiceBox.MaxLength = 4;
            this.DesiredServiceBox.Name = "DesiredServiceBox";
            this.DesiredServiceBox.Size = new System.Drawing.Size(121, 22);
            this.DesiredServiceBox.TabIndex = 7;
            this.DesiredServiceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DesiredServiceBox.TextChanged += new System.EventHandler(this.DesiredServiceBox_TextChanged);
            this.DesiredServiceBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DesiredServiceBox_KeyPress);
            // 
            // MinServiceBox
            // 
            this.MinServiceBox.Location = new System.Drawing.Point(289, 249);
            this.MinServiceBox.MaxLength = 4;
            this.MinServiceBox.Name = "MinServiceBox";
            this.MinServiceBox.Size = new System.Drawing.Size(121, 22);
            this.MinServiceBox.TabIndex = 6;
            this.MinServiceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MinServiceBox.TextChanged += new System.EventHandler(this.MinServiceBox_TextChanged);
            this.MinServiceBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MinServiceBox_KeyPress);
            // 
            // CheckoutLinesBox
            // 
            this.CheckoutLinesBox.Location = new System.Drawing.Point(289, 195);
            this.CheckoutLinesBox.MaxLength = 3;
            this.CheckoutLinesBox.Name = "CheckoutLinesBox";
            this.CheckoutLinesBox.Size = new System.Drawing.Size(121, 22);
            this.CheckoutLinesBox.TabIndex = 5;
            this.CheckoutLinesBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CheckoutLinesBox.TextChanged += new System.EventHandler(this.CheckoutLinesBox_TextChanged);
            this.CheckoutLinesBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckoutLinesBox_KeyPress);
            // 
            // ExpCustomersBox
            // 
            this.ExpCustomersBox.Location = new System.Drawing.Point(289, 141);
            this.ExpCustomersBox.MaxLength = 4;
            this.ExpCustomersBox.Name = "ExpCustomersBox";
            this.ExpCustomersBox.Size = new System.Drawing.Size(121, 22);
            this.ExpCustomersBox.TabIndex = 4;
            this.ExpCustomersBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ExpCustomersBox.TextChanged += new System.EventHandler(this.ExpCustomersBox_TextChanged);
            this.ExpCustomersBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ExpCustomersBox_KeyPress);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(214, 358);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Clear Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Run Simulation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(112, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 22);
            this.label8.TabIndex = 1;
            this.label8.Text = "Simulation Data";
            // 
            // HoursOpenBox
            // 
            this.HoursOpenBox.Location = new System.Drawing.Point(289, 87);
            this.HoursOpenBox.MaxLength = 5;
            this.HoursOpenBox.Name = "HoursOpenBox";
            this.HoursOpenBox.Size = new System.Drawing.Size(121, 22);
            this.HoursOpenBox.TabIndex = 0;
            this.HoursOpenBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.HoursOpenBox.TextChanged += new System.EventHandler(this.HoursOpenBox_TextChanged);
            this.HoursOpenBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HoursOpenBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Simulation Results";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Beat Expected Service TIme?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Max Line Length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Avg Service Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Customers Served";
            // 
            // BeatExpectBox
            // 
            this.BeatExpectBox.Location = new System.Drawing.Point(292, 264);
            this.BeatExpectBox.Name = "BeatExpectBox";
            this.BeatExpectBox.ReadOnly = true;
            this.BeatExpectBox.Size = new System.Drawing.Size(112, 22);
            this.BeatExpectBox.TabIndex = 6;
            this.BeatExpectBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MaxLineBox
            // 
            this.MaxLineBox.Location = new System.Drawing.Point(292, 205);
            this.MaxLineBox.Name = "MaxLineBox";
            this.MaxLineBox.ReadOnly = true;
            this.MaxLineBox.Size = new System.Drawing.Size(112, 22);
            this.MaxLineBox.TabIndex = 5;
            this.MaxLineBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AvgServiceBox
            // 
            this.AvgServiceBox.Location = new System.Drawing.Point(292, 146);
            this.AvgServiceBox.Name = "AvgServiceBox";
            this.AvgServiceBox.ReadOnly = true;
            this.AvgServiceBox.Size = new System.Drawing.Size(112, 22);
            this.AvgServiceBox.TabIndex = 3;
            this.AvgServiceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CustomersServedBox
            // 
            this.CustomersServedBox.Location = new System.Drawing.Point(292, 87);
            this.CustomersServedBox.Name = "CustomersServedBox";
            this.CustomersServedBox.ReadOnly = true;
            this.CustomersServedBox.Size = new System.Drawing.Size(112, 22);
            this.CustomersServedBox.TabIndex = 2;
            this.CustomersServedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Supermarket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 441);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Supermarket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GoodbyeMessage);
            this.Load += new System.EventHandler(this.Supermarket_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox CustomersServedBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BeatExpectBox;
        private System.Windows.Forms.TextBox MaxLineBox;
        private System.Windows.Forms.TextBox AvgServiceBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox HoursOpenBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox DesiredServiceBox;
        private System.Windows.Forms.TextBox MinServiceBox;
        private System.Windows.Forms.TextBox CheckoutLinesBox;
        private System.Windows.Forms.TextBox ExpCustomersBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
    }
}

