﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    /// <inheritdoc/>>
    [CodeGenModel("RoleAssignment")]
    public partial class KeyVaultRoleAssignment
    {
        /// <summary> The role assignment type. </summary>
        [CodeGenMember("Type")]
        public string RoleAssignmentType { get; }
    }
}
