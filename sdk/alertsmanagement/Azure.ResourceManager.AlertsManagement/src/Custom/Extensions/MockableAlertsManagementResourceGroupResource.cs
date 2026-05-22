// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    // Back-compat ApiCompat shim — kept solely to preserve the binary contract of the previously
    // published GA package (Azure.ResourceManager.AlertsManagement v1.1.x).
    //
    // Why it lives here instead of being regenerated:
    //   The AlertProcessingRule (formerly "actionRules") RP surface was extracted into the sibling
    //   package 'Azure.ResourceManager.AlertProcessingRules'. The MPG generator therefore no longer
    //   emits a MockableAlertsManagementResourceGroupResource (the new TypeSpec spec for this package
    //   has zero resource-group-scope operations), but v1.1.x consumers compiled against the old
    //   surface still reference this type's GetAlertProcessingRule(s) members.
    //
    // What this stub provides:
    //   The class and its members keep the v1.1.x signatures so old binaries still load, but every
    //   member throws NotSupportedException and the class is [Obsolete(..., error: true)] +
    //   [EditorBrowsable(Never)] so new callers are routed to
    //   MockableAlertProcessingRulesResourceGroupResource in the AlertProcessingRules package.
    /// <summary> Back-compat shim mock-able extension class for <see cref="ResourceGroupResource"/>. The AlertProcessingRule APIs have moved to the 'Azure.ResourceManager.AlertProcessingRules' package — every member of this class throws <see cref="NotSupportedException"/> and is kept solely to preserve the binary contract of the previously published GA package (v1.1.x). </summary>
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
