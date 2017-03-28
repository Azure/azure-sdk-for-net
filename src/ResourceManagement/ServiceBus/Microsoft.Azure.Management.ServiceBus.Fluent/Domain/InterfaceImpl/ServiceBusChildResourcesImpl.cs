// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using Microsoft.Rest;
    using System.Collections.Generic;
    using ResourceManager.Fluent.Core;

    internal abstract partial class ServiceBusChildResourcesImpl<T,ImplT,InnerT,InnerCollectionT,ManagerT,ParentT> 
    {
        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource name.
        /// </summary>
        /// <param name="name">The name of the resource to delete.</param>
        void ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByName.DeleteByName(string name)
        {
            this.DeleteByName(name);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        PagedList<T> ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<T>.List()
        {
            return this.List() as PagedList<T>;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name within the current resource group.
        /// </summary>
        /// <param name="name">The name of the resource. (Note, this is not the resource ID.).</param>
        /// <return>An immutable representation of the resource.</return>
        T ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByName<T>.GetByName(string name)
        {
            return this.GetByName(name) as T;
        }

        /// <summary>
        /// Gets the information about a resource based on the resource name.
        /// </summary>
        /// <param name="name">The name of the resource. (Note, this is not the resource ID.).</param>
        /// <return>An immutable representation of the resource.</return>
        Task<T> ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByName<T>.GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return this.GetByNameAsync(name, cancellationToken);
        }
    }
}