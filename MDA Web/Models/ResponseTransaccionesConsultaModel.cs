using System;
using System.ComponentModel.DataAnnotations;

namespace MDA_Web.Models
{
    public class ResponseTransaccionesConsultaModel
    {
        public string message { get; set; }
        public int errorid { get; set; }
        public string operationdate { get; set; }
        public string cardbalancesheet { get; set; }
        public string transactionid { get; set; }
        public string card { get; set; }

    }
}