using System.Windows;
using Tarea_3.Entidades;
using Tarea_3.BLL;

namespace Tarea_3.UI.Registros
{
    public partial class rCarreras : Window
    {
        public rCarreras()
        {
            InitializeComponent();
            this.DataContext = carreras;
        }

        private Carreras carreras = new Carreras(); 

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.carreras;
        }

        private void Limpiar()
        {
            this.carreras = new Carreras();
            this.DataContext = carreras;
        }

        private bool Validar()
        {
            bool esValido = true;
            if(string.IsNullOrWhiteSpace(carreras.Nombre))
            {
                esValido = false;
                TextBoxNombreCarrera.Focus();
                MessageBox.Show("Introduce Nombre carrera.");
            }

            return esValido;
        }



        private void Click_btnBuscar(object sender, RoutedEventArgs e)
        {

            var encontrado = CarrerasBLL.Buscar(this.carreras.CarreraId);

            if(encontrado != null)
            {
                this.carreras = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("no se encontro la carrera");
            }

        }

        private void Click_btnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        
        private void Click_btnGuardar(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if(!Validar())
                return;
            
            paso = CarrerasBLL.Guardar(carreras);

            if(paso)
                MessageBox.Show("Carrera guardada con exito..");
            else
                MessageBox.Show("No se guardo la carrera");
        }

        private void Click_btnEliminar(object sender, RoutedEventArgs e)
        {

            if(CarrerasBLL.Eliminar(carreras.CarreraId))
            {
                Limpiar();
                MessageBox.Show("Carrera eliminada con exito");
            }
            else
                MessageBox.Show("No se pudo eliminar la carrera..");
            
        }
    }

}

