// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Management.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using Microsoft.Azure.Common.Authentication.Factories;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
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
            
            AzureSession.ClientFactory.AddUserAgent("TestUserAgent", "1.0");
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
