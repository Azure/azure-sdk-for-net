// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.ContainerRegistry.Tasks;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerRegistry
{
    public partial class ContainerRegistryResource
    {
        /// <summary>
        /// x
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryAgentPoolCollection GetContainerRegistryAgentPools()
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return ContainerRegistryTasksExtensions.GetContainerRegistryAgentPools(resourceGroup, Data.Name);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryRunCollection GetContainerRegistryRuns()
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return ContainerRegistryTasksExtensions.GetContainerRegistryRuns(resourceGroup, Data.Name);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskRunCollection GetContainerRegistryTaskRuns()
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return ContainerRegistryTasksExtensions.GetContainerRegistryTaskRuns(resourceGroup, Data.Name);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskCollection GetContainerRegistryTasks()
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return ContainerRegistryTasksExtensions.GetContainerRegistryTasks(resourceGroup, Data.Name);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ContainerRegistryRunResource>> ScheduleRunAsync(WaitUntil waitUntil, ContainerRegistryRunContent content, CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return await ContainerRegistryTasksExtensions.ScheduleRunAsync(resourceGroup, waitUntil, Data.Name, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ContainerRegistryRunResource> ScheduleRun(WaitUntil waitUntil, ContainerRegistryRunContent content, CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return ContainerRegistryTasksExtensions.ScheduleRun(resourceGroup, waitUntil, Data.Name, content, cancellationToken);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SourceUploadDefinition>> GetBuildSourceUploadUrlAsync(CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return await ContainerRegistryTasksExtensions.GetBuildSourceUploadUrlAsync(resourceGroup, Data.Name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SourceUploadDefinition> GetBuildSourceUploadUrl(CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return ContainerRegistryTasksExtensions.GetBuildSourceUploadUrl(resourceGroup, Data.Name, cancellationToken);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <param name="agentPoolName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ContainerRegistryAgentPoolResource>> GetContainerRegistryAgentPoolAsync(string agentPoolName, CancellationToken cancellationToken = default)
        {
            return await GetContainerRegistryAgentPools().GetAsync(agentPoolName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <param name="agentPoolName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ContainerRegistryAgentPoolResource> GetContainerRegistryAgentPool(string agentPoolName, CancellationToken cancellationToken = default)
        {
            return GetContainerRegistryAgentPools().Get(agentPoolName, cancellationToken);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <param name="runId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ContainerRegistryRunResource>> GetContainerRegistryRunAsync(string runId, CancellationToken cancellationToken = default)
        {
            return await GetContainerRegistryRuns().GetAsync(runId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <param name="runId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ContainerRegistryRunResource> GetContainerRegistryRun(string runId, CancellationToken cancellationToken = default)
        {
            return GetContainerRegistryRuns().Get(runId, cancellationToken);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <param name="taskRunName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ContainerRegistryTaskRunResource>> GetContainerRegistryTaskRunAsync(string taskRunName, CancellationToken cancellationToken = default)
        {
            return await GetContainerRegistryTaskRuns().GetAsync(taskRunName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <param name="taskRunName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ContainerRegistryTaskRunResource> GetContainerRegistryTaskRun(string taskRunName, CancellationToken cancellationToken = default)
        {
            return GetContainerRegistryTaskRuns().Get(taskRunName, cancellationToken);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<ContainerRegistryTaskResource>> GetContainerRegistryTaskAsync(string taskName, CancellationToken cancellationToken = default)
        {
            return await GetContainerRegistryTasks().GetAsync(taskName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// x
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<ContainerRegistryTaskResource> GetContainerRegistryTask(string taskName, CancellationToken cancellationToken = default)
        {
            return GetContainerRegistryTasks().Get(taskName, cancellationToken);
        }
    }
}
