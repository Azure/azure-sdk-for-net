// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Storage.Models;
using Azure.Management.Storage.Tests.Helpers;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace Azure.Management.Storage.Tests
{
    public class FileServiceTests : StorageTestsManagementClientBase
    {
        public FileServiceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        // create share
        // delete share
        [Test]
        public async Task FileSharesCreateDeleteListTest()
        {
            // Create resource group
            string rgName = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                StorageAccount account = await _CreateStorageAccountAsync(rgName, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // implement case
                string shareName = Recording.GenerateAssetName("share");
                FileShare fileShare = new FileShare();
                Response<FileShare> share = await FileSharesClient.CreateAsync(rgName, accountName, shareName, fileShare);
                Assert.Null(share.Value.Metadata);

                share = await FileSharesClient.GetAsync(rgName, accountName, shareName);
                Assert.Null(share.Value.Metadata);

                string shareName2 = Recording.GenerateAssetName("share");
                fileShare.Metadata = new Dictionary<string, string>
                {
                    { "metadata1", "true" },
                    { "metadata2", "value2" }
                };
                fileShare.ShareQuota = 500;
                Response<FileShare> share2 = await FileSharesClient.CreateAsync(rgName, accountName, shareName2, fileShare);
                Assert.AreEqual(2, share2.Value.Metadata.Count);
                Assert.AreEqual(fileShare.Metadata, share2.Value.Metadata);
                Assert.AreEqual(fileShare.ShareQuota, share2.Value.ShareQuota);

                share2 = await FileSharesClient.GetAsync(rgName, accountName, shareName2);
                Assert.AreEqual(2, share2.Value.Metadata.Count);
                Assert.AreEqual(fileShare.Metadata, share2.Value.Metadata);
                Assert.AreEqual(fileShare.ShareQuota, share2.Value.ShareQuota);

                //Delete share
                await FileSharesClient.DeleteAsync(rgName, accountName, shareName);
                AsyncPageable<FileShareItem> fileShares = FileSharesClient.ListAsync(rgName, accountName);
                Task<List<FileShareItem>> fileSharesList = fileShares.ToEnumerableAsync();
                Assert.AreEqual(1, fileSharesList.Result.Count());

                await FileSharesClient.DeleteAsync(rgName, accountName, shareName2);
                fileShares = FileSharesClient.ListAsync(rgName, accountName);
                fileSharesList = fileShares.ToEnumerableAsync();
                Assert.AreEqual(0, fileSharesList.Result.Count());

                //Delete not exist share, won't fail (return 204)
                await FileSharesClient.DeleteAsync(rgName, accountName, "notexistshare");
            }
            finally
            {
                //Detele storage account
                await _DeleteStorageAccountAsync(rgName, accountName);

                //Delete resource group
                await _DeleteResourceGroupAsync(rgName);
            }
        }

        // update share
        // get share properties
        [Test]
        public async Task FileSharesUpdateGetTest()
        {
            // Create resource group
            var rgName = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                Sku sku = new Sku(SkuName.StandardLRS);
                StorageAccountCreateParameters parameters = StorageManagementTestUtilities.GetDefaultStorageAccountParameters(Sku: sku, Kind: Kind.StorageV2, Location: "westeurope");
                parameters.LargeFileSharesState = LargeFileSharesState.Enabled;
                await _CreateStorageAccountAsync(rgName, accountName, parameters);

                // implement case
                string shareName = Recording.GenerateAssetName("share");
                FileShare fileShare = new FileShare();
                Response<FileShare> share = await FileSharesClient.CreateAsync(rgName, accountName, shareName, fileShare);
                Assert.Null(share.Value.Metadata);

                fileShare.Metadata = new Dictionary<string, string>
                {
                    { "metadata1", "true" },
                    { "metadata2", "value2" }
                };
                fileShare.ShareQuota = 5200;
                Response<FileShare> shareSet = await FileSharesClient.UpdateAsync(rgName, accountName, shareName, fileShare);
                Assert.NotNull(shareSet.Value.Metadata);
                Assert.AreEqual(fileShare.ShareQuota, shareSet.Value.ShareQuota);
                Assert.AreEqual(fileShare.Metadata, shareSet.Value.Metadata);

                Response<FileShare> shareGet = await FileSharesClient.GetAsync(rgName, accountName, shareName);
                Assert.NotNull(shareSet.Value.Metadata);
                Assert.AreEqual(fileShare.Metadata, shareGet.Value.Metadata);
                Assert.AreEqual(fileShare.ShareQuota, shareGet.Value.ShareQuota);
            }
            finally
            {
                //Detele storage account
                await _DeleteStorageAccountAsync(rgName, accountName);

                //Delete resource group
                await _DeleteResourceGroupAsync(rgName);
            }
        }

        // Get/Set File Service Properties
        [Test]
        public async Task FileServiceCorsTest()
        {
            // Create resource group
            var rgName = await _CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            try
            {
                // Create storage account
                StorageAccount account = await _CreateStorageAccountAsync(rgName, accountName);
                StorageManagementTestUtilities.VerifyAccountProperties(account, true);

                // implement case
                Response<FileServiceProperties> properties1 = await FileServicesClient.GetServicePropertiesAsync(rgName, accountName);
                Assert.AreEqual(0, properties1.Value.Cors.CorsRulesValue.Count());

                properties1.Value.Cors = new CorsRules
                {
                    CorsRulesValue = new List<CorsRule>
                    {
                        new CorsRule(allowedOrigins: new string[] { "http://www.contoso.com", "http://www.fabrikam.com" },
                        allowedMethods: new CorsRuleAllowedMethodsItem[] { "GET", "HEAD", "POST", "OPTIONS", "MERGE", "PUT" },
                        maxAgeInSeconds: 100,
                        exposedHeaders: new string[] { "x-ms-meta-*" },
                        allowedHeaders: new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" }),

                        new CorsRule(allowedOrigins: new string[] { "*" },
                        allowedMethods: new CorsRuleAllowedMethodsItem[] { "GET" },
                        maxAgeInSeconds: 2,
                        exposedHeaders: new string[] { "*" },
                        allowedHeaders: new string[] { "*" }),

                        new CorsRule(allowedOrigins: new string[] { "http://www.abc23.com", "https://www.fabrikam.com/*" },
                        allowedMethods: new CorsRuleAllowedMethodsItem[] { "GET", "PUT", "CONNECT" },
                        maxAgeInSeconds: 2000,
                        exposedHeaders: new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x -ms-meta-target*" },
                        allowedHeaders: new string[] { "x-ms-meta-12345675754564*" })
                    }
                };

                Response<FileServiceProperties> properties3 = await FileServicesClient.SetServicePropertiesAsync(rgName, accountName, properties1.Value);

                //Validate CORS Rules
                Assert.AreEqual(properties1.Value.Cors.CorsRulesValue.Count, properties3.Value.Cors.CorsRulesValue.Count);
                for (int i = 0; i < properties1.Value.Cors.CorsRulesValue.Count; i++)
                {
                    CorsRule putRule = properties1.Value.Cors.CorsRulesValue[i];
                    CorsRule getRule = properties3.Value.Cors.CorsRulesValue[i];

                    Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                    Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                    Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                    Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                    Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
                }

                Response<FileServiceProperties> properties4 = await FileServicesClient.GetServicePropertiesAsync(rgName, accountName);

                //Validate CORS Rules
                Assert.AreEqual(properties1.Value.Cors.CorsRulesValue.Count, properties4.Value.Cors.CorsRulesValue.Count);
                for (int i = 0; i < properties1.Value.Cors.CorsRulesValue.Count; i++)
                {
                    CorsRule putRule = properties1.Value.Cors.CorsRulesValue[i];
                    CorsRule getRule = properties4.Value.Cors.CorsRulesValue[i];

                    Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                    Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                    Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                    Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                    Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
                }

            }
            finally
            {
                //Detele storage account
                await _DeleteStorageAccountAsync(rgName, accountName);

                //Delete resource group
                await _DeleteResourceGroupAsync(rgName);
            }
        }


        private async Task<string> _CreateResourceGroupAsync()
        {
            return await StorageManagementTestUtilities.CreateResourceGroup(ResourceGroupsClient, Recording);
        }

        private async Task<StorageAccount> _CreateStorageAccountAsync(string ResourceGroupName, string AccountName, StorageAccountCreateParameters Parameters = null)
        {
            StorageAccountCreateParameters saParameters = Parameters ?? StorageManagementTestUtilities.GetDefaultStorageAccountParameters();
            Operation<StorageAccount> accountsResponse = await AccountsClient.StartCreateAsync(ResourceGroupName, AccountName, saParameters);
            StorageAccount account = (await accountsResponse.WaitForCompletionAsync()).Value;
            return account;
        }

        private async Task<Response> _DeleteStorageAccountAsync(string ResourceGroupName, string AccountName)
        {
            return await AccountsClient.DeleteAsync(ResourceGroupName, AccountName);
        }

        private async Task _DeleteResourceGroupAsync(string ResourceGroupName)
        {
            await ResourceGroupsClient.StartDeleteAsync(ResourceGroupName);
        }
    }
}
