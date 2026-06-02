// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ComputeBulkActions.Mocking
{
    /// <summary> A class to add extension methods to <see cref="Azure.ResourceManager.Resources.ResourceGroupResource"/>. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetBulkActionAsync", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetBulkAction", typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    public partial class MockableComputeBulkActionsResourceGroupResource
    {
        /// <summary> Gets an instance of <see cref="BulkActionResource"/>. </summary>
        /// <param name="location"> The location for the resource. </param>
        /// <param name="name"> The name of the bulk action operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<BulkActionResource>> GetBulkActionAsync(AzureLocation location, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return await GetBulkActions(location).GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets an instance of <see cref="BulkActionResource"/>. </summary>
        /// <param name="location"> The location for the resource. </param>
        /// <param name="name"> The name of the bulk action operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<BulkActionResource> GetBulkAction(AzureLocation location, string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return GetBulkActions(location).Get(name, cancellationToken);
        }
    }
}
