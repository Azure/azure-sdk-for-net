﻿//
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using Hyak.Common;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Xunit;

namespace Authorization.Tests
{
    public class BasicTests : TestBase, IUseFixture<TestExecutionContext>
    {
        public const string ResourceGroup = "resourcegroups/AzureStackSDK";
        private TestExecutionContext testContext;
        private const int RoleAssignmentPageSize = 20;
        private const string RESOURCE_TEST_LOCATION = "westus";
        private const string WEBSITE_RP_VERSION = "2014-04-01";        

        public void SetFixture(TestExecutionContext context)
        {
            testContext = context;
        }

        public static ResourceManagementClient GetResourceManagementClient()
        {
            var client = TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }

            return client;
        }

        [Fact]
        public void ClassicAdministratorListTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var allClassicAdmins = client.ClassicAdministrators.List();

                Assert.NotNull(allClassicAdmins);
                Assert.NotNull(allClassicAdmins.ClassicAdministrators);

                foreach (var classicAdmin in allClassicAdmins.ClassicAdministrators)
                {
                    Assert.NotNull(classicAdmin);
                    Assert.NotNull(classicAdmin.Id);
                    Assert.True(classicAdmin.Id.Contains("/providers/Microsoft.Authorization/classicAdministrators/"));
                    Assert.True(classicAdmin.Id.Contains("/subscriptions/" + client.Credentials.SubscriptionId));
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
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                var client = testContext.GetAuthorizationManagementClient();

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);
                
                var principalId = testContext.Users.ElementAt(4);

                var scope = "subscriptions/" + client.Credentials.SubscriptionId + "/" + ResourceGroup;
                var roleDefinition = client.RoleDefinitions.List(scope, null).RoleDefinitions.ElementAt(1);
                var newRoleAssignment = new RoleAssignmentCreateParameters()
                {
                    Properties = new RoleAssignmentProperties()
                    {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = principalId.ToString()
                    }
                };

                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentNameTestById");

                var assignmentId = string.Format(
                    "{0}/providers/Microsoft.Authorization/roleAssignments/{1}",
                    scope,
                    assignmentName);

                // Create
                var createResult = client.RoleAssignments.CreateById(assignmentId, newRoleAssignment);
                Assert.NotNull(createResult);
                Assert.Equal(HttpStatusCode.Created, createResult.StatusCode);
                Assert.NotNull(createResult.RoleAssignment);
                Assert.NotNull(createResult.RoleAssignment.Id);
                Assert.NotNull(createResult.RoleAssignment.Name);
                Assert.Equal(createResult.RoleAssignment.Name, assignmentName);

                // Get
                var getResult = client.RoleAssignments.GetById(assignmentId);
                Assert.NotNull(getResult);
                Assert.Equal(HttpStatusCode.OK, getResult.StatusCode);
                Assert.NotNull(getResult.RoleAssignment);
                Assert.Equal(createResult.RoleAssignment.Id, getResult.RoleAssignment.Id);
                Assert.Equal(createResult.RoleAssignment.Name, getResult.RoleAssignment.Name);
                
                //Delete
                var deleteResult = client.RoleAssignments.DeleteById(assignmentId);
                Assert.NotNull(deleteResult);
                Assert.Equal(HttpStatusCode.OK, deleteResult.StatusCode);

                var allRoleAssignments = client.RoleAssignments.List(null);
                var createdAssignment = allRoleAssignments.RoleAssignments.FirstOrDefault(
                                            a => a.Name == assignmentName);

