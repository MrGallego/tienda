using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork, IDisposable
    {
        private readonly TiendaContext _context;
        private IProductoRepository _productos;
        private ITiendaRepository _tiendas;

        public UnitOfWork(TiendaContext context)
        {
            _context = context;
        }

        public IProductoRepository Productos
        {
            get
            {
                if (_productos == null)
                {
                    _productos = new ProductoRepository(_context);
                }
                return _productos;
            } 
        }

        public ITiendaRepository Tiendas
        {
            get
            {
                if (_tiendas == null)
                {
                    _tiendas = new TiendaRepository(_context);
                }
                return _tiendas;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }  
}
