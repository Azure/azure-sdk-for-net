// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Host
{
    internal class StructPropertyGetter<TReflected, TProperty> : IPropertyGetter<TReflected, TProperty>
        where TReflected : struct
    {
        private readonly PropertyGetterDelegate _getter;

        private StructPropertyGetter(PropertyGetterDelegate getter)
        {
            Debug.Assert(getter != null);
            _getter = getter;
        }

        private delegate TProperty PropertyGetterDelegate(ref TReflected instance);

        public TProperty GetValue(TReflected instance)
        {
            return _getter.Invoke(ref instance);
        }

        public static StructPropertyGetter<TReflected, TProperty> Create(PropertyInfo property)
        {
            if (property == null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            if (typeof(TReflected) != property.DeclaringType)
            {
                throw new ArgumentException("The property's ReflectedType must exactly match TReflected.", nameof(property));
            }

            if (typeof(TProperty) != property.PropertyType)
            {
                throw new ArgumentException("The property's PropertyType must exactly match TProperty.", nameof(property));
            }

            if (!property.CanRead)
            {
                throw new ArgumentException("The property must be readable.", nameof(property));
            }

            if (property.GetIndexParameters().Length != 0)
            {
                throw new ArgumentException("The property must not have index parameters.", nameof(property));
            }

            MethodInfo getMethod = property.GetMethod;
            Debug.Assert(getMethod != null);
            if (getMethod.IsStatic)
            {
                throw new ArgumentException("The property must not be static.", nameof(property));
            }

            Debug.Assert(getMethod.ReflectedType == typeof(TReflected));
            Debug.Assert(getMethod.ReflectedType.IsValueType);
            Debug.Assert(getMethod.GetParameters().Length == 0);
            Debug.Assert(getMethod.ReturnType == typeof(TProperty));
            PropertyGetterDelegate getter =
                (PropertyGetterDelegate)getMethod.CreateDelegate(typeof(PropertyGetterDelegate));
            return new StructPropertyGetter<TReflected, TProperty>(getter);
        }
    }
}