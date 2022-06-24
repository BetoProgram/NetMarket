using CORE.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BUSSINESLOGIC.Data
{
    public class MarketDbData
    {
        public static async Task CargarDataAsync(MarketDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Marca.Any())
                {
                    string marcaData = File.ReadAllText("../BUSSINESLOGIC/Data/CargaInicial/marca.json");
                    var marcas = JsonSerializer.Deserialize<List<Marca>>(marcaData);

                    foreach(var marca in marcas)
                    {
                        context.Marca.Add(marca);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Categoria.Any())
                {
                    string categoriaData = File.ReadAllText("../BUSSINESLOGIC/Data/CargaInicial/categoria.json");
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriaData);

                    foreach (var categoria in categorias)
                    {
                        context.Categoria.Add(categoria);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Producto.Any())
                {
                    string productosData = File.ReadAllText("../BUSSINESLOGIC/Data/CargaInicial/producto.json");
                    var productos = JsonSerializer.Deserialize<List<Producto>>(productosData);

                    foreach (var producto in productos)
                    {
                        context.Producto.Add(producto);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<MarketDbData>();
                logger.LogError(e.Message);
            }
        }
    }
}
