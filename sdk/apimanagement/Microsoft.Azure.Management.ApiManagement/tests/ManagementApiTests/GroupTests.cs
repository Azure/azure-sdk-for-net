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
    public class GroupTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list all groups
                var groupsList = testBase.client.Group.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotEmpty(groupsList);
                Assert.Equal(3, groupsList.GetEnumerator().ToIEnumerable().Count());
                Assert.Null(groupsList.NextPageLink);

                // list by paging using ODATA query
                groupsList = testBase.client.Group.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    new Microsoft.Rest.Azure.OData.ODataQuery<GroupContract>()
                    {
                        Top = 1
                    });

                Assert.NotNull(groupsList);
                Assert.Single(groupsList);
                Assert.NotNull(groupsList.NextPageLink);

                // create a new group
                var newGroupId = TestUtilities.GenerateName("sdkGroupId");
                try
                {
                    var newGroupDisplayName = TestUtilities.GenerateName("sdkGroup");
                    var parameters = new GroupCreateParameters()
                    {
                        DisplayName = newGroupDisplayName,
                        Description = "Group created from Sdk client"
                    };

                    var groupContract = testBase.client.Group.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId,
                        parameters);
                    Assert.NotNull(groupContract);
                    Assert.Equal(newGroupDisplayName, groupContract.DisplayName);
                    Assert.False(groupContract.BuiltIn);
                    Assert.NotNull(groupContract.Description);
                    Assert.Equal(GroupType.Custom, groupContract.GroupContractType);

                    // get the group tag
                    var groupTag = await testBase.client.Group.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId);
                    Assert.NotNull(groupTag);
                    Assert.NotNull(groupTag.ETag);

                    // update the group
                    var updateParameters = new GroupUpdateParameters()
                    {
                        Description = "Updating the description of the Sdk"
                    };

                    testBase.client.Group.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId,
                        updateParameters,
                        groupTag.ETag);

                    // get the updatedGroup
                    var updatedResponse = await testBase.client.Group.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId);
                    Assert.NotNull(updatedResponse);
                    Assert.Equal(newGroupDisplayName, updatedResponse.DisplayName);
                    Assert.False(updatedResponse.BuiltIn);
                    Assert.NotNull(updatedResponse.Description);
                    Assert.Equal(updateParameters.Description, updatedResponse.Description);
                    Assert.Equal(GroupType.Custom, updatedResponse.GroupContractType);

                    groupTag = await testBase.client.Group.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId);
                    Assert.NotNull(groupTag);
                    Assert.NotNull(groupTag.ETag);

                    // delete the group
                    testBase.client.Group.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId,
                        groupTag.ETag);

                    Assert.Throws<ErrorResponseException>(() =>
                    {
                        testBase.client.Group.Get(
                            testBase.rgName,
                            testBase.serviceName,
                            newGroupId);
                    });
                }
                finally
                {
                    testBase.client.Group.Delete(testBase.rgName, testBase.serviceName, newGroupId, "*");
                }
            }
        }
    }
}
