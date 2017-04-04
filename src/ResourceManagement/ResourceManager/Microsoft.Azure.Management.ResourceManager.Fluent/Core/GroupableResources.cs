// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public abstract class GroupableResources<IFluentResourceT, FluentResourceT, InnerResourceT, InnerCollectionT, ManagerT> :
        CreatableResources<IFluentResourceT, FluentResourceT, InnerResourceT>,
        ISupportsGettingById<IFluentResourceT>,
        ISupportsGettingByGroup<IFluentResourceT>,
        ISupportsDeletingByGroup,
        IHasManager<ManagerT>,
        IHasInner<InnerCollectionT>
        where IFluentResourceT : class, IGroupableResource<ManagerT, InnerResourceT>
        where FluentResourceT : IFluentResourceT
        where ManagerT : IManagerBase
    {
        protected GroupableResources(InnerCollectionT innerCollection, ManagerT manager)
        {
            Inner = innerCollection;
            Manager = manager;
        }

        public ManagerT Manager { get; }

        public InnerCollectionT Inner
        {
            get; private set;
        }

        #region Implementation of ISupportsGettingByGroup interface

        protected abstract Task<InnerResourceT> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken);


        public virtual async Task<IFluentResourceT> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return WrapModel(await this.GetInnerByGroupAsync(groupName, name, cancellationToken));
        }


        public IFluentResourceT GetByGroup(string groupName, string name)
        {
            return GetByGroupAsync(groupName, name, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        #endregion

        #region Implementation of ISupportsGettingById interface

        public async Task<IFluentResourceT> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetByGroupAsync(
                    ResourceUtils.GroupFromResourceId(id),
                    ResourceUtils.NameFromResourceId(id),
                    cancellationToken
                );
        }

        public IFluentResourceT GetById(string id)
        {
            return GetByIdAsync(id, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        #endregion

        #region Implementation of ISupportsDeletingByGroup interface

        protected abstract Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken);

        public virtual async Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteInnerByGroupAsync(groupName, name, cancellationToken);
        }

        public void DeleteByGroup(string groupName, string name)
        {
            this.DeleteByGroupAsync(groupName, name, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        #endregion

        #region Implementation of ISupportsDeletingById interface 

        public override void DeleteById(string id)
        {
            this.DeleteByIdAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteByGroupAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        #endregion
    }
}
