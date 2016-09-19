/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.KeyVault
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.KeyVault.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Graph.RBAC.Models;
    using Microsoft.Azure.Management.V2.Resource;
    using Management.KeyVault;
    using Graph.RBAC;
    using System;
    using System.Threading.Tasks;
    using System.Threading;

    /// <summary>
    /// The implementation of Vaults and its parent interfaces.
    /// </summary>
    public partial class VaultsImpl  :
        GroupableResources<IVault, VaultImpl, VaultInner, IVaultsOperations, IKeyVaultManager>,
        IVaults
    {
        private IGraphRbacManager graphRbacManager;
        private string tenantId;
        internal VaultsImpl (IVaultsOperations client, IKeyVaultManager keyVaultManager, IGraphRbacManager graphRbacManager, string tenantId)
            : base(client, keyVaultManager)
        {
            this.graphRbacManager = graphRbacManager;
            this.tenantId = tenantId;
        }

        public PagedList<IVault> List ()
        {
            var pagedList = new PagedList<VaultInner>(InnerCollection.List());
            return WrapList(pagedList);
        }

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

        public override async Task<IVault> GetByGroupAsync(string groupName, string name)
        {
            var inner = await InnerCollection.GetAsync(groupName, name);
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

        public Task DeleteAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(groupName, name);
        }

        public VaultImpl Define (string name)
        {
            return WrapModel(name)
                .WithSku(SkuName.Standard)
                .WithEmptyAccessPolicy();
        }

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
                MyManager,
                graphRbacManager);
        }

        protected override IVault WrapModel (VaultInner vaultInner)
        {
            return new VaultImpl(
                vaultInner.Name,
                vaultInner,
                InnerCollection,
                MyManager,
                graphRbacManager);
        }
    }
}