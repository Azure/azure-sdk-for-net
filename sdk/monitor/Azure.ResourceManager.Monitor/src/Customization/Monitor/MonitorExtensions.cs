// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Monitor
{
    public static partial class MonitorExtensions
    {
        /// <summary> Gets an object representing a <see cref="MonitorWorkspaceResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MonitorWorkspaceResource"/> object. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MonitorWorkspaceResource GetMonitorWorkspaceResource(this ArmClient client, ResourceIdentifier id) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets a collection of <see cref="MonitorWorkspaceResource"/> objects in the resource group. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <returns> Returns a collection of <see cref="MonitorWorkspaceResource"/> objects. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MonitorWorkspaceResourceCollection GetMonitorWorkspaceResources(this ResourceGroupResource resourceGroupResource) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets all MonitorWorkspace resources in a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MonitorWorkspaceResource"/> objects. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<MonitorWorkspaceResource> GetMonitorWorkspaceResources(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets all MonitorWorkspace resources in a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MonitorWorkspaceResource"/> objects. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<MonitorWorkspaceResource> GetMonitorWorkspaceResourcesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets a MonitorWorkspace resource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <param name="azureMonitorWorkspaceName"> The Azure Monitor workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The MonitorWorkspace resource. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<MonitorWorkspaceResource> GetMonitorWorkspaceResource(this ResourceGroupResource resourceGroupResource, string azureMonitorWorkspaceName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets a MonitorWorkspace resource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <param name="azureMonitorWorkspaceName"> The Azure Monitor workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The MonitorWorkspace resource. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<MonitorWorkspaceResource>> GetMonitorWorkspaceResourceAsync(this ResourceGroupResource resourceGroupResource, string azureMonitorWorkspaceName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");
    }
}
