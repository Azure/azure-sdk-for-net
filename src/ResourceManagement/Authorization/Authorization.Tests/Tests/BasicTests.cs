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

using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Test;
using System;
using System.Linq;
using System.Net;
using Xunit;
using System.Collections.Generic;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;
using Xunit.Abstractions;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure.OData;

namespace Authorization.Tests
{
    public class BasicTests : TestBase, IClassFixture<TestExecutionContext>
    {
        private readonly ITestOutputHelper _output;
        private TestExecutionContext testContext;
        private const int RoleAssignmentPageSize = 20;
        private const string RESOURCE_TEST_LOCATION = "westus";
        private const string WEBSITE_RP_VERSION = "2014-04-01";

        public BasicTests(TestExecutionContext context, ITestOutputHelper output)
        {
            testContext = context;
            _output = output;
        }

        [Fact]
        public void ClassicAdministratorListTests()
        {
            HttpMockServer.RecordsDirectory = "SessionRecords";
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var allClassicAdmins = client.ClassicAdministrators.List("2015-06-01");

                Assert.NotNull(allClassicAdmins);

                foreach (var classicAdmin in allClassicAdmins)
                {
                    Assert.NotNull(classicAdmin);
                    Assert.NotNull(classicAdmin.Id);
                    Assert.True(classicAdmin.Id.Contains("/providers/Microsoft.Authorization/classicAdministrators/"));
                    Assert.True(classicAdmin.Id.Contains("/subscriptions/" + client.SubscriptionId));
                    Assert.NotNull(classicAdmin.Name);
                    Assert.NotNull(classicAdmin.Type);
                    Assert.Equal("Microsoft.Authorization/classicAdministrators", classicAdmin.Type);
                    Assert.NotNull(classicAdmin.Properties);
                    Assert.NotNull(classicAdmin.Properties.EmailAddress);
                    Assert.NotNull(classicAdmin.Properties.Role);
                }
            }
        }

