// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host
{
    internal interface IPropertyGetter<TReflected, TProperty>
    {
        TProperty GetValue(TReflected instance);
    }
}
