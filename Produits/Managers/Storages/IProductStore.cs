using System.Data;

namespace Produits.Managers.Storages
{
    public interface IProductStore
    {
        public DataTable GetProducts();
    }
}