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
