// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.DesktopVirtualization.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    public partial class SessionHostResource
    {
        /// <summary> Update a session host. </summary>
        /// <param name="patch"> Object containing SessionHost definitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SessionHostResource>> UpdateAsync(SessionHostPatch patch, CancellationToken cancellationToken = default)
            => await UpdateAsync(patch, null, cancellationToken).ConfigureAwait(false);

        /// <summary> Update a session host. </summary>
        /// <param name="patch"> Object containing SessionHost definitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SessionHostResource> Update(SessionHostPatch patch, CancellationToken cancellationToken = default)
            => Update(patch, null, cancellationToken);
    }
}
