// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

//#if FullNetFx
namespace Microsoft.Rest.Azure.Authentication
{
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Rest.ClientRuntime.Azure.Authentication.Properties;
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class UserTokenProvider
    {
        #region Net 452
        // Interactive authentication is not implemented for CoreCLR.
#if net452
        /// <summary>
        /// The id of the active directory common tenant.
        /// </summary>
        //public const string UserCommonTenantId = "common";

        #region InteractiveLogin
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
            TaskScheduler scheduler;
            if (SynchronizationContext.Current != null)
            {
                scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            }
            else
            {
                scheduler = TaskScheduler.Current;
            }

            return await LoginWithPromptAsync(domain, clientSettings, serviceSettings, userId, cache, () => { return scheduler; }).ConfigureAwait(false);
        }

        /// <summary>
        /// Log in to Azure active directory with credentials provided by the user.  This call may display a credentials 
        /// dialog, depending on the supplied client settings and the state of the token cache and user cookies.
        /// </summary>
        /// <param name="domain">The domain to authenticate against.</param>
        /// <param name="clientSettings">The client settings to use for authentication. These determine when a dialog will be displayed.</param>
        /// <param name="serviceSettings">The settings for ad service, including endpoint and token audience</param>
        /// <param name="taskScheduler">Scheduler needed to run the task</param>
        /// <returns></returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(string domain, ActiveDirectoryClientSettings clientSettings,
            ActiveDirectoryServiceSettings serviceSettings, Func<TaskScheduler> taskScheduler)
        {
            return await LoginWithPromptAsync(domain, clientSettings, serviceSettings, UserIdentifier.AnyUser, TokenCache.DefaultShared, taskScheduler);
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
        /// <param name="taskScheduler">Scheduler needed to run the task</param>
        /// <returns></returns>
        public static async Task<ServiceClientCredentials> LoginWithPromptAsync(string domain, ActiveDirectoryClientSettings clientSettings,
            ActiveDirectoryServiceSettings serviceSettings, UserIdentifier userId, TokenCache cache, Func<TaskScheduler> taskScheduler)
        {
            var authenticationContext = GetAuthenticationContext(domain, serviceSettings, cache);
            var task = new Task<AuthenticationResult>(() =>
            {
                try
                {
                    var result = authenticationContext.AcquireToken(
                        serviceSettings.TokenAudience.OriginalString,
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

            task.Start(taskScheduler());
            var authResult = await task.ConfigureAwait(false);
            var newUserId = new UserIdentifier(authResult.UserInfo.DisplayableId,
                UserIdentifierType.RequiredDisplayableId);
            return new TokenCredentials(
                new UserTokenProvider(authenticationContext, clientSettings.ClientId, serviceSettings.TokenAudience, newUserId),
                authResult.TenantId,
                authResult.UserInfo.DisplayableId);
        }
        #endregion end of InteractiveLogin

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
                var authResult = await authenticationContext.AcquireTokenAsync(serviceSettings.TokenAudience.OriginalString,
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
#endif
        #endregion Net 452
    }
}
//#endif