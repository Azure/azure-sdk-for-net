// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Reflection;

namespace Microsoft.Azure.WebJobs.Host
{
    internal interface IPropertyAccessorFactory<TReflected>
    {
        IPropertyGetter<TReflected, TProperty> CreateGetter<TProperty>(PropertyInfo property);

        IPropertySetter<TReflected, TProperty> CreateSetter<TProperty>(PropertyInfo property);
    }
}
