// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Billing
{
    // See BillingSubscriptionData for root-cause explanation. BillingSubscriptionAliasProperties
    // extends BillingSubscriptionProperties and inherits the beneficiaryTenantId / customerId
    // flatten proxies — generator emits them under the base names (BeneficiaryTenantId /
    // CustomerId). Add the GA primary names (SubscriptionAlias-prefixed) as forwarders so
    // GA 1.2.2 callers continue to compile. BillingSubscriptionId (Obsolete, ResourceIdentifier)
    // is kept as a thin proxy over the string-typed SubscriptionAliasSubscriptionId.
    public partial class BillingSubscriptionAliasData
    {
        /// <summary> The provisioning tenant of the subscription. </summary>
        [WirePath("properties.beneficiaryTenantId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? SubscriptionAliasBeneficiaryTenantId
        {
            get => BeneficiaryTenantId;
            set => BeneficiaryTenantId = value;
        }

        /// <summary> The fully qualified ID that uniquely identifies a customer. </summary>
        [WirePath("properties.customerId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SubscriptionAliasCustomerId
        {
            get => CustomerId;
            set => CustomerId = value;
        }

        /// <summary> The ID of the billing subscription with the subscription alias. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionAliasSubscriptionId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier BillingSubscriptionId =>
            SubscriptionAliasSubscriptionId is null ? null : new ResourceIdentifier(SubscriptionAliasSubscriptionId);
    }
}
