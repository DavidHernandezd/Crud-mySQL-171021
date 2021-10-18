using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace mysql
{
    public partial class frmpdc : Form
    {
        string actions = "";
        public frmpdc()
        {
            InitializeComponent();
        }

        private void frmrecetas_Load(object sender, EventArgs e)
        {
            filldgv();
        }
        
        public void filldgv()
        {
            Pdc pdc = new Pdc();

            cleardgv();

            dgv.Columns.Add("_ID", "ID de parte");
            dgv.Columns.Add("_Pnombre", "NOMBRE");
            dgv.Columns.Add("_Pprecio", "PRECIO");
            dgv.Columns.Add("_Pmarca", "MARCA");

            MySqlDataReader dataReader = pdc.getallcarpat();

            while (dataReader.Read())
            {
                dgv.Rows.Add(
                    dataReader.GetValue(0),
                    dataReader.GetValue(1),
                    dataReader.GetValue(2),
                    dataReader.GetValue(3)
                    );
            }

        }

        public void cleardgv()
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
        }

        public void clearcontrols()
        {
            txbname.Text = "";
            txbprecio.Text = "";
            txbmarca.Text = "";
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            Pdc pdc = new Pdc();

            if (rdbnuevoelemento.Checked == true)
            {
                actions = "new";
            }
            else if (rdbactualizarelemento.Checked == true)
            {
                actions = "edit";
                pdc._ID = Convert.ToInt32(txbid.Text);
            }
            pdc._Pnombre = txbname.Text;
            pdc._Pprecio = Convert.ToInt32(txbprecio.Text);
            pdc._Pmarca = txbmarca.Text;

            string mensaje = "seguro de que quiere continuar?";
            
            if (MetroFramework.MetroMessageBox.Show(this, mensaje, "confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (pdc.newEditcarpart(actions))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Se ha guardado correctamente :)", "exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Los datos no se han podido guardar, lo sentimos :(",
                        "fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            cleardgv();
            filldgv();
            clearcontrols();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            txbid.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txbname.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txbprecio.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            txbmarca.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            rdbactualizarelemento.Checked = true;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string mensaje = "seguro que deseas eliminar el registro?";
            if (MetroFramework.MetroMessageBox.Show(this, mensaje, "confirmar",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Pdc pdc = new Pdc();
                pdc._ID = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);

                //llamado al metodo deleteBook() de la clase Book
                if (pdc.deletecarpart())
                {
                    MetroFramework.MetroMessageBox.Show(this, "Los datos se han eliminado! (nada paso aqui)",
                        "exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //actualizar datagridview
                    filldgv();

                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "No se han eliminado los datos :(",
                        "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
