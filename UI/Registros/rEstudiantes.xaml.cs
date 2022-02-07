

using Tarea_3.BLL;
using Tarea_3.Entidades;
using System.Windows;


namespace Tarea_3.UI.Registros
{
    public partial class rEstudiantes : Window
    {

        private Estudiantes estudiante = new Estudiantes();
        public rEstudiantes()
        {
            InitializeComponent();
            this.DataContext = estudiante;
        }


        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.estudiante;
        }

        private void Limpiar()
        {
            this.estudiante = new Estudiantes();
            this.DataContext = estudiante;
        }

        private bool Validar()
        {
            bool esValido = true;

            if(string.IsNullOrWhiteSpace(estudiante.Nombres))
            {
                esValido = false;
                TextBoxNombreEstudiante.Focus();
                MessageBox.Show("Indica el nombre");
            }
            else if(string.IsNullOrWhiteSpace(estudiante.Email))
            {
                esValido = false;
                textBoxEmailEstudiante.Focus();
                MessageBox.Show("Indica el email");
            }

            return esValido;
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
            
            paso = EstudianteBLL.Guardar(estudiante);

            if(paso)
            {
                MessageBox.Show("Estudiante Guardado con exito..");
                Limpiar();
            }
            else
                MessageBox.Show("No se guardo el Estudiante");

        }

        private void Click_btnEliminar(object sender, RoutedEventArgs e)
        {
            if(EstudianteBLL.Eliminar(estudiante.EstudianteId))
            {
                Limpiar();
                MessageBox.Show("Estudiante eliminado con exito");
            }
            else
                MessageBox.Show("No se pudo eliminar el estudiante..");
        }

        private void Click_btnBuscar(object sender, RoutedEventArgs e)
        {
            var encontrado = EstudianteBLL.Buscar(this.estudiante.EstudianteId);

            if(encontrado != null)
            {
                this.estudiante = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No se encontro el estudiante");
            }

        }

    }

}