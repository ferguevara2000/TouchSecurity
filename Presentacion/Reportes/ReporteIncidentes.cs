using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Reportes
{
    public partial class ReporteIncidentes : Form
    {
        public ReporteIncidentes()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReporteIncidentes_Load(object sender, EventArgs e)
        {
            this.vistaReportesTableAdapter.Fill(this.touchSecurityDataSet.VistaReportes);

            this.reportViewer1.RefreshReport();
        }
    }
}
