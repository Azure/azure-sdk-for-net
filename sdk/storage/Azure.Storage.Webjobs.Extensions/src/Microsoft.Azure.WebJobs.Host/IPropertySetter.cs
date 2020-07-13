// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Host
{
    internal interface IPropertySetter<TReflected, TProperty>
    {
        void SetValue(ref TReflected instance, TProperty value);
    }
}
