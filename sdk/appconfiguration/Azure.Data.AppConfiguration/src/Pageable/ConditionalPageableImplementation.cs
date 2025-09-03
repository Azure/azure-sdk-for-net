// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    internal class ConditionalPageableImplementation<T>
    {
        private readonly Func<MatchConditions, int?, HttpMessage> _createFirstPageRequest;
        private readonly Func<MatchConditions, int?, string, HttpMessage> _createNextPageRequest;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Func<Response, (List<T> Values, string NextLink)> _responseParser;
        private readonly string _scopeName;
        private readonly CancellationToken _cancellationToken;
        private readonly ErrorOptions _errorOptions;

        public ConditionalPageableImplementation(Func<MatchConditions, int?, HttpMessage> createFirstPageRequest, Func<MatchConditions, int?, string, HttpMessage> createNextPageRequest, Func<Response, (List<T> Values, string NextLink)> responseParser, HttpPipeline pipeline, ClientDiagnostics clientDiagnostics, string scopeName, RequestContext requestContext)
        {
            _createFirstPageRequest = createFirstPageRequest;
            _createNextPageRequest = createNextPageRequest;
            _responseParser = responseParser;
            _pipeline = pipeline;
            _clientDiagnostics = clientDiagnostics;
            _scopeName = scopeName;
            _cancellationToken = requestContext?.CancellationToken ?? default;
            _errorOptions = requestContext?.ErrorOptions ?? ErrorOptions.Default;
        }

        public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            string nextLink = null;
            do
            {
                var response = await GetNextResponseAsync(null, null, nextLink, cancellationToken).ConfigureAwait(false);
                if (!TryGetItemsFromResponse(response, out nextLink, out var items))
                {
                    continue;
                }

                foreach (var item in items)
                {
                    yield return item;
                }
            } while (!string.IsNullOrEmpty(nextLink));
        }

        public async IAsyncEnumerable<Page<T>> AsPagesAsync(IEnumerable<MatchConditions> conditionsEnumerable, string continuationToken, int? pageSizeHint, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var enumerator = conditionsEnumerable.GetEnumerator();
            string nextLink = continuationToken;
            do
            {
                var conditions = enumerator.MoveNext() ? enumerator.Current : null;
                var response = await GetNextResponseAsync(conditions, pageSizeHint, nextLink, cancellationToken).ConfigureAwait(false);
                if (response is null)
                {
                    yield break;
                }
                yield return CreatePage(response, out nextLink);
            } while (!string.IsNullOrEmpty(nextLink));
        }

        public IEnumerator<T> GetEnumerator()
        {
            string nextLink = null;
            do
            {
                var response = GetNextResponse(conditions: null, pageSizeHint: null, nextLink);
                if (!TryGetItemsFromResponse(response, out nextLink, out var items))
                {
                    continue;
                }

                foreach (var item in items)
                {
                    yield return item;
                }
            } while (!string.IsNullOrEmpty(nextLink));
        }

        public IEnumerable<Page<T>> AsPages(IEnumerable<MatchConditions> conditionsEnumerable, string continuationToken, int? pageSizeHint)
        {
            var enumerator = conditionsEnumerable.GetEnumerator();
            string nextLink = continuationToken;
            do
            {
                var conditions = enumerator.MoveNext() ? enumerator.Current : null;
                var response = GetNextResponse(conditions, pageSizeHint, nextLink);
                if (response is null)
                {
                    yield break;
                }
                yield return CreatePage(response, out nextLink);
            } while (!string.IsNullOrEmpty(nextLink));
        }

        private Response GetNextResponse(MatchConditions conditions, int? pageSizeHint, string nextLink)
        {
            var message = CreateMessage(conditions, pageSizeHint, nextLink);
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

        private async ValueTask<Response> GetNextResponseAsync(MatchConditions conditions, int? pageSizeHint, string nextLink, CancellationToken cancellationToken)
        {
            var message = CreateMessage(conditions, pageSizeHint, nextLink);

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

        private HttpMessage CreateMessage(MatchConditions conditions, int? pageSizeHint, string nextLink) =>
            string.IsNullOrEmpty(nextLink)
                ? _createFirstPageRequest(conditions, pageSizeHint)
                : _createNextPageRequest(conditions, pageSizeHint, nextLink);

        private Response GetResponse(HttpMessage message)
        {
            if (message.Response.IsError && !_errorOptions.HasFlag(ErrorOptions.NoThrow))
            {
                throw new RequestFailedException(message.Response);
            }

            return message.Response;
        }

        private bool TryGetItemsFromResponse(Response response, out string nextLink, out List<T> items)
        {
            if (response is null)
            {
                nextLink = default;
                items = default;
                return false;
            }
            else
            {
                var parsedResponse = _responseParser(response);
                items = parsedResponse.Values;
                nextLink = parsedResponse.NextLink;
                return items is not null;
            }
        }

        private Page<T> CreatePage(Response response, out string nextLink) =>
            TryGetItemsFromResponse(response, out nextLink, out var items)
                ? Page<T>.FromValues(items, nextLink, response)
                : Page<T>.FromValues(Array.Empty<T>(), nextLink, response);
    }
}
