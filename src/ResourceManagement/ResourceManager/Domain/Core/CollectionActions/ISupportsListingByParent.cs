// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to listing Azure resources of a specific type in a specific parent resource.
    /// 
    /// (Note: this interface is not intended to be implemented by user code).
    /// </summary>
    /// <typeparam name="">The type of the resources listed.</typeparam>
    public interface ISupportsListingByParent<T, ParentT, ManagerT> where ParentT : IResource, IHasResourceGroup
    {
        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="parentName">The name of parent resource.</param>
        /// <return>The list of resources.</return>
        IEnumerable<T> ListByParent(string resourceGroupName, string parentName);

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <param name="parentName">The name of parent resource.</param>
        /// <return>The list of resources.</return>
        Task<IPagedCollection<T>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="parentResource">The instance of parent resource.</param>
        /// <return>An immutable representation of the resource.</return>
        IEnumerable<T> ListByParent(ParentT parentResource);

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="parentResource">The instance of parent resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Task<IPagedCollection<T>> ListByParentAsync(ParentT parentResource, CancellationToken cancellationToken = default(CancellationToken));
    }
}