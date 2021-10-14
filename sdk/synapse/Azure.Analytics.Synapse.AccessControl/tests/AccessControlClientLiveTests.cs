// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
                var roleAssignmentDetailsJson = JsonDocument.Parse(content.ToMemory());

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
                Response listReponse = await definitionsClient.ListRoleDefinitionsAsync(new());
                var listContent = listReponse.Content;
                var roleDefinitionsJson = JsonDocument.Parse(listContent.ToMemory());

                var count = roleDefinitionsJson.RootElement.GetArrayLength();
                var roleId = roleDefinitionsJson.RootElement.EnumerateArray().First(roleDefinitionJson => roleDefinitionJson.GetProperty("name").ToString() == "Synapse Administrator").GetProperty("id").ToString();
                string roleAssignmentId = Guid.NewGuid().ToString();

                var roleAssignmentDetails = new
                {
                    roleId = roleId,
                    principalId = Guid.NewGuid(),
                    scope = "workspaces/" + testEnvironment.WorkspaceName
                };

                return await assignmentsClient.CreateRoleAssignmentAsync(roleAssignmentId, RequestContent.Create(roleAssignmentDetails));
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
        public async Task CreateRoleAssignment()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(assignmentsClient, definitionsClient, TestEnvironment);

            Assert.NotNull(role.RoleAssignmentId);
            Assert.NotNull(role.RoleAssignmentRoleDefinitionId);
            Assert.NotNull(role.RoleAssignmentPrincipalId);
        }

        [Test]
        public async Task GetRoleAssignment()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(assignmentsClient, definitionsClient, TestEnvironment);

            var response = await assignmentsClient.GetRoleAssignmentByIdAsync(role.RoleAssignmentId, new());
            var content = response.Content;
            var roleAssignmentJson = JsonDocument.Parse(content.ToMemory());

            Assert.AreEqual(role.RoleAssignmentRoleDefinitionId, roleAssignmentJson.RootElement.GetProperty("roleDefinitionId").GetString());
            Assert.AreEqual(role.RoleAssignmentPrincipalId, roleAssignmentJson.RootElement.GetProperty("principalId").GetString());
        }

        [Test]
        public async Task GetRoleAssignment_GrowUpHelper()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(assignmentsClient, definitionsClient, TestEnvironment);

            Response<RoleAssignmentDetails> response = await assignmentsClient.GetRoleAssignmentByIdAsync(role.RoleAssignmentId);

            Assert.AreEqual(role.RoleAssignmentRoleDefinitionId, response.Value.RoleDefinitionId.ToString());
            Assert.AreEqual(role.RoleAssignmentPrincipalId, response.Value.PrincipalId.ToString());
        }

        [Test]
        public async Task ListRoleAssignments()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(assignmentsClient, definitionsClient, TestEnvironment);

            // TODO: This will change to pageable with next LLC Generator update
            Response listReponse = await definitionsClient.ListRoleDefinitionsAsync(new());
            var listContent = listReponse.Content;
            var roleDefinitionsJson = JsonDocument.Parse(listContent.ToMemory());

            foreach (var expectedRoleDefinitionJson in roleDefinitionsJson.RootElement.EnumerateArray())
            {
                string id = expectedRoleDefinitionJson.GetProperty("id").ToString();

                var roleDefinitionResponse = await definitionsClient.GetRoleDefinitionByIdAsync(id, new());
                var roleDefinitionContent = roleDefinitionResponse.Content;
                var actualRoleDefinitionJson = JsonDocument.Parse(roleDefinitionContent.ToMemory());

                Assert.AreEqual(expectedRoleDefinitionJson.GetProperty("id").ToString(), actualRoleDefinitionJson.RootElement.GetProperty("id").ToString());
                Assert.AreEqual(expectedRoleDefinitionJson.GetProperty("name").ToString(), actualRoleDefinitionJson.RootElement.GetProperty("name").ToString());
            }

            Assert.GreaterOrEqual(roleDefinitionsJson.RootElement.GetArrayLength(), 1);
        }

        [Test]
        public async Task DeleteRoleAssignments()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            var createResponse = await DisposableClientRole.CreateResource(assignmentsClient, definitionsClient, TestEnvironment);
            var content = createResponse.Content;
            var roleAssignmentDetailsJson = JsonDocument.Parse(content.ToMemory());

            Response deleteResponse = await assignmentsClient.DeleteRoleAssignmentByIdAsync(roleAssignmentDetailsJson.RootElement.GetProperty("id").GetString());
            deleteResponse.AssertSuccess();
        }
    }
}
