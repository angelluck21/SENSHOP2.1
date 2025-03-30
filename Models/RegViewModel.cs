using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SENSHOP2._1.Models
{

	public class RegViewModel
	{
		[Required(ErrorMessage = "el campo {0} es requerido ")]
		[MaxLength(10)]

		public string n_identficacion { get; set; }
		[Required(ErrorMessage = "el campo {0} es requerido ")]
		public string name { get; set; }
		[Required(ErrorMessage = "el campo {0} es requerido ")]
		public string apellido { get; set; }
		[Required(ErrorMessage = "el campo {0} es requerido ")]
		public string sexo { get; set; }
		[Required(ErrorMessage = "el campo {0} es requerido ")]
		public string fecha { get; set; }
		[Required(ErrorMessage = "el campo {0} es requerido ")]
		public string correo { get; set; }
		[Required(ErrorMessage = "el campo {0} es requerido ")]

		public string cotraseña { get; set; }
		[Required(ErrorMessage = "el campo {0} es requerido ")]
		public string concontraseña { get; set; }

       
		
			
		

    }

}
	

