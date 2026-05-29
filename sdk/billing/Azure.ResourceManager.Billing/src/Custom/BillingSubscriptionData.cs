// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Billing
{
    // Back-compat shims for GA 1.2.2 API surface. New gen renamed
    // BeneficiaryTenantId (string) -> SubscriptionBeneficiaryTenantId (Guid?)
    // and CustomerId (string) -> SubscriptionCustomerId (string). Restore the
    // [Obsolete] back-compat aliases so existing callers keep compiling.
    public partial class BillingSubscriptionData
    {
        /// <summary> The tenant id of the customer for whom the subscription is created. The field is required for MCA Individual (Pay-as-you-go) and Microsoft Partner Agreement accounts. It is also required for some Enterprise Agreement accounts. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionBeneficiaryTenantId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BeneficiaryTenantId
        {
            get => SubscriptionBeneficiaryTenantId?.ToString();
            set => SubscriptionBeneficiaryTenantId = string.IsNullOrEmpty(value) ? null : Guid.Parse(value);
        }

        /// <summary> The ID of the customer for whom the subscription was created. The field is applicable only for Microsoft Partner Agreement billing accounts. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionCustomerId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CustomerId
        {
            get => SubscriptionCustomerId;
            set => SubscriptionCustomerId = value;
        }
    }
}
