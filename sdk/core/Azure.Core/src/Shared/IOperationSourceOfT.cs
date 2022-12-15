// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
#pragma warning disable SA1649 // File name should match first type name
    internal interface IOperationSource<T>
#pragma warning restore SA1649
    {
        T CreateResult(Response response, CancellationToken cancellationToken);
        ValueTask<T> CreateResultAsync(Response response, CancellationToken cancellationToken);
    }
}
