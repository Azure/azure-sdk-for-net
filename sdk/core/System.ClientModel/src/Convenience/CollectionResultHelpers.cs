// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel;

/// <summary>
/// Provides factory methods for creating <see cref="CollectionResult{T}"/> and
/// <see cref="AsyncCollectionResult{T}"/> instances with built-in distributed
/// tracing support for per-page HTTP calls.
/// </summary>
/// <remarks>
/// This is the System.ClientModel equivalent of Azure.Core's PageableHelpers.
/// Each page fetch is wrapped in a <see cref="DiagnosticScope"/> for tracing.
/// </remarks>
internal static class CollectionResultHelpers
{
    /// <summary>
    /// Creates a <see cref="CollectionResult{T}"/> that fetches pages synchronously
    /// with distributed tracing for each page request.
    /// </summary>
    /// <typeparam name="T">The type of values in the collection.</typeparam>
    /// <param name="createFirstPageRequest">A delegate that creates the <see cref="PipelineMessage"/> for the first page request.</param>
    /// <param name="createNextPageRequest">A delegate that creates the <see cref="PipelineMessage"/> for subsequent page requests given a next link. Null if the result is a single page.</param>
    /// <param name="getValues">A delegate that extracts values from a page response.</param>
    /// <param name="getNextLink">A delegate that extracts the next link from a page response, or returns null if there are no more pages.</param>
    /// <param name="pipeline">The <see cref="ClientPipeline"/> used to send requests.</param>
    /// <param name="diagnostics">The <see cref="DiagnosticScopeFactory"/> used for tracing.</param>
    /// <param name="scopeName">The name of the diagnostic scope (e.g. "MyClient.ListItems").</param>
    /// <param name="requestOptions">Optional <see cref="RequestOptions"/> to apply to each request.</param>
    /// <returns>A <see cref="CollectionResult{T}"/> that fetches pages with tracing.</returns>
    public static CollectionResult<T> CreateCollectionResult<T>(
        Func<PipelineMessage> createFirstPageRequest,
        Func<string, PipelineMessage>? createNextPageRequest,
        Func<ClientResult, IReadOnlyList<T>> getValues,
        Func<ClientResult, string?> getNextLink,
        ClientPipeline pipeline,
        DiagnosticScopeFactory diagnostics,
        string scopeName,
        RequestOptions? requestOptions = null)
    {
        return new PageableCollectionResult<T>(
            createFirstPageRequest,
            createNextPageRequest,
            getValues,
            getNextLink,
            pipeline,
            diagnostics,
            scopeName,
            requestOptions);
    }

    /// <summary>
    /// Creates an <see cref="AsyncCollectionResult{T}"/> that fetches pages asynchronously
    /// with distributed tracing for each page request.
    /// </summary>
    /// <typeparam name="T">The type of values in the collection.</typeparam>
    /// <param name="createFirstPageRequest">A delegate that creates the <see cref="PipelineMessage"/> for the first page request.</param>
    /// <param name="createNextPageRequest">A delegate that creates the <see cref="PipelineMessage"/> for subsequent page requests given a next link. Null if the result is a single page.</param>
    /// <param name="getValues">A delegate that extracts values from a page response.</param>
    /// <param name="getNextLink">A delegate that extracts the next link from a page response, or returns null if there are no more pages.</param>
    /// <param name="pipeline">The <see cref="ClientPipeline"/> used to send requests.</param>
    /// <param name="diagnostics">The <see cref="DiagnosticScopeFactory"/> used for tracing.</param>
    /// <param name="scopeName">The name of the diagnostic scope (e.g. "MyClient.ListItems").</param>
    /// <param name="requestOptions">Optional <see cref="RequestOptions"/> to apply to each request.</param>
    /// <returns>An <see cref="AsyncCollectionResult{T}"/> that fetches pages with tracing.</returns>
    public static AsyncCollectionResult<T> CreateAsyncCollectionResult<T>(
        Func<PipelineMessage> createFirstPageRequest,
        Func<string, PipelineMessage>? createNextPageRequest,
        Func<ClientResult, IReadOnlyList<T>> getValues,
        Func<ClientResult, string?> getNextLink,
        ClientPipeline pipeline,
        DiagnosticScopeFactory diagnostics,
        string scopeName,
        RequestOptions? requestOptions = null)
    {
        return new AsyncPageableCollectionResult<T>(
            createFirstPageRequest,
            createNextPageRequest,
            getValues,
            getNextLink,
            pipeline,
            diagnostics,
            scopeName,
            requestOptions);
    }

    private sealed class PageableCollectionResult<T> : CollectionResult<T>
    {
        private readonly Func<PipelineMessage> _createFirstPageRequest;
        private readonly Func<string, PipelineMessage>? _createNextPageRequest;
        private readonly Func<ClientResult, IReadOnlyList<T>> _getValues;
        private readonly Func<ClientResult, string?> _getNextLink;
        private readonly ClientPipeline _pipeline;
        private readonly DiagnosticScopeFactory _diagnostics;
        private readonly string _scopeName;
        private readonly RequestOptions? _requestOptions;

