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
    internal class ClientAssertionCredential : TokenCredential
    {
        internal string TenantId { get; }
        internal string ClientId { get; }
        internal MsalConfidentialClient Client { get; }
        internal bool AllowMultiTenantAuthentication { get; }

        public ClientAssertionCredential(string tenantId, string clientId, Func<Task<string>> getAssertionCallback, ClientAssertionCredentialOptions options = default) :
            this(tenantId, clientId, () => getAssertionCallback().GetAwaiter().GetResult(), options)
        {
        }

        public ClientAssertionCredential(string tenantId, string clientId, Func<string> getAssertionCallback, ClientAssertionCredentialOptions options = default)
        {
            TenantId = tenantId;
            ClientId = clientId;
            Client = options?.MsalClient ?? new MsalConfidentialClient(options?.Pipeline ?? CredentialPipeline.GetInstance(options), tenantId, clientId, getAssertionCallback, null, null, options?.IsLoggingPIIEnabled ?? false);
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = Client.Pipeline.StartGetTokenScope("ClientAssertionCredential.GetToken", requestContext);

            try
            {
                var tenantId = TenantIdResolver.Resolve(TenantId, requestContext);

                AuthenticationResult result = Client.AcquireTokenForClientAsync(requestContext.Scopes, tenantId, false, cancellationToken).EnsureCompleted();

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        public async override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = Client.Pipeline.StartGetTokenScope("ClientAssertionCredential.GetToken", requestContext);

            try
            {
                var tenantId = TenantIdResolver.Resolve(TenantId, requestContext);

                AuthenticationResult result = await Client.AcquireTokenForClientAsync(requestContext.Scopes, tenantId, true, cancellationToken).ConfigureAwait(false);

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }
    }
}
