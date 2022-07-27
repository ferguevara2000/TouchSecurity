using Apis.Models;
using System.Linq;
using System.Web.Http;

namespace Apis.Controllers
{
    public class NumEmpresasController : ApiController
    {
        public int GetNumberEmpresas()
        {
            int num = 0;
            using (var context = new VistasDataContext())
            {
                var result = context.NumeroEmpresas.ToList();
                foreach (var item in result)
                {
                    num = (int)item.NUMERO_EMPRESAS;
                }
            }
            return num;
        }
    }
}
