using Dapper;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SENSHOP2._1.Models;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace SENSHOP2._1.Repositorio
{

    

    public class PDFRepositorio1
    {


        public interface IRepositorioPDF1
        {
            List<ProveedoresViewModel> proveedorespdf(ProveedoresViewModel hacer1);
        }
        public class RepositorioPDF1 : IRepositorioPDF1
        {

            private readonly string cnx;
            private readonly IConfiguration _configuration;
            public RepositorioPDF1(IConfiguration config)
            {

                cnx = config.GetConnectionString("DefaultConnection");
            }
            public List<ProveedoresViewModel> proveedorespdf(ProveedoresViewModel proveer)
            {

                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using var connection = new SqlConnection(cnx);
                var query = "SELECT Nombre, Apellido, NTelefono, empresa  FROM Proveedores";
                using var hacer = new SqlConnection(connectionString);
                var pr = connection.Query<ProveedoresViewModel>(query).ToList();




                return pr;


            }
        }
        
    }
   
}
