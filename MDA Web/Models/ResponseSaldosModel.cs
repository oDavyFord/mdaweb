using System;
using System.ComponentModel.DataAnnotations;

namespace MDA_Web.Models
{
    public class ResponseSaldosModel
    {
        public string sessionId { get; set; }
        public string clienteNombre { get; set; }
        public string saldoPuntos { get; set; }
        public string saldoDesglose1 { get; set; }
        public string saldoDesglose2 { get; set; }
        public int errorid { get; set; }
        public string mensaje { get; set; }

    }
}