// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to listing Azure resources of a specific type based on their region.
    /// <p>
    /// (Note: this interface is not intended to be implemented by user code)
    /// 
    /// @param <T> the fluent type of the resource
    /// </summary>
    public interface ISupportsListingByRegion<T> 
    {
        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">region the selected Azure region</param>
        /// <returns>list of resources</returns>
        IEnumerable<T> ListByRegion (Region region);

        /// <summary>
        /// List all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="regionName">regionName the name of an Azure region</param>
        /// <returns>list of resources</returns>
        IEnumerable<T> ListByRegion (string regionName);

        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">the selected Azure region</param>
        /// <param name="cancellationToken">the cancellation token</param>
        /// <returns>a representation of the deferred computation of this call, returning the requested resources</returns>
        Task<IPagedCollection<T>> ListByRegionAsync(Region region, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">the selected Azure region</param>
        /// <param name="cancellationToken">the cancellation token</param>
        /// <returns>a representation of the deferred computation of this call, returning the requested resources</returns>
        Task<IPagedCollection<T>> ListByRegionAsync(string region, CancellationToken cancellationToken = default(CancellationToken));
    }
}