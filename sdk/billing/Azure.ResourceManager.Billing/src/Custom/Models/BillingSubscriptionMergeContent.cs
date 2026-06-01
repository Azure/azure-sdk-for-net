// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591
namespace Azure.ResourceManager.Billing.Models
{
    // Back-compat POCO restored from GA 1.2.2. The new MPG generator renamed this
    // payload to BillingSubscriptionMergeRequest; this aggregate is preserved so
    // existing GA call sites that pass BillingSubscriptionMergeContent continue
    // to compile. The Resource.Merge overload that accepts this type forwards
    // to the new generated overload.
    public partial class BillingSubscriptionMergeContent
    {
        public BillingSubscriptionMergeContent() { }

        [WirePath("quantity")]
        public int? Quantity { get; set; }
        [WirePath("targetBillingSubscriptionName")]
        public string TargetBillingSubscriptionName { get; set; }
    }
}
