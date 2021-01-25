// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Quantum.Tests.Helpers;
using Microsoft.Azure.Management.Quantum;
using Microsoft.Azure.Management.Quantum.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Quantum.Tests
{
    public class QuantumWorkspaceTests
    {
        private const string c_resourceNamespace = "Microsoft.Quantum";
        private const string c_resourceType = "accounts";

        public QuantumWorkspaceTests()
        {
        }

        [Fact]
        public void QuantumWorkspaceCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // prepare account properties
                string accountName = TestUtilities.GenerateName("csa");
                var parameters = QuantumManagementTestUtilities.GetDefaultQuantumWorkspaceParameters();

                // Create cognitive services account
                var account = QuantumMgmtClient.Workspaces.Create(rgname, accountName, parameters);
                QuantumManagementTestUtilities.VerifyWorkspaceProperties(account, true);

                // Create same account again, make sure it doesn't fail
                account = QuantumMgmtClient.Workspaces.Create(rgname, accountName, parameters);
                QuantumManagementTestUtilities.VerifyWorkspaceProperties(account, true);

                // Create account with only required params, for each sku (but free, since we can't have two free accounts in the same subscription)
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S1");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S2");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S3");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S4");
            }
        }

        [Fact]
        public void QuantumWorkspaceCreateAllApisTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S1", "Bing.Autosuggest.v7", "global");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S1", "Bing.CustomSearch", "global");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S1", "Bing.Search.v7", "global");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S0", "Bing.Speech", "global");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S1", "Bing.SpellCheck.v7", "global");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S1", "ComputerVision", "westus");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S0", "ContentModerator", "westus");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S0", "CustomSpeech", "westus");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S0", "CustomVision.Prediction", "southcentralus");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S0", "CustomVision.Training", "southcentralus");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S0", "Face", "westus");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S0", "LUIS", "westus");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S0", "SpeakerRecognition", "westus");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S1", "SpeechTranslation", "global");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S1", "TextAnalytics", "westus");
                QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S1", "TextTranslation", "global");
            }
        }

        [Fact]
        public void QuantumWorkspaceDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Delete an account which does not exist
                QuantumMgmtClient.Workspaces.Delete(rgname, "missingaccount");

                // Create cognitive services account
                string accountName = QuantumManagementTestUtilities.CreateQuantumWorkspace(QuantumMgmtClient, rgname);

                // Delete an account
                QuantumMgmtClient.Workspaces.Delete(rgname, accountName);

                // Delete an account which was just deleted
                QuantumMgmtClient.Workspaces.Delete(rgname, accountName);
            }
        }

        [Fact]
        public void QuantumWorkspaceCreateAndGetDifferentSkusTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Default parameters
                var f0Workspace = QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "F0", "TextAnalytics");
                var s1Workspace = QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S1", "TextAnalytics");

                var f0Properties = QuantumMgmtClient.Workspaces.GetProperties(rgname, f0Workspace.Name);
                Assert.Equal("F0", f0Properties.Sku.Name);
                Assert.Equal("TextAnalytics".ToString(), f0Properties.Kind);


                var s1Properties = QuantumMgmtClient.Workspaces.GetProperties(rgname, s1Workspace.Name);
                Assert.Equal("S1", s1Properties.Sku.Name);
                Assert.Equal("TextAnalytics".ToString(), s1Properties.Kind);
            }
        }

        [Fact]
        public void QuantumWorkspaceListByResourceGroupTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var accounts = QuantumMgmtClient.Workspaces.ListByResourceGroup(rgname);
                Assert.Empty(accounts);

                // Create cognitive services accounts
                string accountName1 = QuantumManagementTestUtilities.CreateQuantumWorkspace(QuantumMgmtClient, rgname);
                string accountName2 = QuantumManagementTestUtilities.CreateQuantumWorkspace(QuantumMgmtClient, rgname);

                accounts = QuantumMgmtClient.Workspaces.ListByResourceGroup(rgname);
                Assert.Equal(2, accounts.Count());

                QuantumManagementTestUtilities.VerifyWorkspaceProperties(accounts.First(), true);
                QuantumManagementTestUtilities.VerifyWorkspaceProperties(accounts.Skip(1).First(), true);
            }
        }

        [Fact]
        public void QuantumWorkspaceListBySubscriptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);


                // Create resource group and cognitive services account
                var rgname1 = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName1 = QuantumManagementTestUtilities.CreateQuantumWorkspace(QuantumMgmtClient, rgname1);

                // Create different resource group and cognitive account
                var rgname2 = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName2 = QuantumManagementTestUtilities.CreateQuantumWorkspace(QuantumMgmtClient, rgname2);

                var accounts = QuantumMgmtClient.Workspaces.List();

                Assert.True(accounts.Count() >= 2);

                QuantumWorkspace account1 = accounts.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName1));
                QuantumManagementTestUtilities.VerifyWorkspaceProperties(account1, true);

                QuantumWorkspace account2 = accounts.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName2));
                QuantumManagementTestUtilities.VerifyWorkspaceProperties(account2, true);
            }
        }

        [Fact]
        public void QuantumWorkspaceListKeysTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                string rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                string accountName = QuantumManagementTestUtilities.CreateQuantumWorkspace(QuantumMgmtClient, rgname);

                // List keys
                var keys = QuantumMgmtClient.Workspaces.ListKeys(rgname, accountName);
                Assert.NotNull(keys);

                // Validate Key1
                Assert.NotNull(keys.Key1);
                // Validate Key2
                Assert.NotNull(keys.Key2);
            }
        }

        [Fact]
        public void QuantumWorkspaceGetUsagesTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                string rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                string accountName = QuantumManagementTestUtilities.CreateQuantumWorkspace(QuantumMgmtClient, rgname);

                // Get usages
                var usages = QuantumMgmtClient.Workspaces.GetUsages(rgname, accountName);

                // Has usage data.
                Assert.NotNull(usages.Value);

                // Has quota limit 
                Assert.True(usages.Value[0].Limit > 0);

                // Current value == 0 as there is no call made for this newly created account.
                Assert.Equal(0, usages.Value[0].CurrentValue);
            }
        }

        [Fact]
        public void QuantumWorkspaceRegenerateKeyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                string rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                string accountName = QuantumManagementTestUtilities.CreateQuantumWorkspace(QuantumMgmtClient, rgname);

                // List keys
                var keys = QuantumMgmtClient.Workspaces.ListKeys(rgname, accountName);
                Assert.NotNull(keys);
                var key2 = keys.Key2;
                Assert.NotNull(key2);

                // Regenerate keys and verify that keys change
                var regenKeys = QuantumMgmtClient.Workspaces.RegenerateKey(rgname, accountName, KeyName.Key2);
                var key2Regen = regenKeys.Key2;
                Assert.NotNull(key2Regen);

                // Validate key was regenerated
                Assert.NotEqual(key2, key2Regen);
            }
        }

        [Fact]
        public void QuantumWorkspaceUpdateWithCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                var createdWorkspace = QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S2", "TextAnalytics");
                var accountName = createdWorkspace.Name;

                // Update SKU 
                var account = QuantumMgmtClient.Workspaces.Update(rgname, accountName, new QuantumWorkspace(sku: new Sku { Name = "S1" }));
                Assert.Equal("S1", account.Sku.Name);

                // Validate
                var fetchedWorkspace = QuantumMgmtClient.Workspaces.GetProperties(rgname, accountName);
                Assert.Equal("S1", fetchedWorkspace.Sku.Name);

                var newTags = new Dictionary<string, string>
                {
                    {"key3","value3"},
                    {"key4","value4"},
                    {"key5","value5"}
                };

                // Update account tags
                account = QuantumMgmtClient.Workspaces.Update(rgname, accountName,  new QuantumWorkspace(tags: newTags));
                Assert.Equal(newTags.Count, account.Tags.Count);
                // Validate
                fetchedWorkspace = QuantumMgmtClient.Workspaces.GetProperties(rgname, accountName);
                Assert.Equal("S1", fetchedWorkspace.Sku.Name);
                Assert.Equal(newTags.Count, fetchedWorkspace.Tags.Count());
                Assert.Collection(fetchedWorkspace.Tags,
                    (keyValue) => { Assert.Equal("key3", keyValue.Key); Assert.Equal("value3", keyValue.Value); },
                    (keyValue) => { Assert.Equal("key4", keyValue.Key); Assert.Equal("value4", keyValue.Value); },
                    (keyValue) => { Assert.Equal("key5", keyValue.Key); Assert.Equal("value5", keyValue.Value); }
                );
            }
        }

        [Fact]
        public void QuantumWorkspaceEnumerateSkusTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                var createdWorkspace = QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S3", "TextAnalytics");
                var accountName = createdWorkspace.Name;

                // Enumerate SKUs

                var skuList = QuantumMgmtClient.Workspaces.ListSkus(rgname, accountName);

                Assert.Single(skuList.Value.Select(x => x.ResourceType).Distinct());

                Assert.Equal($"{c_resourceNamespace}/{c_resourceType}", skuList.Value.Select(x => x.ResourceType).First());

                Assert.Collection(skuList.Value.Select(x => x.Sku),
                    (sku) => { Assert.Equal("F0", sku.Name); Assert.Equal(SkuTier.Free, sku.Tier); },
                    (sku) => { Assert.Equal("S0", sku.Name); Assert.Equal(SkuTier.Standard, sku.Tier); },
                    (sku) => { Assert.Equal("S1", sku.Name); Assert.Equal(SkuTier.Standard, sku.Tier); },
                    (sku) => { Assert.Equal("S2", sku.Name); Assert.Equal(SkuTier.Standard, sku.Tier); },
                    (sku) => { Assert.Equal("S3", sku.Name); Assert.Equal(SkuTier.Standard, sku.Tier); },
                    (sku) => { Assert.Equal("S4", sku.Name); Assert.Equal(SkuTier.Standard, sku.Tier); }
                );
            }
        }

        //   Negative Scenarios Tests
        [Fact]
        public void QuantumCreateWorkspaceErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var accountName = TestUtilities.GenerateName("csa");
                var parameters = new QuantumWorkspace
                {
                    Sku = new Sku { Name = "F0" },
                    Kind = "ComputerVision",
                    Location = QuantumManagementTestUtilities.DefaultLocation,
                    Properties = new QuantumWorkspaceProperties(),
                };

                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.Create("NotExistedRG", accountName, parameters),
                    "ResourceGroupNotFound");

                parameters.Location = "BLA";
                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.Create(rgname, accountName, parameters),
                    "LocationNotAvailableForResourceType");
            }
        }

        [Fact]
        public void QuantumCreateWorkspaceErrorTest2()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var accountName = TestUtilities.GenerateName("csa");
                var nonExistApiPara = new QuantumWorkspace
                {
                    Sku = new Sku { Name = "F0" },
                    Kind = "NonExistAPI",
                    Location = QuantumManagementTestUtilities.DefaultLocation,
                    Properties = new QuantumWorkspaceProperties(),
                };

                var nonExistSkuPara = new QuantumWorkspace
                {
                    Sku = new Sku { Name = "N0" },
                    Kind = "Face",
                    Location = QuantumManagementTestUtilities.DefaultLocation,
                    Properties = new QuantumWorkspaceProperties(),
                };

                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.Create(rgname, accountName, nonExistApiPara),
                    "InvalidApiSetId");

                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.Create(rgname, accountName, nonExistSkuPara),
                    "InvalidSkuId");
            }
        }

        [Fact]
        public void QuantumGetWorkspaceErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.GetProperties("NotExistedRG", "nonExistedWorkspaceName"),
                    "ResourceGroupNotFound");

                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.GetProperties(rgname, "nonExistedWorkspaceName"),
                    "ResourceNotFound");

                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.ListByResourceGroup("NotExistedRG"),
                    "ResourceGroupNotFound");
            }
        }

        [Fact]
        public void QuantumUpdateWorkspaceErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                var createdWorkspace = QuantumManagementTestUtilities.CreateAndValidateWorkspaceWithOnlyRequiredParameters(QuantumMgmtClient, rgname, "S0", "Face");
                var accountName = createdWorkspace.Name;

                // try to update non-existent account
                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.Update("NotExistedRG", "nonExistedWorkspaceName", new QuantumWorkspace()),
                    "ResourceGroupNotFound");

                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.Update(rgname, "nonExistedWorkspaceName", new QuantumWorkspace()),
                    "ResourceNotFound");

                // Update with a SKU which doesn't exist
                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.Update(rgname, accountName, new QuantumWorkspace(sku: new Sku("P1"))),
                    "InvalidSkuId");
            }
        }

        [Fact]
        public void QuantumDeleteWorkspaceErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // try to delete non-existent account
                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.Delete("NotExistedRG", "nonExistedWorkspaceName"),
                    "ResourceGroupNotFound");
            }
        }

        [Fact]
        public void QuantumWorkspaceKeysErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.ListKeys("NotExistedRG", "nonExistedWorkspaceName"),
                    "ResourceGroupNotFound");

                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.ListKeys(rgname, "nonExistedWorkspaceName"),
                    "ResourceNotFound");
            }
        }

        [Fact]
        public void QuantumEnumerateSkusErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.ListSkus("NotExistedRG", "nonExistedWorkspaceName"),
                    "ResourceGroupNotFound");

                QuantumManagementTestUtilities.ValidateExpectedException(
                    () => QuantumMgmtClient.Workspaces.ListSkus(rgname, "nonExistedWorkspaceName"),
                    "ResourceNotFound");
            }
        }

        [Fact]
        public void QuantumCheckSkuAvailabilityTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                var skus = QuantumMgmtClient.CheckSkuAvailability(
                    location: "westus",
                    skus: new List<string>() { "S0" },
                    kind: "Face",
                    type: $"{c_resourceNamespace}/{c_resourceType}");

                Assert.NotNull(skus);
                Assert.NotNull(skus.Value);
                Assert.True(skus.Value.Count > 0);
            }
        }

        [Fact]
        public void QuantumCheckDomainAvailabilityTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                var domainAvailability = QuantumMgmtClient.CheckDomainAvailability(
                    subdomainName: "atestsubdomain",
                    type: $"{c_resourceNamespace}/{c_resourceType}");

                Assert.NotNull(domainAvailability);
                Assert.NotNull(domainAvailability.SubdomainName);
            }
        }

        [Fact]
        public void QuantumResourceSkusListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                var skus = QuantumMgmtClient.ResourceSkus.List();

                Assert.True(skus.Any(), "Assert that the array of skus has at least 1 member.");
                Assert.True(skus.Any(sku => sku.Kind == "Face"), "Assert that the sku list at least contains one Face sku.");
                Assert.True(skus.Any(sku => sku.Name == "F0"), "Assert that the sku list at least contains one F0 sku.");
                Assert.True(skus.Any(sku => sku.Locations != null), "Assert that the sku list has non null location info in it.");
                Assert.True(skus.All(sku => sku.Locations.Count == 1), "There should be exactly one location info per entry.");
            }
        }

        [Fact]
        public void QuantumWorkspaceMinMaxNameLengthTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var parameters = new QuantumWorkspace
                {
                    Sku = new Sku { Name = "S0" },
                    Kind = "Face",
                    Location = QuantumManagementTestUtilities.DefaultLocation,
                    Properties = new QuantumWorkspaceProperties(),
                };

                var minName = "zz";
                var maxName = "AcadAcadAcadAcadAcadAcadAcadAcadAcadAcadAcadAcadAcadAcadAcadAcad";

                var minWorkspace = QuantumMgmtClient.Workspaces.Create(rgname, minName, parameters);
                var maxWorkspace = QuantumMgmtClient.Workspaces.Create(rgname, maxName, parameters);

                Assert.Equal(minName, minWorkspace.Name);
                Assert.Equal(maxName, maxWorkspace.Name);
            }
        }


        [Fact]
        public void QuantumWorkspaceIdentityTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                { // create with MSI
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    QuantumWorkspace parameters = new QuantumWorkspace
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = QuantumManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "Face",
                        Properties = new QuantumWorkspaceProperties(),
                    };

                    // custom parameters
                    parameters.Identity = new Identity(IdentityType.SystemAssigned, null, null, null);

                    // Create cognitive services account
                    var account = QuantumMgmtClient.Workspaces.Create(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Identity);
                    Assert.False(string.IsNullOrEmpty(account.Identity.PrincipalId));
                    Assert.False(string.IsNullOrEmpty(account.Identity.TenantId));
                    Assert.Equal(IdentityType.SystemAssigned, account.Identity.Type);
                }

                { // patch with MSI
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    QuantumWorkspace parameters = new QuantumWorkspace
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = QuantumManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "Face",
                        Properties = new QuantumWorkspaceProperties(),
                    };

                    // Create cognitive services account
                    var account = QuantumMgmtClient.Workspaces.Create(rgname, accountName, parameters);

                    // custom parameters
                    parameters = account;
                    parameters.Identity = new Identity(IdentityType.SystemAssigned, null, null, null);
                    account = QuantumMgmtClient.Workspaces.Update(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Identity);
                    Assert.False(string.IsNullOrEmpty(account.Identity.PrincipalId));
                    Assert.False(string.IsNullOrEmpty(account.Identity.TenantId));
                    Assert.Equal(IdentityType.SystemAssigned, account.Identity.Type);
                }
            }
        }

        [Fact]
        public void QuantumWorkspaceEncryptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                { // create with Encryption
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    QuantumWorkspace parameters = new QuantumWorkspace
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = QuantumManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "E0" },
                        Kind = "Face",
                        Properties = new QuantumWorkspaceProperties(),
                    };

                    // custom parameters
                    parameters.Identity = new Identity(IdentityType.SystemAssigned, null, null, null);
                    parameters.Properties.Encryption = new Encryption(
                        new KeyVaultProperties()
                        {
                            KeyName = "FakeKeyName",
                            KeyVersion = "891CF236-D241-4738-9462-D506AF493DFA",
                            KeyVaultUri = "https://pltfrmscrts-use-pc-dev.vault.azure.net/"
                        },
                        KeySource.MicrosoftKeyVault);

                    // Create cognitive services account
                    var account = QuantumMgmtClient.Workspaces.Create(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Properties?.Encryption);
                    Assert.NotNull(account?.Properties?.Encryption?.KeyVaultProperties);
                    Assert.Equal(parameters.Properties.Encryption.KeySource, account.Properties.Encryption.KeySource);
                    Assert.Equal(parameters.Properties.Encryption.KeyVaultProperties.KeyName, account.Properties.Encryption.KeyVaultProperties.KeyName);
                    Assert.Equal(parameters.Properties.Encryption.KeyVaultProperties.KeyVersion, account.Properties.Encryption.KeyVaultProperties.KeyVersion);
                    Assert.Equal(parameters.Properties.Encryption.KeyVaultProperties.KeyVaultUri, account.Properties.Encryption.KeyVaultProperties.KeyVaultUri);
                    Assert.NotNull(account?.Identity);
                    Assert.False(string.IsNullOrEmpty(account.Identity.PrincipalId));
                    Assert.False(string.IsNullOrEmpty(account.Identity.TenantId));
                    Assert.Equal(IdentityType.SystemAssigned, account.Identity.Type);
                }

                { // patch with Encryption
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    QuantumWorkspace parameters = new QuantumWorkspace
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = QuantumManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "E0" },
                        Kind = "Face",
                        Properties = new QuantumWorkspaceProperties(),
                    };

                    // Create cognitive services account
                    var account = QuantumMgmtClient.Workspaces.Create(rgname, accountName, parameters);

                    // custom parameters
                    parameters = account;
                    parameters.Identity = new Identity(IdentityType.SystemAssigned, null, null, null);
                    parameters.Properties.Encryption = new Encryption(
                        new KeyVaultProperties()
                        {
                            KeyName = "FakeKeyName",
                            KeyVersion = "891CF236-D241-4738-9462-D506AF493DFA",
                            KeyVaultUri = "https://pltfrmscrts-use-pc-dev.vault.azure.net/"
                        },
                        KeySource.MicrosoftKeyVault);
                    account = QuantumMgmtClient.Workspaces.Update(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Properties?.Encryption);
                    Assert.NotNull(account?.Properties?.Encryption?.KeyVaultProperties);
                    Assert.Equal(parameters.Properties.Encryption.KeySource, account.Properties.Encryption.KeySource);
                    Assert.Equal(parameters.Properties.Encryption.KeyVaultProperties.KeyName, account.Properties.Encryption.KeyVaultProperties.KeyName);
                    Assert.Equal(parameters.Properties.Encryption.KeyVaultProperties.KeyVersion, account.Properties.Encryption.KeyVaultProperties.KeyVersion);
                    Assert.Equal(parameters.Properties.Encryption.KeyVaultProperties.KeyVaultUri, account.Properties.Encryption.KeyVaultProperties.KeyVaultUri);
                    Assert.NotNull(account?.Identity);
                    Assert.False(string.IsNullOrEmpty(account.Identity.PrincipalId));
                    Assert.False(string.IsNullOrEmpty(account.Identity.TenantId));
                    Assert.Equal(IdentityType.SystemAssigned, account.Identity.Type);
                }
            }
        }


        [Fact]
        public void QuantumWorkspaceUserOwnedStorageTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                { // create with Encryption
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    QuantumWorkspace parameters = new QuantumWorkspace
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = QuantumManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "SpeechServices",
                        Properties = new QuantumWorkspaceProperties(),
                    };

                    // custom parameters
                    parameters.Identity = new Identity(IdentityType.SystemAssigned, null, null, null);
                    parameters.Properties.UserOwnedStorage = new List<UserOwnedStorage>()
                    {
                        new UserOwnedStorage()
                        {
                            ResourceId = "/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/felixwa-01/providers/Microsoft.Storage/storageWorkspaces/felixwatest"
                        }
                    };

                    // Create cognitive services account
                    var account = QuantumMgmtClient.Workspaces.Create(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Properties?.UserOwnedStorage);
                    Assert.True(account.Properties.UserOwnedStorage.Count == 1);
                    Assert.Equal(parameters.Properties.UserOwnedStorage[0].ResourceId, account.Properties.UserOwnedStorage[0].ResourceId);
                    Assert.NotNull(account?.Identity);
                    Assert.False(string.IsNullOrEmpty(account.Identity.PrincipalId));
                    Assert.False(string.IsNullOrEmpty(account.Identity.TenantId));
                    Assert.Equal(IdentityType.SystemAssigned, account.Identity.Type);
                }

                { // patch with Encryption
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    QuantumWorkspace parameters = new QuantumWorkspace
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = QuantumManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "SpeechServices",
                        Properties = new QuantumWorkspaceProperties(),
                    };

                    // Create cognitive services account
                    var account = QuantumMgmtClient.Workspaces.Create(rgname, accountName, parameters);

                    // custom parameters
                    parameters = account;
                    parameters.Identity = new Identity(IdentityType.SystemAssigned, null, null, null);
                    parameters.Properties.UserOwnedStorage = new List<UserOwnedStorage>()
                    {
                        new UserOwnedStorage()
                        {
                            ResourceId = "/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/felixwa-01/providers/Microsoft.Storage/storageWorkspaces/felixwatest"
                        }
                    };
                    account = QuantumMgmtClient.Workspaces.Update(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Properties?.UserOwnedStorage);
                    Assert.True(account.Properties.UserOwnedStorage.Count == 1);
                    Assert.Equal(parameters.Properties.UserOwnedStorage[0].ResourceId, account.Properties.UserOwnedStorage[0].ResourceId);
                    Assert.NotNull(account?.Identity);
                    Assert.False(string.IsNullOrEmpty(account.Identity.PrincipalId));
                    Assert.False(string.IsNullOrEmpty(account.Identity.TenantId));
                    Assert.Equal(IdentityType.SystemAssigned, account.Identity.Type);
                }
            }
        }

        [Fact]
        public void QuantumWorkspacePrivateEndpointConnectionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                { 
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    QuantumWorkspace parameters = new QuantumWorkspace
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = QuantumManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "Face",
                        Properties = new QuantumWorkspaceProperties(),
                    };

                    // Create cognitive services account
                    var account = QuantumMgmtClient.Workspaces.Create(rgname, accountName, parameters);

                    // 
                    var plResouces = QuantumMgmtClient.PrivateLinkResources.List(rgname, accountName);

                    PrivateEndpointConnection pec = null;
                    try
                    {
                        pec = QuantumMgmtClient.PrivateEndpointConnections.Get(rgname, accountName, "notExistPCN");
                    }
                    catch { }
                    // verify
                    Assert.NotNull(plResouces);
                    Assert.True(plResouces.Value.Count == 1);
                    Assert.Equal("account", plResouces.Value[0].Properties?.GroupId);
                    Assert.Null(pec);

                    var plConnections = QuantumMgmtClient.PrivateEndpointConnections.List(rgname, accountName);
                    Assert.True(plConnections.Value.Count == 0);

                }
            }
        }

        [Fact]
        public void QuantumWorkspaceCapabilityTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = QuantumManagementTestUtilities.GetResourceManagementClient(context, handler);
                var QuantumMgmtClient = QuantumManagementTestUtilities.GetQuantumManagementClient(context, handler);

                // Create resource group
                var rgname = QuantumManagementTestUtilities.CreateResourceGroup(resourcesClient);

                { // create with Encryption
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    QuantumWorkspace parameters = new QuantumWorkspace
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = QuantumManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "F0" },
                        Kind = "FormRecognizer",
                        Properties = new QuantumWorkspaceProperties(),
                    };
                    // Create cognitive services account
                    var account = QuantumMgmtClient.Workspaces.Create(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Properties?.Capabilities);
                    Assert.True(account?.Properties?.Capabilities.Count > 0);
                    Assert.True(account?.Properties?.Capabilities[0].Name.Length > 0);
                }
            }
        }
    }
}