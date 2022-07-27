using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Presentacion.Utils
{
    public static class ModelUtils
    {
        public static string Send<T>(string url, T objectRequest, string method)
        {
            string result = "";
            try
            {
                string oReply = "";

                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);

                //peticion
                WebRequest request = WebRequest.Create(url);
                //headers
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                request.Timeout = 10000; //esto es opcional

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {

                result = e.Message;

            }

            return result;
        }
        public static bool ValidarRuc(string ruc)
        {
            var total = 0;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            const int numProvicincias = 24;
            const int tercerDigito = 6;
            if (ruc.Length == 13 && ruc.Substring(10, 3) == "001")
            {
                string ced = ruc.Substring(0, 10);
                var provincia = Convert.ToInt32(string.Concat(ced[0], ced[1], string.Empty));
                var digitoTres = Convert.ToInt32(ced[2] + string.Empty);
                if ((provincia > 0 && provincia <= numProvicincias) && digitoTres < tercerDigito)
                {
                    var digitoVerificador = Convert.ToInt32(ced[9] + string.Empty);
                    for (int i = 0; i < coeficientes.Length; i++)
                    {
                        var valor = Convert.ToInt32(coeficientes[i] + string.Empty) * Convert.ToInt32(ced[i] + string.Empty);
                        total = valor >= 10 ? total + (valor - 9) : total + valor;
                    }
                    var digitoVerificadorRecibido = total >= 10 ? (total % 10) != 0 ? 10 - (total % 10) : (total % 10) : total;
                    return digitoVerificadorRecibido == digitoVerificador;
                }
            }
            return false;
        }

        public static bool ValidarTelefono(string numero)
        {
            if (numero.Length == 10)
            {
                Regex regex = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
                Match match = regex.Match(numero);
                if (match.Success)
                    return true;
            }
            return false;
        }

        public static string CreatePassword()
        {
            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 15;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }

            return contraseniaAleatoria;
        }
    }
}
