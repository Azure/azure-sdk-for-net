// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Dynatrace.Models
{
    public static partial class ArmDynatraceModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.DynatraceAccountCredentialsInfo"/>. </summary>
        /// <param name="accountId"> Account Id of the account this environment is linked to. </param>
        /// <param name="apiKey"> API Key of the user account. </param>
        /// <param name="regionId"> Region in which the account is created. </param>
        /// <returns> A new <see cref="Models.DynatraceAccountCredentialsInfo"/> instance for mocking. </returns>
        // Add this model due to the api compatibility for operation: Monitors_GetAccountCredentials.
        public static DynatraceAccountCredentialsInfo DynatraceAccountCredentialsInfo(string accountId = null, string apiKey = null, string regionId = null)
        {
            return new DynatraceAccountCredentialsInfo(accountId, apiKey, regionId, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Dynatrace.DynatraceTagRuleData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="logRules"> Set of rules for sending logs for the Monitor resource. </param>
        /// <param name="metricRulesFilteringTags"> Set of rules for sending metrics for the Monitor resource. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <returns> A new <see cref="Dynatrace.DynatraceTagRuleData"/> instance for mocking. </returns>
        // Add this custom code due to the previous swagger definition for MetricRules only had FilteringTags as a direct child property.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DynatraceTagRuleData DynatraceTagRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DynatraceMonitorResourceLogRules logRules, IEnumerable<DynatraceMonitorResourceFilteringTag> metricRulesFilteringTags, DynatraceProvisioningState? provisioningState = null)
        {
            DynatraceMonitorResourceMetricRules metricRules = null;
            if (metricRulesFilteringTags != null)
            {
                metricRules = new DynatraceMonitorResourceMetricRules();
                foreach (var tag in metricRulesFilteringTags)
                {
                    metricRules.FilteringTags.Add(tag);
                }
            }
            return DynatraceTagRuleData(id, name, resourceType, systemData, logRules, metricRules, provisioningState);
        }
    }
}
