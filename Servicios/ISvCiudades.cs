using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Entidades;

namespace Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISvCiudades" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISvCiudades
    {
        [OperationContract]
        List<string> GetCiudades();

        [OperationContract]
        string GetCiudadById(int id);

        [OperationContract]
        int GetCiudadByName(string name);
    }
}
