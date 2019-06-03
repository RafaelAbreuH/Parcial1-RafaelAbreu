using ProyectoParcial.UI.Consultas;
using ProyectoParcial.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoParcial
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProductos ver = new rProductos();
            ver.MdiParent = this;
            ver.Show();
        }

        private void ValorTotalInventaroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cInventario ver = new cInventario();
            ver.MdiParent = this;
            ver.Show();
        }
    }
}
