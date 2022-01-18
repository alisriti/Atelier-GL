using System.Data;

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
    }
}