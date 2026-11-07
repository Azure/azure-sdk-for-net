// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Monitor.Models
{
#pragma warning disable CS0618 // This partial class intentionally exposes obsolete compatibility members.
    [CodeGenSuppress("MonitorMetricDefinition", typeof(bool?), typeof(string), typeof(string), typeof(MonitorLocalizableString), typeof(string), typeof(string), typeof(MonitorMetricClass?), typeof(MonitorMetricUnit?), typeof(MonitorAggregationType?), typeof(IEnumerable<MonitorAggregationType>), typeof(IEnumerable<MonitorMetricAvailability>), typeof(string), typeof(IEnumerable<MonitorLocalizableString>))]
    public static partial class ArmMonitorModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.MonitorMetricDefinition"/>. </summary>
        /// <param name="isDimensionRequired"> Flag to indicate whether the dimension is required. </param>
        /// <param name="resourceId"> the resource identifier of the resource that emitted the metric. </param>
        /// <param name="namespace"> the namespace the metric belongs to. </param>
        /// <param name="name"> the name and the display name of the metric, i.e. it is a localizable string. </param>
        /// <param name="displayDescription"> Detailed description of this metric. </param>
        /// <param name="category"> Custom category name for this metric. </param>
        /// <param name="metricClass"> The class of the metric. </param>
        /// <param name="unit"> The unit of the metric. </param>
        /// <param name="primaryAggregationType"> the primary aggregation type value defining how to use the values for display. </param>
        /// <param name="supportedAggregationTypes"> the collection of what aggregation types are supported. </param>
        /// <param name="metricAvailabilities"> the collection of what aggregation intervals are available to be queried. </param>
        /// <param name="id"> the resource identifier of the metric definition. </param>
        /// <param name="dimensions"> the name and the display name of the dimension, i.e. it is a localizable string. </param>
        /// <returns> A new <see cref="Models.MonitorMetricDefinition"/> instance for mocking. </returns>
        [Obsolete("This API is no longer supported. Use the MonitorMetricDefinition overload that takes MonitorMetricAggregationType primaryAggregationKind and IEnumerable<MonitorMetricAggregationType> supportedAggregationKinds instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MonitorMetricDefinition MonitorMetricDefinition(bool? isDimensionRequired = default, string resourceId = default, string @namespace = default, MonitorLocalizableString name = default, string displayDescription = default, string category = default, MonitorMetricClass? metricClass = default, MonitorMetricUnit? unit = default, MonitorAggregationType? primaryAggregationType = default, IEnumerable<MonitorAggregationType> supportedAggregationTypes = default, IEnumerable<MonitorMetricAvailability> metricAvailabilities = default, string id = default, IEnumerable<MonitorLocalizableString> dimensions = default)
        {
            List<MonitorMetricAggregationType> supportedAggregationKinds = null;
            if (supportedAggregationTypes is not null)
            {
                supportedAggregationKinds = new List<MonitorMetricAggregationType>();
                foreach (MonitorAggregationType value in supportedAggregationTypes)
                {
                    supportedAggregationKinds.Add(MonitorAggregationTypeHelper.FromLegacyAggregationType(value));
                }
            }

            return MonitorMetricDefinition(
                    isDimensionRequired,
                    resourceId,
                    @namespace,
                    name,
                    displayDescription,
                    category,
                    metricClass,
                    unit,
                    MonitorAggregationTypeHelper.FromLegacyAggregationType(primaryAggregationType),
                    supportedAggregationKinds,
                    metricAvailabilities,
                    id,
                    dimensions);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AlertRuleData"/>.
        /// </summary>
        /// <remarks>This API is no longer supported.</remarks>
        // The current TypeSpec no longer models the old AlertRule resource, so there is no generated factory overload to delegate to.
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        // TODO: Remove these compatibility parameter mappings after https://github.com/Azure/azure-sdk-for-net/issues/61815 is fixed.
        public static Azure.ResourceManager.Monitor.AlertRuleData AlertRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string alertRuleName, string description, string provisioningState, bool isEnabled, AlertRuleCondition condition, AlertRuleAction action, IEnumerable<AlertRuleAction> actions, DateTimeOffset? lastUpdatedOn)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Initializes a new instance of <see cref="Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryData"/>. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system metadata. </param>
        /// <param name="categoryType"> The type of diagnostic settings category. </param>
        /// <param name="categoryGroups"> The supported category groups. </param>
        /// <returns> A new diagnostic settings category data instance. </returns>
        public static Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryData DiagnosticSettingsCategoryData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, MonitorCategoryType? categoryType = null, IEnumerable<string> categoryGroups = null)
            => new Azure.ResourceManager.Monitor.DiagnosticSettingsCategoryData(id, name, resourceType, systemData, new DiagnosticSettingsCategoryProperties(categoryType, categoryGroups?.ToList() ?? new List<string>(), default), default);

        /// <summary>
        /// Initializes a new instance of <see cref="Azure.ResourceManager.Monitor.DiagnosticSettingData"/>.
        /// </summary>
        /// <remarks>This API is no longer supported.</remarks>
        // Current TypeSpec models only the singleton service diagnostic setting, so the old arbitrary-name DiagnosticSettingData shape has no generated factory to delegate to.
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Monitor.DiagnosticSettingData DiagnosticSettingData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ResourceIdentifier storageAccountId, ResourceIdentifier serviceBusRuleId, ResourceIdentifier eventHubAuthorizationRuleId, string eventHubName, IEnumerable<MetricSettings> metrics, IEnumerable<LogSettings> logs, ResourceIdentifier workspaceId, ResourceIdentifier marketplacePartnerId, string logAnalyticsDestinationType)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary>
        /// Initializes a new instance of <see cref="AlertRulePatch"/>.
        /// </summary>
        /// <remarks>This API is no longer supported.</remarks>
        // The current TypeSpec no longer models the old AlertRule patch resource, so there is no generated factory overload to delegate to.
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AlertRulePatch AlertRulePatch(IDictionary<string, string> tags, string name, string description, string provisioningState, bool? isEnabled, AlertRuleCondition condition, AlertRuleAction action, IEnumerable<AlertRuleAction> actions, DateTimeOffset? lastUpdatedOn)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary>
        /// Initializes a new instance of <see cref="MonitorIncident"/>.
        /// </summary>
        /// <remarks>This API is no longer supported.</remarks>
        // The generated MonitorIncident model no longer has the old factory shape, so this removed overload cannot delegate to a generated factory.
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MonitorIncident MonitorIncident(string name, string ruleName, bool? isActive, DateTimeOffset? activatedOn, DateTimeOffset? resolvedOn)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary>
        /// Initializes a new instance of <see cref="MonitorPrivateLinkScopeOperationStatus"/>.
        /// </summary>
        /// <remarks>This API is no longer supported.</remarks>
        // The private-link operation-status polling endpoint is hidden from the current SDK, so there is no generated factory overload to delegate to.
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MonitorPrivateLinkScopeOperationStatus MonitorPrivateLinkScopeOperationStatus(string id, string name, DateTimeOffset? startOn, DateTimeOffset? endOn, string status, ResponseError error)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary>
        /// Initializes a new instance of <see cref="SubscriptionMonitorMetric"/>.
        /// </summary>
        /// <remarks>This API is no longer supported.</remarks>
        // The current TypeSpec no longer models the old subscription metric result shape, so there is no generated factory overload to delegate to.
        [Obsolete("This API is no longer supported.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SubscriptionMonitorMetric SubscriptionMonitorMetric(string id, string subscriptionScopeMetricType, MonitorLocalizableString name, string displayDescription, string errorCode, string errorMessage, MonitorMetricUnit unit, IEnumerable<MonitorTimeSeriesElement> timeseries)
            => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Initializes a new instance of <see cref="VmInsightsOnboardingStatusData"/>. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="name"> The resource name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system metadata. </param>
        /// <param name="resourceId"> The identifier of the resource being monitored. </param>
        /// <param name="onboardingStatus"> The onboarding status. </param>
        /// <param name="dataStatus"> The data status. </param>
        /// <param name="data"> Containers storing VM Insights data. </param>
        /// <returns> A new VM Insights onboarding status data instance. </returns>
        public static Azure.ResourceManager.Monitor.VmInsightsOnboardingStatusData VmInsightsOnboardingStatusData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ResourceIdentifier resourceId = null, OnboardingStatus? onboardingStatus = null, DataStatus? dataStatus = null, IEnumerable<DataContainer> data = null)
            => new Azure.ResourceManager.Monitor.VmInsightsOnboardingStatusData(id, name, resourceType, systemData, new VMInsightsOnboardingStatusProperties(resourceId?.ToString(), onboardingStatus ?? default, dataStatus ?? default, data?.ToList() ?? new List<DataContainer>(), default), default);
    }
#pragma warning restore CS0618
}