        [Fact]
        public void RoleAssignmentByIdTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);
                
                var principalId = testContext.Users.ElementAt(4);

                var scope = "subscriptions/" + client.SubscriptionId;
                var roleDefinition = client.RoleDefinitions.List(scope, null).ElementAt(1);
                var newRoleAssignment = new RoleAssignmentProperties()
                {
                    RoleDefinitionId = roleDefinition.Id,
                    PrincipalId = principalId.ToString()
                };

                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName");

                var assignmentId = string.Format(
                    "{0}/providers/Microsoft.Authorization/roleAssignments/{1}",
                    scope,
                    assignmentName);

                // Create
                var createResult = client.RoleAssignments.CreateById(assignmentId, newRoleAssignment);
                Assert.NotNull(createResult);
                Assert.NotNull(createResult.Id);
                Assert.NotNull(createResult.Name);
                Assert.Equal(createResult.Name, assignmentName.ToString());

                // Get
                var getResult = client.RoleAssignments.GetById(assignmentId);
                Assert.NotNull(getResult);
                Assert.Equal(createResult.Id, getResult.Id);
                Assert.Equal(createResult.Name, getResult.Name);
                
                //Delete
                var deleteResult = client.RoleAssignments.DeleteById(assignmentId);
                Assert.NotNull(deleteResult);

                var allRoleAssignments = client.RoleAssignments.List(null);
                var createdAssignment = allRoleAssignments.FirstOrDefault(
                                            a => a.Name == assignmentName.ToString());

                Assert.Null(createdAssignment);
            }
        }

        [Fact]
        public void RoleAssignmentsListGetTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName");

                var scope = "subscriptions/" + client.SubscriptionId;
                var principalId = testContext.Users.ElementAt(5);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var roleDefinition = client.RoleDefinitions.List(scope, null).Where(r => r.Properties.Type == "BuiltInRole").Last();
                var newRoleAssignment = new RoleAssignmentProperties()
                {
                    RoleDefinitionId = roleDefinition.Id,
                    PrincipalId = principalId.ToString()
                };

                var createResult = client.RoleAssignments.Create(scope, assignmentName.ToString(), newRoleAssignment);
                Assert.NotNull(createResult);
                
                var allRoleAssignments = client.RoleAssignments.List(null);

                Assert.NotNull(allRoleAssignments);

                foreach (var assignment in allRoleAssignments)
                {
                    var singleAssignment = client.RoleAssignments.Get(assignment.Properties.Scope, assignment.Name);

                    Assert.NotNull(singleAssignment);
                    Assert.NotNull(singleAssignment.Id);
                    Assert.NotNull(singleAssignment.Name);
                    Assert.NotNull(singleAssignment.Type);
                    Assert.NotNull(singleAssignment.Properties);
                    Assert.NotNull(singleAssignment.Properties.PrincipalId);
                    Assert.NotNull(singleAssignment.Properties.RoleDefinitionId);
                    Assert.NotNull(singleAssignment.Properties.Scope);
                }

                var deleteResult = client.RoleAssignments.Delete(scope, assignmentName.ToString());
                Assert.NotNull(deleteResult);
            }
        }

        [Fact]
        public void RoleAssignmentsCreateDeleteTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName");

                var scope = "subscriptions/" + client.SubscriptionId;
                var principalId = testContext.Users.ElementAt(3);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var roleDefinition = client.RoleDefinitions.List(scope).Last();
                var newRoleAssignment = new RoleAssignmentProperties()
                {
                    RoleDefinitionId = roleDefinition.Id,
                    PrincipalId = principalId.ToString()
                };

                var createResult = client.RoleAssignments.Create(scope, assignmentName.ToString(), newRoleAssignment);
                Assert.NotNull(createResult);
                
                var deleteResult = client.RoleAssignments.Delete(scope, assignmentName.ToString());
                Assert.NotNull(deleteResult);
                var deletedRoleAssignment = deleteResult;
                Assert.NotNull(deletedRoleAssignment);
                Assert.Equal(deletedRoleAssignment.Id, createResult.Id);

                var allRoleAssignments = client.RoleAssignments.List(null);
                var createdAssignment = allRoleAssignments.FirstOrDefault(
                                            a => a.Name == assignmentName.ToString());

                Assert.Null(createdAssignment);
            }
        }

        [Fact]
        public void RoleAssignmentAtScopeAndAboveTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var allRoleAssignments = client.RoleAssignments
                    .List(new ODataQuery<RoleAssignmentFilter>(f => f.AtScope()));

                Assert.NotNull(allRoleAssignments);

                foreach (var assignment in allRoleAssignments)
                {
                    Assert.NotNull(assignment);
                    Assert.NotNull(assignment.Id);
                    Assert.NotNull(assignment.Name);
                    Assert.NotNull(assignment.Type);
                    Assert.NotNull(assignment.Properties);
                    Assert.NotNull(assignment.Properties.PrincipalId);
                    Assert.NotNull(assignment.Properties.RoleDefinitionId);
                    Assert.NotNull(assignment.Properties.Scope);
                }
            }
        }

        [Fact]
        public void RoleAssignmentListByFilterTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                // Read/write the PrincipalId from Testcontext to enable Playback mode test execution
                var principalId = GetValueFromTestContext(() => testContext.Users.ElementAt(1), Guid.Parse, "PrincipalId").ToString(); 

                var scope = "subscriptions/" + client.SubscriptionId;
                var roleDefinition = client.RoleDefinitions.List(scope).First();

                for(int i=0; i<testContext.Users.Count; i++)
                {
                    var pId = testContext.Users.ElementAt(i);
                    var newRoleAssignment = new RoleAssignmentProperties()
                    {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = pId.ToString()
                    };
                    var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName_" + i);
                    var createResult = client.RoleAssignments.Create(scope, assignmentName.ToString(), newRoleAssignment);
                }

                var allRoleAssignments = client.RoleAssignments
                    .List(new ODataQuery<RoleAssignmentFilter>(f => f.PrincipalId == principalId));

                Assert.NotNull(allRoleAssignments);

                foreach (var assignment in allRoleAssignments)
                {
                    Assert.NotNull(assignment);
                    Assert.NotNull(assignment.Id);
                    Assert.NotNull(assignment.Name);
                    Assert.NotNull(assignment.Type);
                    Assert.NotNull(assignment.Properties);
                    Assert.NotNull(assignment.Properties.PrincipalId);
                    Assert.NotNull(assignment.Properties.RoleDefinitionId);
                    Assert.NotNull(assignment.Properties.Scope);

                    Assert.Equal(principalId.ToString(), assignment.Properties.PrincipalId);
               }
            }
        }

        [Fact(Skip = "PAS Service Issue - Paging not enabled")]
        public void RoleAssignmentPagingTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.SubscriptionId;
                var allBuiltInRoles = client.RoleDefinitions.List(scope).Where(r => r.Properties.Type.Equals("BuiltInRole", StringComparison.OrdinalIgnoreCase));
                var allBuiltInRolesList = allBuiltInRoles as IList<RoleDefinition> ?? allBuiltInRoles.ToList();
                int roleCount = allBuiltInRolesList.Count();
                int userCount = testContext.Users.Count();
                
                List<RoleAssignment> createdAssignments = new List<RoleAssignment>();

                try
                {
                    for (int i = 0; i < RoleAssignmentPageSize + 2; i++)
                    {
                        Random random = new Random();

                        // Get random user
                        int userIndex = random.Next(0, userCount);
                        var principalId = testContext.Users.ElementAt(userIndex);

                        // Get random built-in role definition
                        int roleIndex = random.Next(0, roleCount);
                        var roleDefinition = allBuiltInRolesList.ElementAt(roleIndex);

                        var newRoleAssignment = new RoleAssignmentCreateParameters()
                        {
                            Properties = new RoleAssignmentProperties()
                            {
                                RoleDefinitionId = roleDefinition.Id,
                                PrincipalId = principalId.ToString()
                            }
                        };
                        var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName_" + i);
                        RoleAssignment createResult = null;
                        try
                        {
                            createResult = client.RoleAssignments.Create(
                                scope, 
                                assignmentName.ToString(), 
                                newRoleAssignment.Properties);
                        }
                        catch (CloudException e)
                        {
                            if (e.Response.StatusCode == HttpStatusCode.Conflict)
                            {
                                i--;
                                continue;
                            }
                        }

                        Assert.NotNull(createResult);
                        createdAssignments.Add(createResult);
                    }

                    // Validate
                 
                    // Get the first page of assignments
                    var firstPage = client.RoleAssignments.List(null);
                    Assert.NotNull(firstPage);
                    Assert.NotNull(firstPage.NextPageLink);

                    // Get the next page of assignments
                    var nextPage = client.RoleAssignments.ListNext(firstPage.NextPageLink);
                    
                    Assert.NotNull(nextPage);
                    Assert.NotEqual(0, nextPage.Count());

                    foreach (var roleAssignment in nextPage)
                    {
                        Assert.NotNull(roleAssignment);
                        Assert.NotNull(roleAssignment.Id);
                        Assert.NotNull(roleAssignment.Name);
                        Assert.NotNull(roleAssignment.Type);
                        Assert.NotNull(roleAssignment.Properties);
                        Assert.NotNull(roleAssignment.Properties.PrincipalId);
                        Assert.NotNull(roleAssignment.Properties.RoleDefinitionId);
                        Assert.NotNull(roleAssignment.Properties.Scope);
                    }
                }
                finally
                {
                    foreach (var createdAssignment in createdAssignments)
                    {
                        client.RoleAssignments.Delete(createdAssignment.Properties.Scope, createdAssignment.Name);
                    }
                }
            }
        }


        [Fact]
        public void RoleAssignmentListForScopeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var allRoleAssignments = client.RoleAssignments.ListForScope(
                    "subscriptions/" + client.SubscriptionId,
                    new ODataQuery<RoleAssignmentFilter>(f => f.AtScope()));


                Assert.NotNull(allRoleAssignments);

                foreach (var assignment in allRoleAssignments)
                {
                    Assert.NotNull(assignment);
                    Assert.NotNull(assignment.Id);
                    Assert.NotNull(assignment.Name);
                    Assert.NotNull(assignment.Type);
                    Assert.NotNull(assignment.Properties);
                    Assert.NotNull(assignment.Properties.PrincipalId);
                    Assert.NotNull(assignment.Properties.RoleDefinitionId);
                    Assert.NotNull(assignment.Properties.Scope);
                }
            }
        }

        [Fact(Skip = "Graph issue when adding user to group, needs investigation")]
        public void RoleAssignmentListWithAssignedToFilterTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.SubscriptionId;
                var roleDefinition = client.RoleDefinitions.List(scope).First();
                
                // Get user and group and add the user to the group
                var userId = testContext.Users.First();
                var groupId = testContext.Groups.First();
                testContext.AddMemberToGroup(groupId, userId.ToString());

                // create assignment to group
                var newRoleAssignmentToGroupParams = new RoleAssignmentCreateParameters()
                {
                    Properties = new RoleAssignmentProperties()
                    {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = groupId
                    }
                };
                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName_Group");
                var assignmentToGroup = client.RoleAssignments.Create(
                    scope, 
                    assignmentName.ToString(), 
                    newRoleAssignmentToGroupParams.Properties);

                // create assignment to user
                var newRoleAssignmentToUserParams = new RoleAssignmentCreateParameters()
                {
                    Properties = new RoleAssignmentProperties()
                    {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = userId.ToString()
                    }
                };
                
                assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName_User");
                var assignmentToUser = client.RoleAssignments.Create(scope, 
                    assignmentName.ToString(), 
                    newRoleAssignmentToUserParams.Properties);

                // List role assignments with AssignedTo filter = user id
                var allRoleAssignments = client.RoleAssignments
                    .List(new ODataQuery<RoleAssignmentFilter>(f => f.AssignedTo(userId.ToString())));

                Assert.NotNull(allRoleAssignments);
                Assert.True(allRoleAssignments.Count() >= 2);

                foreach (var assignment in allRoleAssignments)
                {
                    Assert.NotNull(assignment);
                    Assert.NotNull(assignment.Id);
                    Assert.NotNull(assignment.Name);
                    Assert.NotNull(assignment.Type);
                    Assert.NotNull(assignment.Properties);
                    Assert.NotNull(assignment.Properties.PrincipalId);
                    Assert.NotNull(assignment.Properties.RoleDefinitionId);
                    Assert.NotNull(assignment.Properties.Scope);
                }

                // Returned assignments contain assignment to group
                Assert.True(allRoleAssignments.Count(a => a.Properties.PrincipalId.ToString() == groupId) >= 1);
            }
        }

        [Fact]
        public void RoleDefinitionsListGetTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.SubscriptionId;
                var allRoleDefinitions = client.RoleDefinitions.List(scope);
                
                Assert.NotNull(allRoleDefinitions);

                foreach (var roleDefinition in allRoleDefinitions)
                {
                    var singleRole = client.RoleDefinitions.Get(scope, roleDefinition.Name);
                    
                    Assert.NotNull(singleRole);

                    if (singleRole.Properties.Type == "BuiltInRole")
                    {
                        Assert.NotNull(singleRole);
                        Assert.NotNull(singleRole.Id);
                        Assert.NotNull(singleRole.Name);
                        Assert.NotNull(singleRole.Type);
                        Assert.NotNull(singleRole.Properties);
                        Assert.NotNull(singleRole.Properties.Description);
                        Assert.NotNull(singleRole.Properties.RoleName);
                        Assert.NotNull(singleRole.Properties.Type);
                        Assert.NotNull(singleRole.Properties.Permissions);
                   
                        foreach(var assignableScope in singleRole.Properties.AssignableScopes)
                        {
                            Assert.True(!string.IsNullOrWhiteSpace(assignableScope));
                        }

                        foreach(var permission in singleRole.Properties.Permissions) 
                        { 
                            Assert.NotNull(permission.Actions); 
                            Assert.NotNull(permission.NotActions); 
                            Assert.False(permission.Actions.Count() == 0 && 
                            permission.NotActions.Count() == 0); 
                        }
                    }
                }
            }
        }

        // ListWithFilters Method is not supported in Swagger
        //[Fact]
        //public void RoleDefinitionsListWithFilterTests()
        //{
        //    using (MockContext context = MockContext.Start(this.GetType().FullName))
        //    {
        //        var client = testContext.GetAuthorizationManagementClient(context);

        //        Assert.NotNull(client);
        //        Assert.NotNull(client.HttpClient);

        //        var ownerRoleDefinition = client.RoleDefinitions.ListWithFilters(
        //            new ListDefinitionFilterParameters
        //            {
        //                RoleName = "Owner"
        //            });

        //        Assert.NotNull(ownerRoleDefinition);
        //        Assert.NotNull(ownerRoleDefinition.RoleDefinitions);
        //        Assert.Equal(1, ownerRoleDefinition.RoleDefinitions.Count);

        //        // Passsing name as null
        //        var allRoleDefinition = client.RoleDefinitions.ListWithFilters(
        //            new ListDefinitionFilterParameters
        //            {
        //                RoleName = null
        //            });

        //        var allRoleDefinitionsByList = client.RoleDefinitions.List();

        //        Assert.NotNull(allRoleDefinition);
        //        Assert.NotNull(allRoleDefinition.RoleDefinitions);
        //        Assert.Equal(allRoleDefinitionsByList.RoleDefinitions.Count, allRoleDefinition.RoleDefinitions.Count);

        //        Assert.Throws<ArgumentNullException>(() => client.RoleDefinitions.ListWithFilters(null));
        //    }
        //}

        [Fact]
        public void RoleDefinitionsByIdTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.SubscriptionId;
                var allRoleDefinitions = client.RoleDefinitions.List(scope);

                Assert.NotNull(allRoleDefinitions);

                foreach (var roleDefinition in allRoleDefinitions)
                {
                    var singleRole = client.RoleDefinitions.Get(scope, roleDefinition.Name);
                    var byIdRole = client.RoleDefinitions.GetById(roleDefinition.Id);

                    Assert.NotNull(byIdRole);
                    Assert.NotNull(byIdRole.Id);
                    Assert.NotNull(byIdRole.Name);

                    Assert.Equal(
                        singleRole.Id,
                        byIdRole.Id);
                    Assert.Equal(
                        singleRole.Name,
                        byIdRole.Name);
                }
            }
        }

        [Fact]
        public void RoleDefinitionUpdateTests()
        {
			using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                RoleDefinition createOrUpdateParams;
                var roleDefinitionId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition");
                string currentSubscriptionId = "/subscriptions/" + client.SubscriptionId;

                // Create a custom role definition
                try
                {
                    createOrUpdateParams = new RoleDefinition()
                        {
                            // Name = roleDefinitionId,
                            Properties = new RoleDefinitionProperties()
                            {
                                RoleName = "NewRoleName_" + roleDefinitionId.ToString(),
                                Description = "New Test Custom Role",
                                Permissions = new List<Permission>()
                                {
                                    new Permission()
                                    {
                                        Actions = new List<string>{ "Microsoft.Authorization/*/Read" }
                                    }
                                },
                                AssignableScopes = new List<string>() { currentSubscriptionId },
                            },
                    };

                    var roleDefinition = client.RoleDefinitions.CreateOrUpdate(
                        currentSubscriptionId, 
                        roleDefinitionId.ToString(), 
                        createOrUpdateParams);

                    // Update role name, permissions for the custom role
                    createOrUpdateParams.Properties.RoleName = "UpdatedRoleName_" + roleDefinitionId.ToString();
                    createOrUpdateParams.Properties.Permissions.Single().Actions.Add("Microsoft.Support/*/read");

                    var updatedRoleDefinition = client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams);
                   
                    // Validate the updated roleDefinition properties.
                    Assert.NotNull(updatedRoleDefinition);
                    Assert.Equal(updatedRoleDefinition.Id, roleDefinition.Id);
                    Assert.Equal(updatedRoleDefinition.Name, roleDefinition.Name);
                    // Role name and permissions should be updated
                    Assert.Equal("UpdatedRoleName_" + roleDefinitionId.ToString(), updatedRoleDefinition.Properties.RoleName);
                    Assert.NotEmpty(updatedRoleDefinition.Properties.Permissions);
                    Assert.Equal("Microsoft.Authorization/*/Read", updatedRoleDefinition.Properties.Permissions.Single().Actions.First());
                    Assert.Equal("Microsoft.Support/*/read", updatedRoleDefinition.Properties.Permissions.Single().Actions.Last());
                    // Same assignable scopes
                    Assert.NotEmpty(updatedRoleDefinition.Properties.AssignableScopes);
                    Assert.Equal(currentSubscriptionId.ToLower(), updatedRoleDefinition.Properties.AssignableScopes.Single().ToLower());
                
                    // Negative test: Update the role with an empty RoleName 
                    createOrUpdateParams.Properties.RoleName = null;

                    try
                    {
                        client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams);
                    }
                    catch (CloudException ce)
                    {
                        Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                    }
                }
                finally
                {
                    var deleteResult = client.RoleDefinitions.Delete(
                        currentSubscriptionId, 
                        roleDefinitionId.ToString());
                    Assert.NotNull(deleteResult);
                }
            }
        }

        [Fact]
        public void RoleDefinitionCreateTests()
        {
            const string RoleDefIdPrefix = "/providers/Microsoft.Authorization/roleDefinitions/";
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                RoleDefinition createOrUpdateParams;
                var roleDefinitionId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition1");
                string currentSubscriptionId = "/subscriptions/" + client.SubscriptionId;
                string fullRoleId = currentSubscriptionId + RoleDefIdPrefix + roleDefinitionId;

                Guid newRoleId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition2"); 
                var resourceGroup = "newtestrg";   
                string resourceGroupScope = currentSubscriptionId + "/resourceGroups/" + resourceGroup;

                // Create a custom role definition
                try
                {
                    createOrUpdateParams = new RoleDefinition()
                        {
                            Properties = new RoleDefinitionProperties()
                            {
                                RoleName = "NewRoleName_" + roleDefinitionId.ToString(),
                                Description = "New Test Custom Role",
                                Permissions = new List<Permission>()
                                {
                                    new Permission()
                                    {
                                        Actions = new List<string>{ "Microsoft.Authorization/*/Read" }
                                    }
                                },
                                AssignableScopes = new List<string>() { currentSubscriptionId },
                            },
                    };

                    var roleDefinition = client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams);

                    // Validate the roleDefinition properties.
                    Assert.NotNull(roleDefinition);
                    Assert.Equal(fullRoleId, roleDefinition.Id);
                    Assert.Equal(roleDefinitionId.ToString(), roleDefinition.Name);
                    Assert.NotNull(roleDefinition.Properties);
                    Assert.Equal("CustomRole", roleDefinition.Properties.Type);
                    Assert.Equal("New Test Custom Role", roleDefinition.Properties.Description);
                    Assert.NotEmpty(roleDefinition.Properties.AssignableScopes);
                    Assert.Equal(currentSubscriptionId.ToLower(), roleDefinition.Properties.AssignableScopes.Single().ToLower());
                    Assert.NotEmpty(roleDefinition.Properties.Permissions);
                    Assert.Equal("Microsoft.Authorization/*/Read", roleDefinition.Properties.Permissions.Single().Actions.Single());

                    // create resource group
                    var resourceClient = PermissionsTests.GetResourceManagementClient(context);                    
                    resourceClient.ResourceGroups.CreateOrUpdate(
                        resourceGroup, 
                        new ResourceGroup
                        { Location = "westus"});
                    createOrUpdateParams.Properties.AssignableScopes = new List<string> { resourceGroupScope };
                    createOrUpdateParams.Properties.RoleName = "NewRoleName_" + newRoleId.ToString();

                    roleDefinition = client.RoleDefinitions.CreateOrUpdate(
                        resourceGroupScope,
                        newRoleId.ToString(), 
                        createOrUpdateParams);
                    Assert.NotNull(roleDefinition);

                }
                finally
                {
                    var deleteResult = client.RoleDefinitions.Delete(currentSubscriptionId, roleDefinitionId.ToString());
                    Assert.NotNull(deleteResult);

                    deleteResult = client.RoleDefinitions.Delete(resourceGroupScope, newRoleId.ToString());
                    Assert.NotNull(deleteResult);
                }

                
                TestUtilities.Wait(1000 * 15);

                // Negative test - create a roledefinition with same name (but different id) as an already existing custom role
                try
                {
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams);
                    var roleDefinition2Id = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition3");
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams);
                }
                catch (CloudException ce)
                {
                    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                }
                finally
                {
                    var deleteResult = client.RoleDefinitions.Delete(currentSubscriptionId, roleDefinitionId.ToString());
                    Assert.NotNull(deleteResult);
                }

                var scope = "subscriptions/" + client.SubscriptionId;
                // Negative test - create a roledefinition with same id as a built-in role
                try
                {
                    var allRoleDefinitions = client.RoleDefinitions.List(scope);
                    Assert.NotNull(allRoleDefinitions);
                    RoleDefinition builtInRole = allRoleDefinitions.First(x => x.Properties.Type == "BuiltInRole");

                    createOrUpdateParams.Properties.RoleName = "NewRoleName_" + builtInRole.Name.ToString();
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        builtInRole.Name, createOrUpdateParams);
                }
                catch (CloudException ce)
                {
                    Assert.Equal(HttpStatusCode.Conflict, ce.Response.StatusCode);
                }
              
                // Negative test - create a roledefinition with type=BuiltInRole
                createOrUpdateParams.Properties.Type = "BuiltInRole";

                try
                {
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams);
                }
                catch(CloudException ce)
                {
                    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                }
                
                // Negative Test - create a custom role with empty role name
                // reset the role type
                createOrUpdateParams.Properties.Type = null;
                createOrUpdateParams.Properties.RoleName = string.Empty;

                try
                {
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams);
                }
                catch (CloudException ce)
                {
                    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                }

                // Negative Test - create a custom role with empty assignable scopes
                // reset the role name
                createOrUpdateParams.Properties.RoleName = "NewRoleName_" + roleDefinitionId.ToString();
                createOrUpdateParams.Properties.AssignableScopes = new List<string>();

                try
                {
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams);
                }
                catch (CloudException ce)
                {
                    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                }

                // Negative Test - create a custom role with invalid value for assignable scopes
                createOrUpdateParams.Properties.AssignableScopes.Add("Invalid_Scope");

                //try
                //{
                //    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                //        roleDefinitionId.ToString(),
                //        createOrUpdateParams.RoleDefinition);
                //}
                //catch (CloudException ce)
                //{
                //    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                //}

                // Negative Test - create a custom role with empty permissions
                // reset assignable scopes

                /* TODO: Uncomment the below test case when PAS/PAS-RP determine whether to implement blocking of 
                 * create with empty Permission list
                 */
                ////createOrUpdateParams.RoleDefinition.Properties.AssignableScopes.Remove("Invalid_Scope");
                ////createOrUpdateParams.RoleDefinition.Properties.AssignableScopes.Add(currentSubscriptionId);
                ////createOrUpdateParams.RoleDefinition.Properties.Permissions = new List<Permission>();

                ////try
                ////{
                ////    client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, createOrUpdateParams);
                ////}
                ////catch (CloudException ce)
                ////{
                ////    Assert.Equal("AssignableScopeNotUnderSubscriptionScope", ce.Error.Code);
                ////    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                ////}
            }
        }

        private static T GetValueFromTestContext<T>(Func<T> constructor, Func<string, T> parser, string mockName)
        {
            T retValue = default(T);

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                retValue = constructor.Invoke();
                HttpMockServer.Variables[mockName] = retValue.ToString();
            }
            else
            {
                if (HttpMockServer.Variables.ContainsKey(mockName))
                {
                    retValue = parser.Invoke(HttpMockServer.Variables[mockName]);
                }
            }

            return retValue;
        }
    }
}
