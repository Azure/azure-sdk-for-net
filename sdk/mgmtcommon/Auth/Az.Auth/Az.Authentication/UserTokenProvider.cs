// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

//#if FullNetFx
namespace Microsoft.Rest.Azure.Authentication
{
    using System;
    using System.Globalization;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Rest.ClientRuntime.Azure.Authentication.Properties;

    /// <summary>
    /// Provides tokens for Azure Active Directory Microsoft Id and Organization Id users.
    /// </summary>
    public partial class UserTokenProvider : ITokenProvider
    {   
        /// <summary>
        /// Uri parameters used in the credential prompt.  Allows recalling previous 
        /// logins in the login dialog.
        /// </summary>
        private string _tokenAudience;
        private AuthenticationContext _authenticationContext;
        private string _clientId;
        private UserIdentifier _userid;

        /// <summary>
        /// The id of the active directory common tenant.
        /// </summary>
        public const string CommonTenantId = "common";


        /// <summary>
        /// Create a token provider which can provide user tokens in the given context.  The user must have previously authenticated in the given context. 
        /// Tokens are retrieved from the token cache.
        /// </summary>
        /// <param name="context">The active directory authentication context to use for retrieving tokens.</param>
        /// <param name="clientId">The active directory client Id to match when retrieving tokens.</param>
        /// <param name="tokenAudience">The audience to match when retrieving tokens.</param>
        /// <param name="userId">The user id to match when retrieving tokens.</param>
        public UserTokenProvider(AuthenticationContext context, string clientId, Uri tokenAudience,
            UserIdentifier userId)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentNullException("clientId");
            }
            if (tokenAudience == null)
            {
                throw new ArgumentNullException("tokenAudience");
            }
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            this._authenticationContext = context;
            this._clientId = clientId;
            this._tokenAudience = tokenAudience.OriginalString;
            this._userid = userId;
        }


        #region .NET 461
        // please remove this preprocessor #if whenever ADAL will go public with the new library 
