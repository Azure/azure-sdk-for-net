// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure cosmos db.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface ICosmosDBAccount  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBManager,Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<CosmosDBAccount.Update.IUpdate>
    {
        /// <summary>
        /// Gets an array that contains the writable georeplication locations enabled for the CosmosDB account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> WritableReplications { get; }

        /// <summary>
        /// Gets the default consistency level for the CosmosDB database account.
        /// </summary>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.DefaultConsistencyLevel DefaultConsistencyLevel { get; }

        /// <return>The connection strings for the specified Azure CosmosDB database account.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner ListConnectionStrings();

        /// <return>The access keys for the specified Azure CosmosDB database account.</return>
        Task<Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountListKeysResultInner> ListKeysAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets specifies the set of IP addresses or IP address ranges in CIDR form.
        /// </summary>
        string IPRangeFilter { get; }

        /// <return>The access keys for the specified Azure CosmosDB database account.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountListKeysResultInner ListKeys();

        /// <summary>
        /// Gets the consistency policy for the CosmosDB database account.
        /// </summary>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.ConsistencyPolicy ConsistencyPolicy { get; }

        /// <summary>
        /// Gets indicates the type of database account.
        /// </summary>
        string Kind { get; }

        /// <summary>
        /// Gets the connection endpoint for the CosmosDB database account.
        /// </summary>
        string DocumentEndpoint { get; }

        /// <summary>
        /// Gets an array that contains the readable georeplication locations enabled for the CosmosDB account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.CosmosDB.Fluent.Models.Location> ReadableReplications { get; }

        /// <summary>
        /// Gets the offer type for the CosmosDB database account.
        /// </summary>
        Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountOfferType DatabaseAccountOfferType { get; }

        /// <param name="keyKind">The key kind.</param>
        /// <return>The ServiceResponse object if successful.</return>
        Task RegenerateKeyAsync(string keyKind, CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The connection strings for the specified Azure CosmosDB database account.</return>
        Task<Microsoft.Azure.Management.CosmosDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <param name="keyKind">The key kind.</param>
        void RegenerateKey(string keyKind);
    }
}