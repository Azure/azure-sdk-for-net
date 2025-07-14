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
using Azure.AI.Agents.Persistent.Telemetry;

namespace Azure.AI.Agents.Persistent
{
    // Enum to specify the type of items in the pageable
    internal enum ContinuationItemType
    {
        Undefined,
        ThreadMessage,
        RunStep
    }

    internal class ContinuationTokenPageable<T>: Pageable<T>
    {
        private readonly ContinuationTokenPageableImpl<T> _impl;
        private readonly ContinuationItemType _itemType;

        public ContinuationTokenPageable(
            Func<int?, string, HttpMessage> createPageRequest,
            Func<JsonElement, T> valueFactory,
            HttpPipeline pipeline,
            ClientDiagnostics clientDiagnostics,
            string scopeName,
            RequestContext requestContext,
            string itemPropertyName = "data",
            string hasMoreField = "has_more",
            string continuationTokenName = "last_id",
            ContinuationItemType itemType = ContinuationItemType.Undefined,
            string threadId = null,
            string runId = null,
            Uri endpoint = null
        )
        {
            _itemType = itemType;
            _impl = new(
                createPageRequest: createPageRequest,
                valueFactory: valueFactory,
                pipeline: pipeline,
                clientDiagnostics: clientDiagnostics,
                scopeName: scopeName,
                requestContext: requestContext,
                itemPropertyName: itemPropertyName,
                hasMoreField: hasMoreField,
                continuationTokenName: continuationTokenName,
                itemType: itemType,
                threadId: threadId,
                runId: runId,
                endpoint: endpoint
            );
        }

        public override IEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null) => _impl.AsPages(continuationToken, pageSizeHint);
    }

    internal class ContinuationTokenPageableAsync<T> : AsyncPageable<T>
    {
        private readonly ContinuationTokenPageableImpl<T> _impl;
        private readonly ContinuationItemType _itemType;

        public ContinuationTokenPageableAsync(
            Func<int?, string, HttpMessage> createPageRequest,
            Func<JsonElement, T> valueFactory,
            HttpPipeline pipeline,
            ClientDiagnostics clientDiagnostics,
            string scopeName,
            RequestContext requestContext,
            string itemPropertyName = "data",
            string hasMoreField = "has_more",
            string continuationTokenName = "last_id",
            ContinuationItemType itemType = ContinuationItemType.Undefined,
            string threadId = null,
            string runId = null,
            Uri endpoint = null
        )
        {
            _itemType = itemType;
            _impl = new(
                createPageRequest: createPageRequest,
                valueFactory: valueFactory,
                pipeline: pipeline,
                clientDiagnostics: clientDiagnostics,
                scopeName: scopeName,
                requestContext: requestContext,
                itemPropertyName: itemPropertyName,
                hasMoreField: hasMoreField,
                continuationTokenName: continuationTokenName,
                itemType: itemType,
                threadId: threadId,
                runId: runId,
                endpoint: endpoint
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
        private readonly ContinuationItemType _itemType;
        private readonly string _threadId;
        private readonly string _runId;
        private readonly Uri _endpoint;

        public ContinuationTokenPageableImpl(
            Func<int?, string, HttpMessage> createPageRequest,
            Func<JsonElement, T> valueFactory,
            HttpPipeline pipeline,
            ClientDiagnostics clientDiagnostics,
            string scopeName,
            RequestContext requestContext,
            string itemPropertyName,
            string hasMoreField,
            string continuationTokenName,
            ContinuationItemType itemType = ContinuationItemType.Undefined,
            string threadId = null,
            string runId = null,
            Uri endpoint = null
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
            _itemType = itemType;
            _threadId = threadId;
            _runId = runId;
            _endpoint = endpoint;
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

            // Use GenAI scope for paging if item type is specified
            OpenTelemetryScope genAIScope = null;
            DiagnosticScope? diagnosticsScope = null;
            if (_itemType == ContinuationItemType.ThreadMessage)
            {
                genAIScope = OpenTelemetryScope.StartListMessages(_threadId, _runId, _endpoint);
            }
            else if (_itemType == ContinuationItemType.RunStep)
            {
                genAIScope = OpenTelemetryScope.StartListRunSteps(_threadId, _runId, _endpoint);
            }
            else
            {
                diagnosticsScope = _clientDiagnostics.CreateScope(_scopeName);
            }

            using (genAIScope)
            {
                using (diagnosticsScope)
                {
                    diagnosticsScope?.Start();
                    try
                    {
                        _pipeline.Send(message, _cancellationToken);
                        var response = GetResponse(message);
                        genAIScope?.RecordPagedResponse(response);
                        return response;
                    }
                    catch (Exception e)
                    {
                        diagnosticsScope?.Failed(e);
                        genAIScope?.RecordError(e);
                        throw;
                    }
                }
            }
        }

        private async ValueTask<Response> GetNextResponseAsync(int? pageSizeHint, string continuationToken, CancellationToken cancellationToken)
        {
            var message = CreateMessage(pageSizeHint, continuationToken);

            // Use GenAI scope for paging if item type is specified
            OpenTelemetryScope genAIScope = null;
            DiagnosticScope? diagnosticsScope = null;
            if (_itemType == ContinuationItemType.ThreadMessage)
            {
                genAIScope = OpenTelemetryScope.StartListMessages(_threadId, _runId, _endpoint);
            }
            else if (_itemType == ContinuationItemType.RunStep)
            {
                genAIScope = OpenTelemetryScope.StartListRunSteps(_threadId, _runId, _endpoint);
            }
            else
            {
                diagnosticsScope = _clientDiagnostics.CreateScope(_scopeName);
            }

            using (genAIScope)
            {
                using (diagnosticsScope)
                {
                    diagnosticsScope?.Start();
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

                        var response = GetResponse(message);
                        genAIScope?.RecordPagedResponse(response);
                        return response;
                    }
                    catch (Exception e)
                    {
                        diagnosticsScope?.Failed(e);
                        genAIScope?.RecordError(e);
                        throw;
                    }
                }
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
