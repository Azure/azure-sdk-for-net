// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing a collection of <see cref="IpamPoolResource"/> and their operations.
    /// Each <see cref="IpamPoolResource"/> in the collection will belong to the same instance of <see cref="NetworkManagerResource"/>.
    /// To get an <see cref="IpamPoolCollection"/> instance call the GetIpamPools method from an instance of <see cref="NetworkManagerResource"/>.
    /// </summary>
    public partial class IpamPoolCollection : ArmCollection, IEnumerable<IpamPoolResource>, IAsyncEnumerable<IpamPoolResource>
    {
        /// <summary>
        /// Creates/Updates the Pool resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkManagers/{networkManagerName}/ipamPools/{poolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>IpamPools_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IpamPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="poolName"> IP Address Manager Pool resource name. </param>
        /// <param name="data"> Pool resource object to create/update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="poolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="poolName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<IpamPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string poolName, IpamPoolData data, CancellationToken cancellationToken)
            => await CreateOrUpdateAsync(waitUntil, poolName, data, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates/Updates the Pool resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkManagers/{networkManagerName}/ipamPools/{poolName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>IpamPools_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-05-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="IpamPoolResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="poolName"> IP Address Manager Pool resource name. </param>
        /// <param name="data"> Pool resource object to create/update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="poolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="poolName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<IpamPoolResource> CreateOrUpdate(WaitUntil waitUntil, string poolName, IpamPoolData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, poolName, data, null, cancellationToken);
    }
}
