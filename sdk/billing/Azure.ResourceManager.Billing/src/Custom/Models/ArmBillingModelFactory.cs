// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Billing.Models
{
    public partial class ArmBillingModelFactory
    {
        // Back-compat factory for GA 1.2.2 callers. The new MPG generator renamed
        // the action payload to CancelSubscriptionRequest with `string customerId`;
        // GA exposed a CancelSubscriptionContent factory with ResourceIdentifier customerId.
        // The Custom CancelSubscriptionContent POCO (src/Custom/Models/CancelSubscriptionContent.cs)
        // is what callers receive here; it has no internal byte-shape dependency on the
        // generated Request because the generator never emitted the Content type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CancelSubscriptionContent CancelSubscriptionContent(CustomerSubscriptionCancellationReason cancellationReason = default, ResourceIdentifier customerId = null)
        {
            return new CancelSubscriptionContent(cancellationReason) { CustomerId = customerId };
        }
    }
}
