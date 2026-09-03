// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.OperationalInsights.Models;

namespace Azure.ResourceManager.OperationalInsights
{
    public partial class OperationalInsightsSummaryLogsData
    {
        // Backward-compatibility shim for the property type shipped in version 1.3.2.
        /// <summary> SummaryRules rule type: User. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Use SummaryLogsRuleType instead.", false)]
        [WirePath("properties.ruleType")]
        public OperationalInsightsNetworkSecurityPerimeterRuleType? RuleType
        {
            get => SummaryLogsRuleType.HasValue ? SummaryLogsRuleType.Value : default(OperationalInsightsNetworkSecurityPerimeterRuleType?);
            set => SummaryLogsRuleType = value.HasValue ? value.Value : default(OperationalInsightsSummaryLogsRuleType?);
        }

        // Backward-compatibility shim for the property type shipped in version 1.3.2.
        /// <summary> Indicates the reason for rule deactivation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Use SummaryLogsStatusCode instead.", false)]
        [WirePath("properties.statusCode")]
        public OperationalInsightsNetworkSecurityPerimeterStatusCode? StatusCode =>
            SummaryLogsStatusCode.HasValue ? SummaryLogsStatusCode.Value : default(OperationalInsightsNetworkSecurityPerimeterStatusCode?);

        // Backward-compatibility shim for the property type shipped in version 1.3.2.
        /// <summary> The provisioning state of the Summary Logs rule. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Use SummaryLogsProvisioningState instead.", false)]
        [WirePath("properties.provisioningState")]
        public OperationalInsightsNetworkSecurityPerimeterProvisioningState? ProvisioningState =>
            SummaryLogsProvisioningState.HasValue ? SummaryLogsProvisioningState.Value : default(OperationalInsightsNetworkSecurityPerimeterProvisioningState?);
    }
}
