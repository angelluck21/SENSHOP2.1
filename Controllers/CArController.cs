
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using SENSHOP2._1.Models;
using SENSHOP2._1.Repositorio;
using System.Collections.Concurrent;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using static SENSHOP2._1.Models.CarritoViewModel;
using static SENSHOP2._1.Repositorio.RepositorioProducto;
using static SENSHOP2._1.Repositorio.RepositorioCarrito;

namespace SENSHOP2._1.Controllers
{
    public class CArController : Controller
    {
        private readonly IRepositorioCarro _carritoservicio;
        private readonly IRepositorioProducto _repositorioProducto;
        public CArController(IRepositorioCarro carritoservicio, IRepositorioProducto repositorioProducto)
        {
            _carritoservicio = carritoservicio;
            _repositorioProducto = repositorioProducto;
        }
        public IActionResult agregar(int id, int cantidad)
        {
            var Detalle = _repositorioProducto.Selectcar(id);
            if (Detalle != null)
            {

                _carritoservicio.AGitemcarro(Detalle, cantidad);
            }
            var carritoItems = _carritoservicio.listarItemsCarro();
            return View("~/Views/SHOP/CarrodeC.cshtml", carritoItems);
        }
     
        public IActionResult elimina(int productoID) {
        
               _carritoservicio.eliminaritemcarro(productoID);
            var carroitem = _carritoservicio.listarItemsCarro();
            return View("~/Views/SHOP/CarrodeC.cshtml", carroitem);
        }
        public IActionResult actualizar(int productID, int cantidad) {

            if (cantidad < 1) {

                return BadRequest("La cantida minima debe de ser almenos de 1.");


            }
            _carritoservicio.actualizarItemCarro(productID, cantidad);
            var carroitem = _carritoservicio.listarItemsCarro();
            return View("~/Views/SHOP/CarrodeC.cshtml", carroitem);
        
        }

     public IActionResult tienda()
        {
            return View("~/Views/SHOP/Tienda.cshtml");
        }
          
         
        public IActionResult CarrodeC()
        {
            return View("~/Views/SHOP/CarrodeC.cshtml");
        }
    }
}
