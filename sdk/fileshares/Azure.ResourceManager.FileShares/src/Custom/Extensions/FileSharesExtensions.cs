// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.FileShares.Mocking;
using Azure.ResourceManager.FileShares.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.FileShares
{
    public static partial class FileSharesExtensions
    {
        /// <summary>
        /// Get file shares limits.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.FileShares/locations/{location}/getLimits. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> InformationalOperations_GetLimits. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableFileSharesSubscriptionResource.GetLimitsAsync(AzureLocation, FileShareLimitsContent, CancellationToken)"/> instead. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        public static Task<Response<FileShareLimitsResult>> GetLimitsAsync(this SubscriptionResource subscriptionResource, AzureLocation location, FileShareLimitsContent content = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableFileSharesSubscriptionResource(subscriptionResource).GetLimitsAsync(location, content, cancellationToken);
        }

        /// <summary>
        /// Get file shares limits.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.FileShares/locations/{location}/getLimits. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> InformationalOperations_GetLimits. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableFileSharesSubscriptionResource.GetLimits(AzureLocation, FileShareLimitsContent, CancellationToken)"/> instead. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="location"> The name of the Azure region. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        public static Response<FileShareLimitsResult> GetLimits(this SubscriptionResource subscriptionResource, AzureLocation location, FileShareLimitsContent content = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableFileSharesSubscriptionResource(subscriptionResource).GetLimits(location, content, cancellationToken);
        }

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
