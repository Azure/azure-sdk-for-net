// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Support
{
    // Backward-compatible extension methods for TenantResource access, needed for ApiCompat
    public static partial class SupportExtensions
    {
        /// <summary> Gets a collection of TenantSupportTicketResources in the TenantResource. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> instance the method will execute against. </param>
        /// <returns> An object representing collection of TenantSupportTicketResources and their operations over a TenantSupportTicketResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TenantSupportTicketCollection GetTenantSupportTickets(this TenantResource tenantResource)
        {
            return GetMockableSupportTenantResource(tenantResource).GetTenantSupportTickets();
        }

        /// <summary> Gets a specific support ticket details. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> instance the method will execute against. </param>
        /// <param name="supportTicketName"> Support ticket name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<TenantSupportTicketResource>> GetTenantSupportTicketAsync(this TenantResource tenantResource, string supportTicketName, CancellationToken cancellationToken = default)
        {
            return await GetMockableSupportTenantResource(tenantResource).GetTenantSupportTicketAsync(supportTicketName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific support ticket details. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> instance the method will execute against. </param>
        /// <param name="supportTicketName"> Support ticket name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<TenantSupportTicketResource> GetTenantSupportTicket(this TenantResource tenantResource, string supportTicketName, CancellationToken cancellationToken = default)
        {
            return GetMockableSupportTenantResource(tenantResource).GetTenantSupportTicket(supportTicketName, cancellationToken);
        }

        /// <summary> Gets a collection of TenantFileWorkspaceResources in the TenantResource. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> instance the method will execute against. </param>
        /// <returns> An object representing collection of TenantFileWorkspaceResources and their operations over a TenantFileWorkspaceResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TenantFileWorkspaceCollection GetTenantFileWorkspaces(this TenantResource tenantResource)
        {
            return GetMockableSupportTenantResource(tenantResource).GetTenantFileWorkspaces();
        }

        /// <summary> Gets details for a specific file workspace. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> instance the method will execute against. </param>
        /// <param name="fileWorkspaceName"> File workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<TenantFileWorkspaceResource>> GetTenantFileWorkspaceAsync(this TenantResource tenantResource, string fileWorkspaceName, CancellationToken cancellationToken = default)
        {
            return await GetMockableSupportTenantResource(tenantResource).GetTenantFileWorkspaceAsync(fileWorkspaceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets details for a specific file workspace. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> instance the method will execute against. </param>
        /// <param name="fileWorkspaceName"> File workspace name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<TenantFileWorkspaceResource> GetTenantFileWorkspace(this TenantResource tenantResource, string fileWorkspaceName, CancellationToken cancellationToken = default)
        {
            return GetMockableSupportTenantResource(tenantResource).GetTenantFileWorkspace(fileWorkspaceName, cancellationToken);
        }
    }
}
