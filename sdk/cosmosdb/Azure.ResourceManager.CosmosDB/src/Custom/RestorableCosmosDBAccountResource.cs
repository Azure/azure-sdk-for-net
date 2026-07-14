// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.CosmosDB.Models;

namespace Azure.ResourceManager.CosmosDB
{
    // Back-compat surface for RestorableCosmosDBAccountResource:
    //   * GetRestorableSqlDatabases / -Async         -> now emitted by the generator (renamed via @@clientName).
    //   * GetRestorableGremlinResources / -Async     -> now emitted by the generator (renamed via @@clientName).
    //   * GetRestorableTableResources / -Async       -> now emitted by the generator (renamed via @@clientName).
    // Only the [Obsolete] stubs for the legacy `DatabaseRestoreResourceInfo`-shaped methods
    // (GetRestorableSqlResources / GetRestorableMongoDBResources) remain, plus a 2-argument
    // overload of GetRestorableMongoDBCollections to preserve the previously shipped API.
    public partial class RestorableCosmosDBAccountResource
    {
        /// <summary>
        /// Returns a list of database and collection combo that exist on the account at the given timestamp and location.
        /// Legacy API removed in MPG migration; throws on use. The replacement is
        /// <see cref="GetAllRestorableMongoDBResourceData(AzureLocation?, string, CancellationToken)"/>.
        /// </summary>
        [Obsolete("This function is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DatabaseRestoreResourceInfo> GetRestorableMongoDBResources(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This function is obsolete. Use GetAllRestorableMongoDBResourceData instead.");

        /// <summary>
        /// Returns a list of database and collection combo that exist on the account at the given timestamp and location.
        /// Legacy API removed in MPG migration; throws on use. The replacement is
        /// <see cref="GetAllRestorableMongoDBResourceDataAsync(AzureLocation?, string, CancellationToken)"/>.
        /// </summary>
        [Obsolete("This function is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DatabaseRestoreResourceInfo> GetRestorableMongoDBResourcesAsync(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This function is obsolete. Use GetAllRestorableMongoDBResourceDataAsync instead.");

        /// <summary>
        /// Returns a list of database and container combo that exist on the account at the given timestamp and location.
        /// Legacy API removed in MPG migration; throws on use. The replacement is
        /// <see cref="GetAllRestorableSqlResourceDataAsync(AzureLocation?, string, CancellationToken)"/>.
        /// </summary>
        [Obsolete("This function is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DatabaseRestoreResourceInfo> GetRestorableSqlResourcesAsync(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This function is obsolete. Use GetAllRestorableSqlResourceDataAsync instead.");

        /// <summary>
        /// Returns a list of database and container combo that exist on the account at the given timestamp and location.
        /// Legacy API removed in MPG migration; throws on use. The replacement is
        /// <see cref="GetAllRestorableSqlResourceData(AzureLocation?, string, CancellationToken)"/>.
        /// </summary>
        [Obsolete("This function is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DatabaseRestoreResourceInfo> GetRestorableSqlResources(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This function is obsolete. Use GetAllRestorableSqlResourceData instead.");

        /// <summary>
        /// Lists the restorable Azure Cosmos DB MongoDB collections for a given database under a database account.
        /// Back-compat overload that delegates to <see cref="GetRestorableMongoDBCollectionsAsync(string, string, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<RestorableMongoDBCollection> GetRestorableMongoDBCollectionsAsync(string restorableMongoDBDatabaseRid, CancellationToken cancellationToken)
            => GetRestorableMongoDBCollectionsAsync(restorableMongoDBDatabaseRid, null, null, cancellationToken);

        /// <summary>
        /// Lists the restorable Azure Cosmos DB MongoDB collections for a given database under a database account.
        /// Back-compat overload that delegates to <see cref="GetRestorableMongoDBCollections(string, string, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<RestorableMongoDBCollection> GetRestorableMongoDBCollections(string restorableMongoDBDatabaseRid, CancellationToken cancellationToken)
            => GetRestorableMongoDBCollections(restorableMongoDBDatabaseRid, null, null, cancellationToken);
    }
}
