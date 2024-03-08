using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelTransilvania.Models
{
    public class Prenotazione
    {
        [Key]
        public int IdPrenotazione { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Prenotazione")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataPrenotazione { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Check-In")]
        public DateTime DataCheckIn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Check-Out")]
        public DateTime DataCheckOut { get; set; }
        public decimal Anticipo { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Descrizione { get; set; }
        public int Prezzo { get; set; }
        public int IdTipoPrenotazione { get; set; }
        public int IdCliente { get; set; }
        public int IdCamera { get; set; }
        public int IdServizio { get; set; }
    }
}