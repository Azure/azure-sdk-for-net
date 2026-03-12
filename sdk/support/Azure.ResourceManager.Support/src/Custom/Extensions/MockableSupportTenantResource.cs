// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Support.Mocking
{
    // Backward-compatible methods for TenantResource access, needed for ApiCompat
    public partial class MockableSupportTenantResource
    {
        /// <summary> Gets a collection of TenantSupportTicketResources in the TenantResource. </summary>
        /// <returns> An object representing collection of TenantSupportTicketResources and their operations over a TenantSupportTicketResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TenantSupportTicketCollection GetTenantSupportTickets()
        {
            return GetCachedClient(client => new TenantSupportTicketCollection(client, Id));
        }

        /// <summary> Gets a specific support ticket details. </summary>
        /// <param name="supportTicketName"> Support ticket name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<TenantSupportTicketResource>> GetTenantSupportTicketAsync(string supportTicketName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supportTicketName, nameof(supportTicketName));
            return await GetTenantSupportTickets().GetAsync(supportTicketName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific support ticket details. </summary>
        /// <param name="supportTicketName"> Support ticket name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<TenantSupportTicketResource> GetTenantSupportTicket(string supportTicketName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supportTicketName, nameof(supportTicketName));
            return GetTenantSupportTickets().Get(supportTicketName, cancellationToken);
        }

        /// <summary> Gets a collection of TenantFileWorkspaceResources in the TenantResource. </summary>
        /// <returns> An object representing collection of TenantFileWorkspaceResources and their operations over a TenantFileWorkspaceResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TenantFileWorkspaceCollection GetTenantFileWorkspaces()
        {
            return GetCachedClient(client => new TenantFileWorkspaceCollection(client, Id));
        }

        /// <summary> Gets details for a specific file workspace. </summary>
        /// <param name="fileWorkspaceName"> File workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<TenantFileWorkspaceResource>> GetTenantFileWorkspaceAsync(string fileWorkspaceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fileWorkspaceName, nameof(fileWorkspaceName));
            return await GetTenantFileWorkspaces().GetAsync(fileWorkspaceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets details for a specific file workspace. </summary>
        /// <param name="fileWorkspaceName"> File workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<TenantFileWorkspaceResource> GetTenantFileWorkspace(string fileWorkspaceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fileWorkspaceName, nameof(fileWorkspaceName));
            return GetTenantFileWorkspaces().Get(fileWorkspaceName, cancellationToken);
        }
    }
}
