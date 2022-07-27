using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Models
{
    public class EmpresasMasReportes
    {
        public int id { get; set; }
        public string Empresa_Nom { get; set; }
        public int Reportes { get; set; }

        public EmpresasMasReportes()
        {

        }
        public EmpresasMasReportes(int id, string empresa_Nom, int reportes)
        {
            this.id = id;
            Empresa_Nom = empresa_Nom;
            Reportes = reportes;
        }
    }
}
