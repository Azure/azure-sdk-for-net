// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class GroupTests : ApiManagementManagementTestBase
    {
        public GroupTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceData(AzureLocation.WestUS2, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.StandardV2, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetApiManagementGroups();

            // list all groups
            var groupsList = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(groupsList.Count, Is.EqualTo(3));

            // create a new group
            var newGroupId = Recording.GenerateAssetName("sdkGroupId");
            var newGroupDisplayName = Recording.GenerateAssetName("sdkGroup");
            var parameters = new ApiManagementGroupCreateOrUpdateContent()
            {
                DisplayName = newGroupDisplayName,
                Description = "Group created from Sdk client"
            };

            await collection.CreateOrUpdateAsync(WaitUntil.Completed, newGroupId, parameters);
            var groupContract = (await collection.GetAsync(newGroupId)).Value;
            Assert.That(groupContract, Is.Not.Null);
            Assert.That(groupContract.Data.DisplayName, Is.EqualTo(newGroupDisplayName));
            Assert.That(groupContract.Data.IsBuiltIn, Is.False);
            Assert.That(groupContract.Data.Description, Is.Not.Null);
            Assert.That(groupContract.Data.GroupType, Is.EqualTo(ApiManagementGroupType.Custom));

            // update the group
            var updateParameters = new ApiManagementGroupPatch
            {
                Description = "Updating the description of the Sdk"
            };
            await groupContract.UpdateAsync(ETag.All, updateParameters);

            // get the updatedGroup
            var updatedResponse = (await groupContract.GetAsync()).Value;
            Assert.That(updatedResponse, Is.Not.Null);
            Assert.That(updatedResponse.Data.DisplayName, Is.EqualTo(newGroupDisplayName));
            Assert.That(updatedResponse.Data.IsBuiltIn, Is.False);
            Assert.That(updatedResponse.Data.Description, Is.Not.Null);
            Assert.That(updatedResponse.Data.Description, Is.EqualTo(updateParameters.Description));
            Assert.That(updatedResponse.Data.GroupType, Is.EqualTo(ApiManagementGroupType.Custom));

            // delete the group
            await updatedResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            var falseResult = (await collection.ExistsAsync(newGroupId)).Value;
            Assert.That(falseResult, Is.False);
        }
    }
}
