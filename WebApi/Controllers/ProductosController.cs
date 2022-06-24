using AutoMapper;
using CORE.Entities;
using CORE.Interfaces;
using CORE.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IGenericRepository<Producto> _productoService;
        private readonly IMapper _mapper;

        public ProductosController(IGenericRepository<Producto> productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> GetProductos() {
            var spec = new ProductoWithCategoriaAndMarcaSpecification();
            var productos = await _productoService.GetAllWithSpec(spec);
            return Ok(_mapper.Map<List<ProductoDto>>(productos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProductos(int id)
        {
            var spec = new ProductoWithCategoriaAndMarcaSpecification(id);
            var producto = await _productoService.GetByIdWithSpec(spec);
            return Ok(_mapper.Map<ProductoDto>(producto));
        }

    }
}
