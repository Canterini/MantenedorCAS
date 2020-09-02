using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pruebaInnerCB.Datos;

namespace pruebaInnerCB
{
    public partial class Mantenedor : Form
    {
        testingEntities db_context = new testingEntities();

        public Mantenedor()
        {
            InitializeComponent();
        }

        private void Mantenedor_Load(object sender, EventArgs e)
        {

            Listar();
            listarBodega();

        }

        private void Listar()
        {
            ArticuloBodega objart = new ArticuloBodega();
            dgvProd.DataSource = objart.ListarProductos();
            

        }

        private void listarBodega()
        {
            ArticuloBodega objbod = new ArticuloBodega();
            cbBodega.DataSource = objbod.ListarBodegas();
            cbBodega.DisplayMember = "Localidad";
            cbBodega.ValueMember = "idBodegas";

        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string desc = tbDescripcion.Text;
            int precio = Convert.ToInt32(tbPrecio.Text);
            int stock = Convert.ToInt32(tbStock.Text);
            int bodega = Convert.ToInt32(cbBodega.SelectedValue);
            ArticuloBodega objbod = new ArticuloBodega();
            objbod.insertarDatos(bodega, desc, precio, stock);

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
