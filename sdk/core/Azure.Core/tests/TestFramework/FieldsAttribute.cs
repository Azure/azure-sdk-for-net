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
        public FieldsAttribute()
        {
        }

        public IEnumerable GetData(IParameterInfo parameter)
        {
            Type type = parameter.ParameterType;
            if (type.IsValueType)
            {
                FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
                for (int i = 0; i < fields.Length; ++i)
                {
                    if (fields[i].FieldType == type)
                    {
                        yield return fields[i].GetValue(null);
                    }
                }
            }
        }
    }
}
