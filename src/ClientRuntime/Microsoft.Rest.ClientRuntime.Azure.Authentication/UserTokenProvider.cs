// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.ClientRuntime.Azure.Authentication.Properties;

namespace Microsoft.Rest.Azure.Authentication
{
    /// <summary>
    /// Provides tokens for Azure Active Directory Microsoft Id and Organization Id users.
    /// </summary>
    public class UserTokenProvider : ITokenProvider
    {
        /// <summary>
        /// The id of the active directory common tenant.
        /// </summary>
        public const string CommonTenantId = "common";
        /// <summary>
        /// Uri parameters used in the credential prompt.  Allows recalling previous 
        /// logins in the login dialog.
        /// </summary>
        private string _tokenAudience;
        private AuthenticationContext _authenticationContext;
        private string _clientId;
        private UserIdentifier _userid;

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
            this._tokenAudience = tokenAudience.ToString();
            this._userid = userId;
        }
// Interactive authentication is not implemented for CoreCLR.
#if !PORTABLE
        /// <summary>
        /// Log in to Azure active directory common tenant with user account and authentication provided by the user.  Authentication is automatically scoped to the default azure management endpoint. 
        /// This call may display a credentials dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(
            ActiveDirectoryClientSettings clientSettings)
        {
            return await LoginWithPromptAsync(CommonTenantId, clientSettings, ActiveDirectoryServiceSettings.Azure,
               UserIdentifier.AnyUser, TokenCache.DefaultShared);
        }

        /// <summary>
        /// Log in to Azure active directory common tenant using the given username, with authentication provided by the user.  Authentication is automatically scoped to the default azure management endpoint. 
        /// This call may display a credentials dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <param name="username">The username to use for authentication.</param>
        /// <param name="cache">The token cache to target during authentication.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(
            ActiveDirectoryClientSettings clientSettings, string username, TokenCache cache)
        {
            return await LoginWithPromptAsync(CommonTenantId, clientSettings, ActiveDirectoryServiceSettings.Azure,
               new UserIdentifier(username, UserIdentifierType.RequiredDisplayableId), cache);
        }

        /// <summary>
        /// Log in to Azure active directory common tenant using the given username, with authentication provided by the user.  Authentication is automatically scoped to the default azure management endpoint. 
        /// This call may display a credentials dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <param name="username">The username to use for authentication.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(
            ActiveDirectoryClientSettings clientSettings, string username)
        {
            return await LoginWithPromptAsync(CommonTenantId, clientSettings, ActiveDirectoryServiceSettings.Azure,
               new UserIdentifier(username, UserIdentifierType.RequiredDisplayableId), TokenCache.DefaultShared);
        }

        /// <summary>
        /// Log in to Azure active directory common tenant with user account and authentication provided by the user.  Authentication is automatically scoped to the default azure management endpoint. 
        /// This call may display a credentials dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <param name="cache">The token cache to target during authentication.</param>
        /// <returns>ServiceClientCredentials object for the common tenant that match provided authentication credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(
            ActiveDirectoryClientSettings clientSettings, TokenCache cache)
        {
            return await LoginWithPromptAsync(CommonTenantId, clientSettings, ActiveDirectoryServiceSettings.Azure,
               UserIdentifier.AnyUser, cache);
        }

        /// <summary>
        /// Log in to Azure active directory with user account and authentication provided by the user.  Authentication is automatically scoped to the default azure management endpoint. 
        /// This call may display a credentials dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="domain">The domain to authenticate against.</param>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(string domain,
            ActiveDirectoryClientSettings clientSettings)
        {
            return await LoginWithPromptAsync(domain, clientSettings, ActiveDirectoryServiceSettings.Azure,
               UserIdentifier.AnyUser, TokenCache.DefaultShared);
        }

        /// <summary>
        /// Log in to Azure active directory using the given username with authentication provided by the user.  Authentication is automatically scoped to the default azure management endpoint. 
        /// This call may display a credentials dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="domain">The domain to authenticate against.</param>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <param name="username">The username to use for authentication.</param>
        /// <param name="cache">The token cache to target during authentication.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(string domain,
            ActiveDirectoryClientSettings clientSettings, string username, TokenCache cache)
        {
            return await LoginWithPromptAsync(domain, clientSettings, ActiveDirectoryServiceSettings.Azure,
               new UserIdentifier(username, UserIdentifierType.RequiredDisplayableId), cache);
        }

        /// <summary>
        /// Log in to Azure active directory using the given username with authentication provided by the user.  Authentication is automatically scoped to the default azure management endpoint. 
        /// This call may display a credentials dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="domain">The domain to authenticate against.</param>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <param name="username">The username to use for authentication.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(string domain,
            ActiveDirectoryClientSettings clientSettings, string username)
        {
            return await LoginWithPromptAsync(domain, clientSettings, ActiveDirectoryServiceSettings.Azure,
               new UserIdentifier(username, UserIdentifierType.RequiredDisplayableId), TokenCache.DefaultShared);
        }

        /// <summary>
        /// Log in to Azure active directory with both user account and authentication credentials provided by the user.  This call may display a 
        /// credentials dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="domain">The domain to authenticate against.</param>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <param name="cache">The token cache to target during authentication.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(string domain,
            ActiveDirectoryClientSettings clientSettings, TokenCache cache)
        {
            return await LoginWithPromptAsync(domain, clientSettings, ActiveDirectoryServiceSettings.Azure,
               UserIdentifier.AnyUser, cache);
        }

        /// <summary>
        /// Log in to Azure active directory with both user account and authentication credentials provided by the user.  This call may display a 
        /// credentials dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="domain">The domain to authenticate against.</param>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <param name="serviceSettings">The settings for ad service, including endpoint and token audience</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(string domain,
            ActiveDirectoryClientSettings clientSettings,
            ActiveDirectoryServiceSettings serviceSettings)
        {
            return await LoginWithPromptAsync(domain, clientSettings, serviceSettings,
               UserIdentifier.AnyUser, TokenCache.DefaultShared);
        }

        /// <summary>
        /// Log in to Azure active directory with both user account and authentication credentials provided by the user.  This call may display a 
        /// credentials dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="domain">The domain to authenticate against.</param>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <param name="serviceSettings">The settings for ad service, including endpoint and token audience</param>
        /// <param name="cache">The token cache to target during authentication.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(string domain,
            ActiveDirectoryClientSettings clientSettings,
            ActiveDirectoryServiceSettings serviceSettings, TokenCache cache)
        {
            return await LoginWithPromptAsync(domain, clientSettings, serviceSettings,
               UserIdentifier.AnyUser, cache);
        }

        /// <summary>
        /// Log in to Azure active directory using the given username with authentication provided by the user.  This call may display a credentials 
        /// dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="domain">The domain to authenticate against.</param>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <param name="serviceSettings">The settings for ad service, including endpoint and token audience</param>
        /// <param name="username">The username to use for authentication.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(string domain,
            ActiveDirectoryClientSettings clientSettings,
            ActiveDirectoryServiceSettings serviceSettings, string username)
        {
            return await LoginWithPromptAsync(domain, clientSettings, serviceSettings,
               new UserIdentifier(username, UserIdentifierType.RequiredDisplayableId), TokenCache.DefaultShared);
        }

        /// <summary>
        /// Log in to Azure active directory using the given username with authentication provided by the user.  This call may display a credentials 
        /// dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="domain">The domain to authenticate against.</param>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <param name="serviceSettings">The settings for ad service, including endpoint and token audience</param>
        /// <param name="username">The username to use for authentication.</param>
        /// <param name="cache">The token cache to target during authentication.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(string domain,
            ActiveDirectoryClientSettings clientSettings,
            ActiveDirectoryServiceSettings serviceSettings, string username, TokenCache cache)
        {
            return await LoginWithPromptAsync(domain, clientSettings, serviceSettings,
               new UserIdentifier(username, UserIdentifierType.RequiredDisplayableId), cache);
        }

        /// <summary>
        /// Log in to Azure active directory with credentials provided by the user.  This call may display a credentials 
        /// dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="domain">The domain to authenticate against.</param>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <param name="serviceSettings">The settings for ad service, including endpoint and token audience</param>
        /// <param name="userId">The userid of the desired credentials</param>
        /// <param name="cache">The token cache to target during authentication.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(string domain, ActiveDirectoryClientSettings clientSettings, 
            ActiveDirectoryServiceSettings serviceSettings, UserIdentifier userId, TokenCache cache)
        {
            var authenticationContext = GetAuthenticationContext(domain, serviceSettings, cache);
            TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            var task = new Task<AuthenticationResult>(() =>
            {
                try
                {
                    var result = authenticationContext.AcquireToken(
                        serviceSettings.TokenAudience.ToString(),
                        clientSettings.ClientId,
                        clientSettings.ClientRedirectUri,
                        clientSettings.PromptBehavior,
                        userId,
                        clientSettings.AdditionalQueryParameters);
                    return result;
                }
                catch (Exception e)
                {
                    throw new AuthenticationException(
                        string.Format(CultureInfo.CurrentCulture, Resources.ErrorAcquiringToken,
                            e.Message), e);
                }
            });

            task.Start(scheduler);
            var authResult = await task.ConfigureAwait(false);
            var newUserId = new UserIdentifier(authResult.UserInfo.DisplayableId,
                UserIdentifierType.RequiredDisplayableId);
            return new TokenCredentials(
                new UserTokenProvider(authenticationContext, clientSettings.ClientId,serviceSettings.TokenAudience, newUserId),
                authResult.TenantId,
                authResult.UserInfo.DisplayableId);
        }
