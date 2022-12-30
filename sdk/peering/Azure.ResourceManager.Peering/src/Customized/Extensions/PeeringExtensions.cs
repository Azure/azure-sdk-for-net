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
    /// <summary> A class to add extension methods to Azure.ResourceManager.Peering. </summary>
    public static partial class PeeringExtensions
    {
        /// <summary>
        /// Lists all of the legacy peerings under the given subscription matching the specified kind and location.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Peering/legacyPeerings
        /// Operation Id: LegacyPeerings_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="peeringLocation"> The location of the peering. </param>
        /// <param name="kind"> The kind of the peering. </param>
        /// <param name="asn"> The ASN number associated with a legacy peering. </param>
        /// <param name="directPeeringType"> The direct peering type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="peeringLocation"/> is null. </exception>
        /// <returns> An async collection of <see cref="PeeringResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<PeeringResource> GetPeeringsByLegacyPeeringAsync(this SubscriptionResource subscriptionResource, string peeringLocation, LegacyPeeringsKind kind, int? asn = null, DirectPeeringType? directPeeringType = null, CancellationToken cancellationToken = default) =>
            GetPeeringsByLegacyPeeringAsync(subscriptionResource, new PeeringExtensionsGetPeeringsByLegacyPeeringOptions(peeringLocation, kind)
            {
                Asn = asn,
                DirectPeeringType = directPeeringType
            }, cancellationToken);

        /// <summary>
        /// Lists all of the legacy peerings under the given subscription matching the specified kind and location.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Peering/legacyPeerings
        /// Operation Id: LegacyPeerings_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="peeringLocation"> The location of the peering. </param>
        /// <param name="kind"> The kind of the peering. </param>
        /// <param name="asn"> The ASN number associated with a legacy peering. </param>
        /// <param name="directPeeringType"> The direct peering type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="peeringLocation"/> is null. </exception>
        /// <returns> A collection of <see cref="PeeringResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<PeeringResource> GetPeeringsByLegacyPeering(this SubscriptionResource subscriptionResource, string peeringLocation, LegacyPeeringsKind kind, int? asn = null, DirectPeeringType? directPeeringType = null, CancellationToken cancellationToken = default) =>
            GetPeeringsByLegacyPeering(subscriptionResource, new PeeringExtensionsGetPeeringsByLegacyPeeringOptions(peeringLocation, kind)
            {
                Asn = asn,
                DirectPeeringType = directPeeringType
            }, cancellationToken);

        /// <summary>
        /// Run looking glass functionality
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Peering/lookingGlass
        /// Operation Id: LookingGlass_Invoke
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="command"> The command to be executed: ping, traceroute, bgpRoute. </param>
        /// <param name="sourceType"> The type of the source: Edge site or Azure Region. </param>
        /// <param name="sourceLocation"> The location of the source. </param>
        /// <param name="destinationIP"> The IP address of the destination. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceLocation"/> or <paramref name="destinationIP"/> is null. </exception>
        public static async Task<Response<LookingGlassOutput>> InvokeLookingGlassAsync(this SubscriptionResource subscriptionResource, LookingGlassCommand command, LookingGlassSourceType sourceType, string sourceLocation, string destinationIP, CancellationToken cancellationToken = default) =>
            await InvokeLookingGlassAsync(subscriptionResource, new PeeringExtensionsInvokeLookingGlassOptions(command, sourceType, sourceLocation, destinationIP), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Run looking glass functionality
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Peering/lookingGlass
        /// Operation Id: LookingGlass_Invoke
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="command"> The command to be executed: ping, traceroute, bgpRoute. </param>
        /// <param name="sourceType"> The type of the source: Edge site or Azure Region. </param>
        /// <param name="sourceLocation"> The location of the source. </param>
        /// <param name="destinationIP"> The IP address of the destination. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceLocation"/> or <paramref name="destinationIP"/> is null. </exception>
        public static Response<LookingGlassOutput> InvokeLookingGlass(this SubscriptionResource subscriptionResource, LookingGlassCommand command, LookingGlassSourceType sourceType, string sourceLocation, string destinationIP, CancellationToken cancellationToken = default) =>
            InvokeLookingGlass(subscriptionResource, new PeeringExtensionsInvokeLookingGlassOptions(command, sourceType, sourceLocation, destinationIP), cancellationToken);
    }
}
