using System;
using System.ComponentModel.DataAnnotations;

namespace MDA_Web.Models
{
    public class ResponseModel
    {
        public string cardnumber { get; set; }
        public int errorid { get; set; }
        public string operationdate { get; set; }

    }
}