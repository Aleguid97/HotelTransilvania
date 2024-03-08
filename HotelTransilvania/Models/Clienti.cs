using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelTransilvania.Models
{
    public class Clienti
    {
        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Il campo Codice Fiscale è obbligatorio")]
        [Display(Name = "Codice Fiscale")]
        public string CodFisc { get; set; }

        [Required(ErrorMessage = "Il campo Cognome è obbligatorio")]
        [Display(Name = "Cognome")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Il campo Nome è obbligatorio")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il campo Città è obbligatorio")]
        [Display(Name = "Città")]
        public string Citta { get; set; }

        [Required(ErrorMessage = "Il campo Provincia è obbligatorio")]
      
        public string Provincia { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
    }
}