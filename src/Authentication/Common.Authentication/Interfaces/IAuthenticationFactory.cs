// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
