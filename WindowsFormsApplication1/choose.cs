using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class choose : Form
    {
        public choose()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
        }

        public static int choose_result = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
                choose_result = 0;
            else if (this.radioButton2.Checked)
                choose_result = 1;
            else
                choose_result = 2;

        }
    }
}
