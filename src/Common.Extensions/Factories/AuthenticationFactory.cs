// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Common.Extensions.Authentication;
using Microsoft.Azure.Common.Extensions.Models;
using Microsoft.Azure.Common.Extensions.Properties;
using Microsoft.WindowsAzure;
using System;
using System.Linq;
using System.Security;

namespace Microsoft.Azure.Common.Extensions.Factories
{
    public class AuthenticationFactory : IAuthenticationFactory
    {
        public const string CommonAdTenant = "Common";

        public AuthenticationFactory()
        {
            TokenProvider = new AdalTokenProvider();
        }

        public ITokenProvider TokenProvider { get; set; }

        public IAccessToken Authenticate(AzureAccount account, AzureEnvironment environment, string tenant, SecureString password, ShowDialog promptBehavior)
        {
            var token = TokenProvider.GetAccessToken(GetAdalConfiguration(environment, tenant), promptBehavior, account.Id, password, account.Type);
            account.Id = token.UserId;
            return token;
        }

        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(AzureContext context)
        {
            if (context.Subscription == null)
            {
                throw new ApplicationException(Resources.InvalidCurrentSubscription);
            }
            
            if (context.Account == null)
            {
                throw new ArgumentException(Resources.InvalidSubscriptionState);
            }

            if (context.Account.Type == AzureAccount.AccountType.Certificate)
            {
                var certificate = ProfileClient.DataStore.GetCertificate(context.Account.Id);
                return new CertificateCloudCredentials(context.Subscription.Id.ToString(), certificate);
            }

            var tenant = context.Subscription.GetPropertyAsArray(AzureSubscription.Property.Tenants)
                  .Intersect(context.Account.GetPropertyAsArray(AzureAccount.Property.Tenants))
                  .FirstOrDefault();

            if (tenant == null)
            {
                throw new ArgumentException(Resources.InvalidSubscriptionState);
            }

            try
            {
                var token = Authenticate(context.Account, context.Environment, tenant, null, ShowDialog.Never);
                return new AccessTokenCredential(context.Subscription.Id, token);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(Resources.InvalidSubscriptionState, ex);
            }
        }

        private AdalConfiguration GetAdalConfiguration(AzureEnvironment environment, string tenantId)
        {
            if (environment == null)
            {
                throw new ArgumentNullException("environment");
            }
            var adEndpoint = environment.Endpoints[AzureEnvironment.Endpoint.ActiveDirectory];
            var adResourceId = environment.Endpoints[AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId];

            return new AdalConfiguration
            {
                AdEndpoint = adEndpoint,
                ResourceClientUri = adResourceId,
                AdDomain = tenantId
            };
        }
    }
}
