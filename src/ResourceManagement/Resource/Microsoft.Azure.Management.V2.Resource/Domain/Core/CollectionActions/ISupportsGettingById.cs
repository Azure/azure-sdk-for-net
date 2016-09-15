/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{

    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to getting a specific Azure resource based on its resource ID.
    /// 
    /// @param <T> the type of the resource collection
    /// </summary>
    public interface ISupportsGettingById<T> 
    {
        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">id the id of the resource.</param>
        /// <returns>an immutable representation of the resource</returns>
        T GetById (string id);

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="id">id the id of the resource.</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>an immutable representation of the resource</returns>
        Task<T> GetByIdAsync (string id, CancellationToken cancellationToken = default(CancellationToken));

    }
}