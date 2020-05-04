// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Data.Tables.Models;

namespace Azure.Data.Tables
{
    internal partial class TableInternalRestClient
    {
        // Should be unnecessary when https://github.com/Azure/azure-rest-api-specs/pull/8151/files#r414749024 is implemented.
        internal HttpMessage CreateDeleteRequest(string table, string requestId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/Tables('", false);
            uri.AppendPath(table, true);
            uri.AppendPath("')", false);
            request.Uri = uri;
            request.Headers.Add("x-ms-version", version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            // Delete requests fail without this header.
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        // Should be unnecessary when https://github.com/Azure/azure-rest-api-specs/pull/8151/files#r415950870 is implemented.
        internal HttpMessage CreateQueryRequest(string requestId, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/Tables", false);
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            if (queryOptions?.Top != null)
            {
                uri.AppendQuery("$top", queryOptions.Top.Value, true);
            }
            if (queryOptions?.Select != null)
            {
                uri.AppendQuery("$select", queryOptions.Select, true);
            }
            if (queryOptions?.Filter != null)
            {
                uri.AppendQuery("$filter", queryOptions.Filter, true);
            }
            if (queryOptions?.NextTableName != null)
            {
                uri.AppendQuery(TableConstants.QueryParameterNames.NextTableName, queryOptions.NextTableName, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            return message;
        }

        // Should be unnecessary when https://github.com/Azure/azure-rest-api-specs/pull/8151/files#r415950870 is implemented.
        internal HttpMessage CreateQueryEntitiesRequest(string table, int? timeout, string requestId, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/", false);
            uri.AppendPath(table, true);
            uri.AppendPath("()", false);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", timeout.Value, true);
            }
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            if (queryOptions?.Top != null)
            {
                uri.AppendQuery("$top", queryOptions.Top.Value, true);
            }
            if (queryOptions?.Select != null)
            {
                uri.AppendQuery("$select", queryOptions.Select, true);
            }
            if (queryOptions?.Filter != null)
            {
                uri.AppendQuery("$filter", queryOptions.Filter, true);
            }
            if (queryOptions?.NextPartitionKey != null)
            {
                uri.AppendQuery(TableConstants.QueryParameterNames.NextPartitionKey, queryOptions.NextPartitionKey, true);
            }
            if (queryOptions?.NextRowKey != null)
            {
                uri.AppendQuery(TableConstants.QueryParameterNames.NextRowKey, queryOptions.NextRowKey, true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            return message;
        }

        // Should be unnecessary when https://github.com/Azure/azure-rest-api-specs/pull/8151/files/f5cb6fb416ae0a06329599db9dc17c8fdd7f95c7#r416178973 is implemented.
        internal HttpMessage CreateUpdateEntityRequest(string table, string partitionKey, string rowKey, int? timeout, string requestId, IDictionary<string, object> tableEntityProperties, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
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
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            request.Headers.Add("Content-Type", "application/json;odata=nometadata");
            if (queryOptions?.ETag != null)
            {
                request.Headers.Add(TableConstants.HeaderNames.IfMatch, queryOptions.ETag);
            }
            if (tableEntityProperties != null)
            {
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in tableEntityProperties)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteObjectValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
                request.Content = content;
            }
            return message;
        }

        // All Merge related methods Should be unnecessary when https://github.com/Azure/azure-rest-api-specs/pull/8151/files/f5cb6fb416ae0a06329599db9dc17c8fdd7f95c7#r417331328 is implemented.
        internal HttpMessage CreateMergeEntityRequest(string table, string partitionKey, string rowKey, int? timeout, string requestId, IDictionary<string, object> tableEntityProperties, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = new RequestMethod("MERGE");
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
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            request.Headers.Add("Content-Type", "application/json;odata=nometadata");
            if (queryOptions?.ETag != null)
            {
                request.Headers.Add(TableConstants.HeaderNames.IfMatch, queryOptions.ETag);
            }
            if (tableEntityProperties != null)
            {
                using var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteStartObject();
                foreach (var item in tableEntityProperties)
                {
                    content.JsonWriter.WritePropertyName(item.Key);
                    content.JsonWriter.WriteObjectValue(item.Value);
                }
                content.JsonWriter.WriteEndObject();
                request.Content = content;
            }
            return message;
        }

        /// <summary> Merge entity in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<TableInternalMergeEntityHeaders>> MergeEntityAsync(string table, string partitionKey, string rowKey, int? timeout = null, string requestId = null, IDictionary<string, object> tableEntityProperties = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
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

            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.UpdateEntity");
            scope.Start();
            try
            {
                using var message = CreateMergeEntityRequest(table, partitionKey, rowKey, timeout, requestId, tableEntityProperties, queryOptions);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                var headers = new TableInternalMergeEntityHeaders(message.Response);
                switch (message.Response.Status)
                {
                    case 204:
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Merge entity in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<TableInternalMergeEntityHeaders> MergeEntity(string table, string partitionKey, string rowKey, int? timeout = null, string requestId = null, IDictionary<string, object> tableEntityProperties = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
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

            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.UpdateEntity");
            scope.Start();
            try
            {
                using var message = CreateMergeEntityRequest(table, partitionKey, rowKey, timeout, requestId, tableEntityProperties, queryOptions);
                _pipeline.Send(message, cancellationToken);
                var headers = new TableInternalMergeEntityHeaders(message.Response);
                switch (message.Response.Status)
                {
                    case 204:
                        return ResponseWithHeaders.FromValue(headers, message.Response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateDeleteEntityRequest(string table, string partitionKey, string rowKey, int? timeout, string requestId, QueryOptions queryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
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
            if (queryOptions?.Format != null)
            {
                uri.AppendQuery("$format", queryOptions.Format.Value.ToString(), true);
            }
            request.Uri = uri;
            request.Headers.Add("x-ms-version", version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            if (queryOptions?.ETag != null)
            {
                request.Headers.Add(TableConstants.HeaderNames.IfMatch, queryOptions.ETag);
            }
            return message;
        }

        internal HttpMessage CreateSetAccessPolicyRequest(string table, int? timeout, string requestId, IEnumerable<SignedIdentifier> tableAcl)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
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
            request.Headers.Add("x-ms-version", version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("Content-Type", "application/xml");
            if (tableAcl != null)
            {
                using var content = new XmlWriterContent();
                content.XmlWriter.WriteStartDocument();
                content.XmlWriter.WriteStartElement("SignedIdentifiers");
                foreach (var item in tableAcl)
                {
                    content.XmlWriter.WriteObjectValue(item, "SignedIdentifier");
                }
                content.XmlWriter.WriteEndElement();
                request.Content = content;
            }
            return message;
        }
    }
}
