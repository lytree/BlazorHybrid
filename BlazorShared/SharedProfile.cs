using AntDesign;
using AntDesign.ProLayout;
using AutoMapper;
using BlazorConfiguration.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared
{
    public class SharedProfile : Profile
    {
        public SharedProfile()
        {
            CreateMap<MenuDto, MenuDataItem>()
                .ForMember("Children", opt => opt.AllowNull());

        }
    }
}
