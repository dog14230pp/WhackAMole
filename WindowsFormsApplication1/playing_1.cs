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
    public partial class playing_1 : Form
    {
        public playing_1()
        {
            InitializeComponent();
        }

//reset函式
        private void reset_hole(int x)
        {
            if(x == 1)
            {
                this.pictureBox1.Image = Image.FromFile("image\\hole_2.png");//把洞設定好
                this.pictureBox1.Image.Tag = "hole";  //設定圖片的Tag
            }
            else if(x == 2)
            {
                this.pictureBox2.Image = Image.FromFile("image\\hole_2.png");
                this.pictureBox2.Image.Tag = "hole";
            }
            else if(x == 3)
            {
                this.pictureBox3.Image = Image.FromFile("image\\hole_2.png");
                this.pictureBox3.Image.Tag = "hole";
            }
            else if(x == 4)
            {
                this.pictureBox4.Image = Image.FromFile("image\\hole_2.png");
                this.pictureBox4.Image.Tag = "hole";
            }
            else if(x == 5)
            {
                this.pictureBox5.Image = Image.FromFile("image\\hole_2.png");
                this.pictureBox5.Image.Tag = "hole";
            }
            else if(x == 6)
            {
                this.pictureBox6.Image = Image.FromFile("image\\hole_2.png");
                this.pictureBox6.Image.Tag = "hole";

            }
        }

//設定地鼠的函式
        private void set_gophers(int which, int hole_no)
        {
            if(which == 0)
            {
                switch (hole_no)
                {
                    case 1:
                        this.pictureBox1.Image = Image.FromFile("image\\portrait01.png");
                        this.pictureBox1.Image.Tag = "mouse";
                        break;
                    case 2:
                        this.pictureBox2.Image = Image.FromFile("image\\portrait01.png");
                        this.pictureBox2.Image.Tag = "mouse";
                        break;
                    case 3:
                        this.pictureBox3.Image = Image.FromFile("image\\portrait01.png");
                        this.pictureBox3.Image.Tag = "mouse";
                        break;
                    case 4:
                        this.pictureBox4.Image = Image.FromFile("image\\portrait01.png");
                        this.pictureBox4.Image.Tag = "mouse";
                        break;
                    case 5:
                        this.pictureBox5.Image = Image.FromFile("image\\portrait01.png");
                        this.pictureBox5.Image.Tag = "mouse";
                        break;
                    case 6:
                        this.pictureBox6.Image = Image.FromFile("image\\portrait01.png");
                        this.pictureBox6.Image.Tag = "mouse";
                        break;
                    case 7:
                        break;
                }
            }
            else
            {
                switch (hole_no)
                {
                    case 1:
                        this.pictureBox1.Image = Image.FromFile("image\\bad.png");
                        this.pictureBox1.Image.Tag = "bad";
                        break;
                    case 2:
                        this.pictureBox2.Image = Image.FromFile("image\\bad.png");
                        this.pictureBox2.Image.Tag = "bad";
                        break;
                    case 3:
                        this.pictureBox3.Image = Image.FromFile("image\\bad.png");
                        this.pictureBox3.Image.Tag = "bad";
                        break;
                    case 4:
                        this.pictureBox4.Image = Image.FromFile("image\\bad.png");
                        this.pictureBox4.Image.Tag = "bad";
                        break;
                    case 5:
                        this.pictureBox5.Image = Image.FromFile("image\\bad.png");
                        this.pictureBox5.Image.Tag = "bad";
                        break;
                    case 6:
                        this.pictureBox6.Image = Image.FromFile("image\\bad.png");
                        this.pictureBox6.Image.Tag = "bad";
                        break;
                    case 7:
                        break;
                }
            }
          
        }


        //宣告分數
        public static int score;
        //宣告時間
        int time_left = 0;

//所有全域變數的宣告位置
        Random num = new Random();//處理timer1出現的地鼠位置
        Random num_3 = new Random();//處理timer3地鼠出現位置
        Random set_timer3 = new Random();//這個亂數將處理下一次timer_3觸發的時間，達到非常不固定的順序。

        private void playing_Load(object sender, EventArgs e)
        {

            Program.index = 1;

            this.記錄結果ToolStripMenuItem.Enabled = false;
            this.timer1.Enabled = false;
            this.timer2.Enabled = false;
            this.timer3.Enabled = false;
            this.timer4.Enabled = false;
            this.timer5.Enabled = false;

            this.label1.Text = "0";
            score = 0;//初始化分數
            this.timer1.Enabled = true;
            this.timer5.Enabled = true; //for時間倒數
            time_left = 60;//設定時間
            this.label4.Text = time_left.ToString();
            

            if (choose.choose_result == 0)
            {
                this.timer1.Interval = 2000;
                this.timer2.Interval = 1000;
            }
            else if (choose.choose_result == 1)
            {
                this.timer1.Interval = 1500;
                this.timer2.Interval = 800;
            }
            else
            {
                this.timer1.Interval = 1000;
                this.timer2.Interval = 600;
            }

            //呼叫reset
            for (int i = 1; i <= 6; i++)
            {
                reset_hole(i);
            }

            //此將先設定第一次timer3觸發的時間
            this.timer3.Interval = Convert.ToInt32(set_timer3.NextDouble() * 10000);
            this.timer3.Enabled = true;
        }

//設定基本地鼠的位置
        int test;
        private void timer1_Tick(object sender, EventArgs e)
        {
            test = num.Next(7);//設定亂數
            set_gophers(0, test);
            //為了要確保每隻出現的時間都固定!!
            this.timer2.Enabled = true;  
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            reset_hole(test);//reset hole
            this.timer2.Enabled = false;

        }


//以下為點擊地鼠後會發生的事件!!!
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (this.pictureBox1.Image.Tag == "mouse")
            {
                this.axWindowsMediaPlayer1.URL = "hit.wav";
                score += 10;
                reset_hole(1);//呼叫reset
            }
            else if (this.pictureBox1.Image.Tag == "bad")
            {
                this.axWindowsMediaPlayer1.URL = "答錯音效.mp3"; 
                score -= 10;
                reset_hole(1);
            }
                
            this.label1.Text = score.ToString();
                
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.pictureBox2.Image.Tag == "mouse")
            {
                this.axWindowsMediaPlayer1.URL = "hit.wav";
                score += 10;
                reset_hole(2);//呼叫reset
            }
            else if(this.pictureBox2.Image.Tag == "bad")
            {
                this.axWindowsMediaPlayer1.URL = "答錯音效.mp3";
                score -= 10;
                reset_hole(2);
            }
            this.label1.Text = score.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.pictureBox3.Image.Tag== "mouse")
            {
                this.axWindowsMediaPlayer1.URL = "hit.wav";
                score += 10;
                reset_hole(3);//呼叫reset
            }
            else if(this.pictureBox3.Image.Tag == "bad")
            {
                this.axWindowsMediaPlayer1.URL = "答錯音效.mp3";
                score -= 10;
                reset_hole(3);
            }
            this.label1.Text = score.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (this.pictureBox4.Image.Tag == "mouse")
            {
                this.axWindowsMediaPlayer1.URL = "hit.wav";
                score += 10;
                reset_hole(4);//呼叫reset
            }
            else if(this.pictureBox4.Image.Tag == "bad")
            {
                this.axWindowsMediaPlayer1.URL = "答錯音效.mp3";
                score -= 10;
                reset_hole(4);
            }
            this.label1.Text = score.ToString();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (this.pictureBox5.Image.Tag == "mouse")
            {
                this.axWindowsMediaPlayer1.URL = "hit.wav";
                score += 10;
                reset_hole(5);//呼叫reset
            }
            else if(this.pictureBox5.Image.Tag == "bad")
            {
                this.axWindowsMediaPlayer1.URL = "答錯音效.mp3";
                score -= 10;
                reset_hole(5);
            }
            this.label1.Text = score.ToString();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (this.pictureBox6.Image.Tag == "mouse")
            {
                this.axWindowsMediaPlayer1.URL = "hit.wav";
                score += 10;
                reset_hole(6);//呼叫reset
            }
            else if(this.pictureBox6.Image.Tag == "bad")
            {
                this.axWindowsMediaPlayer1.URL = "答錯音效.mp3";
                score -= 10;
                reset_hole(6);
            }
            this.label1.Text = score.ToString();
        }

