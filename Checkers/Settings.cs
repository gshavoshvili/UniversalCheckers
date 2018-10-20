using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Rules.BackKills = checkBox3.Checked;
            Rules.MustKill = checkBox1.Checked;
            Rules.LongMoves = checkBox2.Checked;
            Form1 f1 = new Form1(this);
            f1.Show();
            Hide();
        }
    }
}
