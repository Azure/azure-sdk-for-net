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
            await InsertInternalAsync(true, entity, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Inserts a Table Entity into the Table.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The inserted Table entity.</returns>
        public virtual Response<IReadOnlyDictionary<string, object>> Insert(IDictionary<string, object> entity, CancellationToken cancellationToken = default) =>
            InsertInternalAsync(false, entity, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Updates the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey  that identifies the table entity.</param>
        /// <param name="entity">The entity to update.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual async Task<Response> UpdateAsync(string partitionKey, string rowKey, IDictionary<string, object> entity, CancellationToken cancellationToken = default) =>
            await UpdateInternalAsync(true, partitionKey, rowKey, entity, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Updates the specified table entity.
        /// </summary>
        /// <param name="partitionKey">The partitionKey that identifies the table entity.</param>
        /// <param name="rowKey">The rowKey  that identifies the table entity.</param>
        /// <param name="entity">The entity to update.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="Response"/> indicating the result of the operation.</returns>
        public virtual Response Update(string partitionKey, string rowKey, IDictionary<string, object> entity, CancellationToken cancellationToken = default) =>
            UpdateInternalAsync(false, partitionKey, rowKey, entity, cancellationToken).EnsureCompleted();

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
            //TODO: support continuation tokens

            return PageableHelpers.CreateAsyncEnumerable(async tableName =>
            {
                var response = await _tableOperations.RestClient.QueryEntitiesAsync(_table,
                    queryOptions: new QueryOptions() { Format = _format, Top = top, Filter = filter, Select = @select },
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextPartitionKey, response.GetRawResponse());
            }, (_, __) => throw new NotImplementedException());
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
            //TODO: support continuation tokens

            return PageableHelpers.CreateEnumerable(tableName =>
            {
                var response = _tableOperations.RestClient.QueryEntities(_table,
                    queryOptions: new QueryOptions() { Format = _format, Top = top, Filter = filter, Select = @select },
                    cancellationToken: cancellationToken);
                return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextPartitionKey, response.GetRawResponse());
            }, (_, __) => throw new NotImplementedException());
        }

        internal async Task<Response<IReadOnlyDictionary<string, object>>> InsertInternalAsync(bool async, IDictionary<string, object> entity, CancellationToken cancellationToken)
        {
            Response<IReadOnlyDictionary<string, object>> response;

            if (async)
            {
                response = await _tableOperations.InsertEntityAsync(
                    _table,
                    tableEntityProperties: entity,
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            {
                response = _tableOperations.InsertEntity(
                    _table,
                    tableEntityProperties: entity,
                    queryOptions: new QueryOptions() { Format = _format },
                    cancellationToken: cancellationToken);
            }

            return response;
        }

        internal async Task<Response> UpdateInternalAsync(bool async, string partitionKey, string rowKey, IDictionary<string, object> entity, CancellationToken cancellationToken = default)
        {
            if (async)
            {
                return await _tableOperations.UpdateEntityAsync(_table,
                                                                partitionKey,
                                                                rowKey,
                                                                tableEntityProperties: entity,
                                                                queryOptions: new QueryOptions() { Format = _format },
                                                                cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            else
            {
                return _tableOperations.UpdateEntity(_table,
                                                     partitionKey,
                                                     rowKey,
                                                     tableEntityProperties: entity,
                                                     queryOptions: new QueryOptions() { Format = _format },
                                                     cancellationToken: cancellationToken);
            }
        }
    }
}
