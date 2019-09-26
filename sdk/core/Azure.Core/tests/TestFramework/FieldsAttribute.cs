// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Reflection;
using NUnit.Framework.Interfaces;

namespace Azure.Core.Testing
{
    /// <summary>
    /// Provides values to NUnit that are public, static, read-only fields of the declared type.
    /// Use this in place of ValuesAttribute for enum-like structs.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class FieldsAttribute : Attribute, IParameterDataSource
    {
        private readonly string[] _names;

        /// <summary>
        /// Creates a new instance of the <see cref="FieldsAttribute"/> class.
        /// All public, static, read-only fields of the declared type are included.
        /// </summary>
        public FieldsAttribute()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="FieldsAttribute"/> class.
        /// Only public, static, read-only fields of the declared type with any of the specified <paramref name="names"/> are included.
        /// </summary>
        public FieldsAttribute(params string[] names)
        {
            _names = names;
        }

        /// <summary>
        /// Gets or sets a list of field names to exclude. Fields names specified here will be excluded even if specified in the <see cref="FieldsAttribute(string[])"/> constructor.
        /// </summary>
        public string[] Exclude { get; set; }

        public IEnumerable GetData(IParameterInfo parameter)
        {
            Type type = parameter.ParameterType;
            if (type.IsValueType)
            {
                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
                for (int i = 0; i < fields.Length; ++i)
                {
                    FieldInfo field = fields[i];
                    if (field.FieldType == type && Includes(field.Name) && !Excludes(field.Name))
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
