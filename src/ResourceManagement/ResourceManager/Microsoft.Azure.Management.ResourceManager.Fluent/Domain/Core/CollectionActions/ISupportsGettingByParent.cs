// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// Provides access to getting a specific Azure resource based on its resource group and parent.
    /// </summary>
    /// <typeparam name="">The type of the resource collection.</typeparam>
    public interface ISupportsGettingByParent<T> 
    {
        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="resourceGroup">The name of resource group.</param>
        /// <param name="parentName">The name of parent resource.</param>
        /// <param name="name">The name of resource.</param>
        /// <return>An immutable representation of the resource.</return>
        T GetByParent(string resourceGroup, string parentName, string name);

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="resourceGroup">The name of resource group.</param>
        /// <param name="parentName">The name of parent resource.</param>
        /// <param name="name">The name of resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Task<T> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="parentResource">The instance of parent resource.</param>
        /// <param name="name">The name of resource.</param>
        /// <return>An immutable representation of the resource.</return>
        T GetByParent(IGroupableResource parentResource, string name);

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource id.
        /// </summary>
        /// <param name="parentResource">The instance of parent resource.</param>
        /// <param name="name">The name of resource.</param>
        /// <return>An immutable representation of the resource.</return>
        Task<T> GetByParentAsync(IGroupableResource parentResource, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}