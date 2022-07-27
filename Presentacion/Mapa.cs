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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using Presentacion.Models;

namespace Presentacion
{
    public partial class Mapa : Form
    {
        private string URL = "http://proyectodistribuidas.somee.com/api/";
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        double LatInicial = -1.280407;
        double LngInicial = -78.636754;

        public Mapa()
        {
            InitializeComponent();
        }

        private void Mapa_Load(object sender, EventArgs e)
        {
            string objJson = (new WebClient()).DownloadString(URL + "Empresas");
            List<Empresa> ubicaciones = JsonConvert.DeserializeObject<List<Empresa>>(objJson);
            dataGridView1.DataSource = ubicaciones;
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Latitud"].Visible = false;
            dataGridView1.Columns["Longitud"].Visible = false;
            dataGridView1.Columns["Ciudad_Per"].Visible = false;
            dataGridView1.Columns["Ruc"].Visible = false;
            dataGridView1.Columns["Contrasenia"].Visible = false;
            dataGridView1.Columns["Direccion"].Visible = false;
            dataGridView1.Columns["Telefeno"].Visible = false;
            dataGridView1.Columns["NombreCiudad"].Visible = false;

            //Creando las dimensiones del GMAPCONTROL(herramienta)
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 14;
            gMapControl1.AutoScroll = true;

            List<GMarkerGoogle> listaMarcadores = new List<GMarkerGoogle>();

            markerOverlay = new GMapOverlay("Marcador");

            foreach (var item in ubicaciones)
            {
                double lat, lon;
                lat = item.Latitud;
                lon = item.Longitud;
                marker = new GMarkerGoogle(new PointLatLng(lat, lon), GMarkerGoogleType.blue);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = string.Format("Empresa: {0}\n  Direccion: {1}", item.Empresa_Nom, item.Direccion);
                markerOverlay.Markers.Add(marker);
            }
            marker = new GMarkerGoogle(new PointLatLng(-1.280407, -1.280407), GMarkerGoogleType.blue);
            markerOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markerOverlay);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackZoom.Value = Convert.ToInt32(gMapControl1.Zoom);
        }

        private void trackZoom_ValueChanged(object sender, EventArgs e)
        {
            gMapControl1.Zoom = trackZoom.Value;
        }

        private void buttonSatelite_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleChinaSatelliteMap;
        }

        private void buttonNormal_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
        }

        private void buttonRelieve_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleTerrainMap;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaSeleccionada = 0;
            string nombre, direccion;
            double lat, lon;
            filaSeleccionada = e.RowIndex;//Fila Seleccionada

            //se asignan los valores del grid al macador
            lat = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Latitud"].Value.ToString());
            lon = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Longitud"].Value.ToString());
            nombre = dataGridView1.CurrentRow.Cells["Empresa_Nom"].Value.ToString();
            direccion = dataGridView1.CurrentRow.Cells["Direccion"].Value.ToString();
            marker.Position = new PointLatLng(lat, lon);
            //marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            //marker.ToolTipText = string.Format("Empresa: {0}\n  Direccion: {1}", nombre, direccion);
            //se posiciona el foco del mapa en ese punto
            gMapControl1.Position = marker.Position;
        }
    }
}
