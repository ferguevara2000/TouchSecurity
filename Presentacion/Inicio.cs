using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion.Models;

namespace Presentacion
{
    public partial class Inicio : Form
    {
        string URL = "http://proyectodistribuidas.somee.com/api/";
        public Inicio()
        {
            InitializeComponent();
        }

        private void timer_horaFecha_Tick(object sender, EventArgs e)
        {
            label_hora.Text = DateTime.Now.ToLongTimeString();
            label_fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            FillData();
            LoadGraphicEmpresas();
            LoadGraphicCiudades();
            LoadLastIncident();
        }

        private void FillData()
        {
            labelEmpresas.Text = Convert.ToString(GetNumeroEmpresas());
            labelIncidentes.Text = Convert.ToString(GetTotalIncidentes());
            labelIncidentesMes.Text = Convert.ToString(GetIncidentesMes());
        }

        private int GetNumeroEmpresas()
        {
            string objJson = (new WebClient()).DownloadString(URL + "NumEmpresas");
            int num = JsonConvert.DeserializeObject<int>(objJson);
            return num;
        }

        private int GetTotalIncidentes()
        {
            string objJson = (new WebClient()).DownloadString(URL + "TotalReportes");
            int num = JsonConvert.DeserializeObject<int>(objJson);
            return num;
        }

        private int GetIncidentesMes()
        {
            string objJson = (new WebClient()).DownloadString(URL + "ReporteUltimoMes");
            int num = JsonConvert.DeserializeObject<int>(objJson);
            return num;
        }

        private void LoadGraphicEmpresas()
        {
            List<string> Empresas = new List<string>();
            List<int> Reportes = new List<int>();

            string objJson = (new WebClient()).DownloadString(URL + "EmpresasMasReportes");
            List<EmpresasMasReportes> empresasMasReportes = JsonConvert.DeserializeObject<List<EmpresasMasReportes>>(objJson);
            foreach (var item in empresasMasReportes)
            {
                Empresas.Add(item.Empresa_Nom);
                Reportes.Add(item.Reportes);
            }
            chartInsidentes.Series[0].Points.DataBindXY(Empresas, Reportes);
        }

        private void LoadGraphicCiudades()
        {
            List<string> Ciudades = new List<string>();
            List<int> Reportes = new List<int>();
            string objJson = (new WebClient()).DownloadString(URL + "ReportePorCiudad");
            List<EmpresasMasReportes> empresasMasReportes = JsonConvert.DeserializeObject<List<EmpresasMasReportes>>(objJson);
            foreach (var item in empresasMasReportes)
            {
                Ciudades.Add(item.Empresa_Nom);
                Reportes.Add(item.Reportes);
            }
            chartCiudades.Series[0].Points.DataBindXY(Ciudades, Reportes);
        }

        private void LoadLastIncident()
        {
            string objJson = (new WebClient()).DownloadString(URL + "UltimoReporte");
            var objReportes = JsonConvert.DeserializeObject<Reporte>(objJson);

            string objJson1 = (new WebClient()).DownloadString(URL + "Empresas/" + objReportes.Empresa_Per);
            var objEmpresas = JsonConvert.DeserializeObject<Empresa>(objJson1);

            string objJson2 = (new WebClient()).DownloadString(URL + "Ciudades/" + objEmpresas.Ciudad_Per);
            var ciudad = JsonConvert.DeserializeObject<string>(objJson2);

            labelEmpresa.Text = objEmpresas.Empresa_Nom;
            label1Ciudad.Text = ciudad;
            labelFecha.Text = objReportes.Fecha.ToString();
            labelDescripcion.Text = objReportes.Descripcion.ToString();

        }
    }
}
