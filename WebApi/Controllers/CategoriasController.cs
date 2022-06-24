﻿using CORE.Entities;
using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IGenericRepository<Categoria> _categoriaService;

        public CategoriasController(IGenericRepository<Categoria> categoriaService)
        {
            _categoriaService = categoriaService;
        }
        
        // GET: api/<CategoriasController>
        [HttpGet]
        public async Task<ActionResult<Categoria>> GetCategorias()
        {
            return Ok(await _categoriaService.GetAllAsync());
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategorias(int id)
        {
            return Ok(await _categoriaService.GetByIdAsync(id));
        }
    }
}