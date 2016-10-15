// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.Azure.Authentication;

namespace Microsoft.Rest
{
    public static class ClientContextExtensions
    {
        private const string TenantIdKey = "TenantId";
        private const string ServiceSettingsKey = "ActiveDirectoryServiceSettings";
        private const string ClientSettingsKey = "ActiveDirectoryClientSettngs";
        private static readonly Uri AzureChinaCloudBaseUri = new Uri("https://management.chinacloudapi.cn/");
        private static readonly Uri AzureGermanCloudBaseUri = new Uri("https://management.microsoftazure.de/");
        private static readonly Uri AzureUSGovernmentCloudBaseUri = new Uri("https://management.usgovcloudapi.net/");

        /// <summary>
        /// Get the token cache from the current context.
        /// </summary>
        /// <param name="context">The context to check for a Token Cache.</param>
        /// <returns>The TokenCache for the current context, or none if no TokenCache is available.</returns>
        public static TokenCache GetTokenCache(this IClientContext context)
        {
            return GetExtendedValue<TokenCache>(context, nameof(TokenCache), TokenCache.DefaultShared);
        }

        /// <summary>
        /// Add the given TokenCache to the context and return the resulting context
        /// </summary>
        /// <param name="context">The context to add the TokenCache to</param>
        /// <param name="cache">The TokenCache to add to the context</param>
        /// <returns>The context with the given TokenCache added.</returns>
        public static IClientContext WithTokenCache(this IClientContext context, TokenCache cache)
        {
            return SetExtendedValue(context, nameof(TokenCache), cache);
        }

        /// <summary>
        /// Get Active Directory service settings (active directory endpoint, token audience)
        /// </summary>
        /// <param name="context">The context to get the AD service settings from.</param>
        /// <returns>The active directory service settings for this context.</returns>
        public static ActiveDirectoryServiceSettings GetServiceSettings(this IClientContext context)
        {
            var defaultSettings = context.HttpClient != null
                ? GetMatchingSettingsByUri(context.HttpClient.BaseAddress)
                : ActiveDirectoryServiceSettings.Azure;
            return GetExtendedValue<ActiveDirectoryServiceSettings>(context, ServiceSettingsKey, defaultSettings);
        }

        /// <summary>
        /// Add the given Active Directory service settings to the context and return the resulting context.
        /// </summary>
        /// <param name="context">The context to change.</param>
        /// <param name="settings">The settings to add to the context.</param>
        /// <returns></returns>
        public static IClientContext WithServiceSettings(this IClientContext context, ActiveDirectoryServiceSettings settings)
        {
            return SetExtendedValue(context, ServiceSettingsKey, settings);
        }

        /// <summary>
        /// Get Active Directory client settings (prompt behavior, client id, client redirect uri)
        /// </summary>
        /// <param name="context">The context to get the AD service settings from.</param>
        /// <returns>The active directory service settings for this context.</returns>
        public static ActiveDirectoryClientSettings GetClientSettings(this IClientContext context)
        {
            return GetExtendedValue<ActiveDirectoryClientSettings>(context, ClientSettingsKey,
                ActiveDirectoryClientSettings.UseCacheCookiesOrPrompt("1950a258-227b-4e31-a9cf-717495945fc2", 
                new Uri("urn:ietf:wg:oauth:2.0:oob")));
        }

        /// <summary>
        /// Add the given Active Directory service settings to the context and return the resulting context.
        /// </summary>
        /// <param name="context">The context to change.</param>
        /// <param name="settings">The settings to add to the context.</param>
        /// <returns></returns>
        public static IClientContext WithClientSettings(this IClientContext context,
            ActiveDirectoryClientSettings settings)
        {
            return context.SetExtendedValue(ClientSettingsKey, settings);
        }

        /// <summary>
        /// Get the Tenant Id for the authentication in this context.  This value is private, 
        /// it can only be set through one of the login methods
        /// </summary>
        /// <param name="context">The context to get the Tenant Id from.</param>
        /// <returns>The tenant Id used for authentication in this context</returns>
        private static string GetTenantId(this IClientContext context)
        {
            return GetExtendedValue<string>(context, TenantIdKey, "Common");
        }

        /// <summary>
        /// Add the given tenant id to the given context.
        /// </summary>
        /// <param name="context">The context to alter.</param>
        /// <param name="tenantId">The tenant id to add to the context.</param>
        /// <returns></returns>
        private static IClientContext WithTenantId(this IClientContext context, string tenantId)
        {
            return SetExtendedValue(context, TenantIdKey, tenantId);
        }

        /// <summary>
        /// Get the client Id used in this context.
        /// </summary>
        /// <param name="context">The context to retrieve data from.</param>
        /// <returns>The client id used in the context.</returns>
        public static string GetClientId(this IClientContext context)
        {
            return context.GetClientSettings()?.ClientId;
        }

