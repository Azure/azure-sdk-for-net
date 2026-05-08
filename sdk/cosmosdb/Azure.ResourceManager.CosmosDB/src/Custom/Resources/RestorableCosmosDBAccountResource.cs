// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
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
        /// Wrapper for back-compat; delegates to <see cref="GetAllRestorableSqlResourceData(AzureLocation?, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<RestorableSqlResourceData> GetRestorableSqlResources(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => GetAllRestorableSqlResourceData(restoreLocation, restoreTimestampInUtc, cancellationToken);

        /// <summary>
        /// Returns a list of database and container combo that exist on the account at the given timestamp and location.
        /// Wrapper for back-compat; delegates to <see cref="GetAllRestorableSqlResourceDataAsync(AzureLocation?, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<RestorableSqlResourceData> GetRestorableSqlResourcesAsync(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => GetAllRestorableSqlResourceDataAsync(restoreLocation, restoreTimestampInUtc, cancellationToken);

        /// <summary>
        /// Returns a list of database and collection combo that exist on the account at the given timestamp and location.
        /// Wrapper for back-compat; delegates to <see cref="GetAllRestorableMongoDBResourceData(AzureLocation?, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<RestorableMongoDBResourceData> GetRestorableMongoDBResources(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => GetAllRestorableMongoDBResourceData(restoreLocation, restoreTimestampInUtc, cancellationToken);

        /// <summary>
        /// Returns a list of database and collection combo that exist on the account at the given timestamp and location.
        /// Wrapper for back-compat; delegates to <see cref="GetAllRestorableMongoDBResourceDataAsync(AzureLocation?, string, CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<RestorableMongoDBResourceData> GetRestorableMongoDBResourcesAsync(AzureLocation? restoreLocation = default, string restoreTimestampInUtc = null, CancellationToken cancellationToken = default)
            => GetAllRestorableMongoDBResourceDataAsync(restoreLocation, restoreTimestampInUtc, cancellationToken);

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

        /// <summary>
        /// Back-compat 2-arg overload of GetRestorableMongoDBCollections delegating to the canonical 4-arg method.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<RestorableMongoDBCollection> GetRestorableMongoDBCollections(string restorableMongodbDatabaseRid, CancellationToken cancellationToken)
            => GetRestorableMongoDBCollections(restorableMongodbDatabaseRid, null, null, cancellationToken);

        /// <summary>
        /// Back-compat 2-arg overload of GetRestorableMongoDBCollectionsAsync delegating to the canonical 4-arg method.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<RestorableMongoDBCollection> GetRestorableMongoDBCollectionsAsync(string restorableMongodbDatabaseRid, CancellationToken cancellationToken)
            => GetRestorableMongoDBCollectionsAsync(restorableMongodbDatabaseRid, null, null, cancellationToken);
    }
}
