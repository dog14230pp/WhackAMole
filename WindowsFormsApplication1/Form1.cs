using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            choose form_ch = new choose();
            form_ch.ShowDialog();
            if (form_ch.DialogResult == DialogResult.OK)
            {
                //開啟遊戲視窗!!
                playing_1 play = new playing_1();
                play.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Computer mycomputer = new Computer();
            //mycomputer.Audio.Play("原創音樂配樂-愉快.wav", AudioPlayMode.BackgroundLoop);
            if(Program.index == 0)
            {
                this.axWindowsMediaPlayer1.URL = "原創音樂配樂-愉快.wav";
                this.axWindowsMediaPlayer1.settings.setMode("loop", true);
                this.axWindowsMediaPlayer1.settings.volume = 100;
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Showing_rank sr = new Showing_rank();
            sr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("在一定的時間內清除最多的地鼠\n一隻地鼠+10分，打到不是地鼠的-10分");
        }
    }
}
