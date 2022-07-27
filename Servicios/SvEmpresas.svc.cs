using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Negocio;

namespace Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SvEmpresas" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SvEmpresas.svc o SvEmpresas.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SvEmpresas : ISvEmpresas
    {
        public bool DeleteEmpresa(int id)
        {
            return EmpresaNegocio.DeleteEmpresa(id);
        }

        public Empresa GetEmpresaById(int id)
        {
            return EmpresaNegocio.GetEmpresaById(id);
        }

        public List<Empresa> GetListEmpresas()
        {
            return EmpresaNegocio.GetListEmpresas();
        }

        public Empresa SaveEmpresaNegocio(Empresa empresa)
        {
            return EmpresaNegocio.SaveEmpresaNegocio(empresa);
        }
    }
}
