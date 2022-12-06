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
                Response listResponse = await definitionsClient.GetRoleDefinitionsAsync(true);
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

            Assert.NotNull(role.RoleAssignmentId);
            Assert.NotNull(role.RoleAssignmentRoleDefinitionId);
            Assert.NotNull(role.RoleAssignmentPrincipalId);
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

            Assert.AreEqual(role.RoleAssignmentRoleDefinitionId, roleAssignmentJson.RootElement.GetProperty("roleDefinitionId").GetString());
            Assert.AreEqual(role.RoleAssignmentPrincipalId, roleAssignmentJson.RootElement.GetProperty("principalId").GetString());
        }

        [Test]
        public async Task CanGetRoleAssignmentViaGrowUpHelper()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(assignmentsClient, definitionsClient, TestEnvironment);

            Response<RoleAssignmentDetails> response = await assignmentsClient.GetRoleAssignmentByIdAsync(role.RoleAssignmentId);

            Assert.AreEqual(role.RoleAssignmentRoleDefinitionId, response.Value.RoleDefinitionId.ToString());
            Assert.AreEqual(role.RoleAssignmentPrincipalId, response.Value.PrincipalId.ToString());
        }

        [Test]
        public async Task CanListRoleDefinitions()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(assignmentsClient, definitionsClient, TestEnvironment);

            // TODO: This will change to pageable with next (Data Plane) client generator update
            Response listReponse = await definitionsClient.GetRoleDefinitionsAsync(true);
            var listContent = listReponse.Content;
            using var roleDefinitionsJson = JsonDocument.Parse(listContent.ToMemory());

            foreach (var expectedRoleDefinitionJson in roleDefinitionsJson.RootElement.EnumerateArray())
            {
                string id = expectedRoleDefinitionJson.GetProperty("id").ToString();

                var roleDefinitionResponse = await definitionsClient.GetRoleDefinitionByIdAsync(id, new());
                var roleDefinitionContent = roleDefinitionResponse.Content;
                using var actualRoleDefinitionJson = JsonDocument.Parse(roleDefinitionContent.ToMemory());

                Assert.AreEqual(expectedRoleDefinitionJson.GetProperty("id").ToString(), actualRoleDefinitionJson.RootElement.GetProperty("id").ToString());
                Assert.AreEqual(expectedRoleDefinitionJson.GetProperty("name").ToString(), actualRoleDefinitionJson.RootElement.GetProperty("name").ToString());
            }

            Assert.GreaterOrEqual(roleDefinitionsJson.RootElement.GetArrayLength(), 1);
        }

        [Test]
        public async Task CanListRoleAssignments()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(assignmentsClient, definitionsClient, TestEnvironment);

            // TODO: This will change to pageable with https://github.com/azure/azure-sdk-for-net/issues/24680
            Response listReponse = await assignmentsClient.GetRoleAssignmentsAsync();
            var listContent = listReponse.Content;
            using var outerJson = JsonDocument.Parse(listContent.ToMemory());
            var roleAssignmentsJson = outerJson.RootElement.GetProperty("value");

            foreach (var expectedRoleAssignmentJson in roleAssignmentsJson.EnumerateArray())
            {
                string id = expectedRoleAssignmentJson.GetProperty("id").ToString();

                var roleAssignmentResponse = await assignmentsClient.GetRoleAssignmentByIdAsync(id, new());
                var roleAssignmentContent = roleAssignmentResponse.Content;
                using var actualRoleDefinitionJson = JsonDocument.Parse(roleAssignmentContent.ToMemory());

                Assert.AreEqual(expectedRoleAssignmentJson.GetProperty("id").ToString(), actualRoleDefinitionJson.RootElement.GetProperty("id").ToString());
                Assert.AreEqual(expectedRoleAssignmentJson.GetProperty("roleDefinitionId").ToString(), actualRoleDefinitionJson.RootElement.GetProperty("roleDefinitionId").ToString());
                Assert.AreEqual(expectedRoleAssignmentJson.GetProperty("principalId").ToString(), actualRoleDefinitionJson.RootElement.GetProperty("principalId").ToString());
                Assert.AreEqual(expectedRoleAssignmentJson.GetProperty("scope").ToString(), actualRoleDefinitionJson.RootElement.GetProperty("scope").ToString());
            }

            Assert.GreaterOrEqual(roleAssignmentsJson.GetArrayLength(), 1);
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

            Assert.AreEqual(1, accessDecisionsEnumerator.Count());

            var accessDecisionJson = accessDecisionsEnumerator.First();

            Assert.AreEqual("Allowed", accessDecisionJson.GetProperty("accessDecision").ToString());
            Assert.AreEqual(actionId, accessDecisionJson.GetProperty("actionId").ToString());

            var roleAssignmentJson = accessDecisionJson.GetProperty("roleAssignment");
            Assert.AreEqual(role.RoleAssignmentId, roleAssignmentJson.GetProperty("id").ToString());
            Assert.AreEqual(role.RoleAssignmentRoleDefinitionId, roleAssignmentJson.GetProperty("roleDefinitionId").ToString());
            Assert.AreEqual(role.RoleAssignmentPrincipalId, roleAssignmentJson.GetProperty("principalId").ToString());
            Assert.AreEqual(scope, roleAssignmentJson.GetProperty("scope").ToString());
        }

        [Test]
        public async Task CanCheckPrincipalAccessViaGrowUpHelper()
        {
            // Arrange
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            string scope = "workspaces/" + TestEnvironment.WorkspaceName;
            string actionId = "Microsoft.Synapse/workspaces/read";

            await using DisposableClientRole role = await DisposableClientRole.Create(assignmentsClient, definitionsClient, TestEnvironment);

            // Act
            CheckPrincipalAccessRequest checkAccessRequest = new CheckPrincipalAccessRequest(
                new SubjectInfo(new Guid(role.RoleAssignmentPrincipalId)),
                new List<RequiredAction>() { new RequiredAction(actionId, isDataAction: true) },
                scope);

            Response<CheckPrincipalAccessResponse> response = await assignmentsClient.CheckPrincipalAccessAsync(checkAccessRequest);

            // Assert
            var decisions = response.Value.AccessDecisions;
            Assert.AreEqual(1, decisions.Count);

            var decision = decisions[0];

            Assert.AreEqual("Allowed", decision.AccessDecision);
            Assert.AreEqual(actionId, decision.ActionId);
            Assert.AreEqual(role.RoleAssignmentPrincipalId, decision.RoleAssignment.PrincipalId.ToString());
            Assert.AreEqual(role.RoleAssignmentRoleDefinitionId, decision.RoleAssignment.RoleDefinitionId.ToString());
            Assert.AreEqual(scope, decision.RoleAssignment.Scope);
            Assert.AreEqual(role.RoleAssignmentId, decision.RoleAssignment.Id);
        }
    }
}
