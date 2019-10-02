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
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Ranking : Form
    {
        public Ranking()
        {
            InitializeComponent();
        }

        private void read_xml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("record_rank.xml");
            XmlNode rootNode = doc.SelectSingleNode("Person");
            XmlNodeList nodelist = doc.SelectNodes("Person/玩家");
            XmlNode flagNode = null;
            if (nodelist.Count != 0) //代表XML中已經有元素
            {
                foreach (XmlNode tempNode in nodelist) //先找到應該要插在哪個位置
                {
                    if (int.Parse(tempNode.SelectSingleNode("分數").InnerText) < playing_1.score)
                    {
                        flagNode = tempNode;  //參考節點
                        break;
                    }
                }
                //再來要檢查ID存不存在，存在則做更新，不存在才新建立
                XmlElement root = doc.DocumentElement;
                XmlNode xn = doc.SelectSingleNode("/Person/玩家[ID='" + this.textBox1.Text + "']");
                if (xn != null)
                {
                    if (int.Parse(xn.SelectSingleNode("分數").InnerText) < playing_1.score)
                    {
                        xn.ParentNode.RemoveChild(xn);
                        doc.Save("record_rank.xml");//避免雙開
                        read_xml();
                    }
                    else
                    {
                        MessageBox.Show("不允許紀錄比之前爛的成績");
                        this.Close();
                    }

                }
                else //新元素，直接建立!!! / 或者更新玩家資訊，刪除舊資料後重新建立
                {
                    XmlNode nodeA = doc.CreateElement("玩家");
                    nodeA.InnerXml = "<ID>" + this.textBox1.Text + "</ID><分數>" + playing_1.score.ToString() + "</分數>";
                    if (flagNode != null)
                    {
                        rootNode.InsertBefore(nodeA, flagNode);

                    }
                    else //代表分數沒有比元素中任何一個人分數來的高
                    {
                        rootNode.AppendChild(nodeA);//加在最後面
                    }
                    doc.Save("record_rank.xml");
                    MessageBox.Show("儲存完畢囉!!");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("讀取出現問題");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            if (File.Exists("record_rank.xml") == false)
            {
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "", "yes");
                doc.PrependChild(xmlDeclaration);
                XmlElement main = doc.CreateElement("Person");
                doc.AppendChild(main);
                XmlElement player = doc.CreateElement("玩家");
                main.AppendChild(player);
                XmlElement id = doc.CreateElement("ID");
                player.AppendChild(id);
                id.InnerText = this.textBox1.Text;
                XmlElement sc = doc.CreateElement("分數");
                player.AppendChild(sc);
                sc.InnerText = playing_1.score.ToString();
                doc.Save("record_rank.xml");
                MessageBox.Show("儲存完畢囉!!");
                this.Close();
            }
            else
            {
                read_xml();
            }

        }
    }
}
