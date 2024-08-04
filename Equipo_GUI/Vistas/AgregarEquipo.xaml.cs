using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Equipo_GUI.Vistas
{
    public partial class AgregarEquipo : Window
    {
        private static Regex s_regex = new Regex("[^0-9]+");
        private Equipo_Negocio.Equipo equipo;

        // Definimos el evento para notificar al MainWindow  
        public event Action<Equipo_Negocio.Equipo> EquipoAdded;

        public AgregarEquipo()
        {
            InitializeComponent();
            equipo = new Equipo_Negocio.Equipo();
            this.DataContext = equipo; // bindings  
            CargarTipoEquipo(); // Llama al método para cargar los tipos de equipo  
        }

        private void btnAgregarEquipo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Asignar los valores a las propiedades del objeto  
                equipo.NombreEquipo = txtNombre.Text;
                equipo.CantidadJugadores = int.TryParse(txtCantidad.Text, out int cantidad) ? cantidad : 0;
                equipo.NombreDT = txtNomDT.Text;
                equipo.TipoEquipo = cmbTipoEquipo.Text;
                equipo.CapitanEquipo = txtNomCapitan.Text;
                equipo.TieneSub21 = chkTieneSub21.IsChecked ?? false;

                bool response = equipo.Create();

                if (response)
                {
                    MessageBox.Show("El equipo fue agregado correctamente");
                    // Invocar el evento para notificar a MainWindow  
                    EquipoAdded?.Invoke(equipo);
                    AgregarOtroEquipo();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error. Intentelo más tarde");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void CheckTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = s_regex.IsMatch(e.Text);
        }

        private void AgregarOtroEquipo()
        {
            string title = "Agregar nuevo Equipo";
            string message = "¿Desea agregar otro equipo?";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message, title, buttons);

            if (result == MessageBoxResult.No)
            {
                this.Close();
            }
        }
        private void CargarTipoEquipo()
        {
            // cmbTipoEquipo debe estar vacío antes de asignar ItemsSource  
            cmbTipoEquipo.Items.Clear(); 
            var tiposEquipo = new List<string> { "Masculino", "Femenino" }; // Reemplaza con tus datos  
            cmbTipoEquipo.ItemsSource = tiposEquipo;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtNomDT.Text = string.Empty;
            cmbTipoEquipo.SelectedIndex = -1; // Limpia la selección del ComboBox  
            txtNomCapitan.Text = string.Empty;
            chkTieneSub21.IsChecked = false;
        }
        public class NombreEquipoValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                string nombre = value as string;

                if (string.IsNullOrEmpty(nombre))
                {
                    return new ValidationResult(false, "El campo NombreEquipo no puede estar vacío.");
                }

                if (nombre.Length < 8)
                {
                    return new ValidationResult(false, "El campo NombreEquipo debe tener al menos 8 caracteres.");
                }

                if (nombre.Length > 25)
                {
                    return new ValidationResult(false, "El campo NombreEquipo no puede tener más de 25 caracteres.");
                }

                return ValidationResult.ValidResult;
            }
        }

        public class CantidadJugadoresValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                int cantidadJugadores;

                if (int.TryParse(value as string, out cantidadJugadores))
                {
                    if (cantidadJugadores < 16)
                    {
                        return new ValidationResult(false, "La cantidad de jugadores debe ser al menos 16.");
                    }

                    if (cantidadJugadores > 25)
                    {
                        return new ValidationResult(false, "La cantidad de jugadores no puede ser mayor de 25.");
                    }

                    // Validation passed
                    return ValidationResult.ValidResult;
                }

                return new ValidationResult(false, "La cantidad de jugadores debe ser un número válido.");
            }
        }

        public class NombreDTValidationRule : ValidationRule
        {
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
                string nombreDT = value as string;

                if (string.IsNullOrEmpty(nombreDT))
                {
                    return new ValidationResult(false, "El campo NombreDT no puede estar vacío.");
                }

                if (nombreDT.Length < 5)
                {
                    return new ValidationResult(false, "El campo NombreDT debe tener al menos 5 caracteres.");
                }

                if (nombreDT.Length > 30)
                {
                    return new ValidationResult(false, "El campo NombreDT no puede tener más de 30 caracteres.");
                }

                return ValidationResult.ValidResult;
            }
        }

        private void cmbTipoEquipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = cmbTipoEquipo.SelectedItem as ComboBoxItem;

            if (selectedItem != null && selectedItem.Content.ToString() == "Seleccionar")
            {
                // El valor seleccionado es inválido
                // Realiza las acciones necesarias, como mostrar un mensaje de error
            }
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}