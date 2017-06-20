// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public static class EnumHelper
    {
        public static string ToEnumMemberSerializationValue(Enum enumValue)
        {
            Type enumType = enumValue.GetType();
            FieldInfo fieldInfo = enumType.GetRuntimeField(enumValue.ToString());
            System.Runtime.Serialization.EnumMemberAttribute attribute = fieldInfo
                .GetCustomAttributes(typeof(System.Runtime.Serialization.EnumMemberAttribute), false)
                .FirstOrDefault() as System.Runtime.Serialization.EnumMemberAttribute;
            if (attribute == null)
            {
                throw new ArgumentException("Expected attribute System.Runtime.Serialization.EnumMemberAttribute not found for " + enumValue.ToString());
            }
            return attribute.Value;
        }

        public static T FromEnumMemberSerializationValue<T>(string enumSerialzationValue)
        {
            Type enumType = typeof(T);
            foreach (var fieldInfo in enumType.GetRuntimeFields())
            {
                foreach (var custom in fieldInfo.CustomAttributes)
                {
                    if (custom.AttributeType == typeof(System.Runtime.Serialization.EnumMemberAttribute)
                        && ((string)custom.NamedArguments.First().TypedValue.Value).Equals(enumSerialzationValue, StringComparison.OrdinalIgnoreCase))
                    {
                        return (T)Enum.Parse(enumType, fieldInfo.Name);
                    }
                }
            }
            throw new ArgumentException("An enum with System.Runtime.Serialization.EnumMemberAttribute " + enumSerialzationValue + " not found");
        }
    }
}

