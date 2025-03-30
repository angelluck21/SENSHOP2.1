
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SENSHOP2._1.Models;
using SENSHOP2._1.Repositorio;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using static SENSHOP2._1.Models.CarritoViewModel;
using static SENSHOP2._1.Repositorio.RepositorioProducto;



namespace SENSHOP2._1.Controllers
{
    public class ProductoController : Controller
    {
		
		public readonly IRepositorioProducto repoproducto;
        private readonly ProductoViewModel _context;

        public ProductoController(IRepositorioProducto repoHome)
        {
            this.repoproducto = repoHome;
        }
        public async Task<IActionResult> producto(ProductoViewModel model)
        {
            try
            {
                if (model.sl_img != null && model.sl_img.Length > 0)
                {

                    var extension = Path.GetExtension(model.sl_img.FileName);
                    var nuevoname = Guid.NewGuid().ToString() + extension;
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Produimag", nuevoname);
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        await model.sl_img.CopyToAsync(stream);
                    }

                    model.urlimagen = "./produimag/" + nuevoname;
                    repoproducto.producto(model);

                }

            }
            catch
            {

            }


            return View("~/Views/SHOP/producto.cshtml");
        }
        [HttpGet]
        public string Mensaje()
        {
            return "mensaje Back sino crees";
        }

        [HttpGet]
        public JsonResult detalle(int id)
        {

            ProductoViewModel detalle = repoproducto.detalleproc(id);
            return Json(detalle);
        }
        [HttpPost]
        public async Task<IActionResult> Borrar(int id)
        {
            await repoproducto.BorrarProducto(id);
            return View("~/Views/SHOP/Gracias.cshtml");

        }

		[HttpGet]
		public async Task<IActionResult> ObtenerProductoPorCodigo(string code) 
        { var producto = await repoproducto.ObtenerProductoPorCodigo(code);                                  
            if (producto == null) 
            { return NotFound(); } 
            return Json(producto);
        }
	}

}