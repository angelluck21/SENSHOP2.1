using System;
using System.ComponentModel.DataAnnotations;

namespace SENSHOP2._1.Models
{
    public class ProductoViewModel
    {
        public string code { get; set; }
        public string name { get; set; }
        public string p_venta { get; set; }
        public string Uni { get; set; }
        public string descripsionE { get; set; }
        public string descripsionP { get; set; }
        public string Marca { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile sl_img { get; set; }
        public string urlimagen { get; set; }
        public DateTime Fecha { get; set; }

    }

   
}
