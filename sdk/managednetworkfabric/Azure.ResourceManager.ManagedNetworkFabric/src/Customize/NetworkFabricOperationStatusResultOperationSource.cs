// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text;
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
            return ModelReaderWriter.Read<NetworkFabricOperationStatusResult>(new BinaryData(Encoding.UTF8.GetBytes(document.RootElement.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerManagedNetworkFabricContext.Default);
        }

        async ValueTask<NetworkFabricOperationStatusResult> IOperationSource<NetworkFabricOperationStatusResult>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return ModelReaderWriter.Read<NetworkFabricOperationStatusResult>(new BinaryData(Encoding.UTF8.GetBytes(document.RootElement.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerManagedNetworkFabricContext.Default);
        }
    }
}
