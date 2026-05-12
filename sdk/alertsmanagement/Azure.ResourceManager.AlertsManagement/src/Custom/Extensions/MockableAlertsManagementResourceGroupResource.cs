// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility stub: the AlertProcessingRule APIs have been moved to the
// 'Azure.ResourceManager.AlertProcessingRules' package. Reference that package and use the
// equivalent APIs (e.g., MockableAlertProcessingRulesResourceGroupResource) instead.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    [Obsolete("The AlertProcessingRule APIs have been moved to the 'Azure.ResourceManager.AlertProcessingRules' package. Reference that package and use the equivalent APIs (e.g., AlertProcessingRulesExtensions, MockableAlertProcessingRulesArmClient, MockableAlertProcessingRulesResourceGroupResource, MockableAlertProcessingRulesSubscriptionResource, ArmAlertProcessingRulesModelFactory) instead.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MockableAlertsManagementResourceGroupResource : ArmResource
    {
        private const string AlertProcessingRuleRemovedMessage = "The AlertProcessingRule APIs have been moved to the 'Azure.ResourceManager.AlertProcessingRules' package. Reference that package and use the equivalent APIs (e.g., AlertProcessingRulesExtensions, MockableAlertProcessingRulesArmClient, MockableAlertProcessingRulesResourceGroupResource, MockableAlertProcessingRulesSubscriptionResource, ArmAlertProcessingRulesModelFactory) instead.";

        /// <summary> Initializes a new instance for mocking. </summary>
        protected MockableAlertsManagementResourceGroupResource() { }

        /// <summary> Gets alert processing rules. </summary>
        public virtual AlertProcessingRuleCollection GetAlertProcessingRules() { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets an alert processing rule. </summary>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        public virtual Response<AlertProcessingRuleResource> GetAlertProcessingRule(string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets an alert processing rule async. </summary>
        /// <param name="alertProcessingRuleName"> The name. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        [ForwardsClientCalls]
        public virtual Task<Response<AlertProcessingRuleResource>> GetAlertProcessingRuleAsync(string alertProcessingRuleName, CancellationToken cancellationToken = default) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }
    }
}
