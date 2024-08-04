using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Equipo_GUI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Equipo_Negocio.EquipoCollection equipoCollection;
        private Equipo_Negocio.EquipoReportes equipoReportes;

        public MainWindow()
        {
            InitializeComponent();
            equipoCollection = new Equipo_Negocio.EquipoCollection();
            equipoReportes = new Equipo_Negocio.EquipoReportes();
            CargarGrilla(); // Cargar la grilla al inicio
        }

        private void optAgregarEquipo_Click(object sender, RoutedEventArgs e)
        {
            Vistas.AgregarEquipo agregarEquipo = new Vistas.AgregarEquipo();
            agregarEquipo.ShowDialog();
        }

        private void optListarEquipos_Click(object sender, RoutedEventArgs e)
        {
            Vistas.ListarEquipo listarEquipos = new Vistas.ListarEquipo();
            CargarGrilla();
            listarEquipos.ShowDialog();
        }

        private void optReportes_Click(object sender, RoutedEventArgs e)
        {
            int equiposDisponibles = equipoReportes.ReporteEquiposDisponibles();
            int equiposNoDisponibles = equipoReportes.ReporteEquiposNoDisponibles();
            string message = string.Format(
                "Equipos disponibles: {0} \n " +
                "Equipos no disponibles: {1}",
                equiposDisponibles,
                equiposNoDisponibles
            );
            MessageBox.Show(message);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgListadoEquipos.ItemsSource = equipoCollection.ReadAll();
        }

        private void dgListadoEquipos_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "Error" || e.Column.Header.ToString() == "ErrorCollection")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
    }
}
 
