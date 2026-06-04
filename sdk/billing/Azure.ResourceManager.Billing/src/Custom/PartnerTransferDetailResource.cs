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
    // PartnerTransferDetailData, CT), but the actual generated Update method takes
    // PartnerTransferDetailCreateOrUpdateContent (partner transfer details are only
    // mutated via Initiate/Cancel actions, not via Data envelope). Provide a
    // NotSupportedException overload so the tag-helper compiles; the happy path
    // (tag-resource fallback) is unaffected.
    public partial class PartnerTransferDetailResource
    {
        /// <summary> Not supported. Partner transfer details are only mutated through Initiate and Cancel actions. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<PartnerTransferDetailResource>> UpdateAsync(WaitUntil waitUntil, PartnerTransferDetailData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Updating PartnerTransferDetailResource via the resource data envelope is not supported. Use Initiate or Cancel instead.");
        }

        /// <summary> Not supported. Partner transfer details are only mutated through Initiate and Cancel actions. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PartnerTransferDetailResource> Update(WaitUntil waitUntil, PartnerTransferDetailData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Updating PartnerTransferDetailResource via the resource data envelope is not supported. Use Initiate or Cancel instead.");
        }
    }
}
