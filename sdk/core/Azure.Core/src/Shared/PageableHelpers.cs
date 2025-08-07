// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal static class PageableHelpers
    {
        private static readonly byte[] DefaultItemPropertyName = Encoding.UTF8.GetBytes("value");
        private static readonly byte[] DefaultNextLinkPropertyName = Encoding.UTF8.GetBytes("nextLink");

        public static AsyncPageable<T> CreateAsyncPageable<T>(Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageRequest, Func<Response, (List<T>? Values, string? NextLink)> responseParser, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, RequestContext? requestContext = null) where T : notnull
        {
            return new AsyncPageableWrapper<T>(new PageableImplementation<T>(createFirstPageRequest, createNextPageRequest, responseParser, pipeline, clientDiagnostics, scopeName, null, requestContext));
        }

        public static AsyncPageable<T> CreateAsyncPageable<T>(Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageRequest, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, CancellationToken cancellationToken) where T : notnull
        {
            return new AsyncPageableWrapper<T>(new PageableImplementation<T>(null, createFirstPageRequest, createNextPageRequest, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, cancellationToken, null));
        }

        public static AsyncPageable<T> CreateAsyncPageable<T>(Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageRequest, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, RequestContext? requestContext = null) where T : notnull
        {
            return new AsyncPageableWrapper<T>(new PageableImplementation<T>(null, createFirstPageRequest, createNextPageRequest, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, requestContext?.CancellationToken, requestContext?.ErrorOptions));
        }

        public static AsyncPageable<T> CreateAsyncPageable<T>(Response initialResponse, Func<int?, string, HttpMessage>? createNextPageRequest, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, CancellationToken cancellationToken) where T : notnull
        {
            return new AsyncPageableWrapper<T>(new PageableImplementation<T>(initialResponse, null, createNextPageRequest, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, cancellationToken, null));
        }

        public static Pageable<T> CreatePageable<T>(Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageRequest, Func<Response, (List<T>? Values, string? NextLink)> responseParser, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, RequestContext? requestContext = null) where T : notnull
        {
            return new PageableWrapper<T>(new PageableImplementation<T>(createFirstPageRequest, createNextPageRequest, responseParser, pipeline, clientDiagnostics, scopeName, null, requestContext));
        }

        public static Pageable<T> CreatePageable<T>(Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageRequest, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, CancellationToken cancellationToken) where T : notnull
        {
            return new PageableWrapper<T>(new PageableImplementation<T>(null, createFirstPageRequest, createNextPageRequest, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, cancellationToken, null));
        }

        public static Pageable<T> CreatePageable<T>(Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageRequest, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, RequestContext? requestContext = null) where T : notnull
        {
            return new PageableWrapper<T>(new PageableImplementation<T>(null, createFirstPageRequest, createNextPageRequest, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, requestContext?.CancellationToken, requestContext?.ErrorOptions));
        }

        public static Pageable<T> CreatePageable<T>(Response initialResponse, Func<int?, string, HttpMessage>? createNextPageRequest, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, CancellationToken cancellationToken) where T : notnull
        {
            return new PageableWrapper<T>(new PageableImplementation<T>(initialResponse, null, createNextPageRequest, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, cancellationToken, null));
        }

        public static async ValueTask<Operation<AsyncPageable<T>>> CreateAsyncPageable<T>(WaitUntil waitUntil, HttpMessage message, Func<int?, string, HttpMessage>? createNextPageMethod, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, OperationFinalStateVia finalStateVia, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, RequestContext? requestContext = null) where T : notnull
        {
            AsyncPageable<T> ResultSelector(Response r) => new AsyncPageableWrapper<T>(new PageableImplementation<T>(r, null, createNextPageMethod, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, requestContext?.CancellationToken, requestContext?.ErrorOptions));

            var response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
            var operation = new ProtocolOperation<AsyncPageable<T>>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, ResultSelector);
            if (waitUntil == WaitUntil.Completed)
            {
                await operation.WaitForCompletionAsync(requestContext?.CancellationToken ?? default).ConfigureAwait(false);
            }
            return operation;
        }

        public static Operation<Pageable<T>> CreatePageable<T>(WaitUntil waitUntil, HttpMessage message, Func<int?, string, HttpMessage>? createNextPageMethod, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, OperationFinalStateVia finalStateVia, string scopeName, string? itemPropertyName, string? nextLinkPropertyName, RequestContext? requestContext = null) where T : notnull
        {
            Pageable<T> ResultSelector(Response r) => new PageableWrapper<T>(new PageableImplementation<T>(r, null, createNextPageMethod, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, requestContext?.CancellationToken, requestContext?.ErrorOptions));

            var response = pipeline.ProcessMessage(message, requestContext);
            var operation = new ProtocolOperation<Pageable<T>>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, ResultSelector);
            if (waitUntil == WaitUntil.Completed)
            {
                operation.WaitForCompletion(requestContext?.CancellationToken ?? default);
            }
            return operation;
        }

        public static Pageable<T> CreateEnumerable<T>(Func<int?, Page<T>> firstPageFunc, Func<string?, int?, Page<T>>? nextPageFunc, int? pageSize = default) where T : notnull
        {
            Func<string?, int?, Page<T>> first = (_, pageSizeHint) => firstPageFunc(pageSizeHint);
            return new FuncPageable<T>(first, nextPageFunc, pageSize);
        }

        public static AsyncPageable<T> CreateAsyncEnumerable<T>(Func<int?, Task<Page<T>>> firstPageFunc, Func<string?, int?, Task<Page<T>>>? nextPageFunc, int? pageSize = default) where T : notnull
        {
            Func<string?, int?, Task<Page<T>>> first = (_, pageSizeHint) => firstPageFunc(pageSizeHint);
            return new FuncAsyncPageable<T>(first, nextPageFunc, pageSize);
        }

        internal class FuncAsyncPageable<T> : AsyncPageable<T> where T : notnull
        {
            private readonly Func<string?, int?, Task<Page<T>>> _firstPageFunc;
            private readonly Func<string?, int?, Task<Page<T>>>? _nextPageFunc;
            private readonly int? _defaultPageSize;

            public FuncAsyncPageable(Func<string?, int?, Task<Page<T>>> firstPageFunc, Func<string?, int?, Task<Page<T>>>? nextPageFunc, int? defaultPageSize = default)
            {
                _firstPageFunc = firstPageFunc;
                _nextPageFunc = nextPageFunc;
                _defaultPageSize = defaultPageSize;
            }

            public override async IAsyncEnumerable<Page<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default)
            {
                Func<string?, int?, Task<Page<T>>>? pageFunc = string.IsNullOrEmpty(continuationToken) ? _firstPageFunc : _nextPageFunc;

                if (pageFunc == null)
                {
                    yield break;
                }

                int? pageSize = pageSizeHint ?? _defaultPageSize;
                do
                {
                    Page<T> pageResponse = await pageFunc(continuationToken, pageSize).ConfigureAwait(false);
                    yield return pageResponse;
                    continuationToken = pageResponse.ContinuationToken;
                    pageFunc = _nextPageFunc;
                } while (!string.IsNullOrEmpty(continuationToken) && pageFunc != null);
            }
        }

        internal class FuncPageable<T> : Pageable<T> where T : notnull
        {
            private readonly Func<string?, int?, Page<T>> _firstPageFunc;
            private readonly Func<string?, int?, Page<T>>? _nextPageFunc;
            private readonly int? _defaultPageSize;

            public FuncPageable(Func<string?, int?, Page<T>> firstPageFunc, Func<string?, int?, Page<T>>? nextPageFunc, int? defaultPageSize = default)
            {
                _firstPageFunc = firstPageFunc;
                _nextPageFunc = nextPageFunc;
                _defaultPageSize = defaultPageSize;
            }

            public override IEnumerable<Page<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default)
            {
                Func<string?, int?, Page<T>>? pageFunc = string.IsNullOrEmpty(continuationToken) ? _firstPageFunc : _nextPageFunc;

                if (pageFunc == null)
                {
                    yield break;
                }

                int? pageSize = pageSizeHint ?? _defaultPageSize;
                do
                {
                    Page<T> pageResponse = pageFunc(continuationToken, pageSize);
                    yield return pageResponse;
                    continuationToken = pageResponse.ContinuationToken;
                    pageFunc = _nextPageFunc;
                } while (!string.IsNullOrEmpty(continuationToken) && pageFunc != null);
            }
        }

        internal class AsyncPageableWrapper<T> : AsyncPageable<T> where T : notnull
        {
            private readonly PageableImplementation<T> _implementation;

            public AsyncPageableWrapper(PageableImplementation<T> implementation)
            {
                _implementation = implementation;
            }

            public override IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default) => _implementation.GetAsyncEnumerator(cancellationToken);
            public override IAsyncEnumerable<Page<T>> AsPages(string? continuationToken = null, int? pageSizeHint = null) => _implementation.AsPagesAsync(continuationToken, pageSizeHint, default);
        }

        internal class PageableWrapper<T> : Pageable<T> where T : notnull
        {
            private readonly PageableImplementation<T> _implementation;

            public PageableWrapper(PageableImplementation<T> implementation)
            {
                _implementation = implementation;
            }

            public override IEnumerator<T> GetEnumerator() => _implementation.GetEnumerator();
            public override IEnumerable<Page<T>> AsPages(string? continuationToken = null, int? pageSizeHint = null) => _implementation.AsPages(continuationToken, pageSizeHint);
        }

        internal class PageableImplementation<T>
        {
            private readonly Response? _initialResponse;
            private readonly Func<int?, HttpMessage>? _createFirstPageRequest;
            private readonly Func<int?, string, HttpMessage>? _createNextPageRequest;
            private readonly HttpPipeline _pipeline;
            private readonly ClientDiagnostics _clientDiagnostics;
            private readonly Func<JsonElement, T>? _valueFactory;
            private readonly Func<Response, (List<T>? Values, string? NextLink)>? _responseParser;
            private readonly string _scopeName;
            private readonly byte[] _itemPropertyName;
            private readonly byte[] _nextLinkPropertyName;
            private readonly int? _defaultPageSize;
            private readonly CancellationToken _cancellationToken;
            private readonly ErrorOptions? _errorOptions;

            public PageableImplementation(
                Response? initialResponse,
                Func<int?, HttpMessage>? createFirstPageRequest,
                Func<int?, string, HttpMessage>? createNextPageRequest,
                Func<JsonElement, T> valueFactory,
                HttpPipeline pipeline,
                ClientDiagnostics clientDiagnostics,
                string scopeName,
                string? itemPropertyName,
                string? nextLinkPropertyName,
                int? defaultPageSize,
                CancellationToken? cancellationToken,
                ErrorOptions? errorOptions)
            {
                _initialResponse = initialResponse;
                _createFirstPageRequest = createFirstPageRequest;
                _createNextPageRequest = createNextPageRequest;
                _valueFactory = typeof(T) == typeof(BinaryData) ? null : valueFactory;
                _responseParser = null;
                _pipeline = pipeline;
                _clientDiagnostics = clientDiagnostics;
                _scopeName = scopeName;
                _itemPropertyName = itemPropertyName != null ? Encoding.UTF8.GetBytes(itemPropertyName) : DefaultItemPropertyName;
                _nextLinkPropertyName = nextLinkPropertyName != null ? Encoding.UTF8.GetBytes(nextLinkPropertyName) : DefaultNextLinkPropertyName;
                _defaultPageSize = defaultPageSize;
                _cancellationToken = cancellationToken ?? default;
                _errorOptions = errorOptions ?? ErrorOptions.Default;
            }

            public PageableImplementation(Func<int?, HttpMessage>? createFirstPageRequest, Func<int?, string, HttpMessage>? createNextPageRequest, Func<Response, (List<T>? Values, string? NextLink)> responseParser, HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, string scopeName, int? defaultPageSize, RequestContext? requestContext)
            {
                _createFirstPageRequest = createFirstPageRequest;
                _createNextPageRequest = createNextPageRequest;
                _valueFactory = null;
                _responseParser = responseParser;
                _pipeline = pipeline;
                _clientDiagnostics = clientDiagnostics;
                _scopeName = scopeName;
                _itemPropertyName = Array.Empty<byte>();
                _nextLinkPropertyName = Array.Empty<byte>();
                _defaultPageSize = defaultPageSize;
                _cancellationToken = requestContext?.CancellationToken ?? default;
                _errorOptions = requestContext?.ErrorOptions ?? ErrorOptions.Default;
            }

            public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            {
                string? nextLink = null;
                do
                {
                    var response = await GetNextResponseAsync(null, nextLink, cancellationToken).ConfigureAwait(false);
                    if (!TryGetItemsFromResponse(response, out nextLink, out var jsonArray, out var items))
                    {
                        continue;
                    }

                    if (_valueFactory != null)
                    {
                        foreach (var jsonItem in jsonArray)
                        {
                            yield return _valueFactory(jsonItem);
                        }
                    }
                    else
                    {
                        foreach (var item in items!)
                        {
                            yield return item;
                        }
                    }
                } while (!string.IsNullOrEmpty(nextLink));
            }

            public async IAsyncEnumerable<Page<T>> AsPagesAsync(string? continuationToken, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                string? nextLink = continuationToken;
                do
                {
                    var response = await GetNextResponseAsync(pageSizeHint, nextLink, cancellationToken).ConfigureAwait(false);
                    if (response is null)
                    {
                        yield break;
                    }
                    yield return CreatePage(response, out nextLink);
                } while (!string.IsNullOrEmpty(nextLink));
            }

            public IEnumerator<T> GetEnumerator()
            {
                string? nextLink = null;
                do
                {
                    var response = GetNextResponse(null, nextLink);
                    if (!TryGetItemsFromResponse(response, out nextLink, out var jsonArray, out var items))
                    {
                        continue;
                    }

                    if (_valueFactory != null)
                    {
                        foreach (var jsonItem in jsonArray)
                        {
                            yield return _valueFactory(jsonItem);
                        }
                    }
                    else
                    {
                        foreach (var item in items!)
                        {
                            yield return item;
                        }
                    }
                } while (!string.IsNullOrEmpty(nextLink));
            }

            public IEnumerable<Page<T>> AsPages(string? continuationToken, int? pageSizeHint)
            {
                string? nextLink = continuationToken;
                do
                {
                    var response = GetNextResponse(pageSizeHint, nextLink);
                    if (response is null)
                    {
                        yield break;
                    }
                    yield return CreatePage(response, out nextLink);
                } while (!string.IsNullOrEmpty(nextLink));
            }

            private Response? GetNextResponse(int? pageSizeHint, string? nextLink)
            {
                var message = CreateMessage(pageSizeHint, nextLink, out var response);
                if (message == null)
                {
                    return response;
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

            private async ValueTask<Response?> GetNextResponseAsync(int? pageSizeHint, string? nextLink, CancellationToken cancellationToken)
            {
                var message = CreateMessage(pageSizeHint, nextLink, out var response);
                if (message == null)
                {
                    return response;
                }

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

            private HttpMessage? CreateMessage(int? pageSizeHint, string? nextLink, out Response? response)
            {
                if (!string.IsNullOrEmpty(nextLink))
                {
                    response = null;
                    return _createNextPageRequest?.Invoke(pageSizeHint ?? _defaultPageSize, nextLink!);
                }

                if (_createFirstPageRequest == null)
                {
                    response = _initialResponse;
                    return null;
                }

                response = null;
                return _createFirstPageRequest(pageSizeHint ?? _defaultPageSize);
            }

            private Response GetResponse(HttpMessage message)
            {
                if (message.Response.IsError && _errorOptions != ErrorOptions.NoThrow)
                {
                    throw new RequestFailedException(message.Response);
                }

                return message.Response;
            }

            // Tries to parse response either using default logic or by using custom parser
            // Returns true when either jsonArrayEnumerator is not default or items is not null
            private bool TryGetItemsFromResponse(Response? response, out string? nextLink, out JsonElement.ArrayEnumerator jsonArrayEnumerator, out List<T>? items)
            {
                if (response is null)
                {
                    nextLink = default;
                    jsonArrayEnumerator = default;
                    items = default;
                    return false;
                }

                if (_valueFactory is not null)
                {
                    items = default;
                    var document = response.ContentStream != null ? JsonDocument.Parse(response.ContentStream) : JsonDocument.Parse(response.Content);
                    if (_createNextPageRequest is null && _itemPropertyName.Length == 0) // Pageable is a simple collection of elements
                    {
                        nextLink = null;
                        jsonArrayEnumerator = document.RootElement.EnumerateArray();
                        return true;
                    }

                    nextLink = document.RootElement.TryGetProperty(_nextLinkPropertyName, out var nextLinkValue) ? nextLinkValue.GetString() : null;
                    if (document.RootElement.TryGetProperty(_itemPropertyName, out var itemsValue))
                    {
                        jsonArrayEnumerator = itemsValue.EnumerateArray();
                        return true;
                    }

                    jsonArrayEnumerator = default;
                    return false;
                }

                jsonArrayEnumerator = default;
                // _responseParser will be null when T is BinaryData
                var parsedResponse = _responseParser?.Invoke(response) ?? ParseResponseForBinaryData<T>(response, _itemPropertyName, _nextLinkPropertyName);
                items = parsedResponse.Values;
                nextLink = parsedResponse.NextLink;
                return items is not null;
            }

            private Page<T> CreatePage(Response response, out string? nextLink)
            {
                if (!TryGetItemsFromResponse(response, out nextLink, out var jsonArray, out var items))
                {
                    return Page<T>.FromValues(Array.Empty<T>(), nextLink, response);
                }

                if (_valueFactory == null)
                {
                    return Page<T>.FromValues(items!, nextLink, response);
                }

                var values = new List<T>();
                foreach (var jsonItem in jsonArray)
                {
                    values.Add(_valueFactory(jsonItem));
                }

                return Page<T>.FromValues(values, nextLink, response);
            }
        }

        // This method is used to avoid calling _valueFactory for BinaryData cause it requires instantiation of strings.
        // Remove it when `JsonElement` provides access to its UTF8 buffer.
        // See also PageableMethodsWriterExtensions.GetValueFactory
        private static (List<T>? Values, string? NextLink) ParseResponseForBinaryData<T>(Response response, byte[] itemPropertyName, byte[] nextLinkPropertyName)
        {
            var content = response.Content.ToMemory();
            var r = new Utf8JsonReader(content.Span);

            List<T>? items = null;
            string? nextLink = null;

            if (!r.Read() || r.TokenType != JsonTokenType.StartObject)
            {
                throw new InvalidOperationException("Expected response to be JSON object");
            }

            while (r.Read())
            {
                switch (r.TokenType)
                {
                    case JsonTokenType.PropertyName:
                        if (r.ValueTextEquals(nextLinkPropertyName))
                        {
                            r.Read();
                            nextLink = r.GetString();
                        }
                        else if (r.ValueTextEquals(itemPropertyName))
                        {
                            if (!r.Read() || r.TokenType != JsonTokenType.StartArray)
                            {
                                throw new InvalidOperationException($"Expected {Encoding.UTF8.GetString(itemPropertyName)} to be an array");
                            }

                            while (r.Read() && r.TokenType != JsonTokenType.EndArray)
                            {
                                var element = ReadBinaryData(ref r, content);
                                items ??= new List<T>();
                                items.Add((T)element);
                            }
                        }
                        else
                        {
                            r.Skip();
                        }
                        break;
                    case JsonTokenType.EndObject:
                        break;

                    default:
                        throw new Exception("Unexpected token");
                }
            }

            return (items, nextLink);

            static object ReadBinaryData(ref Utf8JsonReader r, in ReadOnlyMemory<byte> content)
            {
                switch (r.TokenType)
                {
                    case JsonTokenType.StartObject or JsonTokenType.StartArray:
                        int elementStart = (int)r.TokenStartIndex;
                        r.Skip();
                        int elementEnd = (int)r.TokenStartIndex;
                        int length = elementEnd - elementStart + 1;
                        return new BinaryData(content.Slice(elementStart, length));
                    case JsonTokenType.String:
                        return new BinaryData(content.Slice((int)r.TokenStartIndex, r.ValueSpan.Length + 2 /* open and closing quotes are not captured in the value span */));
                    default:
                        return new BinaryData(content.Slice((int)r.TokenStartIndex, r.ValueSpan.Length));
                }
            }
        }
    }
}
