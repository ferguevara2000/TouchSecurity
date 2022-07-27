using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocio
{
    public static class CiudadesNegocio
    {
        public static List<string> GetCiudades()
        {
            return CiudadesDatos.GetCiudades();
        }

        public static string GetCiudadById(int id)
        {
            return CiudadesDatos.GetCiudadById(id);
        }

        public static int GetCiudadByName(string name)
        {
            return CiudadesDatos.GetCiudadByName(name);
        }
    }
}
