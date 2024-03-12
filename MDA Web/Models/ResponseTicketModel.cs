using System;
using System.ComponentModel.DataAnnotations;

namespace MDA_Web.Models
{
    public class ResponseTicketModel
    {
        public string card { get; set; }
        public string invoice { get; set; }
        public string transactiondate { get; set; }
        public string saleid { get; set; }
        public string storeid { get; set; }
        public string typetransaction { get; set; }
        public string saledate { get; set; }
        public string transactionid { get; set; }
        public string pointsearned { get; set; }
        public string pointspaid { get; set; }
        public string puntospaid { get; set; }

        public string employee { get; set; }
        public string pos { get; set; }
        public string store { get; set; }
        public string state{ get; set; }
        public string county { get; set; }
        public int errorid { get; set; }
        public string message { get; set; }
        public DateTime perationdate { get; set; }




    }

}