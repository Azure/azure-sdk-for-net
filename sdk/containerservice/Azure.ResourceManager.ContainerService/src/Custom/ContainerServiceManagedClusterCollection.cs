// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerService
{
    /// <summary>
    /// A class representing a collection of <see cref="ContainerServiceManagedClusterResource" /> and their operations.
    /// Each <see cref="ContainerServiceManagedClusterResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="ContainerServiceManagedClusterCollection" /> instance call the GetContainerServiceManagedClusters method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class ContainerServiceManagedClusterCollection : ArmCollection, IEnumerable<ContainerServiceManagedClusterResource>, IAsyncEnumerable<ContainerServiceManagedClusterResource>
    {
        /// <summary>
        /// Creates or updates a managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resourceName"> The name of the managed cluster resource. </param>
        /// <param name="data"> The managed cluster to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ContainerServiceManagedClusterResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string resourceName, ContainerServiceManagedClusterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _containerServiceManagedClusterManagedClustersRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, resourceName, data, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation<ContainerServiceManagedClusterResource>(new ContainerServiceManagedClusterOperationSource(Client), _containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, resourceName, data).Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates a managed cluster.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedClusters_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resourceName"> The name of the managed cluster resource. </param>
        /// <param name="data"> The managed cluster to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ContainerServiceManagedClusterResource> CreateOrUpdate(WaitUntil waitUntil, string resourceName, ContainerServiceManagedClusterData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _containerServiceManagedClusterManagedClustersClientDiagnostics.CreateScope("ContainerServiceManagedClusterCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _containerServiceManagedClusterManagedClustersRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, resourceName, data, cancellationToken);
                var operation = new ContainerServiceArmOperation<ContainerServiceManagedClusterResource>(new ContainerServiceManagedClusterOperationSource(Client), _containerServiceManagedClusterManagedClustersClientDiagnostics, Pipeline, _containerServiceManagedClusterManagedClustersRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, resourceName, data).Request, response, OperationFinalStateVia.Location, "2017-08-31");
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
