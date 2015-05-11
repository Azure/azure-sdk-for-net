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
                    Assert.NotNull(singleRole.StatusCode);
                    Assert.NotNull(singleRole.RoleDefinition);
                    Assert.NotNull(singleRole.RoleDefinition.Id);
                    Assert.NotNull(singleRole.RoleDefinition.Name);
                    Assert.NotNull(singleRole.RoleDefinition.Type);
                    Assert.NotNull(singleRole.RoleDefinition.Properties);
                    Assert.NotNull(singleRole.RoleDefinition.Properties.Description);
                    Assert.NotNull(singleRole.RoleDefinition.Properties.RoleName);
                    Assert.NotNull(singleRole.RoleDefinition.Properties.Scope);
                    Assert.NotNull(singleRole.RoleDefinition.Properties.Type);
                    Assert.NotNull(singleRole.RoleDefinition.Properties.Permissions);
                    // The service does not return these as AssignableScopes - when it does this test will need to be updated along with other tests in this file.
                    Assert.Empty(singleRole.RoleDefinition.Properties.AssignableScopes);

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

        [Fact(Skip = "Not yet implemented")]
        public void RoleDefinitionUpdateTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                var roleDefinitionId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition");

                // Create a role definition
                var roleDefinition = client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, new RoleDefinitionCreateOrUpdateParameters
                {
                    RoleDefinition =
                    {
                        Id = roleDefinitionId.ToString(),
                        Properties = new RoleDefinitionProperties()
                        {
                            RoleName = "NewRoleName"
                        }
                    }
                });

                var updatedRoleDefinition = client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, new RoleDefinitionCreateOrUpdateParameters
                {
                    RoleDefinition =
                    {
                        Id = roleDefinitionId.ToString(),
                        Properties = new RoleDefinitionProperties()
                        {
                            RoleName = "NewRoleName",
                            Permissions = new List<Permission>()
                            {
                                new Permission()
                                {
                                    Actions = new List<string>{ "Microsoft.Authorization/*/Read" }
                                }
                            }
                        }
                    }
                });

                // Compare the updatedRoleDefinition with roleDefinition.
                // Id should be same.
                // Role should be different.
                // Permissions should be different.
                // Delete the role definition.

                // Negative test where the role name and actions are not provided.
                var roleDefinition2Id = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition");

                Assert.Throws<Hyak.Common.CloudException>(() => client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, new RoleDefinitionCreateOrUpdateParameters
                    {
                        RoleDefinition =
                        {
                            Id = roleDefinitionId.ToString(),
                            Properties = new RoleDefinitionProperties()
                        }
                    }));
                TestUtilities.EndTest();

                Assert.Throws<Hyak.Common.CloudException>(() => client.RoleDefinitions.Delete(roleDefinition2Id.ToString()));
            }
        }

        [Fact(Skip = "Not yet implemented")]
        public void RoleDefinitionCreateTests()
        {
            const string RoleDefIdPrefix = "/providers/Microsoft.Authorization/roleDefinitions/";
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = testContext.GetAuthorizationManagementClient();

                var roleDefinitionId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition");

                // Create a custom role definition
                var roleDefinition = client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, new RoleDefinitionCreateOrUpdateParameters
                {
                    RoleDefinition =
                    {
                        Id = string.Concat(RoleDefIdPrefix, roleDefinitionId.ToString("D")),
                        Name = roleDefinitionId,
                        Properties = new RoleDefinitionProperties()
                        {
                            RoleName = "NewRoleName",
                            Permissions = new List<Permission>()
                            {
                                new Permission()
                                {
                                    Actions = new List<string>{ "Microsoft.Authorization/*/Read" }
                                }
                            },
                            AssignableScopes = new List<string>() { "Scope1", "Scope2" },
                            Type = "CustomRole"
                        }
                    }
                });
                             
                // TODO: Validate the roleDefinition properties.
                                
                // Negative test - create a roledefinition with type=BuiltInRole
                var roleDefinition2Id = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition");

                Assert.Throws<Hyak.Common.CloudException>(() => client.RoleDefinitions.CreateOrUpdate(roleDefinition2Id, new RoleDefinitionCreateOrUpdateParameters
                {
                    RoleDefinition =
                    {
                        Id = string.Concat(RoleDefIdPrefix, roleDefinition2Id.ToString("D")),
                        Name = roleDefinition2Id,
                        Properties = new RoleDefinitionProperties()
                        {
                            RoleName = "NewRoleName2",
                            Permissions = new List<Permission>()
                            {
                                new Permission()
                                {
                                    Actions = new List<string>{ "Microsoft.Authorization/*/Read" }
                                }
                            },
                            AssignableScopes = new List<string>() { "Scope1", "Scope2" },
                            Type = "BuiltInRole"
                        }
                    }
                }));

                // Negative Test - create a custom role with empty role id
                Assert.Throws<Hyak.Common.CloudException>(() => client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, new RoleDefinitionCreateOrUpdateParameters
                {
                    RoleDefinition =
                    {
                        Id = string.Empty,
                        Name = Guid.Empty,
                        Properties = new RoleDefinitionProperties()
                        {
                            RoleName = "NewRoleName2",
                            Permissions = new List<Permission>()
                            {
                                new Permission()
                                {
                                    Actions = new List<string>{ "Microsoft.Authorization/*/Read" }
                                }
                            },
                            AssignableScopes = new List<string>() { "Scope1", "Scope2" },
                            Type = "CustomRole"
                        }
                    }
                }));

                // Negative Test - create a custom role with Id's last segment not a GUID 
                // (unsure if the service will throw or accept - but would be good to know and can be removed later if not relevant)
                Assert.Throws<Hyak.Common.CloudException>(() => client.RoleDefinitions.CreateOrUpdate(roleDefinitionId, new RoleDefinitionCreateOrUpdateParameters
                {
                    RoleDefinition =
                    {
                        Id = string.Concat(RoleDefIdPrefix, "NON_GUID_VALUE"),
                        Name = Guid.NewGuid(),
                        Properties = new RoleDefinitionProperties()
                        {
                            RoleName = "NewRoleName2",
                            Permissions = new List<Permission>()
                            {
                                new Permission()
                                {
                                    Actions = new List<string>{ "Microsoft.Authorization/*/Read" }
                                }
                            },
                            AssignableScopes = new List<string>() { "Scope1", "Scope2" },
                            Type = "CustomRole"
                        }
                    }
                }));
                
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
