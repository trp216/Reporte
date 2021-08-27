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

namespace Tarea4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

   

    public partial class MainWindow : Window
    {
        private List<Registro> registers = new List<Registro>();

        public MainWindow()
        {
            InitializeComponent();

            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\aleja\\Desktop\\ICESI\\SEMESTRE_7\\PROYECTO_INTEGRADOR_I\\ProyectosVS\\Test\\Codigos_municipios.csv");
                //Read the first line of text

                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    var values = line.Split(',');
                    Registro r = new Registro(values[0], values[1], values[2], values[3], values[4]);
                    registers.Add(r);
                    //lstNames.Content += r.toString() + "\n";
                    //write the lie to console window
                    //lstNames.Content += line + "\n";
                    //Read the next line
                    line = sr.ReadLine();
                }


                int i = 1;
                while (registers.ElementAt(i) != null)
                {
                    lstNames.Content += registers.ElementAt(i).toString() + "\n";
                    i++;
                }


                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