        public PageableCollectionResult(
            Func<PipelineMessage> createFirstPageRequest,
            Func<string, PipelineMessage>? createNextPageRequest,
            Func<ClientResult, IReadOnlyList<T>> getValues,
            Func<ClientResult, string?> getNextLink,
            ClientPipeline pipeline,
            DiagnosticScopeFactory diagnostics,
            string scopeName,
            RequestOptions? requestOptions)
        {
            _createFirstPageRequest = createFirstPageRequest;
            _createNextPageRequest = createNextPageRequest;
            _getValues = getValues;
            _getNextLink = getNextLink;
            _pipeline = pipeline;
            _diagnostics = diagnostics;
            _scopeName = scopeName;
            _requestOptions = requestOptions;
        }

        public override IEnumerable<ClientResult> GetRawPages()
        {
            ClientResult page = SendRequest(_createFirstPageRequest());
            yield return page;

            string? nextLink = _getNextLink(page);
            while (nextLink != null && _createNextPageRequest != null)
            {
                page = SendRequest(_createNextPageRequest(nextLink));
                yield return page;
                nextLink = _getNextLink(page);
            }
        }

        public override ContinuationToken? GetContinuationToken(ClientResult page)
        {
            string? nextLink = _getNextLink(page);
            if (nextLink != null)
            {
                return ContinuationToken.FromBytes(BinaryData.FromString(nextLink));
            }

            return null;
        }

        protected override IEnumerable<T> GetValuesFromPage(ClientResult page) => _getValues(page);

        private ClientResult SendRequest(PipelineMessage message)
        {
            _requestOptions?.Apply(message);
            using DiagnosticScope scope = _diagnostics.CreateScope(_scopeName);
            scope.Start();
            try
            {
                _pipeline.Send(message);

                if (message.Response!.IsError)
                {
                    throw new ClientResultException(message.Response);
                }

                return ClientResult.FromResponse(message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }

    private sealed class AsyncPageableCollectionResult<T> : AsyncCollectionResult<T>
    {
        private readonly Func<PipelineMessage> _createFirstPageRequest;
        private readonly Func<string, PipelineMessage>? _createNextPageRequest;
        private readonly Func<ClientResult, IReadOnlyList<T>> _getValues;
        private readonly Func<ClientResult, string?> _getNextLink;
        private readonly ClientPipeline _pipeline;
        private readonly DiagnosticScopeFactory _diagnostics;
        private readonly string _scopeName;
        private readonly RequestOptions? _requestOptions;

        public AsyncPageableCollectionResult(
            Func<PipelineMessage> createFirstPageRequest,
            Func<string, PipelineMessage>? createNextPageRequest,
            Func<ClientResult, IReadOnlyList<T>> getValues,
            Func<ClientResult, string?> getNextLink,
            ClientPipeline pipeline,
            DiagnosticScopeFactory diagnostics,
            string scopeName,
            RequestOptions? requestOptions)
        {
            _createFirstPageRequest = createFirstPageRequest;
            _createNextPageRequest = createNextPageRequest;
            _getValues = getValues;
            _getNextLink = getNextLink;
            _pipeline = pipeline;
            _diagnostics = diagnostics;
            _scopeName = scopeName;
            _requestOptions = requestOptions;
        }

        public override async IAsyncEnumerable<ClientResult> GetRawPagesAsync()
        {
            ClientResult page = await SendRequestAsync(_createFirstPageRequest()).ConfigureAwait(false);
            yield return page;

            string? nextLink = _getNextLink(page);
            while (nextLink != null && _createNextPageRequest != null)
            {
                page = await SendRequestAsync(_createNextPageRequest(nextLink)).ConfigureAwait(false);
                yield return page;
                nextLink = _getNextLink(page);
            }
        }

        public override ContinuationToken? GetContinuationToken(ClientResult page)
        {
            string? nextLink = _getNextLink(page);
            if (nextLink != null)
            {
                return ContinuationToken.FromBytes(BinaryData.FromString(nextLink));
            }

            return null;
        }

        protected override async IAsyncEnumerable<T> GetValuesFromPageAsync(ClientResult page)
        {
            foreach (T value in _getValues(page))
            {
                yield return value;
            }

            await Task.CompletedTask.ConfigureAwait(false);
        }

        private async Task<ClientResult> SendRequestAsync(PipelineMessage message)
        {
            _requestOptions?.Apply(message);
            using DiagnosticScope scope = _diagnostics.CreateScope(_scopeName);
            scope.Start();
            try
            {
                await _pipeline.SendAsync(message).ConfigureAwait(false);

                if (message.Response!.IsError)
                {
                    throw new ClientResultException(message.Response);
                }

                return ClientResult.FromResponse(message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
