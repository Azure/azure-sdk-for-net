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

using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using System.Security;

namespace Microsoft.Azure.Common.Authentication
{
    public interface IAuthenticationFactory
    {
        /// <summary>
        /// Returns IAccessToken if authentication succeeds or throws an exception if authentication fails.
        /// </summary>
        /// <param name="account">The azure account object</param>
        /// <param name="environment">The azure environment object</param>
        /// <param name="tenant">The AD tenant in most cases should be 'common'</param>
        /// <param name="password">The AD account password</param>
        /// <param name="promptBehavior">The prompt behavior</param>
        /// <param name="tokenCache">Token Cache</param>
        /// <param name="resourceId">Optional, the AD resource id</param>
        /// <returns></returns>
        IAccessToken Authenticate(
            AzureAccount account, 
            AzureEnvironment environment, 
            string tenant, 
            SecureString password, 
            ShowDialog promptBehavior,
            TokenCache tokenCache,
            AzureEnvironment.Endpoint resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId);

        /// <summary>
        /// Returns IAccessToken if authentication succeeds or throws an exception if authentication fails.
        /// </summary>
        /// <param name="account">The azure account object</param>
        /// <param name="environment">The azure environment object</param>
        /// <param name="tenant">The AD tenant in most cases should be 'common'</param>
        /// <param name="password">The AD account password</param>
        /// <param name="promptBehavior">The prompt behavior</param>
        /// <param name="resourceId">Optional, the AD resource id</param>
        /// <returns></returns>
        IAccessToken Authenticate(
            AzureAccount account,
            AzureEnvironment environment,
            string tenant,
            SecureString password,
            ShowDialog promptBehavior,
            AzureEnvironment.Endpoint resourceId = AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId);

        SubscriptionCloudCredentials GetSubscriptionCloudCredentials(AzureContext context);
        SubscriptionCloudCredentials GetSubscriptionCloudCredentials(AzureContext context, AzureEnvironment.Endpoint targetEndpoint);
       
        ServiceClientCredentials GetServiceClientCredentials(AzureContext context);

        ServiceClientCredentials GetServiceClientCredentials(AzureContext context,
            AzureEnvironment.Endpoint targetEndpoint);
    }
}
