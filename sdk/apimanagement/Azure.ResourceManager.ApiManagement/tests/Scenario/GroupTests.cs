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

        private ApiManagementServiceResourceCollection ApiServiceCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync();
            ApiServiceCollection = ResourceGroup.GetApiManagementServiceResources();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("sdktestapimv2-");
            var data = new ApiManagementServiceResourceData(AzureLocation.WestUS2, "Sample@Sample.com", "sample", new ApiManagementServiceSkuProperties(SkuType.StandardV2, 1))
            {
                Identity = new ApiManagementServiceIdentity(ApimIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var collection = ApiServiceResource.GetGroups();

            // list all groups
            var groupsList = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(3, groupsList.Count);

            // create a new group
            var newGroupId = Recording.GenerateAssetName("sdkGroupId");
            var newGroupDisplayName = Recording.GenerateAssetName("sdkGroup");
            var parameters = new GroupCreateContent()
            {
                Description = "Group created from Sdk client"
            };

            await collection.CreateOrUpdateAsync(WaitUntil.Completed, newGroupId, parameters);
            var groupContract = (await collection.GetAsync(newGroupId)).Value;
            Assert.NotNull(groupContract);
            Assert.IsFalse(groupContract.Data.BuiltIn);
            Assert.NotNull(groupContract.Data.Description);
            Assert.AreEqual(ApiManagementGroupType.Custom, groupContract.Data.Type);

            // update the group
            var updateParameters = new GroupPatch
            {
                Description = "Updating the description of the Sdk"
            };
            await groupContract.UpdateAsync(ETag.All.ToString(), updateParameters);

            // get the updatedGroup
            var updatedResponse = (await groupContract.GetAsync()).Value;
            Assert.NotNull(updatedResponse);
            Assert.IsFalse(updatedResponse.Data.BuiltIn);
            Assert.NotNull(updatedResponse.Data.Description);
            Assert.AreEqual(updateParameters.Description, updatedResponse.Data.Description);
            Assert.AreEqual(ApiManagementGroupType.Custom, updatedResponse.Data.Type);

            // delete the group
            await updatedResponse.DeleteAsync(WaitUntil.Completed, ETag.All.ToString());
            var falseResult = (await collection.ExistsAsync(newGroupId)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
