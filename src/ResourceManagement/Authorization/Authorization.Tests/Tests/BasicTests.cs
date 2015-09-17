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
using System.Net.Security;
using Xunit;
using System.Collections.Generic;
using Hyak.Common;

namespace Authorization.Tests
{
    public class BasicTests : TestBase, IUseFixture<TestExecutionContext>
    {
        private TestExecutionContext testContext;

        public void SetFixture(TestExecutionContext context)
        {
            testContext = context;
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

                var roleDefinition = client.RoleDefinitions.List().RoleDefinitions.ElementAt(1);
                var newRoleAssignment = new RoleAssignmentCreateParameters()
                {
                    Properties = new RoleAssignmentProperties()
                    {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = principalId
                    }
                };
                
                var scope = "subscriptions/" + client.Credentials.SubscriptionId;
                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName");

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

                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName");

                var scope = "subscriptions/" + client.Credentials.SubscriptionId;
                var principalId = testContext.Users.ElementAt(5);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var roleDefinition = client.RoleDefinitions.List().RoleDefinitions.Where(r => r.Properties.Type == "BuiltInRole").Last();
                var newRoleAssignment = new RoleAssignmentCreateParameters()
                {
                    Properties = new RoleAssignmentProperties()
                    {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = principalId
                    }
                };

                var createResult = client.RoleAssignments.Create(scope, assignmentName, newRoleAssignment);
                Assert.NotNull(createResult);
                
                var allRoleAssignments = client.RoleAssignments.List(null);

                Assert.NotNull(allRoleAssignments);
                Assert.NotNull(allRoleAssignments.RoleAssignments);

                foreach (var assignment in allRoleAssignments.RoleAssignments)
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

                var deleteResult = client.RoleAssignments.Delete(scope, assignmentName);
                Assert.NotNull(deleteResult);
            }
        }

        [Fact]
        public void RoleAssignmentsCreateDeleteTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                var client = testContext.GetAuthorizationManagementClient();

                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName");

