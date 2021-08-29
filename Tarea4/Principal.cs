﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

        public List<Registro> filtrarPorDepartamento(String letra)
        {

           // Trace.WriteLine("Confirmo que me llego una: " + letra);

            char l = char.Parse(letra);
           
            List<Registro> listaFiltrada = new List<Registro>();

            Trace.WriteLine("registros.Count = " + registros.Count);
            for(int i = 0; i < registros.Count; i++)
            {
               // Trace.WriteLine("i = " + i);

                char c = registros.ElementAt(i).Departamento[0];
               // Trace.WriteLine("Primera letra del actual dpto: " + c);

                if (l.Equals(c))
                {
                    listaFiltrada.Add(registros.ElementAt(i));
                   // Trace.WriteLine(registros.ElementAt(i).Departamento);
                }
            }

            return listaFiltrada;
        }
    }
}
