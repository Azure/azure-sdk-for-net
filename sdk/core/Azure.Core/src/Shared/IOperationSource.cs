// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal interface IOperationSource<T>
    {
        [RequiresDynamicCode("This method uses reflection.")]
        [RequiresUnreferencedCode("This method uses reflection.")]
        T CreateResult(Response response, CancellationToken cancellationToken);

        [RequiresDynamicCode("This method uses reflection.")]
        [RequiresUnreferencedCode("This method uses reflection.")]
        ValueTask<T> CreateResultAsync(Response response, CancellationToken cancellationToken);
    }
}
