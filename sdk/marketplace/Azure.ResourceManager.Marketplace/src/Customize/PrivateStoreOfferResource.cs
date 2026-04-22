// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Marketplace.Models;

namespace Azure.ResourceManager.Marketplace
{
    // Backward-compat shim: old API exposed Delete(PrivateStoreOperation?, CancellationToken) on the
    // Offer resource. The generated code now places this workaround POST on
    // PrivateStoreCollectionInfoResource.Delete(string offerId, ...). Provide the old signature by
    // delegating to the generated Delete on PrivateStoreCollectionInfoResource.
    public partial class PrivateStoreOfferResource
    {
        /// <summary> Delete Private store offer. This is a workaround. </summary>
        /// <param name="payload"> The operation payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> DeleteAsync(PrivateStoreOperation? payload, CancellationToken cancellationToken)
        {
            var parent = Client.GetPrivateStoreCollectionInfoResource(new Core.ResourceIdentifier(Id.Parent.ToString()));
            return await parent.DeleteAsync(Id.Name, payload, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Delete Private store offer. This is a workaround. </summary>
        /// <param name="payload"> The operation payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Delete(PrivateStoreOperation? payload, CancellationToken cancellationToken)
        {
            var parent = Client.GetPrivateStoreCollectionInfoResource(new Core.ResourceIdentifier(Id.Parent.ToString()));
            return parent.Delete(Id.Name, payload, cancellationToken);
        }
    }
}
