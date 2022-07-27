using Apis.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Apis.Controllers
{
    public class UltimoReporteController : ApiController
    {
        private VistasDataContext vistas = new VistasDataContext();

        public UltimoReporte GetRepote()
        {
            List<UltimoReporte> ultimoReportes = vistas.UltimoReporte.ToList();
            UltimoReporte reporte = new UltimoReporte();
            foreach (var item in ultimoReportes)
            {
                reporte.Id = item.Id;
                reporte.Empresa_Per = item.Empresa_Per;
                reporte.Fecha = item.Fecha;
                reporte.Descripcion = item.Descripcion;
            }
            return reporte;
        }
    }
}
