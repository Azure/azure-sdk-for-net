// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Dns
{
    public partial class DnsZoneCollection
    {
        // This method is added to meet the api compatibility requirement for the existing method CreateOrUpdate(string, DnsZoneData, ETag?, string, CancellationToken) in DnsZoneCollection. The existing method is not following the standard pattern for accepting MatchConditions and it is causing confusion for the users. This new method follows the standard pattern and accepts MatchConditions as a parameter. The existing method will be marked as obsolete in the future and will call this new method internally to avoid breaking changes for the users.
        /// <summary>
        /// Creates or updates a DNS zone. Does not modify DNS records within the zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DnsZoneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new DNS zone to be created, but to prevent updating an existing zone. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsZoneResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string zoneName, DnsZoneData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, zoneName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = ifNoneMatch != null ? new ETag(ifNoneMatch) : default(ETag?) }, cancellationToken).ConfigureAwait(false);

        // This method is added to meet the api compatibility requirement for the existing method CreateOrUpdate(string, DnsZoneData, ETag?, string, CancellationToken) in DnsZoneCollection. The existing method is not following the standard pattern for accepting MatchConditions and it is causing confusion for the users. This new method follows the standard pattern and accepts MatchConditions as a parameter. The existing method will be marked as obsolete in the future and will call this new method internally to avoid breaking changes for the users.
        /// <summary>
        /// Creates or updates a DNS zone. Does not modify DNS records within the zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DnsZoneResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="data"> Parameters supplied to the CreateOrUpdate operation. </param>
        /// <param name="ifMatch"> The etag of the DNS zone. Omit this value to always overwrite the current zone. Specify the last-seen etag value to prevent accidentally overwriting any concurrent changes. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new DNS zone to be created, but to prevent updating an existing zone. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> or <paramref name="data"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsZoneResource> CreateOrUpdate(WaitUntil waitUntil, string zoneName, DnsZoneData data, ETag? ifMatch, string ifNoneMatch = null, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, zoneName, data, new MatchConditions() { IfMatch = ifMatch, IfNoneMatch = ifNoneMatch != null ? new ETag(ifNoneMatch) : default(ETag?) }, cancellationToken);
    }
}
