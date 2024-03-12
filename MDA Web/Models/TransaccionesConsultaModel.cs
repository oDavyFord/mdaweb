using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MDA_Web.Models
{
    public class TransaccionesConsultaModel
    {
        [MaxLength(13)]
        public string card { get; set; }
        public string store { get; set; }
        public string pos { get; set; }
        public string employee { get; set; }
        public string authcode { get; set; }
        public string mes { get; set; }
        public string dia { get; set; }
        public string anio { get; set; }
        public List<TransactionModel> Transactions { get; set; }
        public string HtmlContent { get; set; }
        public string Tarjeta { get; set; }
        public string clienteNombre { get; set; }
        public string SaldoPuntos { get; set; }
        public string SaldoDesglose1 { get; set; }
        public string SaldoDesglose2 { get; set; }
        public List<historialapego> PlanesLealtad { get; set; }
        public List<bonuspending> BonificacionesPendientes { get; set; }


    }

   
    
    public class TransactionModel
    {
        public string TipoMovimiento { get; set; }
        public string Invoice { get; set; }
        public string NoSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public string Fecha { get; set; }
        public decimal Abono { get; set; }
        public decimal Cargo { get; set; }
        public string TransactionId { get; set; }

    }

}