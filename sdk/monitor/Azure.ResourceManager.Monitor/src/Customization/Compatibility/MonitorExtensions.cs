// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Monitor.Mocking;
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
        public static Response<AlertRuleResource> GetAlertRule(this ResourceGroupResource resourceGroupResource, string ruleName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets an alert rule. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <param name="ruleName"> The rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The alert rule resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
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
        public static Response<DiagnosticSettingsCategoryResource> GetDiagnosticSettingsCategory(this ArmClient client, ResourceIdentifier scope, string name, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the diagnostic settings category. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope of the resource collection to get. </param>
        /// <param name="name"> The diagnostic settings category name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The diagnostic settings category resource. </returns>
        [Obsolete("This API is no longer supported.", false)]
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
        public static Response<MonitorWorkspaceResource> GetMonitorWorkspaceResource(this ResourceGroupResource resourceGroupResource, string azureMonitorWorkspaceName, CancellationToken cancellationToken = default) => throw new NotSupportedException("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.");

        /// <summary> Gets a MonitorWorkspace resource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <param name="azureMonitorWorkspaceName"> The Azure Monitor workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The MonitorWorkspace resource. </returns>
        [Obsolete("This API has moved to Azure.ResourceManager.Monitor.Workspaces. Use Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceResource, Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceCollection, or Azure.ResourceManager.Monitor.Workspaces.MonitorWorkspaceData instead.", false)]
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
            => GetMockableArmClient(resourceGroupResource).GetActionGroups(resourceGroupResource.Id);

        /// <summary> Gets an action group in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<ActionGroupResource> GetActionGroup(this ResourceGroupResource resourceGroupResource, string actionGroupName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetActionGroup(resourceGroupResource.Id, actionGroupName, cancellationToken);

        /// <summary> Gets an action group in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<ActionGroupResource>> GetActionGroupAsync(this ResourceGroupResource resourceGroupResource, string actionGroupName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetActionGroupAsync(resourceGroupResource.Id, actionGroupName, cancellationToken);

        /// <summary> Gets a collection of activity log alerts in the resource group. </summary>
        public static ActivityLogAlertCollection GetActivityLogAlerts(this ResourceGroupResource resourceGroupResource)
            => GetMockableArmClient(resourceGroupResource).GetActivityLogAlerts(resourceGroupResource.Id);

        /// <summary> Gets an activity log alert in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<ActivityLogAlertResource> GetActivityLogAlert(this ResourceGroupResource resourceGroupResource, string activityLogAlertName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetActivityLogAlert(resourceGroupResource.Id, activityLogAlertName, cancellationToken);

        /// <summary> Gets an activity log alert in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<ActivityLogAlertResource>> GetActivityLogAlertAsync(this ResourceGroupResource resourceGroupResource, string activityLogAlertName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetActivityLogAlertAsync(resourceGroupResource.Id, activityLogAlertName, cancellationToken);

        /// <summary> Gets a collection of autoscale settings in the resource group. </summary>
        public static AutoscaleSettingCollection GetAutoscaleSettings(this ResourceGroupResource resourceGroupResource)
            => GetMockableArmClient(resourceGroupResource).GetAutoscaleSettings(resourceGroupResource.Id);

        /// <summary> Gets an autoscale setting in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<AutoscaleSettingResource> GetAutoscaleSetting(this ResourceGroupResource resourceGroupResource, string autoscaleSettingName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetAutoscaleSetting(resourceGroupResource.Id, autoscaleSettingName, cancellationToken);

        /// <summary> Gets an autoscale setting in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<AutoscaleSettingResource>> GetAutoscaleSettingAsync(this ResourceGroupResource resourceGroupResource, string autoscaleSettingName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetAutoscaleSettingAsync(resourceGroupResource.Id, autoscaleSettingName, cancellationToken);

        /// <summary> Gets a collection of data collection endpoints in the resource group. </summary>
        public static DataCollectionEndpointCollection GetDataCollectionEndpoints(this ResourceGroupResource resourceGroupResource)
            => GetMockableArmClient(resourceGroupResource).GetDataCollectionEndpoints(resourceGroupResource.Id);

        /// <summary> Gets a data collection endpoint in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<DataCollectionEndpointResource> GetDataCollectionEndpoint(this ResourceGroupResource resourceGroupResource, string dataCollectionEndpointName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetDataCollectionEndpoint(resourceGroupResource.Id, dataCollectionEndpointName, cancellationToken);

        /// <summary> Gets a data collection endpoint in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<DataCollectionEndpointResource>> GetDataCollectionEndpointAsync(this ResourceGroupResource resourceGroupResource, string dataCollectionEndpointName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetDataCollectionEndpointAsync(resourceGroupResource.Id, dataCollectionEndpointName, cancellationToken);

        /// <summary> Gets a collection of data collection rules in the resource group. </summary>
        public static DataCollectionRuleCollection GetDataCollectionRules(this ResourceGroupResource resourceGroupResource)
            => GetMockableArmClient(resourceGroupResource).GetDataCollectionRules(resourceGroupResource.Id);

        /// <summary> Gets a data collection rule in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<DataCollectionRuleResource> GetDataCollectionRule(this ResourceGroupResource resourceGroupResource, string dataCollectionRuleName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetDataCollectionRule(resourceGroupResource.Id, dataCollectionRuleName, cancellationToken);

        /// <summary> Gets a data collection rule in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<DataCollectionRuleResource>> GetDataCollectionRuleAsync(this ResourceGroupResource resourceGroupResource, string dataCollectionRuleName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetDataCollectionRuleAsync(resourceGroupResource.Id, dataCollectionRuleName, cancellationToken);

        /// <summary> Gets a collection of metric alerts in the resource group. </summary>
        public static MetricAlertCollection GetMetricAlerts(this ResourceGroupResource resourceGroupResource)
            => GetMockableArmClient(resourceGroupResource).GetMetricAlerts(resourceGroupResource.Id);

        /// <summary> Gets a metric alert in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<MetricAlertResource> GetMetricAlert(this ResourceGroupResource resourceGroupResource, string ruleName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetMetricAlert(resourceGroupResource.Id, ruleName, cancellationToken);

        /// <summary> Gets a metric alert in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<MetricAlertResource>> GetMetricAlertAsync(this ResourceGroupResource resourceGroupResource, string ruleName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetMetricAlertAsync(resourceGroupResource.Id, ruleName, cancellationToken);

        /// <summary> Gets a collection of monitor private link scopes in the resource group. </summary>
        public static MonitorPrivateLinkScopeCollection GetMonitorPrivateLinkScopes(this ResourceGroupResource resourceGroupResource)
            => GetMockableArmClient(resourceGroupResource).GetMonitorPrivateLinkScopes(resourceGroupResource.Id);

        /// <summary> Gets a monitor private link scope in the resource group. </summary>
        [ForwardsClientCalls]
        public static Response<MonitorPrivateLinkScopeResource> GetMonitorPrivateLinkScope(this ResourceGroupResource resourceGroupResource, string scopeName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetMonitorPrivateLinkScope(resourceGroupResource.Id, scopeName, cancellationToken);

        /// <summary> Gets a monitor private link scope in the resource group. </summary>
        [ForwardsClientCalls]
        public static Task<Response<MonitorPrivateLinkScopeResource>> GetMonitorPrivateLinkScopeAsync(this ResourceGroupResource resourceGroupResource, string scopeName, CancellationToken cancellationToken = default)
            => GetMockableArmClient(resourceGroupResource).GetMonitorPrivateLinkScopeAsync(resourceGroupResource.Id, scopeName, cancellationToken);
    }
}
