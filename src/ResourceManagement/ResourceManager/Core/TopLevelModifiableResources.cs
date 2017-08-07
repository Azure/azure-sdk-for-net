// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public abstract class TopLevelModifiableResources<IFluentResourceT, FluentResourceT, InnerResourceT, InnerCollectionT, ManagerT> :
        GroupableResources<IFluentResourceT, FluentResourceT, InnerResourceT, InnerCollectionT, ManagerT>,
        ISupportsGettingById<IFluentResourceT>,
        ISupportsGettingByResourceGroup<IFluentResourceT>,
        ISupportsDeletingByResourceGroup,
        IHasManager<ManagerT>,
        ISupportsListing<IFluentResourceT>,
        ISupportsListingByResourceGroup<IFluentResourceT>,
        IHasInner<InnerCollectionT>,
        ISupportsBatchDeletion
        where IFluentResourceT : class, IGroupableResource<ManagerT, InnerResourceT>
        where FluentResourceT : IFluentResourceT
        where ManagerT : IManagerBase
    {
        public TopLevelModifiableResources(InnerCollectionT innerCollection, ManagerT manager) : base(innerCollection, manager)
        {
        }

        public virtual IEnumerable<IFluentResourceT> List()
        {
            
            return WrapList(Extensions.Synchronize(() => this.ListInnerAsync(default(CancellationToken)))
                .AsContinuousCollection(link => Extensions.Synchronize(() => ListInnerNextAsync(link, default(CancellationToken)))));
        }

        public virtual IEnumerable<IFluentResourceT> ListByResourceGroup(string resourceGroupName)
        {
            return WrapList(Extensions.Synchronize(() => this.ListInnerByGroupAsync(resourceGroupName, default(CancellationToken)))
                .AsContinuousCollection(link => Extensions.Synchronize(() => ListInnerByGroupNextAsync(link, default(CancellationToken)))));
        }

        public virtual async Task<IPagedCollection<IFluentResourceT>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IFluentResourceT, InnerResourceT>.LoadPage(ListInnerAsync, ListInnerNextAsync, WrapModel, loadAllPages, cancellationToken);
        }

        public virtual async Task<IPagedCollection<IFluentResourceT>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IFluentResourceT, InnerResourceT>.LoadPage(
                async(cancellation) => await ListInnerByGroupAsync(resourceGroupName, cancellation),
                ListInnerByGroupNextAsync, WrapModel, loadAllPages, cancellationToken);
        }

        protected abstract Task<IPage<InnerResourceT>> ListInnerAsync(CancellationToken cancellationToken);

        protected abstract Task<IPage<InnerResourceT>> ListInnerNextAsync(string link, CancellationToken cancellationToken);

        protected abstract Task<IPage<InnerResourceT>> ListInnerByGroupAsync(string resourceGroupName, CancellationToken cancellationToken);

        protected abstract Task<IPage<InnerResourceT>> ListInnerByGroupNextAsync(string link, CancellationToken cancellationToken);

        protected static IPage<InnerResourceT> ConvertToPage(IEnumerable<InnerResourceT> list)
        {
            return Extensions.ConvertToPage(list);
        }

        public async Task<IEnumerable<string>> DeleteByIdsAsync(IList<string> ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            var taskList = ids.Select(id => DeleteByIdAsync(id, cancellationToken)).ToList();
            await Task.WhenAll(taskList);
            return ids;
        }

        public Task<IEnumerable<string>> DeleteByIdsAsync(string[] ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteByIdsAsync(new List<string>(ids), cancellationToken);
        }

        public void DeleteByIds(IList<string> ids)
        {
            DeleteByIdsAsync(ids).Wait();
        }

        public void DeleteByIds(params string[] ids)
        {
            DeleteByIdsAsync(ids).Wait();
        }
    }
}
