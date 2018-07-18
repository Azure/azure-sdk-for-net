//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.SmapiTests
{
    using System;
    using System.Net;
    using Hyak.Common;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void GroupsCreateListUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "GroupsCreateListUpdateDelete");

            try
            {
                // list all groups: there should be at least 3 groups: Administrators, Developers, Guests
                var listResponse = ApiManagementClient.Groups.List(ResourceGroupName, ApiManagementServiceName, null);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result);
                Assert.True(listResponse.Result.TotalCount >= 3);
                Assert.True(listResponse.Result.Values.Count >= 3);

                // list paged
                listResponse = ApiManagementClient.Groups.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new QueryParameters {Top = 1});

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result);
                Assert.True(listResponse.Result.TotalCount >= 3);
                Assert.Equal(1, listResponse.Result.Values.Count);

                // create new group with default parameters
                string newGroupId = TestUtilities.GenerateName("newGroupId");
                string newGroupName = TestUtilities.GenerateName("newGroupName");
                var groupCreateParameters = new GroupCreateParameters(newGroupName);

                var createResponse = ApiManagementClient.Groups.Create(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newGroupId,
                    groupCreateParameters);

                Assert.NotNull(createResponse);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // get to check it was created
                var getResponse = ApiManagementClient.Groups.Get(ResourceGroupName, ApiManagementServiceName, newGroupId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);

                Assert.Equal(newGroupId, getResponse.Value.Id);
                Assert.Equal(newGroupName, getResponse.Value.Name);
                Assert.Null(getResponse.Value.Description);
                Assert.Null(getResponse.Value.ExternalId);
                Assert.Equal(GroupTypeContract.Custom, getResponse.Value.Type);
                Assert.Equal(false, getResponse.Value.System);

                // delete the group
                ApiManagementClient.Groups.Delete(ResourceGroupName, ApiManagementServiceName, newGroupId, getResponse.ETag);

                // create a group with other parameters
                string newGroupDescription = TestUtilities.GenerateName("newGroupDescription");
                var newGroupType = GroupTypeContract.Custom;

                groupCreateParameters = new GroupCreateParameters
                {
                    Description = newGroupDescription,
                    Name = newGroupName,
                    Type = newGroupType
                };

                createResponse = ApiManagementClient.Groups.Create(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newGroupId,
                    groupCreateParameters);

                Assert.NotNull(createResponse);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // get to check it was created
                getResponse = ApiManagementClient.Groups.Get(ResourceGroupName, ApiManagementServiceName, newGroupId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);

                Assert.Equal(newGroupId, getResponse.Value.Id);
                Assert.Equal(newGroupName, getResponse.Value.Name);
                Assert.Equal(newGroupDescription, getResponse.Value.Description);
                //Assert.Equal(newGroupExternalId, getResponse.Value.ExternalId);
                Assert.Equal(newGroupType, getResponse.Value.Type);
                Assert.Equal(false, getResponse.Value.System);

                // patch group
                string patchedDescription = TestUtilities.GenerateName("patchedDescription");
                var patchResponse = ApiManagementClient.Groups.Update(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newGroupId,
                    new GroupUpdateParameters
                    {
                        Description = patchedDescription
                    },
                    getResponse.ETag);

                Assert.NotNull(patchResponse);

                // get to check it was patched
                getResponse = ApiManagementClient.Groups.Get(ResourceGroupName, ApiManagementServiceName, newGroupId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);

                Assert.Equal(newGroupId, getResponse.Value.Id);
                Assert.Equal(newGroupName, getResponse.Value.Name);
                Assert.Equal(patchedDescription, getResponse.Value.Description);
                //Assert.Equal(newGroupExternalId, getResponse.Value.ExternalId);
                Assert.Equal(newGroupType, getResponse.Value.Type);
                Assert.Equal(false, getResponse.Value.System);

                // delete the group 
                var deleteResponse = ApiManagementClient.Groups.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newGroupId,
                    getResponse.ETag);

                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                // get the deleted group to make sure it was deleted
                try
                {
                    ApiManagementClient.Groups.Get(ResourceGroupName, ApiManagementServiceName, newGroupId);
                    throw new Exception("This code should not have been executed.");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}