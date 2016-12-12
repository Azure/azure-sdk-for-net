// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    public abstract class GroupableResources<IFluentResourceT, FluentResourceT, InnerResourceT, InnerCollectionT, ManagerT> :
        CreatableResources<IFluentResourceT, FluentResourceT, InnerResourceT>,
        ISupportsGettingById<IFluentResourceT>,
        ISupportsGettingByGroup<IFluentResourceT>,
        ISupportsDeletingByGroup,
        IHasManager<ManagerT>
        where IFluentResourceT : class, IGroupableResource
        where FluentResourceT : IFluentResourceT
        where ManagerT : IManagerBase
    {
        protected GroupableResources(InnerCollectionT innerCollection, ManagerT manager)
        {
            InnerCollection = innerCollection;
            Manager = manager;
        }

        protected InnerCollectionT InnerCollection { get; }

        public ManagerT Manager { get; }

        #region Implementation of ISupportsGettingByGroup interface

        public abstract Task<IFluentResourceT> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken);

        public IFluentResourceT GetByGroup(string groupName, string name)
        {
            return GetByGroupAsync(groupName, name, CancellationToken.None).Result;
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
            return GetByIdAsync(id, CancellationToken.None).Result;
        }

        #endregion

        #region Implementation of ISupportsDeletingByGroup interface

        public abstract Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

        public void DeleteByGroup(string groupName, string name)
        {
            this.DeleteByGroupAsync(groupName, name, CancellationToken.None).Wait();
        }

        #endregion

        #region Implementation of ISupportsDeletingById interface 

        public override void DeleteById(string id)
        {
            this.DeleteByIdAsync(id).Wait();
        }

        public override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.DeleteByGroupAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        #endregion
    }
}
