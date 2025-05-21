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
            Assert.AreEqual(3, groupsList.Count);

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
            Assert.NotNull(groupContract);
            Assert.AreEqual(newGroupDisplayName, groupContract.Data.DisplayName);
            Assert.IsFalse(groupContract.Data.IsBuiltIn);
            Assert.NotNull(groupContract.Data.Description);
            Assert.AreEqual(ApiManagementGroupType.Custom, groupContract.Data.GroupType);

            // update the group
            var updateParameters = new ApiManagementGroupPatch
            {
                Description = "Updating the description of the Sdk"
            };
            await groupContract.UpdateAsync(ETag.All, updateParameters);

            // get the updatedGroup
            var updatedResponse = (await groupContract.GetAsync()).Value;
            Assert.NotNull(updatedResponse);
            Assert.AreEqual(newGroupDisplayName, updatedResponse.Data.DisplayName);
            Assert.IsFalse(updatedResponse.Data.IsBuiltIn);
            Assert.NotNull(updatedResponse.Data.Description);
            Assert.AreEqual(updateParameters.Description, updatedResponse.Data.Description);
            Assert.AreEqual(ApiManagementGroupType.Custom, updatedResponse.Data.GroupType);

            // delete the group
            await updatedResponse.DeleteAsync(WaitUntil.Completed, ETag.All);
            var falseResult = (await collection.ExistsAsync(newGroupId)).Value;
            Assert.IsFalse(falseResult);
        }
    }
}
