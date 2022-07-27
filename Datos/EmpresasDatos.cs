using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Datos
{
    public static class EmpresasDatos
    {
        public static List<Empresa> getEmpresas()
        {
            try
            {
                List<Empresa> listEmpresas = new List<Empresa>();
                List<Empresas> empresas = new List<Empresas>();

                using (DataClasses1DataContext context = new DataClasses1DataContext())
                {
                    var result = from e in context.Empresas select e;
                    empresas = result.ToList();
                }
                foreach (var item in empresas)
                {
                    listEmpresas.Add(new Empresa(item.Id, item.Ruc, item.Empresa_Nom, item.Direccion, item.Ciudad_Per
                        , item.Contrasenia, item.Telefeno, item.Latitud, item.Longitud, CiudadesDatos.GetCiudadById(item.Ciudad_Per)));
                }
                return listEmpresas;
            }
            catch
            {
                throw;
            }
        }

        public static Empresa GetEmpresaById(int id)
        {
            try
            {
                Empresa empresa = new Empresa();
                Empresas empresas = new Empresas();
                using (var context = new DataClasses1DataContext())
                {
                    empresas = context.Empresas.FirstOrDefault(x => x.Id == id);
                }
                empresa.Id = empresas.Id;
                empresa.Ruc = empresas.Ruc;
                empresa.Nombre = empresas.Empresa_Nom;
                empresa.Direccion = empresas.Direccion;
                empresa.Ciudad = (int)empresas.Ciudad_Per;
                empresa.Contraseña = empresas.Contrasenia;
                empresa.Telefono = empresas.Telefeno;
                empresa.Latitud = (double)empresas.Latitud;
                empresa.Longitud = (double)empresas.Longitud;
                empresa.NombreCiudad = CiudadesDatos.GetCiudadById(empresas.Ciudad_Per);

                return empresa;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static Empresa InsertEmpresa(Empresa empresa)
        {
            try
            {
                Empresas empresas = new Empresas();
                empresas.Id = empresa.Id;
                empresas.Ruc = empresa.Ruc;
                empresas.Empresa_Nom = empresa.Nombre;
                empresas.Direccion = empresa.Direccion;
                empresas.Ciudad_Per = empresa.Ciudad;
                empresas.Contrasenia = Utils.CreatePassword();
                empresas.Telefeno = empresa.Telefono;
                empresas.Latitud = empresa.Latitud;
                empresas.Longitud = empresa.Longitud;
                empresa.NombreCiudad = CiudadesDatos.GetCiudadById(empresas.Ciudad_Per);

                using (DataClasses1DataContext context = new DataClasses1DataContext())
                {
                    context.Empresas.InsertOnSubmit(empresas);
                    context.SubmitChanges();
                }
                empresa.Id = empresas.Id;
                return empresa;
            }
            catch
            {
                throw;
            }
        }

        public static Empresa UpdateEmpresa(Empresa empresa)
        {
            try
            {
                using (DataClasses1DataContext context = new DataClasses1DataContext())
                {
                    Empresas empresas = new Empresas();
                    empresas = context.Empresas.FirstOrDefault(x => x.Id == empresa.Id);
                    //empresas.Id = empresa.Id;
                    empresas.Ruc = empresa.Ruc;
                    empresas.Empresa_Nom = empresa.Nombre;
                    empresas.Direccion = empresa.Direccion;
                    empresas.Ciudad_Per = empresa.Ciudad;
                    empresas.Contrasenia = empresa.Contraseña;
                    empresas.Telefeno = empresa.Telefono;
                    empresas.Latitud = empresa.Latitud;
                    empresas.Longitud = empresa.Longitud;
                    //empresa.NombreCiudad = CiudadesDatos.GetCiudadById(empresas.Ciudad_Per);
                    context.SubmitChanges();
                }

                return empresa;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool DeleteEmpresa(int id)
        {
            try
            {
                Empresas empresa = new Empresas();
                using (DataClasses1DataContext context = new DataClasses1DataContext())
                {
                    empresa = context.Empresas.FirstOrDefault(x => x.Id == id);
                    context.Empresas.DeleteOnSubmit(empresa);
                    context.SubmitChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
