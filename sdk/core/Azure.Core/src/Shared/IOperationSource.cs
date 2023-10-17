// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal interface IOperationSource<T>
    {
        T CreateResult(Response response, CancellationToken cancellationToken);
        ValueTask<T> CreateResultAsync(Response response, CancellationToken cancellationToken);
    }
}
