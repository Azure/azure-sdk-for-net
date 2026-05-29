// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591
namespace Azure.ResourceManager.Billing.Models
{
    // Back-compat POCO restored from GA 1.2.2. The new MPG generator renamed this
    // payload to InitiateTransferRequest; this aggregate is preserved so existing
    // GA call sites continue to compile. Resource.Update / Collection.CreateOrUpdate
    // overloads accepting this type forward to the new generated overloads.
    public partial class BillingTransferDetailCreateOrUpdateContent
    {
        public BillingTransferDetailCreateOrUpdateContent() { }

        public string RecipientEmailId { get; set; }
    }
}
