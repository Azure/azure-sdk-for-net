// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        public TableServiceClient(Uri endpoint, TablesSharedKeyCredential credential, TableClientOptions options = null)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new TableClientOptions();

            var endpointString = endpoint.ToString();
            var pipeline = HttpPipelineBuilder.Build(options, new TablesSharedKeyPipelinePolicy(credential));
            var diagnostics = new ClientDiagnostics(options);
            _tableOperations = new TableInternalClient(diagnostics, pipeline, endpointString);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TableServiceClient"/>
        /// class for mocking.
        /// </summary>
        protected TableServiceClient()
        { }

        public TableClient GetTableClient(string tableName)
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
        public virtual AsyncPageable<TableResponseProperties> GetTablesAsync(string select = null, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            //TODO: support continuation tokens

            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                var response = await _tableOperations.RestClient.QueryAsync(
                    null,
                    new QueryOptions() { Filter = filter, Select = select, Top = top, Format = _format },
                    cancellationToken).ConfigureAwait(false);
                return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
            }, (_, __) => throw new NotImplementedException());
        }

        /// <summary>
        /// Gets a list of tables from the storage account.
        /// </summary>
        /// <param name="select">Returns the desired properties of an entity from the set. </param>
        /// <param name="filter">Returns only tables or entities that satisfy the specified filter.</param>
        /// <param name="top">Returns only the top n tables or entities from the set.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        public virtual Pageable<TableResponseProperties> GetTables(string select = null, string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            //TODO: support continuation tokens

            return PageableHelpers.CreateEnumerable(_ =>
            {
                var response = _tableOperations.RestClient.Query(
                    null,
                    new QueryOptions() { Filter = filter, Select = select, Top = top, Format = _format },
                    cancellationToken);
                return Page.FromValues(response.Value.Value, response.Headers.XMsContinuationNextTableName, response.GetRawResponse());
            }, (_, __) => throw new NotImplementedException());
        }

        /// <summary>
        /// Creates a table in the storage account.
        /// </summary>
        /// <param name="tableName">The table name to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        [ForwardsClientCalls]
        public virtual TableResponse CreateTable(string tableName, CancellationToken cancellationToken = default) =>
            _tableOperations.RestClient.Create(new TableProperties(tableName), null, new QueryOptions { Format = _format }, cancellationToken: cancellationToken);

        /// <summary>
        /// Creates a table in the storage account.
        /// </summary>
        /// <param name="tableName">The table name to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        [ForwardsClientCalls]
        public virtual async Task<TableResponse> CreateTableAsync(string tableName, CancellationToken cancellationToken = default) =>
            await _tableOperations.RestClient.CreateAsync(new TableProperties(tableName), null, new QueryOptions { Format = _format }, cancellationToken: cancellationToken).ConfigureAwait(false);

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
