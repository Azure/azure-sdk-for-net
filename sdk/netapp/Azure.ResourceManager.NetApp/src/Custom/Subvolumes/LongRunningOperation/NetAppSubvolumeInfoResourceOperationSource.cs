// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.NetApp
{
    /// <summary></summary>
    [Obsolete("This type is obsolete and will be removed in a future version.")]
    internal partial class NetAppSubvolumeInfoResourceOperationSource : IOperationSource<NetAppSubvolumeInfoResource>
    {
        private readonly ArmClient _client;

        /// <summary></summary>
        /// <param name="client"></param>
        internal NetAppSubvolumeInfoResourceOperationSource(ArmClient client)
        {
            _client = client;
        }

        /// <param name="response"> The response from the service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        NetAppSubvolumeInfoResource IOperationSource<NetAppSubvolumeInfoResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            NetAppSubvolumeInfoData data = NetAppSubvolumeInfoData.DeserializeNetAppSubvolumeInfoData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new NetAppSubvolumeInfoResource(_client, data);
        }

        /// <param name="response"> The response from the service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        async ValueTask<NetAppSubvolumeInfoResource> IOperationSource<NetAppSubvolumeInfoResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            NetAppSubvolumeInfoData data = NetAppSubvolumeInfoData.DeserializeNetAppSubvolumeInfoData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new NetAppSubvolumeInfoResource(_client, data);
        }
    }
}
