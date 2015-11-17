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

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    public class BasicTests : GraphTestBase
    {
        // Indicates items number to create for pagenated test cases
        private const int PagenatedItemsCount = 110;

        [Fact]
        public void UserTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetGraphClient(context);

                var users = client.User.List();
                Assert.NotNull(users);
                Assert.NotEmpty(users);

                var user = client.User.Get(users.ElementAt(1).UserPrincipalName);

                Assert.NotNull(user);
                Assert.NotNull(user.ObjectId);
                Assert.NotNull(user.DisplayName);
                Assert.NotNull(user.ObjectType);
                Assert.NotNull(user.UserPrincipalName);


                var groupMembers = client.User.GetMemberGroups(user.ObjectId, new UserGetMemberGroupsParameters()
                {
                    SecurityEnabledOnly = false
                });

                Assert.NotNull(groupMembers);
                Assert.NotEmpty(groupMembers);
            }
        }

        [Fact(Skip = "TODO: Fix test")]
        public void FilteredListUsersTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetGraphClient(context);
                
                var usersNoFilter = client.User.List(null);
                Assert.NotNull(usersNoFilter);
                Assert.NotEmpty(usersNoFilter);

                var usersByName = client.User.List(f => f.DisplayName.StartsWith(usersNoFilter.ElementAt(1).DisplayName));
                Assert.NotNull(usersByName);
                Assert.NotEmpty(usersByName);
                Assert.Equal(1, usersByName.Count());

                Assert.Equal(usersNoFilter.ElementAt(1).ObjectId, usersByName.ElementAt(0).ObjectId);
            }
        }

        [Fact]
        public void GetUserUsingSignInNameTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                //To run this test, you will need to prepare a tenant which contains a MSA based guest user, such as a live id.
                var client = GetGraphClient(context);

                // Add this user through management portal before recording mocks
                string testLiveId  = "auxtm596@live.com";
                var usersByLiveId = client.User.List(f=>f.SignInName == testLiveId);
                Assert.NotNull(usersByLiveId);
                Assert.Equal(1, usersByLiveId.Count());

                string testOrgId = "test2@" + GetTenantAndDomain().Domain;
                var usersByOrgId = client.User.List(f => f.SignInName == testOrgId);
                Assert.NotNull(usersByOrgId);
                Assert.Equal(1, usersByOrgId.Count());
            }
        }

        [Fact]
        public void ListUsersTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetGraphClient(context);

                var users = client.User.List();
                Assert.NotNull(users);
                Assert.NotEmpty(users);

                foreach (var user in users)
                {
                    Assert.NotNull(user.ObjectId);
                    Assert.NotNull(user.UserPrincipalName);
                    Assert.NotNull(user.ObjectType);
                }
            }
        }

        [Fact(Skip = "TODO: Fix test")]
        public void ListPagedUsersTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetGraphClient(context);
                List<User> createdUsers = new List<User>();

                for(int i=0; i<PagenatedItemsCount; i++)
                {
                    createdUsers.Add(CreateUser(context));
                }
                try
                {
                    var firstPage = client.User.List();
                    Assert.NotNull(firstPage);
                    Assert.NotEmpty(firstPage);
                    Assert.NotNull(firstPage.NextPageLink);

                    var nextPage = client.User.ListNext(firstPage.NextPageLink);

                    Assert.NotNull(nextPage);
                    Assert.NotEmpty(nextPage);

                    foreach (var user in nextPage)
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
                        DeleteUser(context, user.UserPrincipalName);
                    }
                }
            }
        }

        [Fact]
        public void GroupTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetGraphClient(context);

                var groups = client.Group.List();
                var group = client.Group.Get(groups.ElementAt(2).ObjectId);
                Assert.NotNull(group);
                Assert.NotNull(group.ObjectId);
                Assert.NotNull(group.DisplayName);
                Assert.NotNull(group.ObjectType);

                var groupsMembers = client.Group.GetMemberGroups(group.ObjectId, new GroupGetMemberGroupsParameters()
                {
                    SecurityEnabledOnly = false
                });

                Assert.NotNull(groupsMembers);
            }
        }

        [Fact (Skip = "TODO: Fix test")]
        public void FilteredListGroupsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetGraphClient(context);

                var groupsNoFilter = client.Group.List();
                Assert.NotNull(groupsNoFilter);
                Assert.NotEmpty(groupsNoFilter);

                var groupsByName = client.Group.List(f => f.DisplayName.StartsWith(groupsNoFilter.ElementAt(1).DisplayName));
                Assert.NotNull(groupsByName);
                Assert.Equal(1, groupsByName.Count());
                
                Assert.Equal(
                    groupsNoFilter.ElementAt(1).ObjectId,
                    groupsByName.ElementAt(0).ObjectId);
            }
        }

        [Fact]
        public void ListGroupsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetGraphClient(context);

                var groups = client.Group.List();
                Assert.NotNull(groups);
                Assert.NotEmpty(groups);

                foreach (var group in groups)
                {
                    Assert.NotNull(group.ObjectId);
                    Assert.NotNull(group.ObjectType);
                    Assert.NotNull(group.SecurityEnabled);
                }
            }
        }

        [Fact(Skip = "TODO: Fix test")]
        public void ListPagedGroupsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var graphTestBase = new GraphTestBase();
                var client = GetGraphClient(context);
                List<ADGroup> createdGroups = new List<ADGroup>();

                for(int i=0; i<PagenatedItemsCount; i++)
                {
                    createdGroups.Add(graphTestBase.CreateGroup(context));
                }
                try
                {

                    var firstPage = client.Group.List();
                    Assert.NotNull(firstPage);
                    Assert.NotNull(firstPage.NextPageLink);

                    var nextPage = client.Group.ListNext(firstPage.NextPageLink);

                    Assert.NotNull(nextPage);
                    Assert.NotEmpty(nextPage);

                    foreach (var group in nextPage)
                    {
                        Assert.NotNull(group.ObjectId);
                        Assert.NotNull(group.ObjectType);
                    }
                }
                finally
                {
                    foreach (var group in createdGroups)
                    {
                        graphTestBase.DeleteGroup(context, group.ObjectId);
                    }
                }
            }
        }
        
        [Fact]
        public void GroupMemebersTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetGraphClient(context);

                var groups = client.Group.List();
                Assert.NotNull(groups);

                // Mock recorded for group members of "EUROPE-Winweb-WinFTE-8" which has more than 100 users
                var firstPage = client.Group.GetGroupMembers(groups.ElementAt(0).ObjectId);

                Assert.NotEmpty(firstPage);

                foreach (var aadItem in firstPage)
                {
                    Assert.NotNull(aadItem.ObjectId);
                    Assert.NotNull(aadItem.ObjectType);
                }

                // if there are several pages of users in the group 
                if (firstPage.NextPageLink != null)
                {
                    var nextPage = client.Group.GetGroupMembersNext(firstPage.NextPageLink);

                    Assert.NotNull(nextPage);
                    Assert.NotEqual(0, nextPage.Count());

                    foreach (var aadItem in nextPage)
                    {
                        Assert.NotNull(aadItem.ObjectId);
                        Assert.NotNull(aadItem.ObjectType);
                    }
                }
            }
        }

        [Fact(Skip = "TODO: Fix test")]
        public void QueryServicePrincipalTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetGraphClient(context);

                //test general 'list'
                var servicePrincipals = client.ServicePrincipal.List(null);
                Assert.NotNull(servicePrincipals);

                string testServicePrincipalName = servicePrincipals.ElementAt(0).ServicePrincipalNames[0];
                string testObjcetId = servicePrincipals.ElementAt(0).ObjectId;

                //test query by 'service principal name'
                var listResult = client.ServicePrincipal.List(f=> f.DisplayName == testServicePrincipalName);
                ServicePrincipal servicePrincipal = listResult.First();

                Assert.Equal(1, listResult.Count());
                Assert.NotNull(servicePrincipal);
                Assert.True(servicePrincipal.ObjectId == testObjcetId);
                Assert.NotNull(servicePrincipal.DisplayName);
                Assert.NotNull(servicePrincipal.ObjectType);
                Assert.True(servicePrincipal.ServicePrincipalNames.Contains(testServicePrincipalName));

                //test query by 'object id'
                var getResult = client.ServicePrincipal.Get(testObjcetId);
                servicePrincipal = getResult;

                Assert.NotNull(getResult);
                Assert.NotNull(getResult);
                Assert.True(servicePrincipal.ObjectId == testObjcetId);
                Assert.NotNull(servicePrincipal.DisplayName);
                Assert.NotNull(servicePrincipal.ObjectType);
                Assert.True(servicePrincipal.ServicePrincipalNames.Contains(testServicePrincipalName));

                //test query by 'displayName'
                listResult = client.ServicePrincipal.List(f=> f.DisplayName == servicePrincipal.DisplayName);
                servicePrincipal = listResult.First();

                Assert.NotNull(listResult);
                Assert.True(servicePrincipal.ObjectId == testObjcetId);
                Assert.NotNull(servicePrincipal.DisplayName);
                Assert.NotNull(servicePrincipal.ObjectType);
                Assert.True(servicePrincipal.ServicePrincipalNames.Contains(testServicePrincipalName));
            }
        }

        [Fact(Skip = "TODO: Fix test")]
        public void ObjectsByObjectIdsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetGraphClient(context);
                
                var groups = client.Group.List();
                Assert.NotNull(groups);

                var users = client.User.List();
                Assert.NotNull(users);

                var objectByObject = client.Objects.GetObjectsByObjectIds(
                    new GetObjectsParameters
                    { 
                        ObjectIds = new List<string>
                        {
                            groups.ElementAt(0).ObjectId,
                            users.ElementAt(1).ObjectId,
                            groups.ElementAt(2).ObjectId
                        },
                        Types = new List<string>
                        {
                            "StubDirectoryObject"
                        }
                    });

                Assert.NotNull(objectByObject);
                Assert.Equal(3, objectByObject.Count());
            }
        }
    }
}
