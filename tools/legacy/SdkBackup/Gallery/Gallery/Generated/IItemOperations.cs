// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Gallery.Models;

namespace Microsoft.Azure.Gallery
{
    /// <summary>
    /// Operations for working with gallery items.
    /// </summary>
    public partial interface IItemOperations
    {
        /// <summary>
        /// Gets a gallery items.
        /// </summary>
        /// <param name='itemIdentity'>
        /// Gallery item identity.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Gallery item information.
        /// </returns>
        Task<ItemGetParameters> GetAsync(string itemIdentity, CancellationToken cancellationToken);
        
        /// <summary>
        /// Gets collection of gallery items.
        /// </summary>
        /// <param name='parameters'>
        /// Query parameters. If null is passed returns all gallery items.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// List of gallery items.
        /// </returns>
        Task<ItemListResult> ListAsync(ItemListParameters parameters, CancellationToken cancellationToken);
    }
}
