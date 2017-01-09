// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Resource.Fluent.Authentication
{
    /// <summary>
    /// Credentials used for authenticating a fluent management client to Azure.
    /// </summary>
    public class AzureCredentials : ServiceClientCredentials
    {
        private string username;
        private string password;
        private string clientSecret;
        private IDictionary<Uri, ServiceClientCredentials> credentialsCache;
#if PORTABLE
        private Func<DeviceCodeResult, bool> deviceCodeHandler;
#endif

        public string DefaultSubscriptionId { get; private set; }

        public string TenantId { get; private set; }

        public string ClientId { get; private set; }

        public AzureEnvironment Environment { get; private set; }

        public AzureCredentials(string username, string password, string clientId, string tenantId, AzureEnvironment environment)
            : this()
        {
            this.username = username;
            this.password = password;
            ClientId = clientId;
            TenantId = tenantId;
            Environment = environment ?? AzureEnvironment.AzureGlobalCloud;
        }

        private AzureCredentials()
        {
            credentialsCache = new Dictionary<Uri, ServiceClientCredentials>();
        }

#if PORTABLE
        public AzureCredentials(string clientId, string tenantId, AzureEnvironment environment, Func<DeviceCodeResult, bool> deviceCodeFlowHandler)
        {
            ClientId = clientId;
            TenantId = tenantId;
            Environment = environment;
            this.deviceCodeHandler = deviceCodeFlowHandler;
        }
#endif

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