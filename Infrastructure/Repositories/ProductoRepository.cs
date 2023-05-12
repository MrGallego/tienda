using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(TiendaContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Producto>> GetAllProductsPriceMax(int cant)
        {
            return await _context.Productos
                .OrderByDescending(p => p.Valor)
                .Take(cant).ToListAsync();
        }
    }
}
