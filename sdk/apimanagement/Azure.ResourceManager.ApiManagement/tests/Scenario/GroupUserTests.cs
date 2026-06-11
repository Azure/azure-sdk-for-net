// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class GroupUserTests : ApiManagementManagementTestBase
    {
        public GroupUserTests(bool isAsync)
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
            var groupCollection = ApiServiceResource.GetGroups();

            var newGroupId = Recording.GenerateAssetName("sdkGroupId");
            var newGroupDisplayName = Recording.GenerateAssetName("sdkGroup");
            var parameters = new GroupCreateContent()
            {
                Description = "Group created from Sdk client"
            };

            var groupContract = (await groupCollection.CreateOrUpdateAsync(WaitUntil.Completed, newGroupId, parameters)).Value;
            Assert.NotNull(groupContract);
            Assert.IsFalse(groupContract.Data.BuiltIn);
            Assert.NotNull(groupContract.Data.Description);
            Assert.AreEqual(ApiManagementGroupType.Custom, groupContract.Data.Type);

            var userId = Recording.GenerateAssetName("sdkUserId");
            var collection = ApiServiceResource.GetApiManagementUsers();

            // list all group users
            var listResponse = await groupContract.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(listResponse);

            // create a new user and add to the group
            var createParameters = new UserCreateContent()
            {
                State = ApiManagementUserState.Active,
                Note = "dummy note"
            };
            var userContract = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, userId, createParameters)).Value;
            Assert.NotNull(userContract);

            // add user to group
            var addUserContract = (await groupContract.CreateAsync(userId)).Value;
            Assert.NotNull(addUserContract);
            Assert.AreEqual(userContract.Data.Email, addUserContract.Data.Email);
            Assert.AreEqual(userContract.Data.FirstName, addUserContract.Data.FirstName);

            // list group user
            var listgroupResponse = await groupContract.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(listgroupResponse.Count, 1);

            // remove user from group
            await groupContract.DeleteAsync(userId);

            // make sure user is removed
            var checkResult = await groupContract.CheckEntityExistsAsync(userId);
            Assert.NotNull(checkResult);
        }
    }
}
