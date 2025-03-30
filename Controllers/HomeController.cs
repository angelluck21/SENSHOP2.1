using Microsoft.AspNetCore.Mvc;
using SENSHOP2._1.Models;
using System.Diagnostics;

namespace SENSHOP2._1.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult validar(IFormCollection formulario)
		{
			string usuario = formulario["nombre"];
			string contraseña = formulario["password"];

			if (usuario == "angelluiswar456@gmail.com" && contraseña == "123")
			{
				return View("Tienda", "home");
			}
			else
			{
				TempData["error"] = "usuario o contraseña incorrectos";
				return RedirectToAction("login");
			}
		}

		public IActionResult login()
		{
			return View();
		}

		public IActionResult registrar()
		{
			return View();
		}
		 
		 public IActionResult  producto() {
			return View("~/Views/SHOP/producto.cshtml");		
		}
		public IActionResult CODAL()
		{
			return View("~/Views/SHOP/CODAL.cshtml");
		}
		public IActionResult contactos()
		{
			return View();
		}
		public IActionResult Proveedor()
		{
			return View("~/Views/Home/Proveedores.cshtml"); 
		}
        public IActionResult PDF()
        {
            return View("~/Views/SHOP/PDF.cshtml");
        }
		public IActionResult kks()
		{
			return View("~/Views/Home/REGCompra.cshtml");


		}
      public IActionResult add()
		{
			return View("~/Views/SHOP/AdministradorTienda.cshtml");
		}
    }
}
