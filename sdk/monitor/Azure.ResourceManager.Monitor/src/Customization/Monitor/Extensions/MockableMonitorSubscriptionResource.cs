// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor.Mocking
{
    public partial class MockableMonitorSubscriptionResource
    {
        /// <summary>
        /// Sends test notifications to a set of provided receivers at subscription scope.
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
        /// Sends test notifications to a set of provided receivers at subscription scope.
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
        /// Gets the test notification details at subscription scope by notification ID.
        /// </summary>
        /// <param name="notificationId">The notification ID.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The notification status.</returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<NotificationStatus>> GetNotificationStatusAsync(string notificationId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary>
        /// Gets the test notification details at subscription scope by notification ID.
        /// </summary>
        /// <param name="notificationId">The notification ID.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The notification status.</returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NotificationStatus> GetNotificationStatus(string notificationId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets all MonitorWorkspace resources in a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MonitorWorkspaceResource"/> objects. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<MonitorWorkspaceResource> GetMonitorWorkspaceResources(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets all MonitorWorkspace resources in a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MonitorWorkspaceResource"/> objects. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<MonitorWorkspaceResource> GetMonitorWorkspaceResourcesAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");
    }
}
