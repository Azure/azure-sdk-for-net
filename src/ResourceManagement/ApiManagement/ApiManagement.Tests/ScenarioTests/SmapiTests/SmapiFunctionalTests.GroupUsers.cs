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
    using System.Linq;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void GroupUsersListAddRemove()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "GroupUsersListAddRemove");

            try
            {
                // create new group
                string gid = TestUtilities.GenerateName("groupId");

                try
                {
                    var createGroupParams = new GroupCreateParameters
                    {
                        Name = TestUtilities.GenerateName("groupName"),
                        Type = GroupTypeContract.Custom,
                    };

                    ApiManagementClient.Groups.Create(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        gid,
                        createGroupParams);

                    // get the group
                    var getGroupResponse = ApiManagementClient.Groups.Get(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        gid);

                    var group = getGroupResponse.Value;

                    // list all group users
                    var listGroupUsersResponse = ApiManagementClient.GroupUsers.List(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        group.Id,
                        null);

                    Assert.NotNull(listGroupUsersResponse);
                    Assert.NotNull(listGroupUsersResponse.Result);
                    Assert.NotNull(listGroupUsersResponse.Result.Values);

                    // there should be no users in the group
                    Assert.Equal(0, listGroupUsersResponse.Result.TotalCount);
                    Assert.Equal(0, listGroupUsersResponse.Result.Values.Count);

                    // create new user and add it to the group
                    string userId = TestUtilities.GenerateName("userId");
                    try
                    {
                        var creteUserParameters = new UserCreateParameters
                        {
                            FirstName = TestUtilities.GenerateName("Ivan"),
                            LastName = TestUtilities.GenerateName("Ivanov"),
                            Email = TestUtilities.GenerateName("ivan.ivanov") + "@contoso.com",
                            Password = TestUtilities.GenerateName("pwd"),
                            State = UserStateContract.Active,
                            Note = TestUtilities.GenerateName("note")
                        };

                        ApiManagementClient.Users.Create(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            userId,
                            creteUserParameters);

                        // add the user to the group
                        var addResponse = ApiManagementClient.GroupUsers.Add(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            group.Id,
                            userId);

                        Assert.NotNull(addResponse);

                        // list group users
                        listGroupUsersResponse = ApiManagementClient.GroupUsers.List(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            group.Id,
                            null);

                        Assert.NotNull(listGroupUsersResponse);
                        Assert.NotNull(listGroupUsersResponse.Result);
                        Assert.NotNull(listGroupUsersResponse.Result.Values);

                        // there should be one user
                        Assert.Equal(1, listGroupUsersResponse.Result.TotalCount);
                        Assert.Equal(1, listGroupUsersResponse.Result.Values.Count);

                        var user = listGroupUsersResponse.Result.Values.Single();
                        Assert.Equal(userId, user.Id);
                        Assert.Equal(creteUserParameters.FirstName, user.FirstName);
                        Assert.Equal(creteUserParameters.LastName, user.LastName);
                        Assert.Equal(creteUserParameters.Email, user.Email);
                        Assert.Equal(creteUserParameters.Note, user.Note);
                        Assert.Equal(creteUserParameters.State, user.State);

                        // remove the user from the group
                        var removeReponse = ApiManagementClient.GroupUsers.Remove(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            group.Id,
                            userId);

                        Assert.NotNull(removeReponse);

                        // list to make sure it was removed
                        listGroupUsersResponse = ApiManagementClient.GroupUsers.List(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            group.Id,
                            null);

                        Assert.NotNull(listGroupUsersResponse);
                        Assert.NotNull(listGroupUsersResponse.Result);
                        Assert.NotNull(listGroupUsersResponse.Result.Values);

                        // there should be no users
                        Assert.Equal(0, listGroupUsersResponse.Result.TotalCount);
                        Assert.Equal(0, listGroupUsersResponse.Result.Values.Count);
                    }
                    finally
                    {
                        // delete the user
                        ApiManagementClient.Users.Delete(ResourceGroupName, ApiManagementServiceName, userId, "*", true);
                    }
                }
                finally
                {
                    // delete the group
                    ApiManagementClient.Groups.Delete(ResourceGroupName, ApiManagementServiceName, gid, "*");
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}