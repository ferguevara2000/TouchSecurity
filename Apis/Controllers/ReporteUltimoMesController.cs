using Apis.Models;
using System.Linq;
using System.Web.Http;

namespace Apis.Controllers
{
    public class ReporteUltimoMesController : ApiController
    {
        public int GetReporte()
        {
            int num = 0;
            using (var context = new VistasDataContext())
            {
                var result = context.ReportesUltimoMes.ToList();
                foreach (var item in result)
                {
                    num = (int)item.REPORTES;
                }
            }
            return num;
        }
    }
}
