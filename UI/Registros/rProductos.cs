using ProyectoParcial.BLL;
using ProyectoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            var listado = new List<Ubicaciones>();
            listado = UbicacionesBLL.Getlist(p => true);
            UbicacioncomboBox.DataSource = listado;
            UbicacioncomboBox.DisplayMember = "Descripcion";
            UbicacioncomboBox.ValueMember = "IdUbicacion";

        }

        public void soloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
        
                    e.Handled = false;
                }
                else if (Char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {

            }
        }

        private void ValorInventario()
        {
            if (CostotextBox.Text.Length > 0 && ExistenciatextBox.Text.Length > 0)
                ValorInventariotextBox.Text = Convert.ToString(Convert.ToDecimal(CostotextBox.Text) * Convert.ToInt32(ExistenciatextBox.Text));
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            ExistenciatextBox.Text = "0";
            CostotextBox.Text = "0";
            ValorInventariotextBox.Text = string.Empty;
            UbicacioncomboBox.SelectedValue = 1;
            MyerrorProvider.Clear();

        }


        private bool ExisteEnLaBaseDeDatos()
        {
            Productos producto = ProductosBLL.Buscar(Convert.ToInt32(IdnumericUpDown.Value));
            return (producto != null);
        }



        private Productos LlenaClase()
        {
            Productos producto = new Productos();
            producto.ProductoId = (int)(IdnumericUpDown.Value);
            producto.Descripcion = DescripciontextBox.Text;
            producto.Costo = Convert.ToDecimal(CostotextBox.Text);
            producto.Existencia = Convert.ToInt32(ExistenciatextBox.Text);
            producto.ValorInventario = Convert.ToDecimal(ValorInventariotextBox.Text);
            

            return producto;

        }

        private void LlenaCampo(Productos producto)
        {
            IdnumericUpDown.Value = producto.ProductoId;
            DescripciontextBox.Text = producto.Descripcion;
            CostotextBox.Text = Convert.ToString(producto.Costo);
            ExistenciatextBox.Text = Convert.ToString(producto.Existencia);

            UbicacioncomboBox.SelectedValue = producto.IdUbicacion;
          //  LlenarComboBox();

        }


       
        private bool ValidarEliminar()
        {
            bool paso = true;
            MyerrorProvider.Clear();

            if(IdnumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(IdnumericUpDown, "Debes de introducir un ID");
                IdnumericUpDown.Focus();
                paso = false;
            }
            return paso;
        }
        private bool Validar()
        {
            bool paso = true;
            MyerrorProvider.Clear();


            if (DescripciontextBox.Text == string.Empty)
            {
                MyerrorProvider.SetError(DescripciontextBox, " Debes poner una descripcion");
                DescripciontextBox.Focus();
                paso = false;
            }

            if (ExistenciatextBox.Text == "0")
            {
                MyerrorProvider.SetError(ExistenciatextBox, "Existencia no puede ser 0");
                ExistenciatextBox.Focus();
                paso = false;
            }

            if (ExistenciatextBox.Text == string.Empty)
            {
                MyerrorProvider.SetError(ExistenciatextBox, "Existencia no puede estar vacia");
                ExistenciatextBox.Focus();
                paso = false;
            }
            if (CostotextBox.Text == "0")
            {
                MyerrorProvider.SetError(CostotextBox, "Costo no puede ser 0");
                CostotextBox.Focus();
                paso = false;
            }

            if (CostotextBox.Text == string.Empty)
            {
                MyerrorProvider.SetError(CostotextBox, "Costo no puede estar vacio");
                CostotextBox.Focus();
                paso = false;
            }
            return paso;
        }
        private void ExistenciatextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           // soloNumeros(e);
           // Solo acepta numero del 1-9 y Backspace.
            const int BACKSPACE = 8;
            const int ZERO = 48;
            const int NINE = 57;

            int keyvalue = e.KeyChar;

            if ((keyvalue == BACKSPACE) ||
            ((keyvalue >= ZERO) && (keyvalue <= NINE))) return;
            // Allow nothing else
            e.Handled = true;


        }


        private void ExistenciatextBox_TextChanged(object sender, EventArgs e)
        {
            ValorInventario();
        }


        private void CostotextBox_TextChanged(object sender, EventArgs e)
        {
            ValorInventario();
        }
        private void CostotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
            if (e.KeyChar == '.')
            {
                // No deja poner un punto primero
                if (CostotextBox.TextLength < 1)
                    e.Handled = true;

                //Para que no deje poner mas de 1 Punto
                if (e.KeyChar == '.' && CostotextBox.Text.IndexOf('.') > -1)
                    e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }

        }
        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Productos producto = new Productos();
            int.TryParse(IdnumericUpDown.Text, out id);

            Limpiar();

            producto = ProductosBLL.Buscar(id);

            if (producto != null)
            {
                MessageBox.Show("Producto Encontrado");
                LlenaCampo(producto);
            }
            else
            {
                MessageBox.Show("Producto no encontrado");
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Productos producto;
            bool paso = false;

            if (!Validar())
                return;


            producto = LlenaClase();


            //determinar si es guardar o modificar
            if (IdnumericUpDown.Value == 0)
            {
                paso = ProductosBLL.Guardar(producto);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se peude modificar un Producto que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = ProductosBLL.Modificar(producto);
            }
            Limpiar();
            //informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {

            
            int id;
            int.TryParse(IdnumericUpDown.Text, out id);

            if (!ValidarEliminar())
            return;

            if(ProductosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se peude Eliminar un Producto que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

        }
        //que las Ubicaciones no se repitan
        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            rUbicacion ver = new rUbicacion();
            ver.ShowDialog();
        }

        private void RProductos_Load(object sender, EventArgs e)
        {
  
        }

        private void UbicacioncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}