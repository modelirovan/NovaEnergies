using AutoMapper;
using NovaEnergies.Core.Clients.Responses;
using NovaEnergies.Core.DTOs;
using NovaEnergies.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.Profiles
{
    public  class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RouteDto, Route>();
            CreateMap<PointDto, Point>();
        }
    }
}
