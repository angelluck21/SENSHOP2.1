using Microsoft.AspNetCore.Mvc;
using SENSHOP2._1.Models;
using SENSHOP2._1.Repositorio;
using System.Security.Cryptography;
using static SENSHOP2._1.Repositorio.RepositorioProveedores;

namespace SENSHOP2._1.Controllers
{
	public class ProveedoresController : Controller
	{

		private readonly IRepositorioProveedores RepoProveer;
		public ProveedoresController(IRepositorioProveedores repoProveer)
		{
			this.RepoProveer = repoProveer;
		}
		public ActionResult RegistrarProveedor(ProveedoresViewModel proveedor) {
		 
		 if (!ModelState.IsValid)
			{
				return View("~/Views/Home/Proveedores.cshtml", proveedor);
			}			RepoProveer.RegistrarProveedor(proveedor);
			return View("~/Views/Home/Proveedores.cshtml");
		}
		public IActionResult Index()
		{
			return View();
			
		}
	}
}
