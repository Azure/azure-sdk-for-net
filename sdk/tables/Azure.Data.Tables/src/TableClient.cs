// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        /// Inserts a Table Entity into the Table.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The inserted Table entity.</returns>
        public virtual async Task<Response<IReadOnlyDictionary<string, object>>> InsertAsync(IDictionary<string, object> entity, CancellationToken cancellationToken = default) =>
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
        public virtual Response<IReadOnlyDictionary<string, object>> Insert(IDictionary<string, object> entity, CancellationToken cancellationToken = default) =>
            _tableOperations.InsertEntity(_table,
                                          tableEntityProperties: entity,
                                          queryOptions: new QueryOptions() { Format = _format },
                                          cancellationToken: cancellationToken);

        /// <summary>
        /// Updates the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey  that identifies the table entity.</param>
        /// <param name="entity">The entity to update.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> UpdateAsync(string partitionKey, string rowKey, IDictionary<string, object> entity, CancellationToken cancellationToken = default) =>
            await _tableOperations.UpdateEntityAsync(_table,
                                                     partitionKey,
                                                     rowKey,
                                                     tableEntityProperties: entity,
                                                     queryOptions: new QueryOptions() { Format = _format },
                                                     cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey  that identifies the table entity.</param>
        /// <param name="entity">The entity to update.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response Update(string partitionKey, string rowKey, IDictionary<string, object> entity, CancellationToken cancellationToken = default) =>
            _tableOperations.UpdateEntity(_table,
                                          partitionKey,
                                          rowKey,
                                          tableEntityProperties: entity,
                                          queryOptions: new QueryOptions() { Format = _format },
                                          cancellationToken: cancellationToken);

        /// <summary>
        /// Queries entities in the table.
        /// </summary>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="filter">Returns only tables or entities that satisfy the specified filter.</param>
        /// <param name="top">Returns only the top n tables or entities from the set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
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
