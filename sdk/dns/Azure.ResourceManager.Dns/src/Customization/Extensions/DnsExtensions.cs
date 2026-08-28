// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Dns
{
    public static partial class DnsExtensions
    {
        /// <summary> Lists the DNS zones in all resource groups in a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="top"> The maximum number of DNS zones to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="DnsZoneResource"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<DnsZoneResource> GetDnsZonesAsync(this SubscriptionResource subscriptionResource, int? top = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableDnsSubscriptionResource(subscriptionResource).GetDnsZonesAsync(top, cancellationToken);
        }

        /// <summary> Lists the DNS zones in all resource groups in a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="top"> The maximum number of DNS zones to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        /// <returns> A collection of <see cref="DnsZoneResource"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<DnsZoneResource> GetDnsZones(this SubscriptionResource subscriptionResource, int? top = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableDnsSubscriptionResource(subscriptionResource).GetDnsZones(top, cancellationToken);
        }
    }
}
