using Dapper;
using Microsoft.Data.SqlClient;
using SENSHOP2._1.Models;
using System.Data;

namespace SENSHOP2._1.Repositorio
{
    public class RepositorioCompras1
    {


        public interface IRepositorioCompras
        {
            Task<bool> Guardarcompras(ComprasViewModel model);
        }
        public class RepositorioCompras : IRepositorioCompras
        {
            private readonly string cnx;

            public RepositorioCompras(IConfiguration configuration)
            {
                cnx = configuration.GetConnectionString("DefaultConnection");
            }

            public async Task<bool> Guardarcompras(ComprasViewModel model)
            {
                bool IsInserted = false;
                try
                {
                    var connection = new SqlConnection(cnx);
                    IsInserted = await connection.ExecuteAsync(@"INSERT INTO ReCompras (fecha, NombreP, code, proveedor, cantidad, subtotal,val_Unidad ) VALUES (@fecha, @NombreP, @code, @proveedor, @cantidad, s@ubtotal, @val_Unidad) ", model) > 0;

                }
                catch (Exception ex)
                {

                    string message = ex.Message;
                }
                return IsInserted;

            }

        }
    }
}