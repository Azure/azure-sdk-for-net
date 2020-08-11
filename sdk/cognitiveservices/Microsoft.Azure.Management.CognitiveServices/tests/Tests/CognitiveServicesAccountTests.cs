// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using CognitiveServices.Tests.Helpers;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace CognitiveServices.Tests
{
    public class CognitiveServicesAccountTests
    {
        private const string c_resourceNamespace = "Microsoft.CognitiveServices";
        private const string c_resourceType = "accounts";

        public CognitiveServicesAccountTests()
        {
        }

        [Fact]
        public void CognitiveServicesAccountCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // prepare account properties
                string accountName = TestUtilities.GenerateName("csa");
                var parameters = CognitiveServicesManagementTestUtilities.GetDefaultCognitiveServicesAccountParameters();

                // Create cognitive services account
                var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);
                CognitiveServicesManagementTestUtilities.VerifyAccountProperties(account, true);

                // Create same account again, make sure it doesn't fail
                account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);
                CognitiveServicesManagementTestUtilities.VerifyAccountProperties(account, true);

                // Create account with only required params, for each sku (but free, since we can't have two free accounts in the same subscription)
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S1");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S2");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S3");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S4");
            }
        }

        [Fact]
        public void CognitiveServicesAccountCreateAllApisTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S1", "Bing.Autosuggest.v7", "global");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S1", "Bing.CustomSearch", "global");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S1", "Bing.Search.v7", "global");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S0", "Bing.Speech", "global");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S1", "Bing.SpellCheck.v7", "global");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S1", "ComputerVision", "westus");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S0", "ContentModerator", "westus");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S0", "CustomSpeech", "westus");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S0", "CustomVision.Prediction", "southcentralus");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S0", "CustomVision.Training", "southcentralus");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S0", "Face", "westus");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S0", "LUIS", "westus");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S0", "SpeakerRecognition", "westus");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S1", "SpeechTranslation", "global");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S1", "TextAnalytics", "westus");
                CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S1", "TextTranslation", "global");
            }
        }

        [Fact]
        public void CognitiveServicesAccountDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Delete an account which does not exist
                cognitiveServicesMgmtClient.Accounts.Delete(rgname, "missingaccount");

                // Create cognitive services account
                string accountName = CognitiveServicesManagementTestUtilities.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname);

                // Delete an account
                cognitiveServicesMgmtClient.Accounts.Delete(rgname, accountName);

                // Delete an account which was just deleted
                cognitiveServicesMgmtClient.Accounts.Delete(rgname, accountName);
            }
        }

        [Fact]
        public void CognitiveServicesAccountCreateAndGetDifferentSkusTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Default parameters
                var f0Account = CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "F0", "TextAnalytics");
                var s1Account = CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S1", "TextAnalytics");

                var f0Properties = cognitiveServicesMgmtClient.Accounts.GetProperties(rgname, f0Account.Name);
                Assert.Equal("F0", f0Properties.Sku.Name);
                Assert.Equal("TextAnalytics".ToString(), f0Properties.Kind);


                var s1Properties = cognitiveServicesMgmtClient.Accounts.GetProperties(rgname, s1Account.Name);
                Assert.Equal("S1", s1Properties.Sku.Name);
                Assert.Equal("TextAnalytics".ToString(), s1Properties.Kind);
            }
        }

        [Fact]
        public void CognitiveServicesAccountListByResourceGroupTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var accounts = cognitiveServicesMgmtClient.Accounts.ListByResourceGroup(rgname);
                Assert.Empty(accounts);

                // Create cognitive services accounts
                string accountName1 = CognitiveServicesManagementTestUtilities.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname);
                string accountName2 = CognitiveServicesManagementTestUtilities.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname);

                accounts = cognitiveServicesMgmtClient.Accounts.ListByResourceGroup(rgname);
                Assert.Equal(2, accounts.Count());

                CognitiveServicesManagementTestUtilities.VerifyAccountProperties(accounts.First(), true);
                CognitiveServicesManagementTestUtilities.VerifyAccountProperties(accounts.Skip(1).First(), true);
            }
        }

        [Fact]
        public void CognitiveServicesAccountListBySubscriptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);


                // Create resource group and cognitive services account
                var rgname1 = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName1 = CognitiveServicesManagementTestUtilities.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname1);

                // Create different resource group and cognitive account
                var rgname2 = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string accountName2 = CognitiveServicesManagementTestUtilities.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname2);

                var accounts = cognitiveServicesMgmtClient.Accounts.List();

                Assert.True(accounts.Count() >= 2);

                CognitiveServicesAccount account1 = accounts.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName1));
                CognitiveServicesManagementTestUtilities.VerifyAccountProperties(account1, true);

                CognitiveServicesAccount account2 = accounts.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName2));
                CognitiveServicesManagementTestUtilities.VerifyAccountProperties(account2, true);
            }
        }

        [Fact]
        public void CognitiveServicesAccountListKeysTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                string rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                string accountName = CognitiveServicesManagementTestUtilities.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname);

                // List keys
                var keys = cognitiveServicesMgmtClient.Accounts.ListKeys(rgname, accountName);
                Assert.NotNull(keys);

                // Validate Key1
                Assert.NotNull(keys.Key1);
                // Validate Key2
                Assert.NotNull(keys.Key2);
            }
        }

        [Fact]
        public void CognitiveServicesAccountGetUsagesTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                string rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                string accountName = CognitiveServicesManagementTestUtilities.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname);

                // Get usages
                var usages = cognitiveServicesMgmtClient.Accounts.GetUsages(rgname, accountName);

                // Has usage data.
                Assert.NotNull(usages.Value);

                // Has quota limit 
                Assert.True(usages.Value[0].Limit > 0);

                // Current value == 0 as there is no call made for this newly created account.
                Assert.Equal(0, usages.Value[0].CurrentValue);
            }
        }

        [Fact]
        public void CognitiveServicesAccountRegenerateKeyTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                string rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                string accountName = CognitiveServicesManagementTestUtilities.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname);

                // List keys
                var keys = cognitiveServicesMgmtClient.Accounts.ListKeys(rgname, accountName);
                Assert.NotNull(keys);
                var key2 = keys.Key2;
                Assert.NotNull(key2);

                // Regenerate keys and verify that keys change
                var regenKeys = cognitiveServicesMgmtClient.Accounts.RegenerateKey(rgname, accountName, KeyName.Key2);
                var key2Regen = regenKeys.Key2;
                Assert.NotNull(key2Regen);

                // Validate key was regenerated
                Assert.NotEqual(key2, key2Regen);
            }
        }

        [Fact]
        public void CognitiveServicesAccountUpdateWithCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                var createdAccount = CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S2", "TextAnalytics");
                var accountName = createdAccount.Name;

                // Update SKU 
                var account = cognitiveServicesMgmtClient.Accounts.Update(rgname, accountName, new CognitiveServicesAccount(sku: new Sku { Name = "S1" }));
                Assert.Equal("S1", account.Sku.Name);

                // Validate
                var fetchedAccount = cognitiveServicesMgmtClient.Accounts.GetProperties(rgname, accountName);
                Assert.Equal("S1", fetchedAccount.Sku.Name);

                var newTags = new Dictionary<string, string>
                {
                    {"key3","value3"},
                    {"key4","value4"},
                    {"key5","value5"}
                };

                // Update account tags
                account = cognitiveServicesMgmtClient.Accounts.Update(rgname, accountName,  new CognitiveServicesAccount(tags: newTags));
                Assert.Equal(newTags.Count, account.Tags.Count);
                // Validate
                fetchedAccount = cognitiveServicesMgmtClient.Accounts.GetProperties(rgname, accountName);
                Assert.Equal("S1", fetchedAccount.Sku.Name);
                Assert.Equal(newTags.Count, fetchedAccount.Tags.Count());
                Assert.Collection(fetchedAccount.Tags,
                    (keyValue) => { Assert.Equal("key3", keyValue.Key); Assert.Equal("value3", keyValue.Value); },
                    (keyValue) => { Assert.Equal("key4", keyValue.Key); Assert.Equal("value4", keyValue.Value); },
                    (keyValue) => { Assert.Equal("key5", keyValue.Key); Assert.Equal("value5", keyValue.Value); }
                );
            }
        }

        [Fact]
        public void CognitiveServicesAccountEnumerateSkusTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                var createdAccount = CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S3", "TextAnalytics");
                var accountName = createdAccount.Name;

                // Enumerate SKUs

                var skuList = cognitiveServicesMgmtClient.Accounts.ListSkus(rgname, accountName);

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
        public void CognitiveServicesCreateAccountErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var accountName = TestUtilities.GenerateName("csa");
                var parameters = new CognitiveServicesAccount
                {
                    Sku = new Sku { Name = "F0" },
                    Kind = "ComputerVision",
                    Location = CognitiveServicesManagementTestUtilities.DefaultLocation,
                    Properties = new CognitiveServicesAccountProperties(),
                };

                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Create("NotExistedRG", accountName, parameters),
                    "ResourceGroupNotFound");

                parameters.Location = "BLA";
                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters),
                    "LocationNotAvailableForResourceType");
            }
        }

        [Fact]
        public void CognitiveServicesCreateAccountErrorTest2()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var accountName = TestUtilities.GenerateName("csa");
                var nonExistApiPara = new CognitiveServicesAccount
                {
                    Sku = new Sku { Name = "F0" },
                    Kind = "NonExistAPI",
                    Location = CognitiveServicesManagementTestUtilities.DefaultLocation,
                    Properties = new CognitiveServicesAccountProperties(),
                };

                var nonExistSkuPara = new CognitiveServicesAccount
                {
                    Sku = new Sku { Name = "N0" },
                    Kind = "Face",
                    Location = CognitiveServicesManagementTestUtilities.DefaultLocation,
                    Properties = new CognitiveServicesAccountProperties(),
                };

                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, nonExistApiPara),
                    "InvalidApiSetId");

                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, nonExistSkuPara),
                    "InvalidSkuId");
            }
        }

        [Fact]
        public void CognitiveServicesGetAccountErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.GetProperties("NotExistedRG", "nonExistedAccountName"),
                    "ResourceGroupNotFound");

                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.GetProperties(rgname, "nonExistedAccountName"),
                    "ResourceNotFound");

                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.ListByResourceGroup("NotExistedRG"),
                    "ResourceGroupNotFound");
            }
        }

        [Fact]
        public void CognitiveServicesUpdateAccountErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                var createdAccount = CognitiveServicesManagementTestUtilities.CreateAndValidateAccountWithOnlyRequiredParameters(cognitiveServicesMgmtClient, rgname, "S0", "Face");
                var accountName = createdAccount.Name;

                // try to update non-existent account
                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Update("NotExistedRG", "nonExistedAccountName", new CognitiveServicesAccount()),
                    "ResourceGroupNotFound");

                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Update(rgname, "nonExistedAccountName", new CognitiveServicesAccount()),
                    "ResourceNotFound");

                // Update with a SKU which doesn't exist
                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Update(rgname, accountName, new CognitiveServicesAccount(sku: new Sku("P1"))),
                    "InvalidSkuId");
            }
        }

        [Fact]
        public void CognitiveServicesDeleteAccountErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // try to delete non-existent account
                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Delete("NotExistedRG", "nonExistedAccountName"),
                    "ResourceGroupNotFound");
            }
        }

        [Fact]
        public void CognitiveServicesAccountKeysErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.ListKeys("NotExistedRG", "nonExistedAccountName"),
                    "ResourceGroupNotFound");

                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.ListKeys(rgname, "nonExistedAccountName"),
                    "ResourceNotFound");
            }
        }

        [Fact]
        public void CognitiveServicesEnumerateSkusErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.ListSkus("NotExistedRG", "nonExistedAccountName"),
                    "ResourceGroupNotFound");

                CognitiveServicesManagementTestUtilities.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.ListSkus(rgname, "nonExistedAccountName"),
                    "ResourceNotFound");
            }
        }

        [Fact]
        public void CognitiveServicesCheckSkuAvailabilityTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                var skus = cognitiveServicesMgmtClient.CheckSkuAvailability(
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
        public void CognitiveServicesCheckDomainAvailabilityTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                var domainAvailability = cognitiveServicesMgmtClient.CheckDomainAvailability(
                    subdomainName: "atestsubdomain",
                    type: $"{c_resourceNamespace}/{c_resourceType}");

                Assert.NotNull(domainAvailability);
                Assert.NotNull(domainAvailability.SubdomainName);
            }
        }

        [Fact]
        public void CognitiveServicesResourceSkusListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                var skus = cognitiveServicesMgmtClient.ResourceSkus.List();

                Assert.True(skus.Any(), "Assert that the array of skus has at least 1 member.");
                Assert.True(skus.Any(sku => sku.Kind == "Face"), "Assert that the sku list at least contains one Face sku.");
                Assert.True(skus.Any(sku => sku.Name == "F0"), "Assert that the sku list at least contains one F0 sku.");
                Assert.True(skus.Any(sku => sku.Locations != null), "Assert that the sku list has non null location info in it.");
                Assert.True(skus.All(sku => sku.Locations.Count == 1), "There should be exactly one location info per entry.");
            }
        }

        [Fact]
        public void CognitiveServicesAccountMinMaxNameLengthTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                var parameters = new CognitiveServicesAccount
                {
                    Sku = new Sku { Name = "S0" },
                    Kind = "Face",
                    Location = CognitiveServicesManagementTestUtilities.DefaultLocation,
                    Properties = new CognitiveServicesAccountProperties(),
                };

                var minName = "zz";
                var maxName = "AcadAcadAcadAcadAcadAcadAcadAcadAcadAcadAcadAcadAcadAcadAcadAcad";

                var minAccount = cognitiveServicesMgmtClient.Accounts.Create(rgname, minName, parameters);
                var maxAccount = cognitiveServicesMgmtClient.Accounts.Create(rgname, maxName, parameters);

                Assert.Equal(minName, minAccount.Name);
                Assert.Equal(maxName, maxAccount.Name);
            }
        }


        [Fact]
        public void CognitiveServicesAccountIdentityTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                { // create with MSI
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    CognitiveServicesAccount parameters = new CognitiveServicesAccount
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = CognitiveServicesManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "Face",
                        Properties = new CognitiveServicesAccountProperties(),
                    };

                    // custom parameters
                    parameters.Identity = new Identity(IdentityType.SystemAssigned, null, null, null);

                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Identity);
                    Assert.False(string.IsNullOrEmpty(account.Identity.PrincipalId));
                    Assert.False(string.IsNullOrEmpty(account.Identity.TenantId));
                    Assert.Equal(IdentityType.SystemAssigned, account.Identity.Type);
                }

                { // patch with MSI
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    CognitiveServicesAccount parameters = new CognitiveServicesAccount
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = CognitiveServicesManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "Face",
                        Properties = new CognitiveServicesAccountProperties(),
                    };

                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    // custom parameters
                    parameters = account;
                    parameters.Identity = new Identity(IdentityType.SystemAssigned, null, null, null);
                    account = cognitiveServicesMgmtClient.Accounts.Update(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Identity);
                    Assert.False(string.IsNullOrEmpty(account.Identity.PrincipalId));
                    Assert.False(string.IsNullOrEmpty(account.Identity.TenantId));
                    Assert.Equal(IdentityType.SystemAssigned, account.Identity.Type);
                }
            }
        }

        [Fact]
        public void CognitiveServicesAccountEncryptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                { // create with Encryption
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    CognitiveServicesAccount parameters = new CognitiveServicesAccount
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = CognitiveServicesManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "E0" },
                        Kind = "Face",
                        Properties = new CognitiveServicesAccountProperties(),
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
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

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
                    CognitiveServicesAccount parameters = new CognitiveServicesAccount
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = CognitiveServicesManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "E0" },
                        Kind = "Face",
                        Properties = new CognitiveServicesAccountProperties(),
                    };

                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

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
                    account = cognitiveServicesMgmtClient.Accounts.Update(rgname, accountName, parameters);

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
        public void CognitiveServicesAccountUserOwnedStorageTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                { // create with Encryption
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    CognitiveServicesAccount parameters = new CognitiveServicesAccount
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = CognitiveServicesManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "SpeechServices",
                        Properties = new CognitiveServicesAccountProperties(),
                    };

                    // custom parameters
                    parameters.Identity = new Identity(IdentityType.SystemAssigned, null, null, null);
                    parameters.Properties.UserOwnedStorage = new List<UserOwnedStorage>()
                    {
                        new UserOwnedStorage()
                        {
                            ResourceId = "/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/felixwa-01/providers/Microsoft.Storage/storageAccounts/felixwatest"
                        }
                    };

                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

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
                    CognitiveServicesAccount parameters = new CognitiveServicesAccount
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = CognitiveServicesManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "SpeechServices",
                        Properties = new CognitiveServicesAccountProperties(),
                    };

                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    // custom parameters
                    parameters = account;
                    parameters.Identity = new Identity(IdentityType.SystemAssigned, null, null, null);
                    parameters.Properties.UserOwnedStorage = new List<UserOwnedStorage>()
                    {
                        new UserOwnedStorage()
                        {
                            ResourceId = "/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/felixwa-01/providers/Microsoft.Storage/storageAccounts/felixwatest"
                        }
                    };
                    account = cognitiveServicesMgmtClient.Accounts.Update(rgname, accountName, parameters);

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
        public void CognitiveServicesAccountPrivateEndpointConnectionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                { 
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    CognitiveServicesAccount parameters = new CognitiveServicesAccount
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = CognitiveServicesManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "Face",
                        Properties = new CognitiveServicesAccountProperties(),
                    };

                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    // 
                    var plResouces = cognitiveServicesMgmtClient.PrivateLinkResources.List(rgname, accountName);

                    PrivateEndpointConnection pec = null;
                    try
                    {
                        pec = cognitiveServicesMgmtClient.PrivateEndpointConnections.Get(rgname, accountName, "notExistPCN");
                    }
                    catch { }
                    // verify
                    Assert.NotNull(plResouces);
                    Assert.True(plResouces.Value.Count == 1);
                    Assert.Equal("account", plResouces.Value[0].Properties?.GroupId);
                    Assert.Null(pec);

                }
            }
        }

        [Fact]
        public void CognitiveServicesAccountCapabilityTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = CognitiveServicesManagementTestUtilities.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = CognitiveServicesManagementTestUtilities.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = CognitiveServicesManagementTestUtilities.CreateResourceGroup(resourcesClient);

                { // create with Encryption
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    CognitiveServicesAccount parameters = new CognitiveServicesAccount
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = CognitiveServicesManagementTestUtilities.DefaultTags,
                        Sku = new Sku { Name = "F0" },
                        Kind = "FormRecognizer",
                        Properties = new CognitiveServicesAccountProperties(),
                    };
                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Properties?.Capabilities);
                    Assert.True(account?.Properties?.Capabilities.Count > 0);
                    Assert.True(account?.Properties?.Capabilities[0].Name.Length > 0);
                }
            }
        }
    }
}