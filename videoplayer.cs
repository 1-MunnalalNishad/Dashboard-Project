using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Dashboard
{
    public partial class Videoplayer :Form
    {
        private int playlistindex;

        public string[] FileName { get; private set; }
        public string[] FilePath { get; private set; }
        public int Startindex { get; private set; }

        public Videoplayer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opnFileDlg = new OpenFileDialog();
            opnFileDlg.Multiselect = true;
            opnFileDlg.Filter = "(mp3,wav,mp4,mov,wmv,mpg,avi,3gp,flv)|*.mp3;*.wav;*.mp4;*.3gp;*.avi;*.mov;*.flv;*.wmv;*.mpg|all files|*.*";
            if (opnFileDlg.ShowDialog() == DialogResult.OK)
            {
                FileName = opnFileDlg.SafeFileNames;
                FilePath = opnFileDlg.FileNames;
                for (int i = 0; i < FilePath.Length; i++)

                {
                    listBox1.Items.Add(FileName[i]);
                    Startindex = 0;
                    Playfile(0);
                }
            }
        }

        private void Playfile(int v)
        {
            axWindowsMediaPlayer2.settings.autoStart = true;
            axWindowsMediaPlayer2.URL = FilePath[playlistindex];
            axWindowsMediaPlayer2.Ctlcontrols.next();
            axWindowsMediaPlayer2.Ctlcontrols.play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                if (listBox1.SelectedIndex == 0)
                {
                    listBox1.SelectedIndex = 0;
                    listBox1.Update();
                }
                else
                {
                    axWindowsMediaPlayer2.Ctlcontrols.previous();
                    listBox1.SelectedIndex -= 1;
                    listBox1.Update();
                }
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                axWindowsMediaPlayer2.Ctlcontrols.play();
            }
            else
            {
                axWindowsMediaPlayer2.Ctlcontrols.pause();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                if (listBox1.SelectedIndex < (listBox1.Items.Count - 1))
                {
                    axWindowsMediaPlayer2.Ctlcontrols.next();
                    listBox1.SelectedIndex += 1;
                    listBox1.Update();
                }
                else
                {

                    listBox1.SelectedIndex = 0;
                    listBox1.Update();
                }
            }
        }

        private void FastRevBtn_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                WMPLib.IWMPControls3 controls = (WMPLib.IWMPControls3)axWindowsMediaPlayer1.Ctlcontrols;
                if (controls.get_isAvailable("fastReverse"))
                {
                    controls.fastReverse();
                }
            }
        }

        private void fastNBtn_Click(object sender, EventArgs e)
        {

            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                WMPLib.IWMPControls3 controls = (WMPLib.IWMPControls3)axWindowsMediaPlayer2.Ctlcontrols;
                if (controls.get_isAvailable("fastForward"))
                {
                    controls.fastForward();
                }
            }
        }

        private void fullscrBtn_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer2.fullScreen = true;

            }
            else
            {
                axWindowsMediaPlayer2.fullScreen = false;
            }

        }

        private void volumeUpBtn_Scroll(object sender, EventArgs e)
        {
            volumeUpBtn.Minimum = 0;
            volumeUpBtn.Maximum = 100;
            axWindowsMediaPlayer2.settings.volume = volumeUpBtn.Value;
        }

        private void VoiceBtn_Click(object sender, EventArgs e)
        {

            if (axWindowsMediaPlayer2.settings.volume == 100)
            {
                axWindowsMediaPlayer2.settings.volume = 0;
            }
            else
            {
                axWindowsMediaPlayer2.settings.volume = 100;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.URL = FilePath[listBox1.SelectedIndex];

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer2.fullScreen = true;

            }
            else
            {
                axWindowsMediaPlayer2.fullScreen = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                if (listBox1.SelectedIndex == 0)
                {
                    listBox1.SelectedIndex = 0;
                    listBox1.Update();
                }
                else
                {
                    axWindowsMediaPlayer2.Ctlcontrols.previous();
                    listBox1.SelectedIndex -= 1;
                    listBox1.Update();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                axWindowsMediaPlayer2.Ctlcontrols.play();
            }
            else
            {
                axWindowsMediaPlayer2.Ctlcontrols.pause();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                if (listBox1.SelectedIndex < (listBox1.Items.Count - 1))
                {
                    axWindowsMediaPlayer2.Ctlcontrols.next();
                    listBox1.SelectedIndex += 1;
                    listBox1.Update();
                }
                else
                {

                    listBox1.SelectedIndex = 0;
                    listBox1.Update();
                }
            }
        }

        private void FastNextBtn_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                WMPLib.IWMPControls3 controls = (WMPLib.IWMPControls3)axWindowsMediaPlayer2.Ctlcontrols;
                if (controls.get_isAvailable("fastReverse"))
                {
                    controls.fastReverse();
                }
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                WMPLib.IWMPControls3 controls = (WMPLib.IWMPControls3)axWindowsMediaPlayer2.Ctlcontrols;
                if (controls.get_isAvailable("fastForward"))
                {
                    controls.fastForward();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer2.settings.volume == 100)
            {
                axWindowsMediaPlayer2.settings.volume = 0;
            }
            else
            {
                axWindowsMediaPlayer2.settings.volume = 100;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 100;
            axWindowsMediaPlayer2.settings.volume = trackBar1.Value;
        }

        private void axWindowsMediaPlayer2_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {

        }

        private void axWindowsMediaPlayer2_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar1.Maximum = (int)axWindowsMediaPlayer2.Ctlcontrols.currentItem.duration;
                timer1.Start();
            }
            else if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
            }
            else if (axWindowsMediaPlayer2.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Stop();
                progressBar1.Value = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = axWindowsMediaPlayer2.Ctlcontrols.currentPositionString;
            label3.Text = axWindowsMediaPlayer2.Ctlcontrols.currentItem.durationString.ToString();
            if(axWindowsMediaPlayer2.playState==WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar1.Value = (int)axWindowsMediaPlayer2.Ctlcontrols.currentPosition;
            }
        }
    }
}