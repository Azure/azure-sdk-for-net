using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.Azure.Authentication;
using System.IO;

namespace Microsoft.Azure.Management.V2.Resource.Authentication
{
    public class ApplicationTokenCredentails : ServiceClientCredentials
    {
        private string tenantId;
        private string clientId;
        private string clientSecret;
        public TokenCache TokenCache { get; private set; }
        public string SubscriptionId { get; private set; }

        private ActiveDirectoryServiceSettings activeDirectoryServiceSettings;

        public ApplicationTokenCredentails(AzureEnvironment environment, string tenantId, string clientId, string clientSecret)
        {
            Init(environment, tenantId, clientId, clientSecret);
        }

        public ApplicationTokenCredentails(string tenantId, string clientId, string clientSecret) : this(AzureEnvironment.AzureGlobalCloud, tenantId, clientId, clientSecret)
        { }

        public ApplicationTokenCredentails(string authFile)
        {
            Dictionary<string, string> config = new Dictionary<string, string>() {
                { "authurl", AzureEnvironment.AzureGlobalCloud.AuthenticationEndpoint },
                { "baseurl", AzureEnvironment.AzureGlobalCloud.ResourceManagerEndpoint },
                { "managementuri", AzureEnvironment.AzureGlobalCloud.TokenAuidence }
            };

            File.ReadLines(authFile)
                .All(line => {
                    var keyVal = line.Trim().Split(new char[] { '=' }, 2);
                    config[keyVal[0].ToLowerInvariant()] = keyVal[1];
                    return true;
                });

            Init(new AzureEnvironment
            {
                AuthenticationEndpoint = config["authurl"].Replace("\\", ""),
                TokenAuidence = config["managementuri"].Replace("\\", ""),
                ResourceManagerEndpoint = config["baseurl"].Replace("\\", "")
            }, config["tenant"], config["client"], config["key"]);
            WithSubscription(config["subscription"]);
        }

        private void Init(AzureEnvironment environment, string tenantId, string clientId, string clientSecret)
        {
            this.tenantId = tenantId;
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            activeDirectoryServiceSettings = new ActiveDirectoryServiceSettings
            {
                AuthenticationEndpoint = new Uri(environment.AuthenticationEndpoint),
                TokenAudience = new Uri(environment.TokenAuidence),
                ValidateAuthority = true
            };
            TokenCache = new TokenCache(); // Default to in-memory cache
        }

        public ApplicationTokenCredentails withTokenCache(TokenCache tokenCache)
        {
            TokenCache = tokenCache;
            return this;
        }

        public ApplicationTokenCredentails WithSubscription(string subscriptionId)
        {
            SubscriptionId = subscriptionId;
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
