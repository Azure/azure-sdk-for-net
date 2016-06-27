// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Test.Azure.Management.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using System;

    /// <summary>
    /// Scenario tests for the integration accounts.
    /// </summary>
    [Collection("IntegrationAccountScenarioTests")]
    public class IntegrationAccountScenarioTests : BaseScenarioTests
    {
        /// <summary>
        /// Name of the test class.
        /// </summary>
        private const string TestClass = "Test.Azure.Management.Logic.IntegrationAccountScenarioTests";

        /// <summary>
        /// Tests the create and delete operations of the integration account.
        /// </summary>
        [Fact]
        public void CreateAndDeleteIntegrationAccount()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();
                // Create a IntegrationAccount
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                // Get the IntegrationAccount and verify the content
                Assert.Equal(createdAccount.Name, integrationAccountName);

                // Delete the IntegrationAccount
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);

            }
        }

        /// <summary>
        /// Tests the create, update and delete operations of the integration account.
        /// </summary>
        [Fact]
        public void CreateAndUpdateIntegrationAccount()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();

                // Create a IntegrationAccount
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                // Get the IntegrationAccount and verify the content
                Assert.NotNull(createdAccount);
                Assert.Equal(createdAccount.Name, integrationAccountName);

                var updatedAccount = client.IntegrationAccounts.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    integrationAccount: new IntegrationAccount
                    {
                        Location = Constants.DefaultLocation,
                        Sku = new IntegrationAccountSku()
                        {
                            Name = SkuName.Free
                        },
                        Properties = new JObject(),
                        Name = integrationAccountName
                    });

                Assert.NotNull(updatedAccount);
                // Delete the IntegrationAccount
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);

            }
        }

        /// <summary>
        /// Tests the create and get(by account name) operations of the integration account.
        /// </summary>
        [Fact]
        public void CreateAndGetIntegrationAccountByName()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();

                // Create a IntegrationAccount
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                Assert.NotNull(createdAccount);

                // Get the IntegrationAccount and verify the content
                var getAccount = client.IntegrationAccounts.Get(Constants.DefaultResourceGroup, createdAccount.Name);
                Assert.Equal(createdAccount.Name, getAccount.Name);

                // Delete the IntegrationAccount
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);

            }
        }

        /// <summary>
        /// Tests the create and list (by subscription name) operations of the integration account.
        /// </summary>
        [Fact]
        public void ListIntegrationAccountBySubscription()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();

                // Create a IntegrationAccount
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                Assert.NotNull(createdAccount);

                // Get the IntegrationAccount and verify the content
                var accounts = client.IntegrationAccounts.ListBySubscription();
                Assert.True(accounts.Any());

                // Delete the IntegrationAccount
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);

            }
        }

        /// <summary>
        /// Tests the create and list (by resource group name) operations of the integration account.
        /// </summary>
        [Fact]
        public void ListIntegrationAccountByResourceGroup()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();

                // Create a IntegrationAccount
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                // Get the IntegrationAccount and verify the content
                var accounts = client.IntegrationAccounts.ListByResourceGroup(Constants.DefaultResourceGroup);

                Assert.True(accounts.Any());

                // Delete the IntegrationAccount
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);

            }
        }

        /// <summary>
        /// Tests the create and update (by account name) operations of the integration account.
        /// </summary>
        [Fact]
        public void UpdateIntegrationAccount()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();

                // Create a IntegrationAccount
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                // Get the IntegrationAccount and verify the content
                Assert.NotNull(createdAccount);
                Assert.Equal(createdAccount.Name, integrationAccountName);

                IDictionary<string, string> tags = new Dictionary<string, string>();
                tags.Add("IntegrationAccount", integrationAccountName);

                //Only the tags property can be patched
                var updatedAccount = client.IntegrationAccounts.Update(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    integrationAccount: new IntegrationAccount
                    {
                        Tags = tags
                    });

                Assert.NotNull(updatedAccount);
                // Delete the IntegrationAccount
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);

            }
        }

        /// <summary>
        /// Tests the integartion account callback URL.
        /// </summary>
        [Fact]
        public void ListIntegrationAccountCallbackUrl()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();

                // Create a IntegrationAccount
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                // Get the IntegrationAccount and verify the content
                var callbackUrl1 = client.IntegrationAccounts.ListCallbackUrl(Constants.DefaultResourceGroup,
                    integrationAccountName);

                Assert.NotNull(callbackUrl1);

                var callbackUrl2 = client.IntegrationAccounts.ListCallbackUrl(Constants.DefaultResourceGroup,
                    integrationAccountName);

                Assert.NotNull(callbackUrl2);

                // Delete the IntegrationAccount
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);

            }
        }

    }
}