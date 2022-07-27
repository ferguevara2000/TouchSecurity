using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciudad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }

        public Ciudad()
        {

        }

        public Ciudad(int id, string nombre, string provincia)
        {
            Id = id;
            Nombre = nombre;
            Provincia = provincia;
        }
    }
}
