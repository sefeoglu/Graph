using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace proje4
{
    public partial class Form1 : Form
    {
        //panellerin ve gerekli verilerini tanımlanması
        Panel panel = new Panel();
        Panel panel1 = new Panel();
        Panel panel2 = new Panel();
        Panel panel3 = new Panel();
        int tepesayısı;
        int başlangıç_tepesi;
        int başlangıç;
        int bitiştepesi;
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {//panel boyutlarını ayarlama

         
           
            panel.Width = 535;
            panel.Height = 535;
            panel.Location = new Point(45, 120);
            panel.BackColor = Color.DodgerBlue;


            panel1.Width = 535;
            panel1.Height = 535;
            panel1.Location = new Point(45, 120);
            panel1.BackColor = Color.DodgerBlue;

            panel2.Width = 535;
            panel2.Height = 535;
            panel2.Location = new Point(45, 120);
            panel2.BackColor = Color.DodgerBlue;

            panel3.Width = 535;
            panel3.Height = 535;
            panel3.Location = new Point(45, 120);
            panel3.BackColor = Color.DodgerBlue;

        }

        private void button5_Click(object sender, EventArgs e)
        {//DFTS dolasım için panel seçimi ve yazılımı
           
            if (this.panel.Equals(panel))
            {
                panel.Dispose();
                this.Controls.Remove(panel);
                this.Controls.Add(panel2);
            }
            else if (this.panel1.Equals(panel1))
            {
                panel1.Dispose();
                this.Controls.Remove(panel);
                this.Controls.Add(panel2);
            }
            else if (this.panel3.Equals(panel3))
            {
                panel3.Dispose();
                this.Controls.Remove(panel);
                this.Controls.Add(panel2);
            }
            panel2.Paint += DFTS;
            panel2.Show();

        }
        private void dugumleriCizdir(object sender, PaintEventArgs e)//düğümü sayısına göre panele düğümleirn çizimi
        {
            Graphs.Node a = new Graphs.Node();
            a.noktalar(tepesayısı);
            Graphics panel = e.Graphics;
            Pen pen = new Pen(Color.Black);
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Brush B = new SolidBrush(Color.Azure);

            for (int i = 0; i < tepesayısı; ++i)
            {
                panel.DrawEllipse(pen, a.noktaların[i].noktanın.X, a.noktaların[i].noktanın.Y, 50, 50);
                panel.FillEllipse(B, a.noktaların[i].noktanın.X, a.noktaların[i].noktanın.Y, 50, 50);
                Rectangle drawRect = new Rectangle((a.noktaların[i].noktanın.X + 15), (a.noktaların[i].noktanın.Y + 15), 60, 60);
                panel.DrawString(a.noktaların[i].ad, drawFont, drawBrush, drawRect);

            }


        }
        private void DFTS(object sender, PaintEventArgs e)//Dfts için çizim yapılması
        {

            Graphs.Node a = new Graphs.Node();
            Graphs.Derinlik__Oncelikli kısayolerişim = new Graphs.Derinlik__Oncelikli();
            kısayolerişim.DepthFirst(tepesayısı,başlangıç);
            a.noktalar(tepesayısı);
            Graphics panel2 = e.Graphics;
            Pen pen = new Pen(Color.Black);
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);


            for (int i = 0; i < tepesayısı; ++i)
            {
                Brush B = new SolidBrush(Color.Azure);
                panel2.DrawEllipse(pen, a.noktaların[i].noktanın.X, a.noktaların[i].noktanın.Y, 50, 50);
                panel2.FillEllipse(B, a.noktaların[i].noktanın.X, a.noktaların[i].noktanın.Y, 50, 50);
                Rectangle drawRect = new Rectangle((a.noktaların[i].noktanın.X + 15), (a.noktaların[i].noktanın.Y + 15), 60, 60);
                panel2.DrawString(a.noktaların[i].ad, drawFont, drawBrush, drawRect);
            }
            int j = 0;
            for (int i = 0; i < kısayolerişim.dolaşılanlarderinlik.Count - 1; ++i)
            {
                Brush B = new SolidBrush(Color.Red);
                panel2.DrawEllipse(pen, a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i]].noktanın.X, a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i]].noktanın.Y, 50, 50);
                panel2.FillEllipse(B, a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i]].noktanın.X, a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i]].noktanın.Y, 50, 50);
                Rectangle drawRect = new Rectangle((a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i]].noktanın.X + 15), (a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i]].noktanın.Y + 15), 60, 60);
                panel2.DrawString(a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i]].ad, drawFont, drawBrush, drawRect);
                panel2.DrawLine(pen, a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i]].noktanın.X + 20, a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i]].noktanın.Y + 20, a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i + 1]].noktanın.X + 20, a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i + 1]].noktanın.Y + 20);

                panel2.DrawString(""+(i+1), drawFont, drawBrush,new Point( (a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i]].noktanın.X +a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i+1]].noktanın.X)/2 , (a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i]].noktanın.Y +a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[i+1]].noktanın.Y)/2));
                j = i;
            }
            Brush Brush = new SolidBrush(Color.Red);
            panel2.DrawEllipse(pen, a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[j + 1]].noktanın.X, a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[j + 1]].noktanın.Y, 50, 50);
            panel2.FillEllipse(Brush, a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[j + 1]].noktanın.X, a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[j + 1]].noktanın.Y, 50, 50);
            Rectangle draw = new Rectangle((a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[j + 1]].noktanın.X + 15), (a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[j + 1]].noktanın.Y + 15), 60, 60);
            panel2.DrawString(a.noktaların[(int)kısayolerişim.dolaşılanlarderinlik[j + 1]].ad, drawFont, drawBrush, draw);

           
        }
        private void kisaYolCiz(object sender, PaintEventArgs e)//kısayol için çizim yapılması
        {
            Graphs.Node a = new Graphs.Node();
            Graphs.Floyd kısayolerişim = new Graphs.Floyd();
            Graphs.matrismaliyet matris = new Graphs.matrismaliyet();
            a.noktalar(tepesayısı);
            matris.maliyet(tepesayısı, 200, a);
            kısayolerişim.Siralama(matris.cost, başlangıç_tepesi, bitiştepesi);
            Graphics panel1 = e.Graphics;
            Pen pen = new Pen(Color.Black);
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);


            for (int i = 0; i < tepesayısı; ++i)
            {
                Brush B = new SolidBrush(Color.BlueViolet);
                panel1.DrawEllipse(pen, a.noktaların[i].noktanın.X, a.noktaların[i].noktanın.Y, 50, 50);
                panel1.FillEllipse(B, a.noktaların[i].noktanın.X, a.noktaların[i].noktanın.Y, 50, 50);
                Rectangle drawRect = new Rectangle((a.noktaların[i].noktanın.X + 15), (a.noktaların[i].noktanın.Y + 15), 60, 60);
                panel1.DrawString(a.noktaların[i].ad, drawFont, drawBrush, drawRect);
            }
            int j = 0;

            for (int i = 0; i < kısayolerişim.dolasılannoktalar.Count - 1; ++i)
            {
                Brush B = new SolidBrush(Color.Red);
                panel1.DrawEllipse(pen, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.X, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.Y, 50, 50);
                panel1.FillEllipse(B, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.X, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.Y, 50, 50);
                Rectangle drawRect = new Rectangle((a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.X + 15), (a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.Y + 15), 60, 60);
                panel1.DrawString(a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].ad, drawFont, drawBrush, drawRect);
                panel1.DrawLine(pen, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.X + 20, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.Y + 20, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i + 1]].noktanın.X + 20, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i + 1]].noktanın.Y + 20);
                panel1.DrawString("" + matris.cost[(int)kısayolerişim.dolasılannoktalar[i], (int)kısayolerişim.dolasılannoktalar[i+1]], drawFont, drawBrush, new Point((a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.X + a.noktaların[(int)kısayolerişim.dolasılannoktalar[i + 1]].noktanın.X) / 2, (a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.Y + a.noktaların[(int)kısayolerişim.dolasılannoktalar[i + 1]].noktanın.Y) / 2));
                j = i;
            }
            Brush Brush = new SolidBrush(Color.Red);
            panel1.DrawEllipse(pen, a.noktaların[(int)kısayolerişim.dolasılannoktalar[j + 1]].noktanın.X, a.noktaların[(int)kısayolerişim.dolasılannoktalar[j + 1]].noktanın.Y, 50, 50);
            panel1.FillEllipse(Brush, a.noktaların[(int)kısayolerişim.dolasılannoktalar[j + 1]].noktanın.X, a.noktaların[(int)kısayolerişim.dolasılannoktalar[j + 1]].noktanın.Y, 50, 50);
            Rectangle draw = new Rectangle((a.noktaların[(int)kısayolerişim.dolasılannoktalar[j + 1]].noktanın.X + 15), (a.noktaların[(int)kısayolerişim.dolasılannoktalar[j + 1]].noktanın.Y + 15), 60, 60);
            panel1.DrawString(a.noktaların[(int)kısayolerişim.dolasılannoktalar[j + 1]].ad, drawFont, drawBrush, draw);
        }
        private void MinimumSpanningTreeÇiz(object sender, PaintEventArgs e)
        {
            Graphs.Node a = new Graphs.Node();
            Graphs.Floyd kısayolerişim = new Graphs.Floyd();
            Graphs.matrismaliyet matris = new Graphs.matrismaliyet();
            a.noktalar(10);
            matris.maliyet(10, 200, a);
            kısayolerişim.Siralama(matris.cost, 1, 5);
            Graphics panel2 = e.Graphics;
            Pen pen = new Pen(Color.Black);
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);


            for (int i = 0; i < tepesayısı; ++i)
            {
                Brush B = new SolidBrush(Color.Azure);
                panel2.DrawEllipse(pen, a.noktaların[i].noktanın.X, a.noktaların[i].noktanın.Y, 50, 50);
                panel2.FillEllipse(B, a.noktaların[i].noktanın.X, a.noktaların[i].noktanın.Y, 50, 50);
                Rectangle drawRect = new Rectangle((a.noktaların[i].noktanın.X + 15), (a.noktaların[i].noktanın.Y + 15), 30, 30);
                panel2.DrawString(a.noktaların[i].ad, drawFont, drawBrush, drawRect);
            }

            for (int i = 0; i < kısayolerişim.dolasılannoktalar.Count - 1; ++i)
            {
                Brush B = new SolidBrush(Color.Red);
                panel2.DrawEllipse(pen, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.X, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.Y, 50, 50);
                panel2.FillEllipse(B, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.X, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.Y, 50, 50);
                Rectangle drawRect = new Rectangle((a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.X + 20), (a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.Y + 20), 30, 30);
                panel2.DrawString(a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].ad, drawFont, drawBrush, drawRect);
                panel2.DrawLine(pen, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.X + 20, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.Y + 20, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i + 1]].noktanın.X + 20, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i + 1]].noktanın.Y + 20);
                Rectangle draw = new Rectangle(((a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.X + a.noktaların[(int)kısayolerişim.dolasılannoktalar[i + 1]].noktanın.X) / 2 + 10), ((a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.Y + a.noktaların[(int)kısayolerişim.dolasılannoktalar[i]].noktanın.Y) / 2 - 10), 30, 30);
                panel2.DrawString("" + matris.cost[(int)kısayolerişim.dolasılannoktalar[i], (int)kısayolerişim.dolasılannoktalar[i + 1]], drawFont, drawBrush, new Point(a.noktaların[(int)kısayolerişim.dolasılannoktalar[i + 1]].noktanın.X, a.noktaların[(int)kısayolerişim.dolasılannoktalar[i + 1]].noktanın.Y));
            }
        }

        private void button1_Click(object sender, EventArgs e)//tepe sayısının alınması
        {
            button1.Refresh();
            
            tepesayısı = Int16.Parse(textBox1.Text);

            panel.Paint += dugumleriCizdir;

            this.Controls.Add(panel);//panel ekle
            panel.Show();//paneli göster
        }

        private void button4_Click(object sender, EventArgs e)//en kısa yol için paneli göster
        {
           
            if (this.panel.Equals(panel))
            {
                panel.Dispose();
                this.Controls.Remove(panel);
                this.Controls.Add(panel1);
            }
            else if (this.panel2.Equals(panel1))
            {
                panel1.Dispose();
                this.Controls.Remove(panel);
                this.Controls.Add(panel1);
            }
            else  if (this.panel3.Equals(panel3))
            {
                panel3.Dispose();
                this.Controls.Remove(panel);
                this.Controls.Add(panel1);
            }

            panel1.Paint += kisaYolCiz;
            panel1.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)//DFTS başlanğıç tepesinin alımı
        {
            başlangıç = Int32.Parse(textBox4.Text);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            başlangıç = Int32.Parse(textBox4.Text);
        }

        private void button3_Click_2(object sender, EventArgs e)//en kısa yol başlangıç ve bitiş tepesinin alımı
        {
            başlangıç_tepesi = Int32.Parse(textBox2.Text);
            bitiştepesi = Int32.Parse(textBox3.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
          
        }
    }
    namespace Graphs//Graps ad uzayı
    {

        class matrismaliyet//minimum spanning tree ve en kısa yol için noktalar arası maliyet atama
        {

            Random rnd = new Random();
            public int[,] cost;
            public void maliyet(int tepesayısı, int yarıçap, Node a)//me
            {

                cost = new int[tepesayısı, tepesayısı];

                for (int i = 0; i < tepesayısı; ++i)
                {
                    for (int j = 0; j < tepesayısı; j++)
                    {
                        cost[i, j] = new int();
                        if (i == j)
                            cost[i, j] = 0;
                        else
                            cost[i, j] = rnd.Next(1, 25);
                    }
                }
            }

        }
        class Floyd
        {

            public ArrayList dolasılannoktalar;

            public void Siralama(int[,] Cost, int başlangıçnoktası, int bitiş)
            {
                dolasılannoktalar = new ArrayList();
                dolasılannoktalar.Add(başlangıçnoktası);
                dolasılannoktalar.Add(bitiş);

                for (int k = 0; k < Cost.GetLength(0); ++k)

                    if (Cost[başlangıçnoktası, bitiş] > Cost[başlangıçnoktası, k] + Cost[k, bitiş])
                    {
                        Cost[başlangıçnoktası, bitiş] = Cost[başlangıçnoktası, k] + Cost[k, bitiş];
                        dolasılannoktalar.Add(k);
                    }

            }


        }
        class Derinlik__Oncelikli
        {
            public ArrayList dolaşılanlarderinlik;
            int[] visited;
             Random rnd = new Random();
            int[,] cost;
            public void DepthFirst(int tepesayısı, int başlangıç)
            {

                cost = new int[tepesayısı, tepesayısı];

                for (int i = 0; i < tepesayısı; ++i)
                {
                    for (int j = 0; j < tepesayısı; j++)
                    {
                        cost[i, j] = new int();
                        if (i == j)
                            cost[i, j] = 1;
                        else
                            cost[i, j] = rnd.Next(1);
                    }
                }
                visited = new int[cost.GetLength(0)];
                dolaşılanlarderinlik = new ArrayList();
                for (int i = 0; i < cost.GetLength(0); ++i)
                    visited[i] = 0;
                traverse(cost, başlangıç);
            }
            public void traverse(int[,] cost, int başlangıç)
            {
                visited[başlangıç] = 1;
                dolaşılanlarderinlik.Add(başlangıç);
                for (int w = 0; w < cost.GetLength(0); ++w)
                {
                    if (0== visited[w])
                        traverse(cost, w);

                }

            }





        }


        class Mst
        {









        }

        class Node
        {

            public Node[] noktaların;
            public Point noktanın { get; set; }
            public string ad { get; set; }
            int çap = 200;
            public Node(string ad, Point x)
            {
                noktanın = x;
                this.ad = ad;

            }
            public Node()
            { }
            public void noktalar(int tepesayısı)
            {
                noktaların = new Node[tepesayısı];


                for (int i = 0; i < tepesayısı; ++i)
                {
                    noktaların[i] = new Node();
                    Point denek = new Point((int)(250 + çap * Math.Cos(2 * Math.PI * i / tepesayısı)), (int)(250 + çap * Math.Sin(2 * Math.PI * i / tepesayısı)));
                    noktaların[i].noktanın = denek;
                    noktaların[i].ad = "" + i;
                }

            }

        }

    }
}

