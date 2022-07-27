using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Negocio;

namespace Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SvCiudades" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SvCiudades.svc o SvCiudades.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SvCiudades : ISvCiudades
    {
        public string GetCiudadById(int id)
        {
            return CiudadesNegocio.GetCiudadById(id);
        }

        public int GetCiudadByName(string name)
        {
            return CiudadesNegocio.GetCiudadByName(name);
        }

        public List<string> GetCiudades()
        {
            return CiudadesNegocio.GetCiudades();
        }
    }
}
