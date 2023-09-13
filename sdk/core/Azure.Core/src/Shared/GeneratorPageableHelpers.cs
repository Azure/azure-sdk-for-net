// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Autorest.CSharp.Core
{
    internal static class GeneratorPageableHelpers
    {
        private static readonly byte[] DefaultItemPropertyName = Encoding.UTF8.GetBytes("value");
        private static readonly byte[] DefaultNextLinkPropertyName = Encoding.UTF8.GetBytes("nextLink");

        public static AsyncPageable<T> CreateAsyncPageable<T>(
            Func<int?, HttpMessage>? createFirstPageRequest,
            Func<int?, string, HttpMessage>? createNextPageRequest,
            Func<Response, (List<T>? Values, string? NextLink)> responseParser,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            string scopeName,
            RequestContext? requestContext = null) where T : notnull
        {
            return new PageableHelpers.AsyncPageableWrapper<T>(new PageableHelpers.PageableImplementation<T>(createFirstPageRequest, createNextPageRequest, responseParser, pipeline, clientDiagnostics, scopeName, null, requestContext));
        }

        public static AsyncPageable<T> CreateAsyncPageable<T>(
            Func<int?, HttpMessage>? createFirstPageRequest,
            Func<int?, string, HttpMessage>? createNextPageRequest,
            Func<JsonElement, T> valueFactory,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            string scopeName,
            string? itemPropertyName,
            string? nextLinkPropertyName,
            CancellationToken cancellationToken) where T : notnull
        {
            return new PageableHelpers.AsyncPageableWrapper<T>(new PageableHelpers.PageableImplementation<T>(null, createFirstPageRequest, createNextPageRequest, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, cancellationToken, null));
        }

        public static AsyncPageable<T> CreateAsyncPageable<T>(
            Func<int?, HttpMessage>? createFirstPageRequest,
            Func<int?, string, HttpMessage>? createNextPageRequest,
            Func<JsonElement, T> valueFactory,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            string scopeName,
            string? itemPropertyName,
            string? nextLinkPropertyName,
            RequestContext? requestContext = null) where T : notnull
        {
            return new PageableHelpers.AsyncPageableWrapper<T>(new PageableHelpers.PageableImplementation<T>(null, createFirstPageRequest, createNextPageRequest, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, requestContext?.CancellationToken, requestContext?.ErrorOptions));
        }

        public static AsyncPageable<T> CreateAsyncPageable<T>(
            Response initialResponse,
            Func<int?, string, HttpMessage>? createNextPageRequest,
            Func<JsonElement, T> valueFactory,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            string scopeName,
            string? itemPropertyName,
            string? nextLinkPropertyName,
            CancellationToken cancellationToken) where T : notnull
        {
            return new PageableHelpers.AsyncPageableWrapper<T>(new PageableHelpers.PageableImplementation<T>(initialResponse, null, createNextPageRequest, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, cancellationToken, null));
        }

        public static Pageable<T> CreatePageable<T>(
            Func<int?, HttpMessage>? createFirstPageRequest,
            Func<int?, string, HttpMessage>? createNextPageRequest,
            Func<Response, (List<T>? Values, string? NextLink)> responseParser,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            string scopeName,
            RequestContext? requestContext = null) where T : notnull
        {
            return new PageableHelpers.PageableWrapper<T>(new PageableHelpers.PageableImplementation<T>(createFirstPageRequest, createNextPageRequest, responseParser, pipeline, clientDiagnostics, scopeName, null, requestContext));
        }

        public static Pageable<T> CreatePageable<T>(
            Func<int?, HttpMessage>? createFirstPageRequest,
            Func<int?, string, HttpMessage>? createNextPageRequest,
            Func<JsonElement, T> valueFactory,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            string scopeName,
            string? itemPropertyName,
            string? nextLinkPropertyName,
            CancellationToken cancellationToken) where T : notnull
        {
            return new PageableHelpers.PageableWrapper<T>(new PageableHelpers.PageableImplementation<T>(null, createFirstPageRequest, createNextPageRequest, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, cancellationToken, null));
        }

        public static Pageable<T> CreatePageable<T>(
            Func<int?, HttpMessage>? createFirstPageRequest,
            Func<int?, string, HttpMessage>? createNextPageRequest,
            Func<JsonElement, T> valueFactory,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            string scopeName,
            string? itemPropertyName,
            string? nextLinkPropertyName,
            RequestContext? requestContext = null) where T : notnull
        {
            return new PageableHelpers.PageableWrapper<T>(new PageableHelpers.PageableImplementation<T>(null, createFirstPageRequest, createNextPageRequest, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, requestContext?.CancellationToken, requestContext?.ErrorOptions));
        }

        public static Pageable<T> CreatePageable<T>(
            Response initialResponse,
            Func<int?, string, HttpMessage>? createNextPageRequest,
            Func<JsonElement, T> valueFactory,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            string scopeName,
            string? itemPropertyName,
            string? nextLinkPropertyName,
            CancellationToken cancellationToken) where T : notnull
        {
            return new PageableHelpers.PageableWrapper<T>(new PageableHelpers.PageableImplementation<T>(initialResponse, null, createNextPageRequest, valueFactory, pipeline, clientDiagnostics, scopeName, itemPropertyName, nextLinkPropertyName, null, cancellationToken, null));
        }

        public static async ValueTask<Operation<AsyncPageable<T>>> CreateAsyncPageable<T>(
            WaitUntil waitUntil,
            HttpMessage message,
            Func<int?, string, HttpMessage>? createNextPageMethod,
            Func<JsonElement, T> valueFactory,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            OperationFinalStateVia finalStateVia,
            string scopeName,
            string? itemPropertyName,
            string? nextLinkPropertyName,
            RequestContext? requestContext = null) where T : notnull
            => await PageableHelpers.CreateAsyncPageable(waitUntil, message, createNextPageMethod, valueFactory, clientDiagnostics, pipeline, finalStateVia, scopeName, itemPropertyName, nextLinkPropertyName, requestContext).ConfigureAwait(false);

        public static Operation<Pageable<T>> CreatePageable<T>(
            WaitUntil waitUntil,
            HttpMessage message,
            Func<int?, string, HttpMessage>? createNextPageMethod,
            Func<JsonElement, T> valueFactory,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            OperationFinalStateVia finalStateVia,
            string scopeName,
            string? itemPropertyName,
            string? nextLinkPropertyName,
            RequestContext? requestContext = null) where T : notnull
            => PageableHelpers.CreatePageable(waitUntil, message, createNextPageMethod, valueFactory, clientDiagnostics, pipeline, finalStateVia, scopeName, itemPropertyName, nextLinkPropertyName, requestContext);

        public static Pageable<T> CreateEnumerable<T>(
            Func<int?, Page<T>> firstPageFunc,
            Func<string?, int?, Page<T>>? nextPageFunc,
            int? pageSize = default) where T : notnull
            => PageableHelpers.CreateEnumerable<T>(firstPageFunc, nextPageFunc, pageSize);

        public static AsyncPageable<T> CreateAsyncEnumerable<T>(
            Func<int?, Task<Page<T>>> firstPageFunc,
            Func<string?, int?, Task<Page<T>>>? nextPageFunc,
            int? pageSize = default) where T : notnull
            => PageableHelpers.CreateAsyncEnumerable<T>(firstPageFunc, nextPageFunc, pageSize);
    }
}
