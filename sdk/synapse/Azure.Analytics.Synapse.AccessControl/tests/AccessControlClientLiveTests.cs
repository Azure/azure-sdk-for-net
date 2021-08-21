// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Tests;
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
            private readonly SynapseAccessControlClient _client;
            public SynapseRoleAssignment Assignment;

            private DisposableClientRole(SynapseAccessControlClient client, SynapseRoleAssignment assignment)
            {
                _client = client;
                Assignment = assignment;
            }

            public static async ValueTask<DisposableClientRole> Create(SynapseAccessControlClient client, SynapseTestEnvironment testEnvironment) =>
                new DisposableClientRole(client, await CreateResource(client, testEnvironment));

            public static async ValueTask<SynapseRoleAssignment> CreateResource(SynapseAccessControlClient client, SynapseTestEnvironment testEnvironment)
            {
                string scope = "workspaces/" + testEnvironment.WorkspaceName;

                Guid? roleID = new Guid((await client.GetRoleDefinitionsAsync(scope).FirstAsync(x => x.Name == "Synapse Administrator")).Id);
                Guid principalId = Guid.NewGuid();
                Guid roleAssignmentId = Guid.NewGuid();
                return await client.CreateRoleAssignmentAsync(scope, roleID.Value.ToString(), principalId.ToString(), roleAssignmentId);
            }

            public async ValueTask DisposeAsync()
            {
                await _client.DeleteRoleAssignmentByIdAsync(Assignment.Id.ToString());
            }
        }

        public AccessControlClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }

        private SynapseAccessControlClient CreateClient()
        {
            return InstrumentClient(new SynapseAccessControlClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new SynapseAdministrationClientOptions())
            ));
        }

        [Test]
        public async Task CreateRoleAssignment()
        {
            SynapseAccessControlClient client = CreateClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(client, TestEnvironment);

            Assert.NotNull(role.Assignment.Id);
            Assert.NotNull(role.Assignment.Properties.RoleDefinitionId);
            Assert.NotNull(role.Assignment.Properties.PrincipalId);
        }

        [Test]
        public async Task CreateRoleAssignment_ModelTypeParameterOverload()
        {
            SynapseAccessControlClient client = CreateClient();

            string scope = "workspaces/" + TestEnvironment.WorkspaceName;
            Guid roleId = new Guid((await client.GetRoleDefinitionsAsync(scope).FirstAsync(x => x.Name == "Synapse Administrator")).Id);
            Guid principalId = Guid.NewGuid();
            string roleAssignmentId = Guid.NewGuid().ToString();

            SynapseRoleAssignment roleAssignment = new SynapseRoleAssignment(roleId, principalId, scope);

            SynapseRoleAssignment returnedRoleAssignment = await client.CreateRoleAssignmentAsync(roleAssignmentId, roleAssignment, new RequestOptions()
            {
                StatusOption = ResponseStatusOption.NoThrow
            });

            // TODO: Finish this test and figure out the rest.

            await using DisposableClientRole role = await DisposableClientRole.Create(client, TestEnvironment);

            Assert.NotNull(role.Assignment.Id);
            Assert.NotNull(role.Assignment.Properties.RoleDefinitionId);
            Assert.NotNull(role.Assignment.Properties.PrincipalId);
        }

        [Test]
        public async Task GetRoleAssignment()
        {
            SynapseAccessControlClient client = CreateClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(client, TestEnvironment);

            // TODO: This string conversion is awkward -- should RoleAssignmentIdParameter be marked as a uuid?
            SynapseRoleAssignment roleAssignment = await client.GetRoleAssignmentAsync("", role.Assignment.Id.ToString());

            Assert.AreEqual(role.Assignment.Properties.RoleDefinitionId, roleAssignment.Properties.RoleDefinitionId);
            Assert.AreEqual(role.Assignment.Properties.PrincipalId, roleAssignment.Properties.PrincipalId);
        }

        [Test]
        public async Task ListRoleAssignments()
        {
            SynapseAccessControlClient client = CreateClient();

            await using DisposableClientRole role = await DisposableClientRole.Create(client, TestEnvironment);

            AsyncPageable<SynapseRoleDefinition> roleDefinitions = client.GetRoleDefinitionsAsync("");
            int count = 0;
            await foreach (SynapseRoleDefinition expected in roleDefinitions)
            {
                SynapseRoleDefinition actual = await client.GetRoleDefinitionAsync("", new Guid(expected.Id));
                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [Test]
        public async Task DeleteRoleAssignments()
        {
            SynapseAccessControlClient client = CreateClient();

            SynapseRoleAssignment assignment = await DisposableClientRole.CreateResource(client, TestEnvironment);

            // TODO: This string conversion is awkward -- should RoleAssignmentIdParameter be marked as a uuid?
            Response response = await client.DeleteRoleAssignmentAsync("", assignment.Id.ToString());
            response.AssertSuccess();
        }

        [Test]
        public async Task GetRbacScopes()
        {
            SynapseAccessControlClient client = CreateClient();

            var response = await client.ListScopesAsync();
        }

        //[Test]
        //public async Task ListRoleDefinitions()
        //{
        //    SynapseAccessControlClient client = CreateClient();

        //    client.ListRoleDefinitionsAsync()

        //}
    }
}
