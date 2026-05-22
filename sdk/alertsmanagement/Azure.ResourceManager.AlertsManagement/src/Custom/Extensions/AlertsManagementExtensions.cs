// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AlertsManagement.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertsManagement
{
    // Custom partial of the generator-emitted AlertsManagementExtensions. Two reasons for the
    // additions below:
    //
    //  1. Restore back-compat extension methods that the MPG generator no longer emits:
    //     - GetServiceAlerts(SubscriptionResource) / GetServiceAlertSummary(SubscriptionResource, ...):
    //       In the v1.1.x AutoRest SDK these lived on SubscriptionResource, but the regenerated
    //       TypeSpec spec places the equivalents on ArmClient (scope-based, via
    //       MockableAlertsManagementArmClient). Forwarding wrappers are added here so existing
    //       callers compile unchanged and the published GA binary contract is preserved.
    //
    //  2. Re-expose the AlertProcessingRule* / SmartGroup* / GetServiceAlert(Guid) entry points as
    //     [Obsolete(..., error: true)] / [EditorBrowsable(Never)] stubs throwing NotSupportedException.
    //     - AlertProcessingRule APIs were extracted into the sibling 'Azure.ResourceManager.
    //       AlertProcessingRules' package; SmartGroup APIs are deferred to a future dedicated package;
    //       GetServiceAlert(Guid) was replaced by ArmClient.GetServiceAlertResource(id) /
    //       ServiceAlertCollection.Get(alertId.ToString()) in the new emitter shape.
    //     - Keeping these obsolete stubs satisfies ApiCompat against v1.1.x while compile-time-
    //       redirecting new code to the correct API.
    public static partial class AlertsManagementExtensions
    {
        private const string AlertProcessingRuleRemovedMessage = "The AlertProcessingRule APIs have been moved to the 'Azure.ResourceManager.AlertProcessingRules' package. Reference that package and use the equivalent APIs (e.g., AlertProcessingRulesExtensions, MockableAlertProcessingRulesArmClient, MockableAlertProcessingRulesResourceGroupResource, MockableAlertProcessingRulesSubscriptionResource, ArmAlertProcessingRulesModelFactory) instead.";
        private const string SmartGroupRemovedMessage = "The SmartGroup APIs have been removed from this package and will be shipped in a separate package in a future release.";
        private const string GetServiceAlertGuidReplacedMessage = "Use ArmClient.GetServiceAlertResource(id) or ServiceAlertCollection.Get(alertId.ToString()) instead.";

        private static Mocking.MockableAlertsManagementSubscriptionResource GetMockableAlertsManagementSubscriptionResource(SubscriptionResource subscriptionResource)
        {
            return subscriptionResource.GetCachedClient(client => new Mocking.MockableAlertsManagementSubscriptionResource(client, subscriptionResource.Id));
        }

        /// <summary>
        /// Get a summarized count of your alerts grouped by various parameters (e.g. grouping by &apos;Severity&apos; returns the count of alerts for each severity).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/alertsSummary</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Alerts_GetSummary</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="groupby"> This parameter allows the result set to be grouped by input fields (Maximum 2 comma separated fields supported). For example, groupby=severity or groupby=severity,alertstate. </param>
        /// <param name="includeSmartGroupsCount"> Include count of the SmartGroups as part of the summary. Default value is &apos;false&apos;. </param>
        /// <param name="targetResource"> Filter by target resource( which is full ARM ID) Default value is select all. </param>
        /// <param name="targetResourceType"> Filter by target resource type. Default value is select all. </param>
        /// <param name="targetResourceGroup"> Filter by target resource group name. Default value is select all. </param>
        /// <param name="monitorService"> Filter by monitor service which generates the alert instance. Default value is select all. </param>
        /// <param name="monitorCondition"> Filter by monitor condition which is either &apos;Fired&apos; or &apos;Resolved&apos;. Default value is to select all. </param>
        /// <param name="severity"> Filter by severity.  Default value is select all. </param>
        /// <param name="alertState"> Filter by state of the alert instance. Default value is to select all. </param>
        /// <param name="alertRule"> Filter by specific alert rule.  Default value is to select all. </param>
        /// <param name="timeRange"> Filter by time range by below listed values. Default value is 1 day. </param>
        /// <param name="customTimeRange"> Filter by custom time range in the format &lt;start-time&gt;/&lt;end-time&gt;  where time is in (ISO-8601 format)&apos;. Permissible values is within 30 days from  query time. Either timeRange or customTimeRange could be used but not both. Default is none. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static async Task<Response<ServiceAlertSummary>> GetServiceAlertSummaryAsync(this SubscriptionResource subscriptionResource, AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = null, string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? alertState = null, string alertRule = null, TimeRangeFilter? timeRange = null, string customTimeRange = null, CancellationToken cancellationToken = default)
        {
            return await GetMockableAlertsManagementSubscriptionResource(subscriptionResource).GetServiceAlertSummaryAsync(groupby, includeSmartGroupsCount, targetResource, targetResourceType, targetResourceGroup, monitorService, monitorCondition, severity, alertState, alertRule, timeRange, customTimeRange, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a summarized count of your alerts grouped by various parameters (e.g. grouping by &apos;Severity&apos; returns the count of alerts for each severity).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.AlertsManagement/alertsSummary</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Alerts_GetSummary</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="groupby"> This parameter allows the result set to be grouped by input fields (Maximum 2 comma separated fields supported). For example, groupby=severity or groupby=severity,alertstate. </param>
        /// <param name="includeSmartGroupsCount"> Include count of the SmartGroups as part of the summary. Default value is &apos;false&apos;. </param>
        /// <param name="targetResource"> Filter by target resource( which is full ARM ID) Default value is select all. </param>
        /// <param name="targetResourceType"> Filter by target resource type. Default value is select all. </param>
        /// <param name="targetResourceGroup"> Filter by target resource group name. Default value is select all. </param>
        /// <param name="monitorService"> Filter by monitor service which generates the alert instance. Default value is select all. </param>
        /// <param name="monitorCondition"> Filter by monitor condition which is either &apos;Fired&apos; or &apos;Resolved&apos;. Default value is to select all. </param>
        /// <param name="severity"> Filter by severity.  Default value is select all. </param>
        /// <param name="alertState"> Filter by state of the alert instance. Default value is to select all. </param>
        /// <param name="alertRule"> Filter by specific alert rule.  Default value is to select all. </param>
        /// <param name="timeRange"> Filter by time range by below listed values. Default value is 1 day. </param>
        /// <param name="customTimeRange"> Filter by custom time range in the format &lt;start-time&gt;/&lt;end-time&gt;  where time is in (ISO-8601 format)&apos;. Permissible values is within 30 days from  query time. Either timeRange or customTimeRange could be used but not both. Default is none. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Response<ServiceAlertSummary> GetServiceAlertSummary(this SubscriptionResource subscriptionResource, AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = null, string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? alertState = null, string alertRule = null, TimeRangeFilter? timeRange = null, string customTimeRange = null, CancellationToken cancellationToken = default)
        {
            return GetMockableAlertsManagementSubscriptionResource(subscriptionResource).GetServiceAlertSummary(groupby, includeSmartGroupsCount, targetResource, targetResourceType, targetResourceGroup, monitorService, monitorCondition, severity, alertState, alertRule, timeRange, customTimeRange, cancellationToken);
        }

        /// <summary> Get a summarized count of your alerts grouped by various parameters. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="options"> The options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public static Task<Response<ServiceAlertSummary>> GetServiceAlertSummaryAsync(this SubscriptionResource subscriptionResource, SubscriptionResourceGetServiceAlertSummaryOptions options, CancellationToken cancellationToken = default)
        {
            return GetMockableAlertsManagementSubscriptionResource(subscriptionResource).GetServiceAlertSummaryAsync(options, cancellationToken);
        }

        /// <summary> Get a summarized count of your alerts grouped by various parameters. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="options"> The options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public static Response<ServiceAlertSummary> GetServiceAlertSummary(this SubscriptionResource subscriptionResource, SubscriptionResourceGetServiceAlertSummaryOptions options, CancellationToken cancellationToken = default)
        {
            return GetMockableAlertsManagementSubscriptionResource(subscriptionResource).GetServiceAlertSummary(options, cancellationToken);
        }

        /// <summary> Gets a collection of ServiceAlertCollection in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        public static ServiceAlertCollection GetServiceAlerts(this SubscriptionResource subscriptionResource)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableAlertsManagementSubscriptionResource(subscriptionResource).GetServiceAlerts();
        }

        /// <summary> Gets an alert processing rule resource. </summary>
        /// <param name="client"> The client. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AlertProcessingRuleResource GetAlertProcessingRuleResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets an alert processing rule. </summary>
        /// <param name="resourceGroupResource"> The resource group. </param>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<AlertProcessingRuleResource> GetAlertProcessingRule(this ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets an alert processing rule async. </summary>
        /// <param name="resourceGroupResource"> The resource group. </param>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<AlertProcessingRuleResource>> GetAlertProcessingRuleAsync(this ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets alert processing rules collection. </summary>
        /// <param name="resourceGroupResource"> The resource group. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AlertProcessingRuleCollection GetAlertProcessingRules(this ResourceGroupResource resourceGroupResource) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets all alert processing rules. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<AlertProcessingRuleResource> GetAlertProcessingRules(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets all alert processing rules async. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<AlertProcessingRuleResource> GetAlertProcessingRulesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets a service alert by Guid (use ArmClient.GetServiceAlertResource(id) instead). </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(GetServiceAlertGuidReplacedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<ServiceAlertResource> GetServiceAlert(this SubscriptionResource subscriptionResource, Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(GetServiceAlertGuidReplacedMessage); }

        /// <summary> Gets a service alert by Guid async (use ArmClient.GetServiceAlertResource(id) instead). </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(GetServiceAlertGuidReplacedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<ServiceAlertResource>> GetServiceAlertAsync(this SubscriptionResource subscriptionResource, Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(GetServiceAlertGuidReplacedMessage); }

        /// <summary> Gets a smart group. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SmartGroupResource> GetSmartGroup(this SubscriptionResource subscriptionResource, Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(SmartGroupRemovedMessage); }

        /// <summary> Gets a smart group async. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<SmartGroupResource>> GetSmartGroupAsync(this SubscriptionResource subscriptionResource, Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(SmartGroupRemovedMessage); }

        /// <summary> Gets a smart group resource. </summary>
        /// <param name="client"> The client. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SmartGroupResource GetSmartGroupResource(this ArmClient client, ResourceIdentifier id) { throw new NotSupportedException(SmartGroupRemovedMessage); }

        /// <summary> Gets smart groups. </summary>
        /// <param name="subscriptionResource"> The subscription. </param>
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SmartGroupCollection GetSmartGroups(this SubscriptionResource subscriptionResource) { throw new NotSupportedException(SmartGroupRemovedMessage); }
    }
}
