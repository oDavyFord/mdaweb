using System;
using System.ComponentModel.DataAnnotations;

namespace MDA_Web.Models
{
    public class SaldoModel
    {
        public string sTarjeta { get; set; }
        public string sSucId { get; set; }
        public string sCajaId { get; set; }
        public string sTerminalId { get; set; }
        public string sAuthCode { get; set; }

    }

}