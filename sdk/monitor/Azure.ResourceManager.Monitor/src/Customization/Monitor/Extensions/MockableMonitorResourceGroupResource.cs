// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor.Mocking
{
    public partial class MockableMonitorResourceGroupResource
    {
        /// <summary>
        /// Sends test notifications to a set of provided receivers at resource group scope.
        /// </summary>
        /// <param name="waitUntil">When to wait for completion of the long-running operation.</param>
        /// <param name="content">The notification request body which includes the contact details.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An operation for tracking notification progress.</returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<NotificationStatus>> CreateNotificationsAsync(WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary>
        /// Sends test notifications to a set of provided receivers at resource group scope.
        /// </summary>
        /// <param name="waitUntil">When to wait for completion of the long-running operation.</param>
        /// <param name="content">The notification request body which includes the contact details.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An operation for tracking notification progress.</returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationStatus> CreateNotifications(WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary>
        /// Gets the test notification details at resource group scope by notification ID.
        /// </summary>
        /// <param name="notificationId">The notification ID.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The notification status.</returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<NotificationStatus>> GetNotificationStatusAsync(string notificationId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary>
        /// Gets the test notification details at resource group scope by notification ID.
        /// </summary>
        /// <param name="notificationId">The notification ID.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The notification status.</returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NotificationStatus> GetNotificationStatus(string notificationId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a collection of <see cref="MonitorWorkspaceResource"/> objects in the resource group. </summary>
        /// <returns> Returns a collection of <see cref="MonitorWorkspaceResource"/> objects. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual MonitorWorkspaceResourceCollection GetMonitorWorkspaceResources() => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets a MonitorWorkspace resource. </summary>
        /// <param name="azureMonitorWorkspaceName"> The Azure Monitor workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The MonitorWorkspace resource. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<MonitorWorkspaceResource> GetMonitorWorkspaceResource(string azureMonitorWorkspaceName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets a MonitorWorkspace resource. </summary>
        /// <param name="azureMonitorWorkspaceName"> The Azure Monitor workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The MonitorWorkspace resource. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<MonitorWorkspaceResource>> GetMonitorWorkspaceResourceAsync(string azureMonitorWorkspaceName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");
    }
}