#if !net452
        /// <summary>
        /// Log in to azure active directory using device code authentication.
        /// </summary>
        /// <param name="clientId">The active directory client id for this application.</param>
        /// <param name="deviceCodeHandler">User provided callback to display device code request. if returns false no token will be acquired.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginByDeviceCodeAsync(
            string clientId,
            Func<DeviceCodeResult, bool> deviceCodeHandler)
        {
            return await LoginByDeviceCodeAsync(clientId, CommonTenantId, ActiveDirectoryServiceSettings.Azure, TokenCache.DefaultShared, deviceCodeHandler);
        }

        /// <summary>
        /// Log in to azure active directory using device code authentication.
        /// </summary>
        /// <param name="clientId">The active directory client id for this application.</param>
        /// <param name="domain">The active directory domain or tenant id to authenticate with.</param>
        /// <param name="deviceCodeHandler">User provided callback to display device code request. if returns false no token will be acquired.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginByDeviceCodeAsync(
            string clientId,
            string domain,
            Func<DeviceCodeResult, bool> deviceCodeHandler)
        {
            return await LoginByDeviceCodeAsync(clientId, domain, ActiveDirectoryServiceSettings.Azure, TokenCache.DefaultShared, deviceCodeHandler);
        }

        /// <summary>
        /// Log in to azure active directory using device code authentication.
        /// </summary>
        /// <param name="clientId">The active directory client id for this application.</param>
        /// <param name="domain">The active directory domain or tenant id to authenticate with.</param>
        /// <param name="cache">The token cache to target during authentication.</param>
        /// <param name="deviceCodeHandler">User provided callback to display device code request. if returns false no token will be acquired.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginByDeviceCodeAsync(
            string clientId,
            string domain,
            TokenCache cache,
            Func<DeviceCodeResult, bool> deviceCodeHandler)
        {
            return await LoginByDeviceCodeAsync(clientId, domain, ActiveDirectoryServiceSettings.Azure, cache, deviceCodeHandler);
        }

        /// <summary>
        /// Log in to azure active directory using device code authentication.
        /// </summary>
        /// <param name="clientId">The active directory client id for this application.</param>
        /// <param name="domain">The active directory domain or tenant id to authenticate with.</param>
        /// <param name="serviceSettings">The active directory service details, including authentication endpoints and the intended token audience.</param>
        /// <param name="deviceCodeHandler">User provided callback to display device code request. if returns false no token will be acquired.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginByDeviceCodeAsync(
            string clientId,
            string domain,
            ActiveDirectoryServiceSettings serviceSettings,
            Func<DeviceCodeResult, bool> deviceCodeHandler)
        {
            return await LoginByDeviceCodeAsync(clientId, domain, serviceSettings, TokenCache.DefaultShared, deviceCodeHandler);
        }

        /// <summary>
        /// Log in to azure active directory using device code authentication.
        /// </summary>
        /// <param name="clientId">The active directory client id for this application.</param>
        /// <param name="domain">The active directory domain or tenant id to authenticate with.</param>
        /// <param name="serviceSettings">The active directory service details, including authentication endpoints and the intended token audience.</param>
        /// <param name="cache">The token cache to target during authentication.</param>
        /// <param name="deviceCodeHandler">User provided callback to display device code request. if returns false no token will be acquired.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginByDeviceCodeAsync(
            string clientId, 
            string domain, 
            ActiveDirectoryServiceSettings serviceSettings, 
            TokenCache cache, 
            Func<DeviceCodeResult, bool> deviceCodeHandler)
        {
            if(deviceCodeHandler == null)
            {
                throw new ArgumentException("deviceCodeHandler");
            }

            var authenticationContext = GetAuthenticationContext(domain, serviceSettings, cache);

            try
            {
                DeviceCodeResult codeResult = await authenticationContext.AcquireDeviceCodeAsync(
                                                                                serviceSettings.TokenAudience.OriginalString,
                                                                                clientId)
                                                                         .ConfigureAwait(false);

                if (deviceCodeHandler(codeResult))
                {
                    AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenByDeviceCodeAsync(codeResult)
                                                                                           .ConfigureAwait(false);

                    return new TokenCredentials(
                        new UserTokenProvider(
                            authenticationContext,
                            clientId,
                            serviceSettings.TokenAudience,
                            new UserIdentifier(authenticationResult.UserInfo.DisplayableId, UserIdentifierType.RequiredDisplayableId)),
                        authenticationResult.TenantId,
                        authenticationResult.UserInfo == null ? null : authenticationResult.UserInfo.DisplayableId);
                }

                return null;
            }
            catch (AdalException ex)
            {
                throw new AuthenticationException(Resources.ErrorAcquiringToken, ex);
            }
            catch (FormatException ex)
            {
                throw new AuthenticationException(Resources.ErrorAcquiringToken, ex);
            }
        }
