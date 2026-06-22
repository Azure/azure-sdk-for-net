// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;

namespace Azure.ResourceManager.Dns.Mocking
{
    public partial class MockableDnsSubscriptionResource
    {
        /// <summary> Lists the DNS zones in all resource groups in a subscription. </summary>
        /// <param name="top"> The maximum number of DNS zones to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DnsZoneResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DnsZoneResource> GetDnsZonesAsync(int? top = default, CancellationToken cancellationToken = default)
            => GetAllAsync(top, cancellationToken);

        /// <summary> Lists the DNS zones in all resource groups in a subscription. </summary>
        /// <param name="top"> The maximum number of DNS zones to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DnsZoneResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DnsZoneResource> GetDnsZones(int? top = default, CancellationToken cancellationToken = default)
            => GetAll(top, cancellationToken);
    }
}
