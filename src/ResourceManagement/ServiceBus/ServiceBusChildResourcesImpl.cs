// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.CollectionActions;
    using System.Linq;
    using Rest.Azure;

    /// <summary>
    /// Base class for Service Bus child entities.
    /// Note: When we refactor 'IndependentChildResourcesImpl', move features of this type
    /// to 'IndependentChildResourcesImpl' and remove this type.
    /// </summary>
    /// <typeparam name="">The model interface type.</typeparam>
    /// <typeparam name="Impl">The model interface implementation.</typeparam>
    /// <typeparam name="Inner">The inner model.</typeparam>
    /// <typeparam name="InnerCollection">The inner collection.</typeparam>
    /// <typeparam name="Manager">The manager.</typeparam>
    /// <typeparam name="Parent">The parent model interface type.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uU2VydmljZUJ1c0NoaWxkUmVzb3VyY2VzSW1wbA==
    internal abstract partial class ServiceBusChildResourcesImpl<T,ImplT,InnerT,InnerCollectionT,ManagerT,ParentT>  :
        IndependentChildResourcesImpl<T,ImplT,InnerT,InnerCollectionT,ManagerT,ParentT>,
        ISupportsGettingByName<T>,
        ISupportsListing<T>,
        ISupportsDeletingByName
        where T : class, IHasId
        where ImplT : T
        where ParentT : Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource, IHasResourceGroup
    {
        ///GENMHASH:C091A12D2E54DEE92C5C0A51885174ED:0FCD47CBCD9128C3D4A03458C5796741
        protected  ServiceBusChildResourcesImpl(InnerCollectionT innerCollection, 
            ManagerT manager) : base(innerCollection, manager)
        {
        }

        ///GENMHASH:AD2F63EB9B7A81CCDA7E3A349748EDF7:27E486AB74A10242FF421C0798DDC450
        protected abstract Task<InnerT> GetInnerByNameAsync(string name, CancellationToken cancellationToken);

        ///GENMHASH:885F10CFCF9E6A9547B0702B4BBD8C9E:16F094D018A7AB696812573A607E81FE
        public async Task<T> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await GetInnerByNameAsync(name, cancellationToken);
            return WrapModel(inner);
        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:6B6D1D91AC2FCE3076EBD61D0DB099CF
        public T GetByName(string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(name));
        }

        public abstract Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:C2DC9CFAB6C291D220DD4F29AFF1BBEC:7459D8B9F8BB0A1EBD2FC4702A86F2F5
        public void DeleteByName(string name)
        {
            Extensions.Synchronize(() => DeleteByNameAsync(name));
        }

        ///GENMHASH:D3FBF3E757A0D33222555A7D439A3F12:A13124E7BC21C819368C8CFA9F3DBE5F
        public async Task<IList<string>> DeleteByNameAsync(IList<string> names, CancellationToken cancellationToken = default(CancellationToken))
        {
            var taskList = names.Select(name =>
                       DeleteByNameAsync(name, cancellationToken)).ToList();
            await Task.WhenAll(taskList);
            return names;
        }

        protected abstract Task<IPage<InnerT>> ListInnerFirstPageAsync(CancellationToken cancellationToken);
        protected abstract Task<IPage<InnerT>> ListInnerNextPageAsync(string nextLink, CancellationToken cancellationToken);

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:874C7A8E3CDF988B4BDA901B0FE62ABD
        public IEnumerable<T> List()
        {
            return WrapList(Extensions.Synchronize(() => ListInnerFirstPageAsync(default(CancellationToken)))
                            .AsContinuousCollection(link => Extensions.Synchronize(() => ListInnerNextPageAsync(link, default(CancellationToken)))));
        }

        public async Task<IPagedCollection<T>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<T, InnerT>.LoadPage(
                async (cancellation) => await ListInnerFirstPageAsync(cancellation),
                async (nextLink, cancellation) => await ListInnerNextPageAsync(nextLink, cancellation),
                WrapModel, loadAllPages, cancellationToken);
        }
    }
}