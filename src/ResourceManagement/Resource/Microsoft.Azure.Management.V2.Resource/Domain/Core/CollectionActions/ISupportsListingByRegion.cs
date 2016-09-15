/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.ResourceManager.Models;

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
        PagedList<T> ListByRegion (Region region);

        /// <summary>
        /// List all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="regionName">regionName the name of an Azure region</param>
        /// <returns>list of resources</returns>
        PagedList<T> ListByRegion (string regionName);

    }
}