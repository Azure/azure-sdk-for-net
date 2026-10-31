// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.FileShares.Models;

namespace Azure.ResourceManager.FileShares.Mocking
{
    public partial class MockableFileSharesSubscriptionResource
    {
        /// <summary>
        /// Get file shares limits.
        /// </summary>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Task"/> that resolves to the file share limits for the given location. </returns>
        /// <remarks> Back-compatibility overload; forwards to the current overload with no request body. </remarks>
        public virtual Task<Response<FileShareLimitsResult>> GetLimitsAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetLimitsAsync(location, default, cancellationToken);

        /// <summary>
        /// Get file shares limits.
        /// </summary>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The file share limits for the given location. </returns>
        /// <remarks> Back-compatibility overload; forwards to the current overload with no request body. </remarks>
        public virtual Response<FileShareLimitsResult> GetLimits(AzureLocation location, CancellationToken cancellationToken)
            => GetLimits(location, default, cancellationToken);
    }
}
