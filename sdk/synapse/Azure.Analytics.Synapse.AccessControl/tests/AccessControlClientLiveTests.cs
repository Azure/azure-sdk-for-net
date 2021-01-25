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
            private readonly RoleAssignmentsClient _client;
            public RoleAssignmentDetails Assignment;

            private DisposableClientRole (RoleAssignmentsClient assignmentsClient, RoleDefinitionsClient definitionsClient, RoleAssignmentDetails assignment)
            {
                _client = assignmentsClient;
                Assignment = assignment;
            }

            public static async ValueTask<DisposableClientRole> Create (RoleAssignmentsClient assignmentsClient, RoleDefinitionsClient definitionsClient, TestRecording recording) =>
                new DisposableClientRole (assignmentsClient, definitionsClient, await CreateResource (assignmentsClient, definitionsClient, recording));

            public static async ValueTask<RoleAssignmentDetails> CreateResource (RoleAssignmentsClient assignmentsClient, RoleDefinitionsClient definitionsClient, TestRecording recording)
            {
                string scope = "workspaces/workspacechhamosynapse";

                Guid? roleID = (await definitionsClient.ListRoleDefinitionsAsync()).Value.First (x => x.Name == "Synapse Administrator").Id;
                string roleAssignmentId = recording.Random.NewGuid().ToString();
                Guid principalId = recording.Random.NewGuid();
                Console.WriteLine ($"{roleAssignmentId} {roleID.Value} {principalId}");
                return await assignmentsClient.CreateRoleAssignmentAsync(roleAssignmentId, roleID.Value, principalId, scope);
            }

            public async ValueTask DisposeAsync()
            {
                Console.WriteLine ($"Deleting {Assignment.Id}");
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
                InstrumentClientOptions(new RoleAssignmentsClientOptions())
            ));
        }

        private RoleDefinitionsClient CreateDefinitionsClient()
        {
            return InstrumentClient(new RoleDefinitionsClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new RoleDefinitionsClientOptions())
            ));
        }

        [Test]
        public async Task ReuseTest()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            Guid? roleID = (await definitionsClient.ListRoleDefinitionsAsync()).Value.First (x => x.Name == "Synapse Administrator").Id;
            string roleAssignmentId = "FCEC8F68-E6ED-4C00-9F7C-0C6732AB2276";
            Guid principalId = Guid.Parse("C9AD94B2-541B-4041-92DC-AEC90EF0A74D");
            string scope = "workspaces/workspacechhamosynapse";

            Console.WriteLine ("Before first create");
            Response<RoleAssignmentDetails> response = await assignmentsClient.CreateRoleAssignmentAsync(roleAssignmentId, roleID.Value, principalId, scope);
            Console.WriteLine (response.GetRawResponse().Status);
            Console.WriteLine (response.Value.Id);
            Console.WriteLine();

            Console.WriteLine ("Before first delete");
            Response response2 = await assignmentsClient.DeleteRoleAssignmentByIdAsync(roleAssignmentId);
            Console.WriteLine (response2.Status);
            Console.WriteLine();

            Console.WriteLine ("Before second create");
            Response<RoleAssignmentDetails> response3 = await assignmentsClient.CreateRoleAssignmentAsync(roleAssignmentId, roleID.Value, principalId, scope);
            Console.WriteLine (response3.GetRawResponse().Status);
        }

        [Test]
        public async Task CreateRoleAssignment()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create (assignmentsClient, definitionsClient, this.Recording);

            Assert.NotNull(role.Assignment.Id);
            Assert.NotNull(role.Assignment.RoleDefinitionId);
            Assert.NotNull(role.Assignment.PrincipalId);
        }

        [Test]
        public async Task GetRoleAssignment()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create (assignmentsClient, definitionsClient, this.Recording);

            RoleAssignmentDetails roleAssignment = await assignmentsClient.GetRoleAssignmentByIdAsync(role.Assignment.Id);

            Assert.AreEqual(role.Assignment.RoleDefinitionId, roleAssignment.RoleDefinitionId);
            Assert.AreEqual(role.Assignment.PrincipalId, roleAssignment.PrincipalId);
        }

        [Test]
        public async Task ListRoleAssignments()
        {
            RoleAssignmentsClient assignmentsClient = CreateAssignmentClient();
            RoleDefinitionsClient definitionsClient = CreateDefinitionsClient();

            await using DisposableClientRole role = await DisposableClientRole.Create (assignmentsClient, definitionsClient, this.Recording);

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

            RoleAssignmentDetails assignment = await DisposableClientRole.CreateResource (assignmentsClient, definitionsClient, this.Recording);

            Response response = await assignmentsClient.DeleteRoleAssignmentByIdAsync (assignment.Id);
            response.AssertSuccess();
        }
    }
}
