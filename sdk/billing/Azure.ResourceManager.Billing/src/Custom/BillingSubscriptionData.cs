// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat shims for GA 1.2.2 API surface.
    //
    // GA exposed the inner BillingSubscriptionProperties fields beneficiaryTenantId/customerId
    // both as outer flatten proxies on the read-only Data wrapper (SubscriptionBeneficiaryTenantId,
    // SubscriptionCustomerId) AND as obsolete short-name aliases (BeneficiaryTenantId, CustomerId).
    // MPG's FlattenPropertyVisitor only emits inner {get;} fields as outer proxies on Resource
    // Data wrappers; the inner fields are {get;set;} so they are dropped from the Resource shape
    // and only surface on the Patch wrapper. Restore the GA Data shape via these forwarders.
    public partial class BillingSubscriptionData
    {
        /// <summary> The provisioning tenant of the subscription. </summary>
        [WirePath("properties.beneficiaryTenantId")]
        public Guid? SubscriptionBeneficiaryTenantId
        {
            get => Properties?.BeneficiaryTenantId;
            set
            {
                Properties ??= new BillingSubscriptionProperties();
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
                Properties ??= new BillingSubscriptionProperties();
                Properties.CustomerId = value;
            }
        }

        /// <summary> The provisioning tenant of the subscription. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionBeneficiaryTenantId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BeneficiaryTenantId { get; set; }
        /// <summary> The ID of the customer for whom the subscription was created. The field is applicable only for Microsoft Partner Agreement billing accounts. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionCustomerId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CustomerId { get; set; }
    }
}
