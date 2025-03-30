using Microsoft.AspNetCore.Mvc;
using SENSHOP2._1.Models;
using SENSHOP2._1.Repositorio;
using System.ComponentModel.DataAnnotations;

namespace SENSHOP2._1.Controllers
{
    
    public class ContactarController : Controller
    {
        private readonly IRepositorioContacto contacto1;
        

        public ContactarController(IRepositorioContacto repositoriocontacto)
        {
            this.contacto1= repositoriocontacto;
        }
        public IActionResult contactos(ContactosViewModel contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            
               

            
            contacto1.contactosG(contact);

            return View("~/Views/SHOP/Tienda.cshtml");
        }
        
            
        
    }
        
              
}

          
    
   
    

