// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertsManagement.Mocking
{
    // The TypeSpec spec defines two @armResourceOperations interfaces (Alerts and
    // AlertGetAllTenantOperation) that both bind to the Alert resource model, so the MPG generator
    // emits an identical GetServiceAlertResource(ResourceIdentifier) factory twice (CS0111 duplicate
    // member). The CodeGenSuppress below removes both generator-emitted overloads and we add a single
    // canonical GetServiceAlertResource manually to match the v1.1.1 API surface.
    //
    // The obsolete members below are stubs for APIs removed in this migration:
    //  - AlertProcessingRule*: moved to the 'Azure.ResourceManager.AlertProcessingRules' package.
    //  - SmartGroup*: moved to Legacy in the spec repo; the APIs still exist in Azure and will be
    //    shipped from a separate package in a future release.
    [CodeGenSuppress("GetServiceAlertResource", typeof(ResourceIdentifier))]
    public partial class MockableAlertsManagementArmClient : ArmResource
    {
        private const string AlertProcessingRuleRemovedMessage = "The AlertProcessingRule APIs have been moved to the 'Azure.ResourceManager.AlertProcessingRules' package. Reference that package and use the equivalent APIs (e.g., AlertProcessingRulesExtensions, MockableAlertProcessingRulesArmClient, MockableAlertProcessingRulesResourceGroupResource, MockableAlertProcessingRulesSubscriptionResource, ArmAlertProcessingRulesModelFactory) instead.";
        private const string SmartGroupRemovedMessage = "The SmartGroup APIs have been removed from this package and will be shipped in a separate package in a future release.";

        /// <summary>
        /// Gets an object representing a <see cref="ServiceAlertResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ServiceAlertResource.CreateResourceIdentifier" /> to create a <see cref="ServiceAlertResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ServiceAlertResource" /> object. </returns>
        public virtual ServiceAlertResource GetServiceAlertResource(ResourceIdentifier id)
        {
            ServiceAlertResource.ValidateResourceId(id);
            return new ServiceAlertResource(Client, id);
        }

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
