using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Specifications
{
    public class ProductoWithCategoriaAndMarcaSpecification: BaseSpecification<Producto>
    {
        public ProductoWithCategoriaAndMarcaSpecification()
        {
            AddIncludes(p => p.Categoria);
            AddIncludes(p => p.Marca);
        }
        public ProductoWithCategoriaAndMarcaSpecification(int id): base(x => x.Id == id) {
            AddIncludes(p => p.Categoria);
            AddIncludes(p => p.Marca);
        }
        
    }
}
