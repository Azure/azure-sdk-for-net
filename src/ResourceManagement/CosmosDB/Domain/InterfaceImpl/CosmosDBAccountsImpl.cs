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

    public partial class CosmosDBAccountsImpl 
    {
        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        CosmosDBAccount.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<CosmosDBAccount.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as CosmosDBAccount.Definition.IBlank;
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        async Task<IPagedCollection<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>.ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListByResourceGroupAsync(resourceGroupName, loadAllPages, cancellationToken) as IPagedCollection<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>;
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>.ListByResourceGroup(string resourceGroupName)
        {
            return this.ListByResourceGroup(resourceGroupName) as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<ICosmosDBAccount>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<ICosmosDBAccount>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>.List()
        {
            return this.List() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>;
        }

        /// <summary>
        /// Lists the access keys for the specified Azure CosmosDB database account.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <return>A list of keys.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountListKeysResultInner Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccounts.ListKeys(string groupName, string accountName)
        {
            return this.ListKeys(groupName, accountName) as Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountListKeysResultInner;
        }

        /// <summary>
        /// Lists the connection strings for the specified Azure CosmosDB database account.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <return>A list of connection strings.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccounts.ListConnectionStrings(string groupName, string accountName)
        {
            return this.ListConnectionStrings(groupName, accountName) as Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner;
        }

        /// <summary>
        /// Changes the failover priority for the Azure CosmosDB database account. A failover priority of 0 indicates
        /// a write region. The maximum value for a failover priority = (total number of regions - 1).
        /// Failover priority values must be unique for each of the regions in which the database account exists.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="failoverPolicies">The list of failover policies.</param>
        /// <return>The ServiceResponse object if successful.</return>
        async Task Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccounts.FailoverPriorityChangeAsync(string groupName, string accountName, IList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> failoverPolicies, CancellationToken cancellationToken)
        {
 
            await this.FailoverPriorityChangeAsync(groupName, accountName, failoverPolicies, cancellationToken);
        }

        /// <summary>
        /// Regenerates an access key for the specified Azure CosmosDB database account.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="keyKind">The key kind.</param>
        void Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccounts.RegenerateKey(string groupName, string accountName, string keyKind)
        {
 
            this.RegenerateKey(groupName, accountName, keyKind);
        }

        /// <summary>
        /// Changes the failover priority for the Azure CosmosDB database account. A failover priority of 0 indicates
        /// a write region. The maximum value for a failover priority = (total number of regions - 1).
        /// Failover priority values must be unique for each of the regions in which the database account exists.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="failoverPolicies">The list of failover policies.</param>
        void Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccounts.FailoverPriorityChange(string groupName, string accountName, IList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> failoverPolicies)
        {
 
            this.FailoverPriorityChange(groupName, accountName, failoverPolicies);
        }

        /// <summary>
        /// Regenerates an access key for the specified Azure CosmosDB database account.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="keyKind">The key kind.</param>
        /// <return>The ServiceResponse object if successful.</return>
        async Task Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccounts.RegenerateKeyAsync(string groupName, string accountName, string keyKind, CancellationToken cancellationToken)
        {
 
            await this.RegenerateKeyAsync(groupName, accountName, keyKind, cancellationToken);
        }

        /// <summary>
        /// Lists the access keys for the specified Azure CosmosDB database account.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <return>A list of keys.</return>
        async Task<Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountListKeysResultInner> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccounts.ListKeysAsync(string groupName, string accountName, CancellationToken cancellationToken)
        {
            return await this.ListKeysAsync(groupName, accountName, cancellationToken) as Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountListKeysResultInner;
        }

        /// <summary>
        /// Lists the connection strings for the specified Azure CosmosDB database account.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <return>A list of connection strings.</return>
        async Task<Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner> Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccounts.ListConnectionStringsAsync(string groupName, string accountName, CancellationToken cancellationToken)
        {
            return await this.ListConnectionStringsAsync(groupName, accountName, cancellationToken) as Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner;
        }
    }
}