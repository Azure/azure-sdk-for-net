// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Host
{
    internal class StructPropertySetter<TReflected, TProperty> : IPropertySetter<TReflected, TProperty>
        where TReflected : struct
    {
        private readonly PropertySetterDelegate _setter;

        private StructPropertySetter(PropertySetterDelegate setter)
        {
            Debug.Assert(setter != null);
            _setter = setter;
        }

        private delegate void PropertySetterDelegate(ref TReflected instance, TProperty value);

        public void SetValue(ref TReflected instance, TProperty value)
        {
            _setter.Invoke(ref instance, value);
        }

        public static StructPropertySetter<TReflected, TProperty> Create(PropertyInfo property)
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

            if (!property.CanWrite)
            {
                throw new ArgumentException("The property must be writable.", nameof(property));
            }

            if (property.GetIndexParameters().Length != 0)
            {
                throw new ArgumentException("The property must not have index parameters.", nameof(property));
            }

            MethodInfo setMethod = property.SetMethod;
            Debug.Assert(setMethod != null);
            if (setMethod.IsStatic)
            {
                throw new ArgumentException("The property must not be static.", nameof(property));
            }

            Debug.Assert(setMethod.ReflectedType == typeof(TReflected));
            Debug.Assert(setMethod.ReflectedType.IsValueType);
            Debug.Assert(setMethod.GetParameters().Length == 1);
            Debug.Assert(setMethod.GetParameters()[0].ParameterType == typeof(TProperty));
            Debug.Assert(setMethod.ReturnType == typeof(void));
            PropertySetterDelegate setter =
                (PropertySetterDelegate)setMethod.CreateDelegate(typeof(PropertySetterDelegate));
            return new StructPropertySetter<TReflected, TProperty>(setter);
        }
    }
}