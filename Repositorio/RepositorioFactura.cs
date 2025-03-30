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
    public class RepositorioFactura
    {
        public interface IRepositorioFactura
        {
            List<ProductoViewModel> GenerarFactura(ProductoViewModel fac);
        }


        public class RepositorioFactura1 : IRepositorioFactura
        {

            private readonly string cnx;
            private readonly IConfiguration _configuration;
            public RepositorioFactura1(IConfiguration config)
            {
                cnx = config.GetConnectionString("DefaultConnection");
            }

            public List<ProductoViewModel> GenerarFactura(ProductoViewModel fac)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                using var connection = new SqlConnection(cnx);
                var query = "SELECT name, p_venta, Uni, descripsionE, code, Marca FROM p_ductos";
                using var factura = new SqlConnection(connectionString);
                var facs = connection.Query<ProductoViewModel>(query).ToList();




                return facs;


            }
        }
    }
}
