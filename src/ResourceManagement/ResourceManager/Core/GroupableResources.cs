// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
using System.Threading.Tasks;
using System;
using System.Threading;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public abstract class GroupableResources<IFluentResourceT, FluentResourceT, InnerResourceT, InnerCollectionT, ManagerT> :
        CreatableResources<IFluentResourceT, FluentResourceT, InnerResourceT>,
        ISupportsGettingById<IFluentResourceT>,
        ISupportsGettingByResourceGroup<IFluentResourceT>,
        ISupportsDeletingByResourceGroup,
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

        #region Implementation of ISupportsGettingByResourceGroup interface

        protected abstract Task<InnerResourceT> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken);


        public virtual async Task<IFluentResourceT> GetByResourceGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            try
            {
                return WrapModel(await this.GetInnerByGroupAsync(groupName, name, cancellationToken));
            }
            catch (CloudException ex) when (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (AggregateException ex) when((ex.InnerExceptions[0] as CloudException).Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }


        public IFluentResourceT GetByResourceGroup(string groupName, string name)
        {
            return Extensions.Synchronize(() => GetByResourceGroupAsync(groupName, name, CancellationToken.None));
        }

        #endregion

        #region Implementation of ISupportsGettingById interface

        public async Task<IFluentResourceT> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetByResourceGroupAsync(
                    ResourceUtils.GroupFromResourceId(id),
                    ResourceUtils.NameFromResourceId(id),
                    cancellationToken
                );
        }

        public IFluentResourceT GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id, CancellationToken.None));
        }

        #endregion

        #region Implementation of ISupportsDeletingByResourceGroup interface

        protected abstract Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken);

        public virtual async Task DeleteByResourceGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteInnerByGroupAsync(groupName, name, cancellationToken);
        }

        public void DeleteByResourceGroup(string groupName, string name)
        {
            Extensions.Synchronize(() => this.DeleteByResourceGroupAsync(groupName, name, CancellationToken.None));
        }

        #endregion

        #region Implementation of ISupportsDeletingById interface 

        public override void DeleteById(string id)
        {
            Extensions.Synchronize(() => this.DeleteByIdAsync(id));
        }

        public async override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DeleteByResourceGroupAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        #endregion
    }
}
