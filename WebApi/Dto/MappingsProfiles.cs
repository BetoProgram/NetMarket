using AutoMapper;
using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class MappingsProfiles:Profile
    {
        public MappingsProfiles()
        {
            CreateMap<Producto, ProductoDto>();
        }
    }
}
