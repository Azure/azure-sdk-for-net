// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication of a Microsoft Entra service principal using a signed client assertion.
    /// </summary>
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    [UnsupportedOSPlatform("browser")]
    [TypeForwardedFrom("Azure.Identity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8")]
    public class ClientAssertionCredential : TokenCredential
    {
        internal readonly string[] AdditionallyAllowedTenantIds;
        internal string TenantId { get; }
        internal string ClientId { get; }
        internal MsalConfidentialClient Client { get; }
        internal MsalConfidentialClient PopClient { get; }
        internal CredentialPipeline Pipeline { get; }
        internal TenantIdResolverBase TenantIdResolver { get; }

        /// <summary>
        /// Protected constructor for <see href="https://aka.ms/azsdk/net/mocking">mocking</see>.
        /// </summary>
        protected ClientAssertionCredential()
        { }

        /// <summary>
        /// Creates an instance of the ClientAssertionCredential with an asynchronous callback that provides a signed client assertion to authenticate against Microsoft Entra ID.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal.</param>
        /// <param name="assertionCallback">An asynchronous callback returning a valid client assertion used to authenticate the service principal.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to Microsoft Entra ID.</param>
        public ClientAssertionCredential(string tenantId, string clientId, Func<CancellationToken, Task<string>> assertionCallback, ClientAssertionCredentialOptions options = default)
        {
            Argument.AssertNotNull(clientId, nameof(clientId));

            TenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));
            ClientId = clientId;

            Pipeline = options?.Pipeline ?? CredentialPipeline.GetInstance(options);
            Client = options?.MsalClient ?? new MsalConfidentialClient(Pipeline, tenantId, clientId, assertionCallback, options);
            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
        }

        internal ClientAssertionCredential(
            string tenantId,
            string clientId,
            Func<CancellationToken, Task<string>> assertionCallback,
            Func<AssertionRequestOptions, CancellationToken, Task<ClientSignedAssertion>> popAssertionCallback,
            ClientAssertionCredentialOptions options = default)
            : this(tenantId, clientId, assertionCallback, options)
        {
            PopClient = options?.PopMsalClient ?? new MsalConfidentialClient(Pipeline, tenantId, clientId, popAssertionCallback, options);
        }

        internal ClientAssertionCredential(
            string tenantId,
            string clientId,
            TokenCredential assertionCredential,
            string assertionScope,
            ClientAssertionCredentialOptions options = default)
            : this(
                tenantId,
                clientId,
                cancellationToken => GetAssertionAsync(assertionCredential, assertionScope, cancellationToken),
                (assertionOptions, cancellationToken) => GetPopAssertionAsync(assertionCredential, assertionScope, assertionOptions, cancellationToken),
                options)
        {
        }

        private static async Task<string> GetAssertionAsync(TokenCredential assertionCredential, string assertionScope, CancellationToken cancellationToken)
        {
            AccessToken assertion = await assertionCredential.GetTokenAsync(new TokenRequestContext(new[] { assertionScope }), cancellationToken).ConfigureAwait(false);
            return assertion.Token;
        }

        internal static async Task<ClientSignedAssertion> GetPopAssertionAsync(
            TokenCredential assertionCredential,
            string assertionScope,
            AssertionRequestOptions assertionOptions,
            CancellationToken cancellationToken)
        {
            var tokenContext = new TokenRequestContext(
                new[] { assertionScope },
                parentRequestId: assertionOptions.CorrelationId.ToString(),
                claims: assertionOptions.Claims,
                isCaeEnabled: assertionOptions.ClientCapabilities?.Contains("CP1", StringComparer.OrdinalIgnoreCase) == true,
                isProofOfPossessionEnabled: true);
            AccessToken assertion = await assertionCredential.GetTokenAsync(tokenContext, cancellationToken).ConfigureAwait(false);
            return new ClientSignedAssertion
            {
                Assertion = assertion.Token,
                TokenBindingCertificate = assertion.BindingCertificate,
            };
        }

        /// <summary>
        /// Creates an instance of the ClientAssertionCredential with a synchronous callback that provides a signed client assertion to authenticate against Microsoft Entra ID.
        /// </summary>
        /// <param name="tenantId">The Microsoft Entra tenant (directory) ID of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal.</param>
        /// <param name="assertionCallback">A synchronous callback returning a valid client assertion used to authenticate the service principal.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to Microsoft Entra ID.</param>
        public ClientAssertionCredential(string tenantId, string clientId, Func<string> assertionCallback, ClientAssertionCredentialOptions options = default)
        {
            Argument.AssertNotNull(clientId, nameof(clientId));

            TenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));
            ClientId = clientId;

            Client = options?.MsalClient ?? new MsalConfidentialClient(options?.Pipeline ?? CredentialPipeline.GetInstance(options), tenantId, clientId, assertionCallback, options);
            Pipeline = options?.Pipeline ?? CredentialPipeline.GetInstance(options);
            TenantIdResolver = options?.TenantIdResolver ?? TenantIdResolverBase.Default;
            AdditionallyAllowedTenantIds = TenantIdResolver.ResolveAddionallyAllowedTenantIds((options as ISupportsAdditionallyAllowedTenants)?.AdditionallyAllowedTenants);
        }

        /// <summary>
        ///  Obtains a token from Microsoft Entra ID, by calling the assertionCallback specified when constructing the credential to obtain a client assertion for authentication.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope("ClientAssertionCredential.GetToken", requestContext);

            try
            {
                var tenantId = TenantIdResolver.Resolve(TenantId, requestContext, AdditionallyAllowedTenantIds);

                MsalConfidentialClient client = requestContext.IsProofOfPossessionEnabled && PopClient != null ? PopClient : Client;
                AuthenticationResult result;
                try
                {
                    result = client.AcquireTokenForClientAsync(requestContext.Scopes, tenantId, requestContext.Claims, requestContext.IsCaeEnabled, false, cancellationToken).EnsureCompleted();
                }
                catch (MsalClientException e) when (client == PopClient && e.ErrorCode == MsalError.MtlsCertificateNotProvided)
                {
                    result = Client.AcquireTokenForClientAsync(requestContext.Scopes, tenantId, requestContext.Claims, requestContext.IsCaeEnabled, false, cancellationToken).EnsureCompleted();
                }

                return scope.Succeeded(result.ToAccessToken());
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        /// <summary>
        ///  Obtains a token from Microsoft Entra ID, by calling the assertionCallback specified when constructing the credential to obtain a client assertion for authentication.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when the authentication failed.</exception>
        public async override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope("ClientAssertionCredential.GetToken", requestContext);

            try
            {
                var tenantId = TenantIdResolver.Resolve(TenantId, requestContext, AdditionallyAllowedTenantIds);

                MsalConfidentialClient client = requestContext.IsProofOfPossessionEnabled && PopClient != null ? PopClient : Client;
                AuthenticationResult result;
                try
                {
                    result = await client.AcquireTokenForClientAsync(requestContext.Scopes, tenantId, requestContext.Claims, requestContext.IsCaeEnabled, true, cancellationToken).ConfigureAwait(false);
                }
                catch (MsalClientException e) when (client == PopClient && e.ErrorCode == MsalError.MtlsCertificateNotProvided)
                {
                    result = await Client.AcquireTokenForClientAsync(requestContext.Scopes, tenantId, requestContext.Claims, requestContext.IsCaeEnabled, true, cancellationToken).ConfigureAwait(false);
                }

                return scope.Succeeded(result.ToAccessToken());
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }
    }
#pragma warning restore AZC0034
}
