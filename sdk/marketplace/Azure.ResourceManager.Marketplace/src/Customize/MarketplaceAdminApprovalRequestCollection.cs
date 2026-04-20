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
    // Fix generator bug: generated GetAll() returns Response<MarketplaceAdminApprovalRequestList>
    // but IEnumerable implementations call GetAll().GetEnumerator() which doesn't exist on Response<T>.
    [CodeGenSuppress("GetAll", typeof(CancellationToken))]
    [CodeGenSuppress("GetAllAsync", typeof(CancellationToken))]
    public partial class MarketplaceAdminApprovalRequestCollection
    {
        /// <summary> Get list of admin request approvals. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<MarketplaceAdminApprovalRequestResource> GetAll(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _privateStoreClientDiagnostics.CreateScope("MarketplaceAdminApprovalRequestCollection.GetAll");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _privateStoreRestClient.CreateAdminRequestApprovalsListRequest(Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                var list = MarketplaceAdminApprovalRequestList.FromResponse(result);
                var items = (list.Value ?? Array.Empty<MarketplaceAdminApprovalRequestData>())
                    .Select(data => new MarketplaceAdminApprovalRequestResource(Client, data))
                    .ToList();
                var page = Page<MarketplaceAdminApprovalRequestResource>.FromValues(items, null, result);
                return Pageable<MarketplaceAdminApprovalRequestResource>.FromPages(new[] { page });
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get list of admin request approvals. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<MarketplaceAdminApprovalRequestResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            // Use sync HTTP call wrapped in AsyncPageable for this single-page non-paginated API
            return AsyncPageable<MarketplaceAdminApprovalRequestResource>.FromPages(GetAll(cancellationToken).AsPages());
        }
    }
}
