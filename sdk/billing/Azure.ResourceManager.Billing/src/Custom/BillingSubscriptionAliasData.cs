// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing
{
    // See BillingSubscriptionData for the root-cause explanation; BillingSubscriptionAliasProperties
    // extends BillingSubscriptionProperties and inherits the same beneficiaryTenantId / customerId
    // flatten proxies. The Subscription-prefixed primaries are renamed to SubscriptionAlias-prefixed
    // here via @@clientName in client.tsp, but the unprefixed [Obsolete] short-aliases need the same
    // suppress + redeclare treatment (string-typed BeneficiaryTenantId, Obsolete-attributed
    // CustomerId) to keep GA 1.2.2 source-compat. BillingSubscriptionId (Obsolete, ResourceIdentifier)
    // is also a GA back-compat alias kept as a thin proxy over the string-typed
    // SubscriptionAliasSubscriptionId.
    public partial class BillingSubscriptionAliasData
    {
        /// <summary> The provisioning tenant of the subscription. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionAliasBeneficiaryTenantId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.beneficiaryTenantId")]
        public string BeneficiaryTenantId
        {
            get => Properties?.BeneficiaryTenantId?.ToString();
            set
            {
                if (Properties is null)
                {
                    Properties = new Models.BillingSubscriptionAliasProperties();
                }
                Properties.BeneficiaryTenantId = string.IsNullOrEmpty(value) ? (Guid?)null : Guid.Parse(value);
            }
        }

        /// <summary> The fully qualified ID that uniquely identifies a customer. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionAliasCustomerId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.customerId")]
        public string CustomerId
        {
            get => Properties?.CustomerId;
            set
            {
                if (Properties is null)
                {
                    Properties = new Models.BillingSubscriptionAliasProperties();
                }
                Properties.CustomerId = value;
            }
        }

        /// <summary> The provisioning tenant of the subscription. </summary>
        [WirePath("properties.beneficiaryTenantId")]
        public Guid? SubscriptionAliasBeneficiaryTenantId
        {
            get => Properties?.BeneficiaryTenantId;
            set
            {
                if (Properties is null)
                {
                    Properties = new Models.BillingSubscriptionAliasProperties();
                }
                Properties.BeneficiaryTenantId = value;
            }
        }

        /// <summary> The fully qualified ID that uniquely identifies a customer. </summary>
        [WirePath("properties.customerId")]
        public string SubscriptionAliasCustomerId
        {
            get => Properties?.CustomerId;
            set
            {
                if (Properties is null)
                {
                    Properties = new Models.BillingSubscriptionAliasProperties();
                }
                Properties.CustomerId = value;
            }
        }

        /// <summary> The ID of the billing subscription with the subscription alias. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionAliasSubscriptionId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier BillingSubscriptionId =>
            SubscriptionAliasSubscriptionId is null ? null : new ResourceIdentifier(SubscriptionAliasSubscriptionId);
    }
}
