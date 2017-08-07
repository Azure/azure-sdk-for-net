// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using Storage.Fluent;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for BatchAccounts and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmJhdGNoLmltcGxlbWVudGF0aW9uLkJhdGNoQWNjb3VudHNJbXBs
    internal partial class BatchAccountsImpl :
        TopLevelModifiableResources<
            IBatchAccount,
            BatchAccountImpl,
            BatchAccountInner,
            IBatchAccountOperations,
            IBatchManager>,
        IBatchAccounts
    {
        private IStorageManager storageManager;

        ///GENMHASH:704C7023D5B3E401D9747BB082F479BF:B46F5BAEB07AD00DFC9E48403D627ACE
        internal BatchAccountsImpl(BatchManager manager, IStorageManager storageManager)
            : base(manager.Inner.BatchAccount, manager)
        {
            this.storageManager = storageManager;
        }

        public void Delete(string id)
        {
            Delete(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete(string groupName, string name)
        {
            Extensions.Synchronize(() => Inner.DeleteAsync(groupName, name));
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:0EB96B74B82C153C18B62BE83EB415B1
        protected override BatchAccountImpl WrapModel(string name)
        {
            var inner = new BatchAccountInner();

            return new BatchAccountImpl(
                name,
                inner,
                Manager,
                storageManager);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:6FB4EA69673E1D8A74E1418EB52BB9FE
        protected async override Task<IPage<BatchAccountInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(cancellationToken);
        }

        protected async override Task<IPage<BatchAccountInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:F27988875BD81EE531DA23D26C675612
        protected async override Task<IPage<BatchAccountInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<BatchAccountInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListByResourceGroupNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:353632428E49DD5C2FB134FBBB79CA4F:7213377B7C84B2355F61715C95204A42
        protected override IBatchAccount WrapModel(BatchAccountInner inner)
        {
            return new BatchAccountImpl(
                inner.Name,
                inner,
                Manager,
                storageManager);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        internal BatchAccountImpl Define(string name)
        {
            return WrapModel(name);
        }

        internal Task<IEnumerable<IBatchAccount>> ListByResourceGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        protected async override Task<BatchAccountInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:F8EF648D033A93895EA3A4E4EB60B9B2:F0DC62FB7F617AF3C57F4F01580CC827
        internal int GetBatchAccountQuotaByLocation(Region region)
        {
            return Extensions.Synchronize(() => Manager.Inner.Location.GetQuotasAsync(region.Name))
                        .AccountQuota.GetValueOrDefault();
        }
    }
}
