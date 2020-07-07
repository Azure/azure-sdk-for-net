// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Reflection;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Data
{
    internal interface IDataArgumentBindingProvider<TBindingData>
    {
        IArgumentBinding<TBindingData> TryCreate(ParameterInfo parameter);
    }
}
