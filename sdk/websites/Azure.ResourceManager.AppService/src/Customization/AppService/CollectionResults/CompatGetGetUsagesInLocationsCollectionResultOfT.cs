// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService
{
    // ROOT CAUSE: see CompatGetGetUsagesInLocationsAsyncCollectionResultOfT.
    internal partial class CompatGetGetUsagesInLocationsCollectionResultOfT : Pageable<CsmUsageQuota>
    {
        private readonly GetUsagesInLocationOperationGroup _client;
        private readonly Guid _subscriptionId;
        private readonly AzureLocation _location;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;

        public CompatGetGetUsagesInLocationsCollectionResultOfT(GetUsagesInLocationOperationGroup client, Guid subscriptionId, AzureLocation location, RequestContext context, string diagnosticScope)
            : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _location = location;
            _context = context;
            _diagnosticScope = diagnosticScope;
        }

        public override IEnumerable<Page<CsmUsageQuota>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                Response response = GetNextResponse(pageSizeHint, nextPage);
                if (response is null)
                {
                    yield break;
                }
                CsmUsageQuotaListResult result = CsmUsageQuotaListResult.FromResponse(response);
                yield return Page<CsmUsageQuota>.FromValues((IReadOnlyList<CsmUsageQuota>)result.Value, nextPage?.IsAbsoluteUri == true ? nextPage.AbsoluteUri : nextPage?.OriginalString, response);
                nextPage = result.NextLink;
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }

        private Response GetNextResponse(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null
                ? _client.CreateNextGetGetUsagesInLocationsRequest(nextLink, _subscriptionId, _location, _context)
                : _client.CreateGetGetUsagesInLocationsRequest(_subscriptionId, _location, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope(_diagnosticScope);
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
