// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Administration.Models;
using static Azure.Security.KeyVault.Administration.KeyVaultAdministrationConstants;
using NUnit.Framework;
using System.Linq;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class AccessControlClientLiveTests : AccessControlTestBase
    {
        private const string pricipalID = "4ae6842b-2a3e-4919-8305-7db89f3d6edd";
        private const string roleName = "Azure Key Vault Managed HSM Administrator";
        private const string roleAssignmentId = "e7ae2aff-eb17-4c9d-84f0-d12f7f468f16";

        public AccessControlClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback /* To record tests, add this argument, RecordedTestMode.Record */)
        { }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Client = GetClient();

                ChallengeBasedAuthenticationPolicy.AuthenticationChallenge.ClearCache();
            }
        }

        [Test]
        public async Task GetRoleDefinitions()
        {
            List<RoleDefinition> results = await Client.GetRoleDefinitionsAsync(Scopes.Root).ToEnumerableAsync().ConfigureAwait(false);

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
            List<RoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(Scopes.Root).ToEnumerableAsync().ConfigureAwait(false);
            var definitionToAssign = definitions.FirstOrDefault(d => d.RoleName == roleName);

            var properties = new RoleAssignmentProperties(definitionToAssign.Id, pricipalID);
            RoleAssignment result = await Client.CreateRoleAssignmentAsync(roleAssignmentId, Scopes.Root, properties).ConfigureAwait(false);

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
            List<RoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(Scopes.Root).ToEnumerableAsync().ConfigureAwait(false);
            var definitionToAssign = definitions.FirstOrDefault(d => d.RoleName == roleName);

            var properties = new RoleAssignmentProperties(definitionToAssign.Id, pricipalID);
            RoleAssignment assignment = await Client.CreateRoleAssignmentAsync(roleAssignmentId, Scopes.Root, properties).ConfigureAwait(false);

            RegisterForCleanup(assignment);

            RoleAssignment result = await Client.GetRoleAssignmentAsync(Scopes.Root, assignment.Name).ConfigureAwait(false);

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
            List<RoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(Scopes.Root).ToEnumerableAsync().ConfigureAwait(false);
            var definitionToAssign = definitions.FirstOrDefault(d => d.RoleName == roleName);

            var properties = new RoleAssignmentProperties(definitionToAssign.Id, pricipalID);
            RoleAssignment assignment = await Client.CreateRoleAssignmentAsync(roleAssignmentId, Scopes.Root, properties).ConfigureAwait(false);

            RoleAssignment result = await Client.DeleteRoleAssignmentAsync(Scopes.Root, assignment.Name).ConfigureAwait(false);

            Assert.That(result.Id, Is.EqualTo(assignment.Id));
            Assert.That(result.Name, Is.EqualTo(assignment.Name));
            Assert.That(result.Type, Is.EqualTo(assignment.Type));
            Assert.That(result.Properties.PrincipalId, Is.EqualTo(assignment.Properties.PrincipalId));
            Assert.That(result.Properties.RoleDefinitionId, Is.EqualTo(assignment.Properties.RoleDefinitionId));
            Assert.That(result.Properties.Scope, Is.EqualTo(assignment.Properties.Scope));
        }
    }
}
