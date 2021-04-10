// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.AccessControl;
using Azure.Analytics.Synapse.AccessControl.Models;
using Azure.Core.TestFramework;
using Azure.Analytics.Synapse.Tests;
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
            public RoleAssignmentDetails Assignment;

            private DisposableClientRole (RoleAssignmentsClient assignmentsClient, RoleDefinitionsClient definitionsClient, RoleAssignmentDetails assignment)
            {
                _client = assignmentsClient;
                Assignment = assignment;
            }

            public static async ValueTask<DisposableClientRole> Create (RoleAssignmentsClient assignmentsClient, RoleDefinitionsClient definitionsClient, SynapseTestEnvironment testEnvironment) =>
                new DisposableClientRole (assignmentsClient, definitionsClient, await CreateResource (assignmentsClient, definitionsClient, testEnvironment));

            public static async ValueTask<RoleAssignmentDetails> CreateResource (RoleAssignmentsClient assignmentsClient, RoleDefinitionsClient definitionsClient, SynapseTestEnvironment testEnvironment)
            {
                string scope = "workspaces/" + testEnvironment.WorkspaceName;

                Guid? roleID = (await definitionsClient.ListRoleDefinitionsAsync()).Value.First (x => x.Name == "Synapse Administrator").Id;
                Guid principalId = Guid.NewGuid();
                string roleAssignmentId = Guid.NewGuid().ToString();
                return await assignmentsClient.CreateRoleAssignmentAsync(roleAssignmentId, roleID.Value, principalId, scope);
            }

            public async ValueTask DisposeAsync()
            {
                await _client.DeleteRoleAssignmentByIdAsync(Assignment.Id);
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

            await using DisposableClientRole role = await DisposableClientRole.Create (assignmentsClient, definitionsClient, TestEnvironment);

            Assert.NotNull(role.Assignment.Id);
            Assert.NotNull(role.Assignment.RoleDefinitionId);
            Assert.NotNull(role.Assignment.PrincipalId);
        }

        [Test]
        public async Task GetRoleAssignment()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create (assignmentsClient, definitionsClient, TestEnvironment);

            RoleAssignmentDetails roleAssignment = await assignmentsClient.GetRoleAssignmentByIdAsync(role.Assignment.Id);

            Assert.AreEqual(role.Assignment.RoleDefinitionId, roleAssignment.RoleDefinitionId);
            Assert.AreEqual(role.Assignment.PrincipalId, roleAssignment.PrincipalId);
        }

        [Test]
        public async Task ListRoleAssignments()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create (assignmentsClient, definitionsClient, TestEnvironment);

            Response<IReadOnlyList<SynapseRoleDefinition>> roleAssignments = await definitionsClient.ListRoleDefinitionsAsync();
            foreach (SynapseRoleDefinition expected in roleAssignments.Value)
            {
                SynapseRoleDefinition actual = await definitionsClient.GetRoleDefinitionByIdAsync(expected.Id.ToString());
                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
            }
            Assert.GreaterOrEqual(roleAssignments.Value.Count, 1);
        }

        [Test]
        public async Task DeleteRoleAssignments()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            RoleAssignmentDetails assignment = await DisposableClientRole.CreateResource (assignmentsClient, definitionsClient, TestEnvironment);

            Response response = await assignmentsClient.DeleteRoleAssignmentByIdAsync (assignment.Id);
            response.AssertSuccess();
        }
    }
}
