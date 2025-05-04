using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace gestorDeInventario
{
    public partial class Form1: Form
    {
        private List<Articulo> articuloList; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cargar();

        }

        private void cargar()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {
                articuloList = articuloNegocio.listar();
                dgvArticulos.DataSource = articuloList;
                ocultarColumnas();
                Helper.cargarImagen(articuloList[0].ImagenUrl, pbxArticulo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["id"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
        }


        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow != null)
            {
                Articulo seleccion = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                Helper.cargarImagen(seleccion.ImagenUrl, pbxArticulo);
            } 
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo articuloDetallado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            FrmDetalle frmDetalle = new FrmDetalle(articuloDetallado);
            frmDetalle.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar frmAgregar = new frmAgregar();
            frmAgregar.ShowDialog();
            cargar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
