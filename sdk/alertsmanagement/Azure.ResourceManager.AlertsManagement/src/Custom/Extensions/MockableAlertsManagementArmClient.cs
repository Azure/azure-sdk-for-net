// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    // Custom partial of the generator-emitted MockableAlertsManagementArmClient. The only purpose of
    // this file is to re-expose two ArmClient-level "Get*Resource(ResourceIdentifier)" entry points
    // that the previously published GA package (v1.1.x) exported but the regenerated TypeSpec spec no
    // longer covers:
    //
    //   - GetAlertProcessingRuleResource(id): the AlertProcessingRule RP surface was extracted into the
    //     sibling 'Azure.ResourceManager.AlertProcessingRules' package; the equivalent API now lives on
    //     that package's MockableAlertProcessingRulesArmClient.
    //   - GetSmartGroupResource(id): the SmartGroup RP is intentionally out of scope for this spec and
    //     will ship from a separate dedicated package in a future release.
    //
    // Both methods are kept with their original v1.1.x signature so consumer assemblies compiled
    // against the old GA still load, but are marked [Obsolete(..., error: true)] +
    // [EditorBrowsable(Never)] and throw NotSupportedException at runtime, redirecting new callers to
    // the correct package.
    public partial class MockableAlertsManagementArmClient : ArmResource
    {
        private const string AlertProcessingRuleRemovedMessage = "The AlertProcessingRule APIs have been moved to the 'Azure.ResourceManager.AlertProcessingRules' package. Reference that package and use the equivalent APIs (e.g., AlertProcessingRulesExtensions, MockableAlertProcessingRulesArmClient, MockableAlertProcessingRulesResourceGroupResource, MockableAlertProcessingRulesSubscriptionResource, ArmAlertProcessingRulesModelFactory) instead.";
        private const string SmartGroupRemovedMessage = "The SmartGroup APIs have been removed from this package and will be shipped in a separate package in a future release.";

        /// <summary> Gets an alert processing rule resource. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete(AlertProcessingRuleRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AlertProcessingRuleResource GetAlertProcessingRuleResource(ResourceIdentifier id) { throw new NotSupportedException(AlertProcessingRuleRemovedMessage); }

        /// <summary> Gets a smart group resource. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete(SmartGroupRemovedMessage, true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SmartGroupResource GetSmartGroupResource(ResourceIdentifier id) { throw new NotSupportedException(SmartGroupRemovedMessage); }
    }
}
