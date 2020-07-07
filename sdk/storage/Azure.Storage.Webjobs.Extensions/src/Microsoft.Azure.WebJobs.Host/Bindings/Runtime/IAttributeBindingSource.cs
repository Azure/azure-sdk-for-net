// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Runtime
{
    internal interface IAttributeBindingSource
    {
        AmbientBindingContext AmbientBindingContext { get; }

        Task<IBinding> BindAsync<TValue>(Attribute attribute, Attribute[] additionalAttributes = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
