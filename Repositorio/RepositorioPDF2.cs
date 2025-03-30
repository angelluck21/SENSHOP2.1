using Microsoft.Data.SqlClient;

using Dapper;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using SENSHOP2._1.Models;
using System.Collections.Generic;
using System.Reflection.Metadata;


namespace SENSHOP2._1.Repositorio
{
    public class RepositorioPDF2
    {
        public interface IRepositorioPDF_2
        {
            List<ProductoViewModel> HacerPDF2(ProductoViewModel hacer2);
        }
        public class RepositorioPDF_2 : IRepositorioPDF_2
        {

            private readonly string cnx;
            private readonly IConfiguration _configuration;
            public RepositorioPDF_2(IConfiguration config)
            {

                cnx = config.GetConnectionString("DefaultConnection");
            }
            public List<ProductoViewModel> HacerPDF2(ProductoViewModel hacer2)
            {

                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using var connection = new SqlConnection(cnx);
                var query = "SELECT name, p_venta, Uni, descripsionE, code, Marca FROM p_ductos";
                using var hacer_2 = new SqlConnection(connectionString);
                var pdf2 = connection.Query<ProductoViewModel>(query).ToList();




                return pdf2;


            }
        }

    }
}

