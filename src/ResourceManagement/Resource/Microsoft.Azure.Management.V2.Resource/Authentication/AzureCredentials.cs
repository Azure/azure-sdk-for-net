// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Resource.Authentication
{
    /// <summary>
    /// Credentials used for authenticating a fluent management client to Azure.
    /// </summary>
    public class AzureCredentials : ServiceClientCredentials
    {
        private string username, password;
        private string clientSecret;
        private Func<DeviceCodeResult, bool> deviceCodeHandler;
        private IDictionary<Uri, ServiceClientCredentials> credentialsCache;

        public string DefaultSubscriptionId { get; private set; }

        public string TenantId { get; private set; }

        public string ClientId { get; private set; }

        public AzureEnvironment Environment { get; private set; }

        private AzureCredentials() 
        {
            Environment = AzureEnvironment.AzureGlobalCloud;
            credentialsCache = new Dictionary<Uri, ServiceClientCredentials>();
        }

        /// <summary>
        /// Creates a credentials object from a username/password combination.
        /// </summary>
        /// <param name="username">the user name</param>
        /// <param name="password">the associated password</param>
        /// <param name="clientId">the client ID of the application</param>
        /// <param name="tenantId">the tenant ID or domain the user is in</param>
        /// <param name="environment">the environment to authenticate to</param>
        /// <returns>an authenticated credentials object</returns>
        public static AzureCredentials FromUser(string username, string password, string clientId, string tenantId, AzureEnvironment environment)
        {
            AzureCredentials credentials = new AzureCredentials()
            {
                username = username,
                password = password,
                ClientId = clientId,
                TenantId = tenantId,
                Environment = environment
            };
            return credentials;
        }

#if PORTABLE
        /// <summary>
        /// Creates a credentials object through device flow.
        /// </summary>
        /// <param name="clientId">the client ID of the application</param>
        /// <param name="tenantId">the tenant ID or domain</param>
        /// <param name="environment">the environment to authenticate to</param>
        /// <param name="deviceCodeHandler">a user defined function to handle device flow</param>
        /// <returns>an authenticated credentials object</returns>
        public static AzureCredentials FromDevice(string clientId, string tenantId, AzureEnvironment environment, Func<DeviceCodeResult, bool> deviceCodeHandler = null)
        {
            AzureCredentials credentials = new AzureCredentials()
            {
                ClientId = clientId,
                TenantId = tenantId,
                Environment = environment
            };
            return credentials;
        }
#endif

        /// <summary>
        /// Creates a credentials object from a service principal.
        /// </summary>
        /// <param name="clientId">the client ID of the application the service principal is associated with</param>
        /// <param name="clientSecret">the secret for the client ID</param>
        /// <param name="tenantId">the tenant ID or domain the application is in</param>
        /// <param name="environment">the environment to authenticate to</param>
        /// <returns>an authenticated credentials object</returns>
        public static AzureCredentials FromServicePrincipal(string clientId, string clientSecret, string tenantId, AzureEnvironment environment)
        {
            AzureCredentials credentials = new AzureCredentials()
            {
                clientSecret = clientSecret,
                ClientId = clientId,
                TenantId = tenantId,
                Environment = environment
            };
            return credentials;
        }

        /// <summary>
        /// Creates a credentials object from a file in the following format:
        /// 
        ///     subscription=&lt;subscription-id&gt;
        ///     tenant=&lt;tenant-id&gt;
        ///     client=&lt;client-id&gt;
        ///     key=&lt;client-key&gt;
        ///     managementURI=&lt;management-URI&gt;
        ///     baseURL=&lt;base-URL&gt;
        ///     authURL=&lt;authentication-URL&gt;
        /// </summary>
        /// <param name="authFile">the path to the file</param>
        /// <returns>an authenticated credentials object</returns>
        public static AzureCredentials FromFile(string authFile)
        {
            var config = new Dictionary<string, string>()
            {
                { "authurl", AzureEnvironment.AzureGlobalCloud.AuthenticationEndpoint },
                { "baseurl", AzureEnvironment.AzureGlobalCloud.ResourceManagerEndpoint },
                { "managementuri", AzureEnvironment.AzureGlobalCloud.ManagementEnpoint }
            };

            File.ReadLines(authFile)
                .All(line =>
                {
                    var keyVal = line.Trim().Split(new char[] { '=' }, 2);
                    config[keyVal[0].ToLowerInvariant()] = keyVal[1];
                    return true;
                });

            var env = new AzureEnvironment()
            {
                AuthenticationEndpoint = config["authurl"].Replace("\\", ""),
                ManagementEnpoint = config["managementuri"].Replace("\\", ""),
                ResourceManagerEndpoint = config["baseurl"].Replace("\\", ""),
                GraphEndpoint = config.ContainsKey("graphurl") ? config["graphurl"].Replace("\\", "") : "https://graph.windows.net"
            };

            AzureCredentials credentials = FromServicePrincipal(config["client"], config["key"], config["tenant"], env);
            credentials.WithDefaultSubscription(config["subscription"]);
            return credentials;
        }
        
        public AzureCredentials WithDefaultSubscription(string subscriptionId)
        {
            DefaultSubscriptionId = subscriptionId;
            return this;
        }

        public async override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var adSettings = new ActiveDirectoryServiceSettings
            {
                AuthenticationEndpoint = new Uri(Environment.AuthenticationEndpoint),
                TokenAudience = new Uri(Environment.ResourceManagerEndpoint),
                ValidateAuthority = true
            };
            string url = request.RequestUri.ToString();
            if (url.StartsWith(Environment.GraphEndpoint, StringComparison.OrdinalIgnoreCase))
            {
                adSettings.TokenAudience = new Uri(Environment.GraphEndpoint);
            }

            if (!credentialsCache.ContainsKey(adSettings.TokenAudience))
            {
                if (username != null && password != null)
                {
                    credentialsCache[adSettings.TokenAudience] = await UserTokenProvider.LoginSilentAsync(
                        ClientId, TenantId, username, password, adSettings, TokenCache.DefaultShared);
                }
                else if (clientSecret != null)
                {
                    credentialsCache[adSettings.TokenAudience] = await ApplicationTokenProvider.LoginSilentAsync(
                        TenantId, ClientId, clientSecret, adSettings, TokenCache.DefaultShared);
                }
#if PORTABLE
                else if (deviceCodeHandler != null)
                {
                    credentialsCache[adSettings.TokenAudience] = await UserTokenProvider.LoginByDeviceCodeAsync(
                        ClientId, TenantId, adSettings, TokenCache.DefaultShared, deviceCodeHandler);
                }
#endif
            }
            await credentialsCache[adSettings.TokenAudience].ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}