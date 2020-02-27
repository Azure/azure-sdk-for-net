// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using System;
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
        private readonly MsalPublicClient _client = null;
        private readonly CredentialPipeline _pipeline;
        private IAccount _account = null;
        private readonly string _clientId;
        private readonly Func<DeviceCodeInfo, CancellationToken, Task> _deviceCodeCallback;

        /// <summary>
        /// Protected constructor for mocking
        /// </summary>
        protected DeviceCodeCredential()
        {

        }

        /// <summary>
        /// Creates a new DeviceCodeCredential with the specified options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="deviceCodeCallback">The callback to be executed to display the device code to the user</param>
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
        /// <param name="options">The client options for the newly created DeviceCodeCredential</param>
        public DeviceCodeCredential(Func<DeviceCodeInfo, CancellationToken, Task> deviceCodeCallback, string clientId, TokenCredentialOptions options = default)
            : this(deviceCodeCallback, null, clientId, options)
        {

        }

        /// <summary>
        /// Creates a new DeviceCodeCredential with the specifeid options, which will authenticate users with the specified application.
        /// </summary>
        /// <param name="deviceCodeCallback">The callback to be executed to display the device code to the user</param>
        /// <param name="tenantId">The tenant id of the application to which users will authenticate.  This can be null for multi-tenanted applications.</param>
        /// <param name="clientId">The client id of the application to which the users will authenticate</param>
        /// <param name="options">The client options for the newly created DeviceCodeCredential</param>
        public DeviceCodeCredential(Func<DeviceCodeInfo, CancellationToken, Task> deviceCodeCallback, string tenantId, string clientId,  TokenCredentialOptions options = default)
            : this(deviceCodeCallback, tenantId, clientId, CredentialPipeline.GetInstance(options))
        {
        }

        internal DeviceCodeCredential(Func<DeviceCodeInfo, CancellationToken, Task> deviceCodeCallback, string tenantId, string clientId, CredentialPipeline pipeline)
            : this(deviceCodeCallback, clientId, pipeline, pipeline.CreateMsalPublicClient(clientId, tenantId, redirectUrl: "https://login.microsoftonline.com/common/oauth2/nativeclient"))
        {
        }

        internal DeviceCodeCredential(Func<DeviceCodeInfo, CancellationToken, Task> deviceCodeCallback, string clientId, CredentialPipeline pipeline, MsalPublicClient client)
        {
            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            _deviceCodeCallback = deviceCodeCallback ?? throw new ArgumentNullException(nameof(deviceCodeCallback));

            _pipeline = pipeline;

            _client = client;
        }
        /// <summary>
        /// Obtains a token for a user account, authenticating them through the device code authentication flow. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Obtains a token for a user account, authenticating them through the device code authentication flow. This method is called by Azure SDK clients. It isn't intended for use in application code.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("DeviceCodeCredential.GetToken", requestContext);

            try
            {
                if (_account != null)
                {
                    try
                    {
                        AuthenticationResult result = await _client.AcquireTokenSilentAsync(requestContext.Scopes, _account, async, cancellationToken).ConfigureAwait(false);

                        return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
                    }
                    catch (MsalUiRequiredException)
                    {
                        return scope.Succeeded(await GetTokenViaDeviceCodeAsync(requestContext.Scopes, async, cancellationToken).ConfigureAwait(false));
                    }
                }
                else
                {
                    return scope.Succeeded(await GetTokenViaDeviceCodeAsync(requestContext.Scopes, async, cancellationToken).ConfigureAwait(false));
                }
            }
            catch (OperationCanceledException e)
            {
                scope.Failed(e);

                throw;
            }
            catch (Exception e)
            {
                throw scope.FailAndWrap(e);
            }
        }

        private async Task<AccessToken> GetTokenViaDeviceCodeAsync(string[] scopes, bool async, CancellationToken cancellationToken)
        {
            AuthenticationResult result = await _client.AcquireTokenWithDeviceCodeAsync(scopes, code => DeviceCodeCallback(code, cancellationToken), async, cancellationToken).ConfigureAwait(false);

            _account = result.Account;

            return new AccessToken(result.AccessToken, result.ExpiresOn);
        }

        private Task DeviceCodeCallback(DeviceCodeResult deviceCode, CancellationToken cancellationToken)
        {
            return _deviceCodeCallback(new DeviceCodeInfo(deviceCode), cancellationToken);
        }


    }
}
