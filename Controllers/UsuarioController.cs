using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SENSHOP2._1.Models;
using SENSHOP2._1.Repositorio;
using static SENSHOP2._1.Repositorio.RepositorioUsuario;

namespace BYTHEMARKET.Controllers
{
	public class UsuarioController : Controller
	{
		private readonly IRepositorioUsuario repositorioUsuario;
		private readonly IRepositoriohome repohome;

		public UsuarioController(IRepositorioUsuario repositorioUsuario)
		{
			this.repositorioUsuario = repositorioUsuario;
		}
		public IActionResult registrar(RegViewModel user)
		{
            repositorioUsuario.registrarUsuario(user);
            CryptoClass cryptoClasse = new CryptoClass();
            user.cotraseña = cryptoClasse.Encrypt(user.cotraseña);
         
            if (!ModelState.IsValid)
			{
               
                return View("~/Views/SHOP/Tienda.cshtml",user);

			}

           
            return View("~/Views/SHOP/Tienda.cshtml");



        }
		public IActionResult regist (RegViewModel usuario )
		{
			if (!ModelState.IsValid)
			{
                
                return View("~/Views/SHOP/Tienda.cshtml", usuario);
			}
            
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> login(RegViewModel login)
		{
            
            ErrorViewModel error1 = new ErrorViewModel();
			try
			{
				CryptoClass clave = new CryptoClass();
				login.cotraseña = clave.Encrypt(login.cotraseña);
				bool rsp = await repositorioUsuario.ValidarUser(login);
				if (rsp)
				{
                    IEnumerable<ProductoViewModel> productos = repohome.listarProducto();
                    return View("\"~/Views/SHOP/Tienda.cshtml", productos);

				}
				return View("login");
            }
			catch (Exception error)
			{ 
			    error1.RequestId =error.HResult.ToString();
                error1.message = error.HResult.ToString();
            }
			return View("Error", error1);
		}

	}
}