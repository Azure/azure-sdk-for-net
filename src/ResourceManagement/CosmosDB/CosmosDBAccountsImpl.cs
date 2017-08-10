// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Linq;
    using Rest.Azure;
    using System;

    /// <summary>
    /// Implementation for Registries.
    /// </summary>
    public partial class CosmosDBAccountsImpl :
        TopLevelModifiableResources<ICosmosDBAccount,
            CosmosDBAccountImpl,
            Models.DatabaseAccountInner,
            IDatabaseAccountsOperations, 
            ICosmosDBManager>,
        ICosmosDBAccounts
    {
        internal CosmosDBAccountsImpl(ICosmosDBManager manager) :
            base(manager.Inner.DatabaseAccounts, manager)
        {
        }

        public CosmosDBAccountImpl Define(string name)
        {
            return WrapModel(name);
        }

        protected override ICosmosDBAccount WrapModel(Models.DatabaseAccountInner inner)
        {
            return new CosmosDBAccountImpl(inner.Name, inner, Manager);
        }

        /// <summary>
        /// Fluent model helpers.
        /// </summary>

        protected override CosmosDBAccountImpl WrapModel(string name)
        {
            return new CosmosDBAccountImpl(name, new Models.DatabaseAccountInner(), Manager);
        }

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        public override IEnumerable<ICosmosDBAccount> List()
        {
            return Manager.ResourceManager.ResourceGroups.List()
                                          .SelectMany(rg => ListByResourceGroup(rg.Name));
        }

        public override async Task<IPagedCollection<ICosmosDBAccount>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var task = await Manager.ResourceManager.ResourceGroups.ListAsync(true, cancellationToken);
            return await PagedCollection<ICosmosDBAccount, Models.DatabaseAccountInner>.LoadPage(async (cancellation) =>
            {
                var resourceGroups = await Manager.ResourceManager.ResourceGroups.ListAsync(true, cancellation);
                var containerService = await Task.WhenAll(resourceGroups.Select(async (rg) => await ListInnerByGroupAsync(rg.Name, cancellation)));
                return containerService.SelectMany(x => x);
            }, WrapModel, cancellationToken);
        }


        protected override Task<IPage<Models.DatabaseAccountInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<IPage<Models.DatabaseAccountInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task<IPage<Models.DatabaseAccountInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected async override Task<IPage<Models.DatabaseAccountInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Task.FromResult<IPage<Models.DatabaseAccountInner>>(null);
        }

        protected async override Task<Models.DatabaseAccountInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        public async Task FailoverPriorityChangeAsync(string groupName, string accountName, IList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> failoverLocations, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Models.FailoverPolicyInner> policyInners = new List<Models.FailoverPolicyInner>();
            for (int i = 0; i < failoverLocations.Count(); i++) {
            Models.Location location  = failoverLocations[i];
            Models.FailoverPolicyInner policyInner = new Models.FailoverPolicyInner();
            policyInner.LocationName = location.LocationName;
            policyInner.FailoverPriority = i;
            policyInners.Add(policyInner);
            }
            
            await this.Manager.Inner.DatabaseAccounts.FailoverPriorityChangeAsync(groupName, accountName, policyInners);
        }

        public Models.DatabaseAccountListConnectionStringsResultInner ListConnectionStrings(string groupName, string accountName)
        {
            return Extensions.Synchronize(() => this.ListConnectionStringsAsync(groupName, accountName));
        }

        public Models.DatabaseAccountListKeysResultInner ListKeys(string groupName, string accountName)
        {
            return Extensions.Synchronize(() => this.ListKeysAsync(groupName, accountName));
        }

        public async Task<Models.DatabaseAccountListKeysResultInner> ListKeysAsync(string groupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Inner.ListKeysAsync(groupName, accountName, cancellationToken);
        }

        public void FailoverPriorityChange(string groupName, string accountName, IList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> failoverLocations)
        {
            Extensions.Synchronize(() => this.FailoverPriorityChangeAsync(groupName, accountName, failoverLocations));
        }

        public async Task RegenerateKeyAsync(string groupName, string accountName, string keyKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.DatabaseAccounts.RegenerateKeyAsync(groupName, accountName, keyKind);
        }

        public async Task<Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner> ListConnectionStringsAsync(string groupName, string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.DatabaseAccounts.ListConnectionStringsAsync(groupName, accountName);
        }

        public void RegenerateKey(string groupName, string accountName, string keyKind)
        {
            Extensions.Synchronize(() => this.RegenerateKeyAsync(groupName, accountName, keyKind));
        }
    }
}