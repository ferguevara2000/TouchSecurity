using Apis.Models;
using System.Linq;
using System.Web.Http;

namespace Apis.Controllers
{
    public class TotalReportesController : ApiController
    {
        public int GetReportes()
        {
            int num = 0;
            using (var context = new VistasDataContext())
            {
                var result = context.TotalReportes.ToList();
                foreach (var item in result)
                {
                    num = (int)item.TOTAL;
                }
            }
            return num;
        }
    }
}
