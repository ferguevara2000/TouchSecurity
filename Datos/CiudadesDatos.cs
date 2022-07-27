using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Datos
{
    public static class CiudadesDatos
    {
        public static List<string> GetCiudades()
        {
            try
            {
                List<string> listCiudades = new List<string>();
                List<Ciudades> listLinq = new List<Ciudades>();

                using (DataClasses1DataContext context = new DataClasses1DataContext())
                {
                    var result = from ciudad in context.Ciudades select ciudad;
                    listLinq = result.ToList();
                }
                foreach (var item in listLinq)
                {
                    listCiudades.Add(item.Ciudad);
                }
                return listCiudades;
            }catch(Exception e)
            {
                throw;
            }
        }

        public static string GetCiudadById(int? id)
        {
            try
            {
                Ciudades ciudades = new Ciudades();
                using (DataClasses1DataContext context = new DataClasses1DataContext())
                {
                    var result = context.Ciudades.FirstOrDefault(g => g.Id == id);
                    ciudades = result;
                }
                return ciudades.Ciudad;
            }catch(Exception)
            {
                throw;
            }
        }

        public static int GetCiudadByName(string name)
        {
            try
            {
                Ciudades ciudades = new Ciudades();
                using (DataClasses1DataContext context = new DataClasses1DataContext())
                {
                    var result = context.Ciudades.FirstOrDefault(g => g.Ciudad == name);
                    ciudades = result;
                }
                return ciudades.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
