// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.ResourceManager.EventGrid
{
    // Back-compat shim for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // Dispatches EventSubscriptionCollection.GetAllAsync() to CreateGetByDomainTopicRequest
    // when the collection scope is a DomainTopic (Microsoft.EventGrid/domains/{}/topics/{}).
    internal partial class EventSubscriptionsGetByDomainTopicAsyncCollectionResultOfT : AsyncPageable<EventGridSubscriptionData>
    {
        private readonly EventSubscriptions _client;
        private readonly Guid _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _domainName;
        private readonly string _topicName;
        private readonly string _filter;
        private readonly int? _top;
        private readonly RequestContext _context;
        private readonly string _diagnosticScope;

        public EventSubscriptionsGetByDomainTopicAsyncCollectionResultOfT(EventSubscriptions client, Guid subscriptionId, string resourceGroupName, string domainName, string topicName, string filter, int? top, RequestContext context, string diagnosticScope) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _domainName = domainName;
            _topicName = topicName;
            _filter = filter;
            _top = top;
            _context = context;
            _diagnosticScope = diagnosticScope;
        }

        public override async IAsyncEnumerable<Page<EventGridSubscriptionData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                Response response = await GetNextResponseAsync(pageSizeHint, nextPage).ConfigureAwait(false);
                if (response is null)
                {
                    yield break;
                }
                EventSubscriptionsListResult result = EventSubscriptionsListResult.FromResponse(response);
                yield return Page<EventGridSubscriptionData>.FromValues((IReadOnlyList<EventGridSubscriptionData>)result.Value, nextPage?.IsAbsoluteUri == true ? nextPage.AbsoluteUri : nextPage?.OriginalString, response);
                nextPage = result.NextLink;
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }

        private async ValueTask<Response> GetNextResponseAsync(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null
                ? _client.CreateNextGetByDomainTopicRequest(nextLink, _subscriptionId, _resourceGroupName, _domainName, _topicName, _filter, _top, _context)
                : _client.CreateGetByDomainTopicRequest(_subscriptionId, _resourceGroupName, _domainName, _topicName, _filter, _top, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope(_diagnosticScope);
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
