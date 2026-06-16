// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth
{
    internal partial class GetHealthEventsOfSingleResourceAsyncCollectionResult : AsyncPageable<ResourceHealthEventData>
    {
        private readonly Events _client;
        private readonly string _resourceUri;
        private readonly string _filter;
        private readonly RequestContext _context;

        public GetHealthEventsOfSingleResourceAsyncCollectionResult(Events client, string resourceUri, string filter, RequestContext context)
            : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _resourceUri = resourceUri;
            _filter = filter;
            _context = context;
        }

        public override async IAsyncEnumerable<Page<ResourceHealthEventData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken, UriKind.RelativeOrAbsolute) : null;
            while (true)
            {
                Response response = await GetNextResponseAsync(nextPage).ConfigureAwait(false);
                if (response is null)
                {
                    yield break;
                }

                ResourceHealthEventListResult result = ResourceHealthEventListResult.FromResponse(response);
                yield return Page<ResourceHealthEventData>.FromValues((IReadOnlyList<ResourceHealthEventData>)result.Value, result.NextLink?.OriginalString, response);
                nextPage = result.NextLink;
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }

        private async ValueTask<Response> GetNextResponseAsync(Uri nextPage)
        {
            HttpMessage message = nextPage != null ? _client.CreateNextGetHealthEventsOfSingleResourceRequest(nextPage, _resourceUri, _filter, _context) : _client.CreateGetHealthEventsOfSingleResourceRequest(_resourceUri, _filter, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("MockableResourceHealthArmClient.GetHealthEventsOfSingleResource");
            scope.Start();
            try
            {
                return await _client.Pipeline.ProcessMessageAsync(message, _context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
