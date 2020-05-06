// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Microsoft.Rest.Azure.OData;
using Microsoft.Graph.RBAC.Tests.Infrastructure;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    public class BasicTests : GraphTestBase
    {
        // Indicates items number to create for pagenated test cases
        private const int PagenatedItemsCount = 110;

        [Fact]
        public void UserTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetGraphClient(context);

                var users = client.Users.List();
                Assert.NotNull(users);
                Assert.NotEmpty(users);

                var user = client.Users.Get(users.ElementAt(1).ObjectId);

                Assert.NotNull(user);
                Assert.NotNull(user.ObjectId);
                Assert.NotNull(user.DisplayName);
                Assert.NotNull(user.UserPrincipalName);


                var groupMembers = client.Users.GetMemberGroups(user.ObjectId, new UserGetMemberGroupsParameters()
                {
                    SecurityEnabledOnly = false
                });

                Assert.NotNull(groupMembers);
            }
        }

        [Fact]
        public void FilteredListUsersTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetGraphClient(context);
                
                var usersNoFilter = client.Users.List(null);
                Assert.NotNull(usersNoFilter);
                Assert.NotEmpty(usersNoFilter);

                var usersByName = client.Users.List(new ODataQuery<User>(f => f.DisplayName.StartsWith(usersNoFilter.ElementAt(1).DisplayName)));
                Assert.NotNull(usersByName);
                Assert.NotEmpty(usersByName);
                Assert.Single(usersByName);

                Assert.Equal(usersNoFilter.ElementAt(1).ObjectId, usersByName.ElementAt(0).ObjectId);
            }
        }

        [Fact]
        [LiveTest]
        public void GetUserUsingSignInNameTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                //To run this test, you will need to prepare a tenant which contains a MSA based guest user, such as a live id.
                var client = GetGraphClient(context);

                // Add this user through management portal before recording mocks
                // string testLiveId  = "auxtm596@live.com";

                // UPN for this user will be a wierd ext string e.g. auxtm596_live.com#EXT#@rbacCliTest.onmicrosoft.com

                string upn = "auxtm596_live.com#EXT#@" + GetTenantAndDomain().Domain;
                var usersByLiveId = client.Users.List(new ODataQuery<User>(f=>f.UserPrincipalName == upn));
                Assert.NotNull(usersByLiveId);
                Assert.Single(usersByLiveId);
                
                string testOrgId = "test2@" + GetTenantAndDomain().Domain;
                var usersByOrgId = client.Users.List(new ODataQuery<User>(f => f.UserPrincipalName == testOrgId));
                Assert.NotNull(usersByOrgId);
                Assert.Single(usersByOrgId);
            }
        }

        [Fact]
        public void ListUsersTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetGraphClient(context);

                var users = client.Users.List();
                Assert.NotNull(users);
                Assert.NotEmpty(users);

                foreach (var user in users)
                {
                    Assert.NotNull(user.ObjectId);
                    Assert.NotNull(user.UserPrincipalName);
                }
            }
        }

        [Fact(Skip = "TODO: Fix test")]
        public void ListPagedUsersTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetGraphClient(context);
                List<User> createdUsers = new List<User>();

                for(int i=0; i<PagenatedItemsCount; i++)
                {
                    createdUsers.Add(CreateUser(context));
                }
                try
                {
                    var firstPage = client.Users.List();
                    Assert.NotNull(firstPage);
                    Assert.NotEmpty(firstPage);
                    Assert.NotNull(firstPage.NextPageLink);

                    var nextPage = client.Users.ListNext(firstPage.NextPageLink);

                    Assert.NotNull(nextPage);
                    Assert.NotEmpty(nextPage);

                    foreach (var user in nextPage)
                    {
                        Assert.NotNull(user.ObjectId);
                        Assert.NotNull(user.UserPrincipalName);
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
        [LiveTest]
        public void GroupTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetGraphClient(context);

                var groups = client.Groups.List();
                var group = client.Groups.Get(groups.ElementAt(1).ObjectId);
                Assert.NotNull(group);
                Assert.NotNull(group.ObjectId);
                Assert.NotNull(group.DisplayName);

                var groupsMembers = client.Groups.GetMemberGroups(group.ObjectId, new GroupGetMemberGroupsParameters()
                {
                    SecurityEnabledOnly = false
                });

                Assert.NotNull(groupsMembers);
            }
        }

        [Fact]
        public void FilteredListGroupsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetGraphClient(context);

                var groupsNoFilter = client.Groups.List();
                Assert.NotNull(groupsNoFilter);
                Assert.NotEmpty(groupsNoFilter);

                var groupsByName = client.Groups.List(new ODataQuery<ADGroup>(f => f.DisplayName.StartsWith(groupsNoFilter.ElementAt(1).DisplayName)));
                Assert.NotNull(groupsByName);
                Assert.Single(groupsByName);
                
                Assert.Equal(
                    groupsNoFilter.ElementAt(1).ObjectId,
                    groupsByName.ElementAt(0).ObjectId);
            }
        }

        [Fact]
        public void ListGroupsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetGraphClient(context);

                var groups = client.Groups.List();
                Assert.NotNull(groups);
                Assert.NotEmpty(groups);

                foreach (var group in groups)
                {
                    Assert.NotNull(group.ObjectId);
                    Assert.NotNull(group.SecurityEnabled);
                }
            }
        }

        [Fact(Skip = "TODO: Fix test")]
        public void ListPagedGroupsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
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

                    var firstPage = client.Groups.List();
                    Assert.NotNull(firstPage);
                    Assert.NotNull(firstPage.NextPageLink);

                    var nextPage = client.Groups.ListNext(firstPage.NextPageLink);

                    Assert.NotNull(nextPage);
                    Assert.NotEmpty(nextPage);

                    foreach (var group in nextPage)
                    {
                        Assert.NotNull(group.ObjectId);
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
        
        [Fact(Skip = "TODO: Fix test")]
        public void GroupMembersTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetGraphClient(context);

                var groups = client.Groups.List();
                Assert.NotNull(groups);

                // Mock recorded for group members of "EUROPE-Winweb-WinFTE-8" which has more than 100 users
                var firstPage = client.Groups.GetGroupMembers(groups.ElementAt(0).ObjectId);

                Assert.NotEmpty(firstPage);

                foreach (var aadItem in firstPage)
                {
                    Assert.NotNull(aadItem.ObjectId);
                }

                // if there are several pages of users in the group 
                if (firstPage.NextPageLink != null)
                {
                    var nextPage = client.Groups.GetGroupMembersNext(firstPage.NextPageLink);

                    Assert.NotNull(nextPage);
                    Assert.NotEmpty(nextPage);

                    foreach (var aadItem in nextPage)
                    {
                        Assert.NotNull(aadItem.ObjectId);
                    }
                }
            }
        }

        [Fact]
        public void QueryServicePrincipalTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetGraphClient(context);

                //test general 'list'
                var servicePrincipals = client.ServicePrincipals.List(null);
                Assert.NotNull(servicePrincipals);

                string testServicePrincipalName = servicePrincipals.ElementAt(0).ServicePrincipalNames[0];
                string testObjectId = servicePrincipals.ElementAt(0).ObjectId;
                string testDisplayName = servicePrincipals.ElementAt(0).DisplayName;

                //test query by 'service principal name'
                var listResult = client.ServicePrincipals.List(new ODataQuery<ServicePrincipal>(f=> f.ServicePrincipalNames.Contains(testServicePrincipalName)));
                ServicePrincipal servicePrincipal = listResult.First();

                Assert.Single(listResult);
                Assert.NotNull(servicePrincipal);
                Assert.True(servicePrincipal.ObjectId == testObjectId);
                Assert.Equal(testDisplayName, servicePrincipal.DisplayName);
                Assert.True(servicePrincipal.ServicePrincipalNames.Contains(testServicePrincipalName));

                //test query by 'object id'
                var getResult = client.ServicePrincipals.Get(testObjectId);
                servicePrincipal = getResult;

                Assert.NotNull(getResult);
                Assert.NotNull(getResult);
                Assert.True(servicePrincipal.ObjectId == testObjectId);
                Assert.Equal(testDisplayName, servicePrincipal.DisplayName);
                Assert.True(servicePrincipal.ServicePrincipalNames.Contains(testServicePrincipalName));

                //test query by 'displayName'
                listResult = client.ServicePrincipals.List(new ODataQuery<ServicePrincipal>(f => f.DisplayName == servicePrincipal.DisplayName));
                servicePrincipal = listResult.First();

                Assert.NotNull(listResult);
                Assert.True(servicePrincipal.ObjectId == testObjectId);
                Assert.Equal(testDisplayName, servicePrincipal.DisplayName);
                Assert.True(servicePrincipal.ServicePrincipalNames.Contains(testServicePrincipalName));
            }
        }

        [Fact]
        public void ObjectsByObjectIdsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetGraphClient(context);
                
                var groups = client.Groups.List();
                Assert.NotNull(groups);

                var users = client.Users.List();
                Assert.NotNull(users);

                var servicePrincipals = client.ServicePrincipals.List();
                Assert.NotNull(servicePrincipals);

                var objectByObject = client.Objects.GetObjectsByObjectIds(
                    new GetObjectsParameters
                    { 
                        ObjectIds = new List<string>
                        {   
                            users.ElementAt(0).ObjectId,
                            users.ElementAt(1).ObjectId
                        },
                        Types = new List<string>
                        {
                            "User"
                        }
                    });

                Assert.NotNull(objectByObject);
                Assert.Equal(2, objectByObject.Count());

                objectByObject = client.Objects.GetObjectsByObjectIds(
                    new GetObjectsParameters
                    {
                        ObjectIds = new List<string>
                        {
                            groups.ElementAt(0).ObjectId,
                            groups.ElementAt(1).ObjectId
                        },
                        Types = new List<string>
                        {
                            "Group"
                        }
                    });

                Assert.NotNull(objectByObject);
                Assert.Equal(2, objectByObject.Count());

                objectByObject = client.Objects.GetObjectsByObjectIds(
                    new GetObjectsParameters
                    {
                        ObjectIds = new List<string>
                        {
                            servicePrincipals.ElementAt(0).ObjectId
                        },
                        Types = new List<string>
                        {
                            "ServicePrincipal"
                        }
                    });

                Assert.NotNull(objectByObject);
                Assert.Single(objectByObject);
            }
        }
    }
}

