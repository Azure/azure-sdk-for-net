// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Marketplace.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Marketplace
{
    // Fix generator bug: generated GetAll() returns Response<RequestApprovalsList>
    // but IEnumerable implementations call GetAll().GetEnumerator() which doesn't exist on Response<T>.
    [CodeGenSuppress("GetAll", typeof(CancellationToken))]
    [CodeGenSuppress("GetAllAsync", typeof(CancellationToken))]
    public partial class MarketplaceApprovalRequestCollection
    {
        /// <summary> Get all open approval requests of current user. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<MarketplaceApprovalRequestResource> GetAll(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _privateStoreClientDiagnostics.CreateScope("MarketplaceApprovalRequestCollection.GetAll");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateStoreRestClient.CreateGetApprovalRequestsListRequest(Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                var list = RequestApprovalsList.FromResponse(result);
                var items = (list.Value ?? Array.Empty<MarketplaceApprovalRequestData>())
                    .Select(data => new MarketplaceApprovalRequestResource(Client, data))
                    .ToList();
                var page = Page<MarketplaceApprovalRequestResource>.FromValues(items, null, result);
                return Pageable<MarketplaceApprovalRequestResource>.FromPages(new[] { page });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get all open approval requests of current user. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<MarketplaceApprovalRequestResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            // Use sync HTTP call wrapped in AsyncPageable for this single-page non-paginated API
            return AsyncPageable<MarketplaceApprovalRequestResource>.FromPages(GetAll(cancellationToken).AsPages());
        }
    }
}
