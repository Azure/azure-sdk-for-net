// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.FileShares.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.FileShares
{
    public static partial class FileSharesExtensions
    {
        /// <summary>
        /// Get file shares limits.
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Task"/> that resolves to the file share limits for the given location. </returns>
        /// <remarks>
        /// Back-compatibility overload for api-version 2026-06-01, where <c>getLimits</c> took no request body. The
        /// request body became optional in 2026-09-01; this overload forwards with no body so existing callers that
        /// passed a positional <see cref="CancellationToken"/> continue to compile.
        /// </remarks>
        public static Task<Response<FileShareLimitsResult>> GetLimitsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableFileSharesSubscriptionResource(subscriptionResource).GetLimitsAsync(location, cancellationToken);
        }

        /// <summary>
        /// Get file shares limits.
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The file share limits for the given location. </returns>
        /// <remarks>
        /// Back-compatibility overload for api-version 2026-06-01, where <c>getLimits</c> took no request body. The
        /// request body became optional in 2026-09-01; this overload forwards with no body so existing callers that
        /// passed a positional <see cref="CancellationToken"/> continue to compile.
        /// </remarks>
        public static Response<FileShareLimitsResult> GetLimits(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableFileSharesSubscriptionResource(subscriptionResource).GetLimits(location, cancellationToken);
        }
    }
}
