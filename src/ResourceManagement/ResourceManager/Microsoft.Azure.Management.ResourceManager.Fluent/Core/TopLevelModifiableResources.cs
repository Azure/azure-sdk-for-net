// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;
using System.Threading;
using System;

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
            return WrapList(this.ListInnerAsync(default(CancellationToken)).GetAwaiter().GetResult().AsContinuousCollection(link => ListInnerNextAsync(link, default(CancellationToken)).GetAwaiter().GetResult()));
        }

        public virtual IEnumerable<IFluentResourceT> ListByResourceGroup(string resourceGroupName)
        {
            return WrapList(this.ListInnerByGroupAsync(resourceGroupName, default(CancellationToken)).GetAwaiter().GetResult().AsContinuousCollection(link => ListInnerByGroupNextAsync(link, default(CancellationToken)).GetAwaiter().GetResult()));
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

        public Task<IEnumerable<string>> DeleteByIdsAsync(IEnumerable<string> ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> DeleteByIdsAsync(CancellationToken cancellationToken = default(CancellationToken), params string[] ids)
        {
            throw new NotImplementedException();
        }

        public void DeleteByIds(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public void DeleteByIds(params string[] ids)
        {
            throw new NotImplementedException();
        }
    }
}