        /// <summary>
        /// Add the given client Id to the context
        /// </summary>
        /// <param name="context">The context to add the client id to.</param>
        /// <param name="clientId">The client Id to add to the context.</param>
        /// <returns>The context with client id added.</returns>
        public static IClientContext WithClientId(this IClientContext context, string clientId)
        {
            var settings = context.GetClientSettings();
            if (settings != null)
            {
                settings.ClientId = clientId;
            }

            return context;
        }

        /// <summary>
        /// Get the redirect uri used for authentication in this context.
        /// </summary>
        /// <param name="context">The context to retrieve information from.</param>
        /// <returns>The redirect uri used for authentication in this context.</returns>
        public static Uri GetRedirectUri(this IClientContext context)
        {
            return context.GetClientSettings()?.ClientRedirectUri;
        }

        /// <summary>
        /// Set the redirect uri to use for authentication in this context. This value is only used with 
        /// prompt-based authentication.
        /// </summary>
        /// <param name="context">The context to alter.</param>
        /// <param name="redirectUri">The redirect URI to use for authentication in this context.</param>
        /// <returns>The context with redirect uri added.</returns>
        public static IClientContext WithRedirectUri(this IClientContext context, Uri redirectUri)
        {
            var settings = context.GetClientSettings();
            if (settings != null)
            {
                settings.ClientRedirectUri = redirectUri;
            }

            return context;
        }

        /// <summary>
        /// Set the given value in the given context.  The value is placed in the extended proeprties dictionary of the context.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="context">The context to alter.</param>
        /// <param name="name">The name of the property to set.</param>
        /// <param name="value">The value to set for the property.</param>
        /// <returns>The context with the new property added.</returns>
        private static IClientContext SetExtendedValue<T>(this IClientContext context, string name, T value) where T : class
        {
            context.ExtendedProperties[name] = value;
            return context;
        }

        /// <summary>
        /// Get the given extended property in the given context.  If a default value is passed and the context does not contain
        /// the given property, the properrty is added to the context with the defautl value as its value.
        /// </summary>
        /// <typeparam name="T">The type of the value expected.</typeparam>
        /// <param name="context">The context to retrieve information from.</param>
        /// <param name="name">The name of the property to retrieve.</param>
        /// <param name="defaultValue">The default value for the property if none is set in the context.</param>
        /// <returns>The value of the property in the context.</returns>
        private static T GetExtendedValue<T>(IClientContext context, string name, T defaultValue = null) where T : class
        {
            T returnValue = context.ExtendedProperties.ContainsKey(name) ? context.ExtendedProperties[name] as T : null;
            if (returnValue == null && defaultValue != null)
            {
                SetExtendedValue(context, name, defaultValue);
                returnValue = defaultValue;
            }

            return returnValue;
        }

#if (NETSTANDARD1_1 || NETSTANDARD1_5)

        /// <summary>
        /// Log in using a device code in a console app.  In this login flow, you must open a browser to https://aka.ms/devicelogin 
        /// and input the test code as instructed by the test displayed in the console window. This overload should 
        /// only be used in console applications.
        /// </summary>
        /// <param name="context">The context to use for authentication.</param>
        public static void LoginByDeviceCode(this IClientContext context)
        {
             context.LoginByDeviceCode(
               (d) =>
                 {
                     Console.WriteLine(d);
                     return true;
                 });
        }

        /// <summary>
        /// Log in using a device code.  In this login flow, you must open a browser to https://aka.ms/devicelogin 
        /// and input the test code ras instructed by the test displayed in the console window. Instructions for browser login are 
        /// sent to the promptPredicate function delegate you pass in - the user must follow these directions for login to complete.
        /// </summary>
        /// <param name="context">The context to use for authentication.</param>
        /// <param name="promptPredicate">A function that receives a login instructions prompt.  The function should 
        /// display this prompt to the user, and the user must follow the directions in the prompt to log in.</param>
        public static void LoginByDeviceCode(this IClientContext context, Func<string, bool> promptPredicate)
        {
             context.LoginByDeviceCode(context.GetTenantId(), promptPredicate);
        }
        
