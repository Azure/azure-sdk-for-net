// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.OracleDatabase.Models;
using System;

namespace Azure.ResourceManager.OracleDatabase.Tests.Scenario
{
    [TestFixture]
    public class ExaInfraTests : OracleDatabaseManagementTestBase
    {
        private string cloudExadataInfrastructureName;
        public ExaInfraTests() : base(true, RecordedTestMode.Record)
        {
        }
        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback){
                await CreateCommonClient();
            }
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        private CloudExadataInfrastructurePatch GetCloudExadataInfrastructurePatch(string tagName, string tagValue) {
            ChangeTrackingDictionary<string, string> tags = new ChangeTrackingDictionary<string, string>
            {
                new KeyValuePair<string, string>(tagName, tagValue)
            };
            var customerContact = new CustomerContact() {
                Email = Recording.GenerateAssetName("Email")
            };
            IList<CustomerContact> customerContacts = new List<CustomerContact>{customerContact};
            return new CloudExadataInfrastructurePatch(
                new List<string>{ "2" }, tags, 2, 3, default, customerContacts, cloudExadataInfrastructureName, default);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestExaInfraOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("NetSdkTestRg");
            await TryRegisterResourceGroupAsync(ResourceGroupsOperations, "eastus", resourceGroupName);
            CloudExadataInfrastructureCollection cloudExadataInfrastructureCollection = await GetCloudExadataInfrastructureCollectionAsync(resourceGroupName);
            cloudExadataInfrastructureName = Recording.GenerateAssetName("OFake_NetSdkTestExaInfra");
            CloudExadataInfrastructureData exadataInfrastructureData = GetDefaultCloudExadataInfrastructureData(cloudExadataInfrastructureName);

            // Create
            var createExadataOperation = await cloudExadataInfrastructureCollection.CreateOrUpdateAsync(WaitUntil.Completed,
            cloudExadataInfrastructureName, exadataInfrastructureData);
            await createExadataOperation.WaitForCompletionAsync();
            Assert.IsTrue(createExadataOperation.HasCompleted);
            Assert.IsTrue(createExadataOperation.HasValue);

            // Get
            Response<CloudExadataInfrastructureResource> getExaInfraResponse = await cloudExadataInfrastructureCollection.GetAsync(cloudExadataInfrastructureName);
            CloudExadataInfrastructureResource exaInfraResource = getExaInfraResponse.Value;
            Assert.IsNotNull(exaInfraResource);

            // ListByResourceGroup
            AsyncPageable<CloudExadataInfrastructureResource> exaInfras = cloudExadataInfrastructureCollection.GetAllAsync();
            List<CloudExadataInfrastructureResource> exaInfraResult = await exaInfras.ToEnumerableAsync();
            Assert.NotNull(exaInfraResult);
            Assert.IsTrue(exaInfraResult.Count >= 1);

            // ListBySubscription
            exaInfras = OracleDatabaseExtensions.GetCloudExadataInfrastructuresAsync(DefaultSubscription);
            exaInfraResult = await exaInfras.ToEnumerableAsync();
            Assert.NotNull(exaInfraResult);
            Assert.IsTrue(exaInfraResult.Count >= 1);

            // // Update - TODO: Updating ExaInfra currently unsupported, add this back when updates are supported.
            // var tagName = Recording.GenerateAssetName("TagName");
            // var tagValue = Recording.GenerateAssetName("TagValue");
            // CloudExadataInfrastructurePatch exaInfraParameter = GetCloudExadataInfrastructurePatch(tagName, tagValue);
            // var updateExaInfraOperation = await exaInfraResource.UpdateAsync(WaitUntil.Completed, exaInfraParameter);
            // Assert.IsTrue(updateExaInfraOperation.HasCompleted);
            // Assert.IsTrue(updateExaInfraOperation.HasValue);

            // // Get after Update
            // getExaInfraResponse = await cloudExadataInfrastructureCollection.GetAsync(cloudExadataInfrastructureName);
            // exaInfraResource = getExaInfraResponse.Value;
            // Assert.IsNotNull(exaInfraResource);
            // Assert.IsTrue(exaInfraResource.Data.Tags.ContainsKey(tagName));

            // Delete
            var deleteExaInfraOperation = await exaInfraResource.DeleteAsync(WaitUntil.Completed);
            await deleteExaInfraOperation.WaitForCompletionResponseAsync();
            Assert.IsTrue(deleteExaInfraOperation.HasCompleted);
        }
    }
}