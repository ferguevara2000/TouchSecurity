using Apis.Models;
using System.Linq;
using System.Web.Http;

namespace Apis.Controllers
{
    public class ReportesMesController : ApiController
    {
        private VistasDataContext vistas = new VistasDataContext();

        public IQueryable<ReportesPorMes> GetReportes()
        {
            return vistas.ReportesPorMes;
        }
    }
}