#endif
        #endregion .NET 46

        /// <summary>
        /// Create service client credentials using information cached from a previous login to azure resource manager using the default token cache. 
        /// Parameters are used to match existing tokens.
        /// </summary>
        /// <param name="clientId">The clientId to match when retrieving authentication tokens.</param>
        /// <param name="domain">The active directory domain or tenant id to match when retrieving authentication tokens.</param>
        /// <param name="username">The account username to match when retrieving authentication tokens.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the retrieved credentials. If no 
        /// credentials can be retrieved, an authentication exception is thrown.</returns>
        public static async Task<ServiceClientCredentials> CreateCredentialsFromCache(string clientId, string domain,
            string username)
        {
            return await CreateCredentialsFromCache(clientId, domain, username, ActiveDirectoryServiceSettings.Azure, TokenCache.DefaultShared);
        }

        /// <summary>
        /// Create service client credentials using information cached from a previous login to azure resource manager. Parameters are used to match 
        /// existing tokens.
        /// </summary>
        /// <param name="clientId">The clientId to match when retrieving authentication tokens.</param>
        /// <param name="domain">The active directory domain or tenant id to match when retrieving authentication tokens.</param>
        /// <param name="username">The account username to match when retrieving authentication tokens.</param>
        /// <param name="cache">The token cache to target when retrieving tokens.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the retrieved credentials. If no 
        /// credentials can be retrieved, an authentication exception is thrown.</returns>
        public static async Task<ServiceClientCredentials> CreateCredentialsFromCache(string clientId, string domain,
            string username, TokenCache cache)
        {
            return await CreateCredentialsFromCache(clientId, domain, username, ActiveDirectoryServiceSettings.Azure, cache);
        }

        /// <summary>
        /// Create service client credentials using information cached from a previous login in the default token cache. Parameters are used to match 
        /// existing tokens.
        /// </summary>
        /// <param name="clientId">The clientId to match when retrieving authentication tokens.</param>
        /// <param name="domain">The active directory domain or tenant id to match when retrieving authentication tokens.</param>
        /// <param name="username">The account username to match when retrieving authentication tokens.</param>
        /// <param name="serviceSettings">The active directory service settings, including token authority and audience to match when retrieving tokens.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the retrieved credentials. If no 
        /// credentials can be retrieved, an authentication exception is thrown.</returns>
        public static async Task<ServiceClientCredentials> CreateCredentialsFromCache(string clientId, string domain,
            string username, ActiveDirectoryServiceSettings serviceSettings)
        {
            return await CreateCredentialsFromCache(clientId, domain, username, serviceSettings, TokenCache.DefaultShared);
        }

        /// <summary>
        /// Create service client credentials using information cached from a previous login. Parameters are used to match existing tokens.
        /// </summary>
        /// <param name="clientId">The clientId to match when retrieving authentication tokens.</param>
        /// <param name="domain">The active directory domain or tenant id to match when retrieving authentication tokens.</param>
        /// <param name="username">The account username to match when retrieving authentication tokens.</param>
        /// <param name="serviceSettings">The active directory service settings, including token authority and audience to match when retrieving tokens.</param>
        /// <param name="cache">The token cache to target when retrieving tokens.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the retrieved credentials. If no 
        /// credentials can be retrieved, an authentication exception is thrown.</returns>
        public static async Task<ServiceClientCredentials> CreateCredentialsFromCache(string clientId, string domain, string username, 
            ActiveDirectoryServiceSettings serviceSettings, TokenCache cache)
        {
            var userId = new UserIdentifier(username, UserIdentifierType.RequiredDisplayableId);
            var authenticationContext = GetAuthenticationContext(domain, serviceSettings, cache);
            try
            {
                var authResult = await authenticationContext.AcquireTokenSilentAsync(serviceSettings.TokenAudience.OriginalString,
                      clientId, userId).ConfigureAwait(false);
                return
                    new TokenCredentials(
                        new UserTokenProvider(authenticationContext, clientId,serviceSettings.TokenAudience, userId),
                        authResult.TenantId,
                        authResult.UserInfo == null ? null : authResult.UserInfo.DisplayableId);
            }
            catch (AdalException ex)
            {
                throw new AuthenticationException(Resources.ErrorAcquiringToken, ex);
            }
        }

        /// <summary>
        /// Gets an access token from the token cache or from AD authentication endpoint.  Will attempt to 
        /// refresh the access token if it has expired.
        /// </summary>
        public virtual async Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            try
            {
                AuthenticationResult result = await this._authenticationContext.AcquireTokenSilentAsync(this._tokenAudience,
                    this._clientId, this._userid).ConfigureAwait(false);
                return new AuthenticationHeaderValue(result.AccessTokenType, result.AccessToken);
            }

            //catch (AdalServiceException serviceException)
            //{
            //    if (ex.ErrorCode == "temporarily_unavailable")
            //    {
            //        RetryConditionHeaderValue retry = serviceException.Headers.RetryAfter;
            //        if (retry.Delta.HasValue)
            //        {
            //            delay = retry.Delta;
            //        }
            //        else if (retry.Date.HasValue)
            //        {
            //            delay = retry.Date.Value.Offset;
            //        }
            //    }
            //}
            catch (AdalException authenticationException)
            {
                throw new AuthenticationException(Resources.ErrorRenewingToken, authenticationException);
            }
        }

        private static AuthenticationContext GetAuthenticationContext(string domain, ActiveDirectoryServiceSettings serviceSettings, TokenCache cache)
        {
            var context = (cache == null
                ? new AuthenticationContext(serviceSettings.AuthenticationEndpoint + domain,
                    serviceSettings.ValidateAuthority)
                : new AuthenticationContext(serviceSettings.AuthenticationEndpoint + domain,
                    serviceSettings.ValidateAuthority, cache));
            return context;
        }
    }
}
//#endif
