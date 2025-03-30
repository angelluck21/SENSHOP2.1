using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SENSHOP2._1.Models
{
    public class ContactosViewModel
    {
        public string nombre { get; set; }
        public string correo { get; set; }
        public int mensaje  { get; set; }
       
    }

}
