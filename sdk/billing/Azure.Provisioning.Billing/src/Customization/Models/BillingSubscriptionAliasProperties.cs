// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Billing
{
    // Suppress the generated ProvisioningState so the alias-specific state can be exposed
    // with a distinct name and avoid a duplicate property inherited from BillingSubscriptionProperties.
    [CodeGenSuppress("ProvisioningState")]
    internal partial class BillingSubscriptionAliasProperties
    {
        private BicepValue<BillingProvisioningState> _subscriptionAliasProvisioningState;

        // Use a distinct property name because the base subscription model already defines ProvisioningState.
        /// <summary> Gets the SubscriptionAliasProvisioningState. </summary>
        public BicepValue<BillingProvisioningState> SubscriptionAliasProvisioningState
        {
            get
            {
                Initialize();
                return _subscriptionAliasProvisioningState;
            }
        }

        partial void DefineAdditionalProperties()
        {
            _subscriptionAliasProvisioningState = DefineProperty<BillingProvisioningState>(
                nameof(SubscriptionAliasProvisioningState),
                new string[] { "provisioningState" },
                isOutput: true);
        }
    }
}
