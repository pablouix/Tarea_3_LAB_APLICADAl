using System;
using System.Collections.Generic;
using System.Windows;
using Tarea_3.BLL;
using Tarea_3.Entidades;

namespace Tarea_3.UI.Consultas
{
    public partial class cEstudiantes : Window
    {
        public cEstudiantes()
        {
            InitializeComponent();
        }

        public void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Estudiantes>();
            
            if(string.IsNullOrWhiteSpace(CriterioTextBox.Text))
            {
              listado = EstudianteBLL.GetList(l => true);
            }   
            else 
            {
                bool esNumero = Int32.TryParse(CriterioTextBox.Text, out int n);

                if(esNumero)
                {
                    listado = EstudianteBLL.GetList(c => c.EstudianteId == Convert.ToInt32(CriterioTextBox.Text));
                }
                else
                {
                    listado = EstudianteBLL.GetList(c => c.Nombres == CriterioTextBox.Text);
                }
            }


            EstudiantesDataGrid.ItemsSource = null;

            EstudiantesDataGrid.ItemsSource = listado;
        }

    }

}