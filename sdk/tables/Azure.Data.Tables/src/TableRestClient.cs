// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Data.Tables.Models;

namespace Azure.Data.Tables
{
    internal partial class TableRestClient
    {
        internal string endpoint
        {
            get { return _url; }
        }

        internal string clientVersion => _version;

        internal HttpMessage CreateBatchRequest(MultipartContent content, string requestId, ResponseFormat? responsePreference)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(_url, false);
            uri.AppendPath("/$batch", false);
            request.Uri = uri;
            request.Headers.Add("x-ms-version", _version);
            if (requestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", requestId);
            }
            request.Headers.Add("DataServiceVersion", "3.0");
            if (responsePreference != null)
            {
                request.Headers.Add("Prefer", responsePreference.Value.ToString());
            }
            request.Headers.Add("Accept", "application/json");

            request.Content = content;
            content.ApplyToRequest(request);
            return message;
        }

        internal static MultipartContent CreateBatchContent(Guid batchGuid)
        {
            var guid = batchGuid == default ? Guid.NewGuid() : batchGuid;
            return new MultipartContent("mixed", $"batch_{guid}");
        }

        /// <summary> Submits a batch operation to a table. </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        public async Task<Response<IReadOnlyList<Response>>> SendBatchRequestAsync(HttpMessage message, CancellationToken cancellationToken = default)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    {
                        var responses = await MultipartResponse.ParseAsync(
                                message.Response,
                                false,
                                cancellationToken)
                            .ConfigureAwait(false);

                        var failedSubResponse = responses.FirstOrDefault(r => r.Status >= 400);
                        if (failedSubResponse == null)
                        {
                            return Response.FromValue((IReadOnlyList<Response>)responses, message.Response);
                        }

                        RequestFailedException rfex = new(failedSubResponse);
                        var ex = new TableTransactionFailedException(rfex);
                        throw ex;
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Submits a batch operation to a table. </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        public Response<IReadOnlyList<Response>> SendBatchRequest(HttpMessage message, CancellationToken cancellationToken = default)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    {
                        var responses = MultipartResponse.Parse(
                                message.Response,
                                false,
                                cancellationToken);

                        var failedSubResponse = responses.FirstOrDefault(r => r.Status >= 400);
                        if (failedSubResponse == null)
                        {
                            return Response.FromValue((IReadOnlyList<Response>)responses, message.Response);
                        }

                        RequestFailedException rfex = new(failedSubResponse);
                        var ex = new TableTransactionFailedException(rfex);
                        throw ex;
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Queries a single entity in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. </param>
        /// <param name="format"> Specifies the media type for the response. Allowed values: &quot;application/json;odata=nometadata&quot; | &quot;application/json;odata=minimalmetadata&quot; | &quot;application/json;odata=fullmetadata&quot;. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/>, <paramref name="partitionKey"/> or <paramref name="rowKey"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="table"/>, <paramref name="partitionKey"/> or <paramref name="rowKey"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response QueryEntityWithPartitionAndRowKey(string table, string partitionKey, string rowKey, int? timeout = null, string format = null, string select = null, string filter = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(table, nameof(table));
            Argument.AssertNotNull(partitionKey, nameof(partitionKey));
            Argument.AssertNotNull(rowKey, nameof(rowKey));

            using var scope = ClientDiagnostics.CreateScope("Table.QueryEntityWithPartitionAndRowKey");
            scope.Start();
            try
            {
                using HttpMessage message = CreateQueryEntityWithPartitionAndRowKeyRequest(table, partitionKey, rowKey, timeout, format, select, filter, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Queries a single entity in a table. </summary>
        /// <param name="table"> The name of the table. </param>
        /// <param name="partitionKey"> The partition key of the entity. </param>
        /// <param name="rowKey"> The row key of the entity. </param>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. </param>
        /// <param name="format"> Specifies the media type for the response. Allowed values: &quot;application/json;odata=nometadata&quot; | &quot;application/json;odata=minimalmetadata&quot; | &quot;application/json;odata=fullmetadata&quot;. </param>
        /// <param name="select"> Select expression using OData notation. Limits the columns on each record to just those requested, e.g. &quot;$select=PolicyAssignmentId, ResourceId&quot;. </param>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="table"/>, <paramref name="partitionKey"/> or <paramref name="rowKey"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="table"/>, <paramref name="partitionKey"/> or <paramref name="rowKey"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> QueryEntityWithPartitionAndRowKeyAsync(string table, string partitionKey, string rowKey, int? timeout = null, string format = null, string select = null, string filter = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(table, nameof(table));
            Argument.AssertNotNull(partitionKey, nameof(partitionKey));
            Argument.AssertNotNull(rowKey, nameof(rowKey));

            using var scope = ClientDiagnostics.CreateScope("Table.QueryEntityWithPartitionAndRowKey");
            scope.Start();
            try
            {
                using HttpMessage message = CreateQueryEntityWithPartitionAndRowKeyRequest(table, partitionKey, rowKey, timeout, format, select, filter, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
