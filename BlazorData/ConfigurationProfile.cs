using AutoMapper;
using BlazorConfiguration.Model.Dto;
using BlazorConfiguration.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<Menu, MenuDto>();

        }
    }
}
