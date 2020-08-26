// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration.Models
{
    /// <inheritdoc/>
    public partial class RoleDefinition
    {
        /// <inheritdoc/>
        public IList<KeyVaultPermission> Permissions { get; }
        /// <inheritdoc/>
        public IList<string> AssignableScopes { get; }
    }
}
