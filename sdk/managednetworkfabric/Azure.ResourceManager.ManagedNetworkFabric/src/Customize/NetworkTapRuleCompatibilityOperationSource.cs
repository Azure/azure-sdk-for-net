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
    internal partial class NetworkTapRuleCompatibilityOperationSource : IOperationSource<NetworkTapRuleResource>
    {
        private readonly ArmClient _client;

        internal NetworkTapRuleCompatibilityOperationSource(ArmClient client)
        {
            _client = client;
        }

        NetworkTapRuleResource IOperationSource<NetworkTapRuleResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            NetworkTapRuleData data = NetworkTapRuleData.DeserializeNetworkTapRuleData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new NetworkTapRuleResource(_client, data);
        }

        async ValueTask<NetworkTapRuleResource> IOperationSource<NetworkTapRuleResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            NetworkTapRuleData data = NetworkTapRuleData.DeserializeNetworkTapRuleData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new NetworkTapRuleResource(_client, data);
        }
    }
}
