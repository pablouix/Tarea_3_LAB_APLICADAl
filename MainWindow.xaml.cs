using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tarea_3.UI.Consultas;
using Tarea_3.UI.Registros;

namespace Tarea_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public void Click_MenuRegistroEstudiantes(object sender, RoutedEventArgs e)
        {
            rEstudiantes rEstudiante = new rEstudiantes();
            rEstudiante.Show();
            
        }

        public void Click_MenuRegistroCarreras(object sender, RoutedEventArgs e)
        {
            rCarreras rCarreras = new rCarreras();
            rCarreras.Show();
        }

        public void Click_MenuConsultaEstudiantes(object sender, RoutedEventArgs e)
        {
            cEstudiantes cEstudiante = new cEstudiantes();
            cEstudiante.Show();
        }

        public void Click_MenuConsultaCarreras(object sender, RoutedEventArgs e)
        {
            cCarreras cCarreras = new cCarreras();
            cCarreras.Show();
        }



    }
}
