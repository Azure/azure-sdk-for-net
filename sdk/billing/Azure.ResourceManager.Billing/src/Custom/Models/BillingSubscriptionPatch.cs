// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Billing.Models
{
    // Back-compat aliases for GA 1.2.2 property names. The new generator emits the raw
    // spec names (SubscriptionBeneficiaryTenantId/SubscriptionCustomerId); GA exposed
    // BeneficiaryTenantId (Guid?) and CustomerId (string) directly on the patch.
    public partial class BillingSubscriptionPatch
    {
        /// <summary> The tenant id of the customer for whom the subscription is created. </summary>
        public Guid? BeneficiaryTenantId
        {
            get => SubscriptionBeneficiaryTenantId;
            set => SubscriptionBeneficiaryTenantId = value;
        }

        /// <summary> The ID of the customer for whom the subscription was created. </summary>
        public string CustomerId
        {
            get => SubscriptionCustomerId;
            set => SubscriptionCustomerId = value;
        }
    }
}
