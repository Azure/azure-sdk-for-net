// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    internal partial class LocalRulestacksGetFirewallsCollectionResultOfT : Pageable<string>
    {
        private readonly LocalRulestacks _client;
        private readonly string _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _localRulestackName;
        private readonly RequestContext _context;

        /// <summary> Initializes a new instance of LocalRulestacksGetFirewallsCollectionResultOfT, which is used to iterate over the pages of a collection. </summary>
        /// <param name="client"> The LocalRulestacks client used to send requests. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="localRulestackName"> LocalRulestack resource name. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="localRulestackName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/> or <paramref name="localRulestackName"/> is an empty string, and was expected to be non-empty. </exception>
        public LocalRulestacksGetFirewallsCollectionResultOfT(LocalRulestacks client, string subscriptionId, string resourceGroupName, string localRulestackName, RequestContext context) : base(context?.CancellationToken ?? default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(localRulestackName, nameof(localRulestackName));

            _client = client;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _localRulestackName = localRulestackName;
            _context = context;
        }

        /// <summary> Gets the pages of LocalRulestacksGetFirewallsCollectionResultOfT as an enumerable collection. </summary>
        /// <param name="continuationToken"> A continuation token indicating where to resume paging. </param>
        /// <param name="pageSizeHint"> The number of items per page. </param>
        /// <returns> The pages of LocalRulestacksGetFirewallsCollectionResultOfT as an enumerable collection. </returns>
        public override IEnumerable<Page<string>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Response response = GetNextResponse(pageSizeHint, null);
            RulestackFirewallListResult result = RulestackFirewallListResult.FromResponse(response);
            yield return Page<string>.FromValues((IReadOnlyList<string>)result.Value, null, response);
        }

        /// <summary> Get next page. </summary>
        /// <param name="pageSizeHint"> The number of items per page. </param>
        /// <param name="continuationToken"> A continuation token indicating where to resume paging. </param>
        private Response GetNextResponse(int? pageSizeHint, string continuationToken)
        {
            HttpMessage message = _client.CreateGetFirewallsRequest(_subscriptionId, _resourceGroupName, _localRulestackName, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("LocalRulestackResource.GetFirewalls");
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
