﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Attempts authentication using a managed identity that has been assigned to the deployment environment.This authentication type works in Azure VMs,
    /// App Service and Azure Functions applications, as well as inside of Azure Cloud Shell. More information about configuring managed identities can be found here:
    /// https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview
    /// </summary>
    public class ManagedIdentityCredential : TokenCredential
    {
        private readonly string _clientId;
        private readonly ManagedIdentityClient _client;

        /// <summary>
        /// Creates an instance of the ManagedIdentityCredential capable of authenticating a resource with a managed identity.
        /// </summary>
        /// <param name="clientId">
        /// The client id to authenticate for a user assigned managed identity.  More information on user assigned managed identities cam be found here:
        /// https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview#how-a-user-assigned-managed-identity-works-with-an-azure-vm
        /// </param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ManagedIdentityCredential(string clientId = null, TokenCredentialOptions options = null)
        {
            _clientId = clientId;

            _client = (options != null) ? new ManagedIdentityClient(options) : ManagedIdentityClient.SharedClient;
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> from the Managed Identity service if available.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/> if no managed identity is available.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await _client.AuthenticateAsync(requestContext.Scopes, _clientId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Obtains an <see cref="AccessToken"/> from the Managed Identity service if available.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls, or a default <see cref="AccessToken"/> if no managed identity is available.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return _client.Authenticate(requestContext.Scopes, _clientId, cancellationToken);
        }
    }
}
