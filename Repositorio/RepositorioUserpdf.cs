using Microsoft.Data.SqlClient;
using SENSHOP2._1.Models;
using Dapper;
namespace SENSHOP2._1.Repositorio
{
    public class RepositorioUserpdf
    {

        public interface IRepositorioUserpdf
        {
            List<RegViewModel> HacerPDF3(RegViewModel hacer3);
        }

        public class RepositorioUserpdf3 : IRepositorioUserpdf
        {
            private readonly string cnx;
            private readonly IConfiguration _configuration;

            public RepositorioUserpdf3(IConfiguration config)
            {

                cnx = config.GetConnectionString("DefaultConnection");

            }
            public List<RegViewModel> HacerPDF3(RegViewModel hacer3)
            {

                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using var connection = new SqlConnection(cnx);
                var query = "SELECT fecha, n_identficacion, name, apellido, correo, contraseña FROM registrar";
                using var hacer_3 = new SqlConnection(connectionString);
                var pdf3 = connection.Query<RegViewModel>(query).ToList();




                return pdf3;


            }
        }
    }
}