        /// <summary>
        /// Log in using a device code.  In this login flow, you must open a browser to https://aka.ms/devicelogin 
        /// and input the test code ras instructed by the test displayed in the console window. Instructions for browser login are 
        /// sent to the promptPredicate function delegate you pass in - the user must follow these directions for login to complete.
        /// </summary>
        /// <param name="context">The context to use for authentication.</param>
        /// <param name="domain">The tenantId or domain name to login to.</param>
        /// <param name="promptPredicate">A function that receives a login instructions prompt.  The function should 
        /// display this prompt to the user, and the user must follow the directions in the prompt to log in.</param>
        public static void LoginByDeviceCode(this IClientContext context, string domain, Func<string, bool> promptPredicate)
        {
            context
              .WithTenantId(domain)
              .Credentials = UserTokenProvider.LoginByDeviceCodeAsync(context.GetClientId(), domain, 
                context.GetServiceSettings(), context.GetTokenCache(),
                 (d) =>
                 {
                     return promptPredicate(d.Message);
                 }).ConfigureAwait(false).GetAwaiter().GetResult();
        }
#else
        /// <summary>
        /// log in to active directory using a pop-up browser dialog for credentials.
        /// </summary>
        /// <param name="context">The context to use for authentication.</param>
        public static void LoginWithPrompt(this IClientContext context)
        {
            context.Credentials =
                UserTokenProvider.LoginWithPromptAsync(context.GetClientSettings(), context.GetTokenCache())
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();
        }

        /// <summary>
        /// log in to active directory using a pop-up browser dialog for credentials.
        /// </summary>
        /// <param name="context">The context to use for authentication.</param>
        /// <param name="userId">The user id to use when logging in.</param>
        public static void LoginWithPrompt(this IClientContext context, string userId)
        {
            context
              .Credentials =
                UserTokenProvider.LoginWithPromptAsync(context.GetClientSettings(), userId,
                  context.GetTokenCache())
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();
        }
#endif
        /// <summary>
        /// Login using a username and password credential.  Note that this login method can only be used with 
        /// work or school accounts that do not have mulit-factor authentication (MFA) enabled.
        /// </summary>
        /// <param name="context">The context to use for authentication.</param>
        /// <param name="userName">The work or school user account to use for log in.</param>
        /// <param name="password">The password associated with this account.</param>
        public static void LoginWithUserCredential(this IClientContext context,
            string userName, string password)
        {
            context.LoginWithUserCredential(context.GetTenantId(), userName, password);
        }

        /// <summary>
        /// Login using a username and password credential.  Note that this login method can only be used with 
        /// work or school accounts that do not have mulit-factor authentication (MFA) enabled.
        /// </summary>
        /// <param name="context">The context to use for authentication.</param>
        /// <param name="tenantId">The Active Directory tenant id to log in against.</param>
        /// <param name="userName">The work or school user account to use for log in.</param>
        /// <param name="password">The password associated with this account.</param>
        public static void LoginWithUserCredential(this IClientContext context, string tenantId,
            string userName, string password)
        {
            context.WithTenantId(tenantId)
              .Credentials =
                UserTokenProvider.LoginSilentAsync(context.GetClientId(), tenantId, userName, password,
                    context.GetServiceSettings(), context.GetTokenCache())
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();
        }

        /// <summary>
        /// Login to active directory in this context as a service principal
        /// </summary>
        /// <param name="context">The context to log in to.</param>
        /// <param name="domain">The domain name or tenant id to log in to.</param>
        /// <param name="servicePrincipalName">The service principal name for the application you are logging in as. 
        /// this value is also called clientId.</param>
        /// <param name="secret">The secret key credential associated with this service principal account</param>
        public static void LoginWithSpnCredential(this IClientContext context, string domain, string servicePrincipalName, string secret)
        {
            context.WithTenantId(domain)
            .WithClientId(servicePrincipalName)
            .Credentials =
                ApplicationTokenProvider.LoginSilentAsync(domain, new ClientCredential(servicePrincipalName, secret),
                    context.GetServiceSettings(), context.GetTokenCache())
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();
        }

        /// <summary>
        /// Get active directory service settings for known endpoints
        /// </summary>
        /// <param name="baseUri"></param>
        /// <returns>Service settings to match the given base uri</returns>
        private static ActiveDirectoryServiceSettings GetMatchingSettingsByUri(Uri baseUri)
        {
            var settings = ActiveDirectoryServiceSettings.Azure;
            if (baseUri != null)
            {
                if (string.Equals(baseUri.Authority, AzureChinaCloudBaseUri.Authority,
                    StringComparison.OrdinalIgnoreCase))
                {
                    settings = ActiveDirectoryServiceSettings.AzureChina;
                }
                else if (string.Equals(baseUri.Authority, AzureGermanCloudBaseUri.Authority,
                    StringComparison.OrdinalIgnoreCase))
                {
                    settings = ActiveDirectoryServiceSettingsConstants.AzureGermanCloud;
                }
                else if (string.Equals(baseUri.Authority, AzureUSGovernmentCloudBaseUri.Authority,
                    StringComparison.OrdinalIgnoreCase))
                {
                    settings = ActiveDirectoryServiceSettingsConstants.AzureUSGovernmentCloud;
                }
            }

            return settings;
        }
    }
}
