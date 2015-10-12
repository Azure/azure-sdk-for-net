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
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Management.Storage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security;
using Microsoft.Azure.Common.Authentication.Factories;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Xunit;

namespace Common.Authentication.Test
{
    public class ClientFactoryHandlerTests
    {
        [Fact]
        public void DelegatingHandlersAreCloned()
        {
            string userAccount = "user@contoso.com";
            Guid subscriptionId = Guid.NewGuid();
             AzureContext context = new AzureContext
            (
                new AzureSubscription()
                {
                    Account = userAccount,
                    Environment = "AzureCloud",
                    Id = subscriptionId,
                    Properties = new Dictionary<AzureSubscription.Property, string>() { { AzureSubscription.Property.Tenants, "common" } }
                }, 
                new AzureAccount()
                {
                    Id = userAccount,
                    Type = AzureAccount.AccountType.User,
                    Properties = new Dictionary<AzureAccount.Property, string>() { { AzureAccount.Property.Tenants, "common" } }
                },
                AzureEnvironment.PublicEnvironments["AzureCloud"]
            );

            AzureSession.AuthenticationFactory = new MockTokenAuthenticationFactory(userAccount, Guid.NewGuid().ToString());
            var mockHandler = new MockDelegatingHandler();
            var factory = new ClientFactory();
            factory.AddHandler(mockHandler);
            var client = factory.CreateClient<StorageManagementClient>(context, AzureEnvironment.Endpoint.ServiceManagement);
            client = factory.CreateClient<StorageManagementClient>(context, AzureEnvironment.Endpoint.ServiceManagement);
            client = factory.CreateClient<StorageManagementClient>(context, AzureEnvironment.Endpoint.ServiceManagement);
            client = factory.CreateClient<StorageManagementClient>(context, AzureEnvironment.Endpoint.ServiceManagement);
            client = factory.CreateClient<StorageManagementClient>(context, AzureEnvironment.Endpoint.ServiceManagement);
            Assert.Equal(5, MockDelegatingHandler.cloneCount); 
        }

        private class MockDelegatingHandler : DelegatingHandler, ICloneable
        {
            public static int cloneCount = 0;

            public object Clone()
            {
                cloneCount++;
                return this;
            }
        }
    }
}
