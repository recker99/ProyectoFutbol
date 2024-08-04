using System;
using System.Windows;
using Equipo_Negocio;

namespace Equipo_GUI.Vistas
{
    /// <summary>
    /// Lógica de interacción para ActualizarEquipo.xaml
    /// </summary>
    public partial class ActualizarEquipo : Window
    {
         Equipo_Negocio.Equipo equipo;

        public ActualizarEquipo(int equipoId)
        {
            InitializeComponent();
            this.Title = string.Format("Actualizar equipo {0}", equipoId);

            equipo = new Equipo_Negocio.Equipo();
            CargarFormulario(equipoId);
        }

        private void btnActualizarEquipo_Click(object sender, RoutedEventArgs e)
        {
            // Actualizar los datos del equipo
            equipo.NombreEquipo = txtNombre.Text;
            equipo.CantidadJugadores = Convert.ToInt32(txtCantidad.Text);
            equipo.NombreDT = txtNomDT.Text;
            equipo.TipoEquipo = cmbTipoEquipo.Text;
            equipo.CapitanEquipo = txtNomCapitan.Text;
            equipo.TieneSub21 = (chkTieneSub21.IsChecked.Value)? true : false;

            // Actualizar el equipo en la base de datos
            bool response = equipo.Update();

            if (response)
            {
                MessageBox.Show(string.Format("Equipo {0} ha sido actualizado exitosamente!", equipo.NombreEquipo));
                this.Close();
            }
            else
            {
                MessageBox.Show(string.Format("No fue posible actualizar el equipo {0}", equipo.EquipoId));
            }
        }

        private void CargarFormulario(int equipoId)
        {
            
            bool response = equipo.Read(equipoId);
            if (response)
            {
                txtNombre.Text = equipo.NombreEquipo;
                txtCantidad.Text = equipo.CantidadJugadores.ToString();
                txtNomDT.Text = equipo.NombreDT;
                cmbTipoEquipo.Text = equipo.TipoEquipo;
                txtNomCapitan.Text = equipo.CapitanEquipo;
                chkTieneSub21.IsChecked = (equipo.TieneSub21) ? true : false;
            }
            else
            {
                MessageBox.Show(string.Format("El equipo con ID {0} no fue encontrado.", equipoId));
                this.Close(); // Cierra la ventana si no se encuentra el equipo
            }
        }
    }
}
