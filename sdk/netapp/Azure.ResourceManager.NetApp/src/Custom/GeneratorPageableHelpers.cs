// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    internal static class GeneratorPageableHelpers
    {
        public static AsyncPageable<T> CreateAsyncPageable<T>(
            Func<int?, HttpMessage> firstPageRequest,
            Func<string, int?, HttpMessage> nextPageRequest,
            Func<JsonElement, T> valueFactory,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            string scopeName,
            string itemName,
            string nextLinkName,
            CancellationToken cancellationToken)
            => new JsonAsyncPageable<T>(firstPageRequest, nextPageRequest, valueFactory, clientDiagnostics, pipeline, scopeName, itemName, nextLinkName, cancellationToken);

        public static Pageable<T> CreatePageable<T>(
            Func<int?, HttpMessage> firstPageRequest,
            Func<string, int?, HttpMessage> nextPageRequest,
            Func<JsonElement, T> valueFactory,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            string scopeName,
            string itemName,
            string nextLinkName,
            CancellationToken cancellationToken)
            => new JsonPageable<T>(firstPageRequest, nextPageRequest, valueFactory, clientDiagnostics, pipeline, scopeName, itemName, nextLinkName, cancellationToken);

        private sealed class JsonAsyncPageable<T> : AsyncPageable<T>
        {
            private readonly Func<int?, HttpMessage> _firstPageRequest;
            private readonly Func<string, int?, HttpMessage> _nextPageRequest;
            private readonly Func<JsonElement, T> _valueFactory;
            private readonly ClientDiagnostics _clientDiagnostics;
            private readonly HttpPipeline _pipeline;
            private readonly string _scopeName;
            private readonly string _itemName;
            private readonly string _nextLinkName;
            private readonly CancellationToken _cancellationToken;

            public JsonAsyncPageable(Func<int?, HttpMessage> firstPageRequest, Func<string, int?, HttpMessage> nextPageRequest, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string itemName, string nextLinkName, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _firstPageRequest = firstPageRequest;
                _nextPageRequest = nextPageRequest;
                _valueFactory = valueFactory;
                _clientDiagnostics = clientDiagnostics;
                _pipeline = pipeline;
                _scopeName = scopeName;
                _itemName = itemName;
                _nextLinkName = nextLinkName;
                _cancellationToken = cancellationToken;
            }

            public override async IAsyncEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                string nextLink = continuationToken;
                do
                {
                    HttpMessage message = nextLink != null && _nextPageRequest != null
                        ? _nextPageRequest(nextLink, pageSizeHint)
                        : _firstPageRequest(pageSizeHint);
                    Response response;
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
                    scope.Start();
                    try
                    {
                        response = await _pipeline.ProcessMessageAsync(message, new RequestContext { CancellationToken = _cancellationToken }).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }

                    yield return CreatePage(response, _valueFactory, _itemName, _nextLinkName, out nextLink);
                } while (nextLink != null);
            }
        }

        private sealed class JsonPageable<T> : Pageable<T>
        {
            private readonly Func<int?, HttpMessage> _firstPageRequest;
            private readonly Func<string, int?, HttpMessage> _nextPageRequest;
            private readonly Func<JsonElement, T> _valueFactory;
            private readonly ClientDiagnostics _clientDiagnostics;
            private readonly HttpPipeline _pipeline;
            private readonly string _scopeName;
            private readonly string _itemName;
            private readonly string _nextLinkName;
            private readonly CancellationToken _cancellationToken;

            public JsonPageable(Func<int?, HttpMessage> firstPageRequest, Func<string, int?, HttpMessage> nextPageRequest, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string itemName, string nextLinkName, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _firstPageRequest = firstPageRequest;
                _nextPageRequest = nextPageRequest;
                _valueFactory = valueFactory;
                _clientDiagnostics = clientDiagnostics;
                _pipeline = pipeline;
                _scopeName = scopeName;
                _itemName = itemName;
                _nextLinkName = nextLinkName;
                _cancellationToken = cancellationToken;
            }

            public override IEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                string nextLink = continuationToken;
                do
                {
                    HttpMessage message = nextLink != null && _nextPageRequest != null
                        ? _nextPageRequest(nextLink, pageSizeHint)
                        : _firstPageRequest(pageSizeHint);
                    Response response;
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope(_scopeName);
                    scope.Start();
                    try
                    {
                        response = _pipeline.ProcessMessage(message, new RequestContext { CancellationToken = _cancellationToken });
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }

                    yield return CreatePage(response, _valueFactory, _itemName, _nextLinkName, out nextLink);
                } while (nextLink != null);
            }
        }

        private static Page<T> CreatePage<T>(Response response, Func<JsonElement, T> valueFactory, string itemName, string nextLinkName, out string nextLink)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            JsonElement root = document.RootElement;
            List<T> values = new List<T>();
            if (root.TryGetProperty(itemName, out JsonElement items) && items.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement item in items.EnumerateArray())
                {
                    values.Add(valueFactory(item));
                }
            }

            nextLink = null;
            if (nextLinkName != null &&
                root.TryGetProperty(nextLinkName, out JsonElement nextLinkElement) &&
                nextLinkElement.ValueKind == JsonValueKind.String)
            {
                nextLink = nextLinkElement.GetString();
            }

            return Page<T>.FromValues(values, nextLink, response);
        }
    }
}
