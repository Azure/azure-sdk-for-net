// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CognitiveServices.Tests.Helpers;
using Microsoft.Azure.Management.CognitiveServices;
using Microsoft.Azure.Management.CognitiveServices.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;
using Xunit;

namespace CognitiveServices.Tests
{
    public class CognitiveServicesTests
    {
        private const string c_resourceNamespace = "Microsoft.CognitiveServices";
        private const string c_resourceType = "accounts";

        public CognitiveServicesTests()
        {
        }

        [Fact]
        public void CognitiveServicesAccountCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                // prepare account properties
                string accountName = TestUtilities.GenerateName("csa");
                var parameters = new Account
                {
                    Location = TestHelper.DefaultLocation,
                    Tags = TestHelper.DefaultTags,
                    Sku = new Sku { Name = TestHelper.DefaultSkuName },
                    Kind = TestHelper.DefaultKind,
                    Properties = new AccountProperties(),
                };

                // Create cognitive services account
                var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);
                TestHelper.VerifyAccountProperties(account, true);

                // Create same account again, make sure it doesn't fail
                account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);
                TestHelper.VerifyAccountProperties(account, true);
            }
        }

        [Fact]
        public void CognitiveServicesAccountDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                // Delete an account which does not exist
                cognitiveServicesMgmtClient.Accounts.Delete(rgname, "missingaccount");

                // Create cognitive services account
                string accountName = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname).Name;

                // Delete an account
                cognitiveServicesMgmtClient.Accounts.Delete(rgname, accountName);

                // Delete an account which was just deleted
                cognitiveServicesMgmtClient.Accounts.Delete(rgname, accountName);
            }
        }

        [Fact]
        public void CognitiveServicesAccountSoftDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                string accountName = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname).Name;
                var account = cognitiveServicesMgmtClient.Accounts.Get(rgname, accountName);
                account.Properties.CustomSubDomainName = accountName;
                cognitiveServicesMgmtClient.Accounts.Update(rgname, accountName, account);

                // Delete an account
                cognitiveServicesMgmtClient.Accounts.Delete(rgname, accountName);

                account = null;
                try
                {
                    account = cognitiveServicesMgmtClient.Accounts.Get(rgname, accountName);
                }
                catch { }
                Assert.Null(account);

                var accounts = cognitiveServicesMgmtClient.DeletedAccounts.List();
                Assert.NotEmpty(accounts);

                account = cognitiveServicesMgmtClient.DeletedAccounts.Get(TestHelper.DefaultLocation, rgname, accountName);
                Assert.Equal(accountName, account.Name);
                Assert.Equal(accountName, account.Properties.CustomSubDomainName);
                Assert.False(string.IsNullOrWhiteSpace(account.Properties.ScheduledPurgeDate));
                Assert.False(string.IsNullOrWhiteSpace(account.Properties.DeletionDate));

                account.Properties.Restore = true;
                account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, account);

                account = null;
                try
                {
                    account = cognitiveServicesMgmtClient.Accounts.Get(rgname, accountName);
                }
                catch { }
                Assert.NotNull(account);
                Assert.Equal(accountName, account.Name);
                Assert.Equal(accountName, account.Properties.CustomSubDomainName); // this can ensure its restored not new created.

                cognitiveServicesMgmtClient.Accounts.Delete(rgname, accountName);

                cognitiveServicesMgmtClient.DeletedAccounts.Purge(TestHelper.DefaultLocation, rgname, accountName);
            }
        }

        [Fact]
        public void CognitiveServicesAccountDisableLocalAuthTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                var rgname = TestHelper.CreateResourceGroup(resourcesClient);
                var account = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname);
                Assert.Null(account.Properties.DisableLocalAuth);

                account.Properties.DisableLocalAuth = true;
                cognitiveServicesMgmtClient.Accounts.Update(rgname, account.Name, account);

                account = cognitiveServicesMgmtClient.Accounts.Get(rgname, account.Name);
                Assert.True(account.Properties.DisableLocalAuth);
            }
        }

        [Fact]
        public void CognitiveServicesAccountOutboundNetworkTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                var rgname = TestHelper.CreateResourceGroup(resourcesClient);
                var account = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname);
                Assert.Null(account.Properties.RestrictOutboundNetworkAccess);
                Assert.Null(account.Properties.AllowedFqdnList);

                account.Properties.RestrictOutboundNetworkAccess = true;
                account.Properties.AllowedFqdnList = new string[] { "abc.com", "dfe.net" };
                cognitiveServicesMgmtClient.Accounts.Update(rgname, account.Name, account);

                account = cognitiveServicesMgmtClient.Accounts.Get(rgname, account.Name);
                Assert.True(account.Properties.RestrictOutboundNetworkAccess);
                Assert.NotNull(account.Properties.AllowedFqdnList);
                Assert.True(account.Properties.AllowedFqdnList.Count == 2);
            }
        }

        [Fact]
        public void CognitiveServicesAccountCreateAndGetDifferentSkusTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                // Default parameters
                var faceAccount = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname, "Face", "S0");
                var taAccount = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname, "TextAnalytics", "S");

                var faceProperties = cognitiveServicesMgmtClient.Accounts.Get(rgname, faceAccount.Name);
                Assert.Equal("S0", faceProperties.Sku.Name);
                Assert.Equal("Face".ToString(), faceProperties.Kind);

                var taProperties = cognitiveServicesMgmtClient.Accounts.Get(rgname, taAccount.Name);
                Assert.Equal("S", taProperties.Sku.Name);
                Assert.Equal("TextAnalytics".ToString(), taProperties.Kind);
            }
        }

        [Fact]
        public void CognitiveServicesAccountListByResourceGroupTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                var accounts = cognitiveServicesMgmtClient.Accounts.ListByResourceGroup(rgname);
                Assert.Empty(accounts);

                // Create cognitive services accounts
                string accountName1 = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname).Name;
                string accountName2 = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname).Name;

                accounts = cognitiveServicesMgmtClient.Accounts.ListByResourceGroup(rgname);
                Assert.Equal(2, accounts.Count());

                TestHelper.VerifyAccountProperties(accounts.First(), true);
                TestHelper.VerifyAccountProperties(accounts.Skip(1).First(), true);
            }
        }

        [Fact]
        public void CognitiveServicesAccountListBySubscriptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);


                // Create resource group and cognitive services account
                var rgname1 = TestHelper.CreateResourceGroup(resourcesClient);
                string accountName1 = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname1).Name;

                // Create different resource group and cognitive account
                var rgname2 = TestHelper.CreateResourceGroup(resourcesClient);
                string accountName2 = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname2).Name;

                var accounts = ListAll(cognitiveServicesMgmtClient.Accounts);

                Assert.True(accounts.Count() >= 2);
            }
        }

        private List<Account> ListAll(IAccountsOperations accountsOperations, int maxPages = 10)
        {
            var accounts = new List<Account>();
            var page = accountsOperations.List();
            while (!string.IsNullOrWhiteSpace(page.NextPageLink) && maxPages > 0) {
                accounts.AddRange(page);
                maxPages = maxPages - 1;
                page = accountsOperations.ListNext(page.NextPageLink);
            }

            accounts.AddRange(page);
            return accounts;
        }

        [Fact]
        public void CognitiveServicesAccountListKeysTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                string rgname = TestHelper.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                string accountName = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname).Name;

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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                string rgname = TestHelper.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                string accountName = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname, "TextTranslation", "S2").Name;

                // Get usages
                var usages = cognitiveServicesMgmtClient.Accounts.ListUsages(rgname, accountName);

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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                string rgname = TestHelper.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                string accountName = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname).Name;

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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                var createdAccount = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname, "ComputerVision", "S0");
                var accountName = createdAccount.Name;

                // Update SKU 
                var account = cognitiveServicesMgmtClient.Accounts.Update(rgname, accountName, new Account(sku: new Sku { Name = "S1" }));
                Assert.Equal("S1", account.Sku.Name);

                // Validate
                var fetchedAccount = cognitiveServicesMgmtClient.Accounts.Get(rgname, accountName);
                Assert.Equal("S1", fetchedAccount.Sku.Name);

                var newTags = new Dictionary<string, string>
                {
                    {"key3","value3"},
                    {"key4","value4"},
                    {"key5","value5"}
                };

                // Update account tags
                account = cognitiveServicesMgmtClient.Accounts.Update(rgname, accountName, new Account(tags: newTags));
                Assert.Equal(newTags.Count, account.Tags.Count);
                // Validate
                fetchedAccount = cognitiveServicesMgmtClient.Accounts.Get(rgname, accountName);
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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                var createdAccount = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname, "Face", "S0");
                var accountName = createdAccount.Name;

                // Enumerate SKUs

                var skuList = cognitiveServicesMgmtClient.Accounts.ListSkus(rgname, accountName);

                Assert.Single(skuList.Value.Select(x => x.ResourceType).Distinct());

                Assert.Equal($"{c_resourceNamespace}/{c_resourceType}", skuList.Value.Select(x => x.ResourceType).First());

                Assert.Collection(skuList.Value.Select(x => x.Sku),
                    (sku) => { Assert.Equal("F0", sku.Name); Assert.Equal(SkuTier.Free, sku.Tier); },
                    (sku) => { Assert.Equal("S0", sku.Name); Assert.Equal(SkuTier.Standard, sku.Tier); }
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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                var accountName = TestUtilities.GenerateName("csa");
                var parameters = new Account
                {
                    Sku = new Sku { Name = "F0" },
                    Kind = "ComputerVision",
                    Location = TestHelper.DefaultLocation,
                    Properties = new AccountProperties(),
                };

                TestHelper.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Create("NotExistedRG", accountName, parameters),
                    "ResourceGroupNotFound");

                parameters.Location = "BLA";
                TestHelper.ValidateExpectedException(
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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                var accountName = TestUtilities.GenerateName("csa");
                var nonExistApiPara = new Account
                {
                    Sku = new Sku { Name = "F0" },
                    Kind = "NonExistAPI",
                    Location = TestHelper.DefaultLocation,
                    Properties = new AccountProperties(),
                };

                var nonExistSkuPara = new Account
                {
                    Sku = new Sku { Name = "N0" },
                    Kind = "Face",
                    Location = TestHelper.DefaultLocation,
                    Properties = new AccountProperties(),
                };

                TestHelper.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, nonExistApiPara),
                    "InvalidApiSetId");

                TestHelper.ValidateExpectedException(
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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                TestHelper.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Get("NotExistedRG", "nonExistedAccountName"),
                    "ResourceGroupNotFound");

                TestHelper.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Get(rgname, "nonExistedAccountName"),
                    "ResourceNotFound");

                TestHelper.ValidateExpectedException(
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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                // Create cognitive services account
                var createdAccount = TestHelper.CreateCognitiveServicesAccount(cognitiveServicesMgmtClient, rgname, "Face", "S0");
                var accountName = createdAccount.Name;

                // try to update non-existent account
                TestHelper.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Update("NotExistedRG", "nonExistedAccountName", new Account()),
                    "ResourceGroupNotFound");

                TestHelper.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Update(rgname, "nonExistedAccountName", new Account()),
                    "ResourceNotFound");

                // Update with a SKU which doesn't exist
                TestHelper.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.Update(rgname, accountName, new Account(sku: new Sku("P1"))),
                    "InvalidSkuId");
            }
        }

        [Fact]
        public void CognitiveServicesDeleteAccountErrorTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                // try to delete non-existent account
                TestHelper.ValidateExpectedException(
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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                TestHelper.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.ListKeys("NotExistedRG", "nonExistedAccountName"),
                    "ResourceGroupNotFound");

                TestHelper.ValidateExpectedException(
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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                TestHelper.ValidateExpectedException(
                    () => cognitiveServicesMgmtClient.Accounts.ListSkus("NotExistedRG", "nonExistedAccountName"),
                    "ResourceGroupNotFound");

                TestHelper.ValidateExpectedException(
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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                var skus = cognitiveServicesMgmtClient.CheckSkuAvailability(
                    location: "centraluseuap",
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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                var domainAvailability = cognitiveServicesMgmtClient.CheckDomainAvailability(
                    subdomainName: "atestsubdomain",
                    type: $"{c_resourceNamespace}/{c_resourceType}");

                Assert.NotNull(domainAvailability);
                Assert.NotNull(domainAvailability.SubdomainName);

                var domainAvailabilityWithKind = cognitiveServicesMgmtClient.CheckDomainAvailability(
                    subdomainName: "atestsubdomain",
                    kind: "OpenAI",
                    type: $"{c_resourceNamespace}/{c_resourceType}");

                Assert.NotNull(domainAvailabilityWithKind);
                Assert.NotNull(domainAvailabilityWithKind.SubdomainName);
            }
        }

        [Fact]
        public void CognitiveServicesResourceSkusListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                var parameters = new Account
                {
                    Sku = new Sku { Name = "S0" },
                    Kind = "Face",
                    Location = TestHelper.DefaultLocation,
                    Properties = new AccountProperties(),
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
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                { // create with MSI
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    var parameters = new Account
                    {
                        Location = TestHelper.DefaultLocation,
                        Tags = TestHelper.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "Face",
                        Properties = new AccountProperties(),
                    };

                    // custom parameters
                    parameters.Identity = new Identity(ResourceIdentityType.SystemAssigned, null, null, null);

                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Identity);
                    Assert.False(string.IsNullOrEmpty(account.Identity.PrincipalId));
                    Assert.False(string.IsNullOrEmpty(account.Identity.TenantId));
                    Assert.Equal(ResourceIdentityType.SystemAssigned, account.Identity.Type);
                }

                { // patch with MSI
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    var parameters = new Account
                    {
                        Location = TestHelper.DefaultLocation,
                        Tags = TestHelper.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "Face",
                        Properties = new AccountProperties(),
                    };

                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    // custom parameters
                    parameters = account;
                    parameters.Identity = new Identity(ResourceIdentityType.SystemAssigned, null, null, null);
                    account = cognitiveServicesMgmtClient.Accounts.Update(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Identity);
                    Assert.False(string.IsNullOrEmpty(account.Identity.PrincipalId));
                    Assert.False(string.IsNullOrEmpty(account.Identity.TenantId));
                    Assert.Equal(ResourceIdentityType.SystemAssigned, account.Identity.Type);
                }
            }
        }

        [Fact]
        public void CognitiveServicesAccountEncryptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                { // create with Encryption
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    var parameters = new Account
                    {
                        Location = TestHelper.DefaultLocation,
                        Tags = TestHelper.DefaultTags,
                        Sku = new Sku { Name = "E0" },
                        Kind = "Face",
                        Properties = new AccountProperties(),
                    };

                    // custom parameters
                    parameters.Identity = new Identity(ResourceIdentityType.SystemAssignedUserAssigned, null, null, new Dictionary<string, UserAssignedIdentity>() {});
                    parameters.Identity.UserAssignedIdentities.Add("/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/yuanyang/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-test-mi", new UserAssignedIdentity() {});

                    parameters.Properties.Encryption = new Encryption(
                        new KeyVaultProperties()
                        {
                            KeyName = "TestKey",
                            KeyVersion = "649d33694df9450cbf2d03c885f7a72f",
                            KeyVaultUri = "https://sdk-test-mi-usc.vault.azure.net/",
                            IdentityClientId = "9feb3cc7-408c-449d-8baf-f3dd44ad292b"
                        },
                        KeySource.MicrosoftKeyVault);

                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.BeginCreate(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Properties?.Encryption);
                    Assert.NotNull(account?.Properties?.Encryption?.KeyVaultProperties);
                    Assert.Equal(parameters.Properties.Encryption.KeySource, account.Properties.Encryption.KeySource);
                    Assert.Equal(parameters.Properties.Encryption.KeyVaultProperties.KeyName, account.Properties.Encryption.KeyVaultProperties.KeyName);
                    Assert.Equal(parameters.Properties.Encryption.KeyVaultProperties.KeyVersion, account.Properties.Encryption.KeyVaultProperties.KeyVersion);
                    Assert.Equal(parameters.Properties.Encryption.KeyVaultProperties.KeyVaultUri, account.Properties.Encryption.KeyVaultProperties.KeyVaultUri);
                    Assert.Equal(parameters.Properties.Encryption.KeyVaultProperties.IdentityClientId, account.Properties.Encryption.KeyVaultProperties.IdentityClientId);
                    Assert.NotNull(account?.Identity);
                    Assert.False(string.IsNullOrEmpty(account.Identity.PrincipalId));
                    Assert.False(string.IsNullOrEmpty(account.Identity.TenantId));
                    Assert.NotNull(account.Identity.UserAssignedIdentities);
                    Assert.Equal(ResourceIdentityType.SystemAssignedUserAssigned, account.Identity.Type);
                }

                { // patch with Encryption
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    var parameters = new Account
                    {
                        Location = TestHelper.DefaultLocation,
                        Tags = TestHelper.DefaultTags,
                        Sku = new Sku { Name = "E0" },
                        Kind = "Face",
                        Properties = new AccountProperties(),
                    };

                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    // custom parameters
                    parameters = account;
                    parameters.Identity = new Identity(ResourceIdentityType.UserAssigned, null, null, new Dictionary<string, UserAssignedIdentity>() { });
                    parameters.Identity.UserAssignedIdentities.Add("/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/yuanyang/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-test-mi", new UserAssignedIdentity() { });

                    parameters.Properties.Encryption = new Encryption(
                        new KeyVaultProperties()
                        {
                            KeyName = "TestKey",
                            KeyVersion = "649d33694df9450cbf2d03c885f7a72f",
                            KeyVaultUri = "https://sdk-test-mi-usc.vault.azure.net/",
                            IdentityClientId = "9feb3cc7-408c-449d-8baf-f3dd44ad292b"
                        },
                        KeySource.MicrosoftKeyVault);

                    account = cognitiveServicesMgmtClient.Accounts.BeginUpdate(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Properties?.Encryption);
                    Assert.NotNull(account?.Properties?.Encryption?.KeyVaultProperties);
                    Assert.Equal(parameters.Properties.Encryption.KeySource, account.Properties.Encryption.KeySource);
                    Assert.Equal(parameters.Properties.Encryption.KeyVaultProperties.KeyName, account.Properties.Encryption.KeyVaultProperties.KeyName);
                    Assert.Equal(parameters.Properties.Encryption.KeyVaultProperties.KeyVersion, account.Properties.Encryption.KeyVaultProperties.KeyVersion);
                    Assert.Equal(parameters.Properties.Encryption.KeyVaultProperties.KeyVaultUri, account.Properties.Encryption.KeyVaultProperties.KeyVaultUri);
                    Assert.NotNull(account?.Identity);
                    Assert.NotNull(account.Identity.UserAssignedIdentities);
                    Assert.Equal(ResourceIdentityType.UserAssigned, account.Identity.Type);
                }
            }
        }


        [Fact]
        public void CognitiveServicesAccountUserOwnedStorageTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                { // create with UserOwnedStorage
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    var parameters = new Account
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = TestHelper.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "SpeechServices",
                        Properties = new AccountProperties(),
                    };

                    // custom parameters
                    parameters.Identity = new Identity(ResourceIdentityType.SystemAssignedUserAssigned, null, null, new Dictionary<string, UserAssignedIdentity>() { });
                    parameters.Identity.UserAssignedIdentities.Add("/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/yuanyang/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sdk-test-mi", new UserAssignedIdentity() { });

                    parameters.Properties.UserOwnedStorage = new List<UserOwnedStorage>()
                    {
                        new UserOwnedStorage()
                        {
                            ResourceId = "/subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/felixwa-01/providers/Microsoft.Storage/storageAccounts/felixwatest",
                            IdentityClientId = "9feb3cc7-408c-449d-8baf-f3dd44ad292b"
                        }
                    };

                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Properties?.UserOwnedStorage);
                    Assert.True(account.Properties.UserOwnedStorage.Count == 1);
                    Assert.Equal(parameters.Properties.UserOwnedStorage[0].ResourceId, account.Properties.UserOwnedStorage[0].ResourceId);
                    Assert.Equal(parameters.Properties.UserOwnedStorage[0].IdentityClientId, account.Properties.UserOwnedStorage[0].IdentityClientId);
                    Assert.NotNull(account?.Identity);
                    Assert.False(string.IsNullOrEmpty(account.Identity.PrincipalId));
                    Assert.False(string.IsNullOrEmpty(account.Identity.TenantId));
                    Assert.Equal(ResourceIdentityType.SystemAssignedUserAssigned, account.Identity.Type);
                }

                { // patch with UserOwnedStorage
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    var parameters = new Account
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = TestHelper.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "SpeechServices",
                        Properties = new AccountProperties(),
                    };

                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    // custom parameters
                    parameters = account;
                    parameters.Identity = new Identity(ResourceIdentityType.SystemAssigned, null, null, null);
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
                    Assert.Equal(ResourceIdentityType.SystemAssigned, account.Identity.Type);
                }
            }
        }

        [Fact]
        public void CognitiveServicesAccountPrivateEndpointConnectionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                {
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    var parameters = new Account
                    {
                        Location = TestHelper.DefaultLocation,
                        Tags = TestHelper.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "Face",
                        Properties = new AccountProperties(),
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

                    var plConnections = cognitiveServicesMgmtClient.PrivateEndpointConnections.List(rgname, accountName);
                    Assert.True(plConnections.Value.Count == 0);

                }
            }
        }

        [Fact]
        public void CognitiveServicesAccountCapabilityTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                { // create with Encryption
                    // prepare account properties
                    string accountName = TestUtilities.GenerateName("csa");
                    var parameters = new Account
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = TestHelper.DefaultTags,
                        Sku = new Sku { Name = "F0" },
                        Kind = "FormRecognizer",
                        Properties = new AccountProperties(),
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

        [Fact]
        public void CognitiveServicesAccountCommitmentPlanTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                var commitmentTiers = new List<CommitmentTier>(cognitiveServicesMgmtClient.CommitmentTiers.List("centraluseuap"));
                Assert.True(commitmentTiers.Count > 0);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                {
                    string accountName = TestUtilities.GenerateName("csa");
                    var parameters = new Account
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = TestHelper.DefaultTags,
                        Sku = new Sku { Name = "S" },
                        Kind = "TextAnalytics",
                        Properties = new AccountProperties(),
                    };
                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Properties?.Capabilities);
                    Assert.True(account?.Properties?.Capabilities.Count > 0);
                    Assert.True(account?.Properties?.Capabilities[0].Name.Length > 0);

                    var plan = new CommitmentPlan();
                    plan.Properties = new CommitmentPlanProperties();
                    plan.Properties.HostingModel = "Web";
                    plan.Properties.AutoRenew = false;
                    plan.Properties.PlanType = "TA";
                    plan.Properties.Current = new CommitmentPeriod();
                    plan.Properties.Current.Tier = "T1";

                    var planResp = cognitiveServicesMgmtClient.CommitmentPlans.CreateOrUpdate(rgname, accountName, "plan", plan);
                    Assert.Equal(plan.Properties.HostingModel, planResp.Properties.HostingModel);
                    Assert.Equal(plan.Properties.AutoRenew, planResp.Properties.AutoRenew);
                    Assert.Equal(plan.Properties.Current.Tier, planResp.Properties.Current.Tier);

                    planResp = cognitiveServicesMgmtClient.CommitmentPlans.Get(rgname, accountName, "plan");
                    Assert.Equal(plan.Properties.HostingModel, planResp.Properties.HostingModel);
                    Assert.Equal(plan.Properties.AutoRenew, planResp.Properties.AutoRenew);
                    Assert.Equal(plan.Properties.Current.Tier, planResp.Properties.Current.Tier);

                    var plansResp = cognitiveServicesMgmtClient.CommitmentPlans.List(rgname, accountName);
                    Assert.True(plansResp.Count() > 0);

                    cognitiveServicesMgmtClient.CommitmentPlans.Delete(rgname, accountName, "plan");
                    plansResp = cognitiveServicesMgmtClient.CommitmentPlans.List(rgname, accountName);
                    Assert.True(plansResp.Count() == 0);
                }
            }
        }

        [Fact]
        public void CognitiveServicesAccountDeploymentTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                {
                    string accountName = TestUtilities.GenerateName("csa");
                    var parameters = new Account
                    {
                        Location = "SOUTHCENTRALUS",
                        Tags = TestHelper.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "OpenAI",
                        Properties = new AccountProperties(),
                    };
                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Properties?.Capabilities);
                    Assert.True(account?.Properties?.Capabilities.Count > 0);
                    Assert.True(account?.Properties?.Capabilities[0].Name.Length > 0);

                    var dpy = new Deployment();
                    dpy.Properties = new DeploymentProperties();
                    dpy.Properties.Model = new DeploymentModel();
                    dpy.Properties.Model.Format = "OpenAI";
                    dpy.Properties.Model.Name = "text-ada-001";
                    dpy.Properties.Model.Version = "1";
                    dpy.Properties.ScaleSettings = new DeploymentScaleSettings();
                    dpy.Properties.ScaleSettings.ScaleType = "Standard";

                    var dpyResp = cognitiveServicesMgmtClient.Deployments.BeginCreateOrUpdate(rgname, accountName, "deployment", dpy);
                    Assert.Equal(dpy.Properties.Model.Format, dpyResp.Properties.Model.Format);
                    Assert.Equal(dpy.Properties.Model.Name, dpyResp.Properties.Model.Name);
                    Assert.Equal(dpy.Properties.Model.Version, dpyResp.Properties.Model.Version);
                    Assert.Equal(dpy.Properties.ScaleSettings.Capacity, dpyResp.Properties.ScaleSettings.Capacity);
                    Assert.Equal(dpy.Properties.ScaleSettings.ScaleType, dpyResp.Properties.ScaleSettings.ScaleType);

                    dpyResp = cognitiveServicesMgmtClient.Deployments.Get(rgname, accountName, "deployment");
                    Assert.Equal(dpy.Properties.Model.Format, dpyResp.Properties.Model.Format);
                    Assert.Equal(dpy.Properties.Model.Name, dpyResp.Properties.Model.Name);
                    Assert.Equal(dpy.Properties.Model.Version, dpyResp.Properties.Model.Version);
                    Assert.Equal(dpy.Properties.ScaleSettings.Capacity, dpyResp.Properties.ScaleSettings.Capacity);
                    Assert.Equal(dpy.Properties.ScaleSettings.ScaleType, dpyResp.Properties.ScaleSettings.ScaleType);

                    var dpysResp = cognitiveServicesMgmtClient.Deployments.List(rgname, accountName);
                    Assert.True(dpysResp.Count() > 0);

                    cognitiveServicesMgmtClient.Deployments.Delete(rgname, accountName, "deployment");
                    dpysResp = cognitiveServicesMgmtClient.Deployments.List(rgname, accountName);
                    Assert.True(dpysResp.Count() == 0);
                }
            }
        }

        [Fact]
        public void CognitiveServicesAccountModelsTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                {
                    string accountName = TestUtilities.GenerateName("csa");
                    var parameters = new Account
                    {
                        Location = "EASTUS",
                        Tags = TestHelper.DefaultTags,
                        Sku = new Sku { Name = "S0" },
                        Kind = "OpenAI",
                        Properties = new AccountProperties(),
                    };
                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    // verify
                    Assert.NotNull(account?.Properties?.Capabilities);
                    Assert.True(account?.Properties?.Capabilities.Count > 0);
                    Assert.True(account?.Properties?.Capabilities[0].Name.Length > 0);

                    var dpy = new Deployment();
                    dpy.Properties = new DeploymentProperties();
                    dpy.Properties.Model = new DeploymentModel();
                    dpy.Properties.Model.Format = "OpenAI";
                    dpy.Properties.Model.Name = "ada";
                    dpy.Properties.Model.Version = "1";
                    dpy.Properties.ScaleSettings = new DeploymentScaleSettings();
                    dpy.Properties.ScaleSettings.Capacity = 1;
                    dpy.Properties.ScaleSettings.ScaleType = "Manual";

                    var modelsResp = cognitiveServicesMgmtClient.Accounts.ListModels(rgname, accountName);
                    Assert.True(modelsResp.Count() >= 0);
                }
            }
        }


        [Fact]
        public void CognitiveServicesAccountDynamicThrottlingEnabledTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = TestHelper.GetResourceManagementClient(context, handler);
                var cognitiveServicesMgmtClient = TestHelper.GetCognitiveServicesManagementClient(context, handler);

                // Create resource group
                var rgname = TestHelper.CreateResourceGroup(resourcesClient);

                {
                    string accountName = TestUtilities.GenerateName("csa");
                    var parameters = new Account
                    {
                        Location = "CENTRALUSEUAP",
                        Tags = TestHelper.DefaultTags,
                        Sku = new Sku { Name = "S" },
                        Kind = "TextAnalytics",
                        Properties = new AccountProperties(),
                    };
                    // Create cognitive services account
                    var account = cognitiveServicesMgmtClient.Accounts.Create(rgname, accountName, parameters);

                    Assert.Null(account.Properties.DynamicThrottlingEnabled);

                    parameters.Properties.DynamicThrottlingEnabled = false;

                    account = cognitiveServicesMgmtClient.Accounts.Update(rgname, accountName, parameters);
                    Assert.False(account.Properties.DynamicThrottlingEnabled);

                    // Currently no Kind has DynamicThrottlingEnabled.
                }
            }
        }
    }
}