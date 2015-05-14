﻿using System;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;

namespace JP.ExamSystem.ExamServer
{
    public class AssemblyQualifiedTypeNameConverter : ConfigurationConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string typeName = (string)value;
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            Type result = Type.GetType(typeName, false);
            if (result == null)
            {
                throw new ArgumentException(string.Format("不能加载类型\"{0}\"", typeName));
            }
            return result;
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            Type type = value as Type;
            if (null == type)
            {
                throw new ArgumentNullException("value");
            }
            return type.AssemblyQualifiedName;
        }
    }
}
