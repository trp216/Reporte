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
        public readonly String URL = "..\\..\\..\\data\\Codigos_municipios.csv";

        private List<Registro> registros = new List<Registro>();
        public Principal() {
            cargarArchivo();
        }

        public Principal(String url)
        {
            URL = url;
            cargarArchivo();
        }

        public void cargarArchivo()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(URL);
                //Read the first line of text
                sr.ReadLine();

                //Continue to read until you reach end of file
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] values = line.Split(',');
                    
                    if (!String.IsNullOrEmpty(values[1]))
                    {
                        Registro r = new Registro(values[0], values[1], values[2], values[3], values[4]);
                        registros.Add(r);
                    }
                    
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

        public List<Registro> filtrarPorDepartamento(String letra)
        {


            char l = char.Parse(letra);
           
            List<Registro> listaFiltrada = new List<Registro>();

            for(int i = 0; i < registros.Count; i++)
            {

                char c = registros.ElementAt(i).Departamento[0];

                if (l.Equals(c))
                {
                    listaFiltrada.Add(registros.ElementAt(i));
                }
            }

            return listaFiltrada;
        }

        public int[] getMunicipiosPorTipo()
        {
            //Se crea un arreglo para almacenar el numero de municipios por cada tipo. [0] Municipio, [1] Area no municipalizada, [2] (Sin valor), [3] Isla
            int[] municipiosPorTipo = new int[4];

            foreach (Registro item in registros)
            {
                if (item.Tipo.Equals("Municipio"))
                {
                    municipiosPorTipo[0]++;
                }
                else if (item.Tipo.Equals("Área no municipalizada"))
                {
                    municipiosPorTipo[1]++;
                }
                else if (item.Tipo.Equals("Isla"))
                {
                    municipiosPorTipo[3]++;
                }
                else municipiosPorTipo[2]++;
            }

            return municipiosPorTipo;
        }
    }
}
