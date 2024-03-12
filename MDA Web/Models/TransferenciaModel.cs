using System;
using System.ComponentModel.DataAnnotations;

namespace MDA_Web.Models
{
    public class TransferenciaModel
    {
        public string userid { get; set; }
        public string tarjeta { get; set; }
        public string tarjetaorigen { get; set; }
        public string tarjetaorigenid { get; set; }
        public string tarjetadestino { get; set; }
        public string tarjetadestinoid { get; set; }
        public string status { get; set; }
        public string balancetransferencia { get; set; }
        public string celular { get; set; }
        public bool permission { get; set; }
        public string nombre { get; set; }
        public string paterno { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public string mes { get; set; }
        public string dia { get; set; }
        public string anio { get; set; }
        public int contacto { get; set; }
        public string store { get; set; }
        public string pos { get; set; }
        public string employee { get; set; }
        public string cardpassword { get; set; }
        public string authcode { get; set; }
        public string fechanacimiento { get; set; }
        public string saldo { get; set; }

    }

}