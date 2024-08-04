using System;
using System.Windows;
using System.Windows.Controls;

namespace Equipo_GUI.Vistas
{
    public partial class ListarEquipo : Window
    {
        private Equipo_Negocio.EquipoCollection equipoCollection;

        public ListarEquipo()
        {
            InitializeComponent();
            CargarGrilla();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            var agregarEquipo = new AgregarEquipo();
            agregarEquipo.EquipoAdded += OnEquipoAdded;
            agregarEquipo.ShowDialog();
        }

        private void OnEquipoAdded(Equipo_Negocio.Equipo nuevoEquipo)
        {
            // Refrescar la grilla después de agregar un equipo
            CargarGrilla();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            var filaSeleccionada = (Equipo_Negocio.Equipo)dgListadoEquipos.SelectedItem;
            if (filaSeleccionada != null)
            {
                ActualizarEquipo actualizarEquipo = new ActualizarEquipo(filaSeleccionada.EquipoId);
                actualizarEquipo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un equipo para actualizar.");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            EliminarRegistroSeleccionado();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            // Limpia el ItemsSource antes de asignar nuevos datos
            dgListadoEquipos.ItemsSource = null;
            equipoCollection = new Equipo_Negocio.EquipoCollection();
            dgListadoEquipos.ItemsSource = equipoCollection.ReadAll();
        }

        private void EliminarRegistroSeleccionado()
        {
            var filaSeleccionada = (Equipo_Negocio.Equipo)dgListadoEquipos.SelectedItem;
            if (filaSeleccionada != null)
            {
                int equipoId = filaSeleccionada.EquipoId;
                string title = "Eliminar equipo";
                string message = string.Format("¿Estás seguro de eliminar el equipo con ID {0}?", equipoId);

                MessageBoxButton buttons = MessageBoxButton.YesNo;
                MessageBoxResult result = MessageBox.Show(message, title, buttons);

                if (result == MessageBoxResult.Yes)
                {
                    bool eliminado = filaSeleccionada.Delete(equipoId);
                    if (eliminado)
                    {
                        MessageBox.Show(string.Format("Equipo {0} eliminado", equipoId));
                        CargarGrilla(); // Recargar la grilla después de eliminar
                    }
                    else
                    {
                        MessageBox.Show("El equipo no pudo ser eliminado");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un equipo para eliminar.");
            }
        }
    }
}
