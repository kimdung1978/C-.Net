namespace QLHoc_Sinh
{
    partial class frmchinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmchinh));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hosohocsinh = new System.Windows.Forms.ToolStripMenuItem();
            this.Danhsachlop = new System.Windows.Forms.ToolStripMenuItem();
            this.Danhsachhocsinh = new System.Windows.Forms.ToolStripMenuItem();
            this.bangdiemmon = new System.Windows.Forms.ToolStripMenuItem();
            this.tongketmon = new System.Windows.Forms.ToolStripMenuItem();
            this.tongkethocky = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btndangxuat = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hosohocsinh,
            this.Danhsachlop,
            this.Danhsachhocsinh,
            this.bangdiemmon,
            this.tongketmon,
            this.tongkethocky});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1134, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hosohocsinh
            // 
            this.hosohocsinh.Name = "hosohocsinh";
            this.hosohocsinh.Size = new System.Drawing.Size(145, 27);
            this.hosohocsinh.Text = "&Hồ sơ học sinh";
            this.hosohocsinh.Click += new System.EventHandler(this.hosohocsinh_Click);
            // 
            // Danhsachlop
            // 
            this.Danhsachlop.Name = "Danhsachlop";
            this.Danhsachlop.Size = new System.Drawing.Size(141, 27);
            this.Danhsachlop.Text = "&Danh sách lớp";
            this.Danhsachlop.Click += new System.EventHandler(this.Danhsachlop_Click);
            // 
            // Danhsachhocsinh
            // 
            this.Danhsachhocsinh.Name = "Danhsachhocsinh";
            this.Danhsachhocsinh.Size = new System.Drawing.Size(182, 27);
            this.Danhsachhocsinh.Text = "&Danh sách học sinh";
            this.Danhsachhocsinh.Click += new System.EventHandler(this.Danhsachhocsinh_Click);
            // 
            // bangdiemmon
            // 
            this.bangdiemmon.Name = "bangdiemmon";
            this.bangdiemmon.Size = new System.Drawing.Size(186, 27);
            this.bangdiemmon.Text = "&Bảng điểm môn học";
            this.bangdiemmon.Click += new System.EventHandler(this.bangdiemmon_Click);
            // 
            // tongketmon
            // 
            this.tongketmon.Name = "tongketmon";
            this.tongketmon.Size = new System.Drawing.Size(140, 27);
            this.tongketmon.Text = "&Tổng kết môn";
            this.tongketmon.Click += new System.EventHandler(this.tongketmon_Click);
            // 
            // tongkethocky
            // 
            this.tongkethocky.Name = "tongkethocky";
            this.tongkethocky.Size = new System.Drawing.Size(160, 27);
            this.tongkethocky.Text = "&Tổng kết học kỳ";
            this.tongkethocky.Click += new System.EventHandler(this.tongkethocky_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(3, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 581);
            this.panel1.TabIndex = 1;
            // 
            // btndangxuat
            // 
            this.btndangxuat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndangxuat.Location = new System.Drawing.Point(475, 628);
            this.btndangxuat.Name = "btndangxuat";
            this.btndangxuat.Size = new System.Drawing.Size(198, 54);
            this.btndangxuat.TabIndex = 2;
            this.btndangxuat.Text = "&Đăng Xuất";
            this.btndangxuat.UseVisualStyleBackColor = true;
            this.btndangxuat.Click += new System.EventHandler(this.btndangxuat_Click);
            // 
            // frmchinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1134, 684);
            this.Controls.Add(this.btndangxuat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmchinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý học sinh";
            this.Load += new System.EventHandler(this.frmchinh_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hosohocsinh;
        private System.Windows.Forms.ToolStripMenuItem Danhsachlop;
        private System.Windows.Forms.ToolStripMenuItem Danhsachhocsinh;
        private System.Windows.Forms.ToolStripMenuItem bangdiemmon;
        private System.Windows.Forms.ToolStripMenuItem tongketmon;
        private System.Windows.Forms.ToolStripMenuItem tongkethocky;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btndangxuat;
    }
}