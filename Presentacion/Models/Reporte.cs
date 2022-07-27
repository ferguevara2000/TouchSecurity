using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Models
{
    public class Reporte
    {
        public int Id { get; set; }
        public int Empresa_Per { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public Reporte()
        {

        }

        public Reporte(int id, int empresa_Per, string descripcion, DateTime fecha)
        {
            Id = id;
            Empresa_Per = empresa_Per;
            Descripcion = descripcion;
            Fecha = fecha;
        }
    }
}
