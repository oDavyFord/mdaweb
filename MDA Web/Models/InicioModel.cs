using System;
using System.ComponentModel.DataAnnotations;

namespace MDA_Web.Models
{
    public class InicioModel
    {
        [MaxLength(13)]
        public string card { get; set; }
        public string store { get; set; }
        public string pos { get; set; }
        public string employee { get; set; }
        public string cardpassword { get; set; }
        public string authcode { get; set; }
        public string mes { get; set; }
        public string dia { get; set; }
        public string anio { get; set; }



    }

}