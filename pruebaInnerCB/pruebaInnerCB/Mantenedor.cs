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
        
        ArticuloBodega objart = new ArticuloBodega();
        bool Editar = false;
        string idprod;

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
            
            dgvProd.DataSource = objart.ListarProductos();
            
            

        }

        // Aqui cambié el valor mostrado para evitar el problema con la relación de la BD
        private void listarBodega()
        {
            ArticuloBodega objbod = new ArticuloBodega();
            cbBodega.DataSource = objbod.ListarBodegas();
            cbBodega.DisplayMember = "Localidad";
            cbBodega.ValueMember = "idBodegas";

        }

        public void Limpiar()
        {
            tbDescripcion.Clear();
            tbPrecio.Clear();
            tbStock.Clear();

        }
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {

                string desc = tbDescripcion.Text;
                int precio = Convert.ToInt32(tbPrecio.Text);
                int stock = Convert.ToInt32(tbStock.Text);
                int bodega = Convert.ToInt32(cbBodega.SelectedValue);
                ArticuloBodega objbod = new ArticuloBodega();
                objbod.insertarDatos(bodega, desc, precio, stock);
            }
            else if (Editar == true)
            {

                objart.editarProducto(Convert.ToInt32(idprod), 
                   Convert.ToInt32(cbBodega.SelectedValue), tbDescripcion.Text, 
                   Convert.ToInt32(tbPrecio.Text), Convert.ToInt32(tbStock.Text));
                MessageBox.Show("Registro editado");

            }

            Listar();
            Limpiar();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProd.SelectedRows.Count > 0)
            {

                Editar = true;
                tbDescripcion.Text = dgvProd.CurrentRow.Cells["Descripcion"].Value.ToString();
                tbPrecio.Text = dgvProd.CurrentRow.Cells[3].Value.ToString();
                tbStock.Text = dgvProd.CurrentRow.Cells[4].Value.ToString();
                cbBodega.Text = dgvProd.CurrentRow.Cells["idBodega"].Value.ToString();
                idprod = dgvProd.CurrentRow.Cells[0].Value.ToString();


            }
            else
            {
                Editar = false;
                MessageBox.Show("Debe seleccionar una fila");
                
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            idprod = dgvProd.CurrentRow.Cells[0].Value.ToString();
            objart.eliminarProducto(Convert.ToInt32(idprod));
            Listar();
        }
    }
}
