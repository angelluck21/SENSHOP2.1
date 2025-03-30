using SENSHOP2._1.Models;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;
namespace SENSHOP2._1.Repositorio
{
    public interface IRepositorioProveedores
    {
        Task<bool> RegistrarProveedor(ProveedoresViewModel Proveedor);
    }
    public class RepositorioProveedores : IRepositorioProveedores
    {
        private readonly string cnx;
        public RepositorioProveedores(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> RegistrarProveedor(ProveedoresViewModel Proveedor)
        {
            try
            {
                using var connection = new SqlConnection(cnx);
                bool isinserted = await connection.ExecuteAsync(@"INSERT INTO Proveedores (nombre, apellido, NTelefono, Correo, empresa) VALUES (@nombre, @apellido, @NTelefono, @Correo, @empresa) ", Proveedor) > 0;
                return isinserted;
            }
            catch (Exception ex)
            {

            }
            return true;

        }
    }
}
