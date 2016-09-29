// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch
{
    using Management.Batch;
    using Microsoft.Azure.Management.Batch.Models;
    using Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Storage;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using V2.Storage;

    /// <summary>
    /// Implementation for BatchAccounts and its parent interfaces.
    /// </summary>
    internal partial class BatchAccountsImpl :
        GroupableResources<
            IBatchAccount,
            BatchAccountImpl,
            BatchAccountInner,
            IBatchAccountOperations,
            BatchManager>,
        IBatchAccounts
    {
        private IStorageManager storageManager;
        private IApplicationOperations applicationsClient;
        private IApplicationPackageOperations applicationPackagesClient;
        private ILocationOperations locationClient;

        internal BatchAccountsImpl(
                IBatchAccountOperations batchAccountOperations,
                BatchManager manager,
                IApplicationOperations applicationsClient,
                IApplicationPackageOperations applicationPackagesClient,
                ILocationOperations locationClient,
                IStorageManager storageManager)
            : base(batchAccountOperations, manager)
        {
            this.storageManager = storageManager;
            this.applicationsClient = applicationsClient;
            this.applicationPackagesClient = applicationPackagesClient;
            this.locationClient = locationClient;
        }

        public void Delete(string id)
        {
            Delete(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete(string groupName, string name)
        {
            InnerCollection.Delete(groupName, name);
        }

        protected override BatchAccountImpl WrapModel(string name)
        {
            var inner = new BatchAccountInner();

            return new BatchAccountImpl(
                name,
                inner,
                InnerCollection,
                Manager,
                applicationsClient,
                applicationPackagesClient,
                storageManager);
        }

        public PagedList<Microsoft.Azure.Management.Fluent.Batch.IBatchAccount> List()
        {
            var firstPage = InnerCollection.List();
            var pagedList = new PagedList<BatchAccountInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        public PagedList<Microsoft.Azure.Management.Fluent.Batch.IBatchAccount> ListByGroup(string resourceGroupName)
        {
            var firstPage = InnerCollection.ListByResourceGroup(resourceGroupName);
            var pagedList = new PagedList<BatchAccountInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListByResourceGroupNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        protected override IBatchAccount WrapModel(BatchAccountInner inner)
        {
            return new BatchAccountImpl(
                inner.Name,
                inner,
                InnerCollection,
                Manager,
                applicationsClient,
                applicationPackagesClient,
                storageManager);
        }

        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        public Task<PagedList<IBatchAccount>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
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

        public int GetBatchAccountQuotaByLocation(Region region)
        {
            return locationClient.GetQuotas(region.ToString()).AccountQuota.GetValueOrDefault();
        }
    }
}