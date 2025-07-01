// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing a collection of <see cref="NetworkCloudBareMetalMachineKeySetResource"/> and their operations.
    /// Each <see cref="NetworkCloudBareMetalMachineKeySetResource"/> in the collection will belong to the same instance of <see cref="NetworkCloudClusterResource"/>.
    /// To get a <see cref="NetworkCloudBareMetalMachineKeySetCollection"/> instance call the GetNetworkCloudBareMetalMachineKeySets method from an instance of <see cref="NetworkCloudClusterResource"/>.
    /// </summary>
    public partial class NetworkCloudBareMetalMachineKeySetCollection : ArmCollection, IEnumerable<NetworkCloudBareMetalMachineKeySetResource>, IAsyncEnumerable<NetworkCloudBareMetalMachineKeySetResource>
    {
        /// <summary>
        /// Create a new bare metal machine key set or update the existing one for the provided cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/clusters/{clusterName}/bareMetalMachineKeySets/{bareMetalMachineKeySetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BareMetalMachineKeySets_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBareMetalMachineKeySetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="bareMetalMachineKeySetName"> The name of the bare metal machine key set. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="bareMetalMachineKeySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="bareMetalMachineKeySetName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NetworkCloudBareMetalMachineKeySetResource> CreateOrUpdate(WaitUntil waitUntil, string bareMetalMachineKeySetName, NetworkCloudBareMetalMachineKeySetData data, CancellationToken cancellationToken)            => CreateOrUpdate(waitUntil, bareMetalMachineKeySetName, data, null, null, cancellationToken);

        /// <summary>
        /// Create a new bare metal machine key set or update the existing one for the provided cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/clusters/{clusterName}/bareMetalMachineKeySets/{bareMetalMachineKeySetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BareMetalMachineKeySets_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudBareMetalMachineKeySetResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="bareMetalMachineKeySetName"> The name of the bare metal machine key set. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="bareMetalMachineKeySetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="bareMetalMachineKeySetName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NetworkCloudBareMetalMachineKeySetResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string bareMetalMachineKeySetName, NetworkCloudBareMetalMachineKeySetData data, CancellationToken cancellationToken)            => await CreateOrUpdateAsync(waitUntil, bareMetalMachineKeySetName, data, null, null, cancellationToken).ConfigureAwait(false);
    }
}
