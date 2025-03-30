using Microsoft.Identity.Client;
using SENSHOP2._1.Models;
using SENSHOP2._1.Repositorio;
using System.Text.Json;
using static SENSHOP2._1.Models.CarritoViewModel;

public interface IRepositorioCarro
{
    void AGitemcarro(Producto id, int cantidad);
    List<carroitem> listarItemsCarro();
    void eliminaritemcarro(int productID);
    void actualizarItemCarro(int productID, int cantidad);
 
}


public class RepositorioCarro : IRepositorioCarro
{
    private readonly PSeleccionados _productoSeleccionados;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public RepositorioCarro(PSeleccionados _productoSeleccionados, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
           this._productoSeleccionados = _productoSeleccionados;


    }
    private PSeleccionados obtenerItemSesion()
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
    public void AGitemcarro(Producto _producto, int cantidad)
    {
        var cart = obtenerItemSesion();
        var existingItem = cart.Items.FirstOrDefault(i => i.producto.code == _producto.code);
        if (existingItem != null)
        {
            
            existingItem.cantidad += cantidad;
        }
        else
        {
            cart.Items.Add(new carroitem { producto = _producto, cantidad = cantidad });

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
        return _productoSeleccionados.TotalP;
    }
    public void actualizarItemCarro(int productID, int cantidad)
    {
        var cart = obtenerItemSesion();
        var ExistItem = cart.Items.FirstOrDefault(i => i.producto.code == productID.ToString());
        if (ExistItem != null)
        {
            ExistItem.cantidad = cantidad;
        }
        guardaItemsSesion(cart);
    }
    public List<carroitem> listarItemsCarro()
    {
        return obtenerItemSesion().Items;
    }
    public decimal obtenerTL()
    {
        return _productoSeleccionados.TotalP;
    }
}


