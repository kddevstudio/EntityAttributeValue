using AutoMapper;
using Models;
using System;
using System.Linq;

namespace Breeze.MVC.Mapping
{
    public class EntityProfile : Profile
    {
        protected Func<string, Action<IMemberConfigurationExpression<Entity, Boolean, Boolean>>> BoolSelector = (propertyName) => opt =>

            opt.MapFrom(
                wao => wao.Values
                    .Where(d => d.Attribute.Name == propertyName.ToString())
                    .Select(d => d.BoolValue)
                    //d.GenericObjectField.DataType == GenericDataType.Boolean ? d.BoolValue.ToString() :
                    //d.GenericObjectField.DataType == GenericDataType.DateTime ? d.DateValue.ToString() :
                    //d.GenericObjectField.DataType == GenericDataType.Integer ? d.IntValue.ToString() :
                    //d.GenericObjectField.DataType == GenericDataType.Number ? d.NumberValue.ToString() : d.StringValue
                    );
                //.FirstOrDefault()
                //);
    }
}