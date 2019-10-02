using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Showing_rank : Form
    {
        public Showing_rank()
        {
            InitializeComponent();
        }

        string text = "", temp = "";
        private void Showing_rank_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml("record_rank.xml");
                this.dataGridView1.DataSource = ds.Tables["玩家"];
                XmlDocument doc = new XmlDocument();
                doc.Load("record_rank.xml");
                XmlNode a = doc.SelectSingleNode("Person");
                XmlNodeList nodelist = doc.SelectNodes("Person/玩家");
                text = "目前排行榜第一名為: "  + nodelist[0].SelectSingleNode("ID").InnerText + " 分數: " + nodelist[0].SelectSingleNode("分數").InnerText + " 請掌聲加尖叫!";
                this.label1.Text = text;
                this.timer1.Enabled = true;
            }
            catch
            {
                MessageBox.Show("找不到記錄檔，請先進行遊戲後並且記錄分數!!");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            temp = text[0].ToString();
            text = text.Substring(1) + temp;
            label1.Text = text;
        }
    }
}
