// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Management.Batch;
    using Management.Batch.Fluent.Models;
    using Resource.Fluent.Core;
    using Storage.Fluent;
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

        internal PagedList<IBatchAccount> List()
        {
            var firstPage = InnerCollection.List();
            var pagedList = new PagedList<BatchAccountInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        internal PagedList<IBatchAccount> ListByGroup(string resourceGroupName)
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

        internal BatchAccountImpl Define(string name)
        {
            return WrapModel(name);
        }

        internal Task<PagedList<IBatchAccount>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        public override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        public override async Task<IBatchAccount> GetByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var batchAccount = await InnerCollection.GetAsync(resourceGroupName, name, cancellationToken);
            return WrapModel(batchAccount);
        }

        internal int GetBatchAccountQuotaByLocation(Region region)
        {
            return locationClient.GetQuotas(region.Name).AccountQuota.GetValueOrDefault();
        }
    }
}