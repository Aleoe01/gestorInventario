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
    public partial class FrmModificar : Form
    {
        private Articulo modificable;
        public FrmModificar()
        {
            InitializeComponent();
        }

        public FrmModificar(Articulo modificable)
        {
            InitializeComponent();
            this.modificable = modificable;
        }

        private void FrmModificar_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {
                txbAddCodigo.Text = modificable.Codigo;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
