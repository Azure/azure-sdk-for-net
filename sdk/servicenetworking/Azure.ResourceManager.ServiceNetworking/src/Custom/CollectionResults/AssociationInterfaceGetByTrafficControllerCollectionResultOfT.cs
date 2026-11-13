// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS0618 // Type or member is obsolete

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ServiceNetworking.Models;

namespace Azure.ResourceManager.ServiceNetworking
{
    /// <summary>
    /// Custom collection result for deprecated AssociationCollection.GetAll methods.
    /// </summary>
    internal partial class AssociationInterfaceGetByTrafficControllerCollectionResultOfT : Pageable<AssociationData>
    {
        private readonly AssociationsInterface _client;
        private readonly string _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly string _trafficControllerName;
        private readonly RequestContext _context;

        /// <summary> Initializes a new instance of AssociationInterfaceGetByTrafficControllerCollectionResultOfT, which is used to iterate over the pages of a collection. </summary>
        /// <param name="client"> The AssociationsInterface client used to send requests. </param>
        /// <param name="subscriptionId"> The ID of the target subscription. The value must be an UUID. </param>
        /// <param name="resourceGroupName"> The name of the resource group. The name is case insensitive. </param>
        /// <param name="trafficControllerName"> traffic controller name for path. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        public AssociationInterfaceGetByTrafficControllerCollectionResultOfT(AssociationsInterface client, string subscriptionId, string resourceGroupName, string trafficControllerName, RequestContext context) : base(context?.CancellationToken ?? default)
        {
            _client = client;
            _subscriptionId = subscriptionId;
            _resourceGroupName = resourceGroupName;
            _trafficControllerName = trafficControllerName;
            _context = context;
        }

        /// <summary> Gets the pages of AssociationInterfaceGetByTrafficControllerCollectionResultOfT as an enumerable collection. </summary>
        /// <param name="continuationToken"> A continuation token indicating where to resume paging. </param>
        /// <param name="pageSizeHint"> The number of items per page. </param>
        /// <returns> The pages of AssociationInterfaceGetByTrafficControllerCollectionResultOfT as an enumerable collection. </returns>
        public override IEnumerable<Page<AssociationData>> AsPages(string continuationToken, int? pageSizeHint)
        {
            Uri nextPage = continuationToken != null ? new Uri(continuationToken) : null;
            while (true)
            {
                Response response = GetNextResponse(pageSizeHint, nextPage);
                if (response is null)
                {
                    yield break;
                }
                AssociationListResult result = AssociationListResult.FromResponse(response);
                // Convert TrafficControllerAssociationData to AssociationData
                var associationDataList = new List<AssociationData>();
                if (result.Value != null)
                {
                    foreach (var item in result.Value)
                    {
                        associationDataList.Add(new AssociationData(item));
                    }
                }
                yield return Page<AssociationData>.FromValues(associationDataList, nextPage?.AbsoluteUri, response);
                nextPage = result.NextLink;
                if (nextPage == null)
                {
                    yield break;
                }
            }
        }

        /// <summary> Get next page. </summary>
        /// <param name="pageSizeHint"> The number of items per page. </param>
        /// <param name="nextLink"> The next link to use for the next page of results. </param>
        private Response GetNextResponse(int? pageSizeHint, Uri nextLink)
        {
            HttpMessage message = nextLink != null ? _client.CreateNextGetByTrafficControllerRequest(nextLink, _subscriptionId, _resourceGroupName, _trafficControllerName, _context) : _client.CreateGetByTrafficControllerRequest(_subscriptionId, _resourceGroupName, _trafficControllerName, _context);
            using DiagnosticScope scope = _client.ClientDiagnostics.CreateScope("AssociationCollection.GetAll");
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
