//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    public class BasicTests : TestBase
    {
        // Indicates items number to create for pagenated test cases
        private const int PagenatedItemsCount = 110;

        [Fact]
        public void UserTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                var client = (new GraphTestBase()).GraphClient;

                var users = client.User.List(null, null);
                Assert.NotNull(users);
                Assert.NotNull(users.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(users.Users);

                var user = client.User.Get(users.Users.ElementAt(0).UserPrincipalName);

                Assert.NotNull(user);
                Assert.NotNull(user.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(user.User);
                Assert.NotNull(user.User.ObjectId);
                Assert.NotNull(user.User.DisplayName);
                Assert.NotNull(user.User.ObjectType);
                Assert.NotNull(user.User.UserPrincipalName);


                var groupMembers = client.User.GetMemberGroups(new UserGetMemberGroupsParameters()
                {
                    ObjectId = user.User.ObjectId,
                    SecurityEnabledOnly = false
                });

                Assert.NotNull(groupMembers);
                Assert.NotNull(groupMembers.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(groupMembers.ObjectIds);
            }
        }

        [Fact]
        public void FilteredListUsersTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = (new GraphTestBase()).GraphClient;
                
                var usersNoFilter = client.User.List(null, null);
                Assert.NotNull(usersNoFilter);
                Assert.NotNull(usersNoFilter.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(usersNoFilter.Users);
                Assert.NotEqual(0, usersNoFilter.Users.Count());

                var usersByName = client.User.List(null, usersNoFilter.Users.ElementAt(1).DisplayName);
                Assert.NotNull(usersByName);
                Assert.NotNull(usersByName.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(usersByName.Users);
                Assert.Equal(1, usersByName.Users.Count());

                Assert.Equal(
                usersNoFilter.Users.ElementAt(1).ObjectId,
                usersByName.Users.ElementAt(0).ObjectId);
            }
        }

        [Fact]
        public void GetUserUsingSignInNameTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                //To run this test, you will need to prepare a tenant which contains a MSA based guest user, such as a live id.
                context.Start();
                var graphTestBase = new GraphTestBase();
                var client = graphTestBase.GraphClient;

                // Add this user through management portal before recording mocks
                string testLiveId = "auxtm596_live.com#EXT#@rbacCliTest.onmicrosoft.com";
                var usersByLiveId = client.User.GetByUserPrincipalName(testLiveId);
                Assert.NotNull(usersByLiveId);
                Assert.NotNull(usersByLiveId.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(usersByLiveId.Users);
                Assert.Equal(1, usersByLiveId.Users.Count());

                string testOrgId = "test2@" + graphTestBase.Domain;
                var usersByOrgId = client.User.GetByUserPrincipalName(testOrgId);
                Assert.NotNull(usersByOrgId);
                Assert.NotNull(usersByOrgId.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(usersByOrgId.Users);
                Assert.Equal(1, usersByOrgId.Users.Count());
            }
        }

        [Fact]
        public void ListUsersTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = (new GraphTestBase()).GraphClient;

                var users = client.User.List(null, null);
                Assert.NotNull(users);
                Assert.NotNull(users.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(users.Users);
                Assert.NotEqual(0, users.Users.Count());

                foreach (var user in users.Users)
                {
                    Assert.NotNull(user.ObjectId);
                    Assert.NotNull(user.UserPrincipalName);
                    Assert.NotNull(user.ObjectType);
                }
            }
        }

        [Fact]
        public void ListPagedUsersTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var graphTestBase = new GraphTestBase();
                var client = graphTestBase.GraphClient;
                List<User> createdUsers = new List<User>();

                for(int i=0; i<PagenatedItemsCount; i++)
                {
                    createdUsers.Add(graphTestBase.CreateUser());
                }
                try
                {
                    var firstPage = client.User.List(null, null);
                    Assert.NotNull(firstPage);
                    Assert.NotNull(firstPage.StatusCode == HttpStatusCode.OK);
                    Assert.NotNull(firstPage.Users);
                    Assert.NotNull(firstPage.NextLink);

                    var nextPage = client.User.ListNext(firstPage.NextLink);

                    Assert.NotNull(nextPage.StatusCode == HttpStatusCode.OK);
                    Assert.NotNull(nextPage.Users);

                    Assert.NotEqual(0, nextPage.Users.Count());

                    foreach (var user in nextPage.Users)
                    {
                        Assert.NotNull(user.ObjectId);
                        Assert.NotNull(user.UserPrincipalName);
                        Assert.NotNull(user.ObjectType);
                    }
                }
                finally
                {
                    foreach(var user in createdUsers)
                    {
                        graphTestBase.DeleteUser(user.UserPrincipalName);
                    }
                }
            }
        }

        [Fact]
        public void GroupTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = (new GraphTestBase()).GraphClient;

                var groups = client.Group.List(null, null);
                var group = client.Group.Get(groups.Groups.ElementAt(2).ObjectId);
                Assert.NotNull(group);
                Assert.NotNull(group.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(group.Group);
                Assert.NotNull(group.Group.ObjectId);
                Assert.NotNull(group.Group.DisplayName);
                Assert.NotNull(group.Group.ObjectType);

                var groupsMembers = client.Group.GetMemberGroups(new GroupGetMemberGroupsParameters()
                {
                    ObjectId = group.Group.ObjectId,
                    SecurityEnabledOnly = false
                });

                Assert.NotNull(groupsMembers);
                Assert.NotNull(groupsMembers.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(groupsMembers.ObjectIds);
            }
        }

        [Fact]
        public void FilteredListGroupsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = (new GraphTestBase()).GraphClient;

                var groupsNoFilter = client.Group.List(null, null);
                Assert.NotNull(groupsNoFilter);
                Assert.NotNull(groupsNoFilter.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(groupsNoFilter.Groups);
                Assert.NotEqual(0, groupsNoFilter.Groups.Count());

                var groupsByName = client.Group.List(null, groupsNoFilter.Groups.ElementAt(1).DisplayName);
                Assert.NotNull(groupsByName);
                Assert.NotNull(groupsByName.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(groupsByName.Groups);
                Assert.Equal(1, groupsByName.Groups.Count());
                
                Assert.Equal(
                    groupsNoFilter.Groups.ElementAt(1).ObjectId,
                    groupsByName.Groups.ElementAt(0).ObjectId);
            }
        }

        [Fact]
        public void ListGroupsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = (new GraphTestBase()).GraphClient;

                var groups = client.Group.List(null, null);
                Assert.NotNull(groups);
                Assert.NotNull(groups.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(groups.Groups);
                Assert.NotEqual(0, groups.Groups.Count());

                foreach (var group in groups.Groups)
                {
                    Assert.NotNull(group.ObjectId);
                    Assert.NotNull(group.ObjectType);
                    Assert.NotNull(group.SecurityEnabled);
                }
            }
        }

        [Fact]
        public void ListPagedGroupsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var graphTestBase = new GraphTestBase();
                var client = graphTestBase.GraphClient;
                List<Group> createdGroups = new List<Group>();

                for(int i=0; i<PagenatedItemsCount; i++)
                {
                    createdGroups.Add(graphTestBase.CreateGroup());
                }
                try
                {

                    var firstPage = client.Group.List(null, null);
                    Assert.NotNull(firstPage);
                    Assert.NotNull(firstPage.StatusCode == HttpStatusCode.OK);
                    Assert.NotNull(firstPage.Groups);
                    Assert.NotNull(firstPage.NextLink);

                    var nextPage = client.Group.ListNext(firstPage.NextLink);

                    Assert.NotNull(nextPage.StatusCode == HttpStatusCode.OK);
                    Assert.NotNull(nextPage.Groups);

                    Assert.NotEqual(0, nextPage.Groups.Count());

                    foreach (var group in nextPage.Groups)
                    {
                        Assert.NotNull(group.ObjectId);
                        Assert.NotNull(group.ObjectType);
                    }
                }
                finally
                {
                    foreach (var group in createdGroups)
                    {
                        graphTestBase.DeleteGroup(group.ObjectId);
                    }
                }
            }
        }
        
        [Fact]
        public void GroupMemebersTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = (new GraphTestBase()).GraphClient;

                var groups = client.Group.List(null, null);
                Assert.NotNull(groups);
                Assert.NotNull(groups.StatusCode == HttpStatusCode.OK);

                // Mock recorded for group members of "EUROPE-Winweb-WinFTE-8" which has more than 100 users
                var firstPage = client.Group.GetGroupMembers(groups.Groups.ElementAt(0).ObjectId);

                Assert.NotNull(firstPage);
                Assert.NotNull(firstPage.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(firstPage.AADObject);

                Assert.NotEqual(0, firstPage.AADObject.Count());

                foreach (var aadItem in firstPage.AADObject)
                {
                    Assert.NotNull(aadItem.ObjectId);
                    Assert.NotNull(aadItem.ObjectType);
                }

                // if there are several pages of users in the group 
                if (firstPage.NextLink != null)
                {
                    var nextPage = client.Group.GetGroupMembersNext(firstPage.NextLink);

                    Assert.NotNull(nextPage.StatusCode == HttpStatusCode.OK);
                    Assert.NotNull(nextPage.AADObject);

                    Assert.NotEqual(0, nextPage.AADObject.Count());

                    foreach (var aadItem in nextPage.AADObject)
                    {
                        Assert.NotNull(aadItem.ObjectId);
                        Assert.NotNull(aadItem.ObjectType);
                    }
                }
            }
        }

        [Fact]
        public void QueryServicePrincipalTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = (new GraphTestBase()).GraphClient;

                //test general 'list'
                var servicePrincipals = client.ServicePrincipal.List(null);
                Assert.NotNull(servicePrincipals);
                Assert.NotNull(servicePrincipals.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(servicePrincipals.ServicePrincipals);

                string testServicePrincipalName = servicePrincipals.ServicePrincipals.ElementAt(0).ServicePrincipalNames[0];
                string testObjcetId = servicePrincipals.ServicePrincipals.ElementAt(0).ObjectId;

                //test query by 'service principal name'
                ServicePrincipalListResult listResult = client.ServicePrincipal.GetByServicePrincipalName(testServicePrincipalName);
                ServicePrincipal servicePrincipal = listResult.ServicePrincipals[0];

                Assert.True(listResult.ServicePrincipals.Count == 1);
                Assert.True(listResult.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(servicePrincipal);
                Assert.True(servicePrincipal.ObjectId == testObjcetId);
                Assert.NotNull(servicePrincipal.DisplayName);
                Assert.NotNull(servicePrincipal.ObjectType);
                Assert.True(servicePrincipal.ServicePrincipalNames.Contains(testServicePrincipalName));

                //test query by 'object id'
                ServicePrincipalGetResult getResult = client.ServicePrincipal.Get(testObjcetId);
                servicePrincipal = getResult.ServicePrincipal;

                Assert.NotNull(getResult);
                Assert.True(getResult.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(getResult.ServicePrincipal);
                Assert.True(servicePrincipal.ObjectId == testObjcetId);
                Assert.NotNull(servicePrincipal.DisplayName);
                Assert.NotNull(servicePrincipal.ObjectType);
                Assert.True(servicePrincipal.ServicePrincipalNames.Contains(testServicePrincipalName));

                //test query by 'displayName'
                listResult = client.ServicePrincipal.List(servicePrincipal.DisplayName);
                servicePrincipal = listResult.ServicePrincipals[0];

                Assert.NotNull(listResult);
                Assert.True(listResult.StatusCode == HttpStatusCode.OK);
                Assert.True(servicePrincipal.ObjectId == testObjcetId);
                Assert.NotNull(servicePrincipal.DisplayName);
                Assert.NotNull(servicePrincipal.ObjectType);
                Assert.True(servicePrincipal.ServicePrincipalNames.Contains(testServicePrincipalName));
            }
        }

        [Fact]
        public void ObjectsByObjectIdsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = (new GraphTestBase()).GraphClient;
                
                var groups = client.Group.List(null, null);
                Assert.NotNull(groups);
                Assert.NotNull(groups.StatusCode == HttpStatusCode.OK);

                var users = client.User.List(null, null);
                Assert.NotNull(users);
                Assert.NotNull(users.StatusCode == HttpStatusCode.OK);

                var objectByObject = client.Objects.GetObjectsByObjectIds(
                    new GetObjectsParameters
                    {
                        Ids = new List<string>
                        {
                            groups.Groups.ElementAt(0).ObjectId,
                            users.Users.ElementAt(1).ObjectId,
                            groups.Groups.ElementAt(2).ObjectId
                        },
                        Types = new List<string>
                        {
                            "StubDirectoryObject"
                        }
                    });

                Assert.NotNull(objectByObject);
                Assert.NotNull(objectByObject.StatusCode == HttpStatusCode.OK);
                Assert.NotNull(objectByObject.AADObject);
                Assert.Equal(3, objectByObject.AADObject.Count());
            }
        }
    }
}
