using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mysql
{
    public partial class frmmenu : Form
    {
        public frmmenu()
        {
            InitializeComponent();
        }

        private void recetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmpdc frmpdc = new frmpdc();
            frmpdc.MdiParent = this;
            frmpdc.Show();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtest frmtest = new frmtest();
            frmtest.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
