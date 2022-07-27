using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;
using Presentacion.Models;
using Presentacion.Utils;

namespace Presentacion
{
    public partial class FormularioEmpresa : Form
    {
        Empresa empresa = new Empresa();
        string URL = "http://proyectodistribuidas.somee.com/api/";


        public FormularioEmpresa()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel_barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadInitialData()
        {
            LoadCiudades();
        }

        private void LoadCiudades()
        {
            string objJson = (new WebClient()).DownloadString(URL + "Ciudades");
            comboBox_ciudades.DataSource = JsonConvert.DeserializeObject<JArray>(objJson);
        }

        private void FormularioEmpresa_Load(object sender, EventArgs e)
        {
            LoadInitialData();
        }

        private bool SaveEmpresa()
        {
            bool rucValido;
            bool telefonoValido;
            if (textBox_ruc.TextLength == 0 || textBox_nombre.TextLength == 0 || textBox_telefono.TextLength == 0 ||
                textBox_direccion.TextLength == 0 || textBox_lat.TextLength == 0 || textBox_lon.TextLength == 0)
            {
                label_error.Text = "Ingresar todos los campos";
                return false;
            }
            if (ModelUtils.ValidarRuc(textBox_ruc.Text))
            {
                rucValido = true;
            }
            else
            {
                label_error.Text = "Ingresar un RUC Valido";
                return false;
            }
            if (ModelUtils.ValidarTelefono(textBox_telefono.Text))
            {
                telefonoValido = true;
            }
            else
            {
                label_error.Text = "Ingresar un Telefono Valido";
                return false;
            }
            if (rucValido && telefonoValido)
            {
                empresa.Ruc = textBox_ruc.Text;
                empresa.Empresa_Nom = textBox_nombre.Text;
                empresa.Direccion = textBox_direccion.Text;
                empresa.Ciudad_Per = LoadCiudadByName(comboBox_ciudades.SelectedItem.ToString());
                empresa.Contrasenia = ModelUtils.CreatePassword();
                empresa.Telefeno = textBox_telefono.Text;
                empresa.Latitud = Convert.ToDouble(textBox_lat.Text);
                empresa.Longitud = Convert.ToDouble(textBox_lon.Text);
                empresa.NombreCiudad = comboBox_ciudades.SelectedItem.ToString();

                string objJson = (new WebClient()).DownloadString(URL + "Ciudades?ruc="+empresa.Ruc);
                if (objJson == null)
                {
                    ModelUtils.Send<Empresa>(URL + "empresas", empresa, "POST");
                    return true;
                }
                else
                {
                    label_error.Text = "El RUC ya existe";
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private int LoadCiudadByName(string name)
        {
            string objJson = (new WebClient()).DownloadString(URL + "Ciudades?name=" + name);
            int id = JsonConvert.DeserializeObject<int>(objJson);
            return id;
        }

        public void LoadEmpresaById(int id)
        {
            string objJson = (new WebClient()).DownloadString(URL + "Empresas/" + id);
            var objEmpresa = JsonConvert.DeserializeObject<Empresa>(objJson);

            textBox_ID.Text = objEmpresa.Id.ToString();
            textBox_ruc.Text = objEmpresa.Ruc.ToString();
            textBox_nombre.Text = objEmpresa.Empresa_Nom.ToString();
            textBox_contraseña.Text = objEmpresa.Contrasenia.ToString();
            textBox_direccion.Text = objEmpresa.Direccion.ToString();
            textBox_telefono.Text = objEmpresa.Telefeno.ToString();
            textBox_lat.Text = objEmpresa.Latitud.ToString();
            textBox_lon.Text = objEmpresa.Longitud.ToString();
        }

        private void UpdateEmpresa()
        {
            empresa.Id = Convert.ToInt32(textBox_ID.Text);
            empresa.Ruc = textBox_ruc.Text;
            empresa.Empresa_Nom = textBox_nombre.Text;
            empresa.Direccion = textBox_direccion.Text;
            empresa.Contrasenia = textBox_contraseña.Text;
            empresa.Ciudad_Per = LoadCiudadByName(comboBox_ciudades.SelectedItem.ToString());
            empresa.Telefeno = textBox_telefono.Text;
            empresa.Latitud = Convert.ToDouble(textBox_lat.Text);
            empresa.Longitud = Convert.ToDouble(textBox_lon.Text);
            empresa.NombreCiudad = comboBox_ciudades.SelectedItem.ToString();

            //clientEmpresas.SaveEmpresaNegocio(empresa);

            ModelUtils.Send<Empresa>(URL + "empresas/"+empresa.Id, empresa, "PUT");
        }


        private void SaveOrUpdateEmpresa()
        {
            if (textBox_ID.TextLength == 0)
            {
                if (SaveEmpresa())
                {
                     MessageBox.Show("Datos Guardados Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                UpdateEmpresa();
                MessageBox.Show("Datos Guardados Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveOrUpdateEmpresa();
        }

        private void textBox_ruc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox_lat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 43) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox_lon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 43) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Map map = new Map();
            AddOwnedForm(map);
            map.Show();
        }
    }
}
