// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    public static partial class ResourcesExtensions
    {
        /// <summary> Decompiles an ARM JSON template into a Bicep template. </summary>
        /// <param name="subscriptionResource"> The subscription on which to perform the operation. </param>
        /// <param name="content"> The decompile operation request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use Azure.ResourceManager.Resources.Bicep.ResourcesBicepExtensions.BicepDecompileAsync instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<DecompileOperationSuccessResult>> BicepDecompileAsync(this SubscriptionResource subscriptionResource, DecompileOperationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableResourcesSubscriptionResource(subscriptionResource).BicepDecompileAsync(content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Decompiles an ARM JSON template into a Bicep template. </summary>
        /// <param name="subscriptionResource"> The subscription on which to perform the operation. </param>
        /// <param name="content"> The decompile operation request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use Azure.ResourceManager.Resources.Bicep.ResourcesBicepExtensions.BicepDecompile instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<DecompileOperationSuccessResult> BicepDecompile(this SubscriptionResource subscriptionResource, DecompileOperationContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableResourcesSubscriptionResource(subscriptionResource).BicepDecompile(content, cancellationToken);
        }
    }
}
