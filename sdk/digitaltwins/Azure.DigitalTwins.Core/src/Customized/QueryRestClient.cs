// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.DigitalTwins.Core
{
    internal partial class QueryRestClient
    {
        internal async Task<ResponseWithHeaders<QueryResult<T>, QueryQueryTwinsHeaders>> QueryTwinsAsync<T>(
            QuerySpecification querySpecification,
            QueryOptions queryTwinsOptions = null,
            ObjectSerializer objectSerializer = null,
            CancellationToken cancellationToken = default)
        {
            if (querySpecification == null)
            {
                throw new ArgumentNullException(nameof(querySpecification));
            }

            if (objectSerializer == null)
            {
                throw new ArgumentNullException(nameof(objectSerializer));
            }

            using HttpMessage message = CreateQueryTwinsRequest(querySpecification, queryTwinsOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new QueryQueryTwinsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        using JsonDocument document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        QueryResult<T> value = QueryResult<T>.DeserializeQueryResult(document.RootElement, objectSerializer);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        internal ResponseWithHeaders<QueryResult<T>, QueryQueryTwinsHeaders> QueryTwins<T>(
            QuerySpecification querySpecification,
            QueryOptions queryTwinsOptions = null,
            ObjectSerializer objectSerializer = null,
            CancellationToken cancellationToken = default)
        {
            if (querySpecification == null)
            {
                throw new ArgumentNullException(nameof(querySpecification));
            }

            if (objectSerializer == null)
            {
                throw new ArgumentNullException(nameof(objectSerializer));
            }

            using HttpMessage message = CreateQueryTwinsRequest(querySpecification, queryTwinsOptions);
            _pipeline.Send(message, cancellationToken);
            var headers = new QueryQueryTwinsHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        QueryResult<T> value = QueryResult<T>.DeserializeQueryResult(document.RootElement, objectSerializer);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        #region null overrides

        // The following methods are only declared so that autorest does not create these functions in the generated code.
        // For methods that we need to override, when the parameter list is the same, autorest knows not to generate them again.
        // These methods should never be called.

#pragma warning disable CA1801, IDE0051, IDE0060, CA1822 // Remove unused parameter

        private Task<ResponseWithHeaders<QueryResult, QueryQueryTwinsHeaders>> QueryTwinsAsync(QuerySpecification querySpecification, QueryOptions queryTwinsOptions = null, CancellationToken cancellationToken = default) => null;

        private ResponseWithHeaders<QueryResult, QueryQueryTwinsHeaders> QueryTwins(QuerySpecification querySpecification, QueryOptions queryTwinsOptions = null, CancellationToken cancellationToken = default) => null;

#pragma warning restore CA1801, IDE0051, IDE0060 // Remove unused parameter

        #endregion null overrides
    }
}
