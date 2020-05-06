// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Data.Tables.Models;

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
        private readonly TableInternalClient _tableOperations;

        internal TableClient(string table, TableInternalClient tableOperations)
        {
            _tableOperations = tableOperations;
            _table = table;
            _format = OdataMetadataFormat.ApplicationJsonOdataFullmetadata;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableClient"/>
        /// class for mocking.
        /// </summary>
        protected TableClient()
        { }

        /// <summary>
        /// Creates the table in the storage account.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        [ForwardsClientCalls]
        public virtual Response<TableItem> Create(CancellationToken cancellationToken = default)
        {
            var response = _tableOperations.RestClient.Create(new TableProperties(_table), null, new QueryOptions { Format = _format }, cancellationToken: cancellationToken);
            return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
        }

        /// <summary>
        /// Creates the table in the storage account.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<TableItem>> CreateAsync(CancellationToken cancellationToken = default)
        {
            var response = await _tableOperations.CreateAsync(new TableProperties(_table), null, new QueryOptions { Format = _format }, cancellationToken: cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
        }

        /// <summary>
        /// Inserts a Table Entity into the Table.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The inserted Table entity.</returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<ReadOnlyDictionary<string, object>>> InsertAsync(IDictionary<string, object> entity, CancellationToken cancellationToken = default) =>
            await _tableOperations.InsertEntityAsync(_table,
                                                     tableEntityProperties: entity,
                                                     queryOptions: new QueryOptions() { Format = _format },
                                                     cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Inserts a Table Entity into the Table.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The inserted Table entity.</returns>
        [ForwardsClientCalls]
        public virtual Response<ReadOnlyDictionary<string, object>> Insert(IDictionary<string, object> entity, CancellationToken cancellationToken = default) =>
            _tableOperations.InsertEntity(_table,
                                          tableEntityProperties: entity,
                                          queryOptions: new QueryOptions() { Format = _format },
                                          cancellationToken: cancellationToken);

        /// <summary>
        /// Replaces the specified table entity, if it exists. Inserts the entity if it does not exist.
        /// </summary>
        /// <param name="entity">The entity to upsert.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        [ForwardsClientCalls]
        public virtual async Task<Response> UpsertAsync(IDictionary<string, object> entity, CancellationToken cancellationToken = default)
        {
            //TODO: Create Resource strings
            if (!entity.TryGetValue(TableConstants.PropertyNames.PartitionKey, out var partitionKey))
            {
                throw new ArgumentException("The entity must contain a PartitionKey value", nameof(entity));
            }

            if (!entity.TryGetValue(TableConstants.PropertyNames.RowKey, out var rowKey))
            {
                throw new ArgumentException("The entity must contain a RowKey value", nameof(entity));
            }

            return await _tableOperations.UpdateEntityAsync(_table,
                                                     partitionKey as string,
                                                     rowKey as string,
                                                     tableEntityProperties: entity,
                                                     queryOptions: new QueryOptions() { Format = _format },
                                                     cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists. Inserts the entity if it does not exist.
        /// </summary>
        /// <param name="entity">The entity to upsert.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        [ForwardsClientCalls]
        public virtual Response Upsert(IDictionary<string, object> entity, CancellationToken cancellationToken = default)
        {
            //TODO: Create Resource strings
            if (!entity.TryGetValue(TableConstants.PropertyNames.PartitionKey, out var partitionKey))
            {
                throw new ArgumentException("The entity must contain a PartitionKey value", nameof(entity));
            }

            if (!entity.TryGetValue(TableConstants.PropertyNames.RowKey, out var rowKey))
            {
                throw new ArgumentException("The entity must contain a RowKey value", nameof(entity));
            }

            return _tableOperations.UpdateEntity(_table,
                                          partitionKey as string,
                                          rowKey as string,
                                          tableEntityProperties: entity,
                                          queryOptions: new QueryOptions() { Format = _format },
                                          cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists. Inserts the entity if it does not exist.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="eTag">The ETag value to be used for optimistic concurrency.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        [ForwardsClientCalls]
        public virtual async Task<Response> UpdateAsync(IDictionary<string, object> entity, string eTag, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(eTag, nameof(eTag));

            //TODO: Create Resource strings
            if (!entity.TryGetValue(TableConstants.PropertyNames.PartitionKey, out var partitionKey))
            {
                throw new ArgumentException("The entity must contain a PartitionKey value", nameof(entity));
            }

            if (!entity.TryGetValue(TableConstants.PropertyNames.RowKey, out var rowKey))
            {
                throw new ArgumentException("The entity must contain a RowKey value", nameof(entity));
            }

            return await _tableOperations.UpdateEntityAsync(_table,
                                                     partitionKey as string,
                                                     rowKey as string,
                                                     tableEntityProperties: entity,
                                                     queryOptions: new QueryOptions() { Format = _format, IfMatch = eTag },
                                                     cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Replaces the specified table entity, if it exists. Inserts the entity if it does not exist.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="eTag">The ETag value to be used for optimistic concurrency.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        [ForwardsClientCalls]
        public virtual Response Update(IDictionary<string, object> entity, string eTag, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(eTag, nameof(eTag));

            //TODO: Create Resource strings
            if (!entity.TryGetValue(TableConstants.PropertyNames.PartitionKey, out var partitionKey))
            {
                throw new ArgumentException("The entity must contain a PartitionKey value", nameof(entity));
            }

            if (!entity.TryGetValue(TableConstants.PropertyNames.RowKey, out var rowKey))
            {
                throw new ArgumentException("The entity must contain a RowKey value", nameof(entity));
            }

            return _tableOperations.UpdateEntity(_table,
                                          partitionKey as string,
                                          rowKey as string,
                                          tableEntityProperties: entity,
                                          queryOptions: new QueryOptions() { Format = _format, IfMatch = eTag },
                                          cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Merges the specified table entity by updating only the properties present in the supplied entity, if it exists. Inserts the entity if it does not exist.
        /// </summary>
        /// <param name="entity">The entity to merge.</param>
        /// <param name="eTag">The ETag value to be used for optimistic concurrency.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        [ForwardsClientCalls]
        public virtual async Task<Response> MergeAsync(IDictionary<string, object> entity, string eTag = null, CancellationToken cancellationToken = default)
        {
            //TODO: Create Resource strings
            if (!entity.TryGetValue(TableConstants.PropertyNames.PartitionKey, out var partitionKey))
            {
                throw new ArgumentException("The entity must contain a PartitionKey value", nameof(entity));
            }

            if (!entity.TryGetValue(TableConstants.PropertyNames.RowKey, out var rowKey))
            {
                throw new ArgumentException("The entity must contain a RowKey value", nameof(entity));
            }

            return (await _tableOperations.RestClient.MergeEntityAsync(_table,
                                                     partitionKey as string,
                                                     rowKey as string,
                                                     tableEntityProperties: entity,
                                                     queryOptions: new QueryOptions() { Format = _format, IfMatch = eTag },
                                                     cancellationToken: cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }

        /// <summary>
        /// Merges the specified table entity by updating only the properties present in the supplied entity, if it exists. Inserts the entity if it does not exist.
        /// </summary>
        /// <param name="entity">The entity to merge.</param>
        /// <param name="eTag">The ETag value to be used for optimistic concurrency.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        [ForwardsClientCalls]
        public virtual Response Merge(IDictionary<string, object> entity, string eTag = null, CancellationToken cancellationToken = default)
        {
            //TODO: Create Resource strings
            if (!entity.TryGetValue(TableConstants.PropertyNames.PartitionKey, out var partitionKey))
            {
                throw new ArgumentException("The entity must contain a PartitionKey value", nameof(entity));
            }

            if (!entity.TryGetValue(TableConstants.PropertyNames.RowKey, out var rowKey))
            {
                throw new ArgumentException("The entity must contain a RowKey value", nameof(entity));
            }

            return _tableOperations.RestClient.MergeEntity(_table,
                                          partitionKey as string,
                                          rowKey as string,
                                          tableEntityProperties: entity,
                                          queryOptions: new QueryOptions() { Format = _format, IfMatch = eTag },
                                          cancellationToken: cancellationToken).GetRawResponse();
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="filter">Returns only tables or entities that satisfy the specified filter.</param>
        /// <param name="top">Returns only the top n tables or entities from the set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<IDictionary<string, object>> QueryAsync(string select = null, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                var response = await _tableOperations.RestClient.QueryEntitiesAsync(
                    _table,
                    queryOptions: new QueryOptions() { Format = _format, Top = top, Filter = filter, Select = @select },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return Page.FromValues(response.Value.Value,
                                       CreateContinuationTokenFromHeaders(response.Headers),
                                       response.GetRawResponse());
            }, async (continuationToken, _) =>
            {
                var (NextPartitionKey, NextRowKey) = ParseContinuationToken(continuationToken);

                var response = await _tableOperations.RestClient.QueryEntitiesAsync(
                    _table,
                    queryOptions: new QueryOptions() { Format = _format, Top = top, Filter = filter, Select = @select, NextPartitionKey = NextPartitionKey, NextRowKey = NextRowKey },
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return Page.FromValues(response.Value.Value,
                                       CreateContinuationTokenFromHeaders(response.Headers),
                                       response.GetRawResponse());
            });
        }

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="filter">Returns only tables or entities that satisfy the specified filter.</param>
        /// <param name="top">Returns only the top n tables or entities from the set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>

        [ForwardsClientCalls]
        public virtual Pageable<IDictionary<string, object>> Query(string select = null, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateEnumerable(_ =>
            {
                var response = _tableOperations.RestClient.QueryEntities(_table,
                    queryOptions: new QueryOptions() { Format = _format, Top = top, Filter = filter, Select = @select },
                    cancellationToken: cancellationToken);
                return Page.FromValues(
                    response.Value.Value,
                    CreateContinuationTokenFromHeaders(response.Headers),
                    response.GetRawResponse());
            }, (continuationToken, _) =>
            {
                var (NextPartitionKey, NextRowKey) = ParseContinuationToken(continuationToken);

                var response = _tableOperations.RestClient.QueryEntities(
                    _table,
                    queryOptions: new QueryOptions() { Format = _format, Top = top, Filter = filter, Select = @select, NextPartitionKey = NextPartitionKey, NextRowKey = NextRowKey },
                    cancellationToken: cancellationToken);

                return Page.FromValues(response.Value.Value,
                                       CreateContinuationTokenFromHeaders(response.Headers),
                                       response.GetRawResponse());
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
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteAsync(string partitionKey, string rowKey, string eTag = "*", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(partitionKey, nameof(partitionKey));
            Argument.AssertNotNull(rowKey, nameof(rowKey));

            return await _tableOperations.DeleteEntityAsync(_table,
                                                     partitionKey,
                                                     rowKey,
                                                     queryOptions: new QueryOptions() { Format = _format, IfMatch = eTag },
                                                     cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey that identifies the table entity.</param>
        /// <param name="eTag">The ETag value to be used for optimistic concurrency. The default is to delete unconditionally.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        [ForwardsClientCalls]
        public virtual Response Delete(string partitionKey, string rowKey, string eTag = "*", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(partitionKey, nameof(partitionKey));
            Argument.AssertNotNull(rowKey, nameof(rowKey));

            return _tableOperations.DeleteEntity(_table,
                                          partitionKey,
                                          rowKey,
                                          queryOptions: new QueryOptions() { Format = _format, IfMatch = eTag },
                                          cancellationToken: cancellationToken);
        }

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used with Shared Access Signatures. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a>. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<ReadOnlyCollection<SignedIdentifier>>> GetAccessPolicyAsync(int? timeout = null, string requestId = null, CancellationToken cancellationToken = default) =>
            await _tableOperations.GetAccessPolicyAsync(_table, timeout, requestId, cancellationToken).ConfigureAwait(false);

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used with Shared Access Signatures. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a>. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<ReadOnlyCollection<SignedIdentifier>> GetAccessPolicy(int? timeout = null, string requestId = null, CancellationToken cancellationToken = default) =>
            _tableOperations.GetAccessPolicy(_table, timeout, requestId, cancellationToken);

        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="tableAcl"> the access policies for the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a>. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response> SetAccessPolicyAsync(IEnumerable<SignedIdentifier> tableAcl = null, int? timeout = null, string requestId = null, CancellationToken cancellationToken = default) =>
            await _tableOperations.SetAccessPolicyAsync(_table, timeout, requestId, tableAcl, cancellationToken).ConfigureAwait(false);

        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="tableAcl"> the access policies for the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations">Setting Timeouts for Queue Service Operations.</a>. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response SetAccessPolicy(IEnumerable<SignedIdentifier> tableAcl, int? timeout = null, string requestId = null, CancellationToken cancellationToken = default) =>
            _tableOperations.SetAccessPolicy(_table, timeout, requestId, tableAcl, cancellationToken);

        private static string CreateContinuationTokenFromHeaders(TableInternalQueryEntitiesHeaders headers)
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
