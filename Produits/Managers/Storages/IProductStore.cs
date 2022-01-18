using Produits.Models.Products;
using System.Collections.Generic;

namespace Produits.Managers.Storages
{
    public interface IProductStore
    {
        public List<Product> GetProducts();
    }
}