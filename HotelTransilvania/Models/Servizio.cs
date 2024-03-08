using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelTransilvania.Models
{
    public class Servizio
    {
        [Key]
        public int IdServizio { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }
        public int IdCliente { get; set; }
    }
}