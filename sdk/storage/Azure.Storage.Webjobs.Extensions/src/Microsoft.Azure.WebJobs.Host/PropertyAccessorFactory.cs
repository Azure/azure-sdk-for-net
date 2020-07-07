// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Host
{
    internal static class PropertyAccessorFactory<TReflected>
    {
        private static readonly IPropertyAccessorFactory<TReflected> Singleton = GetInstance();

        public static IPropertyGetter<TReflected, TProperty> CreateGetter<TProperty>(PropertyInfo property)
        {
            return Singleton.CreateGetter<TProperty>(property);
        }

        public static IPropertySetter<TReflected, TProperty> CreateSetter<TProperty>(PropertyInfo property)
        {
            return Singleton.CreateSetter<TProperty>(property);
        }

        private static IPropertyAccessorFactory<TReflected> GetInstance()
        {
            Type instanceTypeDefinition;

            if (!typeof(TReflected).IsValueType)
            {
                instanceTypeDefinition = typeof(ClassPropertyAccessorFactory<>);
            }
            else
            {
                instanceTypeDefinition = typeof(StructPropertyAccessorFactory<>);
            }

            Type instanceType = instanceTypeDefinition.MakeGenericType(typeof(TReflected));
            MethodInfo instancePropertyMethod = instanceType.GetProperty("Instance").GetMethod;
            return (IPropertyAccessorFactory<TReflected>)instancePropertyMethod.Invoke(null, null);
        }
    }
}
