// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Autorest.CSharp.Core
{
    /// <summary>
    /// Compatibility shim for GeneratorPageableHelpers, providing the paging helpers
    /// previously available from the Autorest.CSharp.Core package. Used by the
    /// single-server PostgreSQL code that was preserved as custom code.
    /// </summary>
    internal static class GeneratorPageableHelpers
    {
        /// <summary> Creates an async pageable from page request functions. </summary>
        public static AsyncPageable<T> CreateAsyncPageable<T>(
            Func<int?, HttpMessage> createFirstPageRequest,
            Func<int?, string, HttpMessage> createNextPageRequest,
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
                    HttpMessage message = createFirstPageRequest(pageSizeHint);
                    await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                    return ParseResponse(message.Response, valueFactory, itemPropertyName, nextLinkPropertyName);
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
                    HttpMessage message = createNextPageRequest(pageSizeHint, nextLink);
                    await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                    return ParseResponse(message.Response, valueFactory, itemPropertyName, nextLinkPropertyName);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(
                FirstPageFunc,
                createNextPageRequest != null ? NextPageFunc : null);
        }

        /// <summary> Creates a sync pageable from page request functions. </summary>
        public static Pageable<T> CreatePageable<T>(
            Func<int?, HttpMessage> createFirstPageRequest,
            Func<int?, string, HttpMessage> createNextPageRequest,
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
                    HttpMessage message = createFirstPageRequest(pageSizeHint);
                    pipeline.Send(message, cancellationToken);
                    return ParseResponse(message.Response, valueFactory, itemPropertyName, nextLinkPropertyName);
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
                    HttpMessage message = createNextPageRequest(pageSizeHint, nextLink);
                    pipeline.Send(message, cancellationToken);
                    return ParseResponse(message.Response, valueFactory, itemPropertyName, nextLinkPropertyName);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(
                FirstPageFunc,
                createNextPageRequest != null ? NextPageFunc : null);
        }

        private static Page<T> ParseResponse<T>(
            Response response,
            Func<JsonElement, T> valueFactory,
            string itemPropertyName,
            string nextLinkPropertyName) where T : notnull
        {
            switch (response.Status)
            {
                case >= 200 and < 300:
                    break;
                default:
                    throw new RequestFailedException(response);
            }

            using JsonDocument document = JsonDocument.Parse(response.Content);
            var items = new List<T>();

            if (document.RootElement.TryGetProperty(itemPropertyName, out JsonElement itemsElement))
            {
                foreach (JsonElement item in itemsElement.EnumerateArray())
                {
                    items.Add(valueFactory(item));
                }
            }

            string nextLink = null;
            if (nextLinkPropertyName != null &&
                document.RootElement.TryGetProperty(nextLinkPropertyName, out JsonElement nextLinkElement) &&
                nextLinkElement.ValueKind != JsonValueKind.Null)
            {
                nextLink = nextLinkElement.GetString();
            }

            return Page<T>.FromValues(items, nextLink, response);
        }
    }
}
