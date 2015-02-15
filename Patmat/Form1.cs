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
using System.IO;
using System.Media;

namespace Patmat
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

    }

    public static Label[,] lbl = new Label[8, 8];
    public static string[,] tas = new string[8, 8];
    public static Image[] img = new Image[12];
    DateTime myStartTime = new DateTime();
    string[] harf = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
    int[] puan = new int[2];
    int startlabelLeft = 30, startlabelTop = 37, sonkaydirmaTop = 0, sonkaydirmaLeft = 0, hareket = 0, devmod = 0, yardim = 1, toplamhamle = 0;
    public static string secim = "", oyuncu = "1";
    public static int terfiKoor0 = 0, terfiKoor1 = 0, terfiOyuncu = 0;
    int x = 0, t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0;

    private void Form1_Load(object sender, EventArgs e)
    {
      label_oyuncusirasi.Visible = false;
      listBox_puan.Visible = false;

      img[0] = Image.FromFile("data/Patmat.Bkale.png");
      img[1] = Image.FromFile("data/Patmat.Bat.png");
      img[2] = Image.FromFile("data/Patmat.Bfil.png");
      img[3] = Image.FromFile("data/Patmat.Bsah.png");
      img[4] = Image.FromFile("data/Patmat.Bvezir.png");
      img[5] = Image.FromFile("data/Patmat.Bpiyon.png");
      img[6] = Image.FromFile("data/Patmat.Skale.png");
      img[7] = Image.FromFile("data/Patmat.Sat.png");
      img[8] = Image.FromFile("data/Patmat.Sfil.png");
      img[9] = Image.FromFile("data/Patmat.Ssah.png");
      img[10] = Image.FromFile("data/Patmat.Svezir.png");
      img[11] = Image.FromFile("data/Patmat.Spiyon.png");


      //arkaplan rengi
      this.BackColor = Color.FromArgb(173, 142, 71);
      //görünmez label attık
      for (int i = 0; i < 8; i++)
      {
        for (int h = 0; h < 8; h++)
        {
          lbl[i, h] = new Label();
          lbl[i, h].BackColor = Color.Transparent;
          lbl[i, h].AutoSize = false;
          lbl[i, h].Height = 70;
          lbl[i, h].Width = 70;
          //lbl[i, h].Text = i + "," + h + ""; Koordinat Numarasını Oyun İçinde Gör
          lbl[i, h].Name = i + "," + h;

          lbl[i, h].Left = startlabelLeft;
          if (h == 0)
          {
            lbl[i, h].Top = startlabelTop;
            sonkaydirmaTop = lbl[i, h].Top;
          }
          else
          {
            lbl[i, h].Top = (sonkaydirmaTop) + ((h) * 70);
          }

          if (i == 0)
          {
            lbl[i, h].Left = startlabelLeft;
            sonkaydirmaLeft = lbl[i, h].Left;
          }
          else
          {
            lbl[i, h].Left = (sonkaydirmaLeft) + ((i) * 70);
          }
          this.Controls.Add(lbl[i, h]);
          lbl[i, h].Click += new EventHandler(lbl_Click);
        }
      }

      ////////////////////////////////////////////

    }
    string tastip = "";
    void lbl_Click(object sender, EventArgs e)
    {
      
      Label labeldavran = (Label)sender;

      

      
      
      if (hareket == 0)
      {
        secim = labeldavran.Name;
        string[] secim2coord = labeldavran.Name.Split(',');
        tastip = tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])];
        if (tastip == null)
        {
          return;
        }
        string[] tastipArr = tastip.Split(',');
       
        if (tastipArr[0] != oyuncu && devmod == 0)
        {
          return;
        }
        

        labeldavran.BackColor = Color.SeaGreen;
        
        string[] secimcoord = secim.Split(',');


        x = 0; t1 = 0; t2 = 0; t3 = 0; t4 = 0; t5 = 0; t6 = 0; t7 = 0; t8 = 0;
        //taşın hareket koordinatlarını göster
        if (yardim == 1)
        {
          TasHareketi(secimcoord, tastipArr);
        }
       
        
      }

      hareket++;
      if (hareket == 2)
      {
        string[] secim2coord = labeldavran.Name.Split(',');
        //ikinci tıklanan alanın taş bilgisi
        
        string[] secilenkareArr = new string[2];
        Array.Clear(secilenkareArr,0,secilenkareArr.Length);
        if (tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null)
        {
          string[] secilenkareBilgisi = tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])].Split(',');
          secilenkareArr[0] = secilenkareBilgisi[0]; // 1,2 Oyuncu Tipi
          secilenkareArr[1] = secilenkareBilgisi[1]; // Taş Tipi
        }


        //ilk tıklanan yani seçilen taş bilgisi
        string[] secimcoord = secim.Split(',');
        string[] tastipArr = tastip.Split(',');
        x = 0; t1 = 0; t2 = 0; t3 = 0; t4 = 0; t5 = 0; t6 = 0; t7 = 0; t8 = 0;
        int SECIM0 = int.Parse(secimcoord[0]);
        int SECIM1 = int.Parse(secimcoord[1]);

        if (tastipArr[0] == "1") // Beyaz
        {
          switch (tastipArr[1])
          {
            // secimcoord = ilk tıklanan taşın yeri
            // secim2coord = taşınmak istenen yer
            #region Beyaz Taşların Gideceği Koordinatlar
            case "Vezir":

              string[] VezirGidisKoorAlternatif = new String[64];
              Array.Clear(VezirGidisKoorAlternatif, 0, 64);

              for (int i = 1; i < 8; i++)
              {
                //Kale Sol
                if (SECIM0 - i <= 7 && SECIM0 - i >= 0 && t1 == 0)
                {
                  if (tas[SECIM0 - i, SECIM1] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                  }
                  else if (tas[SECIM0 - i, SECIM1] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                    t1 = 1;
                  }
                }
                //Kale Sağ
                if (SECIM0 + i <= 7 && SECIM0 + i >= 0 && t2 == 0)
                {
                  if (tas[SECIM0 + i, SECIM1] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                  }
                  else if (tas[SECIM0 + i, SECIM1] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                    t2 = 1;
                  }
                }
                //Kale Yukarı
                if (SECIM1 - i >= 0 && SECIM1 - i <= 7 && t3 == 0)
                {
                  if (tas[SECIM0, SECIM1 - i] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                  }
                  else if (tas[SECIM0, SECIM1 - i] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                    t3 = 1;
                  }
                }
                //Kale Aşağı
                if (SECIM1 + i >= 0 && SECIM1 + i <= 7 && t4 == 0)
                {
                  if (tas[SECIM0, SECIM1 + i] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                  }
                  else if (tas[SECIM0, SECIM1 + i] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                    t4 = 1;
                  }
                }
                // Fil Kontrolü
                if (SECIM0 - i <= 7 && SECIM0 - i >= 0 && SECIM1 - i >= 0 && SECIM1 - i <= 7 && t5 == 0)
                {
                  if (tas[SECIM0 - i, SECIM1 - i] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                  }
                  else if (tas[SECIM0 - i, SECIM1 - i] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                    t5 = 1;
                  }
                }
                if (SECIM0 + i <= 7 && SECIM0 + i >= 0 && SECIM1 - i <= 7 && SECIM1 - i >= 0 && t6 == 0)
                {
                  if (tas[SECIM0 + i, SECIM1 - i] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                  }
                  else if (tas[SECIM0 + i, SECIM1 - i] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                    t6 = 1;
                  }
                }
                if (SECIM0 - i <= 7 && SECIM0 - i >= 0 && SECIM1 + i <= 7 && SECIM1 + i >= 0 && t7 == 0)
                {
                  if (tas[SECIM0 - i, SECIM1 + i] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                  }
                  else if (tas[SECIM0 - i, SECIM1 + i] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                    t7 = 1;
                  }
                }
                if (SECIM0 + i >= 0 && SECIM0 + i <= 7 && SECIM1 + i <= 7 && SECIM1 + i >= 0 && t8 == 0)
                {
                  if (tas[SECIM0 + i, SECIM1 + i] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                  }
                  else if (tas[SECIM0 + i, SECIM1 + i] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                    t8 = 1;
                  }
                }


              }


              bool hasVezirGidis = Array.IndexOf(VezirGidisKoorAlternatif, secim2coord[0] + "," + secim2coord[1]) >= 0;
              if (hasVezirGidis == true && tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null && secilenkareArr[0] == "2")
              {
                //MessageBox.Show("Yediniz", "Patmat");
                puan[0] += 1; SkorDurumuYaz();
              }
              else if (hasVezirGidis == false || tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null)
              {
                hareket = 0; resetle(labeldavran, secimcoord); return;
              }

              break;
            //#########################################################################################
            case "Şah":

              string[] SahGidisKoorAlternatif = new String[]{
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1])),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1])), 
                (int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) - 1), 
                (int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) + 1)
              };
       bool hasSahGidis = Array.IndexOf(SahGidisKoorAlternatif, secim2coord[0] + "," + secim2coord[1]) >= 0;
       if (hasSahGidis == true && tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null && secilenkareArr[0] == "2")
              {
                //MessageBox.Show("Yediniz", "Patmat");
                puan[0] += 1; SkorDurumuYaz();
              }
              else if (hasSahGidis == false || tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null)
              {
                hareket = 0; resetle(labeldavran, secimcoord); return;
              }

              break;
            //#########################################################################################
            case "Kale":

              string[] KaleGidisKoorAlternatif = new String[64];
              Array.Clear(KaleGidisKoorAlternatif, 0, 64);

              for (int i = 1; i < 8; i++)
              {
                //Kale Sol
                if (SECIM0 - i <= 7 && SECIM0 - i >= 0 && t1 == 0)
                {
                  if (tas[SECIM0 - i, SECIM1] == null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) );
                    x++;
                  }
                  else if (tas[SECIM0 - i, SECIM1] != null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) );
                    x++;
                    t1 = 1;
                  }
                }
                //Kale Sağ
                if (SECIM0 + i <= 7 && SECIM0 + i >= 0 && t2 == 0)
                {
                  if (tas[SECIM0 + i, SECIM1] == null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                  }
                  else if (tas[SECIM0 + i, SECIM1] != null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                    t2 = 1;
                  }
                }
                //Kale Yukarı
                if (SECIM1 - i >= 0 && SECIM1 - i <= 7 && t3 == 0)
                {
                  if (tas[SECIM0, SECIM1 - i] == null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                  }
                  else if (tas[SECIM0, SECIM1 - i] != null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                    t3 = 1;
                  }
                }
                //Kale Aşağı
                if (SECIM1 + i >= 0 && SECIM1 + i <= 7 && t4 == 0)
                {
                  if (tas[SECIM0, SECIM1 + i] == null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                  }
                  else if (tas[SECIM0, SECIM1 + i] != null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                    t4 = 1;
                  }
                }
     

              }


              bool hasKaleGidis = Array.IndexOf(KaleGidisKoorAlternatif, secim2coord[0] + "," + secim2coord[1]) >= 0;
              if (hasKaleGidis == true && tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null && secilenkareArr[0] == "2")
              {
                //MessageBox.Show("Yediniz", "Patmat");
                puan[0] += 1; SkorDurumuYaz();
              }
              else if (hasKaleGidis == false || tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null)
              {
                hareket = 0; resetle(labeldavran, secimcoord); return;
              }

              break;
            //#########################################################################################

            case "Fil":
              
              string[] FilGidisKoorAlternatif = new String[64];
              Array.Clear(FilGidisKoorAlternatif, 0, 64);
              for (int i = 1; i < 8; i++)
              {
                    if (SECIM0 - i <= 7 && SECIM0 - i >= 0 && SECIM1 - i >= 0 && SECIM1 - i <= 7 && t1 == 0)
                    {
                      if (tas[SECIM0 - i, SECIM1 - i] == null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                        x++;
                      }
                      else if (tas[SECIM0 - i, SECIM1 - i] != null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                        x++;
                        t1 = 1;
                      }
                    }
                    if (SECIM0 + i <= 7 &&  SECIM0 + i >= 0 && SECIM1 - i <= 7 && SECIM1 - i >= 0 && t2 == 0)
                    {
                      if (tas[SECIM0 + i, SECIM1 - i] == null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                        x++;
                      }
                      else if (tas[SECIM0 + i, SECIM1 - i] != null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                        x++;
                        t2 = 1;
                      }
                    }
                    if (SECIM0 - i <= 7 && SECIM0 - i >= 0 && SECIM1 + i <= 7 && SECIM1 + i >= 0 && t3 == 0)
                    {
                      if (tas[SECIM0 - i, SECIM1 + i] == null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                        x++;
                      }
                      else if (tas[SECIM0 - i, SECIM1 + i] != null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                        x++;
                        t3 = 1;
                      }
                    }
                    if (SECIM0 + i >= 0 && SECIM0 + i <= 7 && SECIM1 + i <= 7 && SECIM1 + i >= 0 && t4 == 0)
                    {
                      if (tas[SECIM0 + i, SECIM1 + i] == null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                        x++;
                      }
                      else if (tas[SECIM0 + i, SECIM1 + i] != null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                        x++;
                        t4 = 1;
                      }
                    }
                  
              }


      bool hasFilGidis = Array.IndexOf(FilGidisKoorAlternatif, secim2coord[0] + "," + secim2coord[1]) >= 0;
      if (hasFilGidis == true && tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null && secilenkareArr[0] == "2")
              {
                //MessageBox.Show("Yediniz", "Patmat");
                puan[0] += 1; SkorDurumuYaz();
              }
              else if (hasFilGidis == false || tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null)
              {
                hareket = 0; resetle(labeldavran, secimcoord); return;
              }

              break;
