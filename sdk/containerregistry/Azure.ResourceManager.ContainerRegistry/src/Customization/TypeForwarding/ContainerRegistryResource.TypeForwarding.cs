using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerRegistry
{
    public partial class ContainerRegistryResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryAgentPoolCollection GetContainerRegistryAgentPools()
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return ContainerRegistryTasksExtensions.GetContainerRegistryAgentPools(resourceGroup, Data.Name);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryRunCollection GetContainerRegistryRuns()
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return ContainerRegistryTasksExtensions.GetContainerRegistryRuns(resourceGroup, Data.Name);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskRunCollection GetContainerRegistryTaskRuns()
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return ContainerRegistryTasksExtensions.GetContainerRegistryTaskRuns(resourceGroup, Data.Name);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ContainerRegistryTaskCollection GetContainerRegistryTasks()
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return ContainerRegistryTasksExtensions.GetContainerRegistryTasks(resourceGroup, Data.Name);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ContainerRegistryRunResource>> ScheduleRunAsync(WaitUntil waitUntil, ContainerRegistryRunContent content, CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return await ContainerRegistryTasksExtensions.ScheduleRunAsync(resourceGroup, waitUntil, Data.Name, content, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ContainerRegistryRunResource> ScheduleRun(WaitUntil waitUntil, ContainerRegistryRunContent content, CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return ContainerRegistryTasksExtensions.ScheduleRun(resourceGroup, waitUntil, Data.Name, content, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SourceUploadDefinition>> GetBuildSourceUploadUrlAsync(CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return await ContainerRegistryTasksExtensions.GetBuildSourceUploadUrlAsync(resourceGroup, Data.Name, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SourceUploadDefinition> GetBuildSourceUploadUrl(CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}"));
            return ContainerRegistryTasksExtensions.GetBuildSourceUploadUrl(resourceGroup, Data.Name, cancellationToken);
        }
    }
}
