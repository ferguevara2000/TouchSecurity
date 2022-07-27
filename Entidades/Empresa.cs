using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Ruc { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Ciudad { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string NombreCiudad { get; set; }

        public Empresa()
        {

        }

        public Empresa(int id, string ruc, string nombre, string direccion, int? ciudad, string contraseña, string telefono, double? latitud, double? longitud, string nombreCiudad)
        {
            Id = id;
            Ruc = ruc;
            Nombre = nombre;
            Direccion = direccion;
            Ciudad = (int)ciudad;
            Contraseña = contraseña;
            Telefono = telefono;
            Latitud = (double)latitud;
            Longitud = (double)longitud;
            NombreCiudad = nombreCiudad;
        }
    }
}
