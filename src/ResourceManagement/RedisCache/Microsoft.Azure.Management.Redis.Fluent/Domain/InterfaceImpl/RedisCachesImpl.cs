// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Redis.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class RedisCachesImpl 
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// <p>
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is {@link Creatable#create()}.
        /// <p>
        /// Note that the {@link Creatable#create()} method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see {@link Creatable#create()} among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">name the name of the new resource</param>
        /// <returns>the first stage of the new resource definition</returns>
        Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IBlank Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsCreating<Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IBlank>.Define (string name) {
            return this.Define( name) as Microsoft.Azure.Management.Redis.Fluent.RedisCache.Definition.IBlank;
        }

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">id the resource ID of the resource to delete</param>
        void Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsDeleting.Delete (string id) {
            this.Delete( id);
        }
        Task Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsDeleting.DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public Task DeleteAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(resourceGroupName, name, cancellationToken);
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">resourceGroupName the name of the resource group to list the resources from</param>
        /// <returns>the list of resources</returns>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Redis.Fluent.IRedisCache> Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsListingByGroup<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>.ListByGroup (string resourceGroupName) {
            return this.ListByGroup( resourceGroupName) as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>;
        }

        public Task<PagedList<IRedisCache>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name and the name of its resource group.
        /// </summary>
        /// <param name="resourceGroupName">resourceGroupName the name of the resource group the resource is in</param>
        /// <param name="name">name the name of the resource. (Note, this is not the ID)</param>
        /// <returns>an immutable representation of the resource</returns>
        Microsoft.Azure.Management.Redis.Fluent.IRedisCache Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsGettingByGroup<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>.GetByGroup (string resourceGroupName, string name) {
            return this.GetByGroup( resourceGroupName,  name) as Microsoft.Azure.Management.Redis.Fluent.IRedisCache;
        }


        public override async Task<IRedisCache> GetByGroupAsync(string groupName, string name)
        {
            var storageAccount = await InnerCollection.GetAsync(groupName, name);
            return WrapModel(storageAccount);
        }

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="groupName">groupName The group the resource is part of</param>
        /// <param name="name">name The name of the resource</param>
        void Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsDeletingByGroup.Delete (string groupName, string name) {
            this.Delete( groupName,  name);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <returns>list of resources</returns>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Redis.Fluent.IRedisCache> Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>.List () {
            return this.List() as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Redis.Fluent.IRedisCache>;
        }
    }
}