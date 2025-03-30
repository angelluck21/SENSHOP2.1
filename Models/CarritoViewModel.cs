namespace SENSHOP2._1.Models
{
    public class CarritoViewModel
    {    public class Producto
        {
            public string code { get; set; }
            public string name { get; set; }
            public decimal p_venta { get; set; }
            public string descripsionE { get; set; }
        }
        
        public class carroitem
        {
              
            public Producto producto { get; set; }
            public int cantidad { get; set; }
        }
        public class PSeleccionados
        {
            public List<carroitem> Items { get; set; } = new List<carroitem>();
            public decimal TotalP => Items.Sum(item => item.producto.p_venta * item.cantidad);
        }

    }
   
  

    
}