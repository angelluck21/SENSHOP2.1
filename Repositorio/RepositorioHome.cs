using SENSHOP2._1.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace SENSHOP2._1.Repositorio
{


    public interface IRepositoriohome
    {
        IEnumerable<ProductoViewModel> listarProducto();
    }

    public class RepositorioHome : IRepositoriohome
    {
        private readonly string cnx;
        public RepositorioHome(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<ProductoViewModel> listarProducto() 
        {
            using (IDbConnection db = new SqlConnection(cnx))
            {
                string sqlQuery = "SELECT * FROM p_ductos";
                var productos = db.Query<ProductoViewModel>(sqlQuery).ToList();
                return productos;
            }
        }

       
    }

}

