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
    public class TableServiceClient
    {
        private readonly TableInternalClient _tableOperations;
        private readonly OdataMetadataFormat _format = OdataMetadataFormat.ApplicationJsonOdataFullmetadata;

        public TableServiceClient(Uri endpoint)
                : this(endpoint, options: null) { }
        public TableServiceClient(Uri endpoint, TableClientOptions options = null)
            : this(endpoint, default(TableSharedKeyPipelinePolicy), options) { }

        public TableServiceClient(Uri endpoint, TableSharedKeyCredential credential)
            : this(endpoint, new TableSharedKeyPipelinePolicy(credential), null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
        }

        public TableServiceClient(Uri endpoint, TableSharedKeyCredential credential, TableClientOptions options = null)
            : this(endpoint, new TableSharedKeyPipelinePolicy(credential), options)
        {
            Argument.AssertNotNull(credential, nameof(credential));
        }

        internal TableServiceClient(Uri endpoint, TableSharedKeyPipelinePolicy policy, TableClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            if (endpoint.Scheme != "https")
            {
                throw new ArgumentException("Cannot use TokenCredential without HTTPS.");
            }
            options ??= new TableClientOptions();
            var endpointString = endpoint.ToString();
            HttpPipeline pipeline;

            if (policy == default)
            {
                pipeline = HttpPipelineBuilder.Build(options);
            }
            else
            {
                pipeline = HttpPipelineBuilder.Build(options, policy);
            }

            var diagnostics = new ClientDiagnostics(options);
            _tableOperations = new TableInternalClient(diagnostics, pipeline, endpointString);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/>
        /// class for mocking.
        /// </summary>
        protected TableServiceClient()
        { }

        public virtual TableClient GetTableClient(string tableName)
        {
            return new TableClient(tableName, _tableOperations);
        }

        /// <summary>
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="filter">Returns only tables or entities that satisfy the specified filter.</param>
        /// <param name="top">Returns only the top n tables or entities from the set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual AsyncPageable<TableItem> GetTablesAsync(string select = null, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                var response = await _tableOperations.RestClient.QueryAsync(
                    null,
                    new QueryOptions() { Filter = filter, Select = select, Top = top, Format = _format },
                    cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
            }, async (nextLink, _) =>
            {
                var response = await _tableOperations.RestClient.QueryAsync(
                       null,
                       new QueryOptions() { Filter = filter, Select = select, Top = top, Format = _format, NextTableName = nextLink },
                       cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
            });
        }

        /// <summary>
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="filter">Returns only tables or entities that satisfy the specified filter.</param>
        /// <param name="top">Returns only the top n tables or entities from the set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual Pageable<TableItem> GetTables(string select = null, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateEnumerable(_ =>
            {
                var response = _tableOperations.RestClient.Query(
                    null,
                    new QueryOptions() { Filter = filter, Select = select, Top = top, Format = _format },
                    cancellationToken);
                return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
            }, (nextLink, _) =>
            {
                var response = _tableOperations.RestClient.Query(
                       null,
                       new QueryOptions() { Filter = filter, Select = select, Top = top, Format = _format, NextTableName = nextLink },
                       cancellationToken);
                return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
            });
        }

        /// <summary>
        /// Creates a table in the storage account.
        /// </summary>
        /// <param name="tableName">The table name to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        [ForwardsClientCalls]
        public virtual Response<TableItem> CreateTable(string tableName, CancellationToken cancellationToken = default)
        {
            var response = _tableOperations.Create(new TableProperties(tableName), null, new QueryOptions { Format = _format }, cancellationToken: cancellationToken);
            return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
        }

        /// <summary>
        /// Creates a table in the storage account.
        /// </summary>
        /// <param name="tableName">The table name to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        [ForwardsClientCalls]
        public virtual async Task<Response<TableItem>> CreateTableAsync(string tableName, CancellationToken cancellationToken = default)
        {
            var response = await _tableOperations.CreateAsync(new TableProperties(tableName), null, new QueryOptions { Format = _format }, cancellationToken: cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value as TableItem, response.GetRawResponse());
        }

        /// <summary>
        /// Deletes a table in the storage account.
        /// </summary>
        /// <param name="tableName">The table name to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        [ForwardsClientCalls]
        public virtual Response DeleteTable(string tableName, CancellationToken cancellationToken = default) =>
            _tableOperations.Delete(tableName, null, cancellationToken: cancellationToken);

        /// <summary>
        /// Deletes a table in the storage account.
        /// </summary>
        /// <param name="tableName">The table name to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteTableAsync(string tableName, CancellationToken cancellationToken = default) =>
            await _tableOperations.DeleteAsync(tableName, null, cancellationToken: cancellationToken).ConfigureAwait(false);
    }
}
