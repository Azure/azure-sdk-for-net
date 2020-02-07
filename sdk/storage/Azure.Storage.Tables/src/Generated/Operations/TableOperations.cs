// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Tables.Models;

namespace Azure.Storage.Tables
{
    internal partial class TableOperations
    {
        private string url;
        private string Version;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;
        /// <summary> Initializes a new instance of TableOperations. </summary>
        public TableOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url, string Version = "2018-10-10")
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }
            if (Version == null)
            {
                throw new ArgumentNullException(nameof(Version));
            }

            this.url = url;
            this.Version = Version;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }
        internal HttpMessage CreateQueryRequest(string requestId, Enum0? format, int? top, string select, string filter)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/Tables", false);
            if (format != null)
            {
                uri.AppendQuery("$format", format.Value, true);
            }
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            if (select != null)
            {
                uri.AppendQuery("$select", select, true);
            }
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", Version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            return message;
        }
        /// <summary> Queries tables under the given account. </summary>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<TableQueryResponse, QueryHeaders>> QueryAsync(string requestId, Enum0? format, int? top, string select, string filter, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("TableOperations.Query");
            scope.Start();
            try
            {
                using var message = CreateQueryRequest(requestId, format, top, select, filter);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = TableQueryResponse.DeserializeTableQueryResponse(document.RootElement);
                            var headers = new QueryHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Queries tables under the given account. </summary>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<TableQueryResponse, QueryHeaders> Query(string requestId, Enum0? format, int? top, string select, string filter, CancellationToken cancellationToken = default)
        {

            using var scope = clientDiagnostics.CreateScope("TableOperations.Query");
            scope.Start();
            try
            {
                using var message = CreateQueryRequest(requestId, format, top, select, filter);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = TableQueryResponse.DeserializeTableQueryResponse(document.RootElement);
                            var headers = new QueryHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateCreateRequest(string requestId, Enum0? format, TableProperties tableProperties)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/Tables", false);
            if (format != null)
            {
                uri.AppendQuery("$format", format.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", Version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            request.Headers.Add("Content-Type", "application/json;odata=fullmetadata");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(tableProperties);
            request.Content = content;
            return message;
        }
        /// <summary> Creates a new table under the given account. </summary>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="tableProperties"> The Table properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<TableResponse, CreateHeaders>> CreateAsync(string requestId, Enum0? format, TableProperties tableProperties, CancellationToken cancellationToken = default)
        {
            if (tableProperties == null)
            {
                throw new ArgumentNullException(nameof(tableProperties));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.Create");
            scope.Start();
            try
            {
                using var message = CreateCreateRequest(requestId, format, tableProperties);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = TableResponse.DeserializeTableResponse(document.RootElement);
                            var headers = new CreateHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Creates a new table under the given account. </summary>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="tableProperties"> The Table properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<TableResponse, CreateHeaders> Create(string requestId, Enum0? format, TableProperties tableProperties, CancellationToken cancellationToken = default)
        {
            if (tableProperties == null)
            {
                throw new ArgumentNullException(nameof(tableProperties));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.Create");
            scope.Start();
            try
            {
                using var message = CreateCreateRequest(requestId, format, tableProperties);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = TableResponse.DeserializeTableResponse(document.RootElement);
                            var headers = new CreateHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteRequest(string requestId, string table)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/Tables('", false);
            uri.AppendPath(table, true);
            uri.AppendPath("')", false);
            request.Uri = uri;
            request.Headers.Add("x-ms-version", Version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            return message;
        }
        /// <summary> Operation permanently deletes the specified table. </summary>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteHeaders>> DeleteAsync(string requestId, string table, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.Delete");
            scope.Start();
            try
            {
                using var message = CreateDeleteRequest(requestId, table);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 204:
                        var headers = new DeleteHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Operation permanently deletes the specified table. </summary>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteHeaders> Delete(string requestId, string table, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.Delete");
            scope.Start();
            try
            {
                using var message = CreateDeleteRequest(requestId, table);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 204:
                        var headers = new DeleteHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateQueryEntitiesRequest(int? timeout, string requestId, Enum0? format, int? top, string select, string filter, string table)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            uri.AppendPath("()", false);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            if (format != null)
            {
                uri.AppendQuery("$format", format.Value, true);
            }
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            if (select != null)
            {
                uri.AppendQuery("$select", select, true);
            }
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", Version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            return message;
        }
        /// <summary> Queries entities in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<TableEntityQueryResponse, QueryEntitiesHeaders>> QueryEntitiesAsync(int? timeout, string requestId, Enum0? format, int? top, string select, string filter, string table, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.QueryEntities");
            scope.Start();
            try
            {
                using var message = CreateQueryEntitiesRequest(timeout, requestId, format, top, select, filter, table);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = TableEntityQueryResponse.DeserializeTableEntityQueryResponse(document.RootElement);
                            var headers = new QueryEntitiesHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Queries entities in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="top"> Maximum number of records to return. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<TableEntityQueryResponse, QueryEntitiesHeaders> QueryEntities(int? timeout, string requestId, Enum0? format, int? top, string select, string filter, string table, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.QueryEntities");
            scope.Start();
            try
            {
                using var message = CreateQueryEntitiesRequest(timeout, requestId, format, top, select, filter, table);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = TableEntityQueryResponse.DeserializeTableEntityQueryResponse(document.RootElement);
                            var headers = new QueryEntitiesHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateQueryEntitiesWithPartitionAndRowKeyRequest(int? timeout, string requestId, Enum0? format, string select, string filter, string table, string partitionKey, string rowKey)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            uri.AppendPath("(PartitionKey='", false);
            uri.AppendPath(partitionKey, true);
            uri.AppendPath("',RowKey='", false);
            uri.AppendPath(rowKey, true);
            uri.AppendPath("')", false);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            if (format != null)
            {
                uri.AppendQuery("$format", format.Value, true);
            }
            if (select != null)
            {
                uri.AppendQuery("$select", select, true);
            }
            if (filter != null)
            {
                uri.AppendQuery("$filter", filter, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", Version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            return message;
        }
        /// <summary> Queries entities in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<TableEntityQueryResponse, QueryEntitiesWithPartitionAndRowKeyHeaders>> QueryEntitiesWithPartitionAndRowKeyAsync(int? timeout, string requestId, Enum0? format, string select, string filter, string table, string partitionKey, string rowKey, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (partitionKey == null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }
            if (rowKey == null)
            {
                throw new ArgumentNullException(nameof(rowKey));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.QueryEntitiesWithPartitionAndRowKey");
            scope.Start();
            try
            {
                using var message = CreateQueryEntitiesWithPartitionAndRowKeyRequest(timeout, requestId, format, select, filter, table, partitionKey, rowKey);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            var value = TableEntityQueryResponse.DeserializeTableEntityQueryResponse(document.RootElement);
                            var headers = new QueryEntitiesWithPartitionAndRowKeyHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Queries entities in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<TableEntityQueryResponse, QueryEntitiesWithPartitionAndRowKeyHeaders> QueryEntitiesWithPartitionAndRowKey(int? timeout, string requestId, Enum0? format, string select, string filter, string table, string partitionKey, string rowKey, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (partitionKey == null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }
            if (rowKey == null)
            {
                throw new ArgumentNullException(nameof(rowKey));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.QueryEntitiesWithPartitionAndRowKey");
            scope.Start();
            try
            {
                using var message = CreateQueryEntitiesWithPartitionAndRowKeyRequest(timeout, requestId, format, select, filter, table, partitionKey, rowKey);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            var value = TableEntityQueryResponse.DeserializeTableEntityQueryResponse(document.RootElement);
                            var headers = new QueryEntitiesWithPartitionAndRowKeyHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateUpdateEntityRequest(int? timeout, string requestId, Enum0? format, string table, string partitionKey, string rowKey, IDictionary<string, object> tableEntityProperties)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            uri.AppendPath("(PartitionKey='", false);
            uri.AppendPath(partitionKey, true);
            uri.AppendPath("',RowKey='", false);
            uri.AppendPath(rowKey, true);
            uri.AppendPath("')", false);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            if (format != null)
            {
                uri.AppendQuery("$format", format.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", Version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            request.Headers.Add("Content-Type", "application/json;odata=fullmetadata");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartObject();
            foreach (var item in tableEntityProperties)
            {
                content.JsonWriter.WritePropertyName(item.Key);
                content.JsonWriter.WriteObjectValue(item.Value);
            }
            content.JsonWriter.WriteEndObject();
            request.Content = content;
            return message;
        }
        /// <summary> Update entity in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<UpdateEntityHeaders>> UpdateEntityAsync(int? timeout, string requestId, Enum0? format, string table, string partitionKey, string rowKey, IDictionary<string, object> tableEntityProperties, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (partitionKey == null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }
            if (rowKey == null)
            {
                throw new ArgumentNullException(nameof(rowKey));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.UpdateEntity");
            scope.Start();
            try
            {
                using var message = CreateUpdateEntityRequest(timeout, requestId, format, table, partitionKey, rowKey, tableEntityProperties);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new UpdateEntityHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Update entity in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<UpdateEntityHeaders> UpdateEntity(int? timeout, string requestId, Enum0? format, string table, string partitionKey, string rowKey, IDictionary<string, object> tableEntityProperties, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (partitionKey == null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }
            if (rowKey == null)
            {
                throw new ArgumentNullException(nameof(rowKey));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.UpdateEntity");
            scope.Start();
            try
            {
                using var message = CreateUpdateEntityRequest(timeout, requestId, format, table, partitionKey, rowKey, tableEntityProperties);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        var headers = new UpdateEntityHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateDeleteEntityRequest(int? timeout, string requestId, Enum0? format, string table, string partitionKey, string rowKey)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            uri.AppendPath("(PartitionKey='", false);
            uri.AppendPath(partitionKey, true);
            uri.AppendPath("',RowKey='", false);
            uri.AppendPath(rowKey, true);
            uri.AppendPath("')", false);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            if (format != null)
            {
                uri.AppendQuery("$format", format.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", Version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            return message;
        }
        /// <summary> Deletes the specified entity in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<DeleteEntityHeaders>> DeleteEntityAsync(int? timeout, string requestId, Enum0? format, string table, string partitionKey, string rowKey, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (partitionKey == null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }
            if (rowKey == null)
            {
                throw new ArgumentNullException(nameof(rowKey));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.DeleteEntity");
            scope.Start();
            try
            {
                using var message = CreateDeleteEntityRequest(timeout, requestId, format, table, partitionKey, rowKey);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 204:
                        var headers = new DeleteEntityHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Deletes the specified entity in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<DeleteEntityHeaders> DeleteEntity(int? timeout, string requestId, Enum0? format, string table, string partitionKey, string rowKey, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            if (partitionKey == null)
            {
                throw new ArgumentNullException(nameof(partitionKey));
            }
            if (rowKey == null)
            {
                throw new ArgumentNullException(nameof(rowKey));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.DeleteEntity");
            scope.Start();
            try
            {
                using var message = CreateDeleteEntityRequest(timeout, requestId, format, table, partitionKey, rowKey);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 204:
                        var headers = new DeleteEntityHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateInsertEntityRequest(int? timeout, string requestId, Enum0? format, string table, IDictionary<string, object> tableEntityProperties)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            if (format != null)
            {
                uri.AppendQuery("$format", format.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", Version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            request.Headers.Add("Content-Type", "application/json;odata=fullmetadata");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartObject();
            foreach (var item in tableEntityProperties)
            {
                content.JsonWriter.WritePropertyName(item.Key);
                content.JsonWriter.WriteObjectValue(item.Value);
            }
            content.JsonWriter.WriteEndObject();
            request.Content = content;
            return message;
        }
        /// <summary> Insert entity in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<IDictionary<string, object>, InsertEntityHeaders>> InsertEntityAsync(int? timeout, string requestId, Enum0? format, string table, IDictionary<string, object> tableEntityProperties, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.InsertEntity");
            scope.Start();
            try
            {
                using var message = CreateInsertEntityRequest(timeout, requestId, format, table, tableEntityProperties);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        {
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            IDictionary<string, object> value = new Dictionary<string, object>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetObject());
                            }
                            var headers = new InsertEntityHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Insert entity in a table. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="format"> Specifies the media type for the response. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<IDictionary<string, object>, InsertEntityHeaders> InsertEntity(int? timeout, string requestId, Enum0? format, string table, IDictionary<string, object> tableEntityProperties, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.InsertEntity");
            scope.Start();
            try
            {
                using var message = CreateInsertEntityRequest(timeout, requestId, format, table, tableEntityProperties);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        {
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            IDictionary<string, object> value = new Dictionary<string, object>();
                            foreach (var property in document.RootElement.EnumerateObject())
                            {
                                value.Add(property.Name, property.Value.GetObject());
                            }
                            var headers = new InsertEntityHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateGetAccessPolicyRequest(int? timeout, string requestId, string table)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            uri.AppendQuery("comp", "acl", true);
            request.Uri = uri;
            request.Headers.Add("x-ms-version", Version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            return message;
        }
        /// <summary> Retrieves details about any stored access policies specified on the table that may be used wit Shared Access Signatures. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ICollection<SignedIdentifier>, GetAccessPolicyHeaders>> GetAccessPolicyAsync(int? timeout, string requestId, string table, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.GetAccessPolicy");
            scope.Start();
            try
            {
                using var message = CreateGetAccessPolicyRequest(timeout, requestId, table);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ICollection<SignedIdentifier> value = default;
                            var signedIdentifiers = document.Element("SignedIdentifiers");
                            if (signedIdentifiers != null)
                            {
                                value = new List<SignedIdentifier>();
                                foreach (var e in signedIdentifiers.Elements("SignedIdentifier"))
                                {
                                    SignedIdentifier value0 = default;
                                    value0 = SignedIdentifier.DeserializeSignedIdentifier(e);
                                    value.Add(value0);
                                }
                            }
                            var headers = new GetAccessPolicyHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Retrieves details about any stored access policies specified on the table that may be used wit Shared Access Signatures. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ICollection<SignedIdentifier>, GetAccessPolicyHeaders> GetAccessPolicy(int? timeout, string requestId, string table, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.GetAccessPolicy");
            scope.Start();
            try
            {
                using var message = CreateGetAccessPolicyRequest(timeout, requestId, table);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            ICollection<SignedIdentifier> value = default;
                            var signedIdentifiers = document.Element("SignedIdentifiers");
                            if (signedIdentifiers != null)
                            {
                                value = new List<SignedIdentifier>();
                                foreach (var e in signedIdentifiers.Elements("SignedIdentifier"))
                                {
                                    SignedIdentifier value0 = default;
                                    value0 = SignedIdentifier.DeserializeSignedIdentifier(e);
                                    value.Add(value0);
                                }
                            }
                            var headers = new GetAccessPolicyHeaders(message.Response);
                            return ResponseWithHeaders.FromValue(value, headers, message.Response);
                        }
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        internal HttpMessage CreateSetAccessPolicyRequest(int? timeout, string requestId, string table, IEnumerable<SignedIdentifier> tableAcl)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethodAdditional.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            uri.AppendQuery("comp", "acl", true);
            request.Uri = uri;
            request.Headers.Add("x-ms-version", Version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("Content-Type", "application/xml");
            using var content = new XmlWriterContent();
            content.XmlWriter.WriteStartElement("SignedIdentifiers");
            foreach (var item in tableAcl)
            {
                content.XmlWriter.WriteObjectValue(item, "SignedIdentifier");
            }
            content.XmlWriter.WriteEndElement();
            request.Content = content;
            return message;
        }
        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="tableAcl"> the acls for the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<SetAccessPolicyHeaders>> SetAccessPolicyAsync(int? timeout, string requestId, string table, IEnumerable<SignedIdentifier> tableAcl, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.SetAccessPolicy");
            scope.Start();
            try
            {
                using var message = CreateSetAccessPolicyRequest(timeout, requestId, table, tableAcl);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 204:
                        var headers = new SetAccessPolicyHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> sets stored access policies for the table that may be used with Shared Access Signatures. </summary>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="tableAcl"> the acls for the table. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<SetAccessPolicyHeaders> SetAccessPolicy(int? timeout, string requestId, string table, IEnumerable<SignedIdentifier> tableAcl, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var scope = clientDiagnostics.CreateScope("TableOperations.SetAccessPolicy");
            scope.Start();
            try
            {
                using var message = CreateSetAccessPolicyRequest(timeout, requestId, table, tableAcl);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 204:
                        var headers = new SetAccessPolicyHeaders(message.Response);
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw message.Response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
