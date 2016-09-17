/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Batch
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Storage;
    using Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition;
    using Management.Batch.Models;
    using Management.Batch;
    using Resource;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for BatchAccounts and its parent interfaces.
    /// </summary>
    public partial class BatchAccountsImpl :
        GroupableResources<
            IBatchAccount,
            BatchAccountImpl,
            AccountResourceInner,
            IAccountOperations,
            BatchManager>,
        IBatchAccounts
    {
        private IStorageManager storageManager;

        internal BatchAccountsImpl(IAccountOperations InnerCollection, BatchManager manager, IStorageManager storageManager)
            : base(InnerCollection, manager)
        {
            this.storageManager = storageManager;
        }

        public void Delete(string id)
        {
            Delete(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete(string groupName, string name)
        {
            this.InnerCollection.Delete(groupName, name);
        }

        protected override BatchAccountImpl WrapModel(string name)
        {
            AccountResourceInner inner = new AccountResourceInner();

            return new BatchAccountImpl(
                name,
                inner,
                InnerCollection,
                MyManager, storageManager);
        }

        public PagedList<IBatchAccount> List()
        {
            return new ChildListFlattener<IResourceGroup, IBatchAccount>(MyManager.ResourceManager.ResourceGroups.List(), (IResourceGroup resourceGroup) =>
            {
                return ListByGroup(resourceGroup.Name);
            }).Flatten();
        }

        public PagedList<IBatchAccount> ListByGroup(string resourceGroupName)
        {
            var pagedList = new PagedList<AccountResourceInner>(InnerCollection.ListByResourceGroup(resourceGroupName));
            return WrapList(pagedList);
        }

        protected override IBatchAccount WrapModel(AccountResourceInner inner)
        {
            return new BatchAccountImpl(
                inner.Name,
                inner,
                InnerCollection,
                MyManager,
                storageManager);
        }

        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        public async Task<PagedList<IBatchAccount>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = await InnerCollection.ListByResourceGroupAsync(resourceGroupName, cancellationToken);
            return this.WrapList(new PagedList<AccountResourceInner>(data));
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            await DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public async Task DeleteAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        public override async Task<IBatchAccount> GetByGroupAsync(string resourceGroupName, string name)
        {
            var batchAccount = await InnerCollection.GetAsync(resourceGroupName, name);
            return WrapModel(batchAccount);
        }
    }
}