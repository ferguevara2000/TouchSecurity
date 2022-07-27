using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidades;
namespace Negocio
{
    public class EmpresaNegocio
    {
        public static Empresa SaveEmpresaNegocio(Empresa empresa)
        {
            if (empresa.Id == 0)
            {
                return EmpresasDatos.InsertEmpresa(empresa);
            }
            else
            {
                return EmpresasDatos.UpdateEmpresa(empresa);
            }
        }

        public static List<Empresa> GetListEmpresas()
        {
            return EmpresasDatos.getEmpresas();
        }

        public static Empresa GetEmpresaById(int id)
        {
            return EmpresasDatos.GetEmpresaById(id);
        }

        public static bool DeleteEmpresa(int id)
        {
            return EmpresasDatos.DeleteEmpresa(id);
        }
    }
}
