using System.ComponentModel.DataAnnotations;

namespace BYTHEMARKET.Models
{
	public class IniciarsesionModel
	{
		[Required(ErrorMessage = "El campo usuario es requerido")]
		public string nombre { get; set; }

		[Required(ErrorMessage = "El campo contraseña es requerido")]
		public string password { get; set; }

		                                 
	}
}
