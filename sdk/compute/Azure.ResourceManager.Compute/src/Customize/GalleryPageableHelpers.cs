// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Compute
{
    internal static class GalleryPageableHelpers
    {
        public static AsyncPageable<T> CreateAsyncPageable<T>(
            Func<int?, HttpMessage> firstPageRequest,
            Func<int?, string, HttpMessage> nextPageRequest,
            Func<JsonElement, T> valueFactory,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            string scopeName,
            string itemPropertyName,
            string nextLinkPropertyName,
            CancellationToken cancellationToken) where T : notnull
        {
            async Task<Page<T>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = clientDiagnostics.CreateScope(scopeName);
                scope.Start();
                try
                {
                    HttpMessage message = firstPageRequest(pageSizeHint);
                    Response result = await pipeline.ProcessMessageAsync(message, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                    return ParseResponse(result, valueFactory, itemPropertyName, nextLinkPropertyName);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<T>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = clientDiagnostics.CreateScope(scopeName);
                scope.Start();
                try
                {
                    HttpMessage message = nextPageRequest(pageSizeHint, nextLink);
                    Response result = await pipeline.ProcessMessageAsync(message, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                    return ParseResponse(result, valueFactory, itemPropertyName, nextLinkPropertyName);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return new GalleryAsyncPageable<T>(FirstPageFunc, NextPageFunc);
        }

        public static Pageable<T> CreatePageable<T>(
            Func<int?, HttpMessage> firstPageRequest,
            Func<int?, string, HttpMessage> nextPageRequest,
            Func<JsonElement, T> valueFactory,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            string scopeName,
            string itemPropertyName,
            string nextLinkPropertyName,
            CancellationToken cancellationToken) where T : notnull
        {
            Page<T> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = clientDiagnostics.CreateScope(scopeName);
                scope.Start();
                try
                {
                    HttpMessage message = firstPageRequest(pageSizeHint);
                    Response result = pipeline.ProcessMessage(message, new RequestContext { CancellationToken = cancellationToken });
                    return ParseResponse(result, valueFactory, itemPropertyName, nextLinkPropertyName);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<T> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = clientDiagnostics.CreateScope(scopeName);
                scope.Start();
                try
                {
                    HttpMessage message = nextPageRequest(pageSizeHint, nextLink);
                    Response result = pipeline.ProcessMessage(message, new RequestContext { CancellationToken = cancellationToken });
                    return ParseResponse(result, valueFactory, itemPropertyName, nextLinkPropertyName);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return new GalleryPageable<T>(FirstPageFunc, NextPageFunc);
        }

        private static Page<T> ParseResponse<T>(Response response, Func<JsonElement, T> valueFactory, string itemPropertyName, string nextLinkPropertyName)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content);
            JsonElement root = document.RootElement;

            var items = new List<T>();
            if (root.TryGetProperty(itemPropertyName, out JsonElement itemsElement))
            {
                foreach (JsonElement item in itemsElement.EnumerateArray())
                {
                    items.Add(valueFactory(item));
                }
            }

            string nextLink = null;
            if (root.TryGetProperty(nextLinkPropertyName, out JsonElement nextLinkElement) && nextLinkElement.ValueKind != JsonValueKind.Null)
            {
                nextLink = nextLinkElement.GetString();
            }

            return Page<T>.FromValues(items, nextLink, response);
        }

        private sealed class GalleryAsyncPageable<T> : AsyncPageable<T> where T : notnull
        {
            private readonly Func<int?, Task<Page<T>>> _firstPageFunc;
            private readonly Func<string, int?, Task<Page<T>>> _nextPageFunc;

            public GalleryAsyncPageable(Func<int?, Task<Page<T>>> firstPageFunc, Func<string, int?, Task<Page<T>>> nextPageFunc)
            {
                _firstPageFunc = firstPageFunc;
                _nextPageFunc = nextPageFunc;
            }

            public override async IAsyncEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                Page<T> page = continuationToken == null
                    ? await _firstPageFunc(pageSizeHint).ConfigureAwait(false)
                    : await _nextPageFunc(continuationToken, pageSizeHint).ConfigureAwait(false);
                yield return page;

                while (page.ContinuationToken != null)
                {
                    page = await _nextPageFunc(page.ContinuationToken, pageSizeHint).ConfigureAwait(false);
                    yield return page;
                }
            }
        }

        private sealed class GalleryPageable<T> : Pageable<T> where T : notnull
        {
            private readonly Func<int?, Page<T>> _firstPageFunc;
            private readonly Func<string, int?, Page<T>> _nextPageFunc;

            public GalleryPageable(Func<int?, Page<T>> firstPageFunc, Func<string, int?, Page<T>> nextPageFunc)
            {
                _firstPageFunc = firstPageFunc;
                _nextPageFunc = nextPageFunc;
            }

            public override IEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                Page<T> page = continuationToken == null
                    ? _firstPageFunc(pageSizeHint)
                    : _nextPageFunc(continuationToken, pageSizeHint);
                yield return page;

                while (page.ContinuationToken != null)
                {
                    page = _nextPageFunc(page.ContinuationToken, pageSizeHint);
                    yield return page;
                }
            }
        }
    }
}