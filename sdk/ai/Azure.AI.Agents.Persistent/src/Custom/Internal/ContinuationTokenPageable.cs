// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Core;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace Azure.AI.Agents.Persistent
{
    internal class ContinuationTokenPageable<T>: Pageable<T>
    {
        private readonly ContinuationTokenPageableImpl<T> _impl;
        public ContinuationTokenPageable(
            Func<int?, string, HttpMessage> createPageRequest,
            Func<JsonElement, T> valueFactory,
            HttpPipeline pipeline,
            ClientDiagnostics clientDiagnostics,
            string scopeName,
            RequestContext requestContext,
            string itemPropertyName = "data",
            string hasMoreField = "has_more",
            string continuationTokenName = "last_id"
        )
        {
            _impl = new(
                createPageRequest: createPageRequest,
                valueFactory: valueFactory,
                pipeline: pipeline,
                clientDiagnostics: clientDiagnostics,
                scopeName: scopeName,
                requestContext: requestContext,
                itemPropertyName: itemPropertyName,
                hasMoreField: hasMoreField,
                continuationTokenName: continuationTokenName
            );
        }

        public override IEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null) => _impl.AsPages(continuationToken, pageSizeHint);
    }

    internal class ContinuationTokenPageableAsync<T> : AsyncPageable<T>
    {
        private readonly ContinuationTokenPageableImpl<T> _impl;
        public ContinuationTokenPageableAsync(
            Func<int?, string, HttpMessage> createPageRequest,
            Func<JsonElement, T> valueFactory,
            HttpPipeline pipeline,
            ClientDiagnostics clientDiagnostics,
            string scopeName,
            RequestContext requestContext,
            string itemPropertyName = "data",
            string hasMoreField = "has_more",
            string continuationTokenName = "last_id"
        )
        {
            _impl = new(
                createPageRequest: createPageRequest,
                valueFactory: valueFactory,
                pipeline: pipeline,
                clientDiagnostics: clientDiagnostics,
                scopeName: scopeName,
                requestContext: requestContext,
                itemPropertyName: itemPropertyName,
                hasMoreField: hasMoreField,
                continuationTokenName: continuationTokenName
            );
        }

        public override IAsyncEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null) => _impl.AsPagesAsync(continuationToken, pageSizeHint, default);
    }

    /// <summary>
    /// The implementation of continuation pageable capable to use continuation token.
    /// </summary>
    internal class ContinuationTokenPageableImpl<T>
    {
        private readonly Func<int?, string, HttpMessage> _createPageRequest;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Func<JsonElement, T> _valueFactory;
        private readonly string _scopeName;
        private readonly CancellationToken _cancellationToken;
        private readonly ErrorOptions _errorOptions;
        private readonly string _itemPropertyName;
        private readonly string _hasMoreField;
        private readonly string _continuationTokenName;

        public ContinuationTokenPageableImpl(
            Func<int?, string, HttpMessage> createPageRequest,
            Func<JsonElement, T> valueFactory,
            HttpPipeline pipeline,
            ClientDiagnostics clientDiagnostics,
            string scopeName,
            RequestContext requestContext,
            string itemPropertyName,
            string hasMoreField,
            string continuationTokenName
        )
        {
            _createPageRequest = createPageRequest;
            _valueFactory = valueFactory;
            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
            _scopeName = scopeName;
            _cancellationToken = requestContext?.CancellationToken ?? default;
            _errorOptions = requestContext?.ErrorOptions ?? ErrorOptions.Default;
            _itemPropertyName = itemPropertyName;
            _hasMoreField = hasMoreField;
            _continuationTokenName = continuationTokenName;
        }

        public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            string continuationToken = default;
            do
            {
                var response = await GetNextResponseAsync(null, continuationToken, cancellationToken).ConfigureAwait(false);
                if (!TryGetItemsFromResponse(response, out continuationToken, out var items))
                {
                    continue;
                }

                foreach (var item in items)
                {
                    yield return item;
                }
            } while (!string.IsNullOrEmpty(continuationToken));
        }

        public IEnumerator<T> GetEnumerator()
        {
            string continuationToken = default;
            do
            {
                Response response = GetNextResponse(pageSizeHint: null, continuationToken: continuationToken);
                if (!TryGetItemsFromResponse(response, out continuationToken, out var items))
                {
                    continue;
                }

                foreach (T item in items)
                {
                    yield return item;
                }
            } while (!string.IsNullOrEmpty(continuationToken));
        }

        public IEnumerable<Page<T>> AsPages(string continuationToken, int? pageSizeHint)
        {
            do
            {
                Response response = GetNextResponse(pageSizeHint, continuationToken);
                if (response is null)
                {
                    yield break;
                }
                yield return CreatePage(response, out continuationToken);
            } while (!string.IsNullOrEmpty(continuationToken));
        }

        public async IAsyncEnumerable<Page<T>> AsPagesAsync(string continuationToken, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            do
            {
                Response response = await GetNextResponseAsync(pageSizeHint, continuationToken, cancellationToken).ConfigureAwait(false);
                if (response is null)
                {
                    yield break;
                }
                yield return CreatePage(response, out continuationToken);
            } while (!string.IsNullOrEmpty(continuationToken));
        }

        private Response GetNextResponse(int? pageSizeHint, string continuationToken)
        {
            var message = CreateMessage(pageSizeHint, continuationToken);
            if (message == null)
            {
                return null;
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
            scope.Start();
            try
            {
                _pipeline.Send(message, _cancellationToken);
                return GetResponse(message);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async ValueTask<Response> GetNextResponseAsync(int? pageSizeHint, string continuationToken, CancellationToken cancellationToken)
        {
            var message = CreateMessage(pageSizeHint, continuationToken);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
            scope.Start();
            try
            {
                if (cancellationToken.CanBeCanceled && _cancellationToken.CanBeCanceled)
                {
                    using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _cancellationToken);
                    await _pipeline.SendAsync(message, cts.Token).ConfigureAwait(false);
                }
                else
                {
                    var ct = cancellationToken.CanBeCanceled ? cancellationToken : _cancellationToken;
                    await _pipeline.SendAsync(message, ct).ConfigureAwait(false);
                }

                return GetResponse(message);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private HttpMessage CreateMessage(int? pageSizeHint, string continuationToken) =>
            string.IsNullOrEmpty(continuationToken)
                ? _createPageRequest(pageSizeHint, null)
                : _createPageRequest(pageSizeHint, continuationToken);

        private Response GetResponse(HttpMessage message)
        {
            if (message.Response.IsError && !_errorOptions.HasFlag(ErrorOptions.NoThrow))
            {
                throw new RequestFailedException(message.Response);
            }

            return message.Response;
        }

        private bool TryGetItemsFromResponse(Response response, out string continuationToken, out List<T> items)
        {
            items = default;
            if (response is null)
            {
                continuationToken = default;
                return false;
            }
            JsonDocument document = response.ContentStream != null ? JsonDocument.Parse(response.ContentStream) : JsonDocument.Parse(response.Content);
            bool hasNext = document.RootElement.TryGetProperty(_hasMoreField, out JsonElement hasNextVal) && hasNextVal.GetBoolean();
            continuationToken = hasNext ? document.RootElement.TryGetProperty(_continuationTokenName, out JsonElement cont) ? cont.GetString() : null : null;
            if (document.RootElement.TryGetProperty(_itemPropertyName, out JsonElement itemsValue))
            {
                JsonElement.ArrayEnumerator jsonArrayEnumerator = itemsValue.EnumerateArray();
                items = [];
                foreach (JsonElement elem in jsonArrayEnumerator)
                    items.Add(_valueFactory(elem));
                return true;
            }
            return items is null;
        }

        private Page<T> CreatePage(Response response, out string continuationToken) =>
            TryGetItemsFromResponse(response, out continuationToken, out List<T> items)
                ? Page<T>.FromValues(items, continuationToken, response)
                : Page<T>.FromValues(Array.Empty<T>(), continuationToken, response);
    }
}
