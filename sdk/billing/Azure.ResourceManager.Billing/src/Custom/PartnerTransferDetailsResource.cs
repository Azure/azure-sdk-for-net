// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Billing
{
    public partial class PartnerTransferDetailsResource
    {
        /// <summary>
        /// Update by full resource data is not supported by the service; partner transfer details
        /// are only mutated through the Initiate and Cancel actions. This overload exists to
        /// satisfy the auto-generated tag boilerplate.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<PartnerTransferDetailsResource>> UpdateAsync(WaitUntil waitUntil, PartnerTransferDetailsData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Updating PartnerTransferDetailsResource via the resource data envelope is not supported. Use Initiate or Cancel instead.");
        }

        /// <summary>
        /// Update by full resource data is not supported by the service; partner transfer details
        /// are only mutated through the Initiate and Cancel actions. This overload exists to
        /// satisfy the auto-generated tag boilerplate.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PartnerTransferDetailsResource> Update(WaitUntil waitUntil, PartnerTransferDetailsData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Updating PartnerTransferDetailsResource via the resource data envelope is not supported. Use Initiate or Cancel instead.");
        }
    }
}
