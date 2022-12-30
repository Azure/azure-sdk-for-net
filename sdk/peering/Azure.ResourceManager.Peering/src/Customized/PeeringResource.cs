// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Peering.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Peering
{
    /// <summary>
    /// A Class representing a Peering along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="PeeringResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetPeeringResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetPeering method.
    /// </summary>
    public partial class PeeringResource : ArmResource
    {
        /// <summary>
        /// Lists the prefixes received over the specified peering under the given subscription and resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Peering/peerings/{peeringName}/receivedRoutes
        /// Operation Id: ReceivedRoutes_ListByPeering
        /// </summary>
        /// <param name="prefix"> The optional prefix that can be used to filter the routes. </param>
        /// <param name="asPath"> The optional AS path that can be used to filter the routes. </param>
        /// <param name="originAsValidationState"> The optional origin AS validation state that can be used to filter the routes. </param>
        /// <param name="rpkiValidationState"> The optional RPKI validation state that can be used to filter the routes. </param>
        /// <param name="skipToken"> The optional page continuation token that is used in the event of paginated result. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PeeringReceivedRoute" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PeeringReceivedRoute> GetReceivedRoutesAsync(string prefix = null, string asPath = null, string originAsValidationState = null, string rpkiValidationState = null, string skipToken = null, CancellationToken cancellationToken = default) =>
            GetReceivedRoutesAsync(new PeeringResourceGetReceivedRoutesOptions
            {
                Prefix = prefix,
                AsPath = asPath,
                OriginAsValidationState = originAsValidationState,
                RpkiValidationState = rpkiValidationState,
                SkipToken = skipToken
            }, cancellationToken);

        /// <summary>
        /// Lists the prefixes received over the specified peering under the given subscription and resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Peering/peerings/{peeringName}/receivedRoutes
        /// Operation Id: ReceivedRoutes_ListByPeering
        /// </summary>
        /// <param name="prefix"> The optional prefix that can be used to filter the routes. </param>
        /// <param name="asPath"> The optional AS path that can be used to filter the routes. </param>
        /// <param name="originAsValidationState"> The optional origin AS validation state that can be used to filter the routes. </param>
        /// <param name="rpkiValidationState"> The optional RPKI validation state that can be used to filter the routes. </param>
        /// <param name="skipToken"> The optional page continuation token that is used in the event of paginated result. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PeeringReceivedRoute" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PeeringReceivedRoute> GetReceivedRoutes(string prefix = null, string asPath = null, string originAsValidationState = null, string rpkiValidationState = null, string skipToken = null, CancellationToken cancellationToken = default) =>
            GetReceivedRoutes(new PeeringResourceGetReceivedRoutesOptions
            {
                Prefix = prefix,
                AsPath = asPath,
                OriginAsValidationState = originAsValidationState,
                RpkiValidationState = rpkiValidationState,
                SkipToken = skipToken
            }, cancellationToken);
    }
}
