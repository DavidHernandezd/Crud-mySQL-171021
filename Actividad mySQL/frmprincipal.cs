using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad_mySQL
{
    public partial class frmprincipal : Form
    {
        public frmprincipal()
        {
            InitializeComponent();
        }

        private void recetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmpdc frmrecetas = new frmpdc();
            frmrecetas.MdiParent = this;
            frmrecetas.Show();
        }
    }
}
