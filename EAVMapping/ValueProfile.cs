using AutoMapper;
using Models;
using System;

namespace Breeze.MVC.Mapping
{
    public class ValueProfile: Profile
    {
        protected override void Configure()
        {
            CreateMap<int, GenericObjectData>().ForMember(god => god.IntValue, opt => opt.MapFrom(src => src));
            CreateMap<double, GenericObjectData>().ForMember(god => god.NumberValue, opt => opt.MapFrom(src => src));
            CreateMap<string, GenericObjectData>().ForMember(god => god.StringValue, opt => opt.MapFrom(src => src));
            CreateMap<DateTime, GenericObjectData>().ForMember(god => god.DateValue, opt => opt.MapFrom(src => src));
            CreateMap<bool, GenericObjectData>().ForMember(god => god.BoolValue, opt => opt.MapFrom(src => src));
        }
    }
}