                var scope = "subscriptions/" + client.Credentials.SubscriptionId;
                var principalId = testContext.Users.ElementAt(3);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var roleDefinition = client.RoleDefinitions.List().RoleDefinitions.Last();
                var newRoleAssignment = new RoleAssignmentCreateParameters()
                {
                    Properties = new RoleAssignmentProperties()
                    {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = principalId
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
            var principalId = testContext.Users.ElementAt(1);
           
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.Credentials.SubscriptionId;
                var roleDefinition = client.RoleDefinitions.List().RoleDefinitions.First();

                for(int i=0; i<testContext.Users.Count; i++)
                {
                    var pId = testContext.Users.ElementAt(i);
                    var newRoleAssignment = new RoleAssignmentCreateParameters()
                    {
                        Properties = new RoleAssignmentProperties()
                        {
                            RoleDefinitionId = roleDefinition.Id,
                            PrincipalId = pId
                        }
                    };
                    var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName_" + i);
                    var createResult = client.RoleAssignments.Create(scope, assignmentName, newRoleAssignment);
                }

                var allRoleAssignments = client.RoleAssignments.List(new ListAssignmentsFilterParameters
                    {
                        PrincipalId = principalId
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

                    Assert.Equal(principalId, assignment.Properties.PrincipalId);
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
                    "subscriptions/" + client.Credentials.SubscriptionId,
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

                var scope = "subscriptions/" + client.Credentials.SubscriptionId;
                var roleDefinition = client.RoleDefinitions.List().RoleDefinitions.First();
                
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
                        PrincipalId = Guid.Parse(groupId)
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
                        PrincipalId = userId
                    }
                };
                
                assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName_User");
                var assignmentToUser = client.RoleAssignments.Create(scope, assignmentName, newRoleAssignmentToUserParams);
            
                // List role assignments with AssignedTo filter = user id
                var allRoleAssignments = client.RoleAssignments.List(new ListAssignmentsFilterParameters
                {
                    AssignedToPrincipalId = userId
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

                var allRoleDefinitions = client.RoleDefinitions.List();
                
                Assert.NotNull(allRoleDefinitions);
                Assert.NotNull(allRoleDefinitions.RoleDefinitions);

                foreach (var roleDefinition in allRoleDefinitions.RoleDefinitions)
                {
                    var singleRole = client.RoleDefinitions.Get(roleDefinition.Name);
                    
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
        public void RoleDefinitionsByIdTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var allRoleDefinitions = client.RoleDefinitions.List();

                Assert.NotNull(allRoleDefinitions);
                Assert.NotNull(allRoleDefinitions.RoleDefinitions);

                foreach (var roleDefinition in allRoleDefinitions.RoleDefinitions)
                {
                    var singleRole = client.RoleDefinitions.Get(roleDefinition.Name);
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
            const string RoleDefIdPrefix = "/providers/Microsoft.Authorization/roleDefinitions/";
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                RoleDefinitionCreateOrUpdateParameters createOrUpdateParams;
                var roleDefinitionId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition");
                string currentSubscriptionId = "/subscriptions/" + client.Credentials.SubscriptionId;
                string fullRoleId = currentSubscriptionId + RoleDefIdPrefix + roleDefinitionId;

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

                    var roleDefinition = client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, createOrUpdateParams);

                    // Update role name, permissions for the custom role
                    createOrUpdateParams.RoleDefinition.Properties.RoleName = "UpdatedRoleName_" + roleDefinitionId.ToString();
                    createOrUpdateParams.RoleDefinition.Properties.Permissions.Single().Actions.Add("Microsoft.Support/*/read");

                    var updatedRoleDefinition = client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, createOrUpdateParams);
                   
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
                        client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, createOrUpdateParams);
                    }
                    catch (CloudException ce)
                    {
                        Assert.Equal("RoleDefinitionNameNullOrEmpty", ce.Error.Code);
                        Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                    }
                }
                finally
                {
                    var deleteResult = client.RoleDefinitions.Delete(fullRoleId);
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

                    var roleDefinition = client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, createOrUpdateParams);

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

                }
                finally
                {
                    var deleteResult = client.RoleDefinitions.Delete(fullRoleId);
                    Assert.NotNull(deleteResult);
                }

                
                TestUtilities.Wait(1000 * 15);

                // Negative test - create a roledefinition with same name (but different id) as an already existing custom role
                try
                {
                    client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, createOrUpdateParams);
                    var roleDefinition2Id = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition2");
                    client.RoleDefinitions.CreateOrUpdate(roleDefinition2Id, createOrUpdateParams);
                }
                catch (CloudException ce)
                {
                    Assert.Equal("RoleDefinitionWithSameNameExists", ce.Error.Code);
                    Assert.Equal(HttpStatusCode.Conflict, ce.Response.StatusCode);
                }
                finally
                {
                    var deleteResult = client.RoleDefinitions.Delete(fullRoleId);
                    Assert.NotNull(deleteResult);
                }

                // Negative test - create a roledefinition with same id as a built-in role
                try
                {
                    var allRoleDefinitions = client.RoleDefinitions.List();
                    Assert.NotNull(allRoleDefinitions);
                    Assert.NotNull(allRoleDefinitions.RoleDefinitions);
                    RoleDefinition builtInRole = allRoleDefinitions.RoleDefinitions.First(x => x.Properties.Type == "BuiltInRole");

                    createOrUpdateParams.RoleDefinition.Properties.RoleName = "NewRoleName_" + builtInRole.Name.ToString();
                    client.RoleDefinitions.CreateOrUpdate(builtInRole.Name, createOrUpdateParams);
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
                    client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, createOrUpdateParams);
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
                    client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, createOrUpdateParams);
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
                    client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, createOrUpdateParams);
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
                    client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, createOrUpdateParams);
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
