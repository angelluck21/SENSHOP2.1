using SENSHOP2._1.Models;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;

namespace SENSHOP2._1.Repositorio
{

		public interface IRepositorioUsuario
		{
        Task<bool> registrarUsuario(RegViewModel usuario);

        Task<bool> ValidarUser(RegViewModel login);
    }
	public class RepositorioUsuario : IRepositorioUsuario {

		private readonly string cnx;
		public RepositorioUsuario(IConfiguration config) {

			cnx = config.GetConnectionString("DefaultConnection");
		}



		public async Task<bool> registrarUsuario(RegViewModel usuario)
		{
			try
			{
				using var connection = new SqlConnection(cnx);
				bool isInserted = await connection.ExecuteAsync(@"INSERT INTO registrar (n_identficacion, name, apellido, sexo, fecha,  correo, contraseña ) VALUES (@n_identficacion, @nombre, @apellido, @sexo, @fecha, @correo, @cotraseña ) ", usuario) > 0;
				return isInserted;

			}
			catch (Exception ex)
			{

			}
			return true;
		}
		public async Task<bool> ValidarUser(RegViewModel login)
		{
			using var conn = new SqlConnection(cnx);
			string query = @"SELECT COUNT(1) FROM registrar  WHERE name = @name  AND contraseña = @contraseña";
			bool usuarioExiste = await conn.ExecuteScalarAsync<int>(query, new { login.name, login.cotraseña }) > 0;
			return usuarioExiste;
		}
	}


}
