using System;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using Presentacion.Utils;
using Presentacion.Models;
using Presentacion.Reportes;

namespace Presentacion
{
    public partial class CRUDEmpresas : Form
    {
        Models.Empresa empresa = new Models.Empresa();
        private string URL = "http://proyectodistribuidas.somee.com/api/";
        DataTable lista;

        public CRUDEmpresas()
        {
            InitializeComponent();
        }

        private void button_nuevo_Click(object sender, EventArgs e)
        {
            FormularioEmpresa formularioEmpresa = new FormularioEmpresa();
            formularioEmpresa.FormClosed += new FormClosedEventHandler(form2_FormClosed);
            formularioEmpresa.Show();
        }

        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {    
            LoadEmpresas();
        }

            private void button_editar_Click(object sender, EventArgs e)
        {
            FormularioEmpresa formularioEmpresa = new FormularioEmpresa();
            formularioEmpresa.FormClosed += new FormClosedEventHandler(form2_FormClosed);
            var id = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            formularioEmpresa.LoadEmpresaById(Convert.ToInt32(id));
            formularioEmpresa.Show();
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de eliminar el Registro?", "Eliminado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var eliminado = DeleteEmpresa();

                if (eliminado != null)
                {
                    MessageBox.Show("Registro Eliminado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmpresas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Registro", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CRUDEmpresas_Load(object sender, EventArgs e)
        {
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            LoadEmpresas();
        }

        public void LoadEmpresas()
        {
            string objJson = (new WebClient()).DownloadString(URL + "Empresas");
            dataGridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(objJson);
            lista = (DataTable)dataGridView1.DataSource;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["$id"].Visible = false;
        }

        private string DeleteEmpresa()
        {
            var id = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            var result = ModelUtils.Send<Models.Empresa>(URL + "Empresas/" + id, empresa, "DELETE");
            return result;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DatosEmpresa datosEmpresa = new DatosEmpresa();
            var id = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            datosEmpresa.LoadData(Convert.ToInt32(id));
            datosEmpresa.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lista.DefaultView.RowFilter = $"Empresa_Nom LIKE '{textBox1.Text}%'";
        }

        private void GenerarReporte()
        {

            ReporteEmpresas reporteEmpresas = new ReporteEmpresas();
            reporteEmpresas.ShowDialog();
        }

        private void buttonReporte_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }
    }

}
