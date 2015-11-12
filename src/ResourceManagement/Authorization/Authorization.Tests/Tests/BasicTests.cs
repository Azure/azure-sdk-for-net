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
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;

namespace Authorization.Tests
{
    public class BasicTests : TestBase, IClassFixture<TestExecutionContext>
    {
        private TestExecutionContext testContext;

        public void SetFixture(TestExecutionContext context)
        {
            testContext = context;
        }

        [Fact]
        public void RoleAssignmentByIdTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                MockContext.Start();

                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);
                
                var principalId = testContext.Users.ElementAt(4);

                var roleDefinition = client.RoleDefinitions.List().ElementAt(1);
                var newRoleAssignment = new RoleAssignmentProperties()
                {
                    RoleDefinitionId = roleDefinition.Id,
                    PrincipalId = principalId.ToString()
                };

                var scope = "subscriptions/" + client.SubscriptionId;
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
                MockContext.Start();

                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName");

                var scope = "subscriptions/" + client.SubscriptionId;
                var principalId = testContext.Users.ElementAt(5);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var roleDefinition = client.RoleDefinitions.List()
                    .Where(r => r.Properties.Type == "BuiltInRole").Last();
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
                MockContext.Start();

                var client = testContext.GetAuthorizationManagementClient(context);

                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName");

                var scope = "subscriptions/" + client.SubscriptionId;
                var principalId = testContext.Users.ElementAt(3);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var roleDefinition = client.RoleDefinitions.List().Last();
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
                MockContext.Start();
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var allRoleAssignments = client.RoleAssignments.List(null);

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
            var principalId = testContext.Users.ElementAt(1);
           
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                MockContext.Start();
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.SubscriptionId;
                var roleDefinition = client.RoleDefinitions.List().First();

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

                var allRoleAssignments = client.RoleAssignments.List(null);

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


        [Fact]
        public void RoleAssignmentListForScopeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                MockContext.Start();
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var allRoleAssignments = client.RoleAssignments.ListForScope(
                    "subscriptions/" + client.SubscriptionId
                    //,new ListAssignmentsFilterParameters
                    //{
                    //    AtScope = true
                    //}
                    );


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
        public void RoleDefinitionsListGetTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                MockContext.Start();
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var allRoleDefinitions = client.RoleDefinitions.List();
                
                Assert.NotNull(allRoleDefinitions);

