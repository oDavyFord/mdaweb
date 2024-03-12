using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MDA_Web.Models
{
    public class ResponsePlanLealtadModel
    {
        public List<historialapego> historialapego { get; set; }
        public List<bonuspending> bonuspending { get; set; }
        public int errorid { get; set; }
        public string message { get; set; }

    }

}