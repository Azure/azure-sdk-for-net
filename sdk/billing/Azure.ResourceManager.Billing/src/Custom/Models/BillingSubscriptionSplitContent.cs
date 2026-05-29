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

        public string BillingFrequency { get; set; }
        public int? Quantity { get; set; }
        public string TargetProductTypeId { get; set; }
        public string TargetSkuId { get; set; }
        public TimeSpan? TermDuration { get; set; }
    }
}
