// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class GroupTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list all groups
                var groupsList = testBase.client.Group.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);
                
                Assert.True(groupsList.IsAny());
                Assert.Equal(3, groupsList.Count());
                Assert.NotNull(groupsList.NextPageLink);

                // list by paging using ODATA query
                groupsList = testBase.client.Group.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    new Microsoft.Rest.Azure.OData.ODataQuery<GroupContract>()
                    {
                        Top = 1
                    });

                Assert.NotNull(groupsList);
                Assert.Equal(1, groupsList.Count());
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

                    var createResponse = testBase.client.Group.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId,
                        parameters);
                    Assert.NotNull(createResponse);
                    Assert.Equal(newGroupDisplayName, createResponse.DisplayName);
                    Assert.Equal(false, createResponse.BuiltIn);
                    Assert.NotNull(createResponse.Description);
                    Assert.Equal(GroupType.Custom, createResponse.GroupContractType);

                    // get the group
                    var getResponse = await testBase.client.Group.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId);
                    Assert.NotNull(getResponse);
                    Assert.Equal(newGroupDisplayName, getResponse.Body.DisplayName);
                    Assert.Equal(false, getResponse.Body.BuiltIn);
                    Assert.NotNull(getResponse.Body.Description);
                    Assert.Equal(GroupType.Custom, getResponse.Body.GroupContractType);
                    Assert.NotNull(getResponse.Headers.ETag);

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
                        getResponse.Headers.ETag);

                    // get the updatedGroup
                    var updatedResponse = await testBase.client.Group.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId);
                    Assert.NotNull(updatedResponse);
                    Assert.Equal(newGroupDisplayName, updatedResponse.Body.DisplayName);
                    Assert.Equal(false, updatedResponse.Body.BuiltIn);
                    Assert.NotNull(updatedResponse.Body.Description);
                    Assert.Equal(updateParameters.Description, updatedResponse.Body.Description);
                    Assert.Equal(GroupType.Custom, updatedResponse.Body.GroupContractType);
                    Assert.NotNull(updatedResponse.Headers.ETag);
                    Assert.NotEqual(getResponse.Headers.ETag, updatedResponse.Headers.ETag);

                    // delete the group
                    testBase.client.Group.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newGroupId,
                        updatedResponse.Headers.ETag);

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