//timer3_隨機出現地鼠
        int test_for_timer3;
        private void timer3_Tick(object sender, EventArgs e)
        {
            test_for_timer3 = num_3.Next(9);//設定亂數

            //為了要確保每隻出現的時間都固定!!
            this.timer4.Interval = this.timer3.Interval / 2;  //地鼠停留時間控制在timer3的一半
            if(test_for_timer3 <= 6)
            {
                set_gophers(0, test_for_timer3);
            }
            else
            {
                test_for_timer3 = num_3.Next(1, 7);
                set_gophers(1, test_for_timer3);
            }
            this.timer4.Enabled = true;

            while (true)
            {
                int temp = Convert.ToInt32(set_timer3.NextDouble() * 10000);//重設timer3的區間
                if(choose.choose_result == 0)
                {
                    if (temp < 4000)  //初級太快
                    {
                        continue;
                    }
                    this.timer3.Interval = temp;  //可以接受的速度
                    break;

                }
                else if(choose.choose_result == 1)
                {
                    if(temp < 3500)  //中級太快
                    {
                        continue;
                    }
                    this.timer3.Interval = temp;   //可以接受的速度  
                    break; 
                }
                else if (choose.choose_result == 2 )   //高級
                {
                    if(temp > 3000 )  //太慢
                    {
                        continue;
                    }
                    this.timer3.Interval = temp;
                    break;
                }
            }  
        }

        //timer3出現地鼠後，控制地鼠出現的時間長度。
        private void timer4_Tick(object sender, EventArgs e)
        {
            reset_hole(test_for_timer3);//reset hole
            this.timer4.Enabled = false;
        }

        //時間倒數!!
        private void timer5_Tick(object sender, EventArgs e)
        {
            --time_left;
            this.label4.Text = time_left.ToString();
            if (time_left == 0)
            {
                this.timer1.Enabled = false;
                this.timer3.Enabled = false;
                this.timer5.Enabled = false;
                this.記錄結果ToolStripMenuItem.Enabled = true;
                //呼叫reset
                for (int i = 1; i <= 6; i++)
                {
                    reset_hole(i);
                }
            }
        }

        private void 離開程式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 回主選單ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.index = 2; //配合form1音檔會重複播放問題!!!
            Form1 f1 = new Form1();
            f1.Show();

            this.Close();
        }

        private void playing_1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Program.index == 1)
                Application.Exit();
        }

        private void 關於ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright  孫帥哥 葉大俠所有!!!");
        }

        private void 記錄結果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ranking rk = new Ranking();
            rk.ShowDialog();
        }

    }
}
