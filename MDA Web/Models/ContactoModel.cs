using System;
using System.ComponentModel.DataAnnotations;

namespace MDA_Web.Models
{
    public class ContactoModel
    {
        [MaxLength(13)]
        public string cardnumber { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public string comments { get; set; }
        public string key { get; set; }



    }

}