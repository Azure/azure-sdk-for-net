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
    public class AzureCredentials : ServiceClientCredentials
    {
        private string username, password;
        private string clientId, clientSecret;
        private string tenantId;
        private AzureEnvironment environment;
        private Func<DeviceCodeResult, bool> deviceCodeHandler;

        public TokenCache TokenCache { get; private set; }
        public string DefaultSubscriptionId { get; private set; }

        private AzureCredentials() {
            TokenCache = new TokenCache();
            environment = AzureEnvironment.AzureGlobalCloud;
        }

        public static AzureCredentials FromUser(string username, string password, string clientId, string tenantId, AzureEnvironment environment)
        {
            AzureCredentials credentials = new AzureCredentials()
            {
                username = username,
                password = password,
                clientId = clientId,
                tenantId = tenantId,
                environment = environment
            };
            return credentials;
        }

#if PORTABLE
        public static AzureCredentials FromDevice(string clientId, string tenantId, AzureEnvironment environment, Func<DeviceCodeResult, bool> deviceCodeHandler = null)
        {
            AzureCredentials credentials = new AzureCredentials()
            {
                clientId = clientId,
                tenantId = tenantId,
                environment = environment
            };
            return credentials;
        }
#endif

        public static AzureCredentials FromServicePrincipal(string clientId, string clientSecret, string tenantId, AzureEnvironment environment)
        {
            AzureCredentials credentials = new AzureCredentials()
            {
                clientId = clientId,
                clientSecret = clientSecret,
                tenantId = tenantId,
                environment = environment
            };
            return credentials;
        }

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

        public string TenantId { get { return tenantId; } }

        public string ClientId { get { return clientId; } }

        public AzureCredentials withTokenCache(TokenCache tokenCache)
        {
            TokenCache = tokenCache;
            return this;
        }

        public AzureCredentials WithDefaultSubscription(string subscriptionId)
        {
            DefaultSubscriptionId = subscriptionId;
            return this;
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var adSettings = new ActiveDirectoryServiceSettings
            {
                AuthenticationEndpoint = new Uri(environment.AuthenticationEndpoint),
                TokenAudience = new Uri(environment.ResourceManagerEndpoint),
                ValidateAuthority = true
            };
            string url = request.RequestUri.ToString();
            if (url.StartsWith(environment.GraphEndpoint, StringComparison.OrdinalIgnoreCase))
            {
                adSettings.TokenAudience = new Uri(environment.GraphEndpoint);
            }
            Task<ServiceClientCredentials> credentials;
            if (username != null && password != null)
            {
                credentials = UserTokenProvider.LoginSilentAsync(clientId, tenantId, username, password, adSettings, TokenCache);
            }
            else if (clientSecret != null)
            {
                credentials = ApplicationTokenProvider.LoginSilentAsync(tenantId, clientId, clientSecret, adSettings, TokenCache);
            }
#if PORTABLE
            else if (deviceCodeHandler != null)
            {
                credentials = UserTokenProvider.LoginByDeviceCodeAsync(clientId, deviceCodeHandler);
            }
#endif
            else
            {
                return Task.FromResult<object>(null);
            }
            return credentials.ContinueWith(cred => cred.Result.ProcessHttpRequestAsync(request, cancellationToken));
        }
    }
}