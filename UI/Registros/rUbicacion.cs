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

namespace ProyectoParcial.UI.Registros
{
    public partial class rUbicacion : Form
    {
        public rUbicacion()
        {
            InitializeComponent();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Ubicaciones ubicacion = UbicacionesBLL.Buscar(Convert.ToInt32(IdnumericUpDown.Value));
            return (ubicacion != null);
        }

        private Ubicaciones LlenaClase()
        {
            Ubicaciones ubicacion = new Ubicaciones();
            ubicacion.IdUbicacion = (int)(IdnumericUpDown.Value);
            ubicacion.Descripcion = DescripciontextBox.Text;

            return ubicacion;

        }

        private void LlenaCampo(Ubicaciones ubicacion)
        {
            IdnumericUpDown.Value = ubicacion.IdUbicacion;
            DescripciontextBox.Text = ubicacion.Descripcion;

        }
        private bool ValidarEliminar()
        {
            bool paso = true;
            MyerrorProvider.Clear();

            if (IdnumericUpDown.Value == 0)
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

            return paso;
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            MyerrorProvider.Clear();

        }
        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Ubicaciones ubicacion = new Ubicaciones();
            int.TryParse(IdnumericUpDown.Text, out id);

            Limpiar();

            ubicacion = UbicacionesBLL.Buscar(id);

            if (ubicacion != null)
            {
                MessageBox.Show("Ubicacion Encontrado");
                LlenaCampo(ubicacion);
            }
            else
            {
                MessageBox.Show("Ubicacion no encontrado");
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(IdnumericUpDown.Text, out id);

            if (!ValidarEliminar())
            return;

            if (ProductosBLL.Eliminar(id))
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

        private void Guardarbutton_Click(object sender, EventArgs e)
        {

            Ubicaciones ubicacion;
            bool paso = false;

            if (!Validar())
                return;


            ubicacion = LlenaClase();


            //determinar si es guardar o modificar
            if (IdnumericUpDown.Value == 0)
            {
                paso = UbicacionesBLL.Guardar(ubicacion);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se peude modificar una Ubicacion que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = UbicacionesBLL.Modificar(ubicacion);
            }
            Limpiar();
            //informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}

