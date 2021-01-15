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
    public class AccessControlClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        internal class DisposableClientRole : IAsyncDisposable
        {
            private readonly AccessControlClient _client;
            public RoleAssignmentDetails Assignment;

            private DisposableClientRole (AccessControlClient client, RoleAssignmentDetails assignment)
            {
                _client = client;
                Assignment = assignment;
            }

            public static async ValueTask<DisposableClientRole> Create (AccessControlClient client, TestRecording recording) =>
                new DisposableClientRole (client, await CreateResource (client, recording));

            public static async ValueTask<RoleAssignmentDetails> CreateResource (AccessControlClient client, TestRecording recording)
            {
                string roleID = (await client.GetRoleDefinitionsAsync().ToListAsync()).First (x => x.Name == "Workspace Admin").Id;
                string principalId = recording.Random.NewGuid().ToString();
                return await client.CreateRoleAssignmentAsync(new RoleAssignmentOptions(roleID, principalId));
            }

            public async ValueTask DisposeAsync() => await _client.DeleteRoleAssignmentByIdAsync(Assignment.Id);
        }

        public AccessControlClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private AccessControlClient CreateClient()
        {
            return InstrumentClient(new AccessControlClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new AccessControlClientOptions())
            ));
        }

        [Test]
        public async Task CreateRoleAssignment()
        {
            AccessControlClient client = CreateClient();
            await using DisposableClientRole role = await DisposableClientRole.Create (client, this.Recording);

            Assert.NotNull(role.Assignment.Id);
            Assert.NotNull(role.Assignment.RoleId);
            Assert.NotNull(role.Assignment.PrincipalId);
        }

        [Test]
        public async Task GetRoleAssignment()
        {
            AccessControlClient client = CreateClient();
            await using DisposableClientRole role = await DisposableClientRole.Create (client, this.Recording);

            RoleAssignmentDetails roleAssignment = await client.GetRoleAssignmentByIdAsync(role.Assignment.Id);

            Assert.AreEqual(role.Assignment.RoleId, roleAssignment.RoleId);
            Assert.AreEqual(role.Assignment.PrincipalId, roleAssignment.PrincipalId);
        }

        [Test]
        public async Task ListRoleAssignments()
        {
            AccessControlClient client = CreateClient();
            await using DisposableClientRole role = await DisposableClientRole.Create (client, this.Recording);

            Response<IReadOnlyList<RoleAssignmentDetails>> roleAssignments = await client.GetRoleAssignmentsAsync();
            foreach (RoleAssignmentDetails expected in roleAssignments.Value)
            {
                RoleAssignmentDetails actual = await client.GetRoleAssignmentByIdAsync(expected.Id);
                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.PrincipalId, actual.PrincipalId);
                Assert.AreEqual(expected.RoleId, actual.RoleId);
            }
            Assert.GreaterOrEqual(roleAssignments.Value.Count, 1);
        }

        [Test]
        public async Task DeleteRoleAssignments()
        {
            // Non-disposable as we'll be deleting it ourselves
            AccessControlClient client = CreateClient();
            RoleAssignmentDetails assignment = await DisposableClientRole.CreateResource (client, this.Recording);

            Response response = await client.DeleteRoleAssignmentByIdAsync (assignment.Id);
            switch (response.Status) {
                case 200:
                case 204:
                    break;
                default:
                    Assert.Fail($"Unexpected status ${response.Status} returned");
                    break;
            }
        }

        [Test]
        public async Task GetCallerRoleAssignment()
        {
            AccessControlClient client = CreateClient();
            Response<IReadOnlyList<string>> assignments = await client.GetCallerRoleAssignmentsAsync ();
            Assert.GreaterOrEqual(assignments.Value.Count, 1);
        }
    }
}
