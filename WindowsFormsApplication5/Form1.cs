using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Кено : Form
    {
        int[] vnes = new int[12];
        int c = 0;
        int[] randoms = new int[25];
        int c1 = 0;
        public Кено()
        {

            InitializeComponent();
            //  flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            Application.DoEvents();
            RoundedButton myButton = new RoundedButton();
            myButton.Text = "OK";
            myButton.Location = new System.Drawing.Point(200, 200);
            myButton.Size = new System.Drawing.Size(40, 40);
            myButton.Enabled = false;
            myButton.FlatStyle = FlatStyle.Flat;
            myButton.FlatAppearance.BorderColor = Color.White;
            // flowLayoutPanel1.Controls.Add(myButton);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            //Thread th1 = new Thread(generate);
            // Thread th2 = new Thread(slep);
            //th1.Start();
            //th2.Start();
           // generate();
        }
        public async void generate()
        {
            Random rnd = new Random();
            flowLayoutPanel2.Controls.Clear();
            for (int i = 0; i < 25; i++)
            {
                //Thread.Sleep(100);
                int numb = rnd.Next(1, 81);
                bool flag = true;
                while (flag)
                {
                    if (!checck(numb))
                    {
                        numb = rnd.Next(1, 81);
                        flag = true;
                    }else
                    {
                        flag = false;
                    }
                   
                }
                if (check2(numb))
                {
                    RoundedButton b1 = new RoundedButton();
                    b1.Text = numb.ToString();
                    b1.Location = new System.Drawing.Point(200, 200);
                    b1.Size = new System.Drawing.Size(40, 40);
                    b1.Enabled = false;
                    b1.FlatStyle = FlatStyle.Flat;
                    b1.FlatAppearance.BorderColor = Color.White;
                    b1.BackColor = Color.Red;
                    flowLayoutPanel2.Controls.Add(b1);
                    randoms[c1++] = numb;
                }
                else
                {
                    RoundedButton b1 = new RoundedButton();
                    b1.Text = numb.ToString();
                    b1.Location = new System.Drawing.Point(200, 200);
                    b1.Size = new System.Drawing.Size(40, 40);
                    b1.Enabled = false;
                    b1.FlatStyle = FlatStyle.Flat;
                    b1.FlatAppearance.BorderColor = Color.White;
                    b1.BackColor = Color.Yellow;
                    flowLayoutPanel2.Controls.Add(b1);
                    randoms[c1++] = numb;
                }
                
                await Task.Delay(1000);

                //System.Threading.Thread.Sleep(500);
            }
            c1 = 0;
            
         
        }
        public bool check2(int k)
        {
            for(int i = 0; i < vnes.Length; i++)
            {
                if (vnes[i] == k) return true;
            }
            return false;
        }
       public bool checck(int k)
        {
            for(int i = 0; i < randoms.Length; i++)
            {
                if (randoms[i] == k)
                {
                    return false;
                    
                }
            }
            return true;
        }
   private int find(int s)
        {
            int j=0;
            int[] vnes2 = new int[12];
            int m = 0;
            for(int i = 0; i < vnes.Length; i++)
            {
                if (vnes[i] == s)
                {
                    j = i;
                }else
                {
                    vnes2[m++] = vnes[i];
                }
            }
            vnes = vnes2;
            return j;
        }
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void новаИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void излезиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }
        
        private void button_Click(object sender, EventArgs eventArgs)
        {
            
            if (((Button)sender).BackColor == Color.Red)
            {
                ((Button)sender).BackColor = Color.Wheat;
                
                int k=find(Convert.ToInt32(((Button)sender).Text));    
                flowLayoutPanel3.Controls.RemoveAt(k);
                c--;
           
               

            }
            else
            {
                if (c != 12)
                {
                    ((Button)sender).BackColor = Color.Red;
                    RoundedButton b1 = new RoundedButton();
                    b1.Text = ((Button)sender).Text;
                    b1.Location = new System.Drawing.Point(200, 200);
                    b1.Size = new System.Drawing.Size(40, 40);
                    b1.Enabled = false;
                    b1.FlatStyle = FlatStyle.Flat;
                    b1.FlatAppearance.BorderColor = Color.White;
                    b1.BackColor = Color.Yellow;
                    flowLayoutPanel3.Controls.Add(b1);
                    vnes[c++] = Convert.ToInt32(((Button)sender).Text);
                  
                  
                }
              
            }
        }

        private void button81_Click(object sender, EventArgs e)
        {
            generate();
        }
    }
}
class RoundedButton : Button
{
    GraphicsPath GetRoundPath(RectangleF Rect, int radius)
    {
        float r2 = radius / 2f; GraphicsPath GraphPath = new GraphicsPath();
        GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
        GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
        GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
        GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
        GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y + Rect.Height - radius, radius, radius, 0, 90); GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height); GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90); GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2); GraphPath.CloseFigure(); return GraphPath;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
        GraphicsPath GraphPath = GetRoundPath(Rect, 33);
        this.Region = new Region(GraphPath);
        using (Pen pen = new Pen(Color.Red, 1.80f)){
            pen.Alignment = PenAlignment.Inset; e.Graphics.DrawPath(pen, GraphPath); }
    }
}

