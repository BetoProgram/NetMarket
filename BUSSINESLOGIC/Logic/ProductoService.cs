using BUSSINESLOGIC.Data;
using CORE.Entities;
using CORE.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESLOGIC.Logic
{
    public class ProductoService : IProductoService
    {
        private readonly MarketDbContext _marketDbContex;

        public ProductoService(MarketDbContext marketDbContex)
        {
            _marketDbContex = marketDbContex;
        }
        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _marketDbContex.Producto
                .Include(p => p.Marca)
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            return await _marketDbContex.Producto
                .Include(p => p.Marca)
                .Include(p => p.Categoria)
                .ToListAsync();
        }
    }
}
