// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618

using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility operation source for BGP route operations that preserve the obsolete PeerRouteList return shape. </summary>
    internal partial class IDictionaryOfStringIListOfPeerRouteListOperationSource : IOperationSource<IDictionary<string, IList<PeerRouteList>>>
    {
        /// <summary> Initializes a new instance of <see cref="IDictionaryOfStringIListOfPeerRouteListOperationSource"/>. </summary>
        internal IDictionaryOfStringIListOfPeerRouteListOperationSource()
        {
        }

        /// <param name="response"> The response from the service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The BGP route operation result. </returns>
        IDictionary<string, IList<PeerRouteList>> IOperationSource<IDictionary<string, IList<PeerRouteList>>>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            IDictionary<string, IList<PeerRouteList>> value = default;
            if (document.RootElement.ValueKind != JsonValueKind.Null)
            {
                Dictionary<string, IList<PeerRouteList>> valueResult = new Dictionary<string, IList<PeerRouteList>>();
                foreach (JsonProperty valueResultProperty in document.RootElement.EnumerateObject())
                {
                    List<PeerRouteList> valueResultValue = new List<PeerRouteList>();
                    foreach (JsonElement valueResultValueElement in valueResultProperty.Value.EnumerateArray())
                    {
                        valueResultValue.Add(PeerRouteList.DeserializePeerRouteList(valueResultValueElement, ModelSerializationExtensions.WireOptions));
                    }
                    valueResult.Add(valueResultProperty.Name, valueResultValue);
                }
                value = valueResult;
            }
            return value;
        }

        /// <param name="response"> The response from the service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The BGP route operation result. </returns>
        async ValueTask<IDictionary<string, IList<PeerRouteList>>> IOperationSource<IDictionary<string, IList<PeerRouteList>>>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            IDictionary<string, IList<PeerRouteList>> value = default;
            if (document.RootElement.ValueKind != JsonValueKind.Null)
            {
                Dictionary<string, IList<PeerRouteList>> valueResult = new Dictionary<string, IList<PeerRouteList>>();
                foreach (JsonProperty valueResultProperty in document.RootElement.EnumerateObject())
                {
                    List<PeerRouteList> valueResultValue = new List<PeerRouteList>();
                    foreach (JsonElement valueResultValueElement in valueResultProperty.Value.EnumerateArray())
                    {
                        valueResultValue.Add(PeerRouteList.DeserializePeerRouteList(valueResultValueElement, ModelSerializationExtensions.WireOptions));
                    }
                    valueResult.Add(valueResultProperty.Name, valueResultValue);
                }
                value = valueResult;
            }
            return value;
        }
    }
}
