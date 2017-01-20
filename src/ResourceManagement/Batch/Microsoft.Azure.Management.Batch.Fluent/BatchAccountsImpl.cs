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
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmJhdGNoLmltcGxlbWVudGF0aW9uLkJhdGNoQWNjb3VudHNJbXBs
    public partial class BatchAccountsImpl :
        GroupableResources<
            IBatchAccount,
            BatchAccountImpl,
            BatchAccountInner,
            IBatchAccountOperations,
            IBatchManager>,
        IBatchAccounts
    {
        private IStorageManager storageManager;
        private IApplicationOperations applicationsClient;
        private IApplicationPackageOperations applicationPackagesClient;
        private ILocationOperations locationClient;

        ///GENMHASH:704C7023D5B3E401D9747BB082F479BF:B46F5BAEB07AD00DFC9E48403D627ACE
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

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:0EB96B74B82C153C18B62BE83EB415B1
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

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:6FB4EA69673E1D8A74E1418EB52BB9FE
        internal PagedList<IBatchAccount> List()
        {
            var firstPage = InnerCollection.List();
            var pagedList = new PagedList<BatchAccountInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:F27988875BD81EE531DA23D26C675612
        internal PagedList<IBatchAccount> ListByGroup(string resourceGroupName)
        {
            var firstPage = InnerCollection.ListByResourceGroup(resourceGroupName);
            var pagedList = new PagedList<BatchAccountInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListByResourceGroupNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        ///GENMHASH:353632428E49DD5C2FB134FBBB79CA4F:7213377B7C84B2355F61715C95204A42
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

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        internal BatchAccountImpl Define(string name)
        {
            return WrapModel(name);
        }

        internal Task<PagedList<IBatchAccount>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        public override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        public override async Task<IBatchAccount> GetByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var batchAccount = await InnerCollection.GetAsync(resourceGroupName, name, cancellationToken);
            return WrapModel(batchAccount);
        }

        ///GENMHASH:F8EF648D033A93895EA3A4E4EB60B9B2:F0DC62FB7F617AF3C57F4F01580CC827
        internal int GetBatchAccountQuotaByLocation(Region region)
        {
            return locationClient.GetQuotas(region.Name).AccountQuota.GetValueOrDefault();
        }
    }
}
