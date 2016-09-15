/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to listing Azure resources of a specific type in a specific resource group.
    /// 
    /// (Note: this interface is not intended to be implemented by user code)
    /// 
    /// @param <T> the type of the resources listed.
    /// </summary>
    public interface ISupportsListingByGroup<T> 
    {
        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">resourceGroupName the name of the resource group to list the resources from</param>
        /// <returns>the list of resources</returns>
        PagedList<T> ListByGroup (string resourceGroupName);

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">resourceGroupName the name of the resource group to list the resources from</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>the list of resources</returns>
        Task<PagedList<T>> ListByGroupAsync (string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));

    }
}