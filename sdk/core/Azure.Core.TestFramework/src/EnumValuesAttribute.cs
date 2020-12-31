// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.Core.TestFramework
{
    /// <summary>
    /// Provides values to NUnit that are public, static, read-only fields and properties of the declared type.
    /// Use this in place of ValuesAttribute for enum-like structs.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class EnumValuesAttribute : Attribute, IParameterDataSource
    {
        private readonly string[] _names;

        /// <summary>
        /// Creates a new instance of the <see cref="EnumValuesAttribute"/> class.
        /// All public, static, read-only fields and properties of the declared type are included.
        /// </summary>
        public EnumValuesAttribute()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="EnumValuesAttribute"/> class.
        /// Only public, static, read-only fields and properties of the declared type with any of the specified <paramref name="names"/> are included.
        /// </summary>
        public EnumValuesAttribute(params string[] names)
        {
            _names = names;
        }

        /// <summary>
        /// Gets or sets a list of field and properties names to exclude. Field and property names specified here will be excluded even if specified in the <see cref="EnumValuesAttribute(string[])"/> constructor.
        /// </summary>
        public string[] Exclude { get; set; }

        public IEnumerable GetData(IParameterInfo parameter) => GetMembers(parameter.ParameterType, parameter.ParameterInfo?.Name);

        public IEnumerable<object> GetMembers(Type parameterType, string parameterName)
        {
            object[] data = GetMembersImpl(parameterType).ToArray();
            if (data is null || data.Length == 0)
            {
                // NUnit handles this exception specifically to mark the test as failed or, in some cases, skipped.
                throw new InvalidDataSourceException(@$"No enumeration members found on parameter ""{parameterName}"".");
            }

            return data;
        }

        private IEnumerable<object> GetMembersImpl(Type type)
        {
            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;

            if (type.IsValueType)
            {
                PropertyInfo[] properties = type.GetProperties(bindingFlags);
                for (int i = 0; i < properties.Length; ++i)
                {
                    PropertyInfo property = properties[i];
                    if (property.PropertyType == type && property.CanRead && !property.CanWrite && Includes(property.Name) && !Excludes(property.Name))
                    {
                        yield return property.GetValue(null);
                    }
                }

                FieldInfo[] fields = type.GetFields(bindingFlags);
                for (int i = 0; i < fields.Length; ++i)
                {
                    FieldInfo field = fields[i];
                    if (field.FieldType == type && (field.IsInitOnly || field.IsLiteral) && Includes(field.Name) && !Excludes(field.Name))
                    {
                        yield return field.GetValue(null);
                    }
                }
            }
        }

        private bool Includes(string name)
        {
            if (_names is null || _names.Length == 0)
            {
                return true;
            }

            for (int i = 0; i < _names.Length; ++i)
            {
                if (string.Equals(_names[i], name, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        private bool Excludes(string name)
        {
            if (Exclude != null)
            {
                for (int i = 0; i < Exclude.Length; ++i)
                {
                    if (string.Equals(Exclude[i], name, StringComparison.Ordinal))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
