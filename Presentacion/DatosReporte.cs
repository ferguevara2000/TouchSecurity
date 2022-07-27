using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Presentacion.Models;

namespace Presentacion
{
    public partial class DatosReporte : Form
    {
        private string URL = "http://proyectodistribuidas.somee.com/api/";
        public DatosReporte()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadReporte(int id)
        {
            string objJson = (new WebClient()).DownloadString(URL + "Reportes/" + id);
            var objReporte = JsonConvert.DeserializeObject<Reporte>(objJson);

            string objJson1 = (new WebClient()).DownloadString(URL + "Empresas/" + objReporte.Empresa_Per);
            var objEmpresas = JsonConvert.DeserializeObject<Empresa>(objJson1);

            string objJson2 = (new WebClient()).DownloadString(URL + "Ciudades/" + objEmpresas.Ciudad_Per);
            var ciudad = JsonConvert.DeserializeObject<string>(objJson2);

            label7.Text = objReporte.Id.ToString();
            label8.Text = objEmpresas.Empresa_Nom.ToString();
            label9.Text = ciudad;
            label10.Text = objReporte.Fecha.ToString();
            labelId.Text = objReporte.Descripcion.ToString();
        }
    }
}
