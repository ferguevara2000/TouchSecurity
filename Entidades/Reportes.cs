using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Reportes
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public Reportes()
        {

        }

        public Reportes(int id, int idEmpresa, string descripcion, DateTime fecha)
        {
            Id = id;
            IdEmpresa = idEmpresa;
            Descripcion = descripcion;
            Fecha = fecha;
        }
    }
}
