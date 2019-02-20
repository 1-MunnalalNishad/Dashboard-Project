using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(startForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
            
        }

        public void startForm()
        {
            Application.Run(new splashscreen());
        }
        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void musicBtn_Click(object sender, EventArgs e)
        {
           
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void vidBtn_Click(object sender, EventArgs e)
        {
            Videoplayer vidplay = new Videoplayer();
            vidplay.ShowDialog();
        }

        private void ImageBtn_Click(object sender, EventArgs e)
        {
            imageviewer img = new imageviewer();
            img.ShowDialog();
        }

        private void PdfBtn_Click(object sender, EventArgs e)
        {
            PDF p = new PDF();
            p.ShowDialog();
        }

        private void YoutubeBtn_Click(object sender, EventArgs e)
        {
            youtube ytube = new youtube();
            ytube.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblSecond.Text = DateTime.Now.ToString("ss");
            lblDate.Text = DateTime.Now.ToString("MM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
        }

        private void CompressBtn_Click(object sender, EventArgs e)
        {
            fileCompression fcompress = new fileCompression();
            fcompress.ShowDialog();
        }

        private void ClanderBtn_Click(object sender, EventArgs e)
        {
            Calander cal = new Calander();
            cal.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void VoiceRecBtn_Click(object sender, EventArgs e)
        {
            mycamera cam = new mycamera();
            cam.ShowDialog();
        }

        private void WebBtn_Click(object sender, EventArgs e)
        {
            browser bro = new browser();
            bro.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            googlemap g = new googlemap();
            g.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            face fa = new face();
            fa.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Note n = new Note();
            n.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Currency cer = new Currency();
            cer.ShowDialog();
        }

        private void Calc_Click(object sender, EventArgs e)
        {
            cal ca = new cal();
            ca.ShowDialog();
        }
    }
}
