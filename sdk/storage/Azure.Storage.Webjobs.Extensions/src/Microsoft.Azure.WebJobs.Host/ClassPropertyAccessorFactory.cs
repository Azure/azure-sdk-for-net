// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Reflection;

namespace Microsoft.Azure.WebJobs.Host
{
    internal class ClassPropertyAccessorFactory<TReflected> : IPropertyAccessorFactory<TReflected>
        where TReflected : class
    {
        private static readonly ClassPropertyAccessorFactory<TReflected> Singleton =
            new ClassPropertyAccessorFactory<TReflected>();

        private ClassPropertyAccessorFactory()
        {
        }

        public static ClassPropertyAccessorFactory<TReflected> Instance
        {
            get { return Singleton; }
        }

        public IPropertyGetter<TReflected, TProperty> CreateGetter<TProperty>(PropertyInfo property)
        {
            return ClassPropertyGetter<TReflected, TProperty>.Create(property);
        }

        public IPropertySetter<TReflected, TProperty> CreateSetter<TProperty>(PropertyInfo property)
        {
            return ClassPropertySetter<TReflected, TProperty>.Create(property);
        }
    }
}