                Assert.Null(createdAssignment);
            }
        }

        [Fact]
        public void RoleAssignmentsListGetTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                var client = testContext.GetAuthorizationManagementClient();

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentNameTestListGet");

                var scope = "subscriptions/" + client.Credentials.SubscriptionId + "/" + ResourceGroup;
                var principalId = testContext.Users.ElementAt(5);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var roleDefinition = client.RoleDefinitions.List(scope, null).RoleDefinitions.Where(r => r.Properties.Type == "BuiltInRole").Last();
                var newRoleAssignment = new RoleAssignmentCreateParameters()
                {
                    Properties = new RoleAssignmentProperties()
                    {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = principalId.ToString()
                    }
                };

                var createResult = client.RoleAssignments.Create(scope, assignmentName, newRoleAssignment);
                Assert.NotNull(createResult);
                
                var allRoleAssignments = client.RoleAssignments.List(null);

                Assert.NotNull(allRoleAssignments);
                Assert.NotNull(allRoleAssignments.RoleAssignments);

                foreach (var assignment in allRoleAssignments.RoleAssignments)
                {
                    if (assignment.Properties.Scope.Contains(ResourceGroup))
                    {
                        var singleAssignment = client.RoleAssignments.Get(assignment.Properties.Scope, assignment.Name);

                        Assert.NotNull(singleAssignment);
                        Assert.NotNull(singleAssignment.StatusCode);
                        Assert.NotNull(singleAssignment.RoleAssignment);
                        Assert.NotNull(singleAssignment.RoleAssignment.Id);
                        Assert.NotNull(singleAssignment.RoleAssignment.Name);
                        Assert.NotNull(singleAssignment.RoleAssignment.Type);
                        Assert.NotNull(singleAssignment.RoleAssignment.Properties);
                        Assert.NotNull(singleAssignment.RoleAssignment.Properties.PrincipalId);
                        Assert.NotNull(singleAssignment.RoleAssignment.Properties.RoleDefinitionId);
                        Assert.NotNull(singleAssignment.RoleAssignment.Properties.Scope);
                    }                    
                }

                var deleteResult = client.RoleAssignments.Delete(scope, assignmentName);
                Assert.NotNull(deleteResult);
            }
        }

        [Fact(Skip = "PAS Service needs to be fixed before this test can be enabled.")]
        public void RoleDefinitionsCustomRoleTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var subscriptionScope = "/subscriptions/" + client.Credentials.SubscriptionId;
                var allRoleDefinitions = client.RoleDefinitions.List(subscriptionScope, null);

                Assert.NotNull(allRoleDefinitions);
                Assert.NotNull(allRoleDefinitions.RoleDefinitions);

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                var resourceClient = GetResourceManagementClient();
                resourceClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new Microsoft.Azure.Management.Resources.Models.ResourceGroup { Location = RESOURCE_TEST_LOCATION });

                var resourceGroupScope = subscriptionScope + "/resourcegroups/" + resourceGroupName;

                RoleDefinitionCreateOrUpdateParameters createOrUpdateParams;
                var roleDefinitionId1 = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition1");
                var roleDefinitionId2 = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition2");

                try
                {
                    // Create a custom role definition with subscription scope as assignable scope
                    createOrUpdateParams = new RoleDefinitionCreateOrUpdateParameters()
                    {
                        RoleDefinition = new RoleDefinition()
                        {
                            Properties = new RoleDefinitionProperties()
                            {
                                RoleName = "CustomRoleName_SubscriptionScope" + roleDefinitionId1,
                                Description = "CustomRoleDescription_SubscriptionScope",
                                Permissions = new List<Permission>()
                                {
                                    new Permission()
                                    {
                                        Actions = new List<string> {"Microsoft.Authorization/*/Read"}
                                    }
                                },
                                AssignableScopes = new List<string>() { subscriptionScope },
                            },
                        }
                    };

                    var roleWithSubscriptionScope = client.RoleDefinitions.CreateOrUpdate(roleDefinitionId1, subscriptionScope, createOrUpdateParams);

                    // Create a custom role definition with resource group scope as assignable scope
                    createOrUpdateParams = new RoleDefinitionCreateOrUpdateParameters()
                    {
                        RoleDefinition = new RoleDefinition()
                        {
                            Properties = new RoleDefinitionProperties()
                            {
                                RoleName = "CustomRoleName_RGScope" + roleDefinitionId2,
                                Description = "CustomRoleDescription_RGScope",
                                Permissions = new List<Permission>()
                                {
                                    new Permission()
                                    {
                                        Actions = new List<string> {"Microsoft.Authorization/*/Read"}
                                    }
                                },
                                AssignableScopes = new List<string>() { resourceGroupScope },
                            },
                        }
                    };

                    var roleWithResourceGroupScope = client.RoleDefinitions.CreateOrUpdate(roleDefinitionId2, resourceGroupScope, createOrUpdateParams);

                    // Query all roles
                    var rolesAtSubscriptionScope = client.RoleDefinitions.List(subscriptionScope, null);
                    var rolesAtRgScope = client.RoleDefinitions.List(resourceGroupScope, null);

                    Assert.NotNull(rolesAtSubscriptionScope);
                    Assert.NotNull(rolesAtRgScope);

                    var customRolesAtSubscriptionScope = rolesAtSubscriptionScope.RoleDefinitions.Where(r => !r.Properties.Type.Equals("builtinRole", StringComparison.InvariantCultureIgnoreCase));
                    var customRolesAtRgScope = rolesAtRgScope.RoleDefinitions.Where(r => !r.Properties.Type.Equals("builtinRole", StringComparison.InvariantCultureIgnoreCase));

                    Assert.NotNull(customRolesAtSubscriptionScope);
                    Assert.NotNull(customRolesAtRgScope);
                    Assert.True(customRolesAtSubscriptionScope.Any());
                    Assert.True(customRolesAtRgScope.Any());


                    // TODO: Not working, needs investigation. 
                    // Querying at subscription scope should not return custom role created at resourcegroup scope (without the atScopeAndBelow() filter)
                    Assert.True(customRolesAtSubscriptionScope.Any(r => r.Name == roleDefinitionId1));
                    Assert.False(customRolesAtSubscriptionScope.Any(r => r.Name == roleDefinitionId2));


                    // Querying at RG scope should return custom role created both at subscription resourcegroup scope
                    Assert.True(customRolesAtRgScope.Any(r => r.Name == roleDefinitionId1));
                    Assert.True(customRolesAtRgScope.Any(r => r.Name == roleDefinitionId2));


                    // Query at Subscription scope for role1 using Name filter, should return the role
                    var customRoleSubscriptionScopeWithName1 = client.RoleDefinitions.List(subscriptionScope,
                        new ListDefinitionFilterParameters
                        {
                            RoleName = "CustomRoleName_SubscriptionScope" + roleDefinitionId1,
                        });

                    Assert.NotNull(customRoleSubscriptionScopeWithName1);
                    Assert.Equal(1, customRoleSubscriptionScopeWithName1.RoleDefinitions.Count);
                    Assert.True(customRoleSubscriptionScopeWithName1.RoleDefinitions.First().Name == roleDefinitionId1);


                    // Query at Subscription scope for role2 using Name filter, should not return anything
                    var customRoleSubscriptionScopeWithName2 = client.RoleDefinitions.List(subscriptionScope,
                        new ListDefinitionFilterParameters
                        {
                            RoleName = "CustomRoleName_RGScope" + roleDefinitionId2,
                        });

                    Assert.NotNull(customRoleSubscriptionScopeWithName2);
                    Assert.Empty(customRoleSubscriptionScopeWithName2.RoleDefinitions);


                    // Query for roles at subscription scope with ScopeAndBelow filter
                    var customRoleSubscriptionScopeWithScopeAndBelow = client.RoleDefinitions.List(subscriptionScope,
                        new ListDefinitionFilterParameters
                        {
                            AtScopeAndBelow = true
                        });

                    Assert.NotNull(customRoleSubscriptionScopeWithScopeAndBelow);
                    Assert.True(customRoleSubscriptionScopeWithScopeAndBelow.RoleDefinitions.Any(r => r.Name == roleDefinitionId1));
                    Assert.True(customRoleSubscriptionScopeWithScopeAndBelow.RoleDefinitions.Any(r => r.Name == roleDefinitionId2));


                    // Query for roles at resourceGroupScope with ScopeAndBelow filter
                    var customRoleRGScopeWithScopeAndBelow = client.RoleDefinitions.List(resourceGroupScope,
                        new ListDefinitionFilterParameters
                        {
                            AtScopeAndBelow = true
                        });

                    Assert.NotNull(customRoleRGScopeWithScopeAndBelow);
                    Assert.True(customRoleRGScopeWithScopeAndBelow.RoleDefinitions.Any(r => r.Name == roleDefinitionId1));
                    Assert.True(customRoleRGScopeWithScopeAndBelow.RoleDefinitions.Any(r => r.Name == roleDefinitionId2));


                    // Query for roles at subscription scope with scopeAndBelow and Name filter with role at Subscription
                    var customRoleSubscriptionScopeWithScopeAndBelowAndName1 = client.RoleDefinitions.List(subscriptionScope,
                        new ListDefinitionFilterParameters
                        {
                            AtScopeAndBelow = true,
                            RoleName = "CustomRoleName_SubscriptionScope" + roleDefinitionId1
                        });

                    Assert.NotNull(customRoleSubscriptionScopeWithScopeAndBelowAndName1);
                    Assert.Equal(1, customRoleSubscriptionScopeWithScopeAndBelowAndName1.RoleDefinitions.Count);
                    Assert.True(customRoleSubscriptionScopeWithScopeAndBelowAndName1.RoleDefinitions.First().Name == roleDefinitionId1);


                    // Query for roles at subscription scope with scopeAndBelow and Name filter with role at RG
                    var customRoleSubscriptionScopeWithScopeAndBelowAndName2 = client.RoleDefinitions.List(subscriptionScope,
                        new ListDefinitionFilterParameters
                        {
                            AtScopeAndBelow = true,
                            RoleName = "CustomRoleName_RGScope" + roleDefinitionId2
                        });

                    Assert.NotNull(customRoleSubscriptionScopeWithScopeAndBelowAndName2);
                    Assert.Equal(1, customRoleSubscriptionScopeWithScopeAndBelowAndName2.RoleDefinitions.Count);
                    Assert.True(customRoleSubscriptionScopeWithScopeAndBelowAndName2.RoleDefinitions.First().Name == roleDefinitionId2);
                }
                finally
                {
                    var deleteResult1 = client.RoleDefinitions.Delete(roleDefinitionId1, subscriptionScope);
                    Assert.NotNull(deleteResult1);

                    var deleteResult2 = client.RoleDefinitions.Delete(roleDefinitionId2, resourceGroupScope);
                    Assert.NotNull(deleteResult2);

                    resourceClient.ResourceGroups.Delete(resourceGroupName);
                }

            }
        }

        [Fact]
        public void RoleAssignmentsCreateDeleteTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                 context.Start();

                var client = testContext.GetAuthorizationManagementClient();

                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentNameCreateDeleteTest");

                var scope = "subscriptions/" + client.Credentials.SubscriptionId + "/" + ResourceGroup;
                var principalId = testContext.Users.ElementAt(3);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var roleDefinition = client.RoleDefinitions.List(scope, null).RoleDefinitions.Last();
                var newRoleAssignment = new RoleAssignmentCreateParameters()
                {
                    Properties = new RoleAssignmentProperties()
                    {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = principalId.ToString()
                    }
                };

                var createResult = client.RoleAssignments.Create(scope, assignmentName, newRoleAssignment);
                Assert.NotNull(createResult);
                Assert.Equal(HttpStatusCode.Created, createResult.StatusCode);
                Assert.NotNull(createResult.RoleAssignment);
                
                var deleteResult = client.RoleAssignments.Delete(scope, assignmentName);
                Assert.NotNull(deleteResult);
                Assert.Equal(HttpStatusCode.OK, deleteResult.StatusCode);
                var deletedRoleAssignment = deleteResult.RoleAssignment;
                Assert.NotNull(deletedRoleAssignment);
                Assert.Equal(deletedRoleAssignment.Id, createResult.RoleAssignment.Id);

                var allRoleAssignments = client.RoleAssignments.List(null);
                var createdAssignment = allRoleAssignments.RoleAssignments.FirstOrDefault(
                                            a => a.Name == assignmentName);

                Assert.Null(createdAssignment);
            }
        }

        [Fact]
        public void RoleAssignmentAtScopeAndAboveTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var allRoleAssignments = client.RoleAssignments.List(new ListAssignmentsFilterParameters
                    {
                        AtScope = true,
                    });

                Assert.NotNull(allRoleAssignments);
                Assert.NotNull(allRoleAssignments.RoleAssignments);

                foreach (var assignment in allRoleAssignments.RoleAssignments)
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
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();
                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var principalId = testContext.Users.ElementAt(1);
                // Read/write the PrincipalId from Testcontext to enable Playback mode test execution
                principalId = GetValueFromTestContext(() => principalId, Guid.Parse, "PrincipalId");

                var scope = "subscriptions/" + client.Credentials.SubscriptionId + "/" + ResourceGroup;
                var roleDefinition = client.RoleDefinitions.List(scope , null).RoleDefinitions.Last();

                for(int i=0; i<testContext.Users.Count; i++)
                {
                    var pId = testContext.Users.ElementAt(i);
                    var newRoleAssignment = new RoleAssignmentCreateParameters()
                    {
                        Properties = new RoleAssignmentProperties()
                        {
                            RoleDefinitionId = roleDefinition.Id,
                            PrincipalId = pId.ToString()
                        }
                    };
                    var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName_" + i);
                    var createResult = client.RoleAssignments.Create(scope, assignmentName, newRoleAssignment);
                }

                var allRoleAssignments = client.RoleAssignments.List(new ListAssignmentsFilterParameters
                    {
                        PrincipalId = principalId.ToString()
                    });

                Assert.NotNull(allRoleAssignments);
                Assert.NotNull(allRoleAssignments.RoleAssignments);

                foreach (var assignment in allRoleAssignments.RoleAssignments)
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
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.Credentials.SubscriptionId + "/" + ResourceGroup;
                var allBuiltInRoles = client.RoleDefinitions.List(scope, null).RoleDefinitions.Where(r => r.Properties.Type.Equals("BuiltInRole", StringComparison.OrdinalIgnoreCase));
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
                        RoleAssignmentCreateResult createResult = null;
                        try
                        {
                            createResult = client.RoleAssignments.Create(scope, assignmentName, newRoleAssignment);
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
                        Assert.NotNull(createResult.RoleAssignment);
                        createdAssignments.Add(createResult.RoleAssignment);
                    }

                    // Validate
                 
                    // Get the first page of assignments
                    var firstPage = client.RoleAssignments.List(null);
                    Assert.NotNull(firstPage);
                    Assert.True(firstPage.StatusCode == HttpStatusCode.OK);
                    Assert.NotNull(firstPage.RoleAssignments);
                    Assert.NotNull(firstPage.NextLink);

                    // Get the next page of assignments
                    var nextPage = client.RoleAssignments.ListNext(firstPage.NextLink);

                    Assert.True(nextPage.StatusCode == HttpStatusCode.OK);
                    Assert.NotNull(nextPage.RoleAssignments);
                    Assert.NotEqual(0, nextPage.RoleAssignments.Count());

                    foreach (var roleAssignment in nextPage.RoleAssignments)
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
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var allRoleAssignments = client.RoleAssignments.ListForScope(
                    "subscriptions/" + client.Credentials.SubscriptionId + "/" + ResourceGroup,
                    new ListAssignmentsFilterParameters
                    {
                        AtScope = true
                    });

                Assert.NotNull(allRoleAssignments);
                Assert.NotNull(allRoleAssignments.RoleAssignments);

                foreach (var assignment in allRoleAssignments.RoleAssignments)
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
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.Credentials.SubscriptionId + "/" + ResourceGroup;
                var roleDefinition = client.RoleDefinitions.List(scope, null).RoleDefinitions.First();
                
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
                var assignmentToGroup = client.RoleAssignments.Create(scope, assignmentName, newRoleAssignmentToGroupParams);

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
                var assignmentToUser = client.RoleAssignments.Create(scope, assignmentName, newRoleAssignmentToUserParams);
            
                // List role assignments with AssignedTo filter = user id
                var allRoleAssignments = client.RoleAssignments.List(new ListAssignmentsFilterParameters
                {
                    AssignedToPrincipalId = userId.ToString()
                });

                Assert.NotNull(allRoleAssignments);
                Assert.NotNull(allRoleAssignments.RoleAssignments);
                Assert.True(allRoleAssignments.RoleAssignments.Count >= 2);

                foreach (var assignment in allRoleAssignments.RoleAssignments)
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
                Assert.True(allRoleAssignments.RoleAssignments.Count(a => a.Properties.PrincipalId.ToString() == groupId) >= 1);
            }
        }

        [Fact]
        public void RoleDefinitionsListGetTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.Credentials.SubscriptionId + "/" + ResourceGroup;
                var allRoleDefinitions = client.RoleDefinitions.List(scope, null);
                
                Assert.NotNull(allRoleDefinitions);
                Assert.NotNull(allRoleDefinitions.RoleDefinitions);

                foreach (var roleDefinition in allRoleDefinitions.RoleDefinitions)
                {
                    var singleRole = client.RoleDefinitions.Get(roleDefinition.Name, scope);
                    
                    Assert.NotNull(singleRole);

                    if (singleRole.RoleDefinition.Properties.Type == "BuiltInRole")
                    {
                        Assert.NotNull(singleRole.StatusCode);
                        Assert.NotNull(singleRole.RoleDefinition);
                        Assert.NotNull(singleRole.RoleDefinition.Id);
                        Assert.NotNull(singleRole.RoleDefinition.Name);
                        Assert.NotNull(singleRole.RoleDefinition.Type);
                        Assert.NotNull(singleRole.RoleDefinition.Properties);
                        Assert.NotNull(singleRole.RoleDefinition.Properties.Description);
                        Assert.NotNull(singleRole.RoleDefinition.Properties.RoleName);
                        Assert.NotNull(singleRole.RoleDefinition.Properties.Type);
                        Assert.NotNull(singleRole.RoleDefinition.Properties.Permissions);
                   
                        foreach(var assignableScope in singleRole.RoleDefinition.Properties.AssignableScopes)
                        {
                            Assert.True(!string.IsNullOrWhiteSpace(assignableScope));
                        }

                        foreach(var permission in singleRole.RoleDefinition.Properties.Permissions) 
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

        [Fact]
        public void RoleDefinitionsListWithFilterTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.Credentials.SubscriptionId + "/" + ResourceGroup;

                var ownerRoleDefinition = client.RoleDefinitions.List(
                    scope,
                    new ListDefinitionFilterParameters
                    {
                        RoleName = "Owner"
                    });

                Assert.NotNull(ownerRoleDefinition);
                Assert.NotNull(ownerRoleDefinition.RoleDefinitions);
                Assert.Equal(1, ownerRoleDefinition.RoleDefinitions.Count);

                // Passsing name as null
                var allRoleDefinition = client.RoleDefinitions.List(
                    scope,
                    new ListDefinitionFilterParameters
                    {
                        RoleName = null
                    });

                var allRoleDefinitionsByList = client.RoleDefinitions.List(scope, null);

                Assert.NotNull(allRoleDefinition);
                Assert.NotNull(allRoleDefinition.RoleDefinitions);
                Assert.Equal(allRoleDefinitionsByList.RoleDefinitions.Count, allRoleDefinition.RoleDefinitions.Count);
            }
        }

        [Fact]
        public void RoleDefinitionsByIdTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.Credentials.SubscriptionId + "/" + ResourceGroup;
                var allRoleDefinitions = client.RoleDefinitions.List(scope, null);

                Assert.NotNull(allRoleDefinitions);
                Assert.NotNull(allRoleDefinitions.RoleDefinitions);

                foreach (var roleDefinition in allRoleDefinitions.RoleDefinitions)
                {
                    var singleRole = client.RoleDefinitions.Get(roleDefinition.Name, scope);
                    var byIdRole = client.RoleDefinitions.GetById(roleDefinition.Id);

                    Assert.NotNull(byIdRole);
                    Assert.NotNull(byIdRole.StatusCode);
                    Assert.NotNull(byIdRole.RoleDefinition);
                    Assert.NotNull(byIdRole.RoleDefinition.Id);
                    Assert.NotNull(byIdRole.RoleDefinition.Name);

                    Assert.Equal(
                        singleRole.RoleDefinition.Id,
                        byIdRole.RoleDefinition.Id);
                    Assert.Equal(
                        singleRole.RoleDefinition.Name,
                        byIdRole.RoleDefinition.Name);
                }
            }
        }

        [Fact]
        public void RoleDefinitionUpdateTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                RoleDefinitionCreateOrUpdateParameters createOrUpdateParams;
                var roleDefinitionId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition");
                string currentSubscriptionId = "subscriptions/" + client.Credentials.SubscriptionId + "/" + ResourceGroup;

                // Create a custom role definition
                try
                {
                    createOrUpdateParams = new RoleDefinitionCreateOrUpdateParameters()
                    {
                        RoleDefinition = new RoleDefinition()
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
                        }
                    };

                    var roleDefinition = client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, currentSubscriptionId, createOrUpdateParams);

                    // Update role name, permissions for the custom role
                    createOrUpdateParams.RoleDefinition.Properties.RoleName = "UpdatedRoleName_" + roleDefinitionId.ToString();
                    createOrUpdateParams.RoleDefinition.Properties.Permissions.Single().Actions.Add("Microsoft.Support/*/read");

                    var updatedRoleDefinition = client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, currentSubscriptionId, createOrUpdateParams);
                   
                    // Validate the updated roleDefinition properties.
                    Assert.NotNull(updatedRoleDefinition);
                    Assert.NotNull(updatedRoleDefinition.RoleDefinition);
                    Assert.Equal(updatedRoleDefinition.RoleDefinition.Id, roleDefinition.RoleDefinition.Id);
                    Assert.Equal(updatedRoleDefinition.RoleDefinition.Name, roleDefinition.RoleDefinition.Name);
                    // Role name and permissions should be updated
                    Assert.Equal("UpdatedRoleName_" + roleDefinitionId.ToString(), updatedRoleDefinition.RoleDefinition.Properties.RoleName);
                    Assert.NotEmpty(updatedRoleDefinition.RoleDefinition.Properties.Permissions);
                    Assert.Equal("Microsoft.Authorization/*/Read", updatedRoleDefinition.RoleDefinition.Properties.Permissions.Single().Actions.First());
                    Assert.Equal("Microsoft.Support/*/read", updatedRoleDefinition.RoleDefinition.Properties.Permissions.Single().Actions.Last());
                    // Same assignable scopes
                    Assert.NotEmpty(updatedRoleDefinition.RoleDefinition.Properties.AssignableScopes);
                    Assert.Equal(currentSubscriptionId.ToLower(), updatedRoleDefinition.RoleDefinition.Properties.AssignableScopes.Single().ToLower());
                
                    // Negative test: Update the role with an empty RoleName 
                    createOrUpdateParams.RoleDefinition.Properties.RoleName = null;

                    try
                    {
                        client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, currentSubscriptionId, createOrUpdateParams);
                    }
                    catch (CloudException ce)
                    {
                        Assert.Equal("RoleDefinitionNameNullOrEmpty", ce.Error.Code);
                        Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                    }
                }
                finally
                {
                    var deleteResult = client.RoleDefinitions.Delete(roleDefinitionId, currentSubscriptionId);
                    Assert.NotNull(deleteResult);
                }

                TestUtilities.EndTest();
            }
        }

        [Fact]
        public void RoleDefinitionCreateTests()
        {
            const string RoleDefIdPrefix = "/providers/Microsoft.Authorization/roleDefinitions/";
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                RoleDefinitionCreateOrUpdateParameters createOrUpdateParams;
                var roleDefinitionId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition1");
                string currentSubscriptionId = "/subscriptions/" + client.Credentials.SubscriptionId;
                string fullRoleId = currentSubscriptionId + RoleDefIdPrefix + roleDefinitionId;

                Guid newRoleId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition2"); 
                var resourceGroup = "newtestrg";   
                string resourceGroupScope = currentSubscriptionId + "/resourceGroups/" + resourceGroup;

                // Create a custom role definition
                try
                {
                    createOrUpdateParams = new RoleDefinitionCreateOrUpdateParameters()
                    {
                        RoleDefinition = new RoleDefinition()
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
                        }
                    };

                    var roleDefinition = client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, currentSubscriptionId, createOrUpdateParams);

                    // Validate the roleDefinition properties.
                    Assert.NotNull(roleDefinition);
                    Assert.NotNull(roleDefinition.RoleDefinition);
                    Assert.Equal(fullRoleId, roleDefinition.RoleDefinition.Id);
                    Assert.Equal(roleDefinitionId, roleDefinition.RoleDefinition.Name);
                    Assert.NotNull(roleDefinition.RoleDefinition.Properties);
                    Assert.Equal("CustomRole", roleDefinition.RoleDefinition.Properties.Type);
                    Assert.Equal("New Test Custom Role", roleDefinition.RoleDefinition.Properties.Description);
                    Assert.NotEmpty(roleDefinition.RoleDefinition.Properties.AssignableScopes);
                    Assert.Equal(currentSubscriptionId.ToLower(), roleDefinition.RoleDefinition.Properties.AssignableScopes.Single().ToLower());
                    Assert.NotEmpty(roleDefinition.RoleDefinition.Properties.Permissions);
                    Assert.Equal("Microsoft.Authorization/*/Read", roleDefinition.RoleDefinition.Properties.Permissions.Single().Actions.Single());

                    // create resource group
                    var resourceClient = PermissionsTests.GetResourceManagementClient();                    
                    resourceClient.ResourceGroups.CreateOrUpdate(resourceGroup, new Microsoft.Azure.Management.Resources.Models.ResourceGroup { Location = "westus"});
                    createOrUpdateParams.RoleDefinition.Properties.AssignableScopes = new List<string> { resourceGroupScope };
                    createOrUpdateParams.RoleDefinition.Properties.RoleName = "NewRoleName_" + newRoleId.ToString();

                    roleDefinition = client.RoleDefinitions.CreateOrUpdate(newRoleId, resourceGroupScope, createOrUpdateParams);
                    Assert.NotNull(roleDefinition);

                }
                finally
                {
                    var deleteResult = client.RoleDefinitions.Delete(roleDefinitionId, currentSubscriptionId);
                    Assert.NotNull(deleteResult);

                    deleteResult = client.RoleDefinitions.Delete(newRoleId, resourceGroupScope);
                    Assert.NotNull(deleteResult);
                }

                
                TestUtilities.Wait(1000 * 15);

                // Negative test - create a roledefinition with same name (but different id) as an already existing custom role
                try
                {
                    client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, currentSubscriptionId, createOrUpdateParams);
                    var roleDefinition2Id = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition3");
                    client.RoleDefinitions.CreateOrUpdate(roleDefinition2Id, currentSubscriptionId, createOrUpdateParams);
                }
                catch (CloudException ce)
                {
                    Assert.Equal("RoleDefinitionWithSameNameExists", ce.Error.Code);
                    Assert.Equal(HttpStatusCode.Conflict, ce.Response.StatusCode);
                }
                finally
                {
                    var deleteResult = client.RoleDefinitions.Delete(roleDefinitionId, currentSubscriptionId);
                    Assert.NotNull(deleteResult);
                }

                var scope = "subscriptions/" + client.Credentials.SubscriptionId;
                // Negative test - create a roledefinition with same id as a built-in role
                try
                {
                    var allRoleDefinitions = client.RoleDefinitions.List(scope, null);
                    Assert.NotNull(allRoleDefinitions);
                    Assert.NotNull(allRoleDefinitions.RoleDefinitions);
                    RoleDefinition builtInRole = allRoleDefinitions.RoleDefinitions.First(x => x.Properties.Type == "BuiltInRole");

                    createOrUpdateParams.RoleDefinition.Properties.RoleName = "NewRoleName_" + builtInRole.Name.ToString();
                    client.RoleDefinitions.CreateOrUpdate(builtInRole.Name, currentSubscriptionId, createOrUpdateParams);
                }
                catch (CloudException ce)
                {
                    Assert.Equal("RoleDefinitionExists", ce.Error.Code);
                    Assert.Equal(HttpStatusCode.Conflict, ce.Response.StatusCode);
                }
              
                // Negative test - create a roledefinition with type=BuiltInRole
                createOrUpdateParams.RoleDefinition.Properties.Type = "BuiltInRole";

                try
                {
                    client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, currentSubscriptionId, createOrUpdateParams);
                }
                catch(CloudException ce)
                {
                    Assert.Equal("InvalidRoleDefinitionType", ce.Error.Code);
                    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                }
                
                // Negative Test - create a custom role with empty role name
                // reset the role type
                createOrUpdateParams.RoleDefinition.Properties.Type = null;
                createOrUpdateParams.RoleDefinition.Properties.RoleName = string.Empty;

                try
                {
                    client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, currentSubscriptionId, createOrUpdateParams);
                }
                catch (CloudException ce)
                {
                    Assert.Equal("RoleDefinitionNameNullOrEmpty", ce.Error.Code);
                    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                }

                // Negative Test - create a custom role with empty assignable scopes
                // reset the role name
                createOrUpdateParams.RoleDefinition.Properties.RoleName = "NewRoleName_" + roleDefinitionId.ToString();
                createOrUpdateParams.RoleDefinition.Properties.AssignableScopes = new List<string>();

                try
                {
                    client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, currentSubscriptionId, createOrUpdateParams);
                }
                catch (CloudException ce)
                {
                    Assert.Equal("MissingAssignableScopes", ce.Error.Code);
                    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                }

                // Negative Test - create a custom role with invalid value for assignable scopes
                createOrUpdateParams.RoleDefinition.Properties.AssignableScopes.Add("Invalid_Scope");

                try
                {
                    client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, currentSubscriptionId, createOrUpdateParams);
                }
                catch (CloudException ce)
                {
                    Assert.Equal("LinkedInvalidPropertyId", ce.Error.Code);
                    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                }

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

                TestUtilities.EndTest();
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
