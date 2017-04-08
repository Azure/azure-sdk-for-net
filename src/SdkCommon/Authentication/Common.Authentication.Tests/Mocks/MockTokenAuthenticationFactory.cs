// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Rest;
using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Mocks
{
    public class MockTokenAuthenticationFactory : IAuthenticationFactory
    {
        public IAccessToken Token { get; set; }

        public Func<AzureAccount, AzureEnvironment, string, IAccessToken> TokenProvider { get; set; }

        public MockTokenAuthenticationFactory()
        {
            Token = new MockAccessToken
            {
                UserId = "Test",
                LoginType = LoginType.OrgId,
                AccessToken = "abc"
            };

            TokenProvider = (account, environment, tenant) => Token = new MockAccessToken
            {
                UserId = account.Id,
                LoginType = LoginType.OrgId,
                AccessToken = Token.AccessToken
            };
        }

        public MockTokenAuthenticationFactory(string userId, string accessToken)
        {
            Token = new MockAccessToken
            {
                UserId = userId,
                LoginType = LoginType.OrgId,
                AccessToken = accessToken
            };
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

            return TokenProvider(account, environment, tenant);
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
            return new AccessTokenCredential(context.Subscription.Id, Token);
        }

        public ServiceClientCredentials GetServiceClientCredentials(AzureContext context)
        {
            return GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager);
        }


        public ServiceClientCredentials GetServiceClientCredentials(AzureContext context, AzureEnvironment.Endpoint targetEndpoint)
        {
            return new TokenCredentials(Token.AccessToken);
        }


        public SubscriptionCloudCredentials GetSubscriptionCloudCredentials(AzureContext context, AzureEnvironment.Endpoint targetEndpoint)
        {
            return new AccessTokenCredential(context.Subscription.Id, Token);
        }
    }
}
