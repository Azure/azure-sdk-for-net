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
using Microsoft.WindowsAzure.Management.Storage;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security;
using System.Linq;
using Xunit;

namespace Common.Authentication.Test
{
    public class ClientFactoryTests
    {
        private string subscriptionId;
        
        private string userAccount;

        private SecureString password;

        private bool runTest;

        public ClientFactoryTests()
        {
            // Example of environment variable: TEST_AZURE_CREDENTIALS=<subscription-id-value>;<email@domain.com>;<email-password>"
            string credsEnvironmentVariable = Environment.GetEnvironmentVariable("TEST_AZURE_CREDENTIALS") ?? "";
            string[] creds = credsEnvironmentVariable.Split(';');

            if (creds.Length != 3)
            {
                // The test is not configured to run.
                runTest = false;
                return;
            }

            subscriptionId = creds[0];
            userAccount = creds[1];
            password = new SecureString();
            foreach (char letter in creds[2])
            {
                password.AppendChar(letter);
            }
            password = password.Length == 0 ? null : password;
            runTest = true;
        }

        /// <summary>
        /// This test run live against Azure to list storage accounts under current subscription.
        /// </summary>
        [Fact]
        public void VerifyClientFactoryWorks()
        {
            if (!runTest)
            {
                return;
            }

            AzureContext context = new AzureContext
            (

                new AzureSubscription()
                {
                    Account = userAccount,
                    Environment = "AzureCloud",
                    Id = Guid.Parse(subscriptionId),
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
            
            // Add registration action to make sure we register for the used provider (if required)
            // AzureSession.ClientFactory.AddAction(new RPRegistrationAction());

            // Authenticate!
            AzureSession.AuthenticationFactory.Authenticate(context.Account, context.Environment, "common", password, ShowDialog.Always);
            
            // Create the client
            var client = AzureSession.ClientFactory.CreateClient<StorageManagementClient>(context, AzureEnvironment.Endpoint.ServiceManagement);

            // List storage accounts
            var storageAccounts = client.StorageAccounts.List().StorageAccounts;
            foreach (var storageAccount in storageAccounts)
            {
                Assert.NotNull(storageAccount);
            }
        }

        [Fact]
        public void VerifyProductInfoHeaderValueEquality()
        {
            ClientFactory factory = new ClientFactory();
            factory.AddUserAgent("test1", "123");
            factory.AddUserAgent("test2", "123");
            factory.AddUserAgent("test1", "123");
            factory.AddUserAgent("test1", "456");
            factory.AddUserAgent("test3");
            factory.AddUserAgent("tesT3");
            
            Assert.Equal(4, factory.UserAgents.Count);
            Assert.True(factory.UserAgents.Any(u => u.Product.Name == "test1" && u.Product.Version == "123"));
            Assert.True(factory.UserAgents.Any(u => u.Product.Name == "test2" && u.Product.Version == "123"));
            Assert.True(factory.UserAgents.Any(u => u.Product.Name == "test1" && u.Product.Version == "456"));
            Assert.True(factory.UserAgents.Any(u => u.Product.Name == "test3" && u.Product.Version == null));
        }
    }
}
;