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

using Microsoft.Azure;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Rest;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Mocks
{
    public class MockCertificateAuthenticationFactory : IAuthenticationFactory
    {
        public X509Certificate2 Certificate { get; set; }

        public MockCertificateAuthenticationFactory()
        {
            Certificate = new X509Certificate2();
        }

        public MockCertificateAuthenticationFactory(string userId, X509Certificate2 certificate)
        {
            Certificate = certificate;
        }

        public IAccessToken Authenticate(
            AzureAccount account, 
            AzureEnvironment environment, 
            string tenant, 
            SecureString password, 
            ShowDialog promptBehavior, 
            IdentityModel.Clients.ActiveDirectory.TokenCache tokenCache, 
            AzureEnvironment.Endpoint resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            if (account.Id == null)
            {
                account.Id = "test";
            }

            var token = new MockAccessToken
            {
                UserId = account.Id,
                LoginType = LoginType.OrgId,
                AccessToken = "123"
            };

            return token;
        }

        public IAccessToken Authenticate(
            AzureAccount account, 
            AzureEnvironment environment, 
            string tenant, 
            SecureString password, 
            ShowDialog promptBehavior,
            AzureEnvironment.Endpoint resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId)
        {
            return Authenticate(account, environment, tenant, password, promptBehavior, AzureSession.TokenCache, resourceId);
        }

        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(AzureContext context)
        {
            return new CertificateCloudCredentials(context.Subscription.Id.ToString(), Certificate);
        }

         public ServiceClientCredentials GetServiceClientCredentials(AzureContext context)
        {
            return GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager);
        }


        public ServiceClientCredentials GetServiceClientCredentials(AzureContext context, AzureEnvironment.Endpoint targetEndpoint)
        {
            throw new System.NotImplementedException();
        }


        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(AzureContext context, AzureEnvironment.Endpoint targetEndpoint)
        {
            return new CertificateCloudCredentials(context.Subscription.Id.ToString(), Certificate);
        }
    }
}
