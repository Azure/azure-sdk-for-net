// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Data.Tables.Models;
using Azure.Data.Tables.Queryable;
using Azure.Data.Tables.Sas;

namespace Azure.Data.Tables
{
    /// <summary>
    /// The <see cref="TableClient"/> allows you to interact with Azure Storage
    /// Tables.
    /// </summary>
    public class TableClient
    {
        private readonly string _table;
        private readonly OdataMetadataFormat _format;
        private readonly ClientDiagnostics _diagnostics;
        private readonly TableRestClient _tableOperations;
        private readonly string _version;
        private readonly bool _isPremiumEndpoint;

        internal TableClient(string table, TableRestClient tableOperations, string version, ClientDiagnostics diagnostics, bool isPremiumEndpoint)
        {
            _tableOperations = tableOperations;
            _version = version;
            _table = table;
            _format = OdataMetadataFormat.ApplicationJsonOdataFullmetadata;
            _diagnostics = diagnostics;
            _isPremiumEndpoint = isPremiumEndpoint;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClient"/>
        /// class for mocking.
        /// </summary>
        protected TableClient()
        { }


        /// <summary>
        /// Gets a <see cref="TableSasBuilder"/> instance scoped to the current table.
        /// </summary>
        /// <param name="permissions"><see cref="TableSasPermissions"/> containing the allowed permissions.</param>
        /// <param name="expiresOn">The time at which the shared access signature becomes invalid.</param>
        /// <returns>An instance of <see cref="TableSasBuilder"/>.</returns>
        public virtual TableSasBuilder GetSasBuilder(TableSasPermissions permissions, DateTimeOffset expiresOn)
        {
            return new TableSasBuilder(_table, permissions, expiresOn) { Version = _version };
        }

        /// <summary>
        /// Gets a <see cref="TableSasBuilder"/> instance scoped to the current table.
        /// </summary>
        /// <param name="rawPermissions">The permissions associated with the shared access signature. This string should contain one or more of the following permission characters in this order: "racwdl".</param>
        /// <param name="expiresOn">The time at which the shared access signature becomes invalid.</param>
        /// <returns>An instance of <see cref="TableSasBuilder"/>.</returns>
        public virtual TableSasBuilder GetSasBuilder(string rawPermissions, DateTimeOffset expiresOn)
        {
            return new TableSasBuilder(_table, rawPermissions, expiresOn) { Version = _version };
        }

        /// <summary>
        /// Creates the table in the storage account.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="TableItem"/> containing properties of the table</returns>
        public virtual Response<TableItem> Create(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Create)}");
            scope.Start();
            try
            {
                var response = _tableOperations.Create(new TableProperties()
                {
                    TableName = _table
                }, null, queryOptions: new QueryOptions() { Format = _format }, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates the table in the storage account.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="TableItem"/> containing properties of the table</returns>
        public virtual async Task<Response<TableItem>> CreateAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Create)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.CreateAsync(new TableProperties() { TableName = _table }, null, queryOptions: new QueryOptions() { Format = _format }, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a Table Entity into the Table.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The created Table entity.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if entity already exists.</exception>
        public virtual async Task<Response<DynamicTableEntity>> CreateEntityAsync(DynamicTableEntity entity, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(entity, nameof(entity));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(CreateEntity)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.InsertEntityAsync(_table,
                    tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var dict = new Dictionary<string, object>((IDictionary<string, object>)response.Value);
                dict.CastAndRemoveAnnotations();

                return Response.FromValue(new DynamicTableEntity(dict), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a Table Entity into the Table.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The created Table entity.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if entity already exists.</exception>
        public virtual Response<DynamicTableEntity> CreateEntity(DynamicTableEntity entity, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(entity, nameof(entity));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(CreateEntity)}");
            scope.Start();
            try
            {
                var response = _tableOperations.InsertEntity(_table,
                    tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken);

                var dict = new Dictionary<string, object>((IDictionary<string, object>)response.Value);
                dict.CastAndRemoveAnnotations();

                return Response.FromValue(new DynamicTableEntity(dict), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a Table Entity into the Table.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The created Table entity.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if entity already exists.</exception>
        public virtual async Task<Response<ReadOnlyDictionary<string, object>>> CreateEntityAsync(IDictionary<string, object> entity, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(entity, nameof(entity));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(CreateEntity)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.InsertEntityAsync(_table,
                    tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var dict = new Dictionary<string, object>((IDictionary<string, object>)response.Value);
                dict.CastAndRemoveAnnotations();

                return Response.FromValue(new ReadOnlyDictionary<string, object>(dict), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a Table Entity into the Table.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The created Table entity.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if entity already exists.</exception>
        public virtual Response<ReadOnlyDictionary<string, object>> CreateEntity(IDictionary<string, object> entity, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(entity, nameof(entity));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(CreateEntity)}");
            scope.Start();
            try
            {
                var response = _tableOperations.InsertEntity(_table,
                    tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken);

                var dict = new Dictionary<string, object>((IDictionary<string, object>)response.Value);
                dict.CastAndRemoveAnnotations();

                return Response.FromValue(new ReadOnlyDictionary<string, object>(dict), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a Table Entity into the Table.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The created Table entity.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if entity already exists.</exception>
        public virtual async Task<Response<T>> CreateEntityAsync<T>(T entity, CancellationToken cancellationToken = default) where T : TableEntity, new()
        {
            Argument.AssertNotNull(entity, nameof(entity));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(CreateEntity)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.InsertEntityAsync(_table,
                    tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var result = ((Dictionary<string, object>)response.Value).ToTableEntity<T>();
                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a Table Entity into the Table.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The created Table entity.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if entity already exists.</exception>
        public virtual Response<T> CreateEntity<T>(T entity, CancellationToken cancellationToken = default) where T : TableEntity, new()
        {
            Argument.AssertNotNull(entity, nameof(entity));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(CreateEntity)}");
            scope.Start();
            try
            {
                var response = _tableOperations.InsertEntity(_table,
                    tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken);

                var result = ((Dictionary<string, object>)response.Value).ToTableEntity<T>();
                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if the entity doesn't exist.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="partitionKey"/> or <paramref name="rowKey"/> is null.</exception>
        public virtual Response<T> GetEntity<T>(string partitionKey, string rowKey, CancellationToken cancellationToken = default) where T : TableEntity, new()
        {
            Argument.AssertNotNull("message", nameof(partitionKey));
            Argument.AssertNotNull("message", nameof(rowKey));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetEntity)}");
            scope.Start();
            try
            {
                var response = _tableOperations.QueryEntitiesWithPartitionAndRowKey(
                    _table,
                    partitionKey,
                    rowKey,
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken);

                var result = ((Dictionary<string, object>)response.Value).ToTableEntity<T>();
                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if the entity doesn't exist.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="partitionKey"/> or <paramref name="rowKey"/> is null.</exception>
        public virtual async Task<Response<T>> GetEntityAsync<T>(string partitionKey, string rowKey, CancellationToken cancellationToken = default) where T : TableEntity, new()
        {
            Argument.AssertNotNull("message", nameof(partitionKey));
            Argument.AssertNotNull("message", nameof(rowKey));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetEntity)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.QueryEntitiesWithPartitionAndRowKeyAsync(
                    _table,
                    partitionKey,
                    rowKey,
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var result = ((Dictionary<string, object>)response.Value).ToTableEntity<T>();
                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if the entity doesn't exist.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="partitionKey"/> or <paramref name="rowKey"/> is null.</exception>
        public virtual Response<IDictionary<string, object>> GetEntity(string partitionKey, string rowKey, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull("message", nameof(partitionKey));
            Argument.AssertNotNull("message", nameof(rowKey));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetEntity)}");
            scope.Start();
            try
            {
                var response = _tableOperations.QueryEntitiesWithPartitionAndRowKey(
                    _table,
                    partitionKey,
                    rowKey,
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken);

                IDictionary<string, object> entity = (IDictionary<string, object>)response.Value;
                entity.CastAndRemoveAnnotations();
                return Response.FromValue(entity, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        /// <exception cref="RequestFailedException">Exception thrown if the entity doesn't exist.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="partitionKey"/> or <paramref name="rowKey"/> is null.</exception>
        public virtual async Task<Response<IDictionary<string, object>>> GetEntityAsync(string partitionKey, string rowKey, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull("message", nameof(partitionKey));
            Argument.AssertNotNull("message", nameof(rowKey));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetEntity)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.QueryEntitiesWithPartitionAndRowKeyAsync(
                    _table,
                    partitionKey,
                    rowKey,
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                IDictionary<string, object> entity = (IDictionary<string, object>)response.Value;
                entity.CastAndRemoveAnnotations();
                return Response.FromValue(entity, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists. Creates the entity if it does not exist.
        /// </summary>
        /// <param name="entity">The entity to upsert.</param>
        /// <param name="mode">An enum that determines which upsert operation to perform.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> UpsertEntityAsync(IDictionary<string, object> entity, UpdateMode mode = UpdateMode.Merge, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(entity, nameof(entity));

            if (!entity.TryGetValue(TableConstants.PropertyNames.PartitionKey, out var partitionKey))
            {
                throw new ArgumentException(TableConstants.ExceptionMessages.MissingPartitionKey, nameof(entity));
            }

            if (!entity.TryGetValue(TableConstants.PropertyNames.RowKey, out var rowKey))
            {
                throw new ArgumentException(TableConstants.ExceptionMessages.MissingRowKey, nameof(entity));
            }

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpsertEntity)}");
            scope.Start();
            try
            {
                if (mode == UpdateMode.Replace)
                {
                    return await _tableOperations.UpdateEntityAsync(_table,
                        partitionKey as string,
                        rowKey as string,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else if (mode == UpdateMode.Merge)
                {
                    return await _tableOperations.MergeEntityAsync(_table,
                        partitionKey as string,
                        rowKey as string,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}");
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists. Creates the entity if it does not exist.
        /// </summary>
        /// <param name="entity">The entity to upsert.</param>
        /// <param name="mode">An enum that determines which upsert operation to perform.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response UpsertEntity(IDictionary<string, object> entity, UpdateMode mode = UpdateMode.Merge, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(entity, nameof(entity));

            if (!entity.TryGetValue(TableConstants.PropertyNames.PartitionKey, out var partitionKey))
            {
                throw new ArgumentException(TableConstants.ExceptionMessages.MissingPartitionKey, nameof(entity));
            }

            if (!entity.TryGetValue(TableConstants.PropertyNames.RowKey, out var rowKey))
            {
                throw new ArgumentException(TableConstants.ExceptionMessages.MissingRowKey, nameof(entity));
            }

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpsertEntity)}");
            scope.Start();
            try
            {
                if (mode == UpdateMode.Replace)
                {
                    return _tableOperations.UpdateEntity(_table,
                        partitionKey as string,
                        rowKey as string,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken);
                }
                else if (mode == UpdateMode.Merge)
                {
                    return _tableOperations.MergeEntity(_table,
                        partitionKey as string,
                        rowKey as string,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken);
                }
                else
                {
                    throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}");
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists. Creates the entity if it does not exist.
        /// </summary>
        /// <param name="entity">The entity to upsert.</param>
        /// <param name="mode">An enum that determines which upsert operation to perform.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> UpsertEntityAsync<T>(T entity, UpdateMode mode = UpdateMode.Merge, CancellationToken cancellationToken = default) where T : TableEntity, new()
        {
            Argument.AssertNotNull(entity?.PartitionKey, nameof(entity.PartitionKey));
            Argument.AssertNotNull(entity?.RowKey, nameof(entity.RowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpsertEntity)}");
            scope.Start();
            try
            {
                if (mode == UpdateMode.Replace)
                {
                    return await _tableOperations.UpdateEntityAsync(_table,
                        entity.PartitionKey,
                        entity.RowKey,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else if (mode == UpdateMode.Merge)
                {
                    return await _tableOperations.MergeEntityAsync(_table,
                        entity.PartitionKey,
                        entity.RowKey,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}");
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists. Creates the entity if it does not exist.
        /// </summary>
        /// <param name="entity">The entity to upsert.</param>
        /// <param name="mode">An enum that determines which upsert operation to perform.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response UpsertEntity<T>(T entity, UpdateMode mode = UpdateMode.Merge, CancellationToken cancellationToken = default) where T : TableEntity, new()
        {
            Argument.AssertNotNull(entity?.PartitionKey, nameof(entity.PartitionKey));
            Argument.AssertNotNull(entity?.RowKey, nameof(entity.RowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpsertEntity)}");
            scope.Start();
            try
            {
                if (mode == UpdateMode.Replace)
                {
                    return _tableOperations.UpdateEntity(_table,
                        entity.PartitionKey,
                        entity.RowKey,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken);
                }
                else if (mode == UpdateMode.Merge)
                {
                    return _tableOperations.MergeEntity(_table,
                        entity.PartitionKey,
                        entity.RowKey,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken);
                }
                else
                {
                    throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}");
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="eTag">The ETag value to be used for optimistic concurrency.</param>
        /// <param name="mode">An enum that determines which upsert operation to perform.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> UpdateEntityAsync(IDictionary<string, object> entity, string eTag, UpdateMode mode = UpdateMode.Merge, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(entity, nameof(entity));
            Argument.AssertNotNullOrWhiteSpace(eTag, nameof(eTag));

            //TODO: Create Resource strings
            if (!entity.TryGetValue(TableConstants.PropertyNames.PartitionKey, out var partitionKey))
            {
                throw new ArgumentException(TableConstants.ExceptionMessages.MissingPartitionKey, nameof(entity));
            }

            if (!entity.TryGetValue(TableConstants.PropertyNames.RowKey, out var rowKey))
            {
                throw new ArgumentException(TableConstants.ExceptionMessages.MissingRowKey, nameof(entity));
            }

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpdateEntity)}");
            scope.Start();
            try
            {
                if (mode == UpdateMode.Replace)
                {
                    return await _tableOperations.UpdateEntityAsync(_table,
                        partitionKey as string,
                        rowKey as string,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        ifMatch: eTag,
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else if (mode == UpdateMode.Merge)
                {
                    return await _tableOperations.MergeEntityAsync(_table,
                        partitionKey as string,
                        rowKey as string,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        ifMatch: eTag,
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}");
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="eTag">The ETag value to be used for optimistic concurrency.</param>
        /// <param name="mode">An enum that determines which upsert operation to perform.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response UpdateEntity(IDictionary<string, object> entity, string eTag, UpdateMode mode = UpdateMode.Merge, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(entity, nameof(entity));
            Argument.AssertNotNullOrWhiteSpace(eTag, nameof(eTag));

            //TODO: Create Resource strings
            if (!entity.TryGetValue(TableConstants.PropertyNames.PartitionKey, out var partitionKey))
            {
                throw new ArgumentException(TableConstants.ExceptionMessages.MissingPartitionKey, nameof(entity));
            }

            if (!entity.TryGetValue(TableConstants.PropertyNames.RowKey, out var rowKey))
            {
                throw new ArgumentException(TableConstants.ExceptionMessages.MissingRowKey, nameof(entity));
            }

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(UpdateEntity)}");
            scope.Start();
            try
            {
                if (mode == UpdateMode.Replace)
                {
                    return _tableOperations.UpdateEntity(_table,
                        partitionKey as string,
                        rowKey as string,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        ifMatch: eTag,
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken);
                }
                else if (mode == UpdateMode.Merge)
                {
                    return _tableOperations.MergeEntity(_table,
                        partitionKey as string,
                        rowKey as string,
                        tableEntityProperties: entity.ToOdataAnnotatedDictionary(),
                        ifMatch: eTag,
                        queryOptions: new QueryOptions() { Format = _format },
                        cancellationToken: cancellationToken);
                }
                else
                {
                    throw new ArgumentException($"Unexpected value for {nameof(mode)}: {mode}");
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="filter">Returns only entities that satisfy the specified filter.</param>
        /// <param name="maxPerPage">The maximum number of entities that will be returned per page.</param>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual AsyncPageable<IDictionary<string, object>> QueryAsync(string filter = null, int? maxPerPage = null, string select = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                var response = await _tableOperations.QueryEntitiesAsync(
                    _table,
                    queryOptions: new QueryOptions() { Format = _format, Top = maxPerPage, Filter = filter, Select = @select },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                response.Value.Value.CastAndRemoveAnnotations();

                return Page.FromValues(response.Value.Value,
                                       CreateContinuationTokenFromHeaders(response.Headers),
                                       response.GetRawResponse());
            }, async (continuationToken, _) =>
            {
                var (NextPartitionKey, NextRowKey) = ParseContinuationToken(continuationToken);

                var response = await _tableOperations.QueryEntitiesAsync(
                    _table,
                    queryOptions: new QueryOptions() { Format = _format, Top = maxPerPage, Filter = filter, Select = @select },
                    nextPartitionKey: NextPartitionKey,
                    nextRowKey: NextRowKey,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                response.Value.Value.CastAndRemoveAnnotations();

                return Page.FromValues(response.Value.Value,
                                       CreateContinuationTokenFromHeaders(response.Headers),
                                       response.GetRawResponse());
            });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="filter">Returns only entities that satisfy the specified filter.</param>
        /// <param name="maxPerPage">The maximum number of entities that will be returned per page.</param>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>

        public virtual Pageable<IDictionary<string, object>> Query(string filter = null, int? maxPerPage = null, string select = null, CancellationToken cancellationToken = default)
        {

            return PageableHelpers.CreateEnumerable(_ =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
                scope.Start();
                try
                {
                    var response = _tableOperations.QueryEntities(_table,
                        queryOptions: new QueryOptions() { Format = _format, Top = maxPerPage, Filter = filter, Select = @select },
                        cancellationToken: cancellationToken);

                    response.Value.Value.CastAndRemoveAnnotations();

                    return Page.FromValues(
                        response.Value.Value,
                        CreateContinuationTokenFromHeaders(response.Headers),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }, (continuationToken, _) =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
                scope.Start();
                try
                {
                    var (NextPartitionKey, NextRowKey) = ParseContinuationToken(continuationToken);

                    var response = _tableOperations.QueryEntities(
                        _table,
                        queryOptions: new QueryOptions() { Format = _format, Top = maxPerPage, Filter = filter, Select = @select },
                        nextPartitionKey: NextPartitionKey,
                        nextRowKey: NextRowKey,
                        cancellationToken: cancellationToken);

                    response.Value.Value.CastAndRemoveAnnotations();

                    return Page.FromValues(response.Value.Value,
                                           CreateContinuationTokenFromHeaders(response.Headers),
                                           response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });

        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="filter">Returns only entities that satisfy the specified filter.</param>
        /// <param name="maxPerPage">The maximum number of entities that will be returned per page.</param>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>

        public virtual AsyncPageable<IDictionary<string, object>> QueryAsync(Expression<Func<IDictionary<string, object>, bool>> filter, int? maxPerPage = null, string select = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return QueryAsync(Bind(filter), maxPerPage, select, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        public virtual Pageable<IDictionary<string, object>> Query(Expression<Func<IDictionary<string, object>, bool>> filter, int? maxPerPage = null, string select = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return Query(Bind(filter), maxPerPage, select, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="filter">Returns only entities that satisfy the specified filter.</param>
        /// <param name="maxPerPage">The maximum number of entities that will be returned per page.</param>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>

        public virtual AsyncPageable<T> QueryAsync<T>(Expression<Func<T, bool>> filter, int? maxPerPage = null, string select = null, CancellationToken cancellationToken = default) where T : TableEntity, new()
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return QueryAsync<T>(Bind(filter), maxPerPage, select, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="filter">Returns only entities that satisfy the specified filter.</param>
        /// <param name="maxPerPage">The maximum number of entities that will be returned per page.</param>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual AsyncPageable<T> QueryAsync<T>(string filter = null, int? maxPerPage = null, string select = null, CancellationToken cancellationToken = default) where T : TableEntity, new()
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                var response = await _tableOperations.QueryEntitiesAsync(
                    _table,
                    queryOptions: new QueryOptions() { Format = _format, Top = maxPerPage, Filter = filter, Select = @select },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return Page.FromValues(response.Value.Value.ToTableEntityList<T>(),
                    CreateContinuationTokenFromHeaders(response.Headers),
                    response.GetRawResponse());
            }, async (continuationToken, _) =>
            {
                var (NextPartitionKey, NextRowKey) = ParseContinuationToken(continuationToken);

                var response = await _tableOperations.QueryEntitiesAsync(
                    _table,
                    queryOptions: new QueryOptions() { Format = _format, Top = maxPerPage, Filter = filter, Select = @select },
                    nextPartitionKey: NextPartitionKey,
                    nextRowKey: NextRowKey,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return Page.FromValues(response.Value.Value.ToTableEntityList<T>(),
                    CreateContinuationTokenFromHeaders(response.Headers),
                    response.GetRawResponse());
            });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="filter">Returns only entities that satisfy the specified filter.</param>
        /// <param name="maxPerPage">The maximum number of entities that will be returned per page.</param>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>

        public virtual Pageable<T> Query<T>(Expression<Func<T, bool>> filter, int? maxPerPage = null, string select = null, CancellationToken cancellationToken = default) where T : TableEntity, new()
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
            scope.Start();
            try
            {
                return Query<T>(Bind(filter), maxPerPage, select, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="filter">Returns only entities that satisfy the specified filter.</param>
        /// <param name="maxPerPage">The maximum number of entities that will be returned per page.</param>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>

        public virtual Pageable<T> Query<T>(string filter = null, int? maxPerPage = null, string select = null, CancellationToken cancellationToken = default) where T : TableEntity, new()
        {

            return PageableHelpers.CreateEnumerable((int? _) =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
                scope.Start();
                try
                {
                    var response = _tableOperations.QueryEntities(_table,
                        queryOptions: new QueryOptions() { Format = _format, Top = maxPerPage, Filter = filter, Select = @select },
                        cancellationToken: cancellationToken);

                    return Page.FromValues(
                        response.Value.Value.ToTableEntityList<T>(),
                        CreateContinuationTokenFromHeaders(response.Headers),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }, (continuationToken, _) =>
            {
                using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Query)}");
                scope.Start();
                try
                {
                    var (NextPartitionKey, NextRowKey) = ParseContinuationToken(continuationToken);

                    var response = _tableOperations.QueryEntities(
                        _table,
                        queryOptions: new QueryOptions() { Format = _format, Top = maxPerPage, Filter = filter, Select = @select },
                        nextPartitionKey: NextPartitionKey,
                        nextRowKey: NextRowKey,
                        cancellationToken: cancellationToken);

                    return Page.FromValues(response.Value.Value.ToTableEntityList<T>(),
                        CreateContinuationTokenFromHeaders(response.Headers),
                        response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary>
        /// Deletes the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="eTag">The ETag value to be used for optimistic concurrency.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> DeleteAsync(string partitionKey, string rowKey, string eTag = "*", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(partitionKey, nameof(partitionKey));
            Argument.AssertNotNull(rowKey, nameof(rowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                return await _tableOperations.DeleteEntityAsync(_table,
                    partitionKey,
                    rowKey,
                    ifMatch: eTag,
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="eTag">The ETag value to be used for optimistic concurrency. The default is to delete unconditionally.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response Delete(string partitionKey, string rowKey, string eTag = "*", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(partitionKey, nameof(partitionKey));
            Argument.AssertNotNull(rowKey, nameof(rowKey));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                return _tableOperations.DeleteEntity(_table,
                    partitionKey,
                    rowKey,
                    ifMatch: eTag,
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used with Shared Access Signatures. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a>. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<SignedIdentifier>>> GetAccessPolicyAsync(int? timeout = null, string requestId = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetAccessPolicy)}");
            scope.Start();
            try
            {
                var response = await _tableOperations.GetAccessPolicyAsync(_table, timeout, requestId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used with Shared Access Signatures. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a>. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<SignedIdentifier>> GetAccessPolicy(int? timeout = null, string requestId = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(GetAccessPolicy)}");
            scope.Start();
            try
            {
                var response = _tableOperations.GetAccessPolicy(_table, timeout, requestId, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="tableAcl"> the access policies for the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a>. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SetAccessPolicyAsync(IEnumerable<SignedIdentifier> tableAcl = null, int? timeout = null, string requestId = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(SetAccessPolicy)}");
            scope.Start();
            try
            {
                return await _tableOperations.SetAccessPolicyAsync(_table, timeout, requestId, tableAcl, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="tableAcl"> the access policies for the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a>. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SetAccessPolicy(IEnumerable<SignedIdentifier> tableAcl, int? timeout = null, string requestId = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TableClient)}.{nameof(SetAccessPolicy)}");
            scope.Start();
            try
            {
                return _tableOperations.SetAccessPolicy(_table, timeout, requestId, tableAcl, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates an Odata filter query string from the provided expression.
        /// </summary>
        /// <typeparam name="T">The type of the entity being queried. Typically this will be derrived from <see cref="TableEntity"/> or <see cref="Dictionary{String, Object}"/>.</typeparam>
        /// <param name="filter">A filter expresssion.</param>
        /// <returns>The string representation of the filter expression.</returns>
        public static string CreateFilter<T>(Expression<Func<T, bool>> filter) => Bind(filter);

        internal static string Bind(Expression expression)
        {
            Argument.AssertNotNull(expression, nameof(expression));

            Dictionary<Expression, Expression> normalizerRewrites = new Dictionary<Expression, Expression>(ReferenceEqualityComparer<Expression>.Instance);

            // Evaluate any local evaluatable expressions ( lambdas etc)
            Expression partialEvaluatedExpression = Evaluator.PartialEval(expression);

            // Normalize expression, replace String Comparisons etc.
            Expression normalizedExpression = ExpressionNormalizer.Normalize(partialEvaluatedExpression, normalizerRewrites);

            // Parse the Bound expression into sub components, i.e. take count, filter, select columns, request options, opcontext, etc.
            ExpressionParser parser = new ExpressionParser();
            parser.Translate(normalizedExpression);

            // Return the FilterString.
            return parser.FilterString == "true" ? null : parser.FilterString;
        }

        private static string CreateContinuationTokenFromHeaders(TableQueryEntitiesHeaders headers)
        {
            if (headers.XMsContinuationNextPartitionKey == null && headers.XMsContinuationNextRowKey == null)
            {
                return null;
            }
            else
            {
                return $"{headers.XMsContinuationNextPartitionKey} {headers.XMsContinuationNextRowKey}";
            }
        }

        private static (string NextPartitionKey, string NextRowKey) ParseContinuationToken(string continuationToken)
        {
            // There were no headers passed and the continuation token contains just the space delimiter
            if (continuationToken?.Length <= 1)
            {
                return (null, null);
            }

            var tokens = continuationToken.Split(' ');
            return (tokens[0], tokens.Length > 1 ? tokens[1] : null);
        }
    }
}
