// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    using CollectionActions;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Rest.Azure;
    using System;

    /// <summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlc291cmNlcy5mbHVlbnRjb3JlLmFybS5jb2xsZWN0aW9uLmltcGxlbWVudGF0aW9uLkluZGVwZW5kZW50Q2hpbGRyZW5JbXBs
    /// Base class for independent child collection class.
    /// (Internal use only).
    /// </summary>
    /// <typeparam name="">The individual resource type returned.</typeparam>
    /// <typeparam name="Impl">The individual resource implementation.</typeparam>
    /// <typeparam name="Inner">The wrapper inner type.</typeparam>
    /// <typeparam name="InnerCollection">The inner type of the collection object.</typeparam>
    /// <typeparam name="Manager">The manager type for this resource provider type.</typeparam>

    public abstract partial class IndependentChildrenImpl<T, ImplT, InnerT, InnerCollectionT, ManagerT, ParentT> :
        CreatableResources<T, ImplT, InnerT>,
        ISupportsGettingById<T>,
        ISupportsGettingByParent<T, ParentT, ManagerT>,
        ISupportsListingByParent<T, ParentT, ManagerT>,
        ISupportsDeletingById,
        ISupportsDeletingByParent,
        IHasManager<ManagerT>,
        IHasInner<InnerCollectionT>
        where T : class, IHasId
        where ImplT : T
        where ParentT : IResource, IHasResourceGroup
    {
        private InnerCollectionT innerCollection;

        public ManagerT Manager { get; private set; }

        public InnerCollectionT Inner
        {
            get
            {
                return innerCollection;
            }
        }

        ///GENMHASH:ED07292865768A689F918C1B84A21178:E628E6DE6456B030DED192E940597C6E
        public IndependentChildrenImpl(InnerCollectionT innerCollection, ManagerT manager)
        {
            this.innerCollection = innerCollection;
            Manager = manager;
        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:A2A025A9F2772D74D0B8615C6144E641
        public T GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id));
        }

        public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id);

            try
            {
                return await GetByParentAsync(resourceId.ResourceGroupName, resourceId.Parent.Name, resourceId.Name, cancellationToken);
            }
            catch(CloudException ex) when (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (AggregateException ex) when ((ex.InnerExceptions[0] as CloudException).Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        ///GENMHASH:B1F9F82090ABF692D9645AE6B2D732EE:B8247A96B5B602D0F01FFC494377AA87
        public T GetByParent(ParentT parentResource, string name)
        {
            return GetByParent(parentResource.ResourceGroupName, parentResource.Name, name);
        }

        public T GetByParent(string resourceGroup, string parentName, string name)
        {
            try
            {
                return Extensions.Synchronize(() => GetByParentAsync(resourceGroup, parentName, name));
            }
            catch (CloudException ex) when (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (AggregateException ex) when ((ex.InnerExceptions[0] as CloudException).Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<T> GetByParentAsync(ParentT parentResource, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                return await GetByParentAsync(parentResource.ResourceGroupName, parentResource.Name, name, cancellationToken);
            }
            catch (CloudException ex) when (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (AggregateException ex) when ((ex.InnerExceptions[0] as CloudException).Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        ///GENMHASH:A0A10EB2FF1149F056003612DA902E09:D8BC76ED0E6FF85C69301F568869AE3D
        public IEnumerable<T> ListByParent(ParentT parentResource)
        {
            return ListByParent(parentResource.ResourceGroupName, parentResource.Name);
        }

        public IEnumerable<T> ListByParent(string resourceGroupName, string parentName)
        {
            return Extensions.Synchronize(() => ListByParentAsync(resourceGroupName, parentName));
        }

        public async Task<IPagedCollection<T>> ListByParentAsync(ParentT parentResource, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ListByParentAsync(parentResource.ResourceGroupName, parentResource.Name, cancellationToken);
        }

        public override void DeleteById(string id)
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id));
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:F75A1B8CEFE83AE0B483457A2928324B
        public async override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id);

            await DeleteByParentAsync(resourceId.ResourceGroupName, resourceId.Parent.Name, resourceId.Name, cancellationToken);
        }

        ///GENMHASH:60749B1ABD9ABFE5DA6F2DE13BAF999E:84B11042D38049C213681791B3D8EAEB
        public void DeleteByParent(string groupName, string parentName, string name)
        {
            Task.WaitAll(DeleteByParentAsync(groupName, parentName, name));
        }

        public abstract Task<T> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken));

        public abstract Task<IPagedCollection<T>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken));

        public abstract Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}
