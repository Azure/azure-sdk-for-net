// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.DocumentDB.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.DocumentDB.Fluent.DatabaseAccount.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to document db management API.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IDatabaseAccounts  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<DatabaseAccount.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.DocumentDB.Fluent.IDocumentDBManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccountsOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount>
    {
        /// <summary>
        /// Changes the failover priority for the Azure DocumentDB database account. A failover priority of 0 indicates
        /// a write region. The maximum value for a failover priority = (total number of regions - 1).
        /// Failover priority values must be unique for each of the regions in which the database account exists.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="failoverPolicies">The list of failover policies.</param>
        /// <return>The ServiceResponse object if successful.</return>
        Task FailoverPriorityChangeAsync(string groupName, string accountName, IList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.Location> failoverPolicies, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Regenerates an access key for the specified Azure DocumentDB database account.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="keyKind">The key kind.</param>
        /// <return>The ServiceResponse object if successful.</return>
        Task RegenerateKeyAsync(string groupName, string accountName, string keyKind, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists the connection strings for the specified Azure DocumentDB database account.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <return>A list of connection strings.</return>
        Task<Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner> ListConnectionStringsAsync(string groupName, string accountName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists the connection strings for the specified Azure DocumentDB database account.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <return>A list of connection strings.</return>
        Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner ListConnectionStrings(string groupName, string accountName);

        /// <summary>
        /// Lists the access keys for the specified Azure DocumentDB database account.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <return>A list of keys.</return>
        Task<Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListKeysResultInner> ListKeysAsync(string groupName, string accountName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists the access keys for the specified Azure DocumentDB database account.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <return>A list of keys.</return>
        Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListKeysResultInner ListKeys(string groupName, string accountName);

        /// <summary>
        /// Regenerates an access key for the specified Azure DocumentDB database account.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="keyKind">The key kind.</param>
        void RegenerateKey(string groupName, string accountName, string keyKind);

        /// <summary>
        /// Changes the failover priority for the Azure DocumentDB database account. A failover priority of 0 indicates
        /// a write region. The maximum value for a failover priority = (total number of regions - 1).
        /// Failover priority values must be unique for each of the regions in which the database account exists.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="accountName">The account name.</param>
        /// <param name="failoverPolicies">The list of failover policies.</param>
        void FailoverPriorityChange(string groupName, string accountName, IList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.Location> failoverPolicies);
    }
}