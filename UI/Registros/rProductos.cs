﻿using ProyectoParcial.BLL;
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
    public partial class rProductos : Form
    {
        public rProductos()
        {
            InitializeComponent();
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
            MyerrorProvider.Clear();

        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Productos producto = ProductosBLL.Buscar((int)IdnumericUpDown.Value);
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

        }

        private bool Validar()
        {
            bool paso = true;
            MyerrorProvider.Clear();

            if(DescripciontextBox.Text == string.Empty)
            {
                MyerrorProvider.SetError(DescripciontextBox, " Debes poner una descripcion");
                DescripciontextBox.Focus();
                paso = false;
            }

            if(ExistenciatextBox.Text == "0")
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
          soloNumeros(e);
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
            MyerrorProvider.Clear();
            int id;
            int.TryParse(IdnumericUpDown.Text, out id);

            Limpiar();
            if (!ExisteEnLaBaseDeDatos())
            {
                MessageBox.Show("No se peude Eliminar un Producto que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ProductosBLL.Eliminar(id);
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
