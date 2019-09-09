// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using ApiManagementManagement.Tests.Helpers;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class GroupUserTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                var userId = TestUtilities.GenerateName("sdkUserId");
                var newGroupId = TestUtilities.GenerateName("sdkGroupId");

                try
                {
                    // create a new group
                    var newGroupDisplayName = TestUtilities.GenerateName("sdkGroup");
                    var parameters = new GroupCreateParameters()
                    {
                        DisplayName = newGroupDisplayName,
                        Description = "Group created from Sdk client"
                    };

                    var groupContract = await testBase.client.Group.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId,
                        parameters);
                    Assert.NotNull(groupContract);
                    Assert.Equal(newGroupDisplayName, groupContract.DisplayName);
                    Assert.False(groupContract.BuiltIn);
                    Assert.NotNull(groupContract.Description);
                    Assert.Equal(GroupType.Custom, groupContract.GroupContractType);

                    // list all group users
                    var listResponse = testBase.client.GroupUser.List(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId,
                        null);
                    Assert.NotNull(listResponse);
                    Assert.Empty(listResponse);

                    // create a new user and add to the group
                    var createParameters = new UserCreateParameters()
                    {
                        FirstName = TestUtilities.GenerateName("sdkFirst"),
                        LastName = TestUtilities.GenerateName("sdkLast"),
                        Email = TestUtilities.GenerateName("sdkFirst.Last") + "@contoso.com",
                        State = UserState.Active,
                        Note = "dummy note"
                    };

                    var userContract = testBase.client.User.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        userId,
                        createParameters);
                    Assert.NotNull(userContract);

                    // add user to group
                    var addUserContract = testBase.client.GroupUser.Create(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId,
                        userId);
                    Assert.NotNull(addUserContract);
                    Assert.Equal(userContract.Email, addUserContract.Email);
                    Assert.Equal(userContract.FirstName, addUserContract.FirstName);

                    // list group user
                    var listgroupResponse = testBase.client.GroupUser.List(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId);
                    Assert.NotNull(listgroupResponse);
                    Assert.Single(listgroupResponse);
                    Assert.Equal(addUserContract.Email, listgroupResponse.GetEnumerator().ToIEnumerable().First().Email);

                    // check entity exists 
                    var entityStatus = await testBase.client.GroupUser.CheckEntityExistsAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId,
                        userId);
                    Assert.True(entityStatus);

                    // remove user from group
                    testBase.client.GroupUser.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId,
                        userId);

                    // make sure user is removed
                    entityStatus = await testBase.client.GroupUser.CheckEntityExistsAsync(
                            testBase.rgName,
                            testBase.serviceName,
                            newGroupId,
                            userId);
                    Assert.False(entityStatus);
                }
                finally
                {
                    // delete the user
                    testBase.client.User.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        userId,
                        "*",
                        deleteSubscriptions: true);

                    // delete the group
                    testBase.client.Group.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId,
                        "*");
                }
            }
        }
    }
}
