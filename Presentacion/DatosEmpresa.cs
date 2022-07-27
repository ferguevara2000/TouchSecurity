using Newtonsoft.Json;
using Presentacion.Models;
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

namespace Presentacion
{
    public partial class DatosEmpresa : Form
    {
        string URL = "http://proyectodistribuidas.somee.com/api/";
        public DatosEmpresa()
        {
            InitializeComponent();
        }

        public void LoadData(int id)
        {
            string objJson = (new WebClient()).DownloadString(URL + "Empresas/" + id);
            var objEmpresa = JsonConvert.DeserializeObject<Empresa>(objJson);

            string objJsonCiudad = (new WebClient()).DownloadString(URL + "Ciudades/" + objEmpresa.Ciudad_Per);
            var ciudad = JsonConvert.DeserializeObject<string>(objJsonCiudad);

            labelId.Text = objEmpresa.Id.ToString();
            labelRuc.Text = objEmpresa.Ruc.ToString();
            labelNombre.Text = objEmpresa.Empresa_Nom.ToString();
            labelDireccion.Text = objEmpresa.Direccion.ToString();
            labelTelefono.Text = objEmpresa.Telefeno.ToString();
            labelContraseña.Text = objEmpresa.Contrasenia.ToString();
            labelLatitud.Text = objEmpresa.Latitud.ToString();
            labelLongitud.Text = objEmpresa.Longitud.ToString();
            labelCiudad.Text = ciudad;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
              Clipboard.SetDataObject(labelContraseña.Text);

        }
    }
}
