using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea4
{
    class Principal
    {
        private List<Registro> registros = new List<Registro>();
        public Principal() {
            cargarArchivo();
        }

        public void cargarArchivo()
        {
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
                    string[] values = line.Split(',');
                    Registro r = new Registro(values[0], values[1], values[2], values[3], values[4]);
                    registros.Add(r);
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                //Console.ReadLine();
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

        public List<Registro> getAllRegistros(){
            return registros;
        }

        public List<Registro> filtrarPorDepartamento(char letra)
        {
            List<Registro> listaFiltrada = null;

            for(int i = 0; i < registros.Count(); i++)
            {
                if (registros.ElementAt(i).Departamento.StartsWith(letra))
                {
                    listaFiltrada.Add(registros.ElementAt(i));
                }
            }

            return listaFiltrada;
        }
    }
}
