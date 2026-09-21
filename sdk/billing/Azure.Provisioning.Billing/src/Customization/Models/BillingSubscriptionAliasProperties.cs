// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Billing
{
    [CodeGenSuppress("ProvisioningState")]
    internal partial class BillingSubscriptionAliasProperties
    {
        private BicepValue<BillingProvisioningState> _subscriptionAliasProvisioningState;

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
