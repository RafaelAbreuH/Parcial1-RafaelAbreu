using ProyectoParcial.BLL;
using ProyectoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoParcial.UI.Consultas
{
    public partial class cInventario : Form
    {
        public cInventario()
        {
            InitializeComponent();
            SyncTotal();
            
        }

        private void SyncTotal()
        {
            Inventarios total = new Inventarios();

            try
            {
                if(InventarioBLL.Buscar() != null)
                {
                    InventarioBLL.Actualizar();
                    total = InventarioBLL.Buscar();
                }
                else
                {
                    Inventarios valor = new Inventarios();
                    InventarioBLL.Guardar(valor);
                    InventarioBLL.Actualizar();
                    valor = InventarioBLL.Buscar();
                }
            }
            catch(Exception)
            {

            }
            SyncedTotaltextBox.Text = total.ValorTotalInventario.ToString();

        }
        private void Syncbutton_Click(object sender, EventArgs e)
        {
            SyncTotal();
        }
    }
}
