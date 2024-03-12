using System;
using System.ComponentModel.DataAnnotations;

namespace MDA_Web.Models
{
    public class historialapego
    {
        public string cardnumber { get; set; }
        public string storebrand { get; set; }
        public string item { get; set; }
        public string itemname { get; set; }
        public string itembrand { get; set; }
        public string itemruledesc { get; set; }
        public string itemrulerestrictiondesc { get; set; }
        public string quantity { get; set; }
        public string discount { get; set; }
        public string quantitybonus { get; set; }
        public string itemnextbonus { get; set; }
        public string itemruleexpiration { get; set; }
        public string operationdate { get; set; }
    }


}