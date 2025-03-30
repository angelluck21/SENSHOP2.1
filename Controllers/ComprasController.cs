using Microsoft.AspNetCore.Mvc;
using SENSHOP2._1.Models;

namespace SENSHOP2._1.Controllers
{
    public class ComprasController : Controller
    {
        public IActionResult RecibirDatos([FromBody] List<TablaItemcs> itemcs ) 
        {
         return Ok(itemcs);
        
        }
    }
}
