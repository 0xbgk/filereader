using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace txtreader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            //MessageBox.Show(IsDigitsOnly("asdasd123456"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txt;            
            string line = "";

            string kontrol = textBox1.Text;                        
            bool eger = false;
            long toplam = 0;
            int counter;
            for (int i = Convert.ToInt32(textBox2.Text); i <= Convert.ToInt32(textBox3.Text); i++)
            {
                counter = 0;
                txt = "ZRAP" + i.ToString("D4") + ".013";
                StreamReader sr = new StreamReader(txt);                              
                    while ((line = sr.ReadLine()) != null)
                    {                        
                        counter++;                                           
                        eger = line.Contains(kontrol);
                        if (eger)
                        {                         
                            string junk = txt + "DOSYASI " + kontrol + IsDigitsOnly(line);
                            toplam += Convert.ToInt64(IsDigitsOnly(line));
                            //MessageBox.Show(junk);
                            eger = false;
                        }
                    }
                
                
            }
            //int xd = 123456789;            
            //string alo = String.Format("{0:0,0}", xd);
            //MessageBox.Show(alo);
            string txt2, txt3;
            txt2 = textBox2.Text;
            txt3 = textBox3.Text;
            label1.Text = "ZRAP"+(Convert.ToInt16(txt2).ToString("D4"))+"-"+(Convert.ToInt16(txt3).ToString("D4")) + "   Toplam : "+toplam.ToString("#", CultureInfo.InvariantCulture);            


            string IsDigitsOnly(string str)
            {
                string sayi = "";
                foreach (char c in str)
                {
                    if (c < '0' || c > '9')
                    {
                    }
                    else
                    {
                        sayi += c;
                    }
                }
                return sayi;
            }
        }
    }
}
