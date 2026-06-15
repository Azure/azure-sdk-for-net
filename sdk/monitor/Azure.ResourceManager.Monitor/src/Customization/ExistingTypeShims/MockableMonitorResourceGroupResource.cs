// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // This file intentionally exposes obsolete removed-type compatibility signatures.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Monitor.Mocking
{
    public partial class MockableMonitorResourceGroupResource
    {
        /// <summary> Gets a collection of <see cref="AlertRuleResource"/> objects in the resource group. </summary>
        /// <returns> Returns a collection of <see cref="AlertRuleResource"/> objects. </returns>
        [Obsolete("This API is no longer supported.", false)]
        public virtual AlertRuleCollection GetAlertRules() => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an alert rule. </summary>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [ForwardsClientCalls]
        public virtual Response<AlertRuleResource> GetAlertRule(string ruleName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an alert rule. </summary>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [ForwardsClientCalls]
        public virtual Task<Response<AlertRuleResource>> GetAlertRuleAsync(string ruleName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a collection of <see cref="MonitorWorkspaceResource"/> objects in the resource group. </summary>
        /// <returns> Returns a collection of <see cref="MonitorWorkspaceResource"/> objects. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        public virtual MonitorWorkspaceResourceCollection GetMonitorWorkspaceResources() => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets a MonitorWorkspace resource. </summary>
        /// <param name="azureMonitorWorkspaceName"> The Azure Monitor workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The MonitorWorkspace resource. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [ForwardsClientCalls]
        public virtual Response<MonitorWorkspaceResource> GetMonitorWorkspaceResource(string azureMonitorWorkspaceName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets a MonitorWorkspace resource. </summary>
        /// <param name="azureMonitorWorkspaceName"> The Azure Monitor workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The MonitorWorkspace resource. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [ForwardsClientCalls]
        public virtual Task<Response<MonitorWorkspaceResource>> GetMonitorWorkspaceResourceAsync(string azureMonitorWorkspaceName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        private ResourceGroupResource ResourceGroup => Client.GetResourceGroupResource(Id);

        /// <summary> Sends test notifications. </summary>
        public virtual ArmOperation<NotificationStatus> CreateNotifications(WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Sends test notifications. </summary>
        public virtual Task<ArmOperation<NotificationStatus>> CreateNotificationsAsync(WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a collection of action groups in the resource group. </summary>
        public virtual ActionGroupCollection GetActionGroups() => MonitorExtensions.GetActionGroups(ResourceGroup);

        /// <summary> Gets an action group in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Response<ActionGroupResource> GetActionGroup(string actionGroupName, CancellationToken cancellationToken = default) => MonitorExtensions.GetActionGroup(ResourceGroup, actionGroupName, cancellationToken);

        /// <summary> Gets an action group in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<ActionGroupResource>> GetActionGroupAsync(string actionGroupName, CancellationToken cancellationToken = default) => MonitorExtensions.GetActionGroupAsync(ResourceGroup, actionGroupName, cancellationToken);

        /// <summary> Gets a collection of activity log alerts in the resource group. </summary>
        public virtual ActivityLogAlertCollection GetActivityLogAlerts() => MonitorExtensions.GetActivityLogAlerts(ResourceGroup);

        /// <summary> Gets an activity log alert in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Response<ActivityLogAlertResource> GetActivityLogAlert(string activityLogAlertName, CancellationToken cancellationToken = default) => MonitorExtensions.GetActivityLogAlert(ResourceGroup, activityLogAlertName, cancellationToken);

        /// <summary> Gets an activity log alert in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<ActivityLogAlertResource>> GetActivityLogAlertAsync(string activityLogAlertName, CancellationToken cancellationToken = default) => MonitorExtensions.GetActivityLogAlertAsync(ResourceGroup, activityLogAlertName, cancellationToken);

        /// <summary> Gets a collection of autoscale settings in the resource group. </summary>
        public virtual AutoscaleSettingCollection GetAutoscaleSettings() => MonitorExtensions.GetAutoscaleSettings(ResourceGroup);

        /// <summary> Gets an autoscale setting in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Response<AutoscaleSettingResource> GetAutoscaleSetting(string autoscaleSettingName, CancellationToken cancellationToken = default) => MonitorExtensions.GetAutoscaleSetting(ResourceGroup, autoscaleSettingName, cancellationToken);

        /// <summary> Gets an autoscale setting in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<AutoscaleSettingResource>> GetAutoscaleSettingAsync(string autoscaleSettingName, CancellationToken cancellationToken = default) => MonitorExtensions.GetAutoscaleSettingAsync(ResourceGroup, autoscaleSettingName, cancellationToken);

        /// <summary> Gets a collection of data collection endpoints in the resource group. </summary>
        public virtual DataCollectionEndpointCollection GetDataCollectionEndpoints() => MonitorExtensions.GetDataCollectionEndpoints(ResourceGroup);

        /// <summary> Gets a data collection endpoint in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Response<DataCollectionEndpointResource> GetDataCollectionEndpoint(string dataCollectionEndpointName, CancellationToken cancellationToken = default) => MonitorExtensions.GetDataCollectionEndpoint(ResourceGroup, dataCollectionEndpointName, cancellationToken);

        /// <summary> Gets a data collection endpoint in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<DataCollectionEndpointResource>> GetDataCollectionEndpointAsync(string dataCollectionEndpointName, CancellationToken cancellationToken = default) => MonitorExtensions.GetDataCollectionEndpointAsync(ResourceGroup, dataCollectionEndpointName, cancellationToken);

        /// <summary> Gets a collection of data collection rules in the resource group. </summary>
        public virtual DataCollectionRuleCollection GetDataCollectionRules() => MonitorExtensions.GetDataCollectionRules(ResourceGroup);

        /// <summary> Gets a data collection rule in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Response<DataCollectionRuleResource> GetDataCollectionRule(string dataCollectionRuleName, CancellationToken cancellationToken = default) => MonitorExtensions.GetDataCollectionRule(ResourceGroup, dataCollectionRuleName, cancellationToken);

        /// <summary> Gets a data collection rule in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<DataCollectionRuleResource>> GetDataCollectionRuleAsync(string dataCollectionRuleName, CancellationToken cancellationToken = default) => MonitorExtensions.GetDataCollectionRuleAsync(ResourceGroup, dataCollectionRuleName, cancellationToken);

        /// <summary> Gets a collection of metric alerts in the resource group. </summary>
        public virtual MetricAlertCollection GetMetricAlerts() => MonitorExtensions.GetMetricAlerts(ResourceGroup);

        /// <summary> Gets a metric alert in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Response<MetricAlertResource> GetMetricAlert(string ruleName, CancellationToken cancellationToken = default) => MonitorExtensions.GetMetricAlert(ResourceGroup, ruleName, cancellationToken);

        /// <summary> Gets a metric alert in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MetricAlertResource>> GetMetricAlertAsync(string ruleName, CancellationToken cancellationToken = default) => MonitorExtensions.GetMetricAlertAsync(ResourceGroup, ruleName, cancellationToken);

        /// <summary> Gets a collection of monitor private link scopes in the resource group. </summary>
        public virtual MonitorPrivateLinkScopeCollection GetMonitorPrivateLinkScopes() => MonitorExtensions.GetMonitorPrivateLinkScopes(ResourceGroup);

        /// <summary> Gets a monitor private link scope in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Response<MonitorPrivateLinkScopeResource> GetMonitorPrivateLinkScope(string scopeName, CancellationToken cancellationToken = default) => MonitorExtensions.GetMonitorPrivateLinkScope(ResourceGroup, scopeName, cancellationToken);

        /// <summary> Gets a monitor private link scope in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MonitorPrivateLinkScopeResource>> GetMonitorPrivateLinkScopeAsync(string scopeName, CancellationToken cancellationToken = default) => MonitorExtensions.GetMonitorPrivateLinkScopeAsync(ResourceGroup, scopeName, cancellationToken);

        /// <summary> Gets notification status. </summary>
        public virtual Response<NotificationStatus> GetNotificationStatus(string notificationId, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets notification status. </summary>
        public virtual Task<Response<NotificationStatus>> GetNotificationStatusAsync(string notificationId, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets private link scope operation status. </summary>
        public virtual Response<MonitorPrivateLinkScopeOperationStatus> GetPrivateLinkScopeOperationStatus(string asyncOperationId, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets private link scope operation status. </summary>
        public virtual Task<Response<MonitorPrivateLinkScopeOperationStatus>> GetPrivateLinkScopeOperationStatusAsync(string asyncOperationId, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a collection of scheduled query rules in the resource group. </summary>
        public virtual ScheduledQueryRuleCollection GetScheduledQueryRules() => MonitorExtensions.GetScheduledQueryRules(ResourceGroup);

        /// <summary> Gets a scheduled query rule in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Response<ScheduledQueryRuleResource> GetScheduledQueryRule(string ruleName, CancellationToken cancellationToken = default) => MonitorExtensions.GetScheduledQueryRule(ResourceGroup, ruleName, cancellationToken);

        /// <summary> Gets a scheduled query rule in the resource group. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<ScheduledQueryRuleResource>> GetScheduledQueryRuleAsync(string ruleName, CancellationToken cancellationToken = default) => MonitorExtensions.GetScheduledQueryRuleAsync(ResourceGroup, ruleName, cancellationToken);
    }
}
