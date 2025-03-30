using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SENSHOP2._1.Controllers;
using SENSHOP2._1.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq.Expressions;
using static SENSHOP2._1.Controllers.ProductoController;
using static SENSHOP2._1.Models.CarritoViewModel;
using ApplicationDbContext = SENSHOP2._1.Controllers.ApplicationDbContext;

namespace SENSHOP2._1.Repositorio
{
    public class RepositorioProducto
    {

        public interface IRepositorioProducto
        {
            ProductoViewModel detalleproc(int idproc);
            Task<bool> producto(ProductoViewModel model);
            Producto Selectcar(int IDproc);

            Task<Producto> ObtenerProductoPorId(int id);
            Task BorrarProducto(int id);
            Task<ProductoViewModel> ObtenerProductoPorCodigo(string code);
        }
        public class RepositorioProducto2 : IRepositorioProducto
        {

            private readonly IConfiguration _configuration;
            private readonly string cnx;

            public RepositorioProducto2(IConfiguration confg)
            {
                cnx = confg.GetConnectionString("DefaultConnection");
                _configuration = confg;

            }

            public async Task<bool> producto(ProductoViewModel model)
            {
                bool IsInserted = false;
                try
                {
                    var connection = new SqlConnection(cnx);
                    IsInserted = await connection.ExecuteAsync(@"INSERT INTO p_ductos (code, name, p_venta, Uni, descripsionE, descripsionP, urlimagen, Marca) VALUES (@code, @name, @p_venta, @Uni, @descripsionP, @descripsionE, @urlimagen, @Marca) ", model) > 0;

                }
                catch (Exception ex)
                {

                    string message = ex.Message;
                }
                return IsInserted;
            }
            public ProductoViewModel detalleproc(int idproc)
            {


                using (IDbConnection db = new SqlConnection(cnx))
                {
                    string sqlquery = "SELECT  code, p_venta, descripsionP, descripsionE, name, urlimagen, Uni, Marca  FROM p_ductos  WHERE code = @idproc ";

                    ProductoViewModel producto = db.QuerySingleOrDefault<ProductoViewModel>(sqlquery, new { idproc });
                    return producto;
                }
            }

            public Producto Selectcar(int IDproc)
            {
                using (IDbConnection db = new SqlConnection(cnx))
                {
                    string sqlquery = "SELECT * FROM p_ductos  WHERE code = @idproc";
                    Producto producto = db.QuerySingleOrDefault<Producto>(sqlquery, new { IDproc });
                    return producto;
                }
            }


            public async Task<Producto> ObtenerProductoPorId(int id)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using var connection = new SqlConnection(connectionString);
                var query = "SELECT code, p_venta, descripsionP, descripsionE, name, urlimagen, Marca FROM p_ductos WHERE code = @Idproc";
                return await connection.QueryFirstOrDefaultAsync<Producto>(query, new { code = id });
            }
            public async Task BorrarProducto(int id)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using var connection = new SqlConnection(connectionString);
                var query = "DELETE FROM p_ductos WHERE code = @code";
                await connection.ExecuteAsync(query, new { code = id });
            }

            public async Task<ProductoViewModel> ObtenerProductoPorCodigo(string code)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using var connection = new SqlConnection(connectionString);
                var query = "SELECT code, name, Uni, p_venta FROM p_ductos WHERE code = @code";
                return await connection.QueryFirstOrDefaultAsync<ProductoViewModel>(query, new { code = code });
            }
        }

    } 
}

