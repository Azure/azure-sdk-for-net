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

        [Fact]
        public void RefreshAuthenticationWithInvalidAccountFails()
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
                    Type = AzureAccount.AccountType.RefreshToken,
                    Properties = new Dictionary<AzureAccount.Property, string>
                    {
                        { AzureAccount.Property.Tenants, "123" },
                        { AzureAccount.Property.RefreshClientId, Guid.NewGuid().ToString()}
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

            var exception = Assert.Throws<InvalidOperationException>(() => authFactory.Authenticate(
                context.Account, context.Environment, "common", null, ShowDialog.Never));
            Assert.Contains("RefreshToken", exception.Message);
            var exception2 = Assert.Throws<ArgumentException>(() => authFactory.GetSubscriptionCloudCredentials(
                context, AzureEnvironment.Endpoint.ResourceManager));
            Assert.NotNull(exception2.InnerException);
            Assert.Equal<Type>(exception2.InnerException.GetType(), typeof(InvalidOperationException));
            Assert.Contains("RefreshToken", exception2.InnerException.Message);
            var exception3 = Assert.Throws<ArgumentException>(() => authFactory.GetServiceClientCredentials(
                context, AzureEnvironment.Endpoint.ResourceManager));
            Assert.NotNull(exception3.InnerException);
            Assert.Equal<Type>(exception3.InnerException.GetType(), typeof(InvalidOperationException));
            Assert.Contains("RefreshToken", exception3.InnerException.Message);

            context = new AzureContext(context.Subscription, new AzureAccount
            {
                Id = "testuser",
                Type = AzureAccount.AccountType.RefreshToken,
                Properties = new Dictionary<AzureAccount.Property, string>
                {
                    {AzureAccount.Property.Tenants, "123"},
                    {AzureAccount.Property.RefreshToken, Guid.NewGuid().ToString()}
                }
            },
            context.Environment);

            exception = Assert.Throws<InvalidOperationException>(() => authFactory.Authenticate(
            context.Account, context.Environment, "common", null, ShowDialog.Never));
            Assert.Contains("RefreshToken", exception.Message);
            Assert.Contains("application ID", exception.Message);
            exception2 = Assert.Throws<ArgumentException>(() => authFactory.GetSubscriptionCloudCredentials(
                context, AzureEnvironment.Endpoint.ResourceManager));
            Assert.NotNull(exception2.InnerException);
            Assert.Equal<Type>(exception2.InnerException.GetType(), typeof(InvalidOperationException));
            Assert.Contains("application ID", exception2.InnerException.Message);
            Assert.Contains("RefreshToken", exception2.InnerException.Message);
            exception3 = Assert.Throws<ArgumentException>(() => authFactory.GetServiceClientCredentials(
                context, AzureEnvironment.Endpoint.ResourceManager));
            Assert.NotNull(exception3.InnerException);
            Assert.Equal<Type>(exception3.InnerException.GetType(), typeof(InvalidOperationException));
            Assert.Contains("RefreshToken", exception3.InnerException.Message);
            Assert.Contains("application ID", exception3.InnerException.Message);
        }
    }
}
