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

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing a collection of <see cref="NetworkCloudClusterMetricsConfigurationResource"/> and their operations.
    /// Each <see cref="NetworkCloudClusterMetricsConfigurationResource"/> in the collection will belong to the same instance of <see cref="NetworkCloudClusterResource"/>.
    /// To get a <see cref="NetworkCloudClusterMetricsConfigurationCollection"/> instance call the GetNetworkCloudClusterMetricsConfigurations method from an instance of <see cref="NetworkCloudClusterResource"/>.
    /// </summary>
    public partial class NetworkCloudClusterMetricsConfigurationCollection : ArmCollection, IEnumerable<NetworkCloudClusterMetricsConfigurationResource>, IAsyncEnumerable<NetworkCloudClusterMetricsConfigurationResource>
    {
        /// <summary>
        /// Create new or update the existing metrics configuration of the provided cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/clusters/{clusterName}/metricsConfigurations/{metricsConfigurationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MetricsConfigurations_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudClusterMetricsConfigurationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="metricsConfigurationName"> The name of the metrics configuration for the cluster. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="metricsConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="metricsConfigurationName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NetworkCloudClusterMetricsConfigurationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string metricsConfigurationName, NetworkCloudClusterMetricsConfigurationData data, CancellationToken cancellationToken)
            => await CreateOrUpdateAsync(waitUntil, metricsConfigurationName, data, null, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Create new or update the existing metrics configuration of the provided cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/clusters/{clusterName}/metricsConfigurations/{metricsConfigurationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MetricsConfigurations_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="NetworkCloudClusterMetricsConfigurationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="metricsConfigurationName"> The name of the metrics configuration for the cluster. </param>
        /// <param name="data"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="metricsConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="metricsConfigurationName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NetworkCloudClusterMetricsConfigurationResource> CreateOrUpdate(WaitUntil waitUntil, string metricsConfigurationName, NetworkCloudClusterMetricsConfigurationData data, CancellationToken cancellationToken)
            => CreateOrUpdate(waitUntil, metricsConfigurationName, data, null, null, cancellationToken);
    }
}
