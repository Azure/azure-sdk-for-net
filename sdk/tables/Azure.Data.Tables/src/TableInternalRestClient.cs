// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Pipeline;
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
            if (queryOptions?.IfMatch != null)
            {
                request.Headers.Add(TableConstants.HeaderNames.IfMatch, queryOptions.IfMatch);
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
            if (queryOptions?.IfMatch != null)
            {
                request.Headers.Add(TableConstants.HeaderNames.IfMatch, queryOptions.IfMatch);
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
            if (queryOptions?.IfMatch != null)
            {
                request.Headers.Add(TableConstants.HeaderNames.IfMatch, queryOptions.IfMatch);
            }
            return message;
        }

        /// <summary> Insert entity in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ReadOnlyDictionary<string, object>, TableInternalInsertEntityHeaders>> InsertEntityAsync(string table, int? timeout = null, string requestId = null, IDictionary<string, object> tableEntityProperties = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default) =>
            await InsertEntityInternalAsync(true, table, timeout, requestId, tableEntityProperties, queryOptions, cancellationToken).ConfigureAwait(false);

        /// <summary> Insert entity in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ReadOnlyDictionary<string, object>, TableInternalInsertEntityHeaders> InsertEntity(string table, int? timeout = null, string requestId = null, IDictionary<string, object> tableEntityProperties = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default) =>
            InsertEntityInternalAsync(false, table, timeout, requestId, tableEntityProperties, queryOptions, cancellationToken).EnsureCompleted();

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used wit Shared Access Signatures. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<ResponseWithHeaders<ReadOnlyCollection<SignedIdentifier>, TableInternalGetAccessPolicyHeaders>> GetAccessPolicyAsync(string table, int? timeout = null, string requestId = null, CancellationToken cancellationToken = default) =>
            await GetAccessPolicyInternalAsync(true, table, timeout, requestId, cancellationToken).ConfigureAwait(false);

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used wit Shared Access Signatures. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<ReadOnlyCollection<SignedIdentifier>, TableInternalGetAccessPolicyHeaders> GetAccessPolicy(string table, int? timeout = null, string requestId = null, CancellationToken cancellationToken = default) =>
            GetAccessPolicyInternalAsync(false, table, timeout, requestId, cancellationToken).EnsureCompleted();

        /// <summary> Retrieves details about any stored access policies specified on the table that may be used wit Shared Access Signatures. </summary>
        /// <param name="async">Determines whether execution will occur asynchronously.</param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        private async ValueTask<ResponseWithHeaders<ReadOnlyCollection<SignedIdentifier>, TableInternalGetAccessPolicyHeaders>> GetAccessPolicyInternalAsync(bool async, string table, int? timeout = null, string requestId = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.GetAccessPolicy");
            scope.Start();
            try
            {
                using var message = CreateGetAccessPolicyRequest(table, timeout, requestId);
                if (async)
                {
                    await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _pipeline.Send(message, cancellationToken);
                }

                var headers = new TableInternalGetAccessPolicyHeaders(message.Response);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            List<SignedIdentifier> value = default;
                            var document = XDocument.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);
                            if (document.Element("SignedIdentifiers") is XElement signedIdentifiersElement)
                            {
                                var array = new List<SignedIdentifier>();
                                foreach (var e in signedIdentifiersElement.Elements("SignedIdentifier"))
                                {
                                    array.Add(SignedIdentifier.DeserializeSignedIdentifier(e));
                                }
                                value = array;
                            }
                            return ResponseWithHeaders.FromValue(value.AsReadOnly(), headers, message.Response);
                        }
                    default:
                        if (async)
                        {
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                        }
                        else
                        {
                            throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                        }

                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Insert entity in a table. </summary>
        /// <param name="async">Determines whether execution will occur asynchronously.</param>
        /// <param name="table"> The name of the table. </param>
        /// <param name="timeout"> The The timeout parameter is expressed in seconds. For more information, see &lt;a href=&quot;https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations&gt;Setting Timeouts for Queue Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestId"> Provides a client-generated, opaque value with a 1 KB character limit that is recorded in the analytics logs when storage analytics logging is enabled. </param>
        /// <param name="tableEntityProperties"> The properties for the table entity. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        private async ValueTask<ResponseWithHeaders<ReadOnlyDictionary<string, object>, TableInternalInsertEntityHeaders>> InsertEntityInternalAsync(bool async, string table, int? timeout = null, string requestId = null, IDictionary<string, object> tableEntityProperties = null, QueryOptions queryOptions = null, CancellationToken cancellationToken = default)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            using var scope = _clientDiagnostics.CreateScope("TableInternalClient.InsertEntity");
            scope.Start();
            try
            {
                using var message = CreateInsertEntityRequest(table, timeout, requestId, tableEntityProperties, queryOptions);
                if (async)
                {
                    await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _pipeline.Send(message, cancellationToken);
                }

                var headers = new TableInternalInsertEntityHeaders(message.Response);
                switch (message.Response.Status)
                {
                    case 201:
                        {
                            Dictionary<string, object> value = default;
                            JsonDocument document;
                            if (async)
                            {
                                document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            }
                            else
                            {
                                document = JsonDocument.Parse(message.Response.ContentStream);
                            }
                            using (document)
                            {

                                if (document.RootElement.ValueKind == JsonValueKind.Null)
                                {
                                    value = null;
                                }
                                else
                                {
                                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                                    foreach (var property in document.RootElement.EnumerateObject())
                                    {
                                        if (property.Value.ValueKind == JsonValueKind.Null)
                                        {
                                            dictionary.Add(property.Name, null);
                                        }
                                        else
                                        {
                                            dictionary.Add(property.Name, property.Value.GetObject());
                                        }
                                    }
                                    value = dictionary;
                                }
                                return ResponseWithHeaders.FromValue(new ReadOnlyDictionary<string, object>(value), headers, message.Response);
                            }
                        }
                    default:
                        if (async)
                        {
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                        }
                        else
                        {
                            throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                        }

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
