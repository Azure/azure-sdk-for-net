// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Management.KeyVault;
    using Graph.RBAC.Fluent;
    using System;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// The implementation of Vaults and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmtleXZhdWx0LmltcGxlbWVudGF0aW9uLlZhdWx0c0ltcGw=
    internal partial class VaultsImpl  :
        GroupableResources<IVault, VaultImpl, VaultInner, IVaultsOperations, IKeyVaultManager>,
        IVaults
    {
        private IGraphRbacManager graphRbacManager;
        private string tenantId;
        ///GENMHASH:CDB7D4D816159A58F5240A4C88E5241C:4E00EDDBAADBA44B155253E3B63448A4
        internal VaultsImpl (IVaultsOperations client, IKeyVaultManager keyVaultManager, IGraphRbacManager graphRbacManager, string tenantId)
            : base(client, keyVaultManager)
        {
            this.graphRbacManager = graphRbacManager;
            this.tenantId = tenantId;
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:6FB4EA69673E1D8A74E1418EB52BB9FE
        public PagedList<IVault> List ()
        {
            var pagedList = new PagedList<VaultInner>(InnerCollection.List());
            return WrapList(pagedList);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:BDFF4CB61E8A8D975417EA5FC914921A
        public PagedList<IVault> ListByGroup (string groupName)
        {
            var pagedList = new PagedList<VaultInner>(InnerCollection.ListByResourceGroup(groupName));
            return WrapList(pagedList);
        }

        public async Task<PagedList<IVault>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await InnerCollection.ListByResourceGroupAsync(resourceGroupName);
            var pagedList = new PagedList<VaultInner>(inner);
            return WrapList(pagedList);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        public override async Task<IVault> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await InnerCollection.GetAsync(groupName, name, cancellationToken);
            return WrapModel(inner);
        }

        public void Delete (string id)
        {
            Delete(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete (string groupName, string name)
        {
            InnerCollection.Delete(groupName, name);
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        public override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(groupName, name);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:913702868132D01F4C836BBF3499B8CE
        public VaultImpl Define (string name)
        {
            return WrapModel(name)
                .WithSku(SkuName.Standard)
                .WithEmptyAccessPolicy();
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:CF5D7C4F8C9C8500DA16344A95E02A83
        protected override VaultImpl WrapModel (string name)
        {
            VaultInner inner = new VaultInner()
            {
                Properties = new VaultProperties()
                {
                    TenantId = Guid.Parse(tenantId)
                }
            };
            return new VaultImpl(
                name,
                inner,
                InnerCollection,
                Manager,
                graphRbacManager);
        }

        ///GENMHASH:CA260E89048F01F05DD7D13D870D6A8F:92A42C7FBDAE00431C015493416F3C0F
        protected override IVault WrapModel (VaultInner vaultInner)
        {
            return new VaultImpl(
                vaultInner.Name,
                vaultInner,
                InnerCollection,
                Manager,
                graphRbacManager);
        }
    }
}
