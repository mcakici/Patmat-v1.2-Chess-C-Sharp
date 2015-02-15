namespace Patmat
{
  partial class FormPiyon
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPiyon));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.radioButton_fil = new System.Windows.Forms.RadioButton();
      this.radioButton_at = new System.Windows.Forms.RadioButton();
      this.radioButton_kale = new System.Windows.Forms.RadioButton();
      this.radioButton_vezir = new System.Windows.Forms.RadioButton();
      this.button1 = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.Color.Transparent;
      this.groupBox1.Controls.Add(this.radioButton_fil);
      this.groupBox1.Controls.Add(this.radioButton_at);
      this.groupBox1.Controls.Add(this.radioButton_kale);
      this.groupBox1.Controls.Add(this.radioButton_vezir);
      this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(179, 80);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Almak İstediğin Taş";
      // 
      // radioButton_fil
      // 
      this.radioButton_fil.AutoSize = true;
      this.radioButton_fil.BackColor = System.Drawing.Color.Transparent;
      this.radioButton_fil.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.radioButton_fil.Location = new System.Drawing.Point(98, 45);
      this.radioButton_fil.Name = "radioButton_fil";
      this.radioButton_fil.Size = new System.Drawing.Size(35, 17);
      this.radioButton_fil.TabIndex = 1;
      this.radioButton_fil.Text = "Fil";
      this.radioButton_fil.UseVisualStyleBackColor = false;
      // 
      // radioButton_at
      // 
      this.radioButton_at.AutoSize = true;
      this.radioButton_at.BackColor = System.Drawing.Color.Transparent;
      this.radioButton_at.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.radioButton_at.Location = new System.Drawing.Point(98, 22);
      this.radioButton_at.Name = "radioButton_at";
      this.radioButton_at.Size = new System.Drawing.Size(35, 17);
      this.radioButton_at.TabIndex = 1;
      this.radioButton_at.Text = "At";
      this.radioButton_at.UseVisualStyleBackColor = false;
      // 
      // radioButton_kale
      // 
      this.radioButton_kale.AutoSize = true;
      this.radioButton_kale.BackColor = System.Drawing.Color.Transparent;
      this.radioButton_kale.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.radioButton_kale.Location = new System.Drawing.Point(17, 45);
      this.radioButton_kale.Name = "radioButton_kale";
      this.radioButton_kale.Size = new System.Drawing.Size(46, 17);
      this.radioButton_kale.TabIndex = 1;
      this.radioButton_kale.Text = "Kale";
      this.radioButton_kale.UseVisualStyleBackColor = false;
      // 
      // radioButton_vezir
      // 
      this.radioButton_vezir.AutoSize = true;
      this.radioButton_vezir.BackColor = System.Drawing.Color.Transparent;
      this.radioButton_vezir.Checked = true;
      this.radioButton_vezir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.radioButton_vezir.Location = new System.Drawing.Point(17, 22);
      this.radioButton_vezir.Name = "radioButton_vezir";
      this.radioButton_vezir.Size = new System.Drawing.Size(48, 17);
      this.radioButton_vezir.TabIndex = 1;
      this.radioButton_vezir.TabStop = true;
      this.radioButton_vezir.Text = "Vezir";
      this.radioButton_vezir.UseVisualStyleBackColor = false;
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.SystemColors.Control;
      this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.button1.Location = new System.Drawing.Point(12, 98);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(180, 35);
      this.button1.TabIndex = 1;
      this.button1.Text = "Terfi Ettir";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // FormPiyon
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Tan;
      this.ClientSize = new System.Drawing.Size(203, 147);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.groupBox1);
      this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormPiyon";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Patmat";
      this.Load += new System.EventHandler(this.FormPiyon_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton radioButton_fil;
    private System.Windows.Forms.RadioButton radioButton_at;
    private System.Windows.Forms.RadioButton radioButton_kale;
    private System.Windows.Forms.RadioButton radioButton_vezir;
    private System.Windows.Forms.Button button1;
  }
}