using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteAPI.Model
{
    public class PeliculaModel
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string director { get; set; }
        public DateTime fecha { get; set; }
    }
}
