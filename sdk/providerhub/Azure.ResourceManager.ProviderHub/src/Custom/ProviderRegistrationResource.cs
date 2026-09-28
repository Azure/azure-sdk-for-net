// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ProviderHub
{
    // Backward-compat: 1.2.x exposed both the long-running Delete(WaitUntil, ...) overload and a
    // synchronous Delete(CancellationToken) overload. The current generator emits only the former,
    // so these restore the synchronous pair by awaiting the long-running overload to completion.
    public partial class ProviderRegistrationResource
    {
        /// <summary> Deletes the provider registration and waits for the operation to complete. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            return Delete(WaitUntil.Completed, cancellationToken).GetRawResponse();
        }

        /// <summary> Deletes the provider registration and waits for the operation to complete. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            ArmOperation operation = await DeleteAsync(WaitUntil.Completed, cancellationToken).ConfigureAwait(false);
            return operation.GetRawResponse();
        }
    }
}
