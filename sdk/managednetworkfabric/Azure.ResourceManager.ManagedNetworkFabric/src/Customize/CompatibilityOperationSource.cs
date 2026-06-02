// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    internal class CompatibilityOperationSource<TResource, TData> : IOperationSource<TResource>
    {
        private readonly ArmClient _client;
        private readonly Func<JsonElement, ModelReaderWriterOptions, TData> _deserialize;
        private readonly Func<ArmClient, TData, TResource> _createResource;

        public CompatibilityOperationSource(ArmClient client, Func<JsonElement, ModelReaderWriterOptions, TData> deserialize, Func<ArmClient, TData, TResource> createResource)
        {
            _client = client;
            _deserialize = deserialize;
            _createResource = createResource;
        }

        TResource IOperationSource<TResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            return _createResource(_client, _deserialize(document.RootElement, ModelSerializationExtensions.WireOptions));
        }

        async ValueTask<TResource> IOperationSource<TResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return _createResource(_client, _deserialize(document.RootElement, ModelSerializationExtensions.WireOptions));
        }
    }
}
