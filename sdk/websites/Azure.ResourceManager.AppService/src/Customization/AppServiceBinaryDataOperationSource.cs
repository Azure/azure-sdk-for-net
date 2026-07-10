// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    internal sealed class AppServiceBinaryDataOperationSource : IOperationSource<BinaryData>
    {
        BinaryData IOperationSource<BinaryData>.CreateResult(Response response, CancellationToken cancellationToken)
            => response.Content;

        ValueTask<BinaryData> IOperationSource<BinaryData>.CreateResultAsync(Response response, CancellationToken cancellationToken)
            => new ValueTask<BinaryData>(response.Content);
    }
}
