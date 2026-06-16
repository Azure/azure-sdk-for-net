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
    internal partial class GetAvailabilityStatusResourcesBySubscriptionCollectionResult : Pageable<ResourceHealthAvailabilityStatusData>
    {
        private readonly AvailabilityStatuses _client;
        private readonly string _subscriptionId;
        private readonly string _filter;
        private readonly string _expand;
        private readonly RequestContext _context;

        public GetAvailabilityStatusResourcesBySubscriptionCollectionResult(AvailabilityStatuses client, string subscriptionId, string filter, string expand, RequestContext context)
            : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _filter = filter;
            _expand = expand;
            _context = context;
        }

        public override IEnumerable<Page<ResourceHealthAvailabilityStatusData>> AsPages(string continuationToken, int? pageSizeHint)
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
                yield return Page<ResourceHealthAvailabilityStatusData>.FromValues((IReadOnlyList<ResourceHealthAvailabilityStatusData>)result.Value, result.NextLink, response);
                nextPage = string.IsNullOrEmpty(result.NextLink) ? null : new Uri(result.NextLink, UriKind.RelativeOrAbsolute);
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }

        private Response GetNextResponse(Uri nextPage)
        {
            HttpMessage message = nextPage != null ? _client.CreateNextGetAvailabilityStatusesBySubscriptionRequest(nextPage, _subscriptionId, _filter, _expand, _context) : _client.CreateGetAvailabilityStatusesBySubscriptionRequest(_subscriptionId, _filter, _expand, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("MockableResourceHealthSubscriptionResource.GetAvailabilityStatusResourcesBySubscription");
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
