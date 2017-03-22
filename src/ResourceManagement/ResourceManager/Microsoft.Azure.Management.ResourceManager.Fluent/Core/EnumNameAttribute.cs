// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public class EnumNameAttribute : Attribute
    {
        private string name;

        public EnumNameAttribute(string name)
        {
            this.name = name;
        }

        public static string GetName(Enum value)
        {
            Type enumType = value.GetType();
            FieldInfo fieldInfo = enumType.GetRuntimeField(value.ToString());
            EnumNameAttribute attribute = fieldInfo
                .GetCustomAttributes(typeof(EnumNameAttribute), false)
                .FirstOrDefault() as EnumNameAttribute;
            if (attribute == null)
            {
                throw new ArgumentException("Expected attribute EnumName not found for " + value.ToString());
            }
            return attribute.name;
        }

        public static T FromName<T>(string name)
        {
            Type enumType = typeof(T);
            foreach (var fieldInfo in enumType.GetRuntimeFields())
            {
                foreach (var custom in fieldInfo.CustomAttributes)
                {
                    if (custom.AttributeType == typeof(EnumNameAttribute)
                        && ((string)custom.ConstructorArguments.First().Value).Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        return (T)Enum.Parse(enumType, fieldInfo.Name);
                    }
                }
            }
            throw new ArgumentException("An enum with EnumName attribute " + name + " not found");
        }
    }
}
