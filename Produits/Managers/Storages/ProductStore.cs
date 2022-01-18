using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Produits.Managers.Storages
{
    public class ProductStore : IProductStore
    {
        private readonly IConfiguration configuration;

        public ProductStore(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DataTable GetProducts()
        {
            DataTable tableProduits = new DataTable();
            string connectionString = configuration.GetConnectionString("depinfo");
            connectionString = configuration.GetConnectionString("depinfo");
            using var connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUITS", connection);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            connection.Open();
            da.Fill(tableProduits);
            return tableProduits;
        }
    }
}