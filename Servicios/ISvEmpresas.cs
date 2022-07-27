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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISvEmpresas" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISvEmpresas
    {
        [OperationContract]
        Empresa SaveEmpresaNegocio(Empresa empresa);

        [OperationContract]
        List<Empresa> GetListEmpresas();

        [OperationContract]
        bool DeleteEmpresa(int id);

        [OperationContract]
        Empresa GetEmpresaById(int id);

    }
}
