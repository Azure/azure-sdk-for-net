// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    using CollectionActions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class for independent child collection class.
    /// (Internal use only).
    /// </summary>
    /// <typeparam name="">The individual resource type returned.</typeparam>
    /// <typeparam name="Impl">The individual resource implementation.</typeparam>
    /// <typeparam name="Inner">The wrapper inner type.</typeparam>
    /// <typeparam name="InnerCollection">The inner type of the collection object.</typeparam>
    /// <typeparam name="Manager">The manager type for this resource provider type.</typeparam>
    public abstract partial class IndependentChildrenImpl<T, ImplT, InnerT, InnerCollectionT, ManagerT> :
        CreatableResources<T, ImplT, InnerT>,
        ISupportsGettingById<T>,
        ISupportsGettingByParent<T>,
        ISupportsListingByParent<T>,
        ISupportsDeletingById,
        ISupportsDeletingByParent
        where T : class, IHasId
        where ImplT : T
    {
        protected InnerCollectionT innerCollection;
        protected ManagerT manager;

        public IndependentChildrenImpl(InnerCollectionT innerCollection, ManagerT manager)
        {
            this.innerCollection = innerCollection;
            this.manager = manager;
        }

        public T GetById(string id)
        {
            return GetByIdAsync(id).Result;
        }

        public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.ParseResourceId(id);

            return await GetByParentAsync(resourceId.ResourceGroupName, resourceId.Parent.Name, resourceId.Name);
        }

        public T GetByParent(IGroupableResource parentResource, string name)
        {
            return GetByParent(parentResource.ResourceGroupName, parentResource.Name, name);
        }

        public T GetByParent(string resourceGroup, string parentName, string name)
        {
            return GetByParentAsync(resourceGroup, parentName, name).Result;
        }

        public async Task<T> GetByParentAsync(IGroupableResource parentResource, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetByParentAsync(parentResource.ResourceGroupName, parentResource.Name, name);
        }

        public PagedList<T> ListByParent(IGroupableResource parentResource)
        {
            return ListByParent(parentResource.ResourceGroupName, parentResource.Name);
        }

        public PagedList<T> ListByParent(string resourceGroupName, string parentName)
        {
            return ListByParentAsync(resourceGroupName, parentName).Result;
        }

        public async Task<PagedList<T>> ListByParentAsync(IGroupableResource parentResource, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ListByParentAsync(parentResource.ResourceGroupName, parentResource.Name);
        }

        public override void DeleteById(string id)
        {
            DeleteByIdAsync(id).Wait();
        }

        public override async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.ParseResourceId(id);

            await DeleteByParentAsync(resourceId.ResourceGroupName, resourceId.Parent.Name, resourceId.Name);
        }

        public void DeleteByParent(string groupName, string parentName, string name)
        {
            Task.WaitAll(DeleteByParentAsync(groupName, parentName, name));
        }

        public abstract Task<T> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken));

        public abstract Task<PagedList<T>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken));

        public abstract Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}