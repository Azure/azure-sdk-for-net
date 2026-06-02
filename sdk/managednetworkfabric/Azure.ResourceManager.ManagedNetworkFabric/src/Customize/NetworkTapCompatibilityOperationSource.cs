// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    internal partial class NetworkTapCompatibilityOperationSource : IOperationSource<NetworkTapResource>
    {
        private readonly ArmClient _client;

        internal NetworkTapCompatibilityOperationSource(ArmClient client)
        {
            _client = client;
        }

        NetworkTapResource IOperationSource<NetworkTapResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            NetworkTapData data = NetworkTapData.DeserializeNetworkTapData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new NetworkTapResource(_client, data);
        }

        async ValueTask<NetworkTapResource> IOperationSource<NetworkTapResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            NetworkTapData data = NetworkTapData.DeserializeNetworkTapData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new NetworkTapResource(_client, data);
        }
    }
}
