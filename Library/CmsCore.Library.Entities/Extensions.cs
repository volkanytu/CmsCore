using System;
using System.ComponentModel;
using System.Reflection;

namespace CmsCore.Library.Entities
{
    public static class Extensions
    {
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null) return value.ToString();

            var field = type.GetField(name);
            if (field == null) return value.ToString();

            var attr =field.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attr != null ? attr.Description : value.ToString();
        }
    }
}