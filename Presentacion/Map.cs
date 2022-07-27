using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Map : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;

        double LatInicial = -1.278071;
        double LngInicial = -78.6565095;
        public Map()
        {
            InitializeComponent();
        }

        private void Map_Load(object sender, EventArgs e)
        {
            //Creando las dimensiones del GMAPCONTROL(herramienta)
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 12;
            gMapControl1.AutoScroll = true;

            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.blue);
            markerOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markerOverlay);
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //se obtiene los datos de lat y lng del mapa donde usuario presiono
            double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

            //se posicionan en el txt de la latitud y longitud
            textBox1.Text = lat.ToString();
            textBox2.Text = lng.ToString();

            //crearemos el marcador para moverlo al lugar indicado por el usuario
            
            marker.Position = new PointLatLng(lat, lng);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormularioEmpresa formularioEmpresa = Owner as FormularioEmpresa;
            formularioEmpresa.textBox_lat.Text = textBox1.Text;
            formularioEmpresa.textBox_lon.Text = textBox2.Text;
            this.Close();
        }
    }
}
