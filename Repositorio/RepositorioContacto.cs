using Dapper;
using Microsoft.Data.SqlClient;
using SENSHOP2._1.Models;
using System.Data;

namespace SENSHOP2._1.Repositorio
{
    public interface IRepositorioContacto
    {
        Task<bool> contactosG(ContactosViewModel model);
    }
    public class RepositorioContacto : IRepositorioContacto
    {
        private readonly string cnx;

        public RepositorioContacto()
        {
        }

        public RepositorioContacto(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("DefaultConnection");
        }



        public async Task<bool> contactosG(ContactosViewModel model)
        {
            bool IsInserted = false;
            try
            {
                var connection = new SqlConnection(cnx);
                IsInserted = await connection.ExecuteAsync(@"INSERT INTO contactos (nombres, correo, mensaje) VALUES (@nombres, @correo, @mensaje) ", model) > 0;

            }
            catch (Exception ex)
            {

                string message = ex.Message;
            }
            return IsInserted;




        }
    }
}
