// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// WorkloadIdentityCredential supports Microsoft Entra Workload ID authentication on Kubernetes and other hosts supporting workload identity.
    /// Refer to <a href="https://learn.microsoft.com/azure/aks/workload-identity-overview">Microsoft Entra Workload ID</a> for more information.
    /// </summary>
    public class WorkloadIdentityCredential : TokenCredential
    {
        private const string UnavailableErrorMessage = "WorkloadIdentityCredential authentication unavailable. The workload options are not fully configured. See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/workloadidentitycredential/troubleshoot";
        private readonly FileContentsCache _tokenFileCache;
        private readonly ClientAssertionCredential _clientAssertionCredential;
        private readonly CredentialPipeline _pipeline;
        internal MsalConfidentialClient Client => _clientAssertionCredential?.Client;
        internal string[] AdditionallyAllowedTenantIds => _clientAssertionCredential?.AdditionallyAllowedTenantIds;

        /// <summary>
        /// Creates a new instance of the <see cref="WorkloadIdentityCredential"/> with the default options.
        /// When no options are specified AZURE_TENANT_ID, AZURE_CLIENT_ID and AZURE_FEDERATED_TOKEN_FILE must be specified in the environment.
        /// </summary>
        public WorkloadIdentityCredential() : this(default) { }

        /// <summary>
        /// Creates a new instance of the <see cref="WorkloadIdentityCredential"/> with the specified options.
        /// </summary>
        /// <param name="options">Options that allow to configure the management of the requests sent to Microsoft Entra ID.</param>
        public WorkloadIdentityCredential(WorkloadIdentityCredentialOptions options)
        {
            options = options ?? new();

            if (!string.IsNullOrEmpty(options.TenantId) && !string.IsNullOrEmpty(options.ClientId) && !string.IsNullOrEmpty(options.TokenFilePath))
            {
                _tokenFileCache = new FileContentsCache(options.TokenFilePath);

                ClientAssertionCredentialOptions clientAssertionCredentialOptions = options.Clone<ClientAssertionCredentialOptions>();
                clientAssertionCredentialOptions.Pipeline = options.Pipeline;
                clientAssertionCredentialOptions.MsalClient = options.MsalClient;

                _clientAssertionCredential = new ClientAssertionCredential(options.TenantId, options.ClientId, _tokenFileCache.GetTokenFileContentsAsync, clientAssertionCredentialOptions);
            }
            _pipeline = _clientAssertionCredential?.Pipeline ?? CredentialPipeline.GetInstance(default);
        }

        /// <inheritdoc />
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenCoreAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <inheritdoc />
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenCoreAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async ValueTask<AccessToken> GetTokenCoreAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("WorkloadIdentityCredential.GetToken", requestContext);

            try
            {
                if (_clientAssertionCredential == null)
                {
                    throw new CredentialUnavailableException(UnavailableErrorMessage);
                }

                AccessToken token = async ? await _clientAssertionCredential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false)
                    : _clientAssertionCredential.GetToken(requestContext, cancellationToken);

                return scope.Succeeded(token);
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }
    }
}
