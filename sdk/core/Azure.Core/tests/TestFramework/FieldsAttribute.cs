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

        public FieldsAttribute()
        {
        }

        public FieldsAttribute(params string[] names)
        {
            _names = names;
        }

        public IEnumerable GetData(IParameterInfo parameter)
        {
            Type type = parameter.ParameterType;
            if (type.IsValueType)
            {
                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
                for (int i = 0; i < fields.Length; ++i)
                {
                    FieldInfo field = fields[i];
                    if (field.FieldType == type && Contains(field.Name))
                    {
                        yield return field.GetValue(null);
                    }
                }
            }
        }

        private bool Contains(string name)
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
    }
}
