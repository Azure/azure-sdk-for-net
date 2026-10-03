// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Billing
{
    // Suppress the generated ProvisioningState so the alias-specific state can be exposed
    // with a distinct name and avoid a duplicate property inherited from BillingSubscriptionProperties.
    [CodeGenSuppress("ProvisioningState")]
    public partial class BillingSubscriptionAlias
    {
        /// <summary> Gets the SubscriptionAliasProvisioningState. </summary>
        public BicepValue<BillingProvisioningState> SubscriptionAliasProvisioningState
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new BillingSubscriptionAliasProperties();
                }

                return Properties.SubscriptionAliasProvisioningState;
            }
        }
    }
}
