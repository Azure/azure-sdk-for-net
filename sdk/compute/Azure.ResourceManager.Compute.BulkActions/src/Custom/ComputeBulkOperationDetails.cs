// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Compute.BulkActions.Models
{
    public partial class ComputeBulkOperationDetails
    {
        /// <summary> Subscription id attached to the request. </summary>
        public Guid SubscriptionId { get; }
    }
}
