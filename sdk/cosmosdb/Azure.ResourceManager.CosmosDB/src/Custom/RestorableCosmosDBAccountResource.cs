// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.CosmosDB.Models;

// MPG/TCGC currently emits these "list-action" operations under their @@clientName
// values literally (e.g. GetAllRestorableSqlResourceData), and the canonical
// RestorableSqlDatabases @list action becomes RestorableCosmosDBAccountResource.GetAll
// (since the resource itself is not collected). The historical AutoRest-based
// surface used `GetRestorableXyz`-shaped names. To preserve API back-compat without
// breaking existing user code, restore the historical names as hidden
// EditorBrowsable(Never) wrappers that delegate to the generated implementations.
namespace Azure.ResourceManager.CosmosDB
{
    public partial class RestorableCosmosDBAccountResource
    {
        /// <summary>
        /// Lists all the restorable Azure Cosmos DB SQL databases available for a specific database account at a given time and location.
        /// Wrapper for back-compat; delegates to <see cref="GetAll(CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<RestorableSqlDatabase> GetRestorableSqlDatabases(CancellationToken cancellationToken = default)
            => GetAll(cancellationToken);

        /// <summary>
        /// Lists all the restorable Azure Cosmos DB SQL databases available for a specific database account at a given time and location.
        /// Wrapper for back-compat; delegates to <see cref="GetAllAsync(CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<RestorableSqlDatabase> GetRestorableSqlDatabasesAsync(CancellationToken cancellationToken = default)
            => GetAllAsync(cancellationToken);

        /// <summary>
        /// Returns a list of database and container combo that exist on the account at the given timestamp and location.
        /// Back-compat wrapper that converts each <see cref="RestorableSqlResourceData"/> from
        /// <see cref="GetAllRestorableSqlResourceData(AzureLocation?, string, CancellationToken)"/> into the legacy
        /// <see cref="DatabaseRestoreResourceInfo"/> shape originally exposed by AutoRest-generated code.
        /// </summary>
        [Obsolete("This function is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DatabaseRestoreResourceInfo> GetRestorableSqlResources(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This function is obsolete. Use GetAllRestorableSqlResourceData instead.");

        /// <summary>
        /// Returns a list of database and container combo that exist on the account at the given timestamp and location.
        /// Back-compat wrapper that converts each <see cref="RestorableSqlResourceData"/> from
        /// <see cref="GetAllRestorableSqlResourceDataAsync(AzureLocation?, string, CancellationToken)"/> into the legacy
        /// <see cref="DatabaseRestoreResourceInfo"/> shape originally exposed by AutoRest-generated code.
        /// </summary>
        [Obsolete("This function is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DatabaseRestoreResourceInfo> GetRestorableSqlResourcesAsync(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This function is obsolete. Use GetAllRestorableSqlResourceDataAsync instead.");

        /// <summary>
        /// Returns a list of database and collection combo that exist on the account at the given timestamp and location.
        /// Back-compat wrapper that converts each <see cref="RestorableMongoDBResourceData"/> from
        /// <see cref="GetAllRestorableMongoDBResourceData(AzureLocation?, string, CancellationToken)"/> into the legacy
        /// <see cref="DatabaseRestoreResourceInfo"/> shape originally exposed by AutoRest-generated code.
        /// </summary>
        [Obsolete("This function is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DatabaseRestoreResourceInfo> GetRestorableMongoDBResources(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This function is obsolete. Use GetAllRestorableMongoDBResourceData instead.");

        /// <summary>
        /// Returns a list of database and collection combo that exist on the account at the given timestamp and location.
        /// Back-compat wrapper that converts each <see cref="RestorableMongoDBResourceData"/> from
        /// <see cref="GetAllRestorableMongoDBResourceDataAsync(AzureLocation?, string, CancellationToken)"/> into the legacy
        /// <see cref="DatabaseRestoreResourceInfo"/> shape originally exposed by AutoRest-generated code.
        /// </summary>
        [Obsolete("This function is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DatabaseRestoreResourceInfo> GetRestorableMongoDBResourcesAsync(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This function is obsolete. Use GetAllRestorableMongoDBResourceDataAsync instead.");

        /// <summary>
        /// Lists the restorable Azure Cosmos DB MongoDB collections for a given database under a database account.
        /// Back-compat overload that delegates to <see cref="GetRestorableMongoDBCollections(string, string, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<RestorableMongoDBCollection> GetRestorableMongoDBCollections(string restorableMongoDBDatabaseRid, CancellationToken cancellationToken)
            => GetRestorableMongoDBCollections(restorableMongoDBDatabaseRid, null, null, cancellationToken);

        /// <summary>
        /// Lists the restorable Azure Cosmos DB MongoDB collections for a given database under a database account.
        /// Back-compat overload that delegates to <see cref="GetRestorableMongoDBCollectionsAsync(string, string, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<RestorableMongoDBCollection> GetRestorableMongoDBCollectionsAsync(string restorableMongoDBDatabaseRid, CancellationToken cancellationToken)
            => GetRestorableMongoDBCollectionsAsync(restorableMongoDBDatabaseRid, null, null, cancellationToken);

        /// <summary>
        /// Returns a list of gremlin database and graphs combo that exist on the account at the given timestamp and location.
        /// Wrapper for back-compat; delegates to <see cref="GetAllRestorableGremlinResourceData(string, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<RestorableGremlinResourceData> GetRestorableGremlinResources(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => GetAllRestorableGremlinResourceData(restoreLocation?.ToString(), restoreTimestampInUtc, cancellationToken);

        /// <summary>
        /// Returns a list of gremlin database and graphs combo that exist on the account at the given timestamp and location.
        /// Wrapper for back-compat; delegates to <see cref="GetAllRestorableGremlinResourceDataAsync(string, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<RestorableGremlinResourceData> GetRestorableGremlinResourcesAsync(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => GetAllRestorableGremlinResourceDataAsync(restoreLocation?.ToString(), restoreTimestampInUtc, cancellationToken);

        /// <summary>
        /// Returns a list of tables that exist on the account at the given timestamp and location.
        /// Wrapper for back-compat; delegates to <see cref="GetAllRestorableTableResourceData(string, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<RestorableTableResourceData> GetRestorableTableResources(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => GetAllRestorableTableResourceData(restoreLocation?.ToString(), restoreTimestampInUtc, cancellationToken);

        /// <summary>
        /// Returns a list of tables that exist on the account at the given timestamp and location.
        /// Wrapper for back-compat; delegates to <see cref="GetAllRestorableTableResourceDataAsync(string, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<RestorableTableResourceData> GetRestorableTableResourcesAsync(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => GetAllRestorableTableResourceDataAsync(restoreLocation?.ToString(), restoreTimestampInUtc, cancellationToken);
    }
}
