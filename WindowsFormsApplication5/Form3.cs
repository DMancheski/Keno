using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form3 : Form
    {
        public Form3(string a,string b,string c, string d,int sleden)
        {
            InitializeComponent();
            if (sleden == 5)
            {
                sleden = 1;
            }
         
            if (sleden == 1)
            {
                label4.Text = d;
                label3.Text = c;
                label2.Text = b;
                label1.Text = a;
            }
            if (sleden == 2)
            {
                label4.Text = a;
                label3.Text = d;
                label2.Text = c;
                label1.Text = b;
            }
            if (sleden == 3)
            {
                label4.Text = b;
                label3.Text = a;
                label2.Text = d;
                label1.Text = c;
            }
            if (sleden == 4)
            {
                label4.Text = c;
                label3.Text = b;
                label2.Text = a;
                label1.Text = d;

            }
            label1.Paint+= new System.Windows.Forms.PaintEventHandler(this.label2_Paint);
            label3.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
            label2.Paint += new System.Windows.Forms.PaintEventHandler(this.label22_Paint);
            label4.Paint += new System.Windows.Forms.PaintEventHandler(this.label11_Paint);
           


        }
        void label1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, label3.DisplayRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
        void label2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, label1.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }
        void label11_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, label4.DisplayRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
        void label22_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, label2.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }
    }


}
