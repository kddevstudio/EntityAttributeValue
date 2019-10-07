using DTO;
using Models;
using System;
using System.Collections.Generic;

namespace Breeze.MVC.Mapping
{
    public class GadgetProfile : EntityProfile
    {

        public override string ProfileName => "Gadget";

        protected override void Configure()
        {
            CreateMap<GenericObject, Gadget>()
                .ForMember(g => g.GadgetId, opt => opt.MapFrom(src => src.GenericObjectId))
                .ForMember(g => g.Description, ValueSelector("Description"))
                .ForMember(g => g.GadgetInteger, ValueSelector("Gadget Integer"))
                .ForMember(g => g.GadgetDate, ValueSelector("Gadget Date"));

            CreateMap<Gadget, GenericObject>();

            CreateMap<Gadget, Dictionary<string, GenericObjectData>>();

            //CreateMap<int, GenericObjectData>().ForMember(god => god.IntValue, opt => opt.MapFrom(src => src));
            //CreateMap<double, GenericObjectData>().ForMember(god => god.NumberValue, opt => opt.MapFrom(src => src));
            //CreateMap<string, GenericObjectData>().ForMember(god => god.StringValue, opt => opt.MapFrom(src => src));
            //CreateMap<DateTime, GenericObjectData>().ForMember(god => god.DateValue, opt => opt.MapFrom(src => src));
            //CreateMap<bool, GenericObjectData>().ForMember(god => god.BoolValue, opt => opt.MapFrom(src => src));
        }
    }
}