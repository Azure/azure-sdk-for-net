// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    internal partial class NetworkFabricOperationStatusResultOperationSource : IOperationSource<NetworkFabricOperationStatusResult>
    {
        NetworkFabricOperationStatusResult IOperationSource<NetworkFabricOperationStatusResult>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            return NetworkFabricOperationStatusResult.DeserializeNetworkFabricOperationStatusResult(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        async ValueTask<NetworkFabricOperationStatusResult> IOperationSource<NetworkFabricOperationStatusResult>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return NetworkFabricOperationStatusResult.DeserializeNetworkFabricOperationStatusResult(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
