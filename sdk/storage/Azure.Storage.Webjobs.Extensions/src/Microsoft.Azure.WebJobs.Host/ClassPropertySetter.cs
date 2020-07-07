// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Host
{
    internal class ClassPropertySetter<TReflected, TProperty> : IPropertySetter<TReflected, TProperty>
        where TReflected : class
    {
        private readonly PropertySetterDelegate _setter;

        private ClassPropertySetter(PropertySetterDelegate setter)
        {
            Debug.Assert(setter != null);
            _setter = setter;
        }

        private delegate void PropertySetterDelegate(TReflected instance, TProperty value);

        public void SetValue(ref TReflected instance, TProperty value)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            _setter.Invoke(instance, value);
        }

        public static ClassPropertySetter<TReflected, TProperty> Create(PropertyInfo property)
        {
            if (property == null)
            {
                throw new ArgumentNullException("property");
            }

            if (typeof(TReflected) != property.ReflectedType)
            {
                throw new ArgumentException("The property's ReflectedType must exactly match TReflected.", "property");
            }

            if (typeof(TProperty) != property.PropertyType)
            {
                throw new ArgumentException("The property's PropertyType must exactly match TProperty.", "property");
            }

            if (!property.CanWrite)
            {
                throw new ArgumentException("The property must be writable.", "property");
            }

            if (property.GetIndexParameters().Length != 0)
            {
                throw new ArgumentException("The property must not have index parameters.", "property");
            }

            MethodInfo setMethod = property.SetMethod;
            Debug.Assert(setMethod != null);

            if (setMethod.IsStatic)
            {
                throw new ArgumentException("The property must not be static.", "property");
            }

            Debug.Assert(setMethod.ReflectedType == typeof(TReflected));
            Debug.Assert(!setMethod.ReflectedType.IsValueType);
            Debug.Assert(setMethod.GetParameters().Length == 1);
            Debug.Assert(setMethod.GetParameters()[0].ParameterType == typeof(TProperty));
            Debug.Assert(setMethod.ReturnType == typeof(void));

            PropertySetterDelegate setter =
                (PropertySetterDelegate)setMethod.CreateDelegate(typeof(PropertySetterDelegate));

            return new ClassPropertySetter<TReflected, TProperty>(setter);
        }
    }
}
