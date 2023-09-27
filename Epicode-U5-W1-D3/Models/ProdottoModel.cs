using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epicode_U5_W1_D3.Models
{
    public class ProdottoModel
    {
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Il prezzo è obbligatorio")]
        public double Prezzo { get; set; }
        public string Descrizione { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set;}
        [Display(Name = "Prodotto visibile nella home")]
        public bool Visibile { get; set; }
    }
}