using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea4
{
    class Registro
    {
        private string codigodep, codigomun, departamento, municipio, tipo;

        public Registro(string codigodep, string codigomun, string departamento, string municipio, string tipo)
        {
            this.codigodep = codigodep;
            this.codigomun = codigomun;
            this.departamento = departamento;
            this.municipio = municipio;
            this.tipo = tipo;
        }

        public String Codigodep
        {
            get
            {
                return codigodep;
            }
            set
            {
                codigodep = value;
            }
        }


        public String Codigomun
        {
            get
            {
                return codigomun;
            }
            set
            {
                codigomun = value;
            }
        }

        public String Municipio
        {
            get
            {
                return municipio;
            }
            set
            {
                municipio = value;
            }
        }

        public String Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }

        public String Departamento
        {
            get
            {
                return departamento;
            }
            set
            {
                departamento = value;
            }
        }

        public String toString()
        {
            return codigodep + " " + codigomun + " " + departamento + " " + municipio + " " + tipo;
        }

    }
}
