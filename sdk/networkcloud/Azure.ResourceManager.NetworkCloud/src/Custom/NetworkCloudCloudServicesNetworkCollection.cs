// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing a collection of <see cref="NetworkCloudCloudServicesNetworkResource"/> and their operations.
    /// Each <see cref="NetworkCloudCloudServicesNetworkResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="NetworkCloudCloudServicesNetworkCollection"/> instance call the GetNetworkCloudCloudServicesNetworks method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class NetworkCloudCloudServicesNetworkCollection : ArmCollection, IEnumerable<NetworkCloudCloudServicesNetworkResource>, IAsyncEnumerable<NetworkCloudCloudServicesNetworkResource>
    {
        /// <summary>
        /// Create a new cloud services network or update the properties of the existing cloud services network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/cloudServicesNetworks/{cloudServicesNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CloudServicesNetworks_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudCloudServicesNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cloudServicesNetworkName"> The name of the cloud services network. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="cloudServicesNetworkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="cloudServicesNetworkName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NetworkCloudCloudServicesNetworkResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string cloudServicesNetworkName, NetworkCloudCloudServicesNetworkData data, CancellationToken cancellationToken)
        {
            return await CreateOrUpdateAsync(waitUntil, cloudServicesNetworkName, data, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new cloud services network or update the properties of the existing cloud services network.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/cloudServicesNetworks/{cloudServicesNetworkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CloudServicesNetworks_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-02-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudCloudServicesNetworkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cloudServicesNetworkName"> The name of the cloud services network. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="cloudServicesNetworkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="cloudServicesNetworkName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NetworkCloudCloudServicesNetworkResource> CreateOrUpdate(WaitUntil waitUntil, string cloudServicesNetworkName, NetworkCloudCloudServicesNetworkData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdate(waitUntil, cloudServicesNetworkName, data, null, null, cancellationToken);
        }
    }
}
