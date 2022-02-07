
using System.Collections.Generic;
using System.Windows;
using Tarea_3.Entidades;
using Tarea_3.BLL;
using System;

namespace Tarea_3.UI.Consultas
{
    public partial class cCarreras : Window
    {
        public cCarreras()
        {
            InitializeComponent();
        }
        public void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Carreras>();
            if(string.IsNullOrWhiteSpace(CriterioTextBox.Text))
                listado = CarrerasBLL.GetList(l => true);
            else 
            {
                bool esNumero = Int32.TryParse(CriterioTextBox.Text, out int n);

                if(esNumero)
                {
                    listado = CarrerasBLL.GetList(c => c.CarreraId == Convert.ToInt32(CriterioTextBox.Text));
                }
                else
                {
                    listado = CarrerasBLL.GetList(c => c.Nombre == CriterioTextBox.Text);
                }
            }   
            CarrerasDataGrid.ItemsSource = null;
            CarrerasDataGrid.ItemsSource = listado;
        }

    }

}