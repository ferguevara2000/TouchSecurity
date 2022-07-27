using Apis.Models;
using System.Linq;
using System.Web.Http;

namespace Apis.Controllers
{
    public class EmpresasMasReportesController : ApiController
    {
        private VistasDataContext vistas = new VistasDataContext();

        public IQueryable<EmpresasMasReportes> GetEmpresas()
        {
            return vistas.EmpresasMasReportes;
        }
    }
}