                foreach (var roleDefinition in allRoleDefinitions)
                {
                    var singleRole = client.RoleDefinitions.Get(roleDefinition.Name);
                    
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

        [Fact]
        public void RoleDefinitionsByIdTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                MockContext.Start();
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var allRoleDefinitions = client.RoleDefinitions.List();

                Assert.NotNull(allRoleDefinitions);

                foreach (var roleDefinition in allRoleDefinitions)
                {
                    var singleRole = client.RoleDefinitions.Get(roleDefinition.Name);
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
            const string RoleDefIdPrefix = "/providers/Microsoft.Authorization/roleDefinitions/";
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                MockContext.Start();
                var client = testContext.GetAuthorizationManagementClient(context);

                RoleDefinitionCreateOrUpdateParameters createOrUpdateParams;
                var roleDefinitionId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition");
                string currentSubscriptionId = "/subscriptions/" + client.SubscriptionId;
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

                    var roleDefinition = client.RoleDefinitions.CreateOrUpdate(
                        currentSubscriptionId, 
                        roleDefinitionId.ToString(), 
                        createOrUpdateParams.RoleDefinition);

                    // Update role name, permissions for the custom role
                    createOrUpdateParams.RoleDefinition.Properties.RoleName = "UpdatedRoleName_" + roleDefinitionId.ToString();
                    createOrUpdateParams.RoleDefinition.Properties.Permissions.Single().Actions.Add("Microsoft.Support/*/read");

                    var updatedRoleDefinition = client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams.RoleDefinition);
                   
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
                    createOrUpdateParams.RoleDefinition.Properties.RoleName = null;

                    try
                    {
                        client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams.RoleDefinition);
                    }
                    catch (CloudException ce)
                    {
                        Assert.Equal("CreateRoleDefinitionFailed", ce.ToString());
                        Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                    }
                }
                finally
                {
                    var deleteResult = client.RoleDefinitions.Delete(currentSubscriptionId, fullRoleId);
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
                MockContext.Start();
                var client = testContext.GetAuthorizationManagementClient(context);

                RoleDefinitionCreateOrUpdateParameters createOrUpdateParams;
                var roleDefinitionId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition1");
                string currentSubscriptionId = "/subscriptions/" + client.SubscriptionId;
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

                    var roleDefinition = client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams.RoleDefinition);

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

                }
                finally
                {
                    var deleteResult = client.RoleDefinitions.Delete(currentSubscriptionId, fullRoleId);
                    Assert.NotNull(deleteResult);
                }

                // Negative test - create a roledefinition with same name (but different id) as an already existing custom role
                try
                {
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams.RoleDefinition);
                    var roleDefinition2Id = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition2");
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams.RoleDefinition);
                }
                catch (CloudException ce)
                {
                    Assert.Equal("CreateRoleDefinitionFailed", ce.ToString());
                    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                }
                finally
                {
                    var deleteResult = client.RoleDefinitions.Delete(currentSubscriptionId, fullRoleId);
                    Assert.NotNull(deleteResult);
                }

                // Negative test - create a roledefinition with same id as a built-in role
                try
                {
                    var allRoleDefinitions = client.RoleDefinitions.List();
                    Assert.NotNull(allRoleDefinitions);
                    RoleDefinition builtInRole = allRoleDefinitions.First(x => x.Properties.Type == "BuiltInRole");

                    createOrUpdateParams.RoleDefinition.Properties.RoleName = "NewRoleName_" + builtInRole.Name.ToString();
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        builtInRole.Name, createOrUpdateParams.RoleDefinition);
                }
                catch (CloudException ce)
                {
                    Assert.Equal("CreateRoleDefinitionFailed", ce.ToString());
                    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                }
              
                // Negative test - create a roledefinition with type=BuiltInRole
                createOrUpdateParams.RoleDefinition.Properties.Type = "BuiltInRole";

                try
                {
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams.RoleDefinition);
                }
                catch(CloudException ce)
                {
                    Assert.Equal("InvalidRoleDefinitionType", ce.ToString());
                    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                }
                
                // Negative Test - create a custom role with empty role name
                // reset the role type
                createOrUpdateParams.RoleDefinition.Properties.Type = null;
                createOrUpdateParams.RoleDefinition.Properties.RoleName = string.Empty;

                try
                {
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams.RoleDefinition);
                }
                catch (CloudException ce)
                {
                    Assert.Equal("CreateRoleDefinitionFailed", ce.ToString());
                    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                }

                // Negative Test - create a custom role with empty assignable scopes
                // reset the role name
                createOrUpdateParams.RoleDefinition.Properties.RoleName = "NewRoleName_" + roleDefinitionId.ToString();
                createOrUpdateParams.RoleDefinition.Properties.AssignableScopes = new List<string>();

                try
                {
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams.RoleDefinition);
                }
                catch (CloudException ce)
                {
                    Assert.Equal("MissingAssignableScopes", ce.ToString());
                    Assert.Equal(HttpStatusCode.BadRequest, ce.Response.StatusCode);
                }

                // Negative Test - create a custom role with invalid value for assignable scopes
                createOrUpdateParams.RoleDefinition.Properties.AssignableScopes.Add("Invalid_Scope");

                try
                {
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams.RoleDefinition);
                }
                catch (CloudException ce)
                {
                    Assert.Equal("LinkedInvalidPropertyId", ce.ToString());
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
