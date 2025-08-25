// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// Options to create or update a role definition passed to <see cref="KeyVaultAccessControlClient.CreateOrUpdateRoleDefinition(CreateOrUpdateRoleDefinitionOptions, System.Threading.CancellationToken)"/>
    /// or <see cref="KeyVaultAccessControlClient.CreateOrUpdateRoleDefinitionAsync(CreateOrUpdateRoleDefinitionOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class CreateOrUpdateRoleDefinitionOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrUpdateRoleDefinitionOptions"/> class using a generated role definition name.
        /// </summary>
        /// <param name="roleScope">The <see cref="KeyVaultRoleScope"/> to which the definition applies.</param>
        public CreateOrUpdateRoleDefinitionOptions(KeyVaultRoleScope roleScope)
            : this(roleScope, Guid.NewGuid())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrUpdateRoleDefinitionOptions"/> class using the specified role definition name.
        /// </summary>
        /// <param name="roleScope">The <see cref="KeyVaultRoleScope"/> to which the definition applies.</param>
        /// <param name="roleDefinitionName">The unique role definition name. If the named role definition is already defined it will be updated.</param>
        public CreateOrUpdateRoleDefinitionOptions(KeyVaultRoleScope roleScope, Guid roleDefinitionName)
        {
            RoleScope = roleScope;
            RoleDefinitionName = roleDefinitionName;

            Permissions = new List<KeyVaultPermission>();
            AssignableScopes = new List<KeyVaultRoleScope>();
        }

        /// <summary>
        /// Gets the <see cref="KeyVaultRoleScope"/> to which this definition applies.
        /// </summary>
        public KeyVaultRoleScope RoleScope { get; }

        /// <summary>
        /// Gets the unique role definition name.
        /// </summary>
        public Guid RoleDefinitionName { get; }

        /// <summary>
        /// Gets the display name of this role definition.
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets a description of this role definition.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets a list of permissions granted by this role definition when assigned to a principal.
        /// </summary>
        public IList<KeyVaultPermission> Permissions { get; }

        /// <summary>
        /// Gets a list of scopes for which this role definition can be assigned.
        /// </summary>
        public IList<KeyVaultRoleScope> AssignableScopes { get; }

        /// <summary>
        /// Converts this instance of <see cref="CreateOrUpdateRoleDefinitionOptions"/> to a <see cref="RoleDefinitionProperties"/> object.
        /// </summary>
        /// <returns></returns>
        internal RoleDefinitionCreateParameters ToParameters(KeyVaultRoleType roleType)
        {
            RoleDefinitionProperties properties = new()
            {
                RoleType = roleType,
                RoleName = RoleName,
                Description = Description,
            };

            foreach (KeyVaultPermission permission in Permissions)
            {
                properties.Permissions.Add(permission);
            }

            foreach (KeyVaultRoleScope scope in AssignableScopes)
            {
                properties.AssignableScopes.Add(scope);
            }

            return new(properties);
        }
    }
}
