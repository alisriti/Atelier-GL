using Microsoft.Extensions.Configuration;
using Produits.Models.Products;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Produits.Managers.Storages
{
    public class ProductStore : IProductStore
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public ProductStore(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("depinfo");
        }

        public List<Product> GetProducts()
        {
            DataTable tableProduits = new DataTable();
            using var connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUITS", connection);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            connection.Open();
            da.Fill(tableProduits);

            return tableProduits.ToProductsList();
        }

        public Product GetProductById(int Id)
        {
            DataTable dt = new DataTable();
            using var connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUITS WHERE Id =@aId", connection);
            cmd.Parameters.AddWithValue("@aId", Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            connection.Open();
            da.Fill(dt);

            return dt.Rows[0].ToProduct();
        }
    }
}