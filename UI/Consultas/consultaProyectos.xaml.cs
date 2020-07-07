using SegundoPacialAna.BLL;
using SegundoPacialAna.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SegundoPacialAna.UI.Consultas
{
    /// <summary>
    /// Interaction logic for Consulta.xaml
    /// </summary>
    public partial class Consulta : Window
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Proyectos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        int num = 0;
                        listado = ProyectosBLL.GetList(e => e.ProyectoId == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                  
                }
            }
            else
            {
                listado = ProyectosBLL.GetList(c => true);
            }

           

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
    
}
