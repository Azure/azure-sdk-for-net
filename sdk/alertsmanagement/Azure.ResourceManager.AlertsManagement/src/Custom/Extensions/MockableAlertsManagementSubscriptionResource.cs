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

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    // Hand-written mockable class: this entire type has NO generated counterpart because the
    // TypeSpec spec has no subscription-scoped operations. The MPG generator only emits
    // MockableAlertsManagementArmClient (scope-based) and MockableAlertsManagementTenantResource.
    //
    // Backward compatibility:
    // 1. The old SDK (AutoRest-based, v1.1.1) exposed GetServiceAlertSummary/GetServiceAlertSummaryAsync
    //    on SubscriptionResource with both individual-parameter and SubscriptionResourceGetServiceAlertSummaryOptions
    //    overloads. The new TypeSpec generator places GetSummary on MockableAlertsManagementArmClient
    //    (scope-based). This custom mockable class re-introduces the old method signatures on
    //    SubscriptionResource, delegating to the generated GetSummary method via MockableAlertsManagementArmClient.
    // 2. Mocking support for the old SDK's GetServiceAlerts(SubscriptionResource) extension method.
    //    The old SDK placed this on SubscriptionResource; the new generator places it on ArmClient
    //    (scope-based). This delegates to the generated MockableAlertsManagementArmClient.GetServiceAlerts(Id).
    // 3. The obsolete members below are stubs for SubscriptionResource extension APIs removed in this
    //    migration (AlertProcessingRule*, SmartGroup*, GetServiceAlert(Guid)).
    //
    // The non-public members (protected ctor / internal ctor / private helper) are the standard
    // mockable-class infrastructure pattern: the protected parameterless ctor enables mocking, the
    // internal ctor is invoked by the AlertsManagementExtensions cached-client factory, and the
    // private GetMockableAlertsManagementArmClient() helper forwards requests to the generated
    // MockableAlertsManagementArmClient. These mirror the same pattern used in
    // generated Mockable*SubscriptionResource classes across other Azure.ResourceManager.* packages.
    /// <summary> Back-compat shim mock-able extension class for <see cref="SubscriptionResource"/>. The AlertProcessingRule and SmartGroup APIs have moved out of this package — every removed member throws <see cref="NotSupportedException"/> and is kept solely to preserve the binary contract of the previously published GA package (v1.1.x). </summary>
    public partial class MockableAlertsManagementSubscriptionResource : ArmResource
    {
        private const string AlertProcessingRuleRemovedMessage = "The AlertProcessingRule APIs have been moved to the 'Azure.ResourceManager.AlertProcessingRules' package. Reference that package and use the equivalent APIs (e.g., AlertProcessingRulesExtensions, MockableAlertProcessingRulesArmClient, MockableAlertProcessingRulesResourceGroupResource, MockableAlertProcessingRulesSubscriptionResource, ArmAlertProcessingRulesModelFactory) instead.";
        private const string SmartGroupRemovedMessage = "The SmartGroup APIs have been removed from this package and will be shipped in a separate package in a future release.";
        private const string GetServiceAlertGuidReplacedMessage = "Use MockableAlertsManagementArmClient.GetServiceAlertResource(id) or ServiceAlertCollection.Get(alertId.ToString()) instead.";

        /// <summary> Initializes a new instance of the <see cref="MockableAlertsManagementSubscriptionResource"/> class for mocking. </summary>
        protected MockableAlertsManagementSubscriptionResource() { }

        /// <summary> Initializes a new instance of the <see cref="MockableAlertsManagementSubscriptionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableAlertsManagementSubscriptionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private MockableAlertsManagementArmClient GetMockableAlertsManagementArmClient()
        {
            return Client.GetCachedClient(client => new MockableAlertsManagementArmClient(client, ResourceIdentifier.Root));
        }

        /// <summary> Gets a collection of ServiceAlertCollection in the SubscriptionResource. </summary>
        public virtual ServiceAlertCollection GetServiceAlerts()
        {
            return Client.GetCachedClient(client => new ServiceAlertCollection(client, Id));
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
        public virtual async Task<Response<ServiceAlertSummary>> GetServiceAlertSummaryAsync(AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = null, string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? alertState = null, string alertRule = null, TimeRangeFilter? timeRange = null, string customTimeRange = null, CancellationToken cancellationToken = default)
        {
            SubscriptionResourceGetServiceAlertSummaryOptions options = new SubscriptionResourceGetServiceAlertSummaryOptions(groupby);
            options.IncludeSmartGroupsCount = includeSmartGroupsCount;
            options.TargetResource = targetResource;
            options.TargetResourceType = targetResourceType;
            options.TargetResourceGroup = targetResourceGroup;
            options.MonitorService = monitorService;
            options.MonitorCondition = monitorCondition;
            options.Severity = severity;
            options.AlertState = alertState;
            options.AlertRule = alertRule;
            options.TimeRange = timeRange;
            options.CustomTimeRange = customTimeRange;
            return await GetServiceAlertSummaryAsync(options, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<ServiceAlertSummary> GetServiceAlertSummary(AlertsSummaryGroupByField groupby, bool? includeSmartGroupsCount = null, string targetResource = null, string targetResourceType = null, string targetResourceGroup = null, MonitorServiceSourceForAlert? monitorService = null, MonitorCondition? monitorCondition = null, ServiceAlertSeverity? severity = null, ServiceAlertState? alertState = null, string alertRule = null, TimeRangeFilter? timeRange = null, string customTimeRange = null, CancellationToken cancellationToken = default)
        {
            SubscriptionResourceGetServiceAlertSummaryOptions options = new SubscriptionResourceGetServiceAlertSummaryOptions(groupby);
            options.IncludeSmartGroupsCount = includeSmartGroupsCount;
            options.TargetResource = targetResource;
            options.TargetResourceType = targetResourceType;
            options.TargetResourceGroup = targetResourceGroup;
            options.MonitorService = monitorService;
            options.MonitorCondition = monitorCondition;
            options.Severity = severity;
            options.AlertState = alertState;
            options.AlertRule = alertRule;
            options.TimeRange = timeRange;
            options.CustomTimeRange = customTimeRange;
            return GetServiceAlertSummary(options, cancellationToken);
        }

        /// <summary> Get a summarized count of your alerts grouped by various parameters. </summary>
        /// <param name="options"> The options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ServiceAlertSummary>> GetServiceAlertSummaryAsync(SubscriptionResourceGetServiceAlertSummaryOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return await GetMockableAlertsManagementArmClient().GetSummaryAsync(Id, options.Groupby, options.IncludeSmartGroupsCount, options.TargetResource, options.TargetResourceType, options.TargetResourceGroup, options.MonitorService, options.MonitorCondition, options.Severity, options.AlertState, options.AlertRule, options.TimeRange, options.CustomTimeRange, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get a summarized count of your alerts grouped by various parameters. </summary>
        /// <param name="options"> The options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ServiceAlertSummary> GetServiceAlertSummary(SubscriptionResourceGetServiceAlertSummaryOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return GetMockableAlertsManagementArmClient().GetSummary(Id, options.Groupby, options.IncludeSmartGroupsCount, options.TargetResource, options.TargetResourceType, options.TargetResourceGroup, options.MonitorService, options.MonitorCondition, options.Severity, options.AlertState, options.AlertRule, options.TimeRange, options.CustomTimeRange, cancellationToken);
        }

        /// <summary> Gets alert processing rules. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<AlertProcessingRuleResource> GetAlertProcessingRules(CancellationToken cancellationToken = default) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets alert processing rules async. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<AlertProcessingRuleResource> GetAlertProcessingRulesAsync(CancellationToken cancellationToken = default) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets a service alert. </summary>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(GetServiceAlertGuidReplacedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ServiceAlertResource> GetServiceAlert(Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(GetServiceAlertGuidReplacedMessage); }

        /// <summary> Gets a service alert async. </summary>
        /// <param name="alertId"> The alert ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(GetServiceAlertGuidReplacedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ServiceAlertResource>> GetServiceAlertAsync(Guid alertId, CancellationToken cancellationToken = default) { throw new NotSupportedException(GetServiceAlertGuidReplacedMessage); }

        /// <summary> Gets a smart group. </summary>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SmartGroupResource> GetSmartGroup(Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(SmartGroupRemovedMessage); }

        /// <summary> Gets a smart group async. </summary>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<SmartGroupResource>> GetSmartGroupAsync(Guid smartGroupId, CancellationToken cancellationToken = default) { throw new NotSupportedException(SmartGroupRemovedMessage); }

        /// <summary> Gets smart groups. </summary>
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SmartGroupCollection GetSmartGroups() { throw new NotSupportedException(SmartGroupRemovedMessage); }
    }
}
