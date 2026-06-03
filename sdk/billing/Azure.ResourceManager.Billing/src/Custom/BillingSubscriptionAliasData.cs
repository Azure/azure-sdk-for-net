// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // See BillingSubscriptionData for the root-cause explanation. Same situation applies on
    // BillingSubscriptionAliasData — inner BillingSubscriptionAliasProperties extends
    // BillingSubscriptionProperties and inherits beneficiaryTenantId/customerId, which MPG
    // does not flatten onto the Read-only Alias Data wrapper.
    public partial class BillingSubscriptionAliasData
    {
        /// <summary> The provisioning tenant of the subscription. </summary>
        [WirePath("properties.beneficiaryTenantId")]
        public Guid? SubscriptionAliasBeneficiaryTenantId
        {
            get => Properties?.BeneficiaryTenantId;
            set
            {
                Properties ??= new BillingSubscriptionAliasProperties();
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
                Properties ??= new BillingSubscriptionAliasProperties();
                Properties.CustomerId = value;
            }
        }

        /// <summary> The provisioning tenant of the subscription. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionAliasBeneficiaryTenantId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BeneficiaryTenantId { get; set; }
        /// <summary> The ID of the customer for whom the subscription was created. The field is applicable only for Microsoft Partner Agreement billing accounts. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionAliasCustomerId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CustomerId { get; set; }
        /// <summary> The ID of the billing subscription with the subscription alias. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `SubscriptionAliasSubscriptionId` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier BillingSubscriptionId { get; }
    }
}
