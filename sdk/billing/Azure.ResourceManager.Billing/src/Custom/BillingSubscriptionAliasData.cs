// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Billing
{
    // Back-compat shims for GA 1.2.2 API surface. The new TypeSpec generator emits the
    // raw spec property names (e.g. SubscriptionBeneficiaryTenantId / SubscriptionCustomerId)
    // and drops the GA-era flattening duplicates plus the [Obsolete] back-compat aliases
    // (BeneficiaryTenantId/CustomerId/BillingSubscriptionId/SubscriptionAliasBeneficiaryTenantId/
    // SubscriptionAliasCustomerId). Restore them as Custom partial properties so existing
    // callers keep compiling. Type conversion is handled inline where the GA shape used
    // `string` but the new shape uses `Guid?` / `ResourceIdentifier`.
    public partial class BillingSubscriptionAliasData
    {
        /// <summary> The tenant id of the customer for whom the subscription is created. The field is required for MCA Individual (Pay-as-you-go) and Microsoft Partner Agreement accounts. It is also required for some Enterprise Agreement accounts. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionAliasBeneficiaryTenantId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BeneficiaryTenantId
        {
            get => SubscriptionBeneficiaryTenantId?.ToString();
            set => SubscriptionBeneficiaryTenantId = string.IsNullOrEmpty(value) ? null : Guid.Parse(value);
        }

        /// <summary> The ID of the billing subscription with the subscription alias. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionAliasSubscriptionId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier BillingSubscriptionId
            => SubscriptionAliasSubscriptionId is null ? null : new ResourceIdentifier(SubscriptionAliasSubscriptionId);

        /// <summary> The ID of the customer for whom the subscription was created. The field is applicable only for Microsoft Partner Agreement billing accounts. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionAliasCustomerId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CustomerId
        {
            get => SubscriptionCustomerId;
            set => SubscriptionCustomerId = value;
        }

        /// <summary> The tenant id of the customer for whom the subscription is created. The field is required for MCA Individual (Pay-as-you-go) and Microsoft Partner Agreement accounts. It is also required for some Enterprise Agreement accounts. </summary>
        public Guid? SubscriptionAliasBeneficiaryTenantId
        {
            get => SubscriptionBeneficiaryTenantId;
            set => SubscriptionBeneficiaryTenantId = value;
        }

        /// <summary> The ID of the customer for whom the subscription was created. The field is applicable only for Microsoft Partner Agreement billing accounts. </summary>
        public string SubscriptionAliasCustomerId
        {
            get => SubscriptionCustomerId;
            set => SubscriptionCustomerId = value;
        }
    }
}
