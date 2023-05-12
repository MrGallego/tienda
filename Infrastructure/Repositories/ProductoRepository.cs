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

        public override async Task<Producto> GetByIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Tienda).FirstOrDefaultAsync(p=>p.Id == id);
        }


        public override async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context
                .Productos
                .Include(t=>t.Tienda)
                .ToListAsync();
        }
      
    }
}
