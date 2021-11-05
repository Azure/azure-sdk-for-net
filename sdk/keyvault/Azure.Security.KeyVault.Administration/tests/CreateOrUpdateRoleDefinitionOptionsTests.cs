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

            Assert.AreEqual(KeyVaultRoleScope.Global, options.RoleScope);
            Assert.AreNotEqual(Guid.Empty, options.RoleDefinitionName);
        }

        [Test]
        public void CreatesWithGuid()
        {
            Guid roleDefinitionName = Guid.NewGuid();

            CreateOrUpdateRoleDefinitionOptions options = new(KeyVaultRoleScope.Global, roleDefinitionName);

            Assert.AreEqual(KeyVaultRoleScope.Global, options.RoleScope);
            Assert.AreEqual(roleDefinitionName, options.RoleDefinitionName);
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

            Assert.AreEqual(KeyVaultRoleType.CustomRole, parameters.Properties.RoleType);
            Assert.AreEqual("Test Role Definition", parameters.Properties.RoleName);
            Assert.AreEqual("This is only a test.", parameters.Properties.Description);
            Assert.AreEqual(1, parameters.Properties.Permissions.Count);
            CollectionAssert.AreEqual(parameters.Properties.Permissions[0].DataActions, new[] { KeyVaultDataAction.BackupHsmKeys });
            CollectionAssert.AreEqual(parameters.Properties.AssignableScopes, new[] { KeyVaultRoleScope.Global });
        }
    }
}
