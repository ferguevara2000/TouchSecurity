using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using Presentacion.Models;
using Presentacion.Reportes;

namespace Presentacion
{
    public partial class ReportesForm : Form
    {
        private string URL = "http://proyectodistribuidas.somee.com/api/";
        public ReportesForm()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            LoadData();
        }

        private void LoadData()
        {
            string objJson = (new WebClient()).DownloadString(URL + "Reportes");
            dataGridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(objJson);

            dataGridView1.Columns["$id"].Visible = false;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DatosReporte datosReporte = new DatosReporte();
            var id = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            datosReporte.LoadReporte(Convert.ToInt32(id));
            datosReporte.Show();
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string Inicio = dateTimePicker1.Text;
            string Fin = dateTimePicker2.Text;
            string objJson = (new WebClient()).DownloadString($"{URL}Reportes?FechaIni={Inicio}&FechaFin={Fin}");
            dataGridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(objJson);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonReporte_Click(object sender, EventArgs e)
        {
            ReporteIncidentes reporteIncidentes = new ReporteIncidentes();
            reporteIncidentes.ShowDialog();
        }
    }
}
