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
        public void UserGroupsListAddRemove()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "UserGroupsListAddRemove");

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

                        // list user groups
                        var listUserGroupsResponse = ApiManagementClient.UserGroups.List(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            userId,
                            null);

                        Assert.NotNull(listUserGroupsResponse);
                        Assert.NotNull(listUserGroupsResponse.Result);
                        Assert.NotNull(listUserGroupsResponse.Result.Values);

                        // there should be 'Developers' group by default
                        Assert.Equal(1, listUserGroupsResponse.Result.TotalCount);
                        Assert.Equal(1, listUserGroupsResponse.Result.Values.Count);

                        // add the user to the group
                        var addResponse = ApiManagementClient.UserGroups.AddToGroup(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            userId,
                            group.Id);

                        Assert.NotNull(addResponse);

                        // list user groups
                        listUserGroupsResponse = ApiManagementClient.UserGroups.List(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            userId,
                            null);

                        Assert.NotNull(listUserGroupsResponse);
                        Assert.NotNull(listUserGroupsResponse.Result);
                        Assert.NotNull(listUserGroupsResponse.Result.Values);

                        // there should be two groups now
                        Assert.Equal(2, listUserGroupsResponse.Result.TotalCount);
                        Assert.Equal(2, listUserGroupsResponse.Result.Values.Count);

                        var userGroup = listUserGroupsResponse.Result.Values.Single(g => g.Name == group.Name);
                        Assert.Equal(group.Id, userGroup.Id);
                        Assert.Equal(group.IdPath, userGroup.IdPath);
                        Assert.Equal(group.Name, userGroup.Name);
                        Assert.Equal(group.Description, userGroup.Description);
                        Assert.Equal(group.ExternalId, userGroup.ExternalId);
                        Assert.Equal(group.System, userGroup.System);
                        Assert.Equal(group.Type, userGroup.Type);

                        // remove the user from the group
                        var removeReponse = ApiManagementClient.UserGroups.RemoveFromGroup(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            userId,
                            group.Id);

                        Assert.NotNull(removeReponse);

                        // list to make sure it was removed
                        listUserGroupsResponse = ApiManagementClient.UserGroups.List(
                            ResourceGroupName,
                            ApiManagementServiceName,
                            userId,
                            null);

                        Assert.NotNull(listUserGroupsResponse);
                        Assert.NotNull(listUserGroupsResponse.Result);
                        Assert.NotNull(listUserGroupsResponse.Result.Values);

                        // there should be default 'Developers' group
                        Assert.Equal(1, listUserGroupsResponse.Result.TotalCount);
                        Assert.Equal(1, listUserGroupsResponse.Result.Values.Count);
                        Assert.Equal("Developers", listUserGroupsResponse.Result.Values.Single().Name);
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