//#########################################################################################
            case "At":
              string[] AtGidisKoor = new String[]{
                (int.Parse(secimcoord[0]) - 2) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) - 2) +","+    (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) + 2) + "," + (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) + 2) + "," + (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) - 1) + "," + (int.Parse(secimcoord[1]) - 2),
                (int.Parse(secimcoord[0])+1) +","+(int.Parse(secimcoord[1]) -2)  ,
                (int.Parse(secimcoord[0]) - 1) +"," + (int.Parse(secimcoord[1]) + 2),
                (int.Parse(secimcoord[0]) + 1) + "," + (int.Parse(secimcoord[1]) + 2)};

              bool hasAtGidis = Array.IndexOf(AtGidisKoor, secim2coord[0]+","+secim2coord[1]) >= 0;
              
              if (hasAtGidis == true && tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null && secilenkareArr[0] == "2")
              {
                //MessageBox.Show("Yediniz", "Patmat");
                puan[0] += 1; SkorDurumuYaz();
              }else if (hasAtGidis == false || tas[int.Parse(secim2coord[0]),int.Parse(secim2coord[1])] != null)
              {
                hareket = 0; resetle(labeldavran, secimcoord); return;
              }

              break;
            //######################################################
            case "Piyon":
              int fark = int.Parse(secimcoord[1]) - int.Parse(secim2coord[1]);

              string[] PiyonGidisKoorAlternatif = new String[]{
                //(int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) - 1),
                //(int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) - 1)                
              };
              if (int.Parse(secimcoord[1]) == 6)
              {
                if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1])-1] == null)
                {
                  Array.Resize(ref PiyonGidisKoorAlternatif, PiyonGidisKoorAlternatif.Length + 1);
                  PiyonGidisKoorAlternatif[1] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - 2);
                }
              }


              string[] PiyonYeGidisKoorAlternatif = new String[]{
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) - 1),
                //(int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) - 1)
              };
              bool hasPiyonGidis = Array.IndexOf(PiyonGidisKoorAlternatif, secim2coord[0] + "," + secim2coord[1]) >= 0;
              
                

              bool hasPiyonYeGidis = Array.IndexOf(PiyonYeGidisKoorAlternatif, secim2coord[0] + "," + secim2coord[1]) >= 0;
