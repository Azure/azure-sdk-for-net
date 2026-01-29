// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Security.KeyVault.Administration.Models;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class CreateOrUpdateRoleDefinitionOptionsTests
    {
        [Test]
        public void CreatesNewGuid()
        {
            CreateOrUpdateRoleDefinitionOptions options = new(KeyVaultRoleScope.Global);

            Assert.That(options.RoleScope, Is.EqualTo(KeyVaultRoleScope.Global));
            Assert.That(options.RoleDefinitionName, Is.Not.Empty);
        }

        [Test]
        public void CreatesWithGuid()
        {
            Guid roleDefinitionName = Guid.NewGuid();

            CreateOrUpdateRoleDefinitionOptions options = new(KeyVaultRoleScope.Global, roleDefinitionName);

            Assert.That(options.RoleScope, Is.EqualTo(KeyVaultRoleScope.Global));
            Assert.That(options.RoleDefinitionName, Is.EqualTo(roleDefinitionName));
        }

        [Test]
        public void ToPermissions()
        {
            Guid roleDefinitionName = Guid.NewGuid();

            CreateOrUpdateRoleDefinitionOptions options = new(KeyVaultRoleScope.Global, roleDefinitionName)
            {
                RoleName = "Test Role Definition",
                Description = "This is only a test.",
                Permissions =
                {
                    new()
                    {
                        DataActions =
                        {
                            KeyVaultDataAction.BackupHsmKeys,
                        },
                    },
                },
                AssignableScopes =
                {
                    KeyVaultRoleScope.Global,
                },
            };

            RoleDefinitionCreateParameters parameters = options.ToParameters(KeyVaultRoleType.CustomRole);

            Assert.That(parameters.Properties.RoleType, Is.EqualTo(KeyVaultRoleType.CustomRole));
            Assert.That(parameters.Properties.RoleName, Is.EqualTo("Test Role Definition"));
            Assert.That(parameters.Properties.Description, Is.EqualTo("This is only a test."));
            Assert.That(parameters.Properties.Permissions.Count, Is.EqualTo(1));
            Assert.That(new[] { KeyVaultDataAction.BackupHsmKeys }, Is.EqualTo(parameters.Properties.Permissions[0].DataActions).AsCollection);
            Assert.That(new[] { KeyVaultRoleScope.Global }, Is.EqualTo(parameters.Properties.AssignableScopes).AsCollection);
        }
    }
}
