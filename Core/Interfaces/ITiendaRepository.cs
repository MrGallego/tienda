using Core.Entities;

namespace Core.Interfaces
{
    public interface ITiendaRepository : IGenericRepository<Tienda>
    {
        Task<List<Producto>> GetProductosByAsyncTiendaId(int tiendaId);
    }
}
