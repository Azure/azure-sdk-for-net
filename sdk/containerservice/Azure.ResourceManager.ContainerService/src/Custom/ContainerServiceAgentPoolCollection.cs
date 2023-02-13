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

namespace Azure.ResourceManager.ContainerService
{
    /// <summary>
    /// A class representing a collection of <see cref="ContainerServiceAgentPoolResource" /> and their operations.
    /// Each <see cref="ContainerServiceAgentPoolResource" /> in the collection will belong to the same instance of <see cref="ContainerServiceManagedClusterResource" />.
    /// To get a <see cref="ContainerServiceAgentPoolCollection" /> instance call the GetContainerServiceAgentPools method from an instance of <see cref="ContainerServiceManagedClusterResource" />.
    /// </summary>
    public partial class ContainerServiceAgentPoolCollection : ArmCollection, IEnumerable<ContainerServiceAgentPoolResource>, IAsyncEnumerable<ContainerServiceAgentPoolResource>
    {
        /// <summary>
        /// Creates or updates an agent pool in the specified managed cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}
        /// Operation Id: AgentPools_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="agentPoolName"> The name of the agent pool. </param>
        /// <param name="data"> The agent pool to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ContainerServiceAgentPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string agentPoolName, ContainerServiceAgentPoolData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agentPoolName, nameof(agentPoolName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _containerServiceAgentPoolAgentPoolsClientDiagnostics.CreateScope("ContainerServiceAgentPoolCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                using var message = _containerServiceAgentPoolAgentPoolsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, agentPoolName, data);
                var response = await _containerServiceAgentPoolAgentPoolsRestClient.CreateOrUpdateAsync(message, cancellationToken).ConfigureAwait(false);
                var operation = new ContainerServiceArmOperation<ContainerServiceAgentPoolResource>(new ContainerServiceAgentPoolOperationSource(Client), _containerServiceAgentPoolAgentPoolsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
        /// Creates or updates an agent pool in the specified managed cluster.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{resourceName}/agentPools/{agentPoolName}
        /// Operation Id: AgentPools_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="agentPoolName"> The name of the agent pool. </param>
        /// <param name="data"> The agent pool to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="agentPoolName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="agentPoolName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ContainerServiceAgentPoolResource> CreateOrUpdate(WaitUntil waitUntil, string agentPoolName, ContainerServiceAgentPoolData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(agentPoolName, nameof(agentPoolName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _containerServiceAgentPoolAgentPoolsClientDiagnostics.CreateScope("ContainerServiceAgentPoolCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                using var message = _containerServiceAgentPoolAgentPoolsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, agentPoolName, data);
                var response = _containerServiceAgentPoolAgentPoolsRestClient.CreateOrUpdate(message, cancellationToken);
                var operation = new ContainerServiceArmOperation<ContainerServiceAgentPoolResource>(new ContainerServiceAgentPoolOperationSource(Client), _containerServiceAgentPoolAgentPoolsClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location, "2017-08-31");
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
