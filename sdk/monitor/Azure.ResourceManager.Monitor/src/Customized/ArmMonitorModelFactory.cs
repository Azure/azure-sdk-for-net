// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMonitorModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Monitor.MetricAlertData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="description"> the description of the metric alert that will be included in the alert email. </param>
        /// <param name="severity"> Alert severity {0, 1, 2, 3, 4}. </param>
        /// <param name="isEnabled"> the flag that indicates whether the metric alert is enabled. </param>
        /// <param name="scopes"> the list of resource id's that this metric alert is scoped to. </param>
        /// <param name="evaluationFrequency"> how often the metric alert is evaluated represented in ISO 8601 duration format. </param>
        /// <param name="windowSize"> the period of time (in ISO 8601 duration format) that is used to monitor alert activity based on the threshold. </param>
        /// <param name="targetResourceType"> the resource type of the target resource(s) on which the alert is created/updated. Mandatory if the scope contains a subscription, resource group, or more than one resource. </param>
        /// <param name="targetResourceRegion"> the region of the target resource(s) on which the alert is created/updated. Mandatory if the scope contains a subscription, resource group, or more than one resource. </param>
        /// <param name="criteria">
        /// defines the specific alert criteria information.
        /// Please note <see cref="MetricAlertCriteria"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="MetricAlertMultipleResourceMultipleMetricCriteria"/>, <see cref="MetricAlertSingleResourceMultipleMetricCriteria"/> and <see cref="WebtestLocationAvailabilityCriteria"/>.
        /// </param>
        /// <param name="isAutoMitigateEnabled"> the flag that indicates whether the alert should be auto resolved or not. The default is true. </param>
        /// <param name="actions"> the array of actions that are performed when the alert rule becomes active, and when an alert condition is resolved. </param>
        /// <param name="lastUpdatedOn"> Last time the rule was updated in ISO8601 format. </param>
        /// <param name="isMigrated"> the value indicating whether this alert rule is migrated. </param>
        /// <returns> A new <see cref="Monitor.MetricAlertData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MetricAlertData MetricAlertData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string description, int severity, bool isEnabled, IEnumerable<string> scopes, TimeSpan evaluationFrequency, TimeSpan windowSize, ResourceType? targetResourceType, AzureLocation? targetResourceRegion, MetricAlertCriteria criteria, bool? isAutoMitigateEnabled, IEnumerable<MetricAlertAction> actions, DateTimeOffset? lastUpdatedOn, bool? isMigrated)
            => MetricAlertData(id, name, resourceType, systemData, tags, location, description, severity, isEnabled, scopes, evaluationFrequency, windowSize, targetResourceType, targetResourceRegion, criteria, isAutoMitigateEnabled, null, actions, lastUpdatedOn, isMigrated, null, null, null);
    }
}