if (hasPiyonYeGidis == true && tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null && secilenkareArr[0] == "2")
              {
                //MessageBox.Show("Yediniz", "Patmat");
                puan[0] += 1; SkorDurumuYaz();
              }
              else if (hasPiyonGidis == false || tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null)
              {
                hareket = 0; resetle(labeldavran, secimcoord); return;
              }

              break;
            //######################################################
            #endregion
          }
        }
        else if (tastipArr[0] == "2") // Siyah
        {
          switch (tastipArr[1])
          {
            #region Siyah Taşların Gideceği Koordinatlar
            case "Vezir":

              string[] VezirGidisKoorAlternatif = new String[64];
              Array.Clear(VezirGidisKoorAlternatif, 0, 64);

              for (int i = 1; i < 8; i++)
              {
                //Kale Sol
                if (SECIM0 - i <= 7 && SECIM0 - i >= 0 && t1 == 0)
                {
                  if (tas[SECIM0 - i, SECIM1] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                  }
                  else if (tas[SECIM0 - i, SECIM1] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                    t1 = 1;
                  }
                }
                //Kale Sağ
                if (SECIM0 + i <= 7 && SECIM0 + i >= 0 && t2 == 0)
                {
                  if (tas[SECIM0 + i, SECIM1] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                  }
                  else if (tas[SECIM0 + i, SECIM1] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                    t2 = 1;
                  }
                }
                //Kale Yukarı
                if (SECIM1 - i >= 0 && SECIM1 - i <= 7 && t3 == 0)
                {
                  if (tas[SECIM0, SECIM1 - i] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                  }
                  else if (tas[SECIM0, SECIM1 - i] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                    t3 = 1;
                  }
                }
                //Kale Aşağı
                if (SECIM1 + i >= 0 && SECIM1 + i <= 7 && t4 == 0)
                {
                  if (tas[SECIM0, SECIM1 + i] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                  }
                  else if (tas[SECIM0, SECIM1 + i] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                    t4 = 1;
                  }
                }
                // Fil Kontrolü
                if (SECIM0 - i <= 7 && SECIM0 - i >= 0 && SECIM1 - i >= 0 && SECIM1 - i <= 7 && t5 == 0)
                {
                  if (tas[SECIM0 - i, SECIM1 - i] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                  }
                  else if (tas[SECIM0 - i, SECIM1 - i] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                    t5 = 1;
                  }
                }
                if (SECIM0 + i <= 7 && SECIM0 + i >= 0 && SECIM1 - i <= 7 && SECIM1 - i >= 0 && t6 == 0)
                {
                  if (tas[SECIM0 + i, SECIM1 - i] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                  }
                  else if (tas[SECIM0 + i, SECIM1 - i] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                    t6 = 1;
                  }
                }
                if (SECIM0 - i <= 7 && SECIM0 - i >= 0 && SECIM1 + i <= 7 && SECIM1 + i >= 0 && t7 == 0)
                {
                  if (tas[SECIM0 - i, SECIM1 + i] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                  }
                  else if (tas[SECIM0 - i, SECIM1 + i] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                    t7 = 1;
                  }
                }
                if (SECIM0 + i >= 0 && SECIM0 + i <= 7 && SECIM1 + i <= 7 && SECIM1 + i >= 0 && t8 == 0)
                {
                  if (tas[SECIM0 + i, SECIM1 + i] == null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                  }
                  else if (tas[SECIM0 + i, SECIM1 + i] != null)
                  {
                    VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                    t8 = 1;
                  }
                }


              }


              bool hasVezirGidis = Array.IndexOf(VezirGidisKoorAlternatif, secim2coord[0] + "," + secim2coord[1]) >= 0;
              if (hasVezirGidis == true && tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null && secilenkareArr[0] == "1")
              {
                //MessageBox.Show("Yediniz", "Patmat");
                puan[1] += 1; SkorDurumuYaz();
              }
              else if (hasVezirGidis == false || tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null)
              {
                hareket = 0; resetle(labeldavran, secimcoord); return;
              }

              break;
            //#########################################################################################
            case "Şah":

              string[] SahGidisKoorAlternatif = new String[]{
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1])),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1])), 
                (int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) - 1), 
                (int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) + 1)
              };
              bool hasSahGidis = Array.IndexOf(SahGidisKoorAlternatif, secim2coord[0] + "," + secim2coord[1]) >= 0;
              if (hasSahGidis == true && tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null && secilenkareArr[0] == "1")
              {
                //MessageBox.Show("Yediniz", "Patmat");
                puan[1] += 1; SkorDurumuYaz();
              }
              else if (hasSahGidis == false || tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null)
              {
                hareket = 0; resetle(labeldavran, secimcoord); return;
              }

              break;
            //#########################################################################################
            case "Kale":

              string[] KaleGidisKoorAlternatif = new String[64];
              Array.Clear(KaleGidisKoorAlternatif, 0, 64);

              for (int i = 1; i < 8; i++)
              {
                //Kale Sol
                if (SECIM0 - i <= 7 && SECIM0 - i >= 0 && t1 == 0)
                {
                  if (tas[SECIM0 - i, SECIM1] == null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                  }
                  else if (tas[SECIM0 - i, SECIM1] != null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                    t1 = 1;
                  }
                }
                //Kale Sağ
                if (SECIM0 + i <= 7 && SECIM0 + i >= 0 && t2 == 0)
                {
                  if (tas[SECIM0 + i, SECIM1] == null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                  }
                  else if (tas[SECIM0 + i, SECIM1] != null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                    t2 = 1;
                  }
                }
                //Kale Yukarı
                if (SECIM1 - i >= 0 && SECIM1 - i <= 7 && t3 == 0)
                {
                  if (tas[SECIM0, SECIM1 - i] == null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                  }
                  else if (tas[SECIM0, SECIM1 - i] != null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                    t3 = 1;
                  }
                }
                //Kale Aşağı
                if (SECIM1 + i >= 0 && SECIM1 + i <= 7 && t4 == 0)
                {
                  if (tas[SECIM0, SECIM1 + i] == null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                  }
                  else if (tas[SECIM0, SECIM1 + i] != null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                    t4 = 1;
                  }
                }


              }


              bool hasKaleGidis = Array.IndexOf(KaleGidisKoorAlternatif, secim2coord[0] + "," + secim2coord[1]) >= 0;
              if (hasKaleGidis == true && tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null && secilenkareArr[0] == "1")
              {
                //MessageBox.Show("Yediniz", "Patmat");
                puan[1] += 1; SkorDurumuYaz();
              }
              else if (hasKaleGidis == false || tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null)
              {
                hareket = 0; resetle(labeldavran, secimcoord); return;
              }

              break;
            //#########################################################################################

            case "Fil":

              string[] FilGidisKoorAlternatif = new String[64];
              Array.Clear(FilGidisKoorAlternatif, 0, 64);
              for (int i = 1; i < 8; i++)
              {
                if (SECIM0 - i <= 7 && SECIM0 - i >= 0 && SECIM1 - i >= 0 && SECIM1 - i <= 7 && t1 == 0)
                {
                  if (tas[SECIM0 - i, SECIM1 - i] == null)
                  {
                    FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                  }
                  else if (tas[SECIM0 - i, SECIM1 - i] != null)
                  {
                    FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                    t1 = 1;
                  }
                }
                if (SECIM0 + i <= 7 && SECIM0 + i >= 0 && SECIM1 - i <= 7 && SECIM1 - i >= 0 && t2 == 0)
                {
                  if (tas[SECIM0 + i, SECIM1 - i] == null)
                  {
                    FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                  }
                  else if (tas[SECIM0 + i, SECIM1 - i] != null)
                  {
                    FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                    t2 = 1;
                  }
                }
                if (SECIM0 - i <= 7 && SECIM0 - i >= 0 && SECIM1 + i <= 7 && SECIM1 + i >= 0 && t3 == 0)
                {
                  if (tas[SECIM0 - i, SECIM1 + i] == null)
                  {
                    FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                  }
                  else if (tas[SECIM0 - i, SECIM1 + i] != null)
                  {
                    FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                    t3 = 1;
                  }
                }
                if (SECIM0 + i >= 0 && SECIM0 + i <= 7 && SECIM1 + i <= 7 && SECIM1 + i >= 0 && t4 == 0)
                {
                  if (tas[SECIM0 + i, SECIM1 + i] == null)
                  {
                    FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                  }
                  else if (tas[SECIM0 + i, SECIM1 + i] != null)
                  {
                    FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                    t4 = 1;
                  }
                }

              }


              bool hasFilGidis = Array.IndexOf(FilGidisKoorAlternatif, secim2coord[0] + "," + secim2coord[1]) >= 0;
              if (hasFilGidis == true && tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null && secilenkareArr[0] == "1")
              {
                //MessageBox.Show("Yediniz", "Patmat");
                puan[1] += 1; SkorDurumuYaz();
              }
              else if (hasFilGidis == false || tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null)
              {
                hareket = 0; resetle(labeldavran, secimcoord); return;
              }

              break;
            //#########################################################################################
            case "At":
              string[] AtGidisKoor = new String[]{
                (int.Parse(secimcoord[0]) - 2) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) - 2) +","+    (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) + 2) + "," + (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) + 2) + "," + (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) - 1) + "," + (int.Parse(secimcoord[1]) - 2),
                (int.Parse(secimcoord[0])+1) +","+(int.Parse(secimcoord[1]) -2)  ,
                (int.Parse(secimcoord[0]) - 1) +"," + (int.Parse(secimcoord[1]) + 2),
                (int.Parse(secimcoord[0]) + 1) + "," + (int.Parse(secimcoord[1]) + 2)};

              bool hasAtGidis = Array.IndexOf(AtGidisKoor, secim2coord[0] + "," + secim2coord[1]) >= 0;

              if (hasAtGidis == true && tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null && secilenkareArr[0] == "1")
              {
                //MessageBox.Show("Yediniz", "Patmat");
                puan[1] += 1; SkorDurumuYaz();
              }
              else if (hasAtGidis == false || tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null)
              {
                hareket = 0; resetle(labeldavran, secimcoord); return;
              }

              break;
