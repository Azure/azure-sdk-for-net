// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Marketplace
{
    public partial class PrivateStoreResource
    {
        /// <summary> Gets the collection of approval requests in this private store. </summary>
        /// <returns> The approval request collection. </returns>
        public virtual MarketplaceApprovalRequestCollection GetMarketplaceApprovalRequests()
            => GetCachedClient(client => new MarketplaceApprovalRequestCollection(client, Id));

        /// <summary> Gets an approval request. </summary>
        /// <param name="requestApprovalId"> The approval request identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The approval request. </returns>
        public virtual Response<MarketplaceApprovalRequestResource> GetMarketplaceApprovalRequest(string requestApprovalId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(requestApprovalId, nameof(requestApprovalId));
            return GetMarketplaceApprovalRequests().Get(requestApprovalId, cancellationToken);
        }

        /// <summary> Gets an approval request. </summary>
        /// <param name="requestApprovalId"> The approval request identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The approval request. </returns>
        public virtual async Task<Response<MarketplaceApprovalRequestResource>> GetMarketplaceApprovalRequestAsync(string requestApprovalId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(requestApprovalId, nameof(requestApprovalId));
            return await GetMarketplaceApprovalRequests().GetAsync(requestApprovalId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the collection of admin approval requests in this private store. </summary>
        /// <returns> The admin approval request collection. </returns>
        public virtual MarketplaceAdminApprovalRequestCollection GetMarketplaceAdminApprovalRequests()
            => GetCachedClient(client => new MarketplaceAdminApprovalRequestCollection(client, Id));

        /// <summary> Gets an admin approval request. </summary>
        /// <param name="adminRequestApprovalId"> The admin approval request identifier. </param>
        /// <param name="publisherId"> The offer's publisher identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The admin approval request. </returns>
        public virtual Response<MarketplaceAdminApprovalRequestResource> GetMarketplaceAdminApprovalRequest(string adminRequestApprovalId, string publisherId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(adminRequestApprovalId, nameof(adminRequestApprovalId));
            Argument.AssertNotNullOrEmpty(publisherId, nameof(publisherId));
            return GetMarketplaceAdminApprovalRequests().Get(adminRequestApprovalId, publisherId, cancellationToken);
        }

        /// <summary> Gets an admin approval request. </summary>
        /// <param name="adminRequestApprovalId"> The admin approval request identifier. </param>
        /// <param name="publisherId"> The offer's publisher identifier. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The admin approval request. </returns>
        public virtual async Task<Response<MarketplaceAdminApprovalRequestResource>> GetMarketplaceAdminApprovalRequestAsync(string adminRequestApprovalId, string publisherId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(adminRequestApprovalId, nameof(adminRequestApprovalId));
            Argument.AssertNotNullOrEmpty(publisherId, nameof(publisherId));
            return await GetMarketplaceAdminApprovalRequests().GetAsync(adminRequestApprovalId, publisherId, cancellationToken).ConfigureAwait(false);
        }
    }
}
