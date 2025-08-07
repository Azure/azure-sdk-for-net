// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Billing
{
    /// <summary>
    /// A class representing the BillingSubscriptionAlias data model.
    /// A billing subscription alias.
    /// </summary>
    public partial class BillingSubscriptionAliasData : ResourceData
    {
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
