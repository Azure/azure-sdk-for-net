// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Administration.Models;
using NUnit.Framework;
using System.Linq;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class AccessControlClientLiveTests : AccessControlTestBase
    {
        public AccessControlClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback /* To record tests, change this argument to RecordedTestMode.Record */)
        { }

        [Test]
        public async Task GetRoleDefinitions()
        {
            List<RoleDefinition> results = await Client.GetRoleDefinitionsAsync(RoleAssignmentScope.Global).ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(results.Count, Is.Not.Zero);
            Assert.That(results[0].AssignableScopes, Is.Not.Empty);
            Assert.That(results[0].Description, Is.Not.Null);
            Assert.That(results[0].Id, Is.Not.Null);
            Assert.That(results[0].Name, Is.Not.Null);
            Assert.That(results[0].Permissions, Is.Not.Empty);
            Assert.That(results[0].RoleName, Is.Not.Null);
            Assert.That(results[0].RoleType, Is.Not.Null);
            Assert.That(results[0].Type, Is.Not.Null);
        }

        [Test]
        public async Task CreateRoleAssignment()
        {
            List<RoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(RoleAssignmentScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            var definitionToAssign = definitions.FirstOrDefault(d => d.RoleName == RoleName);

            var properties = new RoleAssignmentProperties(definitionToAssign.Id, TestEnvironment.ClientObjectId);
            RoleAssignment result = await Client.CreateRoleAssignmentAsync(RoleAssignmentScope.Global, properties, _roleAssignmentId).ConfigureAwait(false);

            RegisterForCleanup(result);

            Assert.That(result.Id, Is.Not.Null);
            Assert.That(result.Name, Is.Not.Null);
            Assert.That(result.Type, Is.Not.Null);
            Assert.That(result.Properties.PrincipalId, Is.EqualTo(properties.PrincipalId));
            Assert.That(result.Properties.RoleDefinitionId, Is.EqualTo(properties.RoleDefinitionId));
        }

        [Test]
        public async Task GetRoleAssignment()
        {
            List<RoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(RoleAssignmentScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            var definitionToAssign = definitions.FirstOrDefault(d => d.RoleName == RoleName);

            var properties = new RoleAssignmentProperties(definitionToAssign.Id, TestEnvironment.ClientObjectId);
            RoleAssignment assignment = await Client.CreateRoleAssignmentAsync(RoleAssignmentScope.Global, properties, _roleAssignmentId).ConfigureAwait(false);

            RegisterForCleanup(assignment);

            RoleAssignment result = await Client.GetRoleAssignmentAsync(RoleAssignmentScope.Global, assignment.Name).ConfigureAwait(false);

            Assert.That(result.Id, Is.EqualTo(assignment.Id));
            Assert.That(result.Name, Is.EqualTo(assignment.Name));
            Assert.That(result.Type, Is.EqualTo(assignment.Type));
            Assert.That(result.Properties.PrincipalId, Is.EqualTo(assignment.Properties.PrincipalId));
            Assert.That(result.Properties.RoleDefinitionId, Is.EqualTo(assignment.Properties.RoleDefinitionId));
            Assert.That(result.Properties.Scope, Is.EqualTo(assignment.Properties.Scope));
        }

        [Test]
        public async Task DeleteRoleAssignment()
        {
            List<RoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(RoleAssignmentScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            var definitionToAssign = definitions.FirstOrDefault(d => d.RoleName == RoleName);

            var properties = new RoleAssignmentProperties(definitionToAssign.Id, TestEnvironment.ClientObjectId);
            RoleAssignment assignment = await Client.CreateRoleAssignmentAsync(RoleAssignmentScope.Global, properties, _roleAssignmentId).ConfigureAwait(false);

            RoleAssignment result = await Client.DeleteRoleAssignmentAsync(RoleAssignmentScope.Global, assignment.Name).ConfigureAwait(false);

            Assert.That(result.Id, Is.EqualTo(assignment.Id));
            Assert.That(result.Name, Is.EqualTo(assignment.Name));
            Assert.That(result.Type, Is.EqualTo(assignment.Type));
            Assert.That(result.Properties.PrincipalId, Is.EqualTo(assignment.Properties.PrincipalId));
            Assert.That(result.Properties.RoleDefinitionId, Is.EqualTo(assignment.Properties.RoleDefinitionId));
            Assert.That(result.Properties.Scope, Is.EqualTo(assignment.Properties.Scope));
        }
    }
}
