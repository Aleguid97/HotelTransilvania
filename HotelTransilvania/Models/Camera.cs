using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelTransilvania.Models
{
    public class Camera
    {
        public int IdCamera { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
    }
}