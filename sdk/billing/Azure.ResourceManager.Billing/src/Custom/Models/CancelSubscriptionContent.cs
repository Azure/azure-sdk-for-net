// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Billing.Models
{
    // Back-compat POCO restored from GA 1.2.2. The new MPG generator renamed this
    // payload to CancelSubscriptionRequest and emits CustomerId as a plain string.
    // The GA shape exposed Azure.Core.ResourceIdentifier; this aggregate preserves
    // that GA contract and is translated to the new Request via the Resource.Cancel
    // back-compat overload.
    public partial class CancelSubscriptionContent
    {
        public CancelSubscriptionContent(CustomerSubscriptionCancellationReason cancellationReason)
        {
            CancellationReason = cancellationReason;
        }

        public CustomerSubscriptionCancellationReason CancellationReason { get; }
        public ResourceIdentifier CustomerId { get; set; }
    }
}
