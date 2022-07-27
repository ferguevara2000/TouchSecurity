using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Ruc { get; set; }
        public string Empresa_Nom { get; set; }
        public string Direccion { get; set; }
        public int Ciudad_Per { get; set; }
        public string Contrasenia { get; set; }
        public string Telefeno { get; set; }
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
            Empresa_Nom = nombre;
            Direccion = direccion;
            Ciudad_Per = (int)ciudad;
            Contrasenia = contraseña;
            Telefeno = telefono;
            Latitud = (double)latitud;
            Longitud = (double)longitud;
            NombreCiudad = nombreCiudad;
        }
    }
}
