using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Presentacion.Models;

namespace Presentacion.Reportes
{
    public partial class ReporteEmpresas : Form
    {
        public ReporteEmpresas()
        {
            InitializeComponent();
        }

        private void ReporteEmpresas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'touchSecurityDataSet.ListaEmpresas' Puede moverla o quitarla según sea necesario.
            this.listaEmpresasTableAdapter.Fill(this.touchSecurityDataSet.ListaEmpresas);
            this.reportViewer1.RefreshReport();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
