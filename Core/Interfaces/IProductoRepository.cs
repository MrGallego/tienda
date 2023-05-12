using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        Task<IEnumerable<Producto>> GetAllProductsPriceMax(int cant);
    }
}
