// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Factories;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using Xunit;

namespace Common.Authentication.Test
{
    public class AuthenticationFactoryTests
    {
        [Fact]
        public void VerifySubscriptionTokenCacheRemove()
        {
            var authFactory = new AuthenticationFactory
            {
                TokenProvider = new MockAccessTokenProvider("testtoken", "testuser")
            };

            var subscriptionId = Guid.NewGuid();

            var credential = authFactory.GetSubscriptionCloudCredentials(new AzureContext
            (
                new AzureSubscription
                {
                    Id = subscriptionId,
                    Properties = new Dictionary<AzureSubscription.Property, string>
                    {
                        { AzureSubscription.Property.Tenants, "123"}
                    }
                },
                new AzureAccount
                {
                    Id = "testuser",
                    Type = AzureAccount.AccountType.User,
                    Properties = new Dictionary<AzureAccount.Property, string>
                    {
                        { AzureAccount.Property.Tenants, "123" }
                    }
                },
                AzureEnvironment.PublicEnvironments["AzureCloud"]
            ));

            Assert.True(credential is AccessTokenCredential);
            Assert.Equal(subscriptionId, new Guid(((AccessTokenCredential)credential).SubscriptionId));
        }

        [Fact]
        public void VerifyValidateAuthorityFalseForOnPremise()
        {
            var authFactory = new AuthenticationFactory
            {
                TokenProvider = new MockAccessTokenProvider("testtoken", "testuser")
            };

            var subscriptionId = Guid.NewGuid();
            var context = new AzureContext
            (
                new AzureSubscription
                {
                    Id = subscriptionId,
                    Properties = new Dictionary<AzureSubscription.Property, string>
                    {
                        { AzureSubscription.Property.Tenants, "123"}
                    }
                },
                new AzureAccount
                {
                    Id = "testuser",
                    Type = AzureAccount.AccountType.User,
                    Properties = new Dictionary<AzureAccount.Property, string>
                    {
                        { AzureAccount.Property.Tenants, "123" }
                    }
                },
                new AzureEnvironment
                {
                    Name = "Katal",
                    OnPremise = true,
                    Endpoints = new Dictionary<AzureEnvironment.Endpoint, string>
                    {
                        { AzureEnvironment.Endpoint.ActiveDirectory, "http://ad.com" },
                        { AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId, "http://adresource.com" }
                    }
                }
            );

            var credential = authFactory.Authenticate(context.Account, context.Environment, "common", null, ShowDialog.Always);
           
            Assert.False(((MockAccessTokenProvider)authFactory.TokenProvider).AdalConfiguration.ValidateAuthority);            
        }
    }
}
