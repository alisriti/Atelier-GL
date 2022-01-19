using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Produits.Models.Products
{
    public static class ProductMapper
    {
        public static Product ToProduct(this DataRow row)
        {
            return new Product()
            {
                Id = (int)row["Id"],
                Designation = (string)row["Designation"],
                Quantite = (int)row["Quantite"],
                Prix = (int)row["Prix"]
            };
        }

        public static List<Product> ToProductsList(this DataTable table) =>
            (from DataRow row in table.Rows select row.ToProduct()).ToList();
    }
}