// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
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
        // Add this custom ode due to the previous swagger definition for MetricRules only had FilteringTags as a direct child property.
        public static DynatraceTagRuleData DynatraceTagRuleData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, DynatraceMonitorResourceLogRules logRules = null, IEnumerable<DynatraceMonitorResourceFilteringTag> metricRulesFilteringTags = null, DynatraceProvisioningState? provisioningState = null)
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
