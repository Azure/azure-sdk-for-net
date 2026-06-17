// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth
{
    internal partial class GetHistoricalAvailabilityStatusesOfChildResourceCollectionResult : Pageable<ResourceHealthAvailabilityStatus>
    {
        private readonly ChildAvailabilityStatuses _client;
        private readonly string _resourceUri;
        private readonly string _filter;
        private readonly string _expand;
        private readonly RequestContext _context;

        public GetHistoricalAvailabilityStatusesOfChildResourceCollectionResult(ChildAvailabilityStatuses client, string resourceUri, string filter, string expand, RequestContext context)
            : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _resourceUri = resourceUri;
            _filter = filter;
            _expand = expand;
            _context = context;
        }

        public override IEnumerable<Page<ResourceHealthAvailabilityStatus>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken, UriKind.RelativeOrAbsolute) : null;
            while (true)
            {
                Response response = GetNextResponse(nextPage);
                if (response is null)
                {
                    yield break;
                }

                ResourceHealthAvailabilityStatusListResult result = ResourceHealthAvailabilityStatusListResult.FromResponse(response);
                yield return Page<ResourceHealthAvailabilityStatus>.FromValues((IReadOnlyList<ResourceHealthAvailabilityStatus>)result.Value, result.NextLink, response);
                nextPage = string.IsNullOrEmpty(result.NextLink) ? null : new Uri(result.NextLink, UriKind.RelativeOrAbsolute);
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }

        private Response GetNextResponse(Uri nextPage)
        {
            HttpMessage message = nextPage != null ? _client.CreateNextGetHistoricalAvailabilityStatusesOfChildResourceRequest(nextPage, _resourceUri, _filter, _expand, _context) : _client.CreateGetHistoricalAvailabilityStatusesOfChildResourceRequest(_resourceUri, _filter, _expand, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("MockableResourceHealthArmClient.GetHistoricalAvailabilityStatusesOfChildResource");
            scope.Start();
            try
            {
                return _client.Pipeline.ProcessMessage(message, _context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