//###################################################################################################################
            case "Piyon":
              string[] PiyonGidisKoorAlternatif = new String[]{
                //(int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) - 1),
                //(int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) + 1)                
              };

              if (int.Parse(secimcoord[1]) == 1)
              {
                if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) + 1] == null)
                {
                  Array.Resize(ref PiyonGidisKoorAlternatif, PiyonGidisKoorAlternatif.Length + 1);
                  PiyonGidisKoorAlternatif[1] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + 2);
                }
              }


              string[] PiyonYeGidisKoorAlternatif = new String[]{
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) + 1),
                //(int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) - 1)
              };
              bool hasPiyonGidis = Array.IndexOf(PiyonGidisKoorAlternatif, secim2coord[0] + "," + secim2coord[1]) >= 0;
              bool hasPiyonYeGidis = Array.IndexOf(PiyonYeGidisKoorAlternatif, secim2coord[0] + "," + secim2coord[1]) >= 0;
              if (hasPiyonYeGidis == true && tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null && secilenkareArr[0] == "1")
              {
                //MessageBox.Show("Yediniz","Patmat");
                puan[1] += 1; SkorDurumuYaz();
              }
              else if (hasPiyonGidis == false || tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] != null)
              {
                hareket = 0; resetle(labeldavran, secimcoord); return;
              }

              break;

            //######################################################

            #endregion
          }
        }





        string secimdenevar = tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1])];
        string[] secimdenevarArr = secimdenevar.Split(',');
        terfiKoor0 = int.Parse(secim2coord[0]);
        terfiKoor1 = int.Parse(secim2coord[1]);
        terfiOyuncu = int.Parse(secimdenevarArr[0]);

        if (tastipArr[1] == "Piyon" && secimdenevarArr[0] == "1" && int.Parse(secim2coord[1]) == 0)
        {
          FormPiyon frmpiyon = new FormPiyon();
          frmpiyon.Show();
        }
        else if (tastipArr[1] == "Piyon" && secimdenevarArr[0] == "2" && int.Parse(secim2coord[1]) == 7)
        {
          FormPiyon frmpiyon = new FormPiyon();
          frmpiyon.Show();
        }
        





        //şah kontrol
        if (tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] == "1,Şah" && secimdenevarArr[0] == "2")
        {
          SesCal(2); oyuncu = "0"; timer_gecensure.Stop();
          MessageBox.Show("Siyah Oyuncu Kazandı! Tebrikler..", "Patmat");
        }
        else if (tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] == "2,Şah" && secimdenevarArr[0] == "1")
        {
          SesCal(2); oyuncu = "0"; timer_gecensure.Stop();
          MessageBox.Show("Beyaz Oyuncu Kazandı! Tebrikler..", "Patmat");
        }

        if (lbl[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])].Image != null)
        {
          SesCal(1);
        }
        else
        {
          SesCal(0);
        }

        labeldavran.Image = lbl[int.Parse(secimcoord[0]), int.Parse(secimcoord[1])].Image;
        lbl[int.Parse(secimcoord[0]), int.Parse(secimcoord[1])].Image = null;
        tas[int.Parse(secim2coord[0]), int.Parse(secim2coord[1])] = tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1])];



        resetle(labeldavran, secimcoord);


        

        string oisim = "";
        if (secimdenevarArr[0] == "1") { oisim = "Beyaz"; }
        else if (secimdenevarArr[0] == "2") { oisim = "Siyah";  }

        //nereden nereye taşındıgı bilgisini eklet.
        listBox_hareket.Items.Add(oisim + " | " + secimdenevarArr[1] + " | " + harf[int.Parse(secimcoord[0])] + (8 - int.Parse(secimcoord[1])) + "=>" + harf[int.Parse(secim2coord[0])] + (8 - int.Parse(secim2coord[1])) + "");
        listBox_hareket.SelectedIndex = listBox_hareket.Items.Count-1;

        

        //taşınan taşı bulunduğu diziden sil
        tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1])] = null;
        //MessageBox.Show(labeldavran.Name);
        hareket = 0;
        toplamhamle += 1;
        label_toplamhamle.Text = toplamhamle.ToString();

         if (oyuncu == "1")
         {
           oyuncu = "2";
           label_oyuncusirasi.Text = "Sıra Siyahta";
           label_oyuncusirasi.BackColor = Color.Black;
           label_oyuncusirasi.ForeColor = Color.White;
           //SesCal(0);
         }
         else if (oyuncu == "2")
         {
           oyuncu = "1";
           label_oyuncusirasi.Text = "Sıra Beyazda";
           label_oyuncusirasi.BackColor = Color.White;
           label_oyuncusirasi.ForeColor = Color.Black;
           //SesCal(0);
         }
         else
         {
           label_oyuncusirasi.Text = "Oyun Bitti";
           label_oyuncusirasi.BackColor = Color.Orange;
           label_oyuncusirasi.ForeColor = Color.White;
         }

      }
     
    }



    private void resetle(Label labeldavran, string[] secimcoord)
    {
      // RESETLE
      foreach (var item in lbl)
      {
        if (labeldavran.Name != item.Name)
        {
          item.BackColor = Color.Transparent;
          lbl[int.Parse(secimcoord[0]), int.Parse(secimcoord[1])].BackColor = Color.Transparent;
        }
      }
      labeldavran.BackColor = Color.Transparent;
      ////////// Resetle bitiş
    }



    private void TasHareketi(string[] secimcoord, string[] tastipArr)
    {

      if (tastipArr[0] == "1")
      {
        switch (tastipArr[1])
        {
          #region Beyaz Taz Hareketleri
          case "Vezir":
            string[] VezirGidisKoorAlternatif = new String[64];
            Array.Clear(VezirGidisKoorAlternatif, 0, 64);
            for (int i = 1; i < 8; i++)
            {
              //Kale Sol
              if (int.Parse(secimcoord[0]) - i <= 7 && int.Parse(secimcoord[0]) - i >= 0 && t1 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1])] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1])] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                  x++;
                  t1 = 1;
                }
              }
              //Kale Sağ
              if (int.Parse(secimcoord[0]) + i <= 7 && int.Parse(secimcoord[0]) + i >= 0 && t2 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1])] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1])] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                  x++;
                  t2 = 1;
                }
              }
              //Kale Yukarı
              if (int.Parse(secimcoord[1]) - i >= 0 && int.Parse(secimcoord[1]) - i <= 7 && t3 == 0)
              {
                if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) - i] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) - i] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                  t3 = 1;
                }
              }
              //Kale Aşağı
              if (int.Parse(secimcoord[1]) + i >= 0 && int.Parse(secimcoord[1]) + i <= 7 && t4 == 0)
              {
                if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) + i] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) + i] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                  t4 = 1;
                }
              }
              // Fil Kontrolü
              if (int.Parse(secimcoord[0]) - i <= 7 && int.Parse(secimcoord[0]) - i >= 0 && int.Parse(secimcoord[1]) - i >= 0 && int.Parse(secimcoord[1]) - i <= 7 && t5 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) - i] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) - i] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                  t5 = 1;
                }
              }
              if (int.Parse(secimcoord[0]) + i <= 7 && int.Parse(secimcoord[0]) + i >= 0 && int.Parse(secimcoord[1]) - i <= 7 && int.Parse(secimcoord[1]) - i >= 0 && t6 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) - i] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) - i] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                  t6 = 1;
                }
              }
              if (int.Parse(secimcoord[0]) - i <= 7 && int.Parse(secimcoord[0]) - i >= 0 && int.Parse(secimcoord[1]) + i <= 7 && int.Parse(secimcoord[1]) + i >= 0 && t7 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) + i] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) + i] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                  t7 = 1;
                }
              }
              if (int.Parse(secimcoord[0]) + i >= 0 && int.Parse(secimcoord[0]) + i <= 7 && int.Parse(secimcoord[1]) + i <= 7 && int.Parse(secimcoord[1]) + i >= 0 && t8 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) + i] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) + i] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                  t8 = 1;
                }
              }

            }

            //Yolları Renklendir
            Array.Sort(VezirGidisKoorAlternatif);
            Array.Reverse(VezirGidisKoorAlternatif);
            Array.Resize(ref VezirGidisKoorAlternatif, x);
            for (int i = 0; i < VezirGidisKoorAlternatif.Length; i++)
            {

              string[] KooRD = VezirGidisKoorAlternatif[i].Split(',');
              if (int.Parse(KooRD[0]) <= 7 && int.Parse(KooRD[0]) >= 0 && int.Parse(KooRD[1]) <= 7 && int.Parse(KooRD[1]) >= 0)
              {
                
                if (tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])] != null)
                {
                  string[] dusmantas = tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])].Split(',');
                  if (dusmantas[0] == "2")
                  lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.Brown;
                }
                else
                {
                  lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.FromArgb(100, 0, 0, 0);
                }
              }
            }
            // END Yolları Renklendir

            break;
          case "Şah":
            string[] SahGidisKoorAlternatif = new String[]{
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1])),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1])), 
                (int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) - 1), 
                (int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) + 1)
              };

            //Yolları Renklendir
            for (int i = 0; i < SahGidisKoorAlternatif.Length; i++)
            {
              string[] KooRD = SahGidisKoorAlternatif[i].Split(',');
              if (int.Parse(KooRD[0]) <= 7 && int.Parse(KooRD[0]) >= 0 && int.Parse(KooRD[1]) <= 7 && int.Parse(KooRD[1]) >= 0)
              {
                if (tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])] != null)
                {
                  string[] dusmantas = tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])].Split(',');
                  if (dusmantas[0] == "2")
                    lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.Brown;
                }
                else
                {
                  lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.FromArgb(100, 0, 0, 0);
                }
              }
            }
            //END Yolları Renklendir.
            break;
          case "Piyon":
            string[] PiyonGidisKoorAlternatif = new String[]{
                //(int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) - 1),
                //(int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) - 1)                
              };

            if (int.Parse(secimcoord[1]) == 6)
            {
              if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) - 1] == null)
              {
                Array.Resize(ref PiyonGidisKoorAlternatif, PiyonGidisKoorAlternatif.Length + 1);
                PiyonGidisKoorAlternatif[1] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - 2);
              }
            }

            string[] PiyonYeGidisKoorAlternatif = new String[]{
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) - 1),
                //(int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) - 1)
              };

            //Yolları Renklendir
            for (int i = 0; i < PiyonGidisKoorAlternatif.Length; i++)
            {
              string[] KooRD = PiyonGidisKoorAlternatif[i].Split(',');
              string[] KooRDPiyonYe = PiyonYeGidisKoorAlternatif[i].Split(',');

              if (int.Parse(KooRD[0]) <= 7 && int.Parse(KooRD[0]) >= 0 && int.Parse(KooRD[1]) <= 7 && int.Parse(KooRD[1]) >= 0)
              {
                if (tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])] == null)
                {
                  lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.FromArgb(100, 0, 0, 0);
                }
              }
            }

            for (int i = 0; i < PiyonYeGidisKoorAlternatif.Length; i++)
            {
              string[] KooRDPiyonYe = PiyonYeGidisKoorAlternatif[i].Split(',');
              if (int.Parse(KooRDPiyonYe[0]) <= 7 && int.Parse(KooRDPiyonYe[0]) >= 0 && int.Parse(KooRDPiyonYe[1]) <= 7 && int.Parse(KooRDPiyonYe[1]) >= 0)
              {
                if (tas[int.Parse(KooRDPiyonYe[0]), int.Parse(KooRDPiyonYe[1])] != null)
                {
                  string[] dusmantas = tas[int.Parse(KooRDPiyonYe[0]), int.Parse(KooRDPiyonYe[1])].Split(',');
                  if (dusmantas[0] == "2")
                    lbl[int.Parse(KooRDPiyonYe[0]), int.Parse(KooRDPiyonYe[1])].BackColor = Color.Brown;
                }
              }
            }
            // END Yolları Renklendir


            break;

          case "At":
            string[] AtGidisKoor = new String[]{
                (int.Parse(secimcoord[0]) - 2) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) - 2) +","+    (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) + 2) + "," + (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) + 2) + "," + (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) - 1) + "," + (int.Parse(secimcoord[1]) - 2),
                (int.Parse(secimcoord[0])+1) +","+(int.Parse(secimcoord[1]) -2)  ,
                (int.Parse(secimcoord[0]) - 1) +"," + (int.Parse(secimcoord[1]) + 2),
                (int.Parse(secimcoord[0]) + 1) + "," + (int.Parse(secimcoord[1]) + 2)};

            //Yolları Renklendir
            for (int i = 0; i < AtGidisKoor.Length; i++)
            {
              string[] KooRD = AtGidisKoor[i].Split(',');
              if (int.Parse(KooRD[0]) <= 7 && int.Parse(KooRD[0]) >= 0 && int.Parse(KooRD[1]) <= 7 && int.Parse(KooRD[1]) >= 0)
              {
                if (tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])] != null)
                {
                  string[] dusmantas = tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])].Split(',');
                  if (dusmantas[0] == "2")
                  lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.Brown;
                }
                else
                {
                  lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.FromArgb(100, 0, 0, 0);
                }
              }
            }
            //END Yolları Renklendir.
            break;


          case "Fil":
            string[] FilGidisKoorAlternatif = new String[64];
              Array.Clear(FilGidisKoorAlternatif, 0, 64);
              for (int i = 1; i < 8; i++)
              {
                    if (int.Parse(secimcoord[0]) - i <= 7 && int.Parse(secimcoord[0]) - i >= 0 && int.Parse(secimcoord[1]) - i >= 0 && int.Parse(secimcoord[1]) - i <= 7 && t1 == 0)
                    {
                      if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) - i] == null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                        x++;
                      }
                      else if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) - i] != null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                        x++;
                        t1 = 1;
                      }
                    }
                    if (int.Parse(secimcoord[0]) + i <= 7 &&  int.Parse(secimcoord[0]) + i >= 0 && int.Parse(secimcoord[1]) - i <= 7 && int.Parse(secimcoord[1]) - i >= 0 && t2 == 0)
                    {
                      if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) - i] == null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                        x++;
                      }
                      else if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) - i] != null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                        x++;
                        t2 = 1;
                      }
                    }
                    if (int.Parse(secimcoord[0]) - i <= 7 && int.Parse(secimcoord[0]) - i >= 0 && int.Parse(secimcoord[1]) + i <= 7 && int.Parse(secimcoord[1]) + i >= 0 && t3 == 0)
                    {
                      if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) + i] == null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                        x++;
                      }
                      else if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) + i] != null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                        x++;
                        t3 = 1;
                      }
                    }
                    if (int.Parse(secimcoord[0]) + i >= 0 && int.Parse(secimcoord[0]) + i <= 7 && int.Parse(secimcoord[1]) + i <= 7 && int.Parse(secimcoord[1]) + i >= 0 && t4 == 0)
                    {
                      if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) + i] == null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                        x++;
                      }
                      else if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) + i] != null)
                      {
                        FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                        x++;
                        t4 = 1;
                      }
                    }
                  
              }
              //Yolları Renklendir
              Array.Sort(FilGidisKoorAlternatif);
              Array.Reverse(FilGidisKoorAlternatif);
              Array.Resize(ref FilGidisKoorAlternatif, x);
              for (int i = 0; i < FilGidisKoorAlternatif.Length; i++)
              {

                string[] KooRD = FilGidisKoorAlternatif[i].Split(',');
                if (int.Parse(KooRD[0]) <= 7 && int.Parse(KooRD[0]) >= 0 && int.Parse(KooRD[1]) <= 7 && int.Parse(KooRD[1]) >= 0)
                {

                  if (tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])] != null)
                  {
                    string[] dusmantas = tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])].Split(',');
                    if (dusmantas[0] == "2")
                      lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.Brown;
                  }
                  else
                  {
                    lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.FromArgb(100, 0, 0, 0);
                  }
                }
              }
              // END Yolları Renklendir
            break;
          case "Kale":
            string[] KaleGidisKoorAlternatif = new String[64];
              Array.Clear(KaleGidisKoorAlternatif, 0, 64);
              for (int i = 1; i < 8; i++)
              {
                //Kale Sol
                if (int.Parse(secimcoord[0]) - i <= 7 && int.Parse(secimcoord[0]) - i >= 0 && t1 == 0)
                {
                  if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1])] == null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                  }
                  else if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1])] != null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                    t1 = 1;
                  }
                }
                //Kale Sağ
                if (int.Parse(secimcoord[0]) + i <= 7 && int.Parse(secimcoord[0]) + i >= 0 && t2 == 0)
                {
                  if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1])] == null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                  }
                  else if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1])] != null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                    x++;
                    t2 = 1;
                  }
                }
                //Kale Yukarı
                if (int.Parse(secimcoord[1]) - i >= 0 && int.Parse(secimcoord[1]) - i <= 7 && t3 == 0)
                {
                  if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) - i] == null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                  }
                  else if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) - i] != null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                    x++;
                    t3 = 1;
                  }
                }
                //Kale Aşağı
                if (int.Parse(secimcoord[1]) + i >= 0 && int.Parse(secimcoord[1]) + i <= 7 && t4 == 0)
                {
                  if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) + i] == null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                  }
                  else if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) + i] != null)
                  {
                    KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                    x++;
                    t4 = 1;
                  }
                }
              }
              //Yolları Renklendir
              Array.Sort(KaleGidisKoorAlternatif);
              Array.Reverse(KaleGidisKoorAlternatif);
              Array.Resize(ref KaleGidisKoorAlternatif, x);
              for (int i = 0; i < KaleGidisKoorAlternatif.Length; i++)
              {

                string[] KooRD = KaleGidisKoorAlternatif[i].Split(',');
                if (int.Parse(KooRD[0]) <= 7 && int.Parse(KooRD[0]) >= 0 && int.Parse(KooRD[1]) <= 7 && int.Parse(KooRD[1]) >= 0)
                {

                  if (tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])] != null)
                  {
                    string[] dusmantas = tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])].Split(',');
                    if (dusmantas[0] == "2")
                      lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.Brown;
                  }
                  else
                  {
                    lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.FromArgb(100, 0, 0, 0);
                  }
                }
              }
              // END Yolları Renklendir
            break;
