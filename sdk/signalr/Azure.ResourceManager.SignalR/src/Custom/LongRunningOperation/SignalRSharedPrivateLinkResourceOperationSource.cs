// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

// TODO: this class should be removed after codegen fix the LRO issue for multiple path resource https://github.com/Azure/azure-sdk-for-net/issues/54819
namespace Azure.ResourceManager.SignalR
{
    /// <summary></summary>
    internal partial class SignalRSharedPrivateLinkResourceOperationSource : IOperationSource<SignalRSharedPrivateLinkResource>
    {
        private readonly ArmClient _client;

        /// <summary></summary>
        /// <param name="client"></param>
        internal SignalRSharedPrivateLinkResourceOperationSource(ArmClient client)
        {
            _client = client;
        }

        /// <param name="response"> The response from the service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        SignalRSharedPrivateLinkResource IOperationSource<SignalRSharedPrivateLinkResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            SignalRSharedPrivateLinkResourceData data = SignalRSharedPrivateLinkResourceData.DeserializeSignalRSharedPrivateLinkResourceData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new SignalRSharedPrivateLinkResource(_client, data);
        }

        /// <param name="response"> The response from the service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        async ValueTask<SignalRSharedPrivateLinkResource> IOperationSource<SignalRSharedPrivateLinkResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            SignalRSharedPrivateLinkResourceData data = SignalRSharedPrivateLinkResourceData.DeserializeSignalRSharedPrivateLinkResourceData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new SignalRSharedPrivateLinkResource(_client, data);
        }
    }
}
