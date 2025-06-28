// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;
using System;
using Azure.Security.KeyVault.Administration.Models;
using System.Text.Json;
using Azure.Security.KeyVault.Keys;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class AccessControlClientLiveTests : AccessControlTestBase
    {
        public AccessControlClientLiveTests(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
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
        public async Task GetRoleDefinition()
        {
            var description = Recording.GenerateAlphaNumericId("role");
            Guid name = Recording.Random.NewGuid();

            CreateOrUpdateRoleDefinitionOptions options = new(KeyVaultRoleScope.Global, name)
            {
                RoleName = name.ToString(),
                Description = description,
                Permissions =
                {
                    new()
                    {
                        DataActions =
                        {
                            KeyVaultDataAction.BackupHsmKeys,
                        }
                    }
                }
            };

            KeyVaultRoleDefinition createdDefinition = await Client.CreateOrUpdateRoleDefinitionAsync(options);

            RegisterForCleanup(createdDefinition);

            KeyVaultRoleDefinition fetchedRoleDefinition = await Client.GetRoleDefinitionAsync(KeyVaultRoleScope.Global, name);

            Assert.That(fetchedRoleDefinition.AssignableScopes, Is.EqualTo(new[] { KeyVaultRoleScope.Global }));
            Assert.That(fetchedRoleDefinition.Description, Is.EqualTo(description));
            Assert.That(fetchedRoleDefinition.Name, Is.EqualTo(name.ToString()));
            Assert.That(fetchedRoleDefinition.Permissions.First().DataActions, Is.EquivalentTo(options.Permissions[0].DataActions));
            Assert.That(fetchedRoleDefinition.Type, Is.EqualTo(KeyVaultRoleDefinitionType.MicrosoftAuthorizationRoleDefinitions));
        }

        [RecordedTest]
        public async Task CreateOrUpdateRoleDefinition()
        {
            var description = Recording.GenerateAlphaNumericId("role");
            Guid name = Recording.Random.NewGuid();

            CreateOrUpdateRoleDefinitionOptions options = new(KeyVaultRoleScope.Global, name)
            {
                RoleName = name.ToString(),
                Description = description,
                Permissions =
                {
                    new()
                    {
                        DataActions =
                        {
                            KeyVaultDataAction.BackupHsmKeys,
                        }
                    }
                }
            };

            KeyVaultRoleDefinition createdDefinition = await Client.CreateOrUpdateRoleDefinitionAsync(options);

            RegisterForCleanup(createdDefinition);

            Assert.That(createdDefinition.AssignableScopes, Is.EqualTo(new[] { KeyVaultRoleScope.Global }));
            Assert.That(createdDefinition.Description, Is.EqualTo(description));
            Assert.That(createdDefinition.Name, Is.EqualTo(name.ToString()));
            Assert.That(createdDefinition.Permissions.First().DataActions, Is.EquivalentTo(options.Permissions[0].DataActions));
            Assert.That(createdDefinition.Type, Is.EqualTo(KeyVaultRoleDefinitionType.MicrosoftAuthorizationRoleDefinitions));

            options.Permissions[0].DataActions.Clear();
            options.Permissions[0].DataActions.Add(KeyVaultDataAction.CreateHsmKey);
            options.Permissions[0].DataActions.Add(KeyVaultDataAction.DownloadHsmSecurityDomain);

            KeyVaultRoleDefinition updatedDefinition = await Client.CreateOrUpdateRoleDefinitionAsync(options);

            Assert.That(updatedDefinition.AssignableScopes, Is.EqualTo(new[] { KeyVaultRoleScope.Global }));
            Assert.That(updatedDefinition.Description, Is.EqualTo(description));
            Assert.That(updatedDefinition.Name, Is.EqualTo(name.ToString()));
            Assert.That(updatedDefinition.Permissions.First().DataActions, Is.EquivalentTo(options.Permissions[0].DataActions));
            Assert.That(updatedDefinition.Type, Is.EqualTo(KeyVaultRoleDefinitionType.MicrosoftAuthorizationRoleDefinitions));
        }

        [RecordedTest]
        public async Task DeleteRoleDefinition()
        {
            var description = Recording.GenerateAlphaNumericId("role");
            Guid name = Recording.Random.NewGuid();

            CreateOrUpdateRoleDefinitionOptions options = new(KeyVaultRoleScope.Global, name)
            {
                RoleName = name.ToString(),
                Description = description,
                Permissions =
                {
                    new()
                    {
                        DataActions =
                        {
                            KeyVaultDataAction.BackupHsmKeys,
                        }
                    }
                }
            };

            KeyVaultRoleDefinition createdDefinition = await Client.CreateOrUpdateRoleDefinitionAsync(options);
            await Client.DeleteRoleDefinitionAsync(KeyVaultRoleScope.Global, name);

            List<KeyVaultRoleDefinition> results = await Client.GetRoleDefinitionsAsync(KeyVaultRoleScope.Global).ToEnumerableAsync().ConfigureAwait(false);

            Assert.That(!results.Any(r => r.Name.ToString().Equals(name.ToString())));
        }

        [RecordedTest]
        public async Task CreateRoleAssignment()
        {
            List<KeyVaultRoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(KeyVaultRoleScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            KeyVaultRoleDefinition definitionToAssign = definitions.First(d => d.RoleName.Contains(RoleName));

            Guid roleAssignmentName = Recording.Random.NewGuid();
            KeyVaultRoleAssignment result = await Client.CreateRoleAssignmentAsync(KeyVaultRoleScope.Global, definitionToAssign.Id, TestEnvironment.ClientObjectId, roleAssignmentName).ConfigureAwait(false);

            RegisterForCleanup(result);

            Assert.That(result.Id, Is.Not.Null);
            Assert.That(result.Name, Is.Not.Null);
            Assert.That(result.Type, Is.Not.Null);
            if (Mode == RecordedTestMode.Live)
            {
                Assert.That(result.Properties.PrincipalId, Is.EqualTo(TestEnvironment.ClientObjectId));
            }

            Assert.That(result.Properties.RoleDefinitionId, Is.EqualTo(definitionToAssign.Id));
        }

        [RecordedTest]
        public async Task CreateKeysRoleAssignment()
        {
            List<KeyVaultRoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(KeyVaultRoleScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            KeyVaultRoleDefinition definitionToAssign = definitions.First(d => d.RoleName.Contains(RoleName));

            Guid roleAssignmentName = Recording.Random.NewGuid();
            KeyVaultRoleAssignment result = await Client.CreateRoleAssignmentAsync(KeyVaultRoleScope.Keys, definitionToAssign.Id, TestEnvironment.ClientObjectId, roleAssignmentName).ConfigureAwait(false);

            RegisterForCleanup(result);

            Assert.That(result.Id, Is.Not.Null);
            Assert.That(result.Name, Is.Not.Null);
            Assert.That(result.Type, Is.Not.Null);
            if (Mode == RecordedTestMode.Live)
            {
                Assert.That(result.Properties.PrincipalId, Is.EqualTo(TestEnvironment.ClientObjectId));
            }

            Assert.That(result.Properties.RoleDefinitionId, Is.EqualTo(definitionToAssign.Id));
        }

        [RecordedTest]
        public async Task CreateKeyRoleAssignment()
        {
            List<KeyVaultRoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(KeyVaultRoleScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            KeyVaultRoleDefinition definitionToAssign = definitions.First(d => d.RoleName.Contains(RoleName));

            string keyName = Recording.GenerateId();
            KeyVaultKey key = await KeyClient.CreateOctKeyAsync(new(keyName));

            Guid roleAssignmentName = Recording.Random.NewGuid();
            KeyVaultRoleAssignment result = await Client.CreateRoleAssignmentAsync(new KeyVaultRoleScope(key.Id), definitionToAssign.Id, TestEnvironment.ClientObjectId, roleAssignmentName).ConfigureAwait(false);

            RegisterForCleanup(result);

            Assert.That(result.Id, Is.Not.Null);
            Assert.That(result.Name, Is.Not.Null);
            Assert.That(result.Type, Is.Not.Null);
            if (Mode == RecordedTestMode.Live)
            {
                Assert.That(result.Properties.PrincipalId, Is.EqualTo(TestEnvironment.ClientObjectId));
            }

            Assert.That(result.Properties.RoleDefinitionId, Is.EqualTo(definitionToAssign.Id));
        }

        [RecordedTest]
        public async Task GetRoleAssignment()
        {
            List<KeyVaultRoleDefinition> definitions = await Client.GetRoleDefinitionsAsync(KeyVaultRoleScope.Global).ToEnumerableAsync().ConfigureAwait(false);
            KeyVaultRoleDefinition definitionToAssign = definitions.First(d => d.RoleName.Contains(RoleName));

            Guid roleAssignmentName = Recording.Random.NewGuid();
            KeyVaultRoleAssignment assignment = await Client.CreateRoleAssignmentAsync(KeyVaultRoleScope.Global, definitionToAssign.Id, TestEnvironment.ClientObjectId, roleAssignmentName).ConfigureAwait(false);

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
            KeyVaultRoleDefinition definitionToAssign = definitions.First(d => d.RoleName.Contains(RoleName));

            Guid roleAssignmentName = Recording.Random.NewGuid();
            KeyVaultRoleAssignment assignment = await Client.CreateRoleAssignmentAsync(KeyVaultRoleScope.Global, definitionToAssign.Id, TestEnvironment.ClientObjectId, roleAssignmentName).ConfigureAwait(false);

            await Client.DeleteRoleAssignmentAsync(KeyVaultRoleScope.Global, assignment.Name).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task DeleteNonexistentRoleAssignment()
        {
            Guid name = Recording.Random.NewGuid();

            Response response = await Client.DeleteRoleAssignmentAsync(KeyVaultRoleScope.Global, name.ToString());
            Assert.AreEqual(404, response.Status);

            JsonDocument json = JsonDocument.Parse(response.Content);
            KeyVaultServiceError error = KeyVaultServiceError.DeserializeKeyVaultServiceError(json.RootElement.GetProperty("error"), ModelSerializationExtensions.WireOptions);
            Assert.AreEqual("RoleAssignmentNotFound", error.Code);
        }

        [RecordedTest]
        public async Task DeleteNonexistentRoleDefinition()
        {
            Guid name = Recording.Random.NewGuid();

            Response response = await Client.DeleteRoleDefinitionAsync(KeyVaultRoleScope.Global, name);
            Assert.AreEqual(404, response.Status);

            JsonDocument json = JsonDocument.Parse(response.Content);
            KeyVaultServiceError error = KeyVaultServiceError.DeserializeKeyVaultServiceError(json.RootElement.GetProperty("error"), ModelSerializationExtensions.WireOptions);
            Assert.AreEqual("RoleDefinitionNotFound", error.Code);
        }
    }
}
