// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Billing
{
    // Generator tag-helper boilerplate (#58747) calls this.Update/UpdateAsync(WaitUntil,
    // BillingTransferDetailData, CT), but the actual generated Update method takes
    // BillingTransferDetailCreateOrUpdateContent (transfer details are only mutated via
    // Initiate/Cancel actions, not via Data envelope). Provide a NotSupportedException
    // overload so the tag-helper compiles; the happy path (tag-resource fallback) is
    // unaffected.
    public partial class BillingTransferDetailResource
    {
        /// <summary> Not supported. Transfer details are only mutated through Initiate and Cancel actions. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<BillingTransferDetailResource>> UpdateAsync(WaitUntil waitUntil, BillingTransferDetailData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Updating BillingTransferDetailResource via the resource data envelope is not supported. Use Initiate or Cancel instead.");
        }

        /// <summary> Not supported. Transfer details are only mutated through Initiate and Cancel actions. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BillingTransferDetailResource> Update(WaitUntil waitUntil, BillingTransferDetailData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Updating BillingTransferDetailResource via the resource data envelope is not supported. Use Initiate or Cancel instead.");
        }
    }
}
