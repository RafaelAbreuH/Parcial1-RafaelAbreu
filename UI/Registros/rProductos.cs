using ProyectoParcial.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoParcial.UI.Registros
{
    public partial class rProductos : Form
    {
        public rProductos()
        {
            InitializeComponent();
        }

        private void ExistenciatextBox_TextChanged(object sender, EventArgs e)
        {

            double relt = 0;
            if (ExistenciatextBox.Text != string.Empty)
            {
                if (CostotextBox.Text != string.Empty)
                {
                    relt = ProductosBLL.ValorInv(Convert.ToInt32(CostotextBox.Text), Convert.ToInt32(ExistenciatextBox.Text));
                    ValorInventariotextBox.Text = Convert.ToString(relt);
                }
            }
        }

        private void CostotextBox_TextChanged(object sender, EventArgs e)
        {
            double relt = 0;
            if (ExistenciatextBox.Text != string.Empty)
            {
                if (CostotextBox.Text != string.Empty)
                {
                    relt = ProductosBLL.ValorInv(Convert.ToInt32(CostotextBox.Text), Convert.ToInt32(ExistenciatextBox.Text));
                    ValorInventariotextBox.Text = Convert.ToString(relt);
                }
            }
        }
    }
}
