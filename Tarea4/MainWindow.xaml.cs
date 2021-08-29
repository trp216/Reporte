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
        }

        public void mostrarRegistros()
        {
            int i = 1;
            ;
            while (i<principal.getAllRegistros().Count())
            {
                lstNames.Content += principal.getAllRegistros().ElementAt(i).toString() + "\n";
                i++;
            }
        }

        public void cargarArchivo(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog()==true)
            {
                String url = openFileDialog.FileName;
                direccionURL.Text = url;
                principal = new Principal(url);
            }
            else
            {
                principal = new Principal();
            }

            mostrarRegistros();

        }
    }
}
