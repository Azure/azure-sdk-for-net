﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// A <see cref="TokenCredential"/> implementation which authenticates a user using the device code flow, and provides access tokens for that user account.
    /// For more information on the device code authentication flow see https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/Device-Code-Flow.
    /// </summary>
    public class DeviceCodeCredential : TokenCredential
    {
        internal MsalPublicClient Client { get; }
        internal string ClientId { get; }
        internal bool DisableAutomaticAuthentication { get; }
        internal AuthenticationRecord Record { get; private set; }
        internal Func<DeviceCodeInfo, CancellationToken, Task> DeviceCodeCallback { get; }
        internal CredentialPipeline Pipeline { get; }

        private const string AuthenticationRequiredMessage = "Interactive authentication is needed to acquire token. Call Authenticate to initiate the device code authentication.";
        private const string NoDefaultScopeMessage = "Authenticating in this environment requires specifying a TokenRequestContext.";

        /// <summary>
        /// Creates a new <see cref="DeviceCodeCredential"/>, which will authenticate users using the device code flow.
        /// </summary>
        public DeviceCodeCredential() :
            this(DefaultDeviceCodeHandler, null, Constants.DeveloperSignOnClientId, null, null)
        {

        }

        /// <summary>
        ///  Creates a new <see cref="DeviceCodeCredential"/> with the specified options, which will authenticate users using the device code flow.
        /// </summary>
        /// <param name="options">The client options for the newly created <see cref="DeviceCodeCredential"/>.</param>
        public DeviceCodeCredential(DeviceCodeCredentialOptions options)
            : this(options?.DeviceCodeCallback ?? DefaultDeviceCodeHandler, options?.TenantId, options?.ClientId ?? Constants.DeveloperSignOnClientId, options, null)
        {
        }

        /// <summary>
        /// Creates a new DeviceCodeCredential with the specified options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="deviceCodeCallback">The callback to be executed to display the device code to the user</param>
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
        /// <param name="options">The client options for the newly created DeviceCodeCredential</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeviceCodeCredential(Func<DeviceCodeInfo, CancellationToken, Task> deviceCodeCallback, string clientId, TokenCredentialOptions options = default)
            : this(deviceCodeCallback, null, clientId, options, null)
        {

        }

        /// <summary>
        /// Creates a new DeviceCodeCredential with the specified options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="deviceCodeCallback">The callback to be executed to display the device code to the user</param>
        /// <param name="tenantId">The tenant id of the application to which users will authenticate.  This can be null for multi-tenanted applications.</param>
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
        /// <param name="options">The client options for the newly created DeviceCodeCredential</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeviceCodeCredential(Func<DeviceCodeInfo, CancellationToken, Task> deviceCodeCallback, string tenantId, string clientId,  TokenCredentialOptions options = default)
            : this(deviceCodeCallback, tenantId, clientId, options, null)
        {
        }

        internal DeviceCodeCredential(Func<DeviceCodeInfo, CancellationToken, Task> deviceCodeCallback, string tenantId, string clientId, TokenCredentialOptions options, CredentialPipeline pipeline)
            : this(deviceCodeCallback, tenantId, clientId, options, pipeline, null)
        {
        }

        internal DeviceCodeCredential(Func<DeviceCodeInfo, CancellationToken, Task> deviceCodeCallback, string tenantId, string clientId, TokenCredentialOptions options, CredentialPipeline pipeline, MsalPublicClient client)
        {
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            DeviceCodeCallback = deviceCodeCallback ?? throw new ArgumentNullException(nameof(deviceCodeCallback));

            DisableAutomaticAuthentication = (options as DeviceCodeCredentialOptions)?.DisableAutomaticAuthentication ?? false;

            Record = (options as DeviceCodeCredentialOptions)?.AuthenticationRecord;

            Pipeline = pipeline ?? CredentialPipeline.GetInstance(options);

            Client = client ?? new MsalPublicClient(Pipeline, tenantId, ClientId, AzureAuthorityHosts.GetDeviceCodeRedirectUri(Pipeline.AuthorityHost).ToString(), options as ITokenCacheOptions);
        }

        /// <summary>
        /// Interactively authenticates a user via the default browser.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The result of the authentication request, containing the acquired <see cref="AccessToken"/>, and the <see cref="AuthenticationRecord"/> which can be used to silently authenticate the account.</returns>
        public virtual AuthenticationRecord Authenticate(CancellationToken cancellationToken = default)
        {
            // get the default scope for the authority, throw if no default scope exists
            string defaultScope = AzureAuthorityHosts.GetDefaultScope(Pipeline.AuthorityHost) ?? throw new CredentialUnavailableException(NoDefaultScopeMessage);

            return Authenticate(new TokenRequestContext(new string[] { defaultScope }), cancellationToken);
        }

        /// <summary>
        /// Interactively authenticates a user via the default browser.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> which can be used to silently authenticate the account on future execution if persistent caching was enabled via <see cref="DeviceCodeCredentialOptions.EnablePersistentCache"/> when credential was instantiated.</returns>
        public virtual async Task<AuthenticationRecord> AuthenticateAsync(CancellationToken cancellationToken = default)
        {
            // get the default scope for the authority, throw if no default scope exists
            string defaultScope = AzureAuthorityHosts.GetDefaultScope(Pipeline.AuthorityHost) ?? throw new CredentialUnavailableException(NoDefaultScopeMessage);

            return await AuthenticateAsync(new TokenRequestContext(new string[] { defaultScope }), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Interactively authenticates a user via the default browser.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual AuthenticationRecord Authenticate(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return AuthenticateImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Interactively authenticates a user via the default browser.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <returns>The <see cref="AuthenticationRecord"/> of the authenticated account.</returns>
        public virtual async Task<AuthenticationRecord> AuthenticateAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await AuthenticateImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Obtains a token for a user account, authenticating them through the device code authentication flow. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains a token for a user account, authenticating them through the device code authentication flow. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        internal static Task DefaultDeviceCodeHandler(DeviceCodeInfo deviceCodeInfo, CancellationToken cancellationToken)
        {
            Console.WriteLine(deviceCodeInfo.Message);

            return Task.CompletedTask;
        }

        private async Task<AuthenticationRecord> AuthenticateImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope($"{nameof(DeviceCodeCredential)}.{nameof(Authenticate)}", requestContext);

            try
            {
                AccessToken token = await GetTokenViaDeviceCodeAsync(requestContext.Scopes, async, cancellationToken).ConfigureAwait(false);

                scope.Succeeded(token);

                return Record;
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = Pipeline.StartGetTokenScope($"{nameof(DeviceCodeCredential)}.{nameof(GetToken)}", requestContext);

            try
            {
                Exception inner = null;

                if (Record != null)
                {
                    try
                    {
                        AuthenticationResult result = await Client.AcquireTokenSilentAsync(requestContext.Scopes, Record, async, cancellationToken).ConfigureAwait(false);

                        return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
                    }
                    catch (MsalUiRequiredException e)
                    {
                        inner = e;
                    }
                }

                if (DisableAutomaticAuthentication)
                {
                    throw new AuthenticationRequiredException(AuthenticationRequiredMessage, requestContext, inner);
                }

                return scope.Succeeded(await GetTokenViaDeviceCodeAsync(requestContext.Scopes, async, cancellationToken).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private async Task<AccessToken> GetTokenViaDeviceCodeAsync(string[] scopes, bool async, CancellationToken cancellationToken)
        {
            AuthenticationResult result = await Client.AcquireTokenWithDeviceCodeAsync(scopes, code => DeviceCodeCallbackImpl(code, cancellationToken), async, cancellationToken).ConfigureAwait(false);

            Record = new AuthenticationRecord(result, ClientId);

            return new AccessToken(result.AccessToken, result.ExpiresOn);
        }

        private Task DeviceCodeCallbackImpl(DeviceCodeResult deviceCode, CancellationToken cancellationToken)
        {
            return DeviceCodeCallback(new DeviceCodeInfo(deviceCode), cancellationToken);
        }

    }
}
