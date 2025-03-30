using Microsoft.Identity.Client;
using System.Text.Json;
using static SENSHOP2._1.Models.CarritoViewModel;

namespace SENSHOP2._1.Repositorio
{
    public class RepositorioCarrito
    {

    }
    public interface Icarritoservice
    {
        void AGitemcarro(Producto product, int cantidad);
        List<carroitem> listarItemsCarro();
        void eliminaritemcarro(int productID);
        void actualizarItemCarro(int productID, int cantidad);

    }
    public class CarritoServicio : Icarritoservice
    {
        private readonly PSeleccionados _productoSeleccionado;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PSeleccionados ObtenerProductoPorId;
        public CarritoServicio (PSeleccionados _productoSeleccionados, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
           this._productoSeleccionado = _productoSeleccionados;

        }

        private     PSeleccionados obtenerItemSesion()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cartJson = session.GetString("Carrito");
            return string.IsNullOrEmpty(cartJson) ? new PSeleccionados() : JsonSerializer.Deserialize<PSeleccionados>(cartJson);
        }
        private void guardaItemsSesion(PSeleccionados cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.SetString("Carrito", JsonSerializer.Serialize(cart));



        }
        public void AGitemcarro(Producto _producto, int canidad)
        {
            var cart = obtenerItemSesion();
            var existingItem = cart.Items.FirstOrDefault(i => i.producto.code == _producto.code );
            if (existingItem != null)
            {
                existingItem.cantidad += canidad;
            }
            else
            {
                cart.Items.Add(new carroitem {producto  = _producto, cantidad = canidad});

            }
            guardaItemsSesion(cart);

        }
        public void eliminaritemcarro(int productID)
        {
            var cart = obtenerItemSesion();
            var item = cart.Items.FirstOrDefault(i => i.producto.code == productID.ToString());
            if (item != null)
            {
                cart.Items.Remove(item);
                guardaItemsSesion(cart);
            }
        }
        public decimal obtenerT()
        {
            return _productoSeleccionado.TotalP;
        }
        public void actualizarItemCarro(int productID, int cantidad)
        {
            var cart = obtenerItemSesion();
            var ExistItem = cart.Items.FirstOrDefault(i => i.producto.code == productID.ToString());
            if (ExistItem != null)
            {
                ExistItem.cantidad =  cantidad;
            }
            guardaItemsSesion(cart);
        }
        public List<carroitem> listarItemsCarro()
        {
            return obtenerItemSesion().Items;
        }
        public decimal obtenerTL()
        {
            return _productoSeleccionado.TotalP;
        }
    }
    
}

