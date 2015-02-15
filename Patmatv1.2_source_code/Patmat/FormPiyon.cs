#region Bilgi: Lisanslama (GPL)
/*
*******************************************************************
*Patmat(Satranç) v1.2 Copyright (C) 2012 Mustafa ÇAKICI ***********
*İletişim İçin: glikoz@live.com ***********************************
*Bu uygulama basit bir satranç oyunudur.***************************
*Uygulama GPL lisansı altında dağıtılmaktadır.*********************
*******************************************************************
*
*******************************************************************
*This program is free software; you can redistribute it and/or
'modify it under the terms of the GNU General Public License
'as published by the Free Software Foundation; either version 2
*of the License, or (at your option) any later version.
*
*This program is distributed in the hope that it will be useful,
*but WITHOUT ANY WARRANTY; without even the implied warranty of
*MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
*GNU General Public License for more details.
*
*You should have received a copy of the GNU General Public License
*along with this program; if not, write to the Free Software
*Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.
*******************************************************************
*
*******************************************************************
*http://www.gnu.org/copyleft/gpl.html
*Turkce cevirisi: http://www.belgeler.org/howto/gpl_copy.html
*******************************************************************
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Patmat
{
  public partial class FormPiyon : Form
  {
    public FormPiyon()
    {
      InitializeComponent();
    }

    Image terfitasimg = Form1.img[1];
    private void FormPiyon_Load(object sender, EventArgs e)
    {
      //arkaplan rengi
      this.BackColor = Color.FromArgb(173, 142, 71);
    }

   
    private void button1_Click(object sender, EventArgs e)
    {
    
      string secilentas = "Vezir";
      if (radioButton_at.Checked == true)
      {
        secilentas = "At";
        if (Form1.terfiOyuncu == 1)
        terfitasimg = Form1.img[1];
        else if (Form1.terfiOyuncu == 2)
        terfitasimg = Form1.img[7];
      }
      else if (radioButton_fil.Checked == true)
      {
        secilentas = "Fil";
        if (Form1.terfiOyuncu == 1)
          terfitasimg = Form1.img[2];
        else if (Form1.terfiOyuncu == 2)
          terfitasimg = Form1.img[8];
      }
      else if (radioButton_kale.Checked == true)
      {
        secilentas = "Kale";
        if (Form1.terfiOyuncu == 1)
          terfitasimg = Form1.img[0];
        else if (Form1.terfiOyuncu == 2)
          terfitasimg = Form1.img[6];
      }
      else if (radioButton_vezir.Checked == true)
      {
        secilentas = "Vezir";
        if (Form1.terfiOyuncu == 1)
          terfitasimg = Form1.img[4];
        else if (Form1.terfiOyuncu == 2)
          terfitasimg = Form1.img[10];
      }
      //MessageBox.Show(secilentas);
      if (Form1.terfiOyuncu > 0)
      {
        Form1.lbl[Form1.terfiKoor0, Form1.terfiKoor1].Image = terfitasimg;
        Form1.tas[Form1.terfiKoor0, Form1.terfiKoor1] = Form1.terfiOyuncu + "," + secilentas;
        Form1.terfiOyuncu = 0;
        this.Close();
      }
    }


  }
}
