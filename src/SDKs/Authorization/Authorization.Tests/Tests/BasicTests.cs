// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
using System.Reflection;
using System.IO;
using Microsoft.Rest;

namespace Authorization.Tests
{
    public class BasicTests : TestBase, IClassFixture<TestExecutionContext>
    {
        public const string ResourceGroup = "resourcegroups/AzureAuthzSDK";
        private readonly ITestOutputHelper _output;
        private TestExecutionContext testContext;
        private const int RoleAssignmentPageSize = 20;
        private const string RESOURCE_TEST_LOCATION = "westus";

        public BasicTests(TestExecutionContext context, ITestOutputHelper output)
        {
            testContext = context;
            _output = output;
        }

        //[Fact(Skip = "Need to re-record due to VS2017 nuget upgrade")]
        [Fact]
        public void ClassicAdministratorListTests()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);
                
                var allClassicAdmins = client.ClassicAdministrators.List();

                Assert.NotNull(allClassicAdmins);

                foreach (var classicAdmin in allClassicAdmins)
                {
                    Assert.NotNull(classicAdmin);
                    Assert.NotNull(classicAdmin.Id);
                    Assert.Contains("/providers/Microsoft.Authorization/classicAdministrators/", classicAdmin.Id);
                    Assert.Contains("/subscriptions/" + client.SubscriptionId, classicAdmin.Id);
                    Assert.NotNull(classicAdmin.Name);
                    Assert.NotNull(classicAdmin.Type);
                    Assert.Equal("Microsoft.Authorization/classicAdministrators", classicAdmin.Type);
                    Assert.NotNull(classicAdmin.EmailAddress);
                    Assert.NotNull(classicAdmin.Role);
                }
            }
        }

        //[Fact(Skip = "Need to re-record due to VS2017 nuget upgrade")]
        [Fact]
        public void RoleAssignmentByIdTests()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var principalId = new Guid(testContext.Users.ElementAt(4).ObjectId);

                var scope = "subscriptions/" + client.SubscriptionId + "/" + ResourceGroup;
                var roleDefinition = client.RoleDefinitions.List(scope, null).ElementAt(1);
                //RA test with cendelegate set to true
                var newRoleAssignment = new RoleAssignmentCreateParameters()
                {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = principalId.ToString(),
                        CanDelegate = true
                };

                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentNameTestById");

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
                Assert.Equal(createResult.CanDelegate, getResult.CanDelegate);


                //Delete
                var deleteResult = client.RoleAssignments.DeleteById(assignmentId);
                Assert.NotNull(deleteResult);

                var allRoleAssignments = client.RoleAssignments.List(null);
                var createdAssignment = allRoleAssignments.FirstOrDefault(
                                            a => a.Name == assignmentName.ToString());

                Assert.Null(createdAssignment);

                //RA test with cendelegate set to false
                newRoleAssignment = new RoleAssignmentCreateParameters()
                {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = principalId.ToString(),
                        CanDelegate = false
                };

                assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentNameTestByIdNew");

                assignmentId = string.Format(
                    "{0}/providers/Microsoft.Authorization/roleAssignments/{1}",
                    scope,
                    assignmentName);

                // Create
                createResult = client.RoleAssignments.CreateById(assignmentId, newRoleAssignment);
                Assert.NotNull(createResult);
                Assert.NotNull(createResult.Id);
                Assert.NotNull(createResult.Name);
                Assert.Equal(createResult.Name, assignmentName.ToString());

                // Get
                getResult = client.RoleAssignments.GetById(assignmentId);
                Assert.NotNull(getResult);
                Assert.Equal(createResult.Id, getResult.Id);
                Assert.Equal(createResult.Name, getResult.Name);
                Assert.Equal(createResult.CanDelegate, getResult.CanDelegate);


                //Delete
                deleteResult = client.RoleAssignments.DeleteById(assignmentId);
                Assert.NotNull(deleteResult);

                allRoleAssignments = client.RoleAssignments.List(null);
                createdAssignment = allRoleAssignments.FirstOrDefault(
                                            a => a.Name == assignmentName.ToString());

                Assert.Null(createdAssignment);
            }
        }

        //[Fact(Skip = "Need to re-record due to VS2017 nuget upgrade")]
        [Fact]
        public void RoleAssignmentsListGetTests()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentNameTestListGet");

                var scope = "subscriptions/" + client.SubscriptionId + "/" + ResourceGroup;
                var principalId = new Guid(testContext.Users.ElementAt(5).ObjectId);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var roleDefinition = client.RoleDefinitions.List(scope, null).Where(r => r.RoleType == "BuiltInRole").Last();
                var newRoleAssignment = new RoleAssignmentCreateParameters()
                {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = principalId.ToString()
                };

                var createResult = client.RoleAssignments.Create(scope, assignmentName.ToString(), newRoleAssignment);
                Assert.NotNull(createResult);

                var allRoleAssignments = client.RoleAssignments.List( new ODataQuery<RoleAssignmentFilter>(f=>f.AtScope()));

                Assert.NotNull(allRoleAssignments);

                foreach (var assignment in allRoleAssignments)
                {
                    if (assignment.Scope.Contains(ResourceGroup))
                    {
                        var singleAssignment = client.RoleAssignments.Get(assignment.Scope+"/", assignment.Name);

                        Assert.NotNull(singleAssignment);
                        Assert.NotNull(singleAssignment.Id);
                        Assert.NotNull(singleAssignment.Name);
                        Assert.NotNull(singleAssignment.Type);
                        Assert.NotNull(singleAssignment.PrincipalId);
                        Assert.NotNull(singleAssignment.RoleDefinitionId);
                        Assert.NotNull(singleAssignment.Scope);
                    }
                }

                var deleteResult = client.RoleAssignments.Delete(scope, assignmentName.ToString());
                Assert.NotNull(deleteResult);
            }
        }

        //[Fact(Skip = "Need to re-record due to VS2017 nuget upgrade")]
        [Fact]
        public void RoleAssignmentsCreateDeleteTests()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentNameCreateDeleteTest");

                var scope = "subscriptions/" + client.SubscriptionId + "/" + ResourceGroup; ;
                var principalId = new Guid(testContext.Users.ElementAt(3).ObjectId);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var roleDefinition = client.RoleDefinitions.List(scope).Last();
                var newRoleAssignment = new RoleAssignmentCreateParameters()
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

        //[Fact(Skip = "Need to re-record due to VS2017 nuget upgrade")]
        [Fact]
        public void RoleAssignmentAtScopeAndAboveTest()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
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
                    Assert.NotNull(assignment.PrincipalId);
                    Assert.NotNull(assignment.RoleDefinitionId);
                    Assert.NotNull(assignment.Scope);
                }
            }
        }

        //[Fact(Skip = "Need to re-record due to VS2017 nuget upgrade")]
        [Fact]
        public void RoleAssignmentListByFilterTest()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                // Read/write the PrincipalId from Testcontext to enable Playback mode test execution
                var principalId = GetValueFromTestContext(() => new Guid(testContext.Users.ElementAt(1).ObjectId), Guid.Parse, "PrincipalId").ToString();

                var scope = "subscriptions/" + client.SubscriptionId + "/" + ResourceGroup;
                var roleDefinition = client.RoleDefinitions.List(scope).First();
                Assert.NotNull(testContext.Users);
                Assert.True(testContext.Users.Count != 0);
                var newRoleAssignment = new RoleAssignmentCreateParameters()
                {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = principalId.ToString(),
                        CanDelegate = false
                };
                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName_FalseCanDelegate");
                var createResult = client.RoleAssignments.Create(scope, assignmentName.ToString(), newRoleAssignment);
                var allRoleAssignments = client.RoleAssignments
                    .List(new ODataQuery<RoleAssignmentFilter>(f => f.PrincipalId == principalId));

                Assert.NotNull(allRoleAssignments);
                Assert.True(allRoleAssignments.Count() == 1);
                RoleAssignment assignment = allRoleAssignments.ElementAt(0);
                Assert.NotNull(assignment);
                Assert.NotNull(assignment.Id);
                Assert.NotNull(assignment.Name);
                Assert.NotNull(assignment.Type);
                Assert.NotNull(assignment.PrincipalId);
                Assert.NotNull(assignment.RoleDefinitionId);
                Assert.NotNull(assignment.Scope);
                Assert.Equal(principalId.ToString(), assignment.PrincipalId);
                Assert.False(assignment.CanDelegate);

                //delete the RA
                client.RoleAssignments.Delete(scope, assignmentName.ToString());

                newRoleAssignment = new RoleAssignmentCreateParameters()
                {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = principalId.ToString(),
                        CanDelegate = true
                };
                assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName_TrueCanDelegate");
                createResult = client.RoleAssignments.Create(scope, assignmentName.ToString(), newRoleAssignment);

                allRoleAssignments = client.RoleAssignments
                    .List(new ODataQuery<RoleAssignmentFilter>(f => f.PrincipalId == principalId));

                Assert.NotNull(allRoleAssignments);
                Assert.True(allRoleAssignments.Count() == 1);
                assignment = allRoleAssignments.ElementAt(0);
                Assert.NotNull(assignment);
                Assert.NotNull(assignment.Id);
                Assert.NotNull(assignment.Name);
                Assert.NotNull(assignment.Type);
                Assert.NotNull(assignment.PrincipalId);
                Assert.NotNull(assignment.RoleDefinitionId);
                Assert.NotNull(assignment.Scope);
                Assert.Equal(principalId.ToString(), assignment.PrincipalId);
                Assert.True(assignment.CanDelegate);

            }
        }

        [Fact(Skip = "PAS Service Issue - Paging not enabled")]
        public void RoleAssignmentPagingTest()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.SubscriptionId + "/" + ResourceGroup;
                var allBuiltInRoles = client.RoleDefinitions.List(scope).Where(r => r.Type.Equals("BuiltInRole", StringComparison.OrdinalIgnoreCase));
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
                                RoleDefinitionId = roleDefinition.Id,
                                PrincipalId = principalId.ToString()
                        };
                        var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName_" + i);
                        RoleAssignment createResult = null;
                        try
                        {
                            createResult = client.RoleAssignments.Create(
                                scope,
                                assignmentName.ToString(),
                                newRoleAssignment);
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
                    Assert.NotEmpty(nextPage);

                    foreach (var roleAssignment in nextPage)
                    {
                        Assert.NotNull(roleAssignment);
                        Assert.NotNull(roleAssignment.Id);
                        Assert.NotNull(roleAssignment.Name);
                        Assert.NotNull(roleAssignment.Type);
                        Assert.NotNull(roleAssignment.PrincipalId);
                        Assert.NotNull(roleAssignment.RoleDefinitionId);
                        Assert.NotNull(roleAssignment.Scope);
                    }
                }
                finally
                {
                    foreach (var createdAssignment in createdAssignments)
                    {
                        client.RoleAssignments.Delete(createdAssignment.Scope, createdAssignment.Name);
                    }
                }
            }
        }

        //[Fact(Skip = "Need to re-record due to VS2017 nuget upgrade")]
        [Fact]
        public void RoleAssignmentListForScopeTest()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var allRoleAssignments = client.RoleAssignments.ListForScope(
                    "subscriptions/" + client.SubscriptionId + "/" + ResourceGroup,
                    new ODataQuery<RoleAssignmentFilter>(f => f.AtScope()));


                Assert.NotNull(allRoleAssignments);

                foreach (var assignment in allRoleAssignments)
                {
                    Assert.NotNull(assignment);
                    Assert.NotNull(assignment.Id);
                    Assert.NotNull(assignment.Name);
                    Assert.NotNull(assignment.Type);
                    Assert.NotNull(assignment.PrincipalId);
                    Assert.NotNull(assignment.RoleDefinitionId);
                    Assert.NotNull(assignment.Scope);
                }
            }
        }

        [Fact]
        public void RoleAssignmentListWithAssignedToFilterTest()
        {
            string executingAssemblyPath = this.GetType().GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.SubscriptionId + "/" + ResourceGroup;
                var roleDefinition = client.RoleDefinitions.List(scope, null).Where(r => r.RoleType == "BuiltInRole").Last();

                // Get user and group and add the user to the group
                var userId = GetValueFromTestContext(() => new Guid(testContext.Users.ElementAt(0).ObjectId), Guid.Parse, "UserId").ToString();
                var groupId = GetValueFromTestContext(() => new Guid(testContext.Groups.ElementAt(0).ObjectId), Guid.Parse, "GroupId").ToString();

                // create assignment to group
                var newRoleAssignmentToGroupParams = new RoleAssignmentCreateParameters()
                {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = groupId
                };
                var assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName_GroupAssigned");
                var assignmentToGroup = client.RoleAssignments.Create(
                    scope,
                    assignmentName.ToString(),
                    newRoleAssignmentToGroupParams);

                // create assignment to user
                var newRoleAssignmentToUserParams = new RoleAssignmentCreateParameters()
                {
                        RoleDefinitionId = roleDefinition.Id,
                        PrincipalId = userId
                };

                assignmentName = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "AssignmentName_UserAssigned");
                var assignmentToUser = client.RoleAssignments.Create(scope,
                    assignmentName.ToString(),
                    newRoleAssignmentToUserParams);

                // List role assignments with AssignedTo filter = user id
                var allRoleAssignments = client.RoleAssignments
                    .List(new ODataQuery<RoleAssignmentFilter>(f => f.AssignedTo(userId)));

                Assert.NotNull(allRoleAssignments);
                Assert.True(allRoleAssignments.Count() >= 1);

                foreach (var assignment in allRoleAssignments)
                {
                    Assert.NotNull(assignment);
                    Assert.NotNull(assignment.Id);
                    Assert.NotNull(assignment.Name);
                    Assert.NotNull(assignment.Type);
                    Assert.NotNull(assignment.PrincipalId);
                    Assert.NotNull(assignment.RoleDefinitionId);
                    Assert.NotNull(assignment.Scope);
                }

                allRoleAssignments = client.RoleAssignments
                    .List(new ODataQuery<RoleAssignmentFilter>(f => f.AssignedTo(groupId)));

                Assert.NotNull(allRoleAssignments);
                Assert.True(allRoleAssignments.Count() >= 1);

                foreach (var assignment in allRoleAssignments)
                {
                    Assert.NotNull(assignment);
                    Assert.NotNull(assignment.Id);
                    Assert.NotNull(assignment.Name);
                    Assert.NotNull(assignment.Type);
                    Assert.NotNull(assignment.PrincipalId);
                    Assert.NotNull(assignment.RoleDefinitionId);
                    Assert.NotNull(assignment.Scope);
                }
                // Returned assignments contain assignment to group
                Assert.True(allRoleAssignments.Count(a => a.PrincipalId.ToString() == groupId) >= 1);
            }
        }

        [Fact]
        public void RoleDefinitionsListGetTests()
        {
            string executingAssemblyPath = this.GetType().GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.SubscriptionId + "/" + ResourceGroup;
                var allRoleDefinitions = client.RoleDefinitions.List(scope);

                Assert.NotNull(allRoleDefinitions);

                foreach (var roleDefinition in allRoleDefinitions)
                {
                    var singleRole = client.RoleDefinitions.Get(scope, roleDefinition.Name);

                    Assert.NotNull(singleRole);

                    if (singleRole.RoleType == "BuiltInRole")
                    {
                        Assert.NotNull(singleRole);
                        Assert.NotNull(singleRole.Id);
                        Assert.NotNull(singleRole.Name);
                        Assert.NotNull(singleRole.Type);
                        Assert.NotNull(singleRole.Description);
                        Assert.NotNull(singleRole.RoleName);
                        Assert.NotNull(singleRole.RoleType);
                        Assert.NotNull(singleRole.Permissions);

                        foreach (var assignableScope in singleRole.AssignableScopes)
                        {
                            Assert.True(!string.IsNullOrWhiteSpace(assignableScope));
                        }

                        foreach (var permission in singleRole.Permissions)
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

        //[Fact(Skip = "Need to re-record due to VS2017 nuget upgrade")]
        [Fact]
        public void RoleDefinitionsByIdTests()
        {
            string executingAssemblyPath = this.GetType().GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.SubscriptionId + "/" + ResourceGroup;
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
        public void RoleDefinitionsFilterTests()
        {
            string executingAssemblyPath = this.GetType().GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var scope = "subscriptions/" + client.SubscriptionId + "/" + ResourceGroup;
                var allRoleDefinitions = client.RoleDefinitions.List(scope ,new ODataQuery<RoleDefinitionFilter>(item=>item.Type == "BuiltInRole"));

                Assert.NotNull(allRoleDefinitions);

                foreach (var roleDefinition in allRoleDefinitions)
                {
                    Assert.NotNull(roleDefinition);
                    Assert.NotNull(roleDefinition.RoleType);
                    Assert.Equal("BuiltInRole", roleDefinition.RoleType);
                }
                allRoleDefinitions = client.RoleDefinitions.List(scope, new ODataQuery<RoleDefinitionFilter>(item => item.Type == "CustomRole"));

                Assert.NotNull(allRoleDefinitions);

                foreach (var roleDefinition in allRoleDefinitions)
                {
                    Assert.NotNull(roleDefinition);
                    Assert.NotNull(roleDefinition.RoleType);
                    Assert.Equal("CustomRole", roleDefinition.RoleType);
                }

                string roleName = allRoleDefinitions.Last().RoleName;
                allRoleDefinitions = client.RoleDefinitions.List(scope, new ODataQuery<RoleDefinitionFilter>(item => item.RoleName == roleName));

                Assert.NotNull(allRoleDefinitions);

                foreach (var roleDefinition in allRoleDefinitions)
                {
                    Assert.NotNull(roleDefinition);
                    Assert.NotNull(roleDefinition.RoleName);
                    Assert.Equal(roleDefinition.RoleName, roleName);
                }
            }
        }

        //[Fact(Skip = "After upgrade to vs2017, starts failing. Needs investigation")]
        [Fact]
        public void RoleDefinitionUpdateTests()
        {
            string executingAssemblyPath = this.GetType().GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                RoleDefinition createOrUpdateParams;
                var roleDefinitionId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition");
                string scope = "subscriptions/" + client.SubscriptionId + "/" + ResourceGroup;

                // Create a custom role definition
                try
                {
                    createOrUpdateParams = new RoleDefinition()
                    {
                        // Name = roleDefinitionId,
                            RoleName = "NewRoleName_" + roleDefinitionId.ToString(),
                            Description = "New Test Custom Role",
                            Permissions = new List<Permission>()
                                {
                                    new Permission()
                                    {
                                        Actions = new List<string>{ "Microsoft.Authorization/*/Read" }
                                    }
                                },
                            AssignableScopes = new List<string>() { scope },
                    };

                    var roleDefinition = client.RoleDefinitions.CreateOrUpdate(
                        scope,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams);

                    // Update role name, permissions for the custom role
                    createOrUpdateParams.RoleName = "UpdatedRoleName_" + roleDefinitionId.ToString();
                    createOrUpdateParams.Permissions.Single().Actions.Add("Microsoft.Support/*/read");

                    var updatedRoleDefinition = client.RoleDefinitions.CreateOrUpdate(scope,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams);

                    // Validate the updated roleDefinition properties.
                    Assert.NotNull(updatedRoleDefinition);
                    Assert.Equal(updatedRoleDefinition.Id, roleDefinition.Id);
                    Assert.Equal(updatedRoleDefinition.Name, roleDefinition.Name);
                    // Role name and permissions should be updated
                    Assert.Equal("UpdatedRoleName_" + roleDefinitionId.ToString(), updatedRoleDefinition.RoleName);
                    Assert.NotEmpty(updatedRoleDefinition.Permissions);
                    Assert.Equal("Microsoft.Authorization/*/Read", updatedRoleDefinition.Permissions.Single().Actions.First());
                    Assert.Equal("Microsoft.Support/*/read", updatedRoleDefinition.Permissions.Single().Actions.Last());
                    // Same assignable scopes
                    Assert.NotEmpty(updatedRoleDefinition.AssignableScopes);
                    Assert.Equal(scope.ToLower(), updatedRoleDefinition.AssignableScopes.Single().ToLower());

                    // Negative test: Update the role with an empty RoleName 
                    createOrUpdateParams.RoleName = null;

                    try
                    {
                        client.RoleDefinitions.CreateOrUpdate(scope,
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
                        scope,
                        roleDefinitionId.ToString());
                    Assert.NotNull(deleteResult);
                }
            }
        }

        [Fact]
        public void RoleDefinitionCreateTests()
        {
            string executingAssemblyPath = this.GetType().GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
            const string RoleDefIdPrefix = "/providers/Microsoft.Authorization/roleDefinitions/";
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                RoleDefinition createOrUpdateParams;
                var roleDefinitionId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition1");
                string currentSubscriptionId = "/subscriptions/" + client.SubscriptionId + "/" + ResourceGroup;
                string fullRoleId = "/subscriptions/" + client.SubscriptionId + RoleDefIdPrefix + roleDefinitionId;

                Guid newRoleId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition2");
                string resourceGroupScope = currentSubscriptionId;

                // create resource group,This works only if logged in using Username/Password method
                var resourceClient = PermissionsTests.GetResourceManagementClient(context);
                try
                {
                    resourceClient.ResourceGroups.CreateOrUpdate(
                        "AzureAuthzSDK1",
                        new ResourceGroup
                        { Location = "westus" });
                }
                catch
                { }

                // Create a custom role definition
                try
                {
                    createOrUpdateParams = new RoleDefinition()
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
                            AssignableScopes = new List<string>() { currentSubscriptionId }
                    };

                    var roleDefinition = client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams);

                    // Validate the roleDefinition properties.
                    Assert.NotNull(roleDefinition);
                    Assert.Equal(fullRoleId, roleDefinition.Id);
                    Assert.Equal(roleDefinitionId.ToString(), roleDefinition.Name);
                    Assert.Equal("CustomRole", roleDefinition.RoleType);
                    Assert.Equal("New Test Custom Role", roleDefinition.Description);
                    Assert.NotEmpty(roleDefinition.AssignableScopes);
                    Assert.Equal(currentSubscriptionId.ToLower(), roleDefinition.AssignableScopes.Single().ToLower());
                    Assert.NotEmpty(roleDefinition.Permissions);
                    Assert.Equal("Microsoft.Authorization/*/Read", roleDefinition.Permissions.Single().Actions.Single());

                    createOrUpdateParams.AssignableScopes = new List<string> { resourceGroupScope };
                    createOrUpdateParams.RoleName = "NewRoleName_" + newRoleId.ToString();

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
                    RoleDefinition builtInRole = allRoleDefinitions.First(x => x.RoleType == "BuiltInRole");

                    createOrUpdateParams.RoleName = "NewRoleName_" + builtInRole.Name.ToString();
                    client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        builtInRole.Name, createOrUpdateParams);
                }
                catch (CloudException ce)
                {
                    Assert.Equal(HttpStatusCode.Conflict, ce.Response.StatusCode);
                }

                // Negative test - create a roledefinition with type=BuiltInRole
                createOrUpdateParams.RoleType = "BuiltInRole";

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

                // Negative Test - create a custom role with empty role name
                // reset the role type
                createOrUpdateParams.RoleType = null;
                createOrUpdateParams.RoleName = string.Empty;

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
                createOrUpdateParams.RoleName = "NewRoleName_" + roleDefinitionId.ToString();
                createOrUpdateParams.AssignableScopes = new List<string>();

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
                createOrUpdateParams.AssignableScopes.Add("Invalid_Scope");

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

        [Fact]
        public void RoleDefinitionCreateWithDataActionTests()
        {
            string executingAssemblyPath = this.GetType().GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
            const string RoleDefIdPrefix = "/providers/Microsoft.Authorization/roleDefinitions/";
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                RoleDefinition createOrUpdateParams;
                var roleDefinitionId = GetValueFromTestContext(Guid.NewGuid, Guid.Parse, "RoleDefinition1");
                string currentSubscriptionId = "/subscriptions/" + client.SubscriptionId + "/" + ResourceGroup;
				
                string fullRoleId = "/subscriptions/" + client.SubscriptionId + RoleDefIdPrefix + roleDefinitionId;
                // Create a custom role definition
                try
                {
                    createOrUpdateParams = new RoleDefinition()
                    {
                        RoleName = "NewRoleName_" + roleDefinitionId.ToString(),
                        Description = "New Test Custom Role",
                        Permissions = new List<Permission>()
                                {
                                    new Permission()
                                    {
                                        DataActions = new List<string> { "Microsoft.Storage/storageAccounts/blobServices/containers/blobs/*" }
                                    }
                                },
                        AssignableScopes = new List<string>() { currentSubscriptionId }
                    };

                    var roleDefinition = client.RoleDefinitions.CreateOrUpdate(currentSubscriptionId,
                        roleDefinitionId.ToString(),
                        createOrUpdateParams);

                    // Validate the roleDefinition properties.
                    Assert.NotNull(roleDefinition);
                    Assert.Equal(fullRoleId, roleDefinition.Id);
                    Assert.Equal(roleDefinitionId.ToString(), roleDefinition.Name);
                    Assert.Equal("CustomRole", roleDefinition.RoleType);
                    Assert.Equal("New Test Custom Role", roleDefinition.Description);
                    Assert.NotEmpty(roleDefinition.AssignableScopes);
                    Assert.Equal(currentSubscriptionId.ToLower(), roleDefinition.AssignableScopes.Single().ToLower());
                    Assert.NotEmpty(roleDefinition.Permissions);
                    Assert.Equal("Microsoft.Storage/storageAccounts/blobServices/containers/blobs/*", roleDefinition.Permissions.Single().DataActions.Single());
                }
                finally
                {
                    var deleteResult = client.RoleDefinitions.Delete(currentSubscriptionId, roleDefinitionId.ToString());
                    Assert.NotNull(deleteResult);
                }
            }
        }

        [Fact]
        public void ProviderOperationsMetadataListGetTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);
                var allProviderOperationsMetadatas = client.ProviderOperationsMetadata.List();

                Assert.NotNull(allProviderOperationsMetadatas);

                foreach (var operationsMetadata in allProviderOperationsMetadatas)
                {
                    Assert.NotNull(operationsMetadata);
                    Assert.NotNull(operationsMetadata.Id);
                    Assert.NotNull(operationsMetadata.Name);
                    Assert.NotNull(operationsMetadata.Operations);
                    Assert.NotNull(operationsMetadata.ResourceTypes);
                    Assert.NotNull(operationsMetadata.Type);
                }
                
                var providerOperationsMetadata = client.ProviderOperationsMetadata.Get("Microsoft.Web");
                Assert.NotNull(providerOperationsMetadata);
                Assert.NotNull(providerOperationsMetadata.DisplayName);
                Assert.NotNull(providerOperationsMetadata.Id);
                Assert.NotNull(providerOperationsMetadata.Name);
                Assert.NotNull(providerOperationsMetadata.Operations);
                Assert.NotNull(providerOperationsMetadata.ResourceTypes);
                Assert.NotNull(providerOperationsMetadata.Type);
            }
        }

        [Fact]
        public void ProviderOperationsMetadataListWithDataActionGetTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);

                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);

                var providerOperationsMetadata = client.ProviderOperationsMetadata.Get("Microsoft.Storage");
                Assert.NotNull(providerOperationsMetadata);
                Assert.NotNull(providerOperationsMetadata.DisplayName);
                Assert.NotNull(providerOperationsMetadata.Id);
                Assert.NotNull(providerOperationsMetadata.Name);
                Assert.NotNull(providerOperationsMetadata.Operations);
                Assert.NotNull(providerOperationsMetadata.ResourceTypes);
                Assert.NotNull(providerOperationsMetadata.Type);

                foreach (var operationsMetadata in providerOperationsMetadata.Operations)
                {
                    Assert.NotNull(operationsMetadata);
                    Assert.NotNull(operationsMetadata.IsDataAction);
                }

                // change it to >=1 when storage deploys actions with data action = true
                Assert.True(providerOperationsMetadata.Operations.Count(a => a.IsDataAction == true) >= 0);
                Assert.True(providerOperationsMetadata.ResourceTypes.Count(a => a.Operations.Count(op => op.IsDataAction == true) >= 0) >= 0);
            }
        }

        [Fact]
        public void GetProviderOperationsMetadataListWithInvalidProvider()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = testContext.GetAuthorizationManagementClient(context);
                Assert.NotNull(client);
                Assert.NotNull(client.HttpClient);
                try
                {
                    var providerOperationsMetadata = client.ProviderOperationsMetadata.Get("InvalidProvider");
                }
                catch (CloudException ex)
                {
                    Assert.Equal("Provider 'InvalidProvider' not found.", ex.Message);
                }
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

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(Authorization.Tests.BasicTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}