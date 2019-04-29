using Azure.Core.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Identity
{
    public class EnvironmentCredentialProvider : TokenCredentialProvider
    {
        private static readonly string s_AzureClientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");

        private static readonly string s_AzureTenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");

        private static readonly string s_AzureClientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");

        private TokenCredential _credential = null;

        public EnvironmentCredentialProvider()
        {
            if (s_AzureClientId != null && s_AzureTenantId != null && s_AzureClientSecret != null)
            {
                _credential = new ClientSecretCredential();
            }
        }

        protected override async ValueTask<TokenCredential> GetCredentialAsync(IEnumerable<string> scopes, CancellationToken cancellationToken)
        {
            await Task.CompletedTask.ConfigureAwait(false);

            return _credential;
        }
    }
}
