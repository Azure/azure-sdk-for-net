// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // This file intentionally exposes obsolete removed-type compatibility signatures.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Monitor.Mocking;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Monitor
{
    public static partial class MonitorExtensions
    {
        /// <summary> Gets an object representing an <see cref="AlertRuleResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns an <see cref="AlertRuleResource"/> object. </returns>
        [Obsolete("This API is no longer supported.", false)]
        public static AlertRuleResource GetAlertRuleResource(this ArmClient client, ResourceIdentifier id) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a collection of <see cref="AlertRuleResource"/> objects in the resource group. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <returns> Returns a collection of <see cref="AlertRuleResource"/> objects. </returns>
        [Obsolete("This API is no longer supported.", false)]
        public static AlertRuleCollection GetAlertRules(this ResourceGroupResource resourceGroupResource) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets all alert rules in a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AlertRuleResource"/> objects. </returns>
        [Obsolete("This API is no longer supported.", false)]
        public static Pageable<AlertRuleResource> GetAlertRules(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets all alert rules in a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AlertRuleResource"/> objects. </returns>
        [Obsolete("This API is no longer supported.", false)]
        public static AsyncPageable<AlertRuleResource> GetAlertRulesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an alert rule. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [ForwardsClientCalls]
        public static Response<AlertRuleResource> GetAlertRule(this ResourceGroupResource resourceGroupResource, string ruleName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an alert rule. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [ForwardsClientCalls]
        public static Task<Response<AlertRuleResource>> GetAlertRuleAsync(this ResourceGroupResource resourceGroupResource, string ruleName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an object representing a <see cref="DiagnosticSettingsCategoryResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DiagnosticSettingsCategoryResource"/> object. </returns>
        [Obsolete("This API is no longer supported.", false)]
        public static DiagnosticSettingsCategoryResource GetDiagnosticSettingsCategoryResource(this ArmClient client, ResourceIdentifier id) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a collection of <see cref="DiagnosticSettingsCategoryResource"/> objects within the specified scope. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope of the resource collection to get. </param>
        /// <returns> Returns a collection of <see cref="DiagnosticSettingsCategoryResource"/> objects. </returns>
        [Obsolete("This API is no longer supported.", false)]
        public static DiagnosticSettingsCategoryCollection GetDiagnosticSettingsCategories(this ArmClient client, ResourceIdentifier scope) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the diagnostic settings category. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope of the resource collection to get. </param>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic settings category resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [ForwardsClientCalls]
        public static Response<DiagnosticSettingsCategoryResource> GetDiagnosticSettingsCategory(this ArmClient client, ResourceIdentifier scope, string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the diagnostic settings category. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope of the resource collection to get. </param>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic settings category resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
        [ForwardsClientCalls]
        public static Task<Response<DiagnosticSettingsCategoryResource>> GetDiagnosticSettingsCategoryAsync(this ArmClient client, ResourceIdentifier scope, string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an object representing a <see cref="MonitorWorkspaceResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MonitorWorkspaceResource"/> object. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        public static MonitorWorkspaceResource GetMonitorWorkspaceResource(this ArmClient client, ResourceIdentifier id) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets a collection of <see cref="MonitorWorkspaceResource"/> objects in the resource group. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <returns> Returns a collection of <see cref="MonitorWorkspaceResource"/> objects. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        public static MonitorWorkspaceResourceCollection GetMonitorWorkspaceResources(this ResourceGroupResource resourceGroupResource) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets all MonitorWorkspace resources in a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MonitorWorkspaceResource"/> objects. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        public static Pageable<MonitorWorkspaceResource> GetMonitorWorkspaceResources(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets all MonitorWorkspace resources in a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MonitorWorkspaceResource"/> objects. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        public static AsyncPageable<MonitorWorkspaceResource> GetMonitorWorkspaceResourcesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets a MonitorWorkspace resource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <param name="azureMonitorWorkspaceName"> The Azure Monitor workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The MonitorWorkspace resource. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [ForwardsClientCalls]
        public static Response<MonitorWorkspaceResource> GetMonitorWorkspaceResource(this ResourceGroupResource resourceGroupResource, string azureMonitorWorkspaceName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets a MonitorWorkspace resource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <param name="azureMonitorWorkspaceName"> The Azure Monitor workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The MonitorWorkspace resource. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
        [ForwardsClientCalls]
        public static Task<Response<MonitorWorkspaceResource>> GetMonitorWorkspaceResourceAsync(this ResourceGroupResource resourceGroupResource, string azureMonitorWorkspaceName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets an object representing a <see cref="VmInsightsOnboardingStatusResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VmInsightsOnboardingStatusResource"/> object. </returns>
        [Obsolete("This API is no longer supported.", false)]
        public static VmInsightsOnboardingStatusResource GetVmInsightsOnboardingStatusResource(this ArmClient client, ResourceIdentifier id) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an object representing a <see cref="VmInsightsOnboardingStatusResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <returns> Returns a <see cref="VmInsightsOnboardingStatusResource"/> object. </returns>
        [Obsolete("This API is no longer supported.", false)]
        public static VmInsightsOnboardingStatusResource GetVmInsightsOnboardingStatus(this ArmClient client, ResourceIdentifier scope) => throw new NotSupportedException("This API is no longer supported.");

        private static MockableMonitorArmClient GetMockableArmClient(ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return resourceGroupResource.GetCachedClient(client => new MockableMonitorArmClient(client, ResourceIdentifier.Root));
        }

        /// <summary> Gets a collection of action groups in the resource group. </summary>
        public static ActionGroupCollection GetActionGroups(this ResourceGroupResource resourceGroupResource)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an action group in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<ActionGroupResource> GetActionGroup(this ResourceGroupResource resourceGroupResource, string actionGroupName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an action group in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<ActionGroupResource>> GetActionGroupAsync(this ResourceGroupResource resourceGroupResource, string actionGroupName, CancellationToken cancellationToken = default)
            => Task.FromException<Response<ActionGroupResource>>(new NotSupportedException("This API is no longer supported."));

        /// <summary> Gets a collection of activity log alerts in the resource group. </summary>
        public static ActivityLogAlertCollection GetActivityLogAlerts(this ResourceGroupResource resourceGroupResource)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an activity log alert in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<ActivityLogAlertResource> GetActivityLogAlert(this ResourceGroupResource resourceGroupResource, string activityLogAlertName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an activity log alert in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<ActivityLogAlertResource>> GetActivityLogAlertAsync(this ResourceGroupResource resourceGroupResource, string activityLogAlertName, CancellationToken cancellationToken = default)
            => Task.FromException<Response<ActivityLogAlertResource>>(new NotSupportedException("This API is no longer supported."));

        /// <summary> Gets a collection of autoscale settings in the resource group. </summary>
        public static AutoscaleSettingCollection GetAutoscaleSettings(this ResourceGroupResource resourceGroupResource)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an autoscale setting in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<AutoscaleSettingResource> GetAutoscaleSetting(this ResourceGroupResource resourceGroupResource, string autoscaleSettingName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an autoscale setting in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<AutoscaleSettingResource>> GetAutoscaleSettingAsync(this ResourceGroupResource resourceGroupResource, string autoscaleSettingName, CancellationToken cancellationToken = default)
            => Task.FromException<Response<AutoscaleSettingResource>>(new NotSupportedException("This API is no longer supported."));

        /// <summary> Gets a collection of data collection endpoints in the resource group. </summary>
        public static DataCollectionEndpointCollection GetDataCollectionEndpoints(this ResourceGroupResource resourceGroupResource)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a data collection endpoint in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<DataCollectionEndpointResource> GetDataCollectionEndpoint(this ResourceGroupResource resourceGroupResource, string dataCollectionEndpointName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a data collection endpoint in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<DataCollectionEndpointResource>> GetDataCollectionEndpointAsync(this ResourceGroupResource resourceGroupResource, string dataCollectionEndpointName, CancellationToken cancellationToken = default)
            => Task.FromException<Response<DataCollectionEndpointResource>>(new NotSupportedException("This API is no longer supported."));

        /// <summary> Gets a collection of data collection rules in the resource group. </summary>
        public static DataCollectionRuleCollection GetDataCollectionRules(this ResourceGroupResource resourceGroupResource)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a data collection rule in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<DataCollectionRuleResource> GetDataCollectionRule(this ResourceGroupResource resourceGroupResource, string dataCollectionRuleName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a data collection rule in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<DataCollectionRuleResource>> GetDataCollectionRuleAsync(this ResourceGroupResource resourceGroupResource, string dataCollectionRuleName, CancellationToken cancellationToken = default)
            => Task.FromException<Response<DataCollectionRuleResource>>(new NotSupportedException("This API is no longer supported."));

        /// <summary> Gets a collection of metric alerts in the resource group. </summary>
        public static MetricAlertCollection GetMetricAlerts(this ResourceGroupResource resourceGroupResource)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a metric alert in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<MetricAlertResource> GetMetricAlert(this ResourceGroupResource resourceGroupResource, string ruleName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a metric alert in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<MetricAlertResource>> GetMetricAlertAsync(this ResourceGroupResource resourceGroupResource, string ruleName, CancellationToken cancellationToken = default)
            => Task.FromException<Response<MetricAlertResource>>(new NotSupportedException("This API is no longer supported."));

        /// <summary> Gets a collection of monitor private link scopes in the resource group. </summary>
        public static MonitorPrivateLinkScopeCollection GetMonitorPrivateLinkScopes(this ResourceGroupResource resourceGroupResource)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a monitor private link scope in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<MonitorPrivateLinkScopeResource> GetMonitorPrivateLinkScope(this ResourceGroupResource resourceGroupResource, string scopeName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a monitor private link scope in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<MonitorPrivateLinkScopeResource>> GetMonitorPrivateLinkScopeAsync(this ResourceGroupResource resourceGroupResource, string scopeName, CancellationToken cancellationToken = default)
            => Task.FromException<Response<MonitorPrivateLinkScopeResource>>(new NotSupportedException("This API is no longer supported."));

        /// <summary> Sends test notifications. </summary>
        public static ArmOperation<NotificationStatus> CreateNotifications(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Sends test notifications. </summary>
        public static Task<ArmOperation<NotificationStatus>> CreateNotificationsAsync(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Sends test notifications. </summary>
        public static ArmOperation<NotificationStatus> CreateNotifications(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Sends test notifications. </summary>
        public static Task<ArmOperation<NotificationStatus>> CreateNotificationsAsync(this SubscriptionResource subscriptionResource, WaitUntil waitUntil, NotificationContent content, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets activity log events for the subscription. </summary>
        public static Pageable<EventDataInfo> GetActivityLogs(this SubscriptionResource subscriptionResource, string filter, string select, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets activity log events for the subscription. </summary>
        public static AsyncPageable<EventDataInfo> GetActivityLogsAsync(this SubscriptionResource subscriptionResource, string filter, string select, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets event categories for the tenant. </summary>
        public static Pageable<MonitorLocalizableString> GetEventCategories(this TenantResource tenantResource, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets event categories for the tenant. </summary>
        public static AsyncPageable<MonitorLocalizableString> GetEventCategoriesAsync(this TenantResource tenantResource, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metric baselines for a resource. </summary>
        public static Pageable<MonitorSingleMetricBaseline> GetMonitorMetricBaselines(this ArmClient client, ResourceIdentifier scope, ArmResourceGetMonitorMetricBaselinesOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metric baselines for a resource. </summary>
        public static AsyncPageable<MonitorSingleMetricBaseline> GetMonitorMetricBaselinesAsync(this ArmClient client, ResourceIdentifier scope, ArmResourceGetMonitorMetricBaselinesOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metrics for a resource. </summary>
        public static Pageable<MonitorMetric> GetMonitorMetrics(this ArmClient client, ResourceIdentifier scope, ArmResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metrics for a resource. </summary>
        public static AsyncPageable<MonitorMetric> GetMonitorMetricsAsync(this ArmClient client, ResourceIdentifier scope, ArmResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metrics for a subscription. </summary>
        public static Pageable<SubscriptionMonitorMetric> GetMonitorMetrics(this SubscriptionResource subscriptionResource, SubscriptionResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metrics for a subscription. </summary>
        public static AsyncPageable<SubscriptionMonitorMetric> GetMonitorMetricsAsync(this SubscriptionResource subscriptionResource, SubscriptionResourceGetMonitorMetricsOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metrics for a subscription with POST. </summary>
        public static Pageable<SubscriptionMonitorMetric> GetMonitorMetricsWithPost(this SubscriptionResource subscriptionResource, SubscriptionResourceGetMonitorMetricsWithPostOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets metrics for a subscription with POST. </summary>
        public static AsyncPageable<SubscriptionMonitorMetric> GetMonitorMetricsWithPostAsync(this SubscriptionResource subscriptionResource, SubscriptionResourceGetMonitorMetricsWithPostOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets notification status. </summary>
        public static Response<NotificationStatus> GetNotificationStatus(this ResourceGroupResource resourceGroupResource, string notificationId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets notification status. </summary>
        public static Task<Response<NotificationStatus>> GetNotificationStatusAsync(this ResourceGroupResource resourceGroupResource, string notificationId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets notification status. </summary>
        public static Response<NotificationStatus> GetNotificationStatus(this SubscriptionResource subscriptionResource, string notificationId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets notification status. </summary>
        public static Task<Response<NotificationStatus>> GetNotificationStatusAsync(this SubscriptionResource subscriptionResource, string notificationId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets private link scope operation status. </summary>
        public static Response<MonitorPrivateLinkScopeOperationStatus> GetPrivateLinkScopeOperationStatus(this ResourceGroupResource resourceGroupResource, string asyncOperationId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets private link scope operation status. </summary>
        public static Task<Response<MonitorPrivateLinkScopeOperationStatus>> GetPrivateLinkScopeOperationStatusAsync(this ResourceGroupResource resourceGroupResource, string asyncOperationId, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a collection of scheduled query rules in the resource group. </summary>
        public static ScheduledQueryRuleCollection GetScheduledQueryRules(this ResourceGroupResource resourceGroupResource)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a scheduled query rule in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<ScheduledQueryRuleResource> GetScheduledQueryRule(this ResourceGroupResource resourceGroupResource, string ruleName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets a scheduled query rule in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<ScheduledQueryRuleResource>> GetScheduledQueryRuleAsync(this ResourceGroupResource resourceGroupResource, string ruleName, CancellationToken cancellationToken = default)
            => Task.FromException<Response<ScheduledQueryRuleResource>>(new NotSupportedException("This API is no longer supported."));

        /// <summary> Gets tenant activity log events. </summary>
        public static Pageable<EventDataInfo> GetTenantActivityLogs(this TenantResource tenantResource, string filter, string select, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets tenant activity log events. </summary>
        public static AsyncPageable<EventDataInfo> GetTenantActivityLogsAsync(this TenantResource tenantResource, string filter, string select, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported.");
    }
}
