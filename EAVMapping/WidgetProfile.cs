using DTO;
using Models;
using System;
using System.Collections.Generic;

namespace Breeze.MVC.Mapping
{
    public class WidgetProfile : EntityProfile
    {

        public override string ProfileName => "Widget";

        protected override void Configure()
        {
            var widgetMap = CreateMap<GenericObject, Widget>();
            widgetMap.ForAllMembers(m => ValueSelector(nameof(m)));
            widgetMap.ForMember(g => g.WidgetId, opt => opt.MapFrom(src => src.GenericObjectId));

            CreateMap<Widget, GenericObject>();

            CreateMap<Widget, Dictionary<string, GenericObjectData>>();
        }
    }
}