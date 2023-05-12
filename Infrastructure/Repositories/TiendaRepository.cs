using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TiendaRepository : GenericRepository<Tienda>, ITiendaRepository
    {
        public TiendaRepository(TiendaContext context) : base(context)
        {

        }

        public async Task<List<Producto>> GetProductosByAsyncTiendaId(int tiendaId)
        {
            return await _context.Productos.Where(p => p.TiendaId == tiendaId).ToListAsync();
        }
    }
}
