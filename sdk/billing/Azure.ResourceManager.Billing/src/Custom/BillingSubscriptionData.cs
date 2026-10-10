// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing
{
    // Back-compat for the GA 1.2.2 public surface around BillingSubscriptionProperties'
    // beneficiaryTenantId / customerId flatten proxies. GA exposed each of them under
    // TWO parallel names:
    //   * an [Obsolete] short-alias on the unprefixed name — BeneficiaryTenantId (string)
    //     and CustomerId (string) — pre-dating the BillingSubscriptionProperties model split.
    //   * a Subscription-prefixed primary — SubscriptionBeneficiaryTenantId (Guid?) and
    //     SubscriptionCustomerId (string) — the GA primary that callers were meant to migrate to.
    // The new MPG generator only emits the unprefixed Generated names. For BeneficiaryTenantId
    // the new TypeSpec model is strongly Guid?-typed (matching the spec), which collides with
    // GA's string-typed [Obsolete] alias by name. To restore the GA surface 1:1 we [CodeGenSuppress]
    // the Generated unprefixed properties and re-emit them here as the GA-shape [Obsolete]
    // string-typed short-aliases, while exposing the Subscription-prefixed primaries (Guid? /
    // string) as forwarders to the same underlying Properties slots. This keeps GA call sites
    // — including ones that read/write the [Obsolete] aliases — source-compatible.
    public partial class BillingSubscriptionData
    {
        /// <summary> The provisioning tenant of the subscription. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionBeneficiaryTenantId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.beneficiaryTenantId")]
        public string BeneficiaryTenantId
        {
            get => Properties?.BeneficiaryTenantId?.ToString();
            set
            {
                if (Properties is null)
                {
                    Properties = new Models.BillingSubscriptionProperties();
                }
                Properties.BeneficiaryTenantId = string.IsNullOrEmpty(value) ? (Guid?)null : Guid.Parse(value);
            }
        }

        /// <summary> The fully qualified ID that uniquely identifies a customer. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionCustomerId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.customerId")]
        public string CustomerId
        {
            get => Properties?.CustomerId;
            set
            {
                if (Properties is null)
                {
                    Properties = new Models.BillingSubscriptionProperties();
                }
                Properties.CustomerId = value;
            }
        }

        /// <summary> The provisioning tenant of the subscription. </summary>
        [WirePath("properties.beneficiaryTenantId")]
        public Guid? SubscriptionBeneficiaryTenantId
        {
            get => Properties?.BeneficiaryTenantId;
            set
            {
                if (Properties is null)
                {
                    Properties = new Models.BillingSubscriptionProperties();
                }
                Properties.BeneficiaryTenantId = value;
            }
        }

        /// <summary> The fully qualified ID that uniquely identifies a customer. </summary>
        [WirePath("properties.customerId")]
        public string SubscriptionCustomerId
        {
            get => Properties?.CustomerId;
            set
            {
                if (Properties is null)
                {
                    Properties = new Models.BillingSubscriptionProperties();
                }
                Properties.CustomerId = value;
            }
        }
    }
}
