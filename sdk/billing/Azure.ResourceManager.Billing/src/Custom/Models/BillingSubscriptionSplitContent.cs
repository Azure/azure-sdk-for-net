// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Billing.Models
{
    // Back-compat POCO restored from GA 1.2.2. The new MPG generator renamed this
    // payload to BillingSubscriptionSplitRequest and emits TermDuration as a
    // wire-format string. The GA shape exposed TimeSpan?; this aggregate preserves
    // that GA contract and is translated to the new Request via the Resource.Split
    // back-compat overload.
    public partial class BillingSubscriptionSplitContent
    {
        public BillingSubscriptionSplitContent() { }

        [WirePath("billingFrequency")]
        public string BillingFrequency { get; set; }
        [WirePath("quantity")]
        public int? Quantity { get; set; }
        [WirePath("targetProductTypeId")]
        public string TargetProductTypeId { get; set; }
        [WirePath("targetSkuId")]
        public string TargetSkuId { get; set; }
        [WirePath("termDuration")]
        public TimeSpan? TermDuration { get; set; }
    }
}
