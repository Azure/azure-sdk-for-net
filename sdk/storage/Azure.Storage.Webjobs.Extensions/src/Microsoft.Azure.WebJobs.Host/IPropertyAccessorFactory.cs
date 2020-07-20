// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;

namespace Microsoft.Azure.WebJobs.Host
{
    internal interface IPropertyAccessorFactory<TReflected>
    {
        IPropertyGetter<TReflected, TProperty> CreateGetter<TProperty>(PropertyInfo property);

        IPropertySetter<TReflected, TProperty> CreateSetter<TProperty>(PropertyInfo property);
    }
}
