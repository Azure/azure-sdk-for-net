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
    // CollectionInfo resource. The generated code now places this workaround POST on
    // PrivateStoreResource.Delete(Guid collectionId, ...). Provide the old signature by delegating
    // to the generated Delete on PrivateStoreResource.
    public partial class PrivateStoreCollectionInfoResource
    {
        /// <summary> Delete Private store collection. This is a workaround. </summary>
        /// <param name="payload"> The operation payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response> DeleteAsync(PrivateStoreOperation? payload, CancellationToken cancellationToken)
        {
            var parent = Client.GetPrivateStoreResource(new Core.ResourceIdentifier(Id.Parent.ToString()));
            return await parent.DeleteAsync(Guid.Parse(Id.Name), payload, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Delete Private store collection. This is a workaround. </summary>
        /// <param name="payload"> The operation payload. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response Delete(PrivateStoreOperation? payload, CancellationToken cancellationToken)
        {
            var parent = Client.GetPrivateStoreResource(new Core.ResourceIdentifier(Id.Parent.ToString()));
            return parent.Delete(Guid.Parse(Id.Name), payload, cancellationToken);
        }
    }
}
