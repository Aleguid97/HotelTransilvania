using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelTransilvania.Models
{
    public class Dettagli
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Camera { get; set; }
        public string Servizio { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }
        public string DescrizioneCamera { get; internal set; }
        public string DescrizioneServizio { get; internal set; }
        public decimal TotalePrezzoServizi { get; internal set; }
    }
}