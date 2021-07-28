using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using ClienteAPI.Model;
using Newtonsoft.Json;

namespace ClienteAPI.Controller
{
    public class PeliculaController
    {
        //Install the Web API Client Libraries
        public List<PeliculaModel> ListarPeliculasJSON()
        {
            List<PeliculaModel> Peliculas = null;
            HttpWebRequest Solicitud = null;
            HttpWebResponse Respuesta = null;
            StreamReader Cliente = null;

            string UriApi = "http://localhost/phpservice/PeliculaView.php";
            string TramRespuesta = string.Empty;

            Solicitud = WebRequest.Create(UriApi) as HttpWebRequest;
            Solicitud.Timeout = 2000;
            Solicitud.Method = "POST";
            Solicitud.ContentType = "application/json";
            Solicitud.Accept = "application/json";

            //Solicitud.Headers.Add("Parametro", "Valor");

            Respuesta = Solicitud.GetResponse() as HttpWebResponse;
            Cliente = new StreamReader(Respuesta.GetResponseStream(), Encoding.UTF8);
            TramRespuesta = Cliente.ReadToEnd();

            Peliculas = JsonConvert.DeserializeObject<List<PeliculaModel>>(TramRespuesta);

            return Peliculas;
        }

        public RespuestaModel GrabarPeliculaJSON(PeliculaModel Pelicula)
        {
            RespuestaModel Salida = null;
            HttpWebRequest Solicitud = null;
            HttpWebResponse Respuesta = null;
            StreamReader Cliente = null;

            string UriApi = "http://localhost/phpservice/PeliculaView.php";
            string TramRespuesta = string.Empty;

            byte[] Trama = null;
            string Datos = JsonConvert.SerializeObject(Pelicula); 
            Trama = UTF32Encoding.UTF8.GetBytes(Datos);

            Solicitud = WebRequest.Create(UriApi) as HttpWebRequest;
            Solicitud.Timeout = 2000;
            Solicitud.Method = "POST";
            Solicitud.ContentLength = Trama.Length;
            Solicitud.ContentType = "application/json";
            Solicitud.Accept = "application/json";

            //Solicitud.Headers.Add("Parametro", "Valor"); ;

            Stream Servicio = Solicitud.GetRequestStream();
            Servicio.Write(Trama, 0, Trama.Length);
            Servicio.Close();

            Respuesta = Solicitud.GetResponse() as HttpWebResponse;
            Cliente = new StreamReader(Respuesta.GetResponseStream(), Encoding.UTF8);
            TramRespuesta = Cliente.ReadToEnd();

            Salida = JsonConvert.DeserializeObject<RespuestaModel>(TramRespuesta);

            return Salida;
        }
    }
}
