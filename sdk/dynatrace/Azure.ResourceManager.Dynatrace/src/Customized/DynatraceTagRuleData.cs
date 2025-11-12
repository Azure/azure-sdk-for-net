// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Dynatrace.Models;

namespace Azure.ResourceManager.Dynatrace
{
    public partial class DynatraceTagRuleData
    {
        /// <summary> List of filtering tags to be used for capturing metrics. If empty, all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules will only include resources with the associated tags. </summary>
        // Add this property due to the previous swagger definition for MetricRules only had FilteringTags as a direct child property.
        public IList<DynatraceMonitorResourceFilteringTag> MetricRulesFilteringTags
        {
            get
            {
                if (MetricRules is null)
                    MetricRules = new DynatraceMonitorResourceMetricRules();
                return MetricRules.FilteringTags;
            }
        }
    }
}
