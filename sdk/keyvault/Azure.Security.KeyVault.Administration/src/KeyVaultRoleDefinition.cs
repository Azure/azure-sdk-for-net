// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary> A Key Vault role definition. </summary>
    [CodeGenType("RoleDefinition")]
    public partial class KeyVaultRoleDefinition
    {
        /// <summary> Role definition properties. </summary>
        internal RoleDefinitionProperties Properties { get; }

        /// <summary> The role name. </summary>
        public string RoleName
        {
            get
            {
                return Properties.RoleName;
            }
            set
            {
                Properties.RoleName = value;
            }
        }

        /// <summary> The role definition description. </summary>
        public string Description
        {
            get
            {
                return Properties.Description;
            }
            set
            {
                Properties.Description = value;
            }
        }

        /// <summary> The role type. </summary>
        public KeyVaultRoleType? RoleType
        {
            get
            {
                return Properties.RoleType;
            }
            set
            {
                Properties.RoleType = value;
            }
        }
        /// <summary> Role definition permissions. </summary>
        public IList<KeyVaultPermission> Permissions => Properties.Permissions;
        /// <summary> Role definition assignable scopes. </summary>
        public IList<KeyVaultRoleScope> AssignableScopes => Properties.AssignableScopes;
    }
}
