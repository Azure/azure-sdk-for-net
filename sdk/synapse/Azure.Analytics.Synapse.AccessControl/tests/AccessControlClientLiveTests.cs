// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.AccessControl.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="AccessControlClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [LiveOnly] // Assignment IDs can not be reused for at least 30 days.
    public class AccessControlClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        internal class DisposableClientRole : IAsyncDisposable
        {
            private readonly RoleAssignmentsClient _client;

            // properties of RoleAssignmentDetails used in this class, and are public because we make them visible to tests.
            public string RoleAssignmentId { get; private set; }
            public string RoleAssignmentRoleDefinitionId { get; private set; }
            public string RoleAssignmentPrincipalId { get; private set; }

            private DisposableClientRole(RoleAssignmentsClient assignmentsClient, RoleDefinitionsClient definitionsClient, Response createResponse)
            {
                _client = assignmentsClient;

                var content = createResponse.Content;
                using var roleAssignmentDetailsJson = JsonDocument.Parse(content.ToMemory());

                RoleAssignmentId = roleAssignmentDetailsJson.RootElement.GetProperty("id").GetString();
                RoleAssignmentRoleDefinitionId = roleAssignmentDetailsJson.RootElement.GetProperty("roleDefinitionId").GetString();
                RoleAssignmentPrincipalId = roleAssignmentDetailsJson.RootElement.GetProperty("principalId").GetString();
            }

            public static async ValueTask<DisposableClientRole> Create(RoleAssignmentsClient assignmentsClient, RoleDefinitionsClient definitionsClient, SynapseTestEnvironment testEnvironment)
            {
                var clientRole = new DisposableClientRole(assignmentsClient, definitionsClient, await CreateResource(assignmentsClient, definitionsClient, testEnvironment));
                return clientRole;
            }

            public static async ValueTask<Response> CreateResource(RoleAssignmentsClient assignmentsClient, RoleDefinitionsClient definitionsClient, SynapseTestEnvironment testEnvironment)
            {
                Response listResponse = await definitionsClient.GetRoleDefinitionsAsync(true, null, new());
                var listContent = listResponse.Content;
                using var roleDefinitionsJson = JsonDocument.Parse(listContent.ToMemory());

                var count = roleDefinitionsJson.RootElement.GetArrayLength();
                var roleId = roleDefinitionsJson.RootElement.EnumerateArray().First(roleDefinitionJson => roleDefinitionJson.GetProperty("name").ToString() == "Synapse Administrator").GetProperty("id").ToString();
                string roleAssignmentId = Guid.NewGuid().ToString();

                var roleAssignmentDetails = new
                {
                    roleId = roleId,
                    principalId = Guid.NewGuid(),
                    scope = "workspaces/" + testEnvironment.WorkspaceName
                };

                return await assignmentsClient.CreateRoleAssignmentAsync(roleAssignmentId, RequestContent.Create(roleAssignmentDetails), ContentType.ApplicationJson);
            }

            public async ValueTask DisposeAsync()
            {
                await _client.DeleteRoleAssignmentByIdAsync(RoleAssignmentId);
            }
        }

        public AccessControlClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private RoleAssignmentsClient CreateAssignmentClient()
        {
            return InstrumentClient(new RoleAssignmentsClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new AccessControlClientOptions())
            ));
        }

        private RoleDefinitionsClient CreateDefinitionsClient()
        {
            return InstrumentClient(new RoleDefinitionsClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new AccessControlClientOptions())
            ));
        }

        [Test]
        public async Task CanCreateRoleAssignment()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(assignmentsClient, definitionsClient, TestEnvironment);

            Assert.Multiple(() =>
            {
                Assert.That(role.RoleAssignmentId, Is.Not.Null);
                Assert.That(role.RoleAssignmentRoleDefinitionId, Is.Not.Null);
                Assert.That(role.RoleAssignmentPrincipalId, Is.Not.Null);
            });
        }

        [Test]
        public async Task CanGetRoleAssignment()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(assignmentsClient, definitionsClient, TestEnvironment);

            var response = await assignmentsClient.GetRoleAssignmentByIdAsync(role.RoleAssignmentId, new());
            var content = response.Content;
            using var roleAssignmentJson = JsonDocument.Parse(content.ToMemory());

            Assert.Multiple(() =>
            {
                Assert.That(roleAssignmentJson.RootElement.GetProperty("roleDefinitionId").GetString(), Is.EqualTo(role.RoleAssignmentRoleDefinitionId));
                Assert.That(roleAssignmentJson.RootElement.GetProperty("principalId").GetString(), Is.EqualTo(role.RoleAssignmentPrincipalId));
            });
        }

        [Test]
        public async Task CanListRoleDefinitions()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(assignmentsClient, definitionsClient, TestEnvironment);

            // TODO: This will change to pageable with next (Data Plane) client generator update
            Response listReponse = await definitionsClient.GetRoleDefinitionsAsync(true, null, new());
            var listContent = listReponse.Content;
            using var roleDefinitionsJson = JsonDocument.Parse(listContent.ToMemory());

            foreach (var expectedRoleDefinitionJson in roleDefinitionsJson.RootElement.EnumerateArray())
            {
                string id = expectedRoleDefinitionJson.GetProperty("id").ToString();

                var roleDefinitionResponse = await definitionsClient.GetRoleDefinitionByIdAsync(id, new());
                var roleDefinitionContent = roleDefinitionResponse.Content;
                using var actualRoleDefinitionJson = JsonDocument.Parse(roleDefinitionContent.ToMemory());

                Assert.Multiple(() =>
                {
                    Assert.That(actualRoleDefinitionJson.RootElement.GetProperty("id").ToString(), Is.EqualTo(expectedRoleDefinitionJson.GetProperty("id").ToString()));
                    Assert.That(actualRoleDefinitionJson.RootElement.GetProperty("name").ToString(), Is.EqualTo(expectedRoleDefinitionJson.GetProperty("name").ToString()));
                });
            }

            Assert.That(roleDefinitionsJson.RootElement.GetArrayLength(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public async Task CanListRoleAssignments()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(assignmentsClient, definitionsClient, TestEnvironment);

            // TODO: This will change to pageable with https://github.com/azure/azure-sdk-for-net/issues/24680
            Response listReponse = await assignmentsClient.GetRoleAssignmentsAsync(null, null, null, null, new());
            var listContent = listReponse.Content;
            using var outerJson = JsonDocument.Parse(listContent.ToMemory());
            var roleAssignmentsJson = outerJson.RootElement.GetProperty("value");

            foreach (var expectedRoleAssignmentJson in roleAssignmentsJson.EnumerateArray())
            {
                string id = expectedRoleAssignmentJson.GetProperty("id").ToString();

                var roleAssignmentResponse = await assignmentsClient.GetRoleAssignmentByIdAsync(id, new());
                var roleAssignmentContent = roleAssignmentResponse.Content;
                using var actualRoleDefinitionJson = JsonDocument.Parse(roleAssignmentContent.ToMemory());

                Assert.Multiple(() =>
                {
                    Assert.That(actualRoleDefinitionJson.RootElement.GetProperty("id").ToString(), Is.EqualTo(expectedRoleAssignmentJson.GetProperty("id").ToString()));
                    Assert.That(actualRoleDefinitionJson.RootElement.GetProperty("roleDefinitionId").ToString(), Is.EqualTo(expectedRoleAssignmentJson.GetProperty("roleDefinitionId").ToString()));
                    Assert.That(actualRoleDefinitionJson.RootElement.GetProperty("principalId").ToString(), Is.EqualTo(expectedRoleAssignmentJson.GetProperty("principalId").ToString()));
                    Assert.That(actualRoleDefinitionJson.RootElement.GetProperty("scope").ToString(), Is.EqualTo(expectedRoleAssignmentJson.GetProperty("scope").ToString()));
                });
            }

            Assert.That(roleAssignmentsJson.GetArrayLength(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public async Task CanDeleteRoleAssignments()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            var createResponse = await DisposableClientRole.CreateResource(assignmentsClient, definitionsClient, TestEnvironment);
            var content = createResponse.Content;
            using var roleAssignmentDetailsJson = JsonDocument.Parse(content.ToMemory());

            Response deleteResponse = await assignmentsClient.DeleteRoleAssignmentByIdAsync(roleAssignmentDetailsJson.RootElement.GetProperty("id").GetString());
            deleteResponse.AssertSuccess();
        }

        [Test]
        public async Task CanCheckPrincipalAccess()
        {
            // Arrange
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            string scope = "workspaces/" + TestEnvironment.WorkspaceName;
            string actionId = "Microsoft.Synapse/workspaces/read";

            await using DisposableClientRole role = await DisposableClientRole.Create(assignmentsClient, definitionsClient, TestEnvironment);

            // Act
            var accessRequest = new
            {
                subject = new
                {
                    principalId = role.RoleAssignmentPrincipalId,
                    groupIds = new string[] { },
                },
                scope = scope,
                actions = new[]
                {
                    new
                    {
                        id = actionId,
                        isDataAction = true
                    }
                }
            };

            var response = await assignmentsClient.CheckPrincipalAccessAsync(RequestContent.Create(accessRequest), ContentType.ApplicationJson);

            // Assert
            var content = response.Content;
            using var accessDecisionsJson = JsonDocument.Parse(content.ToMemory());
            var accessDecisionsEnumerator = accessDecisionsJson.RootElement.GetProperty("AccessDecisions").EnumerateArray();

            Assert.That(accessDecisionsEnumerator.Count(), Is.EqualTo(1));

            var accessDecisionJson = accessDecisionsEnumerator.First();

            Assert.Multiple(() =>
            {
                Assert.That(accessDecisionJson.GetProperty("accessDecision").ToString(), Is.EqualTo("Allowed"));
                Assert.That(accessDecisionJson.GetProperty("actionId").ToString(), Is.EqualTo(actionId));
            });

            var roleAssignmentJson = accessDecisionJson.GetProperty("roleAssignment");
            Assert.Multiple(() =>
            {
                Assert.That(roleAssignmentJson.GetProperty("id").ToString(), Is.EqualTo(role.RoleAssignmentId));
                Assert.That(roleAssignmentJson.GetProperty("roleDefinitionId").ToString(), Is.EqualTo(role.RoleAssignmentRoleDefinitionId));
                Assert.That(roleAssignmentJson.GetProperty("principalId").ToString(), Is.EqualTo(role.RoleAssignmentPrincipalId));
                Assert.That(roleAssignmentJson.GetProperty("scope").ToString(), Is.EqualTo(scope));
            });
        }
    }
}