#endif
        /// <summary>
        /// Log in to azure active directory in non-interactive mode using organizational id credentials and the default token cache. Default service 
        /// settings (authority, audience) for logging in to azure resource manager are used.
        /// </summary>
        /// <param name="clientId">The active directory client id for this application.</param>
        /// <param name="domain">The active directory domain or tenant id to authenticate with.</param>
        /// <param name="username">The organizational account user name, given in the form of a user principal name (e.g. user1@contoso.org).</param>
        /// <param name="password">The organizational account password.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginSilentAsync(string clientId, string domain, string username, string password)
        {
            return await LoginSilentAsync(clientId, domain, username, password, ActiveDirectoryServiceSettings.Azure, TokenCache.DefaultShared);
        }

        /// <summary>
        /// Log in to azure active directory in non-interactive mode using organizational id credentials. Default service settings (authority, audience) 
        /// for logging in to azure resource manager are used.
        /// </summary>
        /// <param name="clientId">The active directory client id for this application.</param>
        /// <param name="domain">The active directory domain or tenant id to authenticate with.</param>
        /// <param name="username">The organizational account user name, given in the form of a user principal name (e.g. user1@contoso.org).</param>
        /// <param name="password">The organizational account password.</param>
        /// <param name="cache">The token cache to target during authentication.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginSilentAsync(string clientId, string domain, string username,
            string password, TokenCache cache)
        {
            return await LoginSilentAsync(clientId, domain, username, password, ActiveDirectoryServiceSettings.Azure, cache);
        }

        /// <summary>
        /// Log in to azure active directory in non-interactive mode using organizational id credentials and the default token cache.
        /// </summary>
        /// <param name="clientId">The active directory client id for this application.</param>
        /// <param name="domain">The active directory domain or tenant id to authenticate with.</param>
        /// <param name="username">The organizational account user name, given in the form of a user principal name (e.g. user1@contoso.org).</param>
        /// <param name="password">The organizational account password.</param>
        /// <param name="serviceSettings">The active directory service details, including authentication endpoints and the intended token audience.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginSilentAsync(string clientId, string domain, string username,
            string password, ActiveDirectoryServiceSettings serviceSettings)
        {
            return await LoginSilentAsync(clientId, domain, username, password, serviceSettings, TokenCache.DefaultShared);
        }
        
        /// <summary>
        /// Log in to azure active directory in non-interactive mode using organizational id credentials.
        /// </summary>
        /// <param name="clientId">The active directory client id for this application.</param>
        /// <param name="domain">The active directory domain or tenant id to authenticate with.</param>
        /// <param name="username">The organizational account user name, given in the form of a user principal name (e.g. user1@contoso.org).</param>
        /// <param name="password">The organizational account password.</param>
        /// <param name="serviceSettings">The active directory service details, including authentication endpoints and the intended token audience.</param>
        /// <param name="cache">The token cache to target during authentication.</param>
        /// <returns>A ServiceClientCredentials object that can be used to authenticate http requests using the given credentials.</returns>
        public static async Task<ServiceClientCredentials> LoginSilentAsync(string clientId, string domain, string username, string password, 
            ActiveDirectoryServiceSettings serviceSettings, TokenCache cache)
        {
            var credentials = new UserCredential(username, password);
            var authenticationContext = GetAuthenticationContext(domain, serviceSettings, cache);
            try
            {
                var authResult = await authenticationContext.AcquireTokenAsync(serviceSettings.TokenAudience.ToString(),
                      clientId, credentials).ConfigureAwait(false);
                return
                    new TokenCredentials(
                        new UserTokenProvider(authenticationContext, clientId,serviceSettings.TokenAudience, 
                                new UserIdentifier(username, UserIdentifierType.RequiredDisplayableId)),
                        authResult.TenantId,
                        authResult.UserInfo == null ? null : authResult.UserInfo.DisplayableId);
            }
            catch (AdalException ex)
            {
                throw new AuthenticationException(Resources.ErrorAcquiringToken, ex);
            }
            catch(FormatException ex)
            {
                throw new AuthenticationException(Resources.ErrorAcquiringToken, ex);
            }
        }

        // please remove this preprocessor #if whenever ADAL will go public with the new library 
#if PORTABLE
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
                                                                                serviceSettings.TokenAudience.ToString(),
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
                var authResult = await authenticationContext.AcquireTokenSilentAsync(serviceSettings.TokenAudience.ToString(),
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
