using Microsoft.AspNetCore.Mvc;
using SENSHOP2._1.Models;
using SENSHOP2._1.Repositorio;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace SENSHOP2._1.Controllers
{
    public class InventarioController : Controller
    {

        private readonly IRepositoriohome repohome;
        public InventarioController(IRepositoriohome repositoriohome)
        {
            this.repohome = repositoriohome;
        }
        public IActionResult produc()
        {
            IEnumerable<ProductoViewModel> productos =repohome.listarProducto();
            return View(productos);
        }


        public IActionResult Tienda()
        {
            IEnumerable<ProductoViewModel> productos = repohome.listarProducto();
            return View("~/Views/SHOP/Tienda.cshtml", productos);

        }

    }
}
    