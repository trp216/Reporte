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
using System.IO;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace Tarea4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

   

    public partial class MainWindow : Window
    {
        private Principal principal;
       // private List<Registro> registers = new List<Registro>();

        public MainWindow()
        {
            InitializeComponent();
            cmbFilter.IsEnabled = false;
            btnDeshacerFiltro.IsEnabled = false;
        }


        public void cargarArchivo(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                String url = openFileDialog.FileName;
                direccionURL.Text = url;
                principal = new Principal(url);
            }
            else
            {
                principal = new Principal();
            }

            actualizarTabla();

            cmbFilter.IsEnabled = true;
            
        }

        public void actualizarTabla()
        {
            dataTable.ItemsSource = principal.getAllRegistros();
        }

        public void cmbFilter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBoxItem ci = (ComboBoxItem)cmbFilter.SelectedItem;

            String sel = ci.Content.ToString();

            if (sel!=null && dataTable!=null)
            {
                dataTable.ItemsSource = principal.filtrarPorDepartamento(sel);
            }
            btnDeshacerFiltro.IsEnabled = true;
        }

        public void deshacerFiltro(object sender, RoutedEventArgs e)
        {
            dataTable.ItemsSource = principal.getAllRegistros();
        }
    }
}
