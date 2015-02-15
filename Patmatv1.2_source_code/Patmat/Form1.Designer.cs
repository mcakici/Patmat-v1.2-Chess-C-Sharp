namespace Patmat
{
  partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniOyunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.kapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_start = new System.Windows.Forms.Button();
            this.listBox_hareket = new System.Windows.Forms.ListBox();
            this.button_reset = new System.Windows.Forms.Button();
            this.label_oyuncusirasi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listBox_puan = new System.Windows.Forms.ListBox();
            this.checkBox_yardim = new System.Windows.Forms.CheckBox();
            this.groupBox_stats = new System.Windows.Forms.GroupBox();
            this.label_gecenzaman = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_toplamhamle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer_gecensure = new System.Windows.Forms.Timer(this.components);
            this.checkBox_ses = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox_stats.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(805, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniOyunToolStripMenuItem,
            this.resetleToolStripMenuItem,
            this.toolStripSeparator1,
            this.kapatToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // yeniOyunToolStripMenuItem
            // 
            this.yeniOyunToolStripMenuItem.Name = "yeniOyunToolStripMenuItem";
            this.yeniOyunToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.yeniOyunToolStripMenuItem.Text = "Yeni Oyun";
            this.yeniOyunToolStripMenuItem.Click += new System.EventHandler(this.yeniOyunToolStripMenuItem_Click);
            // 
            // resetleToolStripMenuItem
            // 
            this.resetleToolStripMenuItem.Name = "resetleToolStripMenuItem";
            this.resetleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetleToolStripMenuItem.Text = "Resetle";
            this.resetleToolStripMenuItem.Click += new System.EventHandler(this.resetleToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // kapatToolStripMenuItem
            // 
            this.kapatToolStripMenuItem.Name = "kapatToolStripMenuItem";
            this.kapatToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kapatToolStripMenuItem.Text = "Kapat";
            this.kapatToolStripMenuItem.Click += new System.EventHandler(this.kapatToolStripMenuItem_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(604, 178);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(97, 70);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "Başlat";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox_hareket
            // 
            this.listBox_hareket.BackColor = System.Drawing.Color.Wheat;
            this.listBox_hareket.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBox_hareket.FormattingEnabled = true;
            this.listBox_hareket.ItemHeight = 18;
            this.listBox_hareket.Location = new System.Drawing.Point(604, 38);
            this.listBox_hareket.Name = "listBox_hareket";
            this.listBox_hareket.Size = new System.Drawing.Size(191, 130);
            this.listBox_hareket.TabIndex = 5;
            // 
            // button_reset
            // 
            this.button_reset.Enabled = false;
            this.button_reset.Location = new System.Drawing.Point(707, 178);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(86, 70);
            this.button_reset.TabIndex = 6;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // label_oyuncusirasi
            // 
            this.label_oyuncusirasi.BackColor = System.Drawing.Color.Snow;
            this.label_oyuncusirasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_oyuncusirasi.Location = new System.Drawing.Point(607, 260);
            this.label_oyuncusirasi.Name = "label_oyuncusirasi";
            this.label_oyuncusirasi.Size = new System.Drawing.Size(186, 50);
            this.label_oyuncusirasi.TabIndex = 7;
            this.label_oyuncusirasi.Text = "Sıra Beyazda";
            this.label_oyuncusirasi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(605, 612);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Copyright © 2012 | Mustafa Çakıcı";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(605, 587);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Wipau  | İletişim:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.LinkColor = System.Drawing.Color.Gainsboro;
            this.linkLabel1.Location = new System.Drawing.Point(689, 587);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(84, 13);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "glikoz@live.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.checkBox1.Location = new System.Drawing.Point(603, 567);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Dev Mod";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listBox_puan
            // 
            this.listBox_puan.BackColor = System.Drawing.Color.Wheat;
            this.listBox_puan.Enabled = false;
            this.listBox_puan.Font = new System.Drawing.Font("Tahoma", 11F);
            this.listBox_puan.FormattingEnabled = true;
            this.listBox_puan.ItemHeight = 18;
            this.listBox_puan.Location = new System.Drawing.Point(604, 324);
            this.listBox_puan.Name = "listBox_puan";
            this.listBox_puan.Size = new System.Drawing.Size(191, 76);
            this.listBox_puan.TabIndex = 11;
            // 
            // checkBox_yardim
            // 
            this.checkBox_yardim.AutoSize = true;
            this.checkBox_yardim.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_yardim.Checked = true;
            this.checkBox_yardim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_yardim.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBox_yardim.Location = new System.Drawing.Point(603, 493);
            this.checkBox_yardim.Name = "checkBox_yardim";
            this.checkBox_yardim.Size = new System.Drawing.Size(138, 17);
            this.checkBox_yardim.TabIndex = 10;
            this.checkBox_yardim.Text = "Hareket Yerlerini Göster";
            this.checkBox_yardim.UseVisualStyleBackColor = false;
            this.checkBox_yardim.Visible = false;
            this.checkBox_yardim.CheckedChanged += new System.EventHandler(this.checkBox_yardim_CheckedChanged);
            // 
            // groupBox_stats
            // 
            this.groupBox_stats.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_stats.Controls.Add(this.label_gecenzaman);
            this.groupBox_stats.Controls.Add(this.label4);
            this.groupBox_stats.Controls.Add(this.label_toplamhamle);
            this.groupBox_stats.Controls.Add(this.label3);
            this.groupBox_stats.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox_stats.Location = new System.Drawing.Point(603, 406);
            this.groupBox_stats.Name = "groupBox_stats";
            this.groupBox_stats.Size = new System.Drawing.Size(192, 75);
            this.groupBox_stats.TabIndex = 12;
            this.groupBox_stats.TabStop = false;
            this.groupBox_stats.Text = "İstatistikler";
            this.groupBox_stats.Visible = false;
            // 
            // label_gecenzaman
            // 
            this.label_gecenzaman.AutoSize = true;
            this.label_gecenzaman.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_gecenzaman.Location = new System.Drawing.Point(109, 22);
            this.label_gecenzaman.Name = "label_gecenzaman";
            this.label_gecenzaman.Size = new System.Drawing.Size(72, 18);
            this.label_gecenzaman.TabIndex = 0;
            this.label_gecenzaman.Text = "00:00:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Toplam Geçen Süre:";
            // 
            // label_toplamhamle
            // 
            this.label_toplamhamle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_toplamhamle.Location = new System.Drawing.Point(125, 45);
            this.label_toplamhamle.Name = "label_toplamhamle";
            this.label_toplamhamle.Size = new System.Drawing.Size(56, 20);
            this.label_toplamhamle.TabIndex = 0;
            this.label_toplamhamle.Text = "0";
            this.label_toplamhamle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Toplam Oyun Hamlesi:";
            // 
            // timer_gecensure
            // 
            this.timer_gecensure.Interval = 1000;
            this.timer_gecensure.Tick += new System.EventHandler(this.timer_gecensure_Tick);
            // 
            // checkBox_ses
            // 
            this.checkBox_ses.AutoSize = true;
            this.checkBox_ses.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_ses.Checked = true;
            this.checkBox_ses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ses.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBox_ses.Location = new System.Drawing.Point(603, 516);
            this.checkBox_ses.Name = "checkBox_ses";
            this.checkBox_ses.Size = new System.Drawing.Size(85, 17);
            this.checkBox_ses.TabIndex = 10;
            this.checkBox_ses.Text = "Ses Efektleri";
            this.checkBox_ses.UseVisualStyleBackColor = false;
            this.checkBox_ses.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(805, 630);
            this.Controls.Add(this.groupBox_stats);
            this.Controls.Add(this.listBox_puan);
            this.Controls.Add(this.checkBox_ses);
            this.Controls.Add(this.checkBox_yardim);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_oyuncusirasi);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.listBox_hareket);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Patmat v1.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox_stats.ResumeLayout(false);
            this.groupBox_stats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem yeniOyunToolStripMenuItem;
    private System.Windows.Forms.Button button_start;
    private System.Windows.Forms.ListBox listBox_hareket;
    private System.Windows.Forms.Button button_reset;
    private System.Windows.Forms.Label label_oyuncusirasi;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.LinkLabel linkLabel1;
    private System.Windows.Forms.ToolStripMenuItem resetleToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem kapatToolStripMenuItem;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.ListBox listBox_puan;
    private System.Windows.Forms.CheckBox checkBox_yardim;
    private System.Windows.Forms.GroupBox groupBox_stats;
    private System.Windows.Forms.Label label_gecenzaman;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label_toplamhamle;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Timer timer_gecensure;
    private System.Windows.Forms.CheckBox checkBox_ses;
  }
}

