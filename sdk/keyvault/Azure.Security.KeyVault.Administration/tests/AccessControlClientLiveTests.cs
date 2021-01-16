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
        public AccessControlClientLiveTests(bool isAsync)
            : base(isAsync, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [RecordedTest]
        public async Task GetRoleDefinitions()
        {
            List<KeyVaultRoleDefinition> results = await Client.GetRoleDefinitionsAsync(KeyVaultRoleScope.Global).ToEnumerableAsync().ConfigureAwait(false);

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

        [RecordedTest]
        public async Task CreateRoleAssignment()
        {
            List<KeyVaultRoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(KeyVaultRoleScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            var definitionToAssign = definitions.FirstOrDefault(d => d.RoleName.Contains(RoleName));

            KeyVaultRoleAssignment result = await Client.CreateRoleAssignmentAsync(KeyVaultRoleScope.Global, definitionToAssign.Id, TestEnvironment.ClientObjectId, _roleAssignmentId).ConfigureAwait(false);

            RegisterForCleanup(result);

            Assert.That(result.Id, Is.Not.Null);
            Assert.That(result.Name, Is.Not.Null);
            Assert.That(result.Type, Is.Not.Null);
            Assert.That(result.Properties.PrincipalId, Is.EqualTo(TestEnvironment.ClientObjectId));
            Assert.That(result.Properties.RoleDefinitionId, Is.EqualTo(definitionToAssign.Id));
        }

        [RecordedTest]
        public async Task GetRoleAssignment()
        {
            List<KeyVaultRoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(KeyVaultRoleScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            var definitionToAssign = definitions.FirstOrDefault(d => d.RoleName.Contains(RoleName));

            KeyVaultRoleAssignment assignment = await Client.CreateRoleAssignmentAsync(KeyVaultRoleScope.Global, definitionToAssign.Id, TestEnvironment.ClientObjectId, _roleAssignmentId).ConfigureAwait(false);

            RegisterForCleanup(assignment);

            KeyVaultRoleAssignment result = await Client.GetRoleAssignmentAsync(KeyVaultRoleScope.Global, assignment.Name).ConfigureAwait(false);

            Assert.That(result.Id, Is.EqualTo(assignment.Id));
            Assert.That(result.Name, Is.EqualTo(assignment.Name));
            Assert.That(result.Type, Is.EqualTo(assignment.Type));
            Assert.That(result.Properties.PrincipalId, Is.EqualTo(assignment.Properties.PrincipalId));
            Assert.That(result.Properties.RoleDefinitionId, Is.EqualTo(assignment.Properties.RoleDefinitionId));
            Assert.That(result.Properties.Scope, Is.EqualTo(assignment.Properties.Scope));
        }

        [RecordedTest]
        public async Task DeleteRoleAssignment()
        {
            List<KeyVaultRoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(KeyVaultRoleScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            var definitionToAssign = definitions.FirstOrDefault(d => d.RoleName.Contains(RoleName));

            KeyVaultRoleAssignment assignment = await Client.CreateRoleAssignmentAsync(KeyVaultRoleScope.Global, definitionToAssign.Id, TestEnvironment.ClientObjectId, _roleAssignmentId).ConfigureAwait(false);

            KeyVaultRoleAssignment result = await Client.DeleteRoleAssignmentAsync(KeyVaultRoleScope.Global, assignment.Name).ConfigureAwait(false);

            Assert.That(result.Id, Is.EqualTo(assignment.Id));
            Assert.That(result.Name, Is.EqualTo(assignment.Name));
            Assert.That(result.Type, Is.EqualTo(assignment.Type));
            Assert.That(result.Properties.PrincipalId, Is.EqualTo(assignment.Properties.PrincipalId));
            Assert.That(result.Properties.RoleDefinitionId, Is.EqualTo(assignment.Properties.RoleDefinitionId));
            Assert.That(result.Properties.Scope, Is.EqualTo(assignment.Properties.Scope));
        }
    }
}
