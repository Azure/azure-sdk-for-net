// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions
{

    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to getting a specific Azure resource based on its name within the current resource group.
    /// 
    /// @param <T> the type of the resource collection
    /// </summary>
    public interface ISupportsGettingByName<T> 
    {
        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name within the current resource group.
        /// </summary>
        /// <param name="name">name the name of the resource. (Note, this is not the resource ID.)</param>
        /// <returns>an immutable representation of the resource</returns>
        T GetByName (string name);

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name within the current resource group.
        /// </summary>
        /// <param name="name">name the name of the resource. (Note, this is not the resource ID.)</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>an immutable representation of the resource</returns>
        Task<T> GetByNameAsync (string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}