#endregion
        }

      }
      else if (tastipArr[0] == "2")
      {
        switch (tastipArr[1])
        {
          #region Siyah Taş Hareketleri
          case "Vezir":
            string[] VezirGidisKoorAlternatif = new String[64];
            Array.Clear(VezirGidisKoorAlternatif, 0, 64);
            for (int i = 1; i < 8; i++)
            {
              //Kale Sol
              if (int.Parse(secimcoord[0]) - i <= 7 && int.Parse(secimcoord[0]) - i >= 0 && t1 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1])] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1])] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                  x++;
                  t1 = 1;
                }
              }
              //Kale Sağ
              if (int.Parse(secimcoord[0]) + i <= 7 && int.Parse(secimcoord[0]) + i >= 0 && t2 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1])] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1])] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                  x++;
                  t2 = 1;
                }
              }
              //Kale Yukarı
              if (int.Parse(secimcoord[1]) - i >= 0 && int.Parse(secimcoord[1]) - i <= 7 && t3 == 0)
              {
                if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) - i] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) - i] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                  t3 = 1;
                }
              }
              //Kale Aşağı
              if (int.Parse(secimcoord[1]) + i >= 0 && int.Parse(secimcoord[1]) + i <= 7 && t4 == 0)
              {
                if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) + i] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) + i] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                  t4 = 1;
                }
              }
              // Fil Kontrolü
              if (int.Parse(secimcoord[0]) - i <= 7 && int.Parse(secimcoord[0]) - i >= 0 && int.Parse(secimcoord[1]) - i >= 0 && int.Parse(secimcoord[1]) - i <= 7 && t5 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) - i] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) - i] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                  t5 = 1;
                }
              }
              if (int.Parse(secimcoord[0]) + i <= 7 && int.Parse(secimcoord[0]) + i >= 0 && int.Parse(secimcoord[1]) - i <= 7 && int.Parse(secimcoord[1]) - i >= 0 && t6 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) - i] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) - i] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                  t6 = 1;
                }
              }
              if (int.Parse(secimcoord[0]) - i <= 7 && int.Parse(secimcoord[0]) - i >= 0 && int.Parse(secimcoord[1]) + i <= 7 && int.Parse(secimcoord[1]) + i >= 0 && t7 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) + i] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) + i] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                  t7 = 1;
                }
              }
              if (int.Parse(secimcoord[0]) + i >= 0 && int.Parse(secimcoord[0]) + i <= 7 && int.Parse(secimcoord[1]) + i <= 7 && int.Parse(secimcoord[1]) + i >= 0 && t8 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) + i] == null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) + i] != null)
                {
                  VezirGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                  t8 = 1;
                }
              }

            }

            //Yolları Renklendir
            Array.Sort(VezirGidisKoorAlternatif);
            Array.Reverse(VezirGidisKoorAlternatif);
            Array.Resize(ref VezirGidisKoorAlternatif, x);
            for (int i = 0; i < VezirGidisKoorAlternatif.Length; i++)
            {

              string[] KooRD = VezirGidisKoorAlternatif[i].Split(',');
              if (int.Parse(KooRD[0]) <= 7 && int.Parse(KooRD[0]) >= 0 && int.Parse(KooRD[1]) <= 7 && int.Parse(KooRD[1]) >= 0)
              {

                if (tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])] != null)
                {
                  string[] dusmantas = tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])].Split(',');
                  if (dusmantas[0] == "1")
                    lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.Brown;
                }
                else
                {
                  lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.FromArgb(100, 0, 0, 0);
                }
              }
            }
            // END Yolları Renklendir

            break;
          case "Şah":
            string[] SahGidisKoorAlternatif = new String[]{
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1])),
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1])), 
                (int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) - 1), 
                (int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) + 1)
              };

            //Yolları Renklendir
            for (int i = 0; i < SahGidisKoorAlternatif.Length; i++)
            {
              string[] KooRD = SahGidisKoorAlternatif[i].Split(',');
              if (int.Parse(KooRD[0]) <= 7 && int.Parse(KooRD[0]) >= 0 && int.Parse(KooRD[1]) <= 7 && int.Parse(KooRD[1]) >= 0)
              {
                if (tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])] != null)
                {
                  string[] dusmantas = tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])].Split(',');
                  if (dusmantas[0] == "1")
                    lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.Brown;
                }
                else
                {
                  lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.FromArgb(100, 0, 0, 0);
                }
              }
            }
            //END Yolları Renklendir.
            break;
          case "Piyon":
            string[] PiyonGidisKoorAlternatif = new String[]{
                //(int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) - 1),
                //(int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) + 1)                
              };
            if (int.Parse(secimcoord[1]) == 1)
            {
              if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) + 1] == null)
              {
                Array.Resize(ref PiyonGidisKoorAlternatif, PiyonGidisKoorAlternatif.Length + 1);
                PiyonGidisKoorAlternatif[1] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + 2);
              }
            }




            string[] PiyonYeGidisKoorAlternatif = new String[]{
                (int.Parse(secimcoord[0]) + 1) +","+ (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) - 1) +","+ (int.Parse(secimcoord[1]) + 1),
                //(int.Parse(secimcoord[0])) +","+ (int.Parse(secimcoord[1]) - 1)
              };

            //Yolları Renklendir
            for (int i = 0; i < PiyonGidisKoorAlternatif.Length; i++)
            {
              string[] KooRD = PiyonGidisKoorAlternatif[i].Split(',');
              string[] KooRDPiyonYe = PiyonYeGidisKoorAlternatif[i].Split(',');

              if (int.Parse(KooRD[0]) <= 7 && int.Parse(KooRD[0]) >= 0 && int.Parse(KooRD[1]) <= 7 && int.Parse(KooRD[1]) >= 0)
              {
                if (tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])] == null)
                {
                  lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.FromArgb(100, 0, 0, 0);
                }
              }
            }

            for (int i = 0; i < PiyonYeGidisKoorAlternatif.Length; i++)
            {
              string[] KooRDPiyonYe = PiyonYeGidisKoorAlternatif[i].Split(',');
              if (int.Parse(KooRDPiyonYe[0]) <= 7 && int.Parse(KooRDPiyonYe[0]) >= 0 && int.Parse(KooRDPiyonYe[1]) <= 7 && int.Parse(KooRDPiyonYe[1]) >= 0)
              {
                if (tas[int.Parse(KooRDPiyonYe[0]), int.Parse(KooRDPiyonYe[1])] != null)
                {
                  string[] dusmantas = tas[int.Parse(KooRDPiyonYe[0]), int.Parse(KooRDPiyonYe[1])].Split(',');
                  if (dusmantas[0] == "1")
                    lbl[int.Parse(KooRDPiyonYe[0]), int.Parse(KooRDPiyonYe[1])].BackColor = Color.Brown;
                }
              }
            }
            // END Yolları Renklendir


            break;

          case "At":
            string[] AtGidisKoor = new String[]{
                (int.Parse(secimcoord[0]) - 2) +","+ (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) - 2) +","+    (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) + 2) + "," + (int.Parse(secimcoord[1]) - 1),
                (int.Parse(secimcoord[0]) + 2) + "," + (int.Parse(secimcoord[1]) + 1),
                (int.Parse(secimcoord[0]) - 1) + "," + (int.Parse(secimcoord[1]) - 2),
                (int.Parse(secimcoord[0])+1) +","+(int.Parse(secimcoord[1]) -2)  ,
                (int.Parse(secimcoord[0]) - 1) +"," + (int.Parse(secimcoord[1]) + 2),
                (int.Parse(secimcoord[0]) + 1) + "," + (int.Parse(secimcoord[1]) + 2)};

            //Yolları Renklendir
            for (int i = 0; i < AtGidisKoor.Length; i++)
            {
              string[] KooRD = AtGidisKoor[i].Split(',');
              if (int.Parse(KooRD[0]) <= 7 && int.Parse(KooRD[0]) >= 0 && int.Parse(KooRD[1]) <= 7 && int.Parse(KooRD[1]) >= 0)
              {
                if (tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])] != null)
                {
                  string[] dusmantas = tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])].Split(',');
                  if (dusmantas[0] == "1")
                    lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.Brown;
                }
                else
                {
                  lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.FromArgb(100, 0, 0, 0);
                }
              }
            }
            //END Yolları Renklendir.
            break;


          case "Fil":
            string[] FilGidisKoorAlternatif = new String[64];
            Array.Clear(FilGidisKoorAlternatif, 0, 64);
            for (int i = 1; i < 8; i++)
            {
              if (int.Parse(secimcoord[0]) - i <= 7 && int.Parse(secimcoord[0]) - i >= 0 && int.Parse(secimcoord[1]) - i >= 0 && int.Parse(secimcoord[1]) - i <= 7 && t1 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) - i] == null)
                {
                  FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) - i] != null)
                {
                  FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                  t1 = 1;
                }
              }
              if (int.Parse(secimcoord[0]) + i <= 7 && int.Parse(secimcoord[0]) + i >= 0 && int.Parse(secimcoord[1]) - i <= 7 && int.Parse(secimcoord[1]) - i >= 0 && t2 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) - i] == null)
                {
                  FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) - i] != null)
                {
                  FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                  t2 = 1;
                }
              }
              if (int.Parse(secimcoord[0]) - i <= 7 && int.Parse(secimcoord[0]) - i >= 0 && int.Parse(secimcoord[1]) + i <= 7 && int.Parse(secimcoord[1]) + i >= 0 && t3 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) + i] == null)
                {
                  FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1]) + i] != null)
                {
                  FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                  t3 = 1;
                }
              }
              if (int.Parse(secimcoord[0]) + i >= 0 && int.Parse(secimcoord[0]) + i <= 7 && int.Parse(secimcoord[1]) + i <= 7 && int.Parse(secimcoord[1]) + i >= 0 && t4 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) + i] == null)
                {
                  FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1]) + i] != null)
                {
                  FilGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                  t4 = 1;
                }
              }

            }
            //Yolları Renklendir
            Array.Sort(FilGidisKoorAlternatif);
            Array.Reverse(FilGidisKoorAlternatif);
            Array.Resize(ref FilGidisKoorAlternatif, x);
            for (int i = 0; i < FilGidisKoorAlternatif.Length; i++)
            {

              string[] KooRD = FilGidisKoorAlternatif[i].Split(',');
              if (int.Parse(KooRD[0]) <= 7 && int.Parse(KooRD[0]) >= 0 && int.Parse(KooRD[1]) <= 7 && int.Parse(KooRD[1]) >= 0)
              {

                if (tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])] != null)
                {
                  string[] dusmantas = tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])].Split(',');
                  if (dusmantas[0] == "1")
                    lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.Brown;
                }
                else
                {
                  lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.FromArgb(100, 0, 0, 0);
                }
              }
            }
            // END Yolları Renklendir
            break;
          case "Kale":
            string[] KaleGidisKoorAlternatif = new String[64];
            Array.Clear(KaleGidisKoorAlternatif, 0, 64);
            for (int i = 1; i < 8; i++)
            {
              //Kale Sol
              if (int.Parse(secimcoord[0]) - i <= 7 && int.Parse(secimcoord[0]) - i >= 0 && t1 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1])] == null)
                {
                  KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) - i, int.Parse(secimcoord[1])] != null)
                {
                  KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) - (i)) + "," + (int.Parse(secimcoord[1]));
                  x++;
                  t1 = 1;
                }
              }
              //Kale Sağ
              if (int.Parse(secimcoord[0]) + i <= 7 && int.Parse(secimcoord[0]) + i >= 0 && t2 == 0)
              {
                if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1])] == null)
                {
                  KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]) + i, int.Parse(secimcoord[1])] != null)
                {
                  KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0]) + (i)) + "," + (int.Parse(secimcoord[1]));
                  x++;
                  t2 = 1;
                }
              }
              //Kale Yukarı
              if (int.Parse(secimcoord[1]) - i >= 0 && int.Parse(secimcoord[1]) - i <= 7 && t3 == 0)
              {
                if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) - i] == null)
                {
                  KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) - i] != null)
                {
                  KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) - (i));
                  x++;
                  t3 = 1;
                }
              }
              //Kale Aşağı
              if (int.Parse(secimcoord[1]) + i >= 0 && int.Parse(secimcoord[1]) + i <= 7 && t4 == 0)
              {
                if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) + i] == null)
                {
                  KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                }
                else if (tas[int.Parse(secimcoord[0]), int.Parse(secimcoord[1]) + i] != null)
                {
                  KaleGidisKoorAlternatif[x] = (int.Parse(secimcoord[0])) + "," + (int.Parse(secimcoord[1]) + (i));
                  x++;
                  t4 = 1;
                }
              }
            }
            //Yolları Renklendir
            Array.Sort(KaleGidisKoorAlternatif);
            Array.Reverse(KaleGidisKoorAlternatif);
            Array.Resize(ref KaleGidisKoorAlternatif, x);
            for (int i = 0; i < KaleGidisKoorAlternatif.Length; i++)
            {

              string[] KooRD = KaleGidisKoorAlternatif[i].Split(',');
              if (int.Parse(KooRD[0]) <= 7 && int.Parse(KooRD[0]) >= 0 && int.Parse(KooRD[1]) <= 7 && int.Parse(KooRD[1]) >= 0)
              {

                if (tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])] != null)
                {
                  string[] dusmantas = tas[int.Parse(KooRD[0]), int.Parse(KooRD[1])].Split(',');
                  if (dusmantas[0] == "1")
                    lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.Brown;
                }
                else
                {
                  lbl[int.Parse(KooRD[0]), int.Parse(KooRD[1])].BackColor = Color.FromArgb(100, 0, 0, 0);
                }
              }
            }
            // END Yolları Renklendir
            break;
          #endregion
        }
      }
    }

    private void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)
    {
      button_start.PerformClick();
    }



    private void button1_Click(object sender, EventArgs e)
    {
      button_reset.Enabled = true;
      button_start.Enabled = false;
      label_oyuncusirasi.Visible = true;
      groupBox_stats.Visible = true;
      checkBox_yardim.Visible = true;
      checkBox1.Enabled = true;
      checkBox_ses.Visible = true;
      listBox_puan.Visible = true;
      SkorDurumuYaz();

      //Piyon
      for (int i = 0; i <= 7; i++)
      {
        //siyahlı
        tas[i, 1] = "2,Piyon";
        lbl[i, 1].Image = img[11];
        //beyazlı
        tas[i, 6] = "1,Piyon";
        lbl[i, 6].Image = img[5];
      }


      //Kale
      lbl[0, 0].Image = img[6]; tas[0, 0] = "2,Kale";
      lbl[7, 0].Image = img[6]; tas[7, 0] = "2,Kale";
      lbl[0, 7].Image = img[0]; tas[0, 7] = "1,Kale";
      lbl[7, 7].Image = img[0]; tas[7, 7] = "1,Kale";

      //At
      lbl[1, 0].Image = img[7]; tas[1, 0] = "2,At";
      lbl[6, 0].Image = img[7]; tas[6, 0] = "2,At";
      lbl[1, 7].Image = img[1]; tas[1, 7] = "1,At";
      lbl[6, 7].Image = img[1]; tas[6, 7] = "1,At";

      //Fil
      lbl[2, 0].Image = img[8]; tas[2, 0] = "2,Fil";
      lbl[5, 0].Image = img[8]; tas[5, 0] = "2,Fil";
      lbl[2, 7].Image = img[2]; tas[2, 7] = "1,Fil";
      lbl[5, 7].Image = img[2]; tas[5, 7] = "1,Fil";

      //Vezir
      lbl[3, 0].Image = img[10]; tas[3, 0] = "2,Vezir";
      lbl[4, 7].Image = img[4]; tas[4, 7] = "1,Vezir";
      //Şah
      lbl[4, 0].Image = img[9]; tas[4, 0] = "2,Şah";
      lbl[3, 7].Image = img[3]; tas[3, 7] = "1,Şah";

      //lbl[0].Image = Image.FromFile("img/kale.png");

      //lbl.Image = Image.FromFile("img/at.png");

      myStartTime = Convert.ToDateTime(DateTime.Now);
      timer_gecensure.Start();

    }

    private void SkorDurumuYaz()
    {
      //if (!listBox_puan.Visible)
        //listBox_puan.Visible = true;
      listBox_puan.Items.Clear();
      listBox_puan.Items.Add("Skor Durumu");
      listBox_puan.Items.Add("-----------------------------------");
      listBox_puan.Items.Add(string.Format("{0} <= Beyaz Oyuncu ", puan[0]));
      listBox_puan.Items.Add(string.Format("{0} <= Siyah Oyuncu", puan[1]));
      
    }



    private void button_reset_Click(object sender, EventArgs e)
    {
      // RESETLE
      foreach (var item in lbl)
      {

        item.BackColor = Color.Transparent;
        item.Image = null;

      }
      Array.Clear(tas, 0, tas.Length);
      timer_gecensure.Stop();
      button_start.Enabled = true;
      button_reset.Enabled = false;
      checkBox_yardim.Visible = false;
      listBox_hareket.Items.Clear();
      oyuncu = "1";
      label_oyuncusirasi.BackColor = Color.White;
      label_oyuncusirasi.ForeColor = Color.Black;
      label_oyuncusirasi.Text = "Beyaz Başlıyor";
      checkBox1.Enabled = false;
      checkBox1.Checked = false;
      hareket = 0;
      puan[0] = 0; puan[1] = 0;
      terfiKoor0 = 0; terfiKoor1 = 0; terfiOyuncu = 0; toplamhamle = 0; 
      label_toplamhamle.Text = "0"; label_gecenzaman.Text = "00:00:00";
      groupBox_stats.Visible = false;
      checkBox_ses.Visible = false;
      listBox_puan.Visible = false;
      label_oyuncusirasi.Visible = false;

    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      System.Diagnostics.Process.Start("mailto:glikoz@live.com");
    }

    private void resetleToolStripMenuItem_Click(object sender, EventArgs e)
    {
      button_reset.PerformClick();
    }

    private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBox1.Checked == true)
      {
        label_oyuncusirasi.Visible = false;
        devmod = 1;
      }
      else
      {
        label_oyuncusirasi.Visible = true;
        devmod = 0;
      }
    }

    private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Form2 frm = new Form2();
      frm.Show();
    }

    private void checkBox_yardim_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBox_yardim.Checked == true)
      {
        yardim = 1;
      }
      else
      {
        yardim = 0;
      }
    }

    private void timer_gecensure_Tick(object sender, EventArgs e)
    {
      TimeSpan myWorkingTime = DateTime.Now - myStartTime;
      label_gecenzaman.Text = myWorkingTime.ToString(@"hh\:mm\:ss");
    }

    private void SesCal(int sesid)
    {
      if (checkBox_ses.Checked == true)
      {
        string path = "data/Patmat.move.wav";
        switch (sesid)
        {
          case 0: path = "data/Patmat.move.wav"; break;
          case 1: path = "data/Patmat.hit.wav"; break;
          case 2: path = "data/Patmat.basla.wav"; break;
        }
        SoundPlayer player = new SoundPlayer();
        player.SoundLocation = path;
        player.Play();
      }
    }


  }
}
