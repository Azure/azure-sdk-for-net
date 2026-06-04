// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Billing
{
    // Back-compat for GA 1.2.2 primary names. GA exposed the inner BillingSubscriptionProperties
    // beneficiaryTenantId / customerId flatten proxies under both the unprefixed name
    // (BeneficiaryTenantId / CustomerId — also marked [Obsolete] in GA) and a Subscription-
    // prefixed name (SubscriptionBeneficiaryTenantId / SubscriptionCustomerId — the GA primary).
    // The new MPG generator emits only the unprefixed Generated names via @@clientName in
    // client.tsp, so add the GA Subscription-prefixed primaries as thin forwarders. The
    // (intentionally already-[Obsolete]) `string` short-alias accessors collide by name with
    // the Generated `Guid?` flavor and are intentionally dropped.
    public partial class BillingSubscriptionData
    {
        /// <summary> The provisioning tenant of the subscription. </summary>
        [WirePath("properties.beneficiaryTenantId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? SubscriptionBeneficiaryTenantId
        {
            get => BeneficiaryTenantId;
            set => BeneficiaryTenantId = value;
        }

        /// <summary> The fully qualified ID that uniquely identifies a customer. </summary>
        [WirePath("properties.customerId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SubscriptionCustomerId
        {
            get => CustomerId;
            set => CustomerId = value;
        }
    }
}
