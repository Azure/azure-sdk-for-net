// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // This file intentionally exposes obsolete removed-type compatibility signatures.

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
        /// <summary> Gets all alert rules in a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AlertRuleResource"/> objects. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<AlertRuleResource> GetAlertRules(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets all alert rules in a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AlertRuleResource"/> objects. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<AlertRuleResource> GetAlertRulesAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

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

        /// <summary> Sends test notifications. </summary>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<NotificationStatus> CreateNotifications(WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Sends test notifications. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API is no longer supported.", false)]
        public virtual Task<ArmOperation<NotificationStatus>> CreateNotificationsAsync(WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets activity logs. </summary>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<EventDataInfo> GetActivityLogs(string filter, string select, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets activity logs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API is no longer supported.", false)]
        public virtual AsyncPageable<EventDataInfo> GetActivityLogsAsync(string filter, string select, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets monitor metrics. </summary>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SubscriptionMonitorMetric> GetMonitorMetrics(SubscriptionResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets monitor metrics. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API is no longer supported.", false)]
        public virtual AsyncPageable<SubscriptionMonitorMetric> GetMonitorMetricsAsync(SubscriptionResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets monitor metrics with POST. </summary>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SubscriptionMonitorMetric> GetMonitorMetricsWithPost(SubscriptionResourceGetMonitorMetricsWithPostOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets monitor metrics with POST. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API is no longer supported.", false)]
        public virtual AsyncPageable<SubscriptionMonitorMetric> GetMonitorMetricsWithPostAsync(SubscriptionResourceGetMonitorMetricsWithPostOptions options, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets notification status. </summary>
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NotificationStatus> GetNotificationStatus(string notificationId, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets notification status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This API is no longer supported.", false)]
        public virtual Task<Response<NotificationStatus>> GetNotificationStatusAsync(string notificationId, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");
    }
}