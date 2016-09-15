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
    public class ApplicationTokenCredentials : ServiceClientCredentials
    {
        private string tenantId;
        private string clientId;
        private string clientSecret;
        public TokenCache TokenCache { get; private set; }
        public string DefaultSubscriptionId { get; private set; }

        private ActiveDirectoryServiceSettings activeDirectoryServiceSettings;

        public ApplicationTokenCredentials(AzureEnvironment environment, string tenantId, string clientId, string clientSecret)
        {
            Init(environment, tenantId, clientId, clientSecret);
        }

        public ApplicationTokenCredentials(string tenantId, string clientId, string clientSecret) : this(AzureEnvironment.AzureGlobalCloud, tenantId, clientId, clientSecret)
        { }

        public ApplicationTokenCredentials(string authFile)
        {
            Dictionary<string, string> config = new Dictionary<string, string>() {
                { "authurl", AzureEnvironment.AzureGlobalCloud.AuthenticationEndpoint },
                { "baseurl", AzureEnvironment.AzureGlobalCloud.ResourceManagerEndpoint },
                { "managementuri", AzureEnvironment.AzureGlobalCloud.TokenAudience }
            };

            File.ReadLines(authFile)
                .All(line =>
                {
                    var keyVal = line.Trim().Split(new char[] { '=' }, 2);
                    config[keyVal[0].ToLowerInvariant()] = keyVal[1];
                    return true;
                });

            Init(new AzureEnvironment
            {
                AuthenticationEndpoint = config["authurl"].Replace("\\", ""),
                TokenAudience = config["managementuri"].Replace("\\", ""),
                ResourceManagerEndpoint = config["baseurl"].Replace("\\", "")
            }, config["tenant"], config["client"], config["key"]);
            WithDefaultSubscription(config["subscription"]);
        }

        private void Init(AzureEnvironment environment, string tenantId, string clientId, string clientSecret)
        {
            this.tenantId = tenantId;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            activeDirectoryServiceSettings = new ActiveDirectoryServiceSettings
            {
                AuthenticationEndpoint = new Uri(environment.AuthenticationEndpoint),
                TokenAudience = new Uri(environment.TokenAudience),
                ValidateAuthority = true
            };
            TokenCache = new TokenCache(); // Default to in-memory cache
        }

        public ApplicationTokenCredentials withTokenCache(TokenCache tokenCache)
        {
            TokenCache = tokenCache;
            return this;
        }

        public ApplicationTokenCredentials WithDefaultSubscription(string subscriptionId)
        {
            DefaultSubscriptionId = subscriptionId;
            return this;
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            ServiceClientCredentials credentials = ApplicationTokenProvider.LoginSilentAsync(tenantId,
                clientId,
                clientSecret,
                activeDirectoryServiceSettings,
                TokenCache).ConfigureAwait(false).GetAwaiter().GetResult();
            return credentials.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}