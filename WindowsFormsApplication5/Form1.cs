using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication5.Properties;

namespace WindowsFormsApplication5
{

    public partial class Кено : Form
    {
        Form2 f = new Form2();
        Form3 f2;
        int[] vnes = new int[12];
        int c = 0;
        int[] randoms = new int[25];
        int[] randoms2 = new int[12];
        int c1 = 0;
        int tiks = 0;
        int pogodocifinal = 0;
        int kredit;
        int time = 120;
        int kreditigra = 0;
        int isplata = 0;
        public bool zatvori = true;
        int[] randombroevi = new int[12];
        int tp = 1;
        int sleden = 1;
        string podatoci1 = "";
        string podatoci2 = "";
        string podatoci3 = "";
        string podatoci4 = "";
        bool gener = true;
        bool voigra=false;
        public object MessageBoxManager { get; private set; }

        public Кено()
        {

            InitializeComponent();

            timer1.Start();
            label12.ForeColor = Color.Blue;
            label1.ForeColor = Color.Blue;

            // button82.Enabled = false;
            label12.Paint += new System.Windows.Forms.PaintEventHandler(this.label12b_Paint);
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));

            label1.Paint += new System.Windows.Forms.PaintEventHandler(this.label2_Paint);



        }

        public void randomgenerator(int k)
        {
            if (gener)
            {



                Random rnd = new Random();
                c = 0;
                flowLayoutPanel3.Controls.Clear();
                randoms2 = new int[k];
                foreach (Button b in flowLayoutPanel1.Controls.OfType<Button>())
                {
                    if (b.BackColor == Color.Red)
                    {
                        b.BackColor = Color.Wheat;
                    }
                }
                for (int i = 0; i < k; i++)
                {

                    int numb = rnd.Next(1, 81);
                    bool flag = true;
                    while (flag)
                    {
                        if (!checck2(numb))
                        {
                            numb = rnd.Next(1, 81);
                            flag = true;


                        }
                        else
                        {
                            flag = false;
                        }

                    }
                    randoms2[i] = numb;

                }

                for (int i = 0; i < k; i++)
                {
                    vnes[i] = randoms2[i];
                    c++;
                    RoundedButton b1 = new RoundedButton(40, Color.Red);
                    b1.Text = randoms2[i].ToString(); ;
                    b1.Location = new System.Drawing.Point(200, 200);
                    b1.Size = new System.Drawing.Size(40, 40);
                    b1.Enabled = false;
                    b1.FlatStyle = FlatStyle.Flat;
                    b1.FlatAppearance.BorderColor = Color.White;
                    b1.BackColor = Color.Yellow;
                    flowLayoutPanel3.Controls.Add(b1);
                    foreach (Button b in flowLayoutPanel1.Controls.OfType<Button>())
                    {
                        if (b.Text == randoms2[i].ToString())
                        {
                            b.BackColor = Color.Red;
                        }
                    }
                }
                izbrani.Text = "Избрани: " + k.ToString();
            }
        }
        void label1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, label1.DisplayRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
        void label2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, label1.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }
        void label12_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, label12.DisplayRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
        void label12b_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, label12.DisplayRectangle, Color.Blue, ButtonBorderStyle.Solid);
        }
        public async void generate()
        {
            voigra = true;
            if (sleden == 5)
            {
                sleden = 1;
            }
            if (sleden == 1)
            {
                podatoci1 = "";
            }
            if (sleden == 2)
            {
                podatoci2 = "";
            }
            if (sleden == 3)
            {
                podatoci3 = "";
            }
            if (sleden == 4)
            {
                podatoci4 = "";
            }
            gener = false;
            button85.Enabled = false;
            bool flag2 = false;
            int n;
            button83.Enabled = false;
            textBox3.Enabled = false;
            button84.Enabled = false;
            if (c == 0)
            {
                izbrani.Text = "Избрани: 0";
            }
            if (label9.Text != "" && int.TryParse(label9.Text, out n))
            {
                flag2 = true;
                p0.ForeColor = Color.Red;
                k0.ForeColor = Color.Red;
                d0.ForeColor = Color.Red;
                d5.Text = (Convert.ToInt32(Convert.ToInt32(label9.Text) * 4)).ToString();
                d4.Text = (Convert.ToInt32(Convert.ToInt32(label9.Text) * 2.5)).ToString();
                d6.Text = (Convert.ToInt32(Convert.ToInt32(label9.Text) * 7)).ToString();
                d7.Text = (Convert.ToInt32(Convert.ToInt32(label9.Text) * 10)).ToString();
                d8.Text = (Convert.ToInt32(Convert.ToInt32(label9.Text) * 20)).ToString();
                d9.Text = (Convert.ToInt32(Convert.ToInt32(label9.Text) * 30)).ToString();
                d10.Text = (Convert.ToInt32(Convert.ToInt32(label9.Text) * 50)).ToString();
                d11.Text = (Convert.ToInt32(Convert.ToInt32(label9.Text) * 80)).ToString();
                d12.Text = (Convert.ToInt32(Convert.ToInt32(label9.Text) * 100)).ToString();
                isplata = Convert.ToInt32((Convert.ToInt32(label9.Text) * 0.4));
                isp.Text = "Вкупна добивка: " + isplata.ToString();
                d0.Text = isplata.ToString();
            }
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
                    } else
                    {
                        flag = false;
                    }

                }
                pogodoci.Text = "Погодоци: " + pogodocifinal.ToString();
                randoms[c1++] = numb;
                if (sleden == 1)
                {
                    if (i != 24)
                    {
                        podatoci1 += numb.ToString() + " "; ;
                    }else
                    {

                    }
                }
                if (sleden == 2)
                {
                    if (i != 24)
                    {
                        podatoci2 += numb.ToString() + " "; ;
                    }
                    else podatoci2 += numb.ToString();

                }
                if (sleden == 3)
                {
                    if (i != 24)
                    {
                        podatoci3 += numb.ToString() + " "; ;
                    }
                    else podatoci3 += numb.ToString();

                }
                if (sleden == 4)
                {
                    if (i != 24)
                    {
                        podatoci4 += numb.ToString() + " ";
                    }
                    else podatoci4 += numb.ToString();

                }
                if (check2(numb))
                {
                    foreach (Button b in flowLayoutPanel3.Controls.OfType<Button>())
                    {
                        if (b.Text == numb.ToString())
                        {
                            b.BackColor = Color.Red;
                        }
                    }
                    RoundedButton b1 = new RoundedButton(40, Color.Red);
                    b1.Text = numb.ToString();
                    b1.Location = new System.Drawing.Point(200, 200);
                    b1.Size = new System.Drawing.Size(40, 40);
                    b1.Enabled = false;
                    b1.FlatStyle = FlatStyle.Flat;
                    b1.FlatAppearance.BorderColor = Color.White;
                    b1.BackColor = Color.Red;
                    flowLayoutPanel2.Controls.Add(b1);

                }
                else
                {
                    RoundedButton b1 = new RoundedButton(40, Color.Red);
                    b1.Text = numb.ToString();
                    b1.Location = new System.Drawing.Point(200, 200);
                    b1.Size = new System.Drawing.Size(40, 40);
                    b1.Enabled = false;
                    b1.FlatStyle = FlatStyle.Flat;
                    b1.FlatAppearance.BorderColor = Color.White;
                    b1.BackColor = Color.Yellow;
                    flowLayoutPanel2.Controls.Add(b1);

                }
                if (check2(numb) && c >= 4 && flag2)
                {



                    pogodocifinal += 1;
                    pogodoci.Text = "Погодоци: " + pogodocifinal.ToString();


                    if (pogodocifinal <= 3)
                    {

                        isplata = Convert.ToInt32(Convert.ToInt32(label9.Text) * 0.4);
                        isp.Text = "Вкупна добивка: " + (Convert.ToInt32(label9.Text) * 0.4).ToString();
                        label6.Text = "Бонус: " + (isplata * (Convert.ToDouble(pogodocifinal) / Convert.ToDouble(c))).ToString();
                        //d0.Text = isplata.ToString();
                    }
                    if (pogodocifinal == 4)
                    {

                        isplata = Convert.ToInt32(Convert.ToInt32(label9.Text) * 2.5);
                        isp.Text = "Вкупна добивка: " + (Convert.ToInt32(label9.Text) * 2.5).ToString();
                        label6.Text = "Бонус: " + (isplata * (Convert.ToDouble(pogodocifinal) / Convert.ToDouble(c))).ToString();
                        p0.ForeColor = Color.White;
                        k0.ForeColor = Color.White;
                        d0.ForeColor = Color.White;
                        p4.ForeColor = Color.Red;
                        k4.ForeColor = Color.Red;
                        d4.ForeColor = Color.Red;

                    }
                    if (pogodocifinal == 5)
                    {
                        isplata = Convert.ToInt32(label9.Text) * 4;
                        isp.Text = "Вкупна добивка: " + (Convert.ToInt32(label9.Text) * 4).ToString();
                        label6.Text = "Бонус: " + (isplata * (Convert.ToDouble(pogodocifinal) / Convert.ToDouble(c))).ToString();
                        p4.ForeColor = Color.White;
                        k4.ForeColor = Color.White;
                        d4.ForeColor = Color.White;
                        p5.ForeColor = Color.Red;
                        k5.ForeColor = Color.Red;
                        d5.ForeColor = Color.Red;
                    }
                    if (pogodocifinal == 6)
                    {
                        isplata = Convert.ToInt32(label9.Text) * 7;
                        isp.Text = "Вкупна добивка: " + (Convert.ToInt32(label9.Text) * 7).ToString();
                        label6.Text = "Бонус: " + (isplata * (Convert.ToDouble(pogodocifinal) / Convert.ToDouble(c))).ToString();
                        p5.ForeColor = Color.White;
                        k5.ForeColor = Color.White;
                        d5.ForeColor = Color.White;
                        p6.ForeColor = Color.Red;
                        k6.ForeColor = Color.Red;
                        d6.ForeColor = Color.Red;
                    }
                    if (pogodocifinal == 7)
                    {
                        isplata = Convert.ToInt32(label9.Text) * 10;
                        isp.Text = "Вкупна добивка: " + (Convert.ToInt32(label9.Text) * 10).ToString();
                        label6.Text = "Бонус: " + (isplata * (Convert.ToDouble(pogodocifinal) / Convert.ToDouble(c))).ToString();
                        p6.ForeColor = Color.White;
                        k6.ForeColor = Color.White;
                        d6.ForeColor = Color.White;
                        p7.ForeColor = Color.Red;
                        k7.ForeColor = Color.Red;
                        d7.ForeColor = Color.Red;
                    }
                    if (pogodocifinal == 8)
                    {
                        isplata = Convert.ToInt32(label9.Text) * 20;
                        isp.Text = "Вкупна добивка: " + (Convert.ToInt32(label9.Text) * 20).ToString();
                        label6.Text = "Бонус: " + (isplata * (Convert.ToDouble(pogodocifinal) / Convert.ToDouble(c))).ToString();
                        p7.ForeColor = Color.White;
                        k7.ForeColor = Color.White;
                        d7.ForeColor = Color.White;
                        p8.ForeColor = Color.Red;
                        k8.ForeColor = Color.Red;
                        d8.ForeColor = Color.Red;
                    }
                    if (pogodocifinal == 9)
                    {
                        isplata = Convert.ToInt32(label9.Text) * 30;
                        isp.Text = "Вкупна добивка " + (Convert.ToInt32(label9.Text) * 30).ToString();
                        label6.Text = "Бонус: " + (isplata * (Convert.ToDouble(pogodocifinal) / Convert.ToDouble(c))).ToString();
                        p8.ForeColor = Color.White;
                        k8.ForeColor = Color.White;
                        d8.ForeColor = Color.White;
                        p9.ForeColor = Color.Red;
                        k9.ForeColor = Color.Red;
                        d9.ForeColor = Color.Red;
                    }
                    if (pogodocifinal == 10)
                    {
                        isplata = Convert.ToInt32(label9.Text) * 50;
                        isp.Text = "Вкупна добивка: " + (Convert.ToInt32(label9.Text) * 50).ToString();

                        label6.Text = "Бонус: " + (isplata * (Convert.ToDouble(pogodocifinal) / Convert.ToDouble(c))).ToString();
                        p9.ForeColor = Color.White;
                        k9.ForeColor = Color.White;
                        d9.ForeColor = Color.White;
                        p10.ForeColor = Color.Red;
                        k10.ForeColor = Color.Red;
                        d10.ForeColor = Color.Red;
                    }
                    if (pogodocifinal == 11)
                    {
                        isplata = Convert.ToInt32(label9.Text) * 80;
                        isp.Text = "Вкупна добивка: " + (Convert.ToInt32(label9.Text) * 80).ToString();
                        label6.Text = "Бонус: " + (isplata * (Convert.ToDouble(pogodocifinal) / Convert.ToDouble(c))).ToString();
                        p10.ForeColor = Color.White;
                        k10.ForeColor = Color.White;
                        d10.ForeColor = Color.White;
                        p11.ForeColor = Color.Red;
                        k11.ForeColor = Color.Red;
                        d11.ForeColor = Color.Red;
                    }
                    if (pogodocifinal == 12)
                    {
                        isplata = Convert.ToInt32(label9.Text) * 100;
                        isp.Text = "Вкупна добивка: " + (Convert.ToInt32(label9.Text) * 100).ToString();
                        label6.Text = "Бонус: " + (isplata * (Convert.ToDouble(pogodocifinal) / Convert.ToDouble(c))).ToString();
                        p11.ForeColor = Color.White;
                        k11.ForeColor = Color.White;
                        d11.ForeColor = Color.White;
                        p12.ForeColor = Color.Red;
                        k12.ForeColor = Color.Red;
                        d12.ForeColor = Color.Red;
                    }

                } else
                {
                    if (check2(numb))
                    {
                        pogodocifinal++;
                    }

                }


                await Task.Delay(700);

                if (i == 24)
                {

                    if (c >= 4 && flag2)
                    {
                        label6.Text = "Бонус: " + (isplata * (Convert.ToDouble(pogodocifinal) / Convert.ToDouble(c))).ToString();
                        isplata += Convert.ToInt32(isplata * (Convert.ToDouble(pogodocifinal) / Convert.ToDouble(c)));
                        isp.Text = "Вкупна добивка: " + isplata.ToString();
                        kredit += isplata;
                    }

                    label10.Text = "Кредит: " + kredit.ToString();
                    label9.Text = "";
                    //await Task.Delay(5000);
                    nova.Enabled = true;

                }
            }
            c1 = 0;
            sleden++;
             voigra = false;

        }
        public bool check2(int k)
        {
            for (int i = 0; i < vnes.Length; i++)
            {
                if (vnes[i] == k) return true;
            }
            return false;
        }
        public bool checck(int k)
        {
            for (int i = 0; i < randoms.Length; i++)
            {
                if (randoms[i] == k)
                {
                    return false;

                }
            }
            return true;
        }
        public bool checck2(int k)
        {
            for (int i = 0; i < randoms2.Length; i++)
            {
                if (randoms2[i] == k)
                {
                    return false;

                }
            }
            return true;
        }
        private int find(int s)
        {
            int j = 0;
            int[] vnes2 = new int[12];
            int m = 0;
            for (int i = 0; i < vnes.Length; i++)
            {
                if (vnes[i] == s)
                {
                    j = i;
                } else
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

                int k = find(Convert.ToInt32(((Button)sender).Text));
                flowLayoutPanel3.Controls.RemoveAt(k);
                c--;



            }
            else
            {
                if (c != 12)
                {
                    ((Button)sender).BackColor = Color.Red;
                    RoundedButton b1 = new RoundedButton(40, Color.Red);
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

            izbrani.Text = "Избрани: " + c.ToString();
        }

        private void button81_Click(object sender, EventArgs e)
        {
            generate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tiks++;
            voigra = false;
            label1.Text = "0" + ((time - tiks) / 60).ToString();
            if (tiks > 60)
            {
                if (tiks > 110)
                {

                    label1.Text += " : " + "0" + ((tiks - 120) * (-1)).ToString();
                } else {
                    label1.Text += " : " + ((tiks - 120) * (-1)).ToString();

                }

            } else
            {
                if (tiks > 50)
                {

                    label1.Text += " : " + "0" + ((tiks - 60) * (-1)).ToString();
                }
                else
                {
                    label1.Text += " : " + ((tiks - 60) * (-1)).ToString();

                }

            }

            if (tiks > 90)
            {
                label1.ForeColor = Color.Red;
                label12.ForeColor = Color.Red;
                label1.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
                label12.Paint += new System.Windows.Forms.PaintEventHandler(this.label12_Paint);
            }
            if (tiks == 120)
            {
                tiks = 0;
                timer1.Stop();
                flowLayoutPanel1.Enabled = false;
                generate();
                voigra = true;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button81_Click_1(object sender, EventArgs e)
        {
            int number;
            if (textBox1.Text != "" && int.TryParse(textBox1.Text, out number))
            {
                
                    kredit += number;
                    label10.Text = "Кредит: " + kredit.ToString();
                    textBox1.Text = "";
                }
               

            
        }

        private void button82_Click(object sender, EventArgs e)
        {
            int number;
            if (textBox2.Text != "" && int.TryParse(textBox2.Text, out number))
            {
                if (kredit - number >= 0)
                {
                    kredit -= number;
                    label10.Text = "Кредит: " + kredit.ToString();
                    textBox2.Text = "";
                }else
                {
                    MessageBox.Show("На вашата сметна имате само: " + kredit.ToString() + " денари.");
                }


            }
        }

        private void button83_Click(object sender, EventArgs e)

        {
            int number;
            if (textBox3.Text != "" && int.TryParse(textBox3.Text, out number))
            {
                if (kredit - number >= 0)
                {
                    if (number <= 10000 && kreditigra+number <=10000)
                    {
                        if (number+kreditigra>= 20)
                        {
                            kredit -= number;
                            kreditigra += number;
                            label10.Text = "Кредит: " + kredit.ToString();
                            label9.Text = kreditigra.ToString();
                            label11.Text = "Уплата: \n  " + kreditigra.ToString();
                            textBox3.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Минимална вредност за улата е 20 денари.");
                        }
                      
                    }else
                    {
                        MessageBox.Show("Уплатата за игра не смее да биде поголема од 10.000 денари.");
                    }


                }else
                {
                    MessageBox.Show("   Немате доволно кредит за уплата \n        Расположлив кредит: " +kredit.ToString()+" денари.");
                }


            }

        }

        private void button84_Click(object sender, EventArgs e)
        {
            kredit += kreditigra;
            label10.Text = "Кредит: " + kredit.ToString();
            kreditigra = 0;
            label9.Text = "";
            label11.Text = "Уплата:";

        }

        private void button85_Click(object sender, EventArgs e)
        {
            if (tiks < 109)
            {
                tiks = 109;
            }

        }

        private void button86_Click(object sender, EventArgs e)
        {

        }

        private void инфоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!f.Visible)
                {
                    f.Show();
                }
            }
            catch
            {
                f = new Form2();
                f.Show();
            }




        }

        private void button87_Click(object sender, EventArgs e)
        {

        }

        private void броевиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            randomgenerator(4);
        }

        private void броевиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            randomgenerator(5);
        }
        private void броевиToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            randomgenerator(6);
        }
        private void броевиToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            randomgenerator(7);
        }

        private void броевиToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            randomgenerator(8);
        }

        private void броевиToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            randomgenerator(9);
        }

        private void броевиToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            randomgenerator(10);
        }

        private void броевиToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            randomgenerator(11);
        }

        private void броевиToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            randomgenerator(12);
        }

        private void новаИграToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            button85.Enabled = true;
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel1.Enabled = true;
            label1.ForeColor = Color.Blue;
            label12.ForeColor = Color.Blue;
            label1.Paint += new System.Windows.Forms.PaintEventHandler(this.label2_Paint);
            label12.Paint += new System.Windows.Forms.PaintEventHandler(this.label12b_Paint);
            c = 0;
            vnes = new int[12];
            randoms = new int[25];
            isplata = 0;
            pogodocifinal = 0;
            kreditigra = 0;

            foreach (Button b in flowLayoutPanel1.Controls.OfType<Button>())
            {
                b.BackColor = Color.Wheat;
            }
            gener = true;
            button84.Enabled = true;
            button83.Enabled = true;
            textBox3.Enabled = true;
            d0.Text = "";
            d4.Text = "";
            d5.Text = "";
            d6.Text = "";
            d7.Text = "";
            d8.Text = "";
            d9.Text = "";
            d10.Text = "";
            d11.Text = "";
            d12.Text = "";
            p0.ForeColor = Color.White;
            p4.ForeColor = Color.White;
            p5.ForeColor = Color.White;
            p6.ForeColor = Color.White;
            p7.ForeColor = Color.White;
            p8.ForeColor = Color.White;
            p9.ForeColor = Color.White;
            p10.ForeColor = Color.White;
            p11.ForeColor = Color.White;
            p12.ForeColor = Color.White;
            k0.ForeColor = Color.White;
            k4.ForeColor = Color.White;
            k5.ForeColor = Color.White;
            k6.ForeColor = Color.White;
            k7.ForeColor = Color.White;
            k8.ForeColor = Color.White;
            k9.ForeColor = Color.White;
            k10.ForeColor = Color.White;
            k11.ForeColor = Color.White;
            k12.ForeColor = Color.White;
            label6.Text = "Бонус: ";
            isp.Text = "Вкупна добивка: ";
            pogodoci.Text = "Погодоци:";
            Settings.Default["sledno"] = sleden;
            label11.Text = "Уплата: ";
            Settings.Default.Save();
            izbrani.Text = "Избрани: ";
            nova.Enabled = false;
            timer1.Start();

            this.Refresh();
        }

        private void историјаНаИграњаToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
                try
                {
                    if (!f2.Visible)
                    {
                        f2.Show();
                    }
                }
                catch
                {
                    f2 = new Form3(podatoci1, podatoci2, podatoci3, podatoci4,sleden);
                    f2.Show();
                }
            
          
        }

        private void Кено_Load(object sender, EventArgs e)
        {
            kredit = (int)Settings.Default["vkkredit"];
            label10.Text = "Кредит: " + kredit.ToString();
            podatoci1=(string)Settings.Default["data1"];
            podatoci2 = (string)Settings.Default["data2"];
            podatoci3 = (string)Settings.Default["data3"];
            podatoci4 = (string)Settings.Default["data4"];
            sleden =(int) Settings.Default["sledno"];



        }

        private void Кено_Leave(object sender, EventArgs e)
        {
            
        }

        private void Кено_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kredit != 0)
            {

           
            DialogResult dr = MessageBox.Show("Преостанат кредит " + kredit.ToString() + " \n Подигни пред излез?", "Излез", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                Settings.Default["vkkredit"] = kredit;
                Settings.Default["data1"] = podatoci1;
                Settings.Default["data2"] = podatoci2;
                Settings.Default["data3"] = podatoci3;
                Settings.Default["data4"] = podatoci4;
              
                Settings.Default["sledno"] = sleden;
                Settings.Default.Save();
                
            }
            else
            {
                label10.Text = "Кредит 0";
                kredit = 0;
                Settings.Default["vkkredit"] = kredit;
                Settings.Default["data1"] = podatoci1;
                Settings.Default["data2"] = podatoci2;
                Settings.Default["data3"] = podatoci3;
                Settings.Default["data4"] = podatoci4;
               
                Settings.Default["sledno"] = sleden;
                Settings.Default.Save();
                

            }
            }else
            {
                Settings.Default["vkkredit"] = kredit;
                Settings.Default["data1"] = podatoci1;
                Settings.Default["data2"] = podatoci2;
                Settings.Default["data3"] = podatoci3;
                Settings.Default["data4"] = podatoci4;
                
                Settings.Default["sledno"] = sleden;
                Settings.Default.Save();
            }


        }

        private void Кено_FormClosed(object sender, FormClosedEventArgs e)
        {


         

        }

        private void затвориToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kredit == 0)
            {
                Settings.Default["vkkredit"] = kredit;
                Settings.Default["data1"] = podatoci1;
                Settings.Default["data2"] = podatoci2;
                Settings.Default["data3"] = podatoci3;
                Settings.Default["data4"] = podatoci4;
               
                Settings.Default["sledno"] = sleden;
                Settings.Default.Save();
                this.Close();
            }else
            {
                DialogResult dr =  MessageBox.Show("Преостанат кредит " + kredit.ToString() + " \n Подигни пред излез?", "Излез", MessageBoxButtons.YesNo);
                if(dr == DialogResult.No)
                {
                    Settings.Default["vkkredit"] = kredit;
                    Settings.Default["data1"] = podatoci1;
                    Settings.Default["data2"] = podatoci2;
                    Settings.Default["data3"] = podatoci3;
                    Settings.Default["data4"] = podatoci4;
                   
                    Settings.Default["sledno"] = sleden;
                    Settings.Default.Save();
                    this.Close();
                }else
                {
                    label10.Text = "Кредит 0";
                    kredit = 0;
                    Settings.Default["vkkredit"] = kredit;
                    Settings.Default["data1"] = podatoci1;
                    Settings.Default["data2"] = podatoci2;
                    Settings.Default["data3"] = podatoci3;
                    Settings.Default["data4"] = podatoci4;
                   
                    Settings.Default["sledno"] = sleden;
                    Settings.Default.Save();
                    this.Close();
                 
                }
            }
               
            }
          


           
        
    }
    

}
class Data1: ApplicationSettingsBase
{
    public int[] d1=new int[25];
    public int[] d2=new int[25];
    public int[] d3 = new int[25];
    public int[] d4 = new int[25];
    int broj;
    public Data1()
    {
        broj = 1;
        d1 = new int[25];
        d2 = new int[25];
        d3 = new int[25];
        d4 = new int[25];
    }
    public Data1(int[] dd1, int[] dd2, int[] dd3, int[] dd4, int br)
    {
        broj = br;
        d1 = dd1;
        d2 = dd2;
        d3 = dd3;
        d4 = dd4;
    }
    public int[] getd1()
    {
        return d1;
    }
    public int[] getd2()
    {
        return d2;
    }
    public int[] getd3()
    {
        return d3;
    }
    public int[] getd4()
    {
        return d4;
    }
    public int getbroj()
    {
        return broj;
    }
}
class RoundedButton : Button
{
    public int r;
    public Color c;
    public RoundedButton(int s,Color col)
    {
        r = s;
        c = col;
    }
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
        base.ForeColor = Color.Red;
        RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
        GraphicsPath GraphPath = GetRoundPath(Rect, r);
        this.Region = new Region(GraphPath);
        using (Pen pen = new Pen(c, 1.7f)){
            pen.Alignment = PenAlignment.Inset; e.Graphics.DrawPath(pen, GraphPath); }
     
    }
}

