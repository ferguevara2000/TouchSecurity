using Apis.Models;
using System.Linq;
using System.Web.Http;

namespace Apis.Controllers
{
    public class ReportePorCiudadController : ApiController
    {
        private VistasDataContext vistas = new VistasDataContext();

        public IQueryable<ReportesPorCiudad> GetReporte()
        {
            return vistas.ReportesPorCiudad;
        }
    }
}
