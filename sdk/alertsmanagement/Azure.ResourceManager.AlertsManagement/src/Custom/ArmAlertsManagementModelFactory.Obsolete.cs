// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: these members were removed in the TypeSpec migration.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    public static partial class ArmAlertsManagementModelFactory
    {
        /// <summary> Creates AlertProcessingRuleData. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> The properties. </param>
        [Obsolete("The AlertProcessingRule APIs have been removed from this package and will be shipped in a separate package in a future release.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AlertProcessingRuleData AlertProcessingRuleData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, AlertProcessingRuleProperties properties = null) { throw new NotSupportedException(); }

        /// <summary> Creates SmartGroupData. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="alertsCount"> The alerts count. </param>
        /// <param name="smartGroupState"> The smart group state. </param>
        /// <param name="severity"> The severity. </param>
        /// <param name="startOn"> The start on. </param>
        /// <param name="lastModifiedOn"> The last modified on. </param>
        /// <param name="lastModifiedBy"> The last modified by. </param>
        /// <param name="resources"> The resources. </param>
        /// <param name="resourceTypes"> The resource types. </param>
        /// <param name="resourceGroups"> The resource groups. </param>
        /// <param name="monitorServices"> The monitor services. </param>
        /// <param name="monitorConditions"> The monitor conditions. </param>
        /// <param name="alertStates"> The alert states. </param>
        /// <param name="alertSeverities"> The alert severities. </param>
        /// <param name="nextLink"> The next link. </param>
        [Obsolete("The SmartGroup APIs have been removed from this package and will be shipped in a separate package in a future release.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SmartGroupData SmartGroupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, long? alertsCount = null, SmartGroupState? smartGroupState = null, ServiceAlertSeverity? severity = null, DateTimeOffset? startOn = null, DateTimeOffset? lastModifiedOn = null, string lastModifiedBy = null, IEnumerable<SmartGroupAggregatedProperty> resources = null, IEnumerable<SmartGroupAggregatedProperty> resourceTypes = null, IEnumerable<SmartGroupAggregatedProperty> resourceGroups = null, IEnumerable<SmartGroupAggregatedProperty> monitorServices = null, IEnumerable<SmartGroupAggregatedProperty> monitorConditions = null, IEnumerable<SmartGroupAggregatedProperty> alertStates = null, IEnumerable<SmartGroupAggregatedProperty> alertSeverities = null, string nextLink = null) { throw new NotSupportedException(); }

        /// <summary> Creates SmartGroupModification. </summary>
        /// <param name="id"> The resource ID. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resource type. </param>
        /// <param name="systemData"> The system data. </param>
        /// <param name="properties"> The properties. </param>
        [Obsolete("The SmartGroup APIs have been removed from this package and will be shipped in a separate package in a future release.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SmartGroupModification SmartGroupModification(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, SmartGroupModificationProperties properties = null) { throw new NotSupportedException(); }

        /// <summary> Creates SmartGroupModificationProperties. </summary>
        /// <param name="smartGroupId"> The smart group ID. </param>
        /// <param name="modifications"> The modifications. </param>
        /// <param name="nextLink"> The next link. </param>
        [Obsolete("The SmartGroup APIs have been removed from this package and will be shipped in a separate package in a future release.", true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SmartGroupModificationProperties SmartGroupModificationProperties(Guid? smartGroupId = null, IEnumerable<SmartGroupModificationItemInfo> modifications = null, string nextLink = null) { throw new NotSupportedException(); }
    }
}