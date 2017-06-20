// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions
{
    /// <summary>
    /// Provides access to listing Azure resources of a specific type based on their tag.
    /// </summary>
    public interface ISupportsListingByTag<T>
    {
        /// <summary>
        /// Lists all the resources with the specified tag.
        /// </summary>
        /// <param name="tagName">tag's name as the key</param>
        /// <param name="tagValue">tag's value</param>
        /// <return>The list of resources.</return>
        IEnumerable<T> ListByTag(string tagName, string tagValue);

        /// <summary>
        /// Lists all the resources with the specified tag.
        /// </summary>
        /// <param name="tagName">tag's name as the key</param>
        /// <param name="tagValue">tag's value</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <return>A await-able Task for asynchronous operation which will have PagedCollection of the resources.</return>
        Task<IPagedCollection<T>> ListByTagAsync(string tagName, string tagValue, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken));
    }
}
