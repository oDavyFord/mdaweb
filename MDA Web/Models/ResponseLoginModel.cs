using System;
using System.ComponentModel.DataAnnotations;

namespace MDA_Web.Models
{
    public class ResponseLoginModel
    {
        public string message { get; set; }
        public int errorid { get; set; }
        public string operationdate { get; set; }
        public string cardbalance { get; set; }
        public string transactionid { get; set; }

